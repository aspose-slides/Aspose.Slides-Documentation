---
title: Ottimizzare la gestione delle immagini nelle presentazioni usando Java
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/java/image/
keywords:
- aggiungere immagine
- aggiungere foto
- aggiungere bitmap
- sostituire immagine
- sostituire foto
- dal web
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- risorse SVG esterne
- risolutore SVG
- immagini SVG collegate
- font SVG
- aggiungere EMF
- aggiungere WMF
- aggiungere TIFF
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Java, migliorando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente attraenti. In Microsoft PowerPoint, è possibile inserire foto nelle diapositive da file, da Internet o da altre fonti. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive della presentazione in diversi modi.

{{% alert  title="Suggerimento" color="info" %}} 

Aspose fornisce convertitori gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che permettono di creare rapidamente presentazioni da immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come fotogramma—soprattutto se prevedi di ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—consulta [Fotogramma immagine](/slides/it/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puoi convertire le immagini da un formato all'altro. Vedi le seguenti pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/java/conversion/image-to-jpg/), [JPG in immagine](https://products.aspose.com/slides/it/java/conversion/jpg-to-image/), [JPG in PNG](https://products.aspose.com/slides/it/java/conversion/jpg-to-png/), [PNG in JPG](https://products.aspose.com/slides/it/java/conversion/png-to-jpg/), [PNG in SVG](https://products.aspose.com/slides/it/java/conversion/png-to-svg/), e [SVG in PNG](https://products.aspose.com/slides/it/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta immagini in formati popolari come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere immagini memorizzate localmente alle diapositive**

È possibile aggiungere una o più immagini memorizzate sul proprio computer a una diapositiva della presentazione. Il seguente esempio di codice Java mostra come aggiungere un'immagine a una diapositiva:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è memorizzata sul tuo computer, puoi aggiungerla direttamente dal Web. 

Il seguente esempio di codice Java mostra come aggiungere un'immagine dal Web a una diapositiva:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini ai master delle diapositive**

Un master delle diapositive memorizza e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un'immagine a un master delle diapositive, l'immagine appare su ogni diapositiva basata su quel master. 

Il seguente esempio di codice Java mostra come aggiungere un'immagine a un master delle diapositive:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Aggiungere immagini come sfondi delle diapositive**

Puoi utilizzare un'immagine come sfondo per una o più diapositive. Per i dettagli, vedi *[Impostare le immagini come sfondi per le diapositive](/slides/it/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione usando la classe [SvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgimage/). L'oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) risultante può quindi essere aggiunto alla raccolta di immagini della presentazione e utilizzato per creare un fotogramma immagine.

Il seguente esempio Java importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse utilizzate da questo SVG sono incorporate direttamente nel contenuto SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importare contenuto SVG con risorse esterne**

I file SVG esportati da strumenti di progettazione, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse memorizzate al di fuori del documento SVG. Ad esempio, un SVG può contenere un collegamento a un'immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di font.

Per importare tale contenuto SVG, crea un'implementazione di [IExternalResourceResolver](https://reference.aspose.com/slides/it/java/com.aspose.slides/iexternalresourceresolver/) e passala, insieme a un URI di base, a un costruttore appropriato di [SvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgimage/). L'URI di base identifica la posizione del documento SVG e viene usato per risolvere i collegamenti relativi.

L'interfaccia [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) fornisce l'accesso alle informazioni sull'SVG importato:

- `getSvgContent()` restituisce il markup SVG come stringa.
- `getSvgData()` restituisce il contenuto SVG come array di byte.
- `getBaseUri()` restituisce l'URI di base usato per i collegamenti relativi.
- `getExternalResourceResolver()` restituisce il risolutore assegnato all'immagine SVG.

### **Implementare un risolutore di risorse esterne**

Il risolutore ha due metodi:

- `resolveUri` combina l'URI di base e un collegamento a una risorsa relativa e restituisce un URI assoluto. Restituisci `null` quando il collegamento non può essere risolto o non è consentito.
- `getEntity` restituisce uno stream leggibile per un URI di risorsa assoluto. Restituisci `null` quando la risorsa è mancante, bloccata o non disponibile. È possibile restituire anche uno stream di fallback quando opportuno.

Il seguente risolutore carica risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory consentita sono bloccati. Un'immagine di fallback opzionale viene restituita per i collegamenti immagine non risolti.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Questo risolutore consente intenzionalmente solo file locali.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Usa un fallback solo per le risorse immagine. Restituire uno stream immagine
            // per un font o un foglio di stile mancante non sarebbe valido.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Risoluzione delle risorse collegate durante l'importazione SVG**

Supponiamo che `assets/diagram.svg` contenga un riferimento relativo come:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Il seguente esempio Java passa l'URI del file SVG come URI di base e fornisce un risolutore personalizzato. Il risolutore converte il collegamento immagine relativo in un URI assoluto e restituisce uno stream contenente la risorsa collegata mentre Aspose.Slides elabora l'SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// L'URI di base rappresenta la posizione del documento SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe `SvgImage` fornisce anche overload che accettano i dati SVG come array di byte o come stream di input, insieme a un risolutore di risorse esterne e a un URI di base.

{{% alert title="Importante" color="warning" %}}

Il risolutore di risorse rende disponibili le risorse esterne mentre Aspose.Slides elabora e rende l'SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un `ISvgImage` viene aggiunto alla raccolta di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un’immagine raster di fallback. Una risorsa collegata può apparire nell’immagine di fallback generata, mentre un collegamento relativo come `images/photo.png` rimane invariato nello SVG memorizzato. Un’applicazione che rende la rappresentazione SVG nativa può quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.

{{% /alert %}}

### **Creare un’immagine SVG portatile**

Per creare un’immagine SVG che non dipenda da file esterni, rendi l'SVG autonomo prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL delle immagini collegate con URI `data:` che contengono i dati dell’immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo che tutte le risorse necessarie sono state incorporate nel contenuto SVG, crea il `SvgImage`, aggiungilo alla raccolta di immagini della presentazione e inseriscilo in un fotogramma immagine come mostrato nell’esempio precedente.

### **Gestire risorse mancanti o bloccate**

Restituisci `null` da `resolveUri` quando un URI di risorsa è non valido, proibito o non può essere risolto. Restituisci `null` da `getEntity` quando la risorsa non può essere letta. Aspose.Slides continua a elaborare l'SVG senza quella risorsa quando possibile.

È possibile restituire uno stream di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Ad esempio, restituisci uno stream di immagine solo per un’immagine mancante, non per un font o un foglio di stile.

{{% alert title="Sicurezza" color="warning" %}}

Non risolvere percorsi di file arbitrari o URL di rete non restritti da file SVG non attendibili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica anche timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.

{{% /alert %}}

## **Convertire SVG in un insieme di forme**

Aspose.Slides può convertire un SVG in un insieme di forme, simile alla funzionalità corrispondente in PowerPoint:

![Menu a comparsa di PowerPoint](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISvgImage) come primo argomento.

Il seguente esempio di codice Java mostra come usare questo metodo per convertire un file SVG in un insieme di forme:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nome file SVG di origine.
String svgFileName = "sample.svg";

// Nome file della presentazione di output.
String outPptxPath = "presentation.pptx";

// Crea una nuova presentazione.
IPresentation presentation = new Presentation();
try {
    // Leggi il contenuto del file SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Crea un oggetto SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottieni la dimensione della diapositiva.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converti l'immagine SVG in un gruppo di forme e scala alla dimensione della diapositiva.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Salva la presentazione in formato PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Aggiungere immagini come EMF alle diapositive**

Aspose.Slides per Java consente di generare immagini EMF da fogli di lavoro Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione.

Il seguente esempio di codice Java mostra come fare ciò:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Salva la cartella di lavoro in uno stream.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Aggiungi il file così com'è in modo che l'immagine rimanga un EMF vettoriale invece di essere rasterizzata.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Sostituire immagini nella raccolta di immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione, incluse le immagini usate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella raccolta. È possibile sostituire un’immagine usando dati grezzi in byte, un’istanza di [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) o un’altra immagine già presente nella raccolta.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Carica una nuova immagine da un file in un array di byte.
1. Sostituisci l’immagine di destinazione con la nuova immagine usando l’array di byte.
1. Nel secondo approccio, carica l’immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) e sostituisci l’immagine di destinazione con quell’oggetto.
1. Nel terzo approccio, sostituisci l’immagine di destinazione con un’immagine già presente nella raccolta di immagini della presentazione.
1. Scrivi la presentazione modificata come file PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Il primo modo.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Il secondo modo.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Il terzo modo.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Salva la presentazione su un file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Con il convertitore gratuito [Testo in GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, puoi facilmente animare il testo e creare GIF dal testo. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell’immagine rimane intatta dopo l’inserimento?**

Sì. I pixel originali sono conservati, ma l’aspetto finale dipende da come il [fotogramma](/slides/it/java/picture-frame/) è scalato sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta di immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che usano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. Puoi convertire un SVG in un gruppo di forme; successivamente le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un’immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l’immagine come sfondo](/slides/it/java/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come evito che una presentazione diventi troppo grande a causa di troppe immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.