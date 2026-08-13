---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 15.9.0
linktitle: Aspose.Slides per Java 15.9.0
type: docs
weight: 170
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) o [rimosse](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) e le altre modifiche introdotte con l'API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Modifiche all'API Pubblica**
#### **I metodi renderToGraphics sono stati aggiunti a com.aspose.slides.ISlide, Slide**
Sono stati aggiunti i seguenti metodi:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
sono stati aggiunti all'interfaccia com.aspose.slides.ISlide e alla classe com.aspose.slides.Slide. Questi metodi consentono di rendere una diapositiva su un oggetto Graphics2D specificato.

I metodi `renderToGraphics` sono stati rimossi dall'API pubblica. Nelle versioni attuali, è possibile rendere una diapositiva con [ISlide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), come mostrato nell'esempio seguente:

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