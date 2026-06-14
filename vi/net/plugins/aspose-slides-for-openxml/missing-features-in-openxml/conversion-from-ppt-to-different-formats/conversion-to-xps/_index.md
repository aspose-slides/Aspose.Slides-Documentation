---
title: Chuyển đổi sang XPS
type: docs
weight: 40
url: /vi/net/conversion-to-xps/
---
**XPS** format cũng được sử dụng rộng rãi để trao đổi dữ liệu. Aspose.Slides for .NET chú trọng đến tầm quan trọng của nó và cung cấp hỗ trợ tích hợp để chuyển đổi một bản trình chiếu thành tài liệu XPS.

Phương thức **Save** được cung cấp bởi lớp Presentation có thể được sử dụng để chuyển đổi toàn bộ bản trình chiếu thành tài liệu **XPS**. Thêm vào đó, lớp **XpsOptions** cung cấp thuộc tính **SaveMetafileAsPng** có thể đặt thành true hoặc false tùy theo yêu cầu.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu

Presentation pres = new Presentation(srcFileName);

//Lưu bản trình chiếu thành tài liệu TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)