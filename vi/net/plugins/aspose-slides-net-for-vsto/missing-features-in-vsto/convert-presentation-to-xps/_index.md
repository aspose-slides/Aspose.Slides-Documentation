---
title: Chuyển đổi bản trình bày sang XPS
type: docs
weight: 60
url: /vi/net/convert-presentation-to-xps/
---
**XPS** format cũng được sử dụng rộng rãi để trao đổi dữ liệu. Aspose.Slides for .NET chú trọng tới tầm quan trọng của nó và cung cấp hỗ trợ tích hợp để chuyển đổi bản trình bày thành tài liệu **XPS**.

Phương thức **Save** được khai báo bởi lớp Presentation có thể được sử dụng để chuyển đổi toàn bộ bản trình bày thành tài liệu **XPS**. Ngoài ra, lớp **XpsOptions** cung cấp thuộc tính **SaveMetafileAsPng** có thể được đặt thành true hoặc false tùy theo yêu cầu.
## **Example**

``` 

 //Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày

Presentation pres = new Presentation("Conversion.ppt");

//Lưu bản trình bày thành tài liệu TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Chuyển đổi bản trình bày PowerPoint sang XPS trong .NET](/slides/vi/net/convert-powerpoint-to-xps/).
{{% /alert %}}