---
title: 导出媒体文件到HTML文件
type: docs
weight: 40
url: /zh/net/export-media-files-to-html-file/
---

为了将媒体文件导出到HTML，请按照以下步骤操作：

- 创建一个Presentation类的实例
- 获取幻灯片的引用
- 设置过渡效果
- 将演示文稿写为PPTX文件

在下面给出的例子中，我们已将媒体文件导出到HTML。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//加载演示文稿

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //设置HTML选项

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //保存文件

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **下载运行示例**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

欲了解更多细节，请访问 [导出媒体文件到html文件](/slides/zh/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)。

{{% /alert %}}