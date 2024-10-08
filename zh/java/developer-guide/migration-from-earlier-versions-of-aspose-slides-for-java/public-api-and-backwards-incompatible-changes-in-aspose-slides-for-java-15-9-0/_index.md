---
title: Aspose.Slides for Java 15.9.0 的公共 API 和向后不兼容的更改
type: docs
weight: 170
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

本页面列出了在 Aspose.Slides for Java 15.8.0 API 中添加的或删除的所有[class](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **renderToGraphics 方法已添加到 com.aspose.slides.ISlide 和 Slide**
已添加以下方法：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
已添加到 com.aspose.slides.ISlide 接口和 com.aspose.slides.Slide 类。这些方法允许将幻灯片渲染到指定的 Graphics2D 对象。

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```