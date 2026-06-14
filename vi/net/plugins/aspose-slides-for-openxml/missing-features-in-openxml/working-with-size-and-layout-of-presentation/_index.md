---
title: Làm việc với Kích thước và Bố cục của Bản trình chiếu
type: docs
weight: 90
url: /vi/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** và **SlideSize.Size** là các thuộc tính của lớp Presentation có thể được đặt hoặc lấy như được minh họa trong ví dụ dưới đây.

## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu 
Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Đặt kích thước slide của bản trình chiếu được tạo thành kích thước của bản gốc
auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Lưu Presentation vào đĩa
auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 

## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)

## **Tải ví dụ chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Thay đổi kích thước slide của bản trình chiếu trong .NET](/slides/vi/net/slide-size/).
{{% /alert %}}