---
title: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/net/slide-transitions/
---
Để dễ hiểu hơn, chúng tôi đã minh họa cách sử dụng Aspose.Slides for .NET để quản lý các chuyển đổi slide đơn giản. Các nhà phát triển không chỉ có thể áp dụng các hiệu ứng chuyển đổi slide khác nhau trên các slide, mà còn có thể tùy chỉnh hành vi của các hiệu ứng chuyển đổi này. Để tạo một hiệu ứng chuyển đổi slide đơn giản, hãy làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for .NET cung cấp thông qua enum **TransitionType**
- Ghi tệp bản trình chiếu đã được chỉnh sửa.
## **Ví dụ**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu

using (Presentation pres = new Presentation(FileName))

{

    //Áp dụng chuyển đổi kiểu vòng tròn cho slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Áp dụng chuyển đổi kiểu comb cho slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Áp dụng chuyển đổi kiểu zoom cho slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Ghi bản trình chiếu ra đĩa

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải Ví Dụ Đang Chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Quản lý Chuyển đổi Slides](/slides/vi/net/slide-transition/).
{{% /alert %}}