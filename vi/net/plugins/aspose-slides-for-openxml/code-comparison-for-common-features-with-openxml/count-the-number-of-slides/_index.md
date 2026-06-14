---
title: Đếm số lượng Slides
type: docs
weight: 50
url: /vi/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Lấy đối tượng trình chiếu và truyền nó cho phương thức CountSlides tiếp theo.

public static int CountSlides(string presentationFile)

{

    // Mở trình chiếu ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Truyền trình chiếu cho phương thức CountSlide tiếp theo

        // và trả về số lượng slide.

        return CountSlides(presentationDocument);

    }

}

// Đếm số slide trong trình chiếu.

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

    // Lấy số slide từ SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Trả về số slide cho phương thức trước.

    return slidesCount;

} 
```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Khởi tạo một đối tượng PresentationEx đại diện cho tệp PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

```
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)