---
title: 导出媒体文件为HTML文件
type: docs
weight: 80
url: /zh/net/export-media-files-into-html-file/
---

为将媒体文件导出为HTML，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 获取幻灯片的引用
- 设置切换效果
- 将演示文稿写入 PPTX 文件

在下面的示例中，我们已将媒体文件导出为HTML。
## **示例**
``` 

 //Loading a presentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Setting HTML options

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Saving the file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **下载运行示例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)