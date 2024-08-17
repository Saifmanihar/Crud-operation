namespace Forms_CRUD_.ViewModels
{
    public class StudentEditViewModel:StudentCreateViewModel
    {
        public new int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
