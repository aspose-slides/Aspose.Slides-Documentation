---
title: Xuất tệp đa phương tiện sang tệp HTML
type: docs
weight: 80
url: /vi/net/export-media-files-into-html-file/
---
Để xuất các tệp đa phương tiện sang HTML, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của slide
- Thiết lập hiệu ứng chuyển tiếp
- Ghi bài thuyết trình dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã xuất các tệp đa phương tiện sang HTML.
## **Ví dụ**
``` 
 //Đang tải bản trình bày

using (Presentation pres = new Presentation("example.pptx"))
{
   const string path = "path";
   const string fileName = "video.html";
   const string baseUri = "http://www.example.com/";
   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);
   //Cài đặt tùy chọn HTML
   HtmlOptions htmlOptions = new HtmlOptions(controller);
   SVGOptions svgOptions = new SVGOptions(controller);
   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);
   //Lưu tệp
   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);
}
``` 
## **Tải ví dụ đang chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)