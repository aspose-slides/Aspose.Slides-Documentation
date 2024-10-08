---
title: API publique et changements incompatibles en arrière dans Aspose.Slides pour PHP via Java 15.9.0
type: docs
weight: 170
url: /fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ou [supprimées](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 15.8.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Les méthodes renderToGraphics ont été ajoutées à com.aspose.slides.ISlide, Slide**
Les méthodes suivantes ont été ajoutées :

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ont été ajoutées à l'interface com.aspose.slides.ISlide et à la classe com.aspose.slides.Slide. Ces méthodes permettent de rendre une diapositive dans l'objet Graphics2D spécifié.

```php
  $bufferedImage = new BufferedImage(960, 720, BufferedImage->TYPE_INT_ARGB);
  $g2d = $bufferedImage->createGraphics();
  $pres = new Presentation("SomePresentation.pptx");
  $pres->getSlides()->get_Item(0)->renderToGraphics(false, $g2d, $bufferedImage->getWidth(), $bufferedImage->getHeight());
  $g2d->dispose();
  Java("javax.imageio.ImageIO")->write($bufferedImage, "png", $fileName);

```