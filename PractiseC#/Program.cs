using System.Collections.Generic;
using System.Globalization;

namespace PractiseC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course  course = new Course("OurAcademy");
          while (true)
            {
              MainDesc:  Console.WriteLine("1 - Qrup elave et \n 2 - Qruplari gor \n " +
              "3 - Qrupu redakte et \n 4 -  Qrupu sil \n 5 - Qrupa student elave et  \n " +
                     " 6 - Qrupdaki studentleri gor \n  7 - Kursdaki studentleri gor \n " +
               " 8 - Qrupdan student sil  \n  9 - Qrupdaki studenti editle \n " +
               " 10 - Studentler uzre axtaris \n 11 - Qiymetlendirme \n 0 -Exit");
                string input = Console.ReadLine();
                int operation ;
                bool isSuccessed = int.TryParse(input, out operation);
                if (isSuccessed)
                {
                    switch ((Operations)operation)
                    {
                        case Operations.Exit:
                            return;
                        case Operations.AddGroup:
                              GroupNamedesc: Console.WriteLine("group adini daxil edin");
                            string groupName = Console.ReadLine();
                            if (groupName.isValidGroupName())
                            {
                                if (!course.Groups.Any(n => n.Name.ToUpper() == groupName.ToUpper()))
                                {
                                   GroupLimitDesc: Console.WriteLine("qrup limitini daxil edin");
                                    input = Console.ReadLine();
                                    int limit;
                                    isSuccessed = int.TryParse(input, out limit);
                                    if (isSuccessed)
                                    {
                                        if (limit<5)
                                        {
                                            Console.WriteLine(Errormessages.MinimalLimit.Replace("{int}","5"));
                                            goto GroupLimitDesc;
                                        }
                                        if (limit>20)
                                        {
                                            Console.WriteLine(Errormessages.MaximalLimit.Replace("{int}","20"));
                                            goto GroupLimitDesc;
                                        }
                                        course.AddGroup(new Group(groupName,limit));
                                        Console.WriteLine($"{groupName} elave edildi");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","limit"));
                                        goto GroupLimitDesc;
                                    }
                                   
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.AlreadyExists.Replace("{Name}","qrup"));
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.InvalidGroupNameFormat);
                                goto GroupNamedesc;
                            }

                         break;

                        case Operations.DisplayGroups:
                            if (course.Groups.Count > 0)
                            {
                                course.GetAllGroupDetails();

                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","group"));
                            }
                            break;

                        case Operations.UpdateGroup:
                            if (course.Groups.Count == 0)
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}", "qrup"));
                                goto MainDesc;
                            }
                            Console.WriteLine("Movcud grouplar");
                            course.GetAllGroupDetails();
                            UpdateGroupDESC: Console.WriteLine("redakte etmek istediyiniz groupun Id-ni daxil edin");
                             input= Console.ReadLine();
                            int id;
                            isSuccessed = int.TryParse(input, out id);
                            if (isSuccessed)
                            {
                                var existGroupUpdate = course.Groups.FirstOrDefault(g=>g.Id==id);
                                if (existGroupUpdate != null)
                                {
                                   newGroupNameDesc: Console.WriteLine("yeni qrup adini daxil edin");
                                    string updatingName=Console.ReadLine();
                                    if (updatingName.isValidGroupName())
                                    {
                                        if (course.Groups.Any(x=>x.Name.ToLower()==updatingName.ToLower() && x.Id!= existGroupUpdate.Id))
                                        {
                                            Console.WriteLine(Errormessages.AlreadyExists.Replace("{Name}","group"));
                                            goto newGroupNameDesc;
                                        }
                                        newLimitDesc: Console.WriteLine("yeni group limiti daxil edin");
                                        input=Console.ReadLine();
                                        int newLimit;
                                        isSuccessed=int.TryParse(input, out newLimit);
                                        if (!isSuccessed)
                                        {
                                            Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                            goto newLimitDesc;
                                        }
                                        if (newLimit < 5)
                                        {
                                            Console.WriteLine(Errormessages.MinimalLimit.Replace("{int}", "5"));
                                            goto newLimitDesc;
                                        }
                                        if (newLimit > 20)
                                        {
                                            Console.WriteLine(Errormessages.MaximalLimit.Replace("{int}", "20"));
                                            goto newLimitDesc;
                                        }
                                        existGroupUpdate.Name = updatingName;
                                        existGroupUpdate.Limit = newLimit;
                                        
                                        Console.WriteLine($" qrup adi {updatingName} -e deyisdirildi limit :{newLimit} oldu");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.InvalidGroupNameFormat);
                                        goto newGroupNameDesc;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","group"));
                                    goto UpdateGroupDESC;
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                goto UpdateGroupDESC;
                            }
                            break;

                        case Operations.DeleteGroup:
                            if (course.Groups.Count>0)
                            {
                               RemoveGroupDesc: Console.WriteLine("Silmek istediyiniz qrupun id-ni daxil edin");
                                course.GetAllGroupDetails();
                                input = Console.ReadLine();
                                int removeId;
                                isSuccessed = int.TryParse(input, out removeId);
                                if (isSuccessed)
                                {
                                  var existRemoveGroup=course.Groups.Find(x=>x.Id==removeId);
                                    if(existRemoveGroup != null)
                                    {
                                        course.Groups.Remove(existRemoveGroup);
                                        Console.WriteLine(existRemoveGroup.Name +" group silindi");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","group"));
                                        goto RemoveGroupDesc;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}", "id"));
                                    goto RemoveGroupDesc;
                                }

                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","group"));
                            }
                            break;

                        case Operations.AddStudentToGroup:
                            if (course.Groups.Count > 0)
                            {
                                 AddStudentToGroupDesc:
                                Console.WriteLine(" telebe elave etmek istediyiniz qrupun adini daxil edin");
                                course.GetAllGroupDetails();
                                
                                string groupNameOfAddStudent=Console.ReadLine();
                                
                                
                                    var existGroupOfAddStudent = course.Groups.FirstOrDefault(x=>x.Name.ToLower()== groupNameOfAddStudent.ToLower()); 
                                    if(existGroupOfAddStudent != null)
                                    {
                                        if (existGroupOfAddStudent.Limit < course.Groups.Count)
                                        {
                                            Console.WriteLine(Errormessages.OutOfStudentCount);
                                            goto MainDesc;
                                        }
                                        StudentNameDesc: Console.WriteLine("Telebenin adini qeyd edin");
                                        string studentName=Console.ReadLine();
                                        if (!studentName.isValidStudentName())
                                        {
                                            Console.WriteLine(Errormessages.InvalidStudentNameFormat);
                                            goto StudentNameDesc;
                                        }
                                        StudentSurNameDesc: Console.WriteLine("Telebenin soyadini qeyd edin");
                                        string studentSurName=Console.ReadLine();
                                        if (!studentSurName.isValidStudentSurName())
                                        {
                                            Console.WriteLine(Errormessages.InvalidStudentSurNameFormat);
                                            goto StudentSurNameDesc;
                                        }
                                         StudentDateTimeDESC: Console.WriteLine("Telebenin tevelludunu qeyd edin ");
                                        var birthday=Console.ReadLine();
                                        DateTime birthdayResult;
                                        isSuccessed=
                                         DateTime.TryParseExact(birthday,"dd.MM.yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out birthdayResult);
                                        if (isSuccessed)
                                        {
                                            var student=new Student(studentName,studentSurName, birthdayResult);
                                            existGroupOfAddStudent.AddStudentToGroup(student);
                                            Console.WriteLine($"{studentName} {existGroupOfAddStudent.Name} adli qrupa elave edildi!!!");
                                        }
                                        else
                                        {
                                            Console.WriteLine(Errormessages.InvalidDateTimeFormat);
                                            goto StudentDateTimeDESC;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","ad").Replace("{name}","group"));
                                        goto AddStudentToGroupDesc;
                                    }
                                
                                
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation);
                            }
                            break;
                       
                        case Operations.DisplayStudentsOnGroup:
                            if (course.Groups.Count>0)
                            {
                              DisplayStudentsOnGroupsDesc:
                                Console.WriteLine("butun telebeleri gormek ucun herhansisa qrup id secin");
                                course.GetAllGroupDetails();
                                input = Console.ReadLine();
                                int grouDisplayId;
                                isSuccessed = int.TryParse(input, out grouDisplayId);
                                if (isSuccessed)
                                {
                                    var existGroupOfDisplayStu = course.Groups.Find(g => g.Id == grouDisplayId);
                                    if (existGroupOfDisplayStu != null)
                                    {
                                        bool hasStudents = false;
                                        foreach (var student in existGroupOfDisplayStu.Students)
                                        {
                                            Console.WriteLine(student.GetDetails());
                                            hasStudents = true;
                                        }
                                        if (!hasStudents)
                                        {
                                            Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","group"));
                                        goto DisplayStudentsOnGroupsDesc;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                    goto DisplayStudentsOnGroupsDesc;
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","group"));
                            }
                            break;

                        case Operations.DisplayStudentsOnCourse:
                            if (course.Groups.Count > 0)
                            {
                                bool hasStu=false;
                                foreach (var group in course.Groups)
                                {
                                    
                                    foreach (var student in group.Students)
                                    {
                                        Console.WriteLine(student.GetDetails()+" "+ group.Name);
                                        hasStu = true;
                                    }
                                }
                                if (!hasStu)
                                {
                                    Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","group"));
                            }
                            break;

                        case Operations.DeleteStudentFromGroup:
                            if (course.Groups.Count ==0)
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","group"));
                                goto MainDesc;
                            }
                            bool hasStudent=false;
                            foreach (var group in course.Groups)
                            {
                                if (group.Students.Count >0)
                                {
                                    hasStudent = true;
                                    break;
                                }
                            }
                            if (!hasStudent)
                            {
                                Console.WriteLine(Errormessages.NotFoundStudentOnCourse);
                                goto MainDesc;
                            }
                            GroupIdOfDeleteStudentDesc:
                            Console.WriteLine(" silinecek telebenin qrupun id-ni secin ");
                            course.GetAllGroupDetails();
                            input= Console.ReadLine();
                            isSuccessed=int.TryParse(input,out id);
                            if (isSuccessed)
                            {
                                var existGroupOfDeleteStudent=course.Groups.FirstOrDefault(x=> x.Id==id);
                                if (existGroupOfDeleteStudent != null)
                                {
                                    if (existGroupOfDeleteStudent.Students.Count==0)
                                    {
                                        Console.WriteLine(Errormessages.NotFoundStudentOnGroup);
                                        goto GroupIdOfDeleteStudentDesc;
                                    }
                                     RemoveStudentDesc: Console.WriteLine("silmek istediyiniz telebenin id-ni daxil edin ");
                                    foreach (var stu in existGroupOfDeleteStudent.Students)
                                    {
                                        Console.WriteLine(stu.GetDetails());
                                    }
                                    
                                    input = Console.ReadLine();
                                    isSuccessed = int.TryParse(input,out id);
                                    if (isSuccessed)
                                    {
                                      var student= existGroupOfDeleteStudent.Students.FirstOrDefault(s=>s.Id==id);
                                        if (student!=null)
                                        {
                                            existGroupOfDeleteStudent.Students.Remove(student);
                                            Console.WriteLine("telebe silindi");
                                        }
                                        else
                                        {
                                                Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","student"));
                                            goto RemoveStudentDesc;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                        goto RemoveStudentDesc;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","group"));
                                    goto GroupIdOfDeleteStudentDesc;
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                goto GroupIdOfDeleteStudentDesc;
                            }
                            break;

                        case Operations.UpdateStudentOnGroup:
                            if (course.Groups.Count==0)
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","qrup"));
                                goto MainDesc;
                            }
                            bool hasStud = false;
                            foreach (var gr in course.Groups)
                            {
                                foreach (var s in gr.Students)
                                {
                                    hasStud = true;
                                }
                            }
                            if (!hasStud)
                            {
                                Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                goto MainDesc;
                            }
                             GroupNameDesc: Console.WriteLine("redakte etmek istediyiniz studentin qrupunun adini daxil edin");
                            course.GetAllGroupDetails();
                            string groupNameOfUpdateStudent=Console.ReadLine();
                            var existGroup=course.Groups.FirstOrDefault(g=>g.Name==groupNameOfUpdateStudent);
                            if (existGroup != null)
                            {
                                
                                if (existGroup.Students.Count==0)
                                {
                                    Console.WriteLine(Errormessages.NotFoundStudentOnGroup);
                                    goto GroupNameDesc;
                                }
                                    UpdateStudentIdDESC:
                                Console.WriteLine("redakte edilecek telebe id-ni daxil edin");
                                foreach (var stu in existGroup.Students)
                                {
                                    Console.WriteLine($"Id : {stu.Id} Name : {stu.Name}");
                                }
                                
                                input=Console.ReadLine();
                                isSuccessed = int.TryParse(input, out id);
                                if (isSuccessed)
                                {
                                    var newStudent=existGroup.Students.FirstOrDefault(f=>f.Id==id);
                                    if (newStudent != null)
                                    {
                                        NewNameDesc: Console.WriteLine(" yeni adi daxil edin");
                                        string newName=Console.ReadLine();
                                        if (!newName.isValidStudentName())
                                        {
                                            Console.WriteLine(Errormessages.InvalidStudentNameFormat);
                                            goto NewNameDesc;
                                        }
                                          NewSurNameDesc: Console.WriteLine("yeni soyadi daxil edin");
                                        string newSurName=Console.ReadLine();
                                        if (!newSurName.isValidStudentSurName())
                                        {
                                            Console.WriteLine(Errormessages.InvalidStudentSurNameFormat);
                                            goto NewSurNameDesc;
                                        }
                                        Console.WriteLine("tevellud deyisdirilecekse ' he ' daxil edin eks halda her hansisa tushu girin");
                                        string answer=Console.ReadLine();
                                        if (answer=="he")
                                        {
                                           NewDateTimeDesc: Console.WriteLine("yenilenmis tarixi girin (dd.MM.yyyy)");
                                            string newBirthday = Console.ReadLine();
                                            DateTime newBirthdayResult;
                                          isSuccessed=  DateTime.TryParseExact(newBirthday, "dd.MM.yyyy",
                                            CultureInfo.InvariantCulture,DateTimeStyles.None,out newBirthdayResult);
                                            if (!isSuccessed)
                                            {
                                                Console.WriteLine(Errormessages.InvalidDateTimeFormat);
                                                goto NewDateTimeDesc;
                                            }
                                            newStudent.BirthDay = newBirthdayResult;
                                        }
                                        newStudent.Name = newName;
                                        newStudent.SurName=newSurName;
                                        Console.WriteLine("telbe melumatlari yenilendi");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","telebe"));
                                        goto UpdateStudentIdDESC;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                    goto UpdateStudentIdDESC;
                                }
                            }
                            else
                            {
                                Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","group adi").Replace("{name}","group"));
                                goto GroupNameDesc;
                            }

                            break;

                        case Operations.SearchStudent:
                            if (course.Groups.Count == 0)
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","qrup"));
                                goto MainDesc;
                            }
                            Console.WriteLine("axtaris ucun ad daxil edin");
                           
                            input= Console.ReadLine();
                            bool foundName=false;
                            foreach (var searchGroup in course.Groups)
                            {
                                foreach (var stu in searchGroup.Students)
                                {
                                    if (stu.Name.ToLower()==input.ToLower())
                                    {
                                        Console.WriteLine($"Id : {stu.Id} Name :{stu.SurName} Birthday : {stu.BirthDay}");
                                        foundName = true;
                                    }
                                }
                            }
                            if (!foundName)
                            {
                                Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                goto MainDesc;
                            }
                            break;

                        case Operations.AddGradeToStudent:
                            if (course.Groups.Count ==0)
                            {
                                Console.WriteLine(Errormessages.NotFoundElementOfOperation.Replace("{name}","group"));
                                goto MainDesc;
                            }
                            bool hasStudentOfGrade=false;
                            foreach (var g in course.Groups)
                            {
                                foreach (var s in g.Students)
                                {
                                    hasStudentOfGrade= true;
                                }
                            }
                            if (!hasStudentOfGrade)
                            {
                                Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                goto MainDesc;
                            }
                            GradetingStuDESC:  Console.WriteLine("telebeni qiymetlendirmek ucun once qrup id-ni daxil edin");
                            course.GetAllGroupDetails();
                            input = Console.ReadLine();
                            int groupIdForGrade;
                            isSuccessed=int.TryParse(input, out groupIdForGrade);
                            if (isSuccessed)
                            {
                                var existGroupForGrade = course.Groups.FirstOrDefault(g => g.Id==groupIdForGrade);
                                if (existGroupForGrade is not null) 
                                {
                                    if (existGroupForGrade.Students.Count==0)
                                    {
                                        Console.WriteLine(Errormessages.NotFoundElement.Replace("{name}","telebe"));
                                        goto GradetingStuDESC;
                                    }
                                     StudentGradetingDEsc: Console.WriteLine("qiymet elave etmek istdeyiniz studentin id-ni daxil edin");

                                    foreach (var student in existGroupForGrade.Students)
                                    {
                                        Console.WriteLine(student.GetDetails());
                                    }
                                    input = Console.ReadLine();
                                    int studentIdForGrade;
                                    isSuccessed = int.TryParse(input,out studentIdForGrade);
                                    if(isSuccessed)
                                    {
                                        var existStudent = existGroupForGrade.Students.FirstOrDefault(e=>e.Id== studentIdForGrade);
                                        if (existStudent is not null)
                                        {
                                            Console.WriteLine("fenn adini daxil edin");
                                              gradeNameDesc: string gradeName=Console.ReadLine();
                                            if (!!gradeName.isValidStudentGradeName())
                                            {
                                                Console.WriteLine(Errormessages.InvalidStudentGradeNameFormat);
                                                goto gradeNameDesc;
                                            }

                                            GradeDesc:  Console.WriteLine("bali daxil edin");
                                            input = Console.ReadLine();
                                            int grade;
                                            isSuccessed = (int.TryParse(input, out grade));
                                            if (isSuccessed)
                                            {
                                                if (grade>=0 && grade<=100)
                                                {
                                                    if (!existStudent.Grades.ContainsKey(gradeName))
                                                    {
                                                        existStudent.Grades[gradeName] = new List<double>();
                                                    }
                                                    existStudent.Grades[gradeName].Add(grade);
                                                    Console.WriteLine("qiymetlendirme ugurla heyata kecirildi!!!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(Errormessages.RangeOfStudentGrade);
                                                    goto GradeDesc;
                                                }
                                            }
                                            else 
                                            {
                                                Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","bal"));
                                                goto GradeDesc;
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","telebe"));
                                            goto StudentGradetingDEsc;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}", "id"));
                                        goto StudentGradetingDEsc;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine(Errormessages.NotFoundForInput.Replace("{prop}","id").Replace("{name}","group"));
                                    goto GradetingStuDESC;
                                }

                            }
                            else
                            {
                                Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","id"));
                                goto GradetingStuDESC;
                            }
                            break;
                    
                    }
                }
                else
                {
                    Console.WriteLine(Errormessages.InvalidIntFormat.Replace("{int}","operator"));
                }
            }
        }
    }
}
