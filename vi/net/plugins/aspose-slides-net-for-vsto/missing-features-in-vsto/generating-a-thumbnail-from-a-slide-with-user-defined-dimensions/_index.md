---
title: Tạo Thumbnail từ Slide với Kích Thước Được Xác Định Bởi Người Dùng
type: docs
weight: 100
url: /vi/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Để tạo thumbnail cho bất kỳ slide nào mong muốn bằng Aspose.Slides for .NET:

- Tạo một thể hiện của lớp Presentation.
- Lấy tham chiếu của bất kỳ slide nào mong muốn bằng cách sử dụng ID hoặc chỉ mục của nó.
- Lấy các hệ số tỉ lệ X và Y dựa trên kích thước X và Y do người dùng xác định.
- Lấy hình ảnh thumbnail của slide đã tham chiếu ở tỉ lệ đã chỉ định.
- Lưu hình ảnh thumbnail dưới bất kỳ định dạng ảnh nào mong muốn.
## **Ví dụ**
```cs
//Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    //Kích thước do người dùng xác định
    int desiredX = 1200;
    int desiredY = 800;

    //Lấy giá trị tỷ lệ của X và Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Tạo hình ảnh tỷ lệ đầy đủ
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Lưu hình ảnh vào đĩa ở định dạng JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Tải Mã Mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Chuyển Đổi Slide](/slides/vi/net/convert-slide/).
{{% /alert %}}