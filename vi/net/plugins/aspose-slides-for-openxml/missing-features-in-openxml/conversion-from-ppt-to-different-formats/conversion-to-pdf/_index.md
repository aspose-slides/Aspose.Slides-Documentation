---
title: Chuyển đổi sang PDF
type: docs
weight: 30
url: /vi/net/conversion-to-pdf/
---
Tài liệu PDF được sử dụng rộng rãi như một định dạng tiêu chuẩn để trao đổi tài liệu giữa các tổ chức, các cơ quan chính phủ và cá nhân. Đây là một định dạng phổ biến, vì vậy các nhà phát triển thường được yêu cầu chuyển đổi các tệp trình chiếu Microsoft PowerPoint sang tài liệu PDF. Nhận thấy nhu cầu có thể xảy ra này, Aspose.Slides for .NET hỗ trợ chuyển đổi các bản trình chiếu sang tài liệu PDF mà không cần sử dụng bất kỳ thành phần nào khác.

**Aspose.Slides for .NET** cung cấp lớp Presentation đại diện cho một tệp trình chiếu. Lớp **Presentation** cung cấp phương thức Save có thể được gọi để chuyển đổi toàn bộ bản trình chiếu thành tài liệu **PDF**. Lớp **PdfOptions** cung cấp các tùy chọn để tạo **PDF** như JpegQuality, TextCompression, Compliance và các tùy chọn khác. Những tùy chọn này có thể được sử dụng để đạt chuẩn PDF mong muốn.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Khởi tạo một đối tượng Presentation đại diện cho một tệp trình chiếu

Presentation pres = new Presentation(srcFileName);

//Lưu bản trình chiếu thành PDF với các tùy chọn mặc định

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)