---
title: Aspose.Slides for .NET 14.9.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- 迁移
- 传统代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和重大更改，以帮助顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)或[已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)的类、方法、属性等，以及随 Aspose.Slides for .NET 14.9.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **在 ISmartArtNodeCollection 中添加了对 ICollection 和通用 IEnumerable 接口的继承**
Aspose.Slides.SmartArt.SmartArtNodeCollection 类（以及相关接口 Aspose.Slides.SmartArt.ISmartArtNodeCollection）继承了通用接口 IEnumerable<ISmartArtNode> 和接口 ICollection。

#### **SmartArtLayoutType.Custom 枚举值已添加**
Custom SmartArt 布局类型表示具有自定义模板的图表。自定义图表只能从演示文稿文件加载，无法通过 ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 方法创建。

#### **SmartArtShape 类和 ISmartArtShape 接口已添加**
Aspose.Slides.SmartArt.SmartArtShape 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShape）提供对 SmartArt 图表中各个形状的访问。SmartArtShape 可用于更改 FillFormat、LineFormat、添加 Hyperlink 等操作。

{{% alert color="primary" %}} 

**注意**：SmartArtShape 不支持 IShape 属性 RawFrame、Frame、Rotation、X、Y、Width、Height，访问这些属性时会抛出 System.NotSupportedException。

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
#### **SmartArtShapeCollection 类、ISmartArtShapeCollection 接口以及 ISmartArtNode.Shapes 属性已添加**
Aspose.Slides.SmartArt.SmartArtShapeCollection 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供对 SmartArt 图表中各个形状的访问。该集合包含与 SmartArtNode 关联的形状。SmartArtNode.Shapes 属性返回与该节点关联的所有形状的集合。

{{% alert color="primary" %}} 

**注意**：根据 SmartArtLayoutType 的不同，一个 SmartArtShape 可能在多个节点之间共享。

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
#### **已添加用于保留页码保存幻灯片的方法**
已添加以下方法：

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

这些方法允许开发者将指定的演示文稿幻灯片保存为 PDF、XPS、TIFF、HTML 等格式。`slides` 数组用于指定页码，起始值为 1。

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; // 幻灯片位置数组

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **已向 PPImage、IPPImage 添加替换图像的方法**
新增方法：

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

// 第一个方法

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

// 第二个方法

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

// 第三个方法

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```