---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.9.0-ban
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) vagy [eltávolított](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az Aspose.Slides for Java 15.8.0 API-val bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API-változások**
#### **renderToGraphics metódusok hozzá lettek adva a com.aspose.slides.ISlide, Slide**
A következő metódusok lettek hozzáadva:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
lettek hozzáadva a com.aspose.slides.ISlide interfészhez és a com.aspose.slides.Slide osztályhoz. Ezek a metódusok lehetővé teszik egy diát a megadott Graphics2D objektumra renderelni.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```