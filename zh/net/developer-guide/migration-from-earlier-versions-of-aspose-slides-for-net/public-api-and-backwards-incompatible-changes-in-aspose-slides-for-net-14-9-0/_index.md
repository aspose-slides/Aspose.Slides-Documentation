---
title: Aspose.Slides for .NET 14.9.0 中的公共 API 和不兼容的变更
type: docs
weight: 110
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

本页面列出了 Aspose.Slides for .NET 14.9.0 API 中所有[添加的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)或[移除的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)类、方法、属性等，以及其他引入的变更。

{{% /alert %}} 
## **公共 API 变更**
#### **ISmartArtNodeCollection 增加了从 ICollection 和 Generic IEnumerable 接口的继承**
Aspose.Slides.SmartArt.SmartArtNodeCollection 类（以及相关的接口 Aspose.Slides.SmartArt.ISmartArtNodeCollection）继承了泛型接口 IEnumerable<ISmartArtNode> 和接口 ICollection。
#### **增加了 SmartArtLayoutType.Custom 枚举值**
Custom SmartArt 布局类型代表一个具有自定义模板的图表。自定义图表只能从演示文稿文件中加载，不能通过 ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 方法创建。
#### **增加了 SmartArtShape 类和 ISmartArtShape 接口**
Aspose.Slides.SmartArt.SmartArtShape 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShape）可以访问 SmartArt 图表中的单个形状。SmartArtShape 可用于更改 FillFormat、LineFormat，添加超链接和其他任务。

{{% alert color="primary" %}} 

**注意**：SmartArtShape 不支持 IShape 属性 RawFrame、Frame、Rotation、X、Y、Width、Height，并且在尝试访问它们时会抛出 System.NotSupportedException。

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
#### **增加了 SmartArtShapeCollection 类、ISmartArtShapeCollection 接口和 ISmartArtNode.Shapes 属性**
Aspose.Slides.SmartArt.SmartArtShapeCollection 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShapeCollection）增加了对 SmartArt 图表中单个形状的访问。该集合包含与 SmartArtNode 关联的形状。SmartArtNode.Shapes 属性返回与该节点关联的所有形状的集合。

{{% alert color="primary" %}} 

**注意**：根据 SmartArtLayoutType，一个 SmartArtShape 可以在多个节点之间共享。

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
#### **增加了保存带页码的幻灯片的方法**
以下方法已被添加：

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

这些方法允许开发人员将指定的演示文稿幻灯片保存为 PDF、XPS、TIFF、HTML 格式。'slides' 数组用于指定页码，从 1 开始。
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //幻灯片位置数组

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **增加了替换图像的方法到 PPImage、IPPImage**
新增的方法：

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//第一种方法

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//第二种方法

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//第三种方法

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 