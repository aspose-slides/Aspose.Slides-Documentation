---
title: Tạo hình thu nhỏ slide dưới dạng JPEG
type: docs
weight: 90
url: /vi/net/generate-slide-thumbnail-as-jpeg/
---
Để tạo thumbnail của bất kỳ slide nào mong muốn bằng Aspose.Slides cho .NET:

- Tạo một thể hiện của lớp Presentation.
- Lấy tham chiếu của bất kỳ slide nào mong muốn bằng cách sử dụng ID hoặc chỉ mục của nó.
- Lấy hình ảnh thumbnail của slide đã tham chiếu với tỷ lệ đã chỉ định.
- Lưu hình ảnh thumbnail dưới bất kỳ định dạng ảnh nào mong muốn.
## **Ví dụ**
```cs
//Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    //Tạo hình ảnh tỷ lệ đầy đủ
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Lưu hình ảnh vào đĩa ở định dạng JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Để biết thêm chi tiết, vui lòng truy cập [Chuyển đổi PPT và PPTX sang JPG trong .NET](/slides/vi/net/convert-powerpoint-to-jpg/).

{{% /alert %}}