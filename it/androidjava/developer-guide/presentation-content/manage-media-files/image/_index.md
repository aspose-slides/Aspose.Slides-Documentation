---
title: Ottimizza la gestione delle immagini nelle presentazioni su Android
linktitle: Gestisci immagini
type: docs
weight: 10
url: /it/androidjava/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- da web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- risorse SVG esterne
- risolutore SVG
- immagini SVG collegate
- font SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Android tramite Java, migliorando le prestazioni e automatizzando il tuo flusso di lavoro.
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente attraenti. In Microsoft PowerPoint è possibile inserire foto nelle diapositive da file, da Internet o da altre fonti. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive di una presentazione in diversi modi.

{{% alert  title="Tip" color="info" %}} 

Aspose fornisce convertitori gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come cornice—soprattutto se prevedi di ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—vedi [Cornice immagine](/slides/it/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

È possibile convertire le immagini da un formato all'altro. Vedi le pagine seguenti: converti [immagine in JPG](https://products.aspose.com/slides/it/androidjava/conversion/image-to-jpg/), [JPG in immagine](https://products.aspose.com/slides/it/androidjava/conversion/jpg-to-image/), [JPG in PNG](https://products.aspose.com/slides/it/androidjava/conversion/jpg-to-png/), [PNG in JPG](https://products.aspose.com/slides/it/androidjava/conversion/png-to-jpg/), [PNG in SVG](https://products.aspose.com/slides/it/androidjava/conversion/png-to-svg/), e [SVG in PNG](https://products.aspose.com/slides/it/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta immagini nei formati più diffusi, come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere immagini archiviate localmente alle diapositive**

È possibile aggiungere una o più immagini memorizzate sul computer a una diapositiva della presentazione. Il codice di esempio Java seguente mostra come aggiungere un'immagine a una diapositiva:

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

Il codice di esempio Java seguente mostra come aggiungere un'immagine dal Web a una diapositiva:

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

Un master della diapositiva archivia e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un'immagine a un master della diapositiva, l'immagine appare su ogni diapositiva basata su quel master. 

Il codice di esempio Java seguente mostra come aggiungere un'immagine a un master della diapositiva:

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

Puoi usare una foto come sfondo per una o più diapositive. Per i dettagli, vedi *[Impostare le immagini come sfondi per le diapositive](/slides/it/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione usando la classe [SvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgimage/). L'oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) risultante può quindi essere aggiunto alla collezione di immagini della presentazione e usato per creare una cornice immagine.

Il seguente esempio Java importa una stringa SVG autocontenuta. Tutte le immagini, gli stili e le altre risorse usate da questo SVG sono incorporati direttamente nel contenuto SVG.

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

I file SVG esportati da strumenti di design, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse memorizzate al di fuori del documento SVG. Ad esempio, un SVG può contenere un collegamento a un'immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di font.

Per importare tale contenuto SVG, crea un'implementazione di [IExternalResourceResolver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iexternalresourceresolver/) e passala, insieme a un URI base, a un costruttore adeguato di [SvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgimage/). L'URI base identifica la posizione del documento SVG ed è usato per risolvere i collegamenti relativi.

L'interfaccia [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) fornisce l'accesso alle informazioni sull'SVG importato:

- `getSvgContent()` restituisce il markup SVG come stringa.  
- `getSvgData()` restituisce il contenuto SVG come array di byte.  
- `getBaseUri()` restituisce l'URI base usato per i collegamenti relativi.  
- `getExternalResourceResolver()` restituisce il risolutore assegnato all'immagine SVG.

### **Implementare un risolutore di risorse esterne**

Il risolutore dispone di due metodi:

- `resolveUri` combina l'URI base e un collegamento a risorsa relativo e restituisce un URI assoluto. Restituisci `null` quando il collegamento non può essere risolto o non è consentito.  
- `getEntity` restituisce uno stream leggibile per un URI di risorsa assoluto. Restituisci `null` quando la risorsa è mancante, bloccata o non disponibile. È possibile restituire anche uno stream di fallback quando opportuno.

Il risolutore seguente carica le risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory consentita sono bloccati. Un'immagine di fallback opzionale è restituita per i collegamenti immagine non risolti.

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

            // Usa un fallback solo per risorse immagine. Restituire uno stream di immagine
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

Il seguente esempio Java passa l'URI del file SVG come URI base e fornisce un risolutore personalizzato. Il risolutore converte il collegamento immagine relativo in un URI assoluto e restituisce uno stream contenente la risorsa collegata mentre Aspose.Slides elabora l'SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// L'URI base rappresenta la posizione del documento SVG.
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

La classe `SvgImage` fornisce anche overload che accettano dati SVG come array di byte o stream di input, insieme a un risolutore di risorse esterne e a un URI base.

{{% alert title="Important" color="warning" %}}

Il risolutore di risorse rende le risorse esterne disponibili mentre Aspose.Slides elabora e rende l'SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un `ISvgImage` viene aggiunto alla collezione di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un'immagine raster di fallback. Una risorsa collegata può apparire nell'immagine di fallback generata, mentre un collegamento relativo come `images/photo.png` rimane invariato nell'SVG memorizzato. Un'applicazione che rende la rappresentazione SVG nativa potrebbe quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.

{{% /alert %}}

### **Creare un'immagine SVG portatile**

Per creare un'immagine SVG che non dipenda da file esterni, rendi l'SVG autocontenuto prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL delle immagini collegate con URI `data:` che contengono i dati dell'immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo aver incorporato tutte le risorse necessarie nel contenuto SVG, crea il `SvgImage`, aggiungilo alla collezione di immagini della presentazione e inseriscilo in una cornice immagine come mostrato nell'esempio precedente.

### **Gestire risorse mancanti o bloccate**

Restituisci `null` da `resolveUri` quando un URI di risorsa è non valido, proibito o non può essere risolto. Restituisci `null` da `getEntity` quando la risorsa non può essere letta. Aspose.Slides continua a elaborare l'SVG senza quella risorsa quando possibile.

È possibile restituire uno stream di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Per esempio, restituisci uno stream immagine solo per un'immagine mancante, non per un font o un foglio di stile.

{{% alert title="Security" color="warning" %}}

Non risolvere percorsi file arbitrari o URL di rete non restritti da file SVG non attendibili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica anche timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.

{{% /alert %}}

## **Convertire SVG in un insieme di forme**

Aspose.Slides può convertire un SVG in un insieme di forme, in modo simile alla funzionalità corrispondente in PowerPoint:

![Menu a comparsa di PowerPoint](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISvgImage) come primo argomento.

Il codice di esempio Java seguente mostra come usare questo metodo per convertire un file SVG in un insieme di forme:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nome file SVG di origine.
String svgFileName = "sample.svg";

// Nome file di output della presentazione.
String outPptxPath = "presentation.pptx";

// Crea una nuova presentazione.
IPresentation presentation = new Presentation();
try {
    // Leggi il contenuto del file SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Crea un oggetto SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottieni le dimensioni della diapositiva.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converte l'immagine SVG in un gruppo di forme e la scala alle dimensioni della diapositiva.
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

Aspose.Slides per Android tramite Java consente di generare immagini EMF da fogli di calcolo Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione.

Il codice di esempio Java seguente mostra come fare:

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

        // Aggiungi il file così com'è in modo che l'immagine rimanga un vettoriale EMF invece di essere rasterizzata.
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

## **Sostituire immagini nella collezione di immagini**

Aspose.Slides permette di sostituire le immagini memorizzate nella collezione di immagini di una presentazione, incluse le immagini usate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella collezione. È possibile sostituire un'immagine usando dati byte grezzi, un'istanza di [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) oppure un'altra immagine già presente nella collezione.

Segui i passaggi seguenti:

1. Carica il file della presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).  
2. Carica una nuova immagine da un file in un array di byte.  
3. Sostituisci l'immagine di destinazione con la nuova immagine usando l'array di byte.  
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e sostituisci l'immagine di destinazione con quell'oggetto.  
5. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine già presente nella collezione di immagini della presentazione.  
6. Scrivi la presentazione modificata come file PPTX.  

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

    // Salva la presentazione in un file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Con il convertitore gratuito di Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), puoi animare facilmente il testo e creare GIF dal testo. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali sono preservati, ma l'aspetto finale dipende da come l'[immagine](/slides/it/androidjava/picture-frame/) viene ridimensionata nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo in decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella collezione di immagini della presentazione: gli aggiornamenti si propagheranno a tutti gli elementi che usano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopodiché le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/androidjava/presentation-background/) sul master della diapositiva o sul layout pertinente: tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come evitare che una presentazione diventi troppo grande a causa di troppe immagini?**

Riutilizza una singola risorsa immagine anziché duplicati, scegli risoluzioni ragionevoli, applica la compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.