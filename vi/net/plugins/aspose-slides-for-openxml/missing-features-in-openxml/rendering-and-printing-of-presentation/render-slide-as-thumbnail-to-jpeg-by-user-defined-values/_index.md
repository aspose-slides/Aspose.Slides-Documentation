---
title: Kết xuất slide thành ảnh thu nhỏ JPEG bằng các giá trị do người dùng định nghĩa
type: docs
weight: 70
url: /vi/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Để tạo ảnh thu nhỏ của bất kỳ slide nào mong muốn bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp **Presentation**.
1. Lấy tham chiếu của slide mong muốn bằng cách sử dụng ID hoặc chỉ mục của nó.
1. Lấy các hệ số tỉ lệ X và Y dựa trên kích thước X và Y do người dùng xác định.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu ở tỷ lệ xác định.
1. Lưu ảnh thu nhỏ ở bất kỳ định dạng hình ảnh nào mong muốn.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
using (Presentation pres = new Presentation(srcFileName))
{
    //Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    //Kích thước do người dùng định nghĩa
    int desiredX = 1200;
    int desiredY = 800;

    //Lấy giá trị tỉ lệ của X và Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Tạo ảnh tỷ lệ đầy đủ
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Lưu ảnh vào đĩa ở định dạng JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Tải về Mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)