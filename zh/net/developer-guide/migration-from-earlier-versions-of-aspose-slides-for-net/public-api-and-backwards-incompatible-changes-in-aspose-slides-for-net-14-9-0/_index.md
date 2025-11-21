---
title: Aspose.Slides for .NET 14.9.0 中的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了所有 [已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) 或 [已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) 类、方法、属性等，以及在 Aspose.Slides for .NET 14.9.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **在 ISmartArtNodeCollection 中添加了对 ICollection 和通用 IEnumerable 接口的继承**
类 Aspose.Slides.SmartArt.SmartArtNodeCollection（以及相关接口 Aspose.Slides.SmartArt.ISmartArtNodeCollection）继承了泛型接口 IEnumerable<ISmartArtNode> 和接口 ICollection。
#### **添加了 SmartArtLayoutType.Custom 枚举值**
自定义 SmartArt 布局类型表示使用自定义模板的图表。自定义图表只能从演示文稿文件加载，不能通过 ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 方法创建。
#### **添加了 SmartArtShape 类和 ISmartArtShape 接口**
Aspose.Slides.SmartArt.SmartArtShape 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShape）提供对 SmartArt 图表中各个形状的访问。SmartArtShape 可用于更改 FillFormat、LineFormat、添加超链接以及其他操作。

{{% alert color="primary" %}} 

**注意**：SmartArtShape 不支持 IShape 的属性 RawFrame、Frame、Rotation、X、Y、Width、Height，且在尝试访问这些属性时会抛出 System.NotSupportedException。

使用示例：

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **添加了 SmartArtShapeCollection 类、ISmartArtShapeCollection 接口以及 ISmartArtNode.Shapes 属性**
Aspose.Slides.SmartArt.SmartArtShapeCollection 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供对 SmartArt 图表中各个形状的访问。该集合包含与 SmartArtNode 关联的形状。SmartArtNode.Shapes 属性返回该节点关联的所有形状的集合。

{{% alert color="primary" %}} 

**注意**：根据 SmartArtLayoutType，一个 SmartArtShape 可能会在多个节点之间共享。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **添加了在保存幻灯片时保留页码的方法**
已添加以下方法：

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

这些方法允许开发者将指定的演示文稿幻灯片保存为 PDF、XPS、TIFF、HTML 格式。'slides' 数组用于指定页码，起始页码为 1。
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **在 PPImage、IPPImage 中添加了替换图像的方法**
添加了新方法：

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```