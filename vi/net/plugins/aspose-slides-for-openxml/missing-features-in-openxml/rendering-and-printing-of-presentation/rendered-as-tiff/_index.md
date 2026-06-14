---
title: Kết xuất dưới dạng Tiff
type: docs
weight: 30
url: /vi/net/rendered-as-tiff/
---
Định dạng TIFF được biết đến với tính linh hoạt trong việc hỗ trợ hình ảnh đa trang và dữ liệu. Nhận thấy tầm quan trọng và sự phổ biến của định dạng TIFF, Aspose.Slides for .NET cung cấp hỗ trợ chuyển đổi các bản trình chiếu thành tài liệu TIFF.  
Bài viết này giải thích các tùy chọn xuất TIFF khác nhau:

- Chuyển đổi Presentation sang TIFF với kích thước mặc định.  
- Chuyển đổi Presentation sang TIFF với kích thước tùy chỉnh.

Phương thức **Save** được cung cấp bởi lớp **Presentation** có thể được các nhà phát triển gọi để chuyển đổi toàn bộ bản trình chiếu thành tài liệu **TIFF**. Ngoài ra, lớp TiffOptions cung cấp thuộc tính ImageSize cho phép nhà phát triển xác định kích thước của hình ảnh nếu cần.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Khởi tạo một đối tượng Presentation đại diện cho tệp trình chiếu

using (Presentation pres = new Presentation(srcFileName))

{

    //Lưu trình chiếu dưới dạng tài liệu TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Tải xuống mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)