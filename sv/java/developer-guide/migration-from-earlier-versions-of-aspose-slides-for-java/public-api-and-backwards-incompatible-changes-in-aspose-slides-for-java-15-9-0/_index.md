---
title: Offentlig API och bakåt oförenliga förändringar i Aspose.Slides för Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammalt tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klasser, metoder, egenskaper och så vidare, samt andra ändringar som införts med Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Offentliga API-förändringar**
#### **renderToGraphics‑metoder lades till i com.aspose.slides.ISlide, Slide**
Följande metoder har lagts till:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
lades till i gränssnittet com.aspose.slides.ISlide och i klassen com.aspose.slides.Slide. Dessa metoder möjliggör att rendera en bild till ett specificerat Graphics2D‑objekt.

`renderToGraphics`‑metoderna har sedan dess tagits bort från det offentliga API:et. I de nuvarande versionerna renderas en bild med [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), som exemplet nedan visar:

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