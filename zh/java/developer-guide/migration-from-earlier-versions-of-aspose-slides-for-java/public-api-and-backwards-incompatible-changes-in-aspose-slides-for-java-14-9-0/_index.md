---
title: Aspose.Slides for Java 14.9.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有 [已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) 类、方法、属性等，以及任何新限制和其他 [更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)，这些均随 Aspose.Slides for Java 14.9.0 API 引入。

{{% /alert %}} 
## **公共 API 更改**
### **已添加用于替换 Image 为 PPImage、IPPImage 的方法**
新增的方法如下：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // 第一种方法
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // 第二种方法
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **已添加用于保存幻灯片并保留页码的方法**
已添加以下方法：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

这些方法可将指定的演示文稿幻灯片保存为 PDF、XPS、TIFF、HTML 等格式。'slides' 数组用于指定页码，起始页码为 1。

``` java
// 添加到 IPresentation 的重载（SaveFormat 值在 Java 中是 int 常量）:
// 
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // 幻灯片位置数组

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **已添加 SmartArtLayoutType.Custom 枚举值**
此类 SmartArt 布局表示使用自定义模板的图表。自定义图表只能从演示文稿文件中加载，不能通过方法 ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 创建。
### **已添加 SmartArtShape 类和 ISmartArtShape 接口**
Aspose.Slides.SmartArt.SmartArtShape 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShape）提供对 SmartArt 图表中各个形状的访问。SmartArtShape 可用于更改 FillFormat、LineFormat、添加超链接等。

{{% alert color="info" %}} 

SmartArtShape 不支持 IShape 属性 RawFrame、Frame、Rotation、X、Y、Width、Height，访问这些属性时会抛出 System.NotSupportedException。

{{% /alert %}} 

示例用法：

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **已添加 SmartArtShapeCollection 类、ISmartArtShapeCollection 接口以及 ISmartArtNode.getShapes() 方法**
Aspose.Slides.SmartArt.SmartArtShapeCollection 类（及其接口 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供对 SmartArt 图表中各个形状的访问。该集合包含与 SmartArtNode 关联的形状。属性 SmartArtNode.Shapes 返回该节点关联的所有形状集合。

{{% alert color="info" %}} 

根据 SmartArtLayoutType，单个 SmartArtShape 可以在多个节点之间共享。

{{% /alert %}} 

 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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