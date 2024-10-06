---
title: Aspose.Slides for PHP via Java 15.9.0 における公開 API と後方互換性のない変更
type: docs
weight: 170
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.8.0 API に導入されたすべての[追加された](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)または[削除された](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)クラス、メソッド、プロパティなどおよびその他の変更を一覧表示します。

{{% /alert %}} 
## **公開 API の変更**
#### **com.aspose.slides.ISlide、Slide に renderToGraphics メソッドが追加されました**
以下のメソッドが追加されました：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
は、com.aspose.slides.ISlide インターフェイスと com.aspose.slides.Slide クラスに追加されました。これらのメソッドは、スライドを指定された Graphics2D オブジェクトにレンダリングします。

```php
  $bufferedImage = new BufferedImage(960, 720, BufferedImage->TYPE_INT_ARGB);
  $g2d = $bufferedImage->createGraphics();
  $pres = new Presentation("SomePresentation.pptx");
  $pres->getSlides()->get_Item(0)->renderToGraphics(false, $g2d, $bufferedImage->getWidth(), $bufferedImage->getHeight());
  $g2d->dispose();
  Java("javax.imageio.ImageIO")->write($bufferedImage, "png", $fileName);

```