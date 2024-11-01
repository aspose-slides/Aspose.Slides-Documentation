---
title: 创建SVG图像的幻灯片
type: docs
weight: 70
url: /zh/net/create-slide-as-svg-image/
---

要使用Aspose.Slides.Pptx for .NET从任何想要的幻灯片生成SVG图像，请按照以下步骤操作：

- 创建Presentation类的实例。
- 通过使用幻灯片的ID或索引获取所需幻灯片的引用。
- 在内存流中获取SVG图像。
- 将内存流保存为文件。
## **示例**

```

 //实例化一个表示演示文稿文件的Presentation类

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //访问第二张幻灯片

   ISlide sld = pres.Slides[1];

   //创建一个内存流对象

   MemoryStream SvgStream = new MemoryStream();

   //生成幻灯片的SVG图像并保存在内存流中

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //将内存流保存到文件中

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

有关更多详细信息，请访问[创建SVG幻灯片图像](/slides/zh/net/presentation-viewer/)。

{{% /alert %}}