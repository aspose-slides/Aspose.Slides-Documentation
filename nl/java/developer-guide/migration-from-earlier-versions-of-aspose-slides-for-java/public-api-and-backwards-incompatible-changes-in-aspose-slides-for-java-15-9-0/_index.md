---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migratie
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de publieke API en breaking changes in Aspose.Slides for Java om soepel uw PowerPoint PPT, PPTX en ODP presentatieoplossingen te migreren."
---
{{% alert color="info" %}}
Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) of [verwijderde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for Java 15.8.0 API.
{{% /alert %}}
## **Publieke API-wijzigingen**
#### **renderToGraphics methoden zijn toegevoegd aan com.aspose.slides.ISlide, Slide**
De volgende methoden zijn toegevoegd:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
werden toegevoegd aan de com.aspose.slides.ISlide‑interface en aan de com.aspose.slides.Slide‑klasse. Deze methoden stellen u in staat om een dia te renderen naar een opgegeven Graphics2D‑object.

De `renderToGraphics`‑methoden zijn sindsdien uit de openbare API verwijderd. In de huidige versies wordt een dia gerenderd met [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), zoals het onderstaande voorbeeld laat zien:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```