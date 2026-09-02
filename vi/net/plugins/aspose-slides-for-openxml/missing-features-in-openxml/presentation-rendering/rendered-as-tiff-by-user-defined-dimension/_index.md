---
title: Được Render Thành Tiff Theo Kích Thước Được Người Dùng Định Nghĩa
type: docs
weight: 40
url: /vi/net/rendered-as-tiff-by-user-defined-dimension/
---
Ví dụ sau đây cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu TIFF với kích thước hình ảnh được tùy chỉnh bằng lớp **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Tạo một đối tượng Presentation đại diện cho một tệp Presentation

Presentation pres = new Presentation(srcFileName);

//Tạo một thể hiện của lớp TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Thiết lập loại nén

opts.CompressionType = TiffCompressionTypes.Default;

//Các loại nén

//Mặc định - Xác định phương án nén mặc định (LZW).

//Không - Chỉ định không nén.

//CCITT3

//CCITT4

//LZW

//RLE

//Độ sâu - phụ thuộc vào loại nén và không thể được thiết lập thủ công.

//Đơn vị độ phân giải - luôn bằng "2" (điểm trên inch)

//Thiết lập DPI ảnh

opts.DpiX = 200;

opts.DpiY = 100;

//Đặt kích thước ảnh

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)