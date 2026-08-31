---
title: Xuất dưới dạng Tiff
type: docs
weight: 30
url: /vi/net/rendered-as-tiff/
---
Định dạng TIFF được biết đến với tính linh hoạt cho phép chứa nhiều trang hình ảnh và dữ liệu. Nhìn vào tầm quan trọng và độ phổ biến của định dạng TIFF, Aspose.Slides for .NET cung cấp hỗ trợ chuyển đổi các bài thuyết trình sang tài liệu TIFF.
Bài viết này giải thích cách sử dụng các tùy chọn xuất TIFF khác nhau:

- Chuyển đổi bài thuyết trình sang TIFF với kích thước mặc định.
- Chuyển đổi bài thuyết trình sang TIFF với kích thước tùy chỉnh.

Phương thức **Save** được cung cấp bởi lớp **Presentation** có thể được các nhà phát triển gọi để chuyển đổi toàn bộ bài thuyết trình thành tài liệu **TIFF**. Thêm nữa, lớp TiffOptions cung cấp thuộc tính ImageSize cho phép nhà phát triển xác định kích thước của hình ảnh nếu cần.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu

using (Presentation pres = new Presentation(srcFileName))

{

    //Lưu bản trình chiếu thành tài liệu TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)