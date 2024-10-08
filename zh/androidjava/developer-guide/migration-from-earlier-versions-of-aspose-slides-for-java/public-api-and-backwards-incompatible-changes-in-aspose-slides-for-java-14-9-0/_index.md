---
title: Aspose.Slides for Java 14.9.0 的公共 API 和向后不兼容的更改
type: docs
weight: 80
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

本页面列出了所有在 Aspose.Slides for Java 14.9.0 API 中添加的 [类](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)、方法、属性等，以及任何新的限制和其他 [更改](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **为 PPImage、IPPImage 添加了替换图像的方法**
新增方法：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//第一种方法

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//第二种方法

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **为保留页面编号而保存幻灯片添加的方法**
新增方法如下：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

这些方法允许将指定的演示文稿幻灯片保存为 PDF、XPS、TIFF、HTML 格式。'slides' 数组允许指定页码，从 1 开始。

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //幻灯片位置数组

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **添加了 SmartArtLayoutType.Custom 枚举值**
这种 SmartArt 布局类型表示具有自定义模板的图表。自定义图表只能从演示文稿文件加载，无法通过方法 ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 创建。
### **添加了 SmartArtShape 类和 ISmartArtShape 接口**
Aspose.Slides.SmartArt.SmartArtShape 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShape）提供对 SmartArt 图表内部单个形状的访问。SmartArtShape 可用于更改 FillFormat、LineFormat、添加超链接等。

{{% alert color="primary" %}} 

SmartArtShape 不支持 IShape 属性 RawFrame、Frame、Rotation、X、Y、Width、Height，尝试访问时会抛出 System.NotSupportedException。

{{% /alert %}} 

使用示例：

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **添加了 SmartArtShapeCollection 类、ISmartArtShapeCollection 接口和 ISmartArtNode.getShapes() 方法**
Aspose.Slides.SmartArt.SmartArtShapeCollection 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供对 SmartArt 图表内部单个形状的访问。该集合包含与 SmartArtNode 相关联的形状。属性 SmartArtNode.Shapes 返回与节点相关联的所有形状的集合。

{{% alert color="primary" %}} 

根据 SmartArtLayoutType，一个 SmartArtShape 可以在多个节点之间共享。

{{% /alert %}} 

﻿

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```