---
title: Aspose.Slides for Java 15.9.0 的公共 API 和向后不兼容的更改
type: docs
weight: 170
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.8.0 API 中 [添加的](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 或 [移除的](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 类、方法、属性等及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **com.aspose.slides.ISlide、Slide 添加了 renderToGraphics 方法**
添加了以下方法：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
这些方法被添加到 com.aspose.slides.ISlide 接口和 com.aspose.slides.Slide 类中。此方法允许将幻灯片渲染到指定的 Graphics2D 对象。

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```