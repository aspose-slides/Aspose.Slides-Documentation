---
title: Được Kết Xuất Dưới Dạng Tiff Với Kích Thước Được Xác Định Bởi Người Dùng
type: docs
weight: 40
url: /vi/net/rendered-as-tiff-by-user-defined-dimension/
---
Ví dụ sau đây cho thấy cách chuyển đổi một bản trình chiếu thành tài liệu TIFF với kích thước hình ảnh tùy chỉnh bằng lớp **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Khởi tạo một đối tượng Presentation đại diện cho tệp tin Presentation

Presentation pres = new Presentation(srcFileName);

//Khởi tạo lớp TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Đặt loại nén

opts.CompressionType = TiffCompressionTypes.Default;

//Các loại nén

//Default - Chỉ định sơ đồ nén mặc định (LZW).

//None - Chỉ định không nén.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - phụ thuộc vào loại nén và không thể đặt thủ công.

//Resolution unit - luôn bằng "2" (điểm trên mỗi inch)

//Đặt DPI cho hình ảnh

opts.DpiX = 200;

opts.DpiY = 100;

//Đặt kích thước hình ảnh

opts.ImageSize = new Size(1728, 1078);

//Lưu bản trình chiếu thành TIFF với kích thước hình ảnh đã chỉ định

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)