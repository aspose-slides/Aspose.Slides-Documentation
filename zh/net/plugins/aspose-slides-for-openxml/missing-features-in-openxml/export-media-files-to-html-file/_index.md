---
title: 将媒体文件导出为 HTML 文件
type: docs
weight: 40
url: /zh/net/export-media-files-to-html-file/
---

为了将媒体文件导出为 HTML，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 获取幻灯片的引用
- 设置切换效果
- 将演示文稿写入 PPTX 文件

在下面的示例中，我们已将媒体文件导出为 HTML。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
欲了解更多详情，请访问 [导出媒体文件到 HTML 文件](/slides/zh/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)。
{{% /alert %}}