---
title: Chuyển đổi sang HTML
type: docs
weight: 20
url: /vi/net/conversion-to-html/
---
**HTML** là một trong những định dạng được sử dụng rộng rãi để trao đổi dữ liệu. **Aspose.Slides for .NET** cung cấp hỗ trợ chuyển đổi một bài thuyết trình sang HTML. Dưới đây là đoạn mã mẫu cho thấy cách thực hiện.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Lưu bài thuyết trình sang HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)