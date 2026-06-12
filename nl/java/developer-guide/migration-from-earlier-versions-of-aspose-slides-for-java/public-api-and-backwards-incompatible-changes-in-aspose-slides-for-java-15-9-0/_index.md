---
title: Publieke API en achterwaartse incompatibele wijzigingen in Aspose.Slides voor Java 15.9.0
linktitle: Aspose.Slides voor Java 15.9.0
type: docs
weight: 170
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) of [removed](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **renderToGraphics methods were added to com.aspose.slides.ISlide, Slide**
De volgende methoden zijn toegevoegd:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
zijn toegevoegd aan de com.aspose.slides.ISlide-interface en aan de com.aspose.slides.Slide-klasse. Deze methoden maken het mogelijk om een dia te renderen naar een opgegeven Graphics2D-object.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```