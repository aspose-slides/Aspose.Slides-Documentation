---
title: Xuất tệp phương tiện sang tệp HTML
type: docs
weight: 40
url: /vi/net/export-media-files-to-html-file/
---
Để xuất tệp phương tiện ra HTML, vui lòng thực hiện các bước bên dưới:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của slide
- Đặt hiệu ứng chuyển tiếp
- Ghi bài thuyết trình dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã xuất các tệp phương tiện sang HTML.
## **Ví dụ**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Tải trình chiếu

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Cài đặt tùy chọn HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Lưu tệp

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải ví dụ chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Để biết thêm chi tiết, hãy truy cập [Xuất tệp phương tiện sang tệp HTML](/slides/vi/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}