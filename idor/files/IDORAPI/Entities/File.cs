namespace IDORAPI.Entities;

public class FileModel
{
    public string? Name { get; set; }
    public string? Content { get; set; }
}

public class UploadSuccessModel
{
    public string? Link { get; set; }
}