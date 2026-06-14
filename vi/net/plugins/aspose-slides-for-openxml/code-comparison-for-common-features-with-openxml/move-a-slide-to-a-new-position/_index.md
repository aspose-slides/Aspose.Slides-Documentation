---
title: Di chuyển một slide tới vị trí mới
type: docs
weight: 140
url: /vi/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Đếm các slide trong bản trình chiếu.
public static int CountSlides(string presentationFile)

{

    // Mở bản trình chiếu dưới dạng chỉ đọc.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Gửi bản trình chiếu tới phương thức CountSlides tiếp theo
        // và trả về số lượng slide.
        return CountSlides(presentationDocument);

    }

}

// Đếm các slide trong bản trình chiếu.
public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kiểm tra đối tượng tài liệu null.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Lấy phần trình chiếu của tài liệu.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy số lượng slide từ SlideParts.
    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Trả về số lượng slide cho phương thức trước.
    return slidesCount;

}

// Di chuyển một slide tới vị trí khác trong thứ tự slide của bản trình chiếu.
public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Di chuyển một slide tới vị trí khác trong thứ tự slide của bản trình chiếu.
public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Gọi phương thức CountSlides để lấy số lượng slide trong bản trình chiếu.
    int slidesCount = CountSlides(presentationDocument);

    // Xác minh rằng cả vị trí from và to đều nằm trong phạm vi và khác nhau.
    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Lấy phần trình chiếu từ tài liệu trình chiếu.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Số lượng slide không bằng không, vì vậy bản trình chiếu phải có slide.            
    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Lấy ID slide của slide nguồn.
    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Xác định vị trí của slide đích mà sau đó sẽ di chuyển slide nguồn.
    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Xóa slide nguồn khỏi vị trí hiện tại.
    sourceSlide.Remove();

    // Chèn slide nguồn vào vị trí mới sau slide đích.
    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Lưu bản trình chiếu đã chỉnh sửa.
    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Di chuyển một slide tới vị trí khác trong thứ tự slide của bản trình chiếu.
public static void MoveSlide(string presentationFile, int from, int to)

{

    // Khởi tạo lớp PresentationEx để tải tệp PPTX nguồn
    using (Presentation pres = new Presentation(presentationFile))

    {

        // Lấy slide mà vị trí cần được thay đổi
        ISlide sld = pres.Slides[from];
        ISlide sld2 = pres.Slides[to];
        // Đặt vị trí mới cho slide
        sld2.SlideNumber = from;
        sld.SlideNumber = to;
        // Ghi tệp PPTX ra đĩa
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);
    }

}
``` 
## **Tải xuống mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)