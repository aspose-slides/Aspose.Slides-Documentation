---
title: Aspose.Slides for Java 15.9.0のパブリックAPIと後方互換性のない変更
type: docs
weight: 170
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.8.0 APIで追加されたまたは削除された[クラス](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)、[メソッド](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリックAPIの変更**
#### **renderToGraphicsメソッドがcom.aspose.slides.ISlideおよびSlideに追加されました**
以下のメソッドが追加されました：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
これらのメソッドはcom.aspose.slides.ISlideインターフェースおよびcom.aspose.slides.Slideクラスに追加されました。これらのメソッドは、スライドを指定されたGraphics2Dオブジェクトにレンダリングすることを可能にします。

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```