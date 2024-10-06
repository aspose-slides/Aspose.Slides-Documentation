---
title: API public et changements non compatibles avec les versions précédentes dans Aspose.Slides pour Java 15.9.0
type: docs
weight: 170
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ou [supprimées](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/), ainsi que d'autres modifications introduites avec l'API Aspose.Slides pour Java 15.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Des méthodes renderToGraphics ont été ajoutées à com.aspose.slides.ISlide, Slide**
Les méthodes suivantes ont été ajoutées :

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ont été ajoutées à l'interface com.aspose.slides.ISlide et à la classe com.aspose.slides.Slide. Ces méthodes permettent de rendre une diapositive sur un objet Graphics2D spécifié.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```