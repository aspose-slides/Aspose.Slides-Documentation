---
title: Converti diapositive di presentazione in immagini in Java
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/java/convert-slide/
keywords:
- convertire diapositiva
- esportare diapositiva
- diapositiva a immagine
- salva diapositiva come immagine
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Converti diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in Java con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Java può renderizzare singole diapositive da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, seguire questi passaggi:

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Selezionare la diapositiva da renderizzare.
3. Se necessario, configurare il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/tiffoptions/).
4. Chiamare il metodo [ISlide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage--). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/).
5. Chiamare il metodo [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/#save-java.lang.String-int-) e specificare il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/).

## **Convertire una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni predefinite di rendering. L'oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

Il seguente esempio Java renderizza la prima diapositiva e la salva come immagine PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertire diapositive in immagini con dimensioni personalizzate**

Utilizzare la sovraccarico [ISlide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) che accetta un valore [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) per renderizzare una diapositiva con esatte dimensioni in pixel.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertire diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Passare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/) al metodo [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per controllare dove appaiono note e commenti.

Il seguente esempio posiziona note troncate sotto la diapositiva e commenti a destra:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Per la conversione da diapositiva a immagine, non passare [BottomFull](https://reference.aspose.com/slides/it/java/com.aspose.slides/notespositions/) al metodo [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Utilizzare invece [BottomTruncated](https://reference.aspose.com/slides/it/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Convertire diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/tiffoptions/) consente di controllare le dimensioni, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio renderizza la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Il supporto TIFF non è garantito nelle versioni Java anteriori a JDK 9.
{{% /alert %}}

## **Convertire tutte le diapositive in immagini**

Iterare la raccolta di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non vengano saltate esplicitamente.

Il seguente esempio renderizza ogni diapositiva come immagine JPEG con fattori di scala orizzontale e verticale pari a 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Creare output Metafile migliorato**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica vettoriale con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la stessa perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile Windows, non un formato di scambio universale. Inoltre, contenuti complessi delle diapositive, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore del metafile vettoriale.

### **Esportare una diapositiva in EMF**

Il metodo [ISlide.writeAsEmf](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) scrive un [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) su uno stream di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive su uno stream di file EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Chi chiama possiede lo stream passato a [ISlide.writeAsEmf](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ed è responsabile della sua chiusura, come mostrato sopra.

### **Convertire un'immagine SVG in EMF e aggiungerla a una presentazione**

Utilizzare [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) per convertire il contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [IImageCollection.addImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) e posizionati su una diapositiva con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile nella prima diapositiva e salva la presentazione:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) non prende possesso dello stream di destinazione. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) memorizza tutti i dati generati in memoria, quindi non è necessario reinizializzare la posizione prima di chiamare `toByteArray`. L'array di byte restituito rimane valido dopo la chiusura dello stream.

La generazione di EMF è disponibile sui sistemi operativi supportati dalla configurazione selezionata di Aspose.Slides per Java e JDK, ma il rendering può differire tra piattaforme quando i font o le dipendenze grafiche non sono disponibili. Installare i font utilizzati dal contenuto di origine o configurare sostituzioni adeguate, seguire i [requisiti di piattaforma](/slides/it/java/system-requirements/) per Aspose.Slides per Java e convalidare il risultato nell'applicazione di destinazione che consuma EMF. Le applicazioni Linux e macOS spesso hanno un supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering emoji a colori**

{{% alert title="Note" color="info" %}}
Per renderizzare correttamente gli emoji a colori durante la conversione delle diapositive della presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font è mancante, gli emoji potrebbero apparire in monocromo nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [ISlide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage--) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come le diapositive regolari. Includerle nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Ombre e altri effetti sono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.