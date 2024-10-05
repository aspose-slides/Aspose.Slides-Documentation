---
title: Aspose.Slides for Java 15.9.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 170
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.8.0 APIで追加されたすべての [追加された](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) または [削除された](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) クラス、メソッド、プロパティなど、およびその他の変更がリストされています。

{{% /alert %}} 
## **パブリックAPIの変更**
#### **renderToGraphicsメソッドがcom.aspose.slides.ISlide、Slideに追加されました**
以下のメソッドが追加されました：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
これらのメソッドはcom.aspose.slides.ISlideインターフェースおよびcom.aspose.slides.Slideクラスに追加されました。これらのメソッドを使用すると、スライドを指定されたGraphics2Dオブジェクトにレンダリングできます。

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```