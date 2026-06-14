---
title: Chuyển đổi bản trình chiếu sang HTML
type: docs
weight: 40
url: /vi/net/convert-presentation-to-html/
---
**HTML** là một trong nhiều định dạng được sử dụng rộng rãi để trao đổi dữ liệu. **Aspose.Slides for .NET** cung cấp hỗ trợ chuyển đổi một bản trình chiếu sang HTML. Dưới đây là đoạn mã mẫu cho thấy cách thực hiện.  
## **Ví dụ**
``` 
 //Tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Lưu bản trình chiếu sang HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);
``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Chuyển đổi bài thuyết trình PowerPoint sang HTML trong .NET](/slides/vi/net/convert-powerpoint-to-html/).
{{% /alert %}}