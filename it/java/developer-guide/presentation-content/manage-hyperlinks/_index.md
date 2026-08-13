---
title: Gestisci i collegamenti ipertestuali della presentazione in Java
linktitle: Gestisci collegamento
type: docs
weight: 20
url: /it/java/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale nel testo
- collegamento ipertestuale nella diapositiva
- collegamento ipertestuale nella forma
- collegamento ipertestuale nell'immagine
- collegamento ipertestuale nel video
- collegamento ipertestuale mutabile
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci facilmente i collegamenti ipertestuali in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Java—migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a un oggetto, a dei dati o a un punto in qualcosa. Questi sono collegamenti ipertestuali comuni nelle presentazioni PowerPoint:

* Collegamenti a siti web all'interno di testi, forme o contenuti multimediali
* Collegamenti a diapositive

Aspose.Slides per Java consente di eseguire molte attività relative ai collegamenti ipertestuali nelle presentazioni.

{{% alert color="info" %}} 
Potresti voler provare Aspose simple, [editor PowerPoint online gratuito.](https://products.aspose.app/slides/it/editor)
{{% /alert %}} 

## **Aggiungi collegamenti URL**

### **Aggiungi collegamenti URL al testo**

Questo codice Java mostra come aggiungere un collegamento ipertestuale a un sito web a un testo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Aggiungi collegamenti URL a forme o cornici**

Questo esempio di codice Java mostra come aggiungere un collegamento ipertestuale a un sito web a una forma:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Aggiungi collegamenti URL ai media**

Aspose.Slides consente di aggiungere collegamenti ipertestuali a immagini, file audio e video.

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un'**immagine**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Aggiunge immagine alla presentazione
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Crea un frame immagine nella diapositiva 1 basato sull'immagine aggiunta precedentemente
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **file audio**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **video**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}} 
Potresti voler vedere *[Gestisci OLE](/slides/it/java/manage-ole/)*.
{{% /alert %}}

## **Usa i collegamenti ipertestuali per creare un indice**

Poiché i collegamenti ipertestuali consentono di aggiungere riferimenti a oggetti o posizioni, è possibile usarli per creare un indice.

Questo esempio di codice mostra come creare un indice con collegamenti ipertestuali:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Formato dei collegamenti ipertestuali**

### **Colore**

Con la proprietà [ColorSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/Hyperlink#setColorSource-int-) nell'interfaccia [IHyperlink](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink), è possibile impostare il colore per i collegamenti ipertestuali e anche ottenere le informazioni sul colore dai collegamenti ipertestuali. La funzionalità è stata introdotta per la prima volta in PowerPoint 2019, quindi le modifiche relative alla proprietà non si applicano alle versioni precedenti di PowerPoint.

Questo esempio di codice dimostra un'operazione in cui sono stati aggiunti collegamenti ipertestuali con colori diversi alla stessa diapositiva:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Rimuovi i collegamenti ipertestuali dalle presentazioni**

### **Rimuovi i collegamenti ipertestuali dal testo**

Questo codice Java mostra come rimuovere il collegamento ipertestuale da un testo in una diapositiva della presentazione:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Rimuovi i collegamenti ipertestuali da forme o cornici**

Questo codice Java mostra come rimuovere il collegamento ipertestuale da una forma in una diapositiva della presentazione: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Collegamento ipertestuale mutabile**

La classe [Hyperlink](https://reference.aspose.com/slides/it/java/com.aspose.slides/Hyperlink) è mutabile. Con questa classe, è possibile modificare i valori di queste proprietà:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Il frammento di codice mostra come aggiungere un collegamento ipertestuale a una diapositiva e modificare il suo suggerimento (tooltip) successivamente:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Modifica il tooltip del collegamento ipertestuale già aggiunto
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Proprietà supportate in IHyperlinkQueries**

È possibile accedere a [IHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries) da una presentazione, diapositiva o testo per cui è definito il collegamento ipertestuale. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

La classe [IHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries) supporta questi metodi e proprietà: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?

Le sezioni in PowerPoint sono raggruppamenti di diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per "navigare a una sezione", di solito si collega alla sua prima diapositiva.

### Posso collegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. tali collegamenti appaiono sulle diapositive figlie e sono cliccabili durante la presentazione.

### I collegamenti ipertestuali verranno mantenuti durante l'esportazione in PDF, HTML, immagini o video?

In [PDF](/slides/it/java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/java/convert-powerpoint-to-html/), sì—i collegamenti sono generalmente mantenuti. Quando si esporta in [immagini](/slides/it/java/convert-powerpoint-to-png/) e [video](/slides/it/java/convert-powerpoint-to-video/), la possibilità di cliccare non sarà mantenuta a causa della natura di questi formati (i fotogrammi raster/video non supportano i collegamenti ipertestuali).