---
title: Render Slide dưới dạng ảnh thu nhỏ sang JPEG
type: docs
weight: 60
url: /vi/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** được sử dụng để tạo tệp trình chiếu chứa các slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Nhưng đôi khi, các nhà phát triển có thể cần xem slide dưới dạng hình ảnh bằng trình xem ảnh yêu thích của họ. Trong những trường hợp như vậy, Aspose.Slides for .NET giúp bạn tạo ảnh thu nhỏ của các slide.

Để tạo ảnh thu nhỏ của bất kỳ slide nào mong muốn bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp **Presentation**.
1. Lấy tham chiếu của bất kỳ slide nào mong muốn bằng cách sử dụng ID hoặc chỉ mục của nó.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu ở tỉ lệ nhất định.
1. Lưu ảnh thu nhỏ ở bất kỳ định dạng hình ảnh nào mong muốn.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
using (Presentation pres = new Presentation(srcFileName))
{
    //Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    //Tạo ảnh với tỷ lệ đầy đủ
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Lưu ảnh ra đĩa ở định dạng JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Tải xuống mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)