---
title: 将幻灯片创建为 SVG 图像
type: docs
weight: 70
url: /zh/net/create-slide-as-svg-image/
---

要使用 Aspose.Slides.Pptx for .NET 从任意所需幻灯片生成 SVG 图像，请按以下步骤操作：

- 创建 Presentation 类的实例。
- 使用幻灯片的 ID 或索引获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存为文件。
## **示例**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

欲了解更多信息，请访问[在 .NET 中将演示文稿幻灯片呈现为 SVG 图像](/slides/zh/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}