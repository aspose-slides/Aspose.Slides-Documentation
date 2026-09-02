---
title: Converti le diapositive di presentazione in immagini su Android
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/androidjava/convert-slide/
keywords:
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in EMF
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Converti le diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine su Android con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides for Android via Java può renderizzare singole diapositive da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri renderizzare.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tiffoptions/).
4. Chiama il metodo [ISlide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage--) . Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/).
5. Chiama il metodo [IImage.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/).

## **Convertire una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni predefinite di rendering. L'oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

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

Utilizza la sovraccarico [ISlide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) che accetta un valore [Size](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides.android/size/) per renderizzare una diapositiva con dimensioni pixel precise.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Passa un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notescommentslayoutingoptions/) al metodo [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per controllare dove appaiono note e commenti.

Il seguente esempio colloca note troncate sotto la diapositiva e commenti a destra:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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
Per la conversione di diapositiva in immagine, non passare [BottomFull](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notespositions/) al metodo [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa [BottomTruncated](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notespositions/) invece.
{{% /alert %}}

## **Convertire diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tiffoptions/) ti consente di controllare la dimensione, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio renderizza la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **Convertire tutte le diapositive in immagini**

Itera attraverso la raccolta di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non vengano esplicitamente saltate.

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

## **Creare un output Enhanced Metafile**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica basata su vettori con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la medesima perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile Windows, non un formato di interscambio universale. Inoltre, contenuti diapositive complessi, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore vettoriale del metafile.

### **Esportare una diapositiva in EMF**

Il metodo [ISlide.writeAsEmf](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) scrive un [ISlide] su uno stream di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive su uno stream di file EMF:

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

Il chiamante possiede lo stream passato a [ISlide.writeAsEmf](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ed è responsabile della sua chiusura, come mostrato sopra.

### **Convertire un'immagine SVG in EMF e aggiungerla a una presentazione**

Usa [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) per convertire il contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [IImageCollection.addImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) e inseriti su una diapositiva con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile sulla prima diapositiva e salva la presentazione:

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

Il metodo [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) non prende possesso dello stream di destinazione. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) memorizza tutti i dati generati in memoria, quindi non è necessario ripristinare la posizione prima di chiamare `toByteArray`. L'array di byte restituito rimane valido dopo la chiusura dello stream.

La generazione di EMF è disponibile sulle versioni Android supportate e sulle configurazioni dei dispositivi, ma il rendering può differire quando i caratteri o le dipendenze grafiche non sono disponibili. Installa i font utilizzati dal contenuto sorgente o configura sostituzioni appropriate, segui la [installation guide](/slides/it/androidjava/install-aspose-slides-for-android-via-java/) per Aspose.Slides for Android via Java e verifica il risultato nell'applicazione destinata a consumare EMF. Le applicazioni su piattaforme non Windows spesso hanno supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering di Emoji a colori**

{{% alert title="Note" color="info" %}}
Per renderizzare correttamente gli emoji a colori durante la conversione delle diapositive della presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font è assente, gli emoji potrebbero apparire in bianco e nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [ISlide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage--) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come le diapositive normali. Includile nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Le ombre e altri effetti vengono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenze e altri effetti grafici supportati nelle immagini delle diapositive.