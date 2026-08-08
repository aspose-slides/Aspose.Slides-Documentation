---
title: "Ottimizza la gestione delle immagini nelle presentazioni con PHP"
linktitle: "Gestisci immagini"
type: docs
weight: 10
url: /it/php-java/image/
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
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Semplifica la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente attraenti. In Microsoft PowerPoint, è possibile inserire immagini nelle diapositive da file, da Internet o da altre fonti. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive di una presentazione in diversi modi.

{{% alert  title="Tip" color="primary" %}} 
Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire dalle immagini. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Se desideri aggiungere un'immagine come fotogramma—soprattutto se prevedi di ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—vedi [Picture Frame](/slides/it/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
È possibile convertire le immagini da un formato all'altro. Vedi le seguenti pagine: converti [image to JPG](https://products.aspose.com/slides/it/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/it/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/it/php-java/conversion/png-to-svg/), e [SVG to PNG](https://products.aspose.com/slides/it/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides supporta immagini nei formati più diffusi come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere immagini archiviate localmente alle diapositive**

È possibile aggiungere una o più immagini archiviate sul computer a una diapositiva della presentazione. Il seguente esempio di codice PHP mostra come aggiungere un'immagine a una diapositiva:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Aggiungere immagini dal web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è archiviata sul tuo computer, puoi aggiungerla direttamente dal web. 

Il seguente esempio di codice PHP mostra come aggiungere un'immagine dal web a una diapositiva:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Aggiungere immagini ai master delle diapositive**

Un master delle diapositive memorizza e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un'immagine a un master delle diapositive, l'immagine appare su ogni diapositiva basata su quel master. 

Il seguente esempio di codice PHP mostra come aggiungere un'immagine a un master delle diapositive:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Aggiungere immagini come sfondi delle diapositive**

Puoi utilizzare un'immagine come sfondo per una o più diapositive. Per i dettagli, vedi *[Setting Images as Backgrounds for Slides](/slides/it/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione utilizzando la classe [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/). L'oggetto immagine SVG risultante può quindi essere aggiunto alla collezione di immagini della presentazione e utilizzato per creare un fotogramma. 

Il seguente esempio PHP importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse usate da questo SVG sono incorporati direttamente nel contenuto SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importare contenuto SVG con risorse esterne**

I file SVG esportati da strumenti di design, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse archiviate al di fuori del documento SVG. Ad esempio, un SVG può contenere un collegamento a un'immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di font. 

Per importare tale contenuto SVG, crea un'implementazione di [ExternalResourceResolver](https://reference.aspose.com/slides/it/php-java/aspose.slides/externalresourceresolver/) e passala, insieme a un URI base, a un costruttore appropriato di [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/). L'URI base identifica la posizione del documento SVG ed è usato per risolvere i collegamenti relativi. 

L'oggetto immagine SVG fornisce accesso alle informazioni sull'SVG importato:

- `getSvgContent()` restituisce il markup SVG come stringa.
- `getSvgData()` restituisce il contenuto SVG come array di byte.
- `getBaseUri()` restituisce l'URI base usato per i collegamenti relativi.
- `getExternalResourceResolver()` restituisce il risolutore assegnato all'immagine SVG.

### **Implementare un risolutore di risorse esterne**

Il risolutore ha due metodi:

- `resolveUri` combina l'URI base e un collegamento a risorsa relativo e restituisce un URI assoluto. Restituisce `null` quando il collegamento non può essere risolto o non è consentito.
- `getEntity` restituisce uno stream leggibile per un URI di risorsa assoluto. Restituisce `null` quando la risorsa è mancante, bloccata o non disponibile. È possibile restituire anche uno stream di fallback quando appropriato.

Il risolutore seguente carica risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory consentita sono bloccati. Un'immagine di fallback opzionale è restituita per i collegamenti a immagini non risolti.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Questo risolutore consente intenzionalmente solo file locali.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Usa un fallback solo per risorse immagine. Restituire uno stream immagine
            // per un font o un foglio di stile mancante non sarebbe valido.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Risoluzione delle risorse collegate durante l'importazione SVG**

Supponiamo che `assets/diagram.svg` contenga un riferimento relativo come ad esempio:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Il seguente esempio PHP passa l'URI del file SVG come URI base e fornisce un risolutore personalizzato. Il risolutore converte il collegamento immagine relativo in un URI assoluto e restituisce uno stream contenente la risorsa collegata mentre Aspose.Slides elabora l'SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// L'URI base rappresenta la posizione del documento SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// L'oggetto immagine SVG espone il contenuto sorgente, i dati binari, l'URI base e il risolutore.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe `SvgImage` fornisce inoltre overload che accettano dati SVG come array di byte o stream di input, insieme a un risolutore di risorse esterne e a un URI base.

{{% alert title="Important" color="warning" %}}
Il risolutore di risorse rende disponibili le risorse esterne mentre Aspose.Slides elabora e renderizza l'SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un'immagine SVG viene aggiunta alla collezione di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un'immagine raster di fallback. Una risorsa collegata può comparire nell'immagine di fallback generata, mentre un collegamento relativo come `images/photo.png` rimane invariato nell'SVG memorizzato. Un'applicazione che rende la rappresentazione SVG nativa può quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.
{{% /alert %}}

### **Creare un'immagine SVG portatile**

Per creare un'immagine SVG che non dipenda da file esterni, rendi l'SVG autonomo prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL delle immagini collegate con URI `data:` che contengono i dati dell'immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo che tutte le risorse necessarie sono state incorporate nel contenuto SVG, crea il `SvgImage`, aggiungilo alla collezione di immagini della presentazione e inseriscilo in un fotogramma come mostrato nell'esempio precedente.

### **Gestire risorse mancanti o bloccate**

Restituisci `null` da `resolveUri` quando un URI di risorsa è inválido, proibito o non può essere risolto. Restituisci `null` da `getEntity` quando la risorsa non può essere letta. Aspose.Slides continua a elaborare l'SVG senza quella risorsa quando possibile.

È possibile restituire uno stream di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Ad esempio, restituisci uno stream immagine solo per un'immagine mancante, non per un font o un foglio di stile.

{{% alert title="Security" color="warning" %}}
Non risolvere percorsi di file arbitrari o URL di rete non limitati da file SVG non affidabili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica anche timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.
{{% /alert %}}

## **Convertire SVG in un insieme di forme**

Aspose.Slides può convertire un SVG in un insieme di forme, simile alla funzionalità corrispondente in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addgroupshape/) della classe [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) che prende un oggetto [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) come primo argomento.

Il seguente esempio di codice PHP mostra come utilizzare questo metodo per convertire un file SVG in un insieme di forme:

```php
// Nome file SVG di origine.
$svgFileName = "sample.svg";

// Nome file di output della presentazione.
$outPptxPath = "presentation.pptx";

// Crea una nuova presentazione.
$presentation = new Presentation();
try {
    // Leggi il contenuto del file SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Crea un oggetto SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Ottieni le dimensioni della diapositiva.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Converti l'immagine SVG in un gruppo di forme e scalala alle dimensioni della diapositiva.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Salva la presentazione in formato PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Aggiungere immagini come EMF alle diapositive**

Aspose.Slides per PHP via Java consente di generare immagini EMF da fogli di lavoro Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione.

Il seguente esempio di codice PHP mostra come fare:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Salva la cartella di lavoro in uno stream.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Aggiungi il file così com'è in modo che l'immagine rimanga un EMF vettoriale invece di essere rasterizzata.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Sostituire immagini nella collezione di immagini**

Aspose.Slides consente di sostituire le immagini archiviate nella collezione di immagini di una presentazione, incluse le immagini utilizzate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella collezione. È possibile sostituire un'immagine usando dati byte grezzi, un'istanza di [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) o un'altra immagine già presente nella collezione.

Segui i passaggi seguenti:

1. Carica il file della presentazione che contiene immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Carica una nuova immagine da un file in un array di byte.
3. Sostituisci l'immagine di destinazione con la nuova immagine usando l'array di byte.
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) e sostituisci l'immagine di destinazione con quell'oggetto.
5. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine già presente nella collezione di immagini della presentazione.
6. Scrivi la presentazione modificata come file PPTX.

```php
// Instanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation("sample.pptx");
try {
    // Il primo modo.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Il secondo modo.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Il terzo modo.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Salva la presentazione su un file.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Con il convertitore gratuito [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, è possibile animare facilmente il testo e creare GIF dal testo. 
{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono conservati, ma l'aspetto finale dipende da come l'[picture](/slides/it/php-java/picture-frame/) è ridimensionata nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella collezione di immagini della presentazione: gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopodiché le singole parti diventano modificabili con le normali proprietà delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/php-java/presentation-background/) sul master della diapositiva o sul layout pertinente: tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come evito che una presentazione diventi troppo grande a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute nel master, ove opportuno.