---
title: Ottimizzare la gestione delle immagini nelle presentazioni usando PHP
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/php-java/image/
keywords:
- aggiungere immagine
- aggiungere foto
- sostituire immagine
- raccolta immagini
- riquadro immagine
- immagine collegata
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG in presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP via Java."
---
## **Introduzione**

Aspose.Slides per PHP via Java fornisce diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo della diapositiva, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate in una presentazione. Per ritaglio, trasparenza, effetti, stiramento e altre formattazioni applicate a un singolo riquadro immagine, vedere [Picture Frame](/slides/it/php-java/picture-frame/).

## **Comprendere il modello immagine**

The following API concepts are closely related but not interchangeable:

- La [presentation image collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Utilizzare [ImageCollection::addImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) per aggiungere dati immagine e ottenere una risorsa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).
- Un [picture frame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Utilizzare [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come un picture frame.
- [PPImage::replaceImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) sostituisce una risorsa immagine. Se più elementi della presentazione utilizzano quella risorsa, tutti usano la sostituzione.
- La conversione di un SVG in forme crea forme diapositive modificabili. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un tipico flusso di lavoro è quindi: aggiungere dati immagine alla collezione immagini, ricevere un [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/), e quindi utilizzare quella risorsa in uno o più picture frame o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, caricare il file, aggiungerlo alla collezione immagini e creare un picture frame che utilizzi il `PPImage` restituito.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dalla disponibilità del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scaricare i suoi byte, aggiungerli alla collezione immagini della presentazione e utilizzare la risorsa immagine restituita nello stesso modo di un'immagine locale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In applicazioni a lungo termine, riutilizzare un client HTTP o una strategia di gestione delle connessioni appropriata all'applicazione invece di creare ripetutamente infrastrutture di rete non necessarie. Inoltre, convalidare URL remoti, dimensioni delle risposte e tipi di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungerla alla presentazione una sola volta e riutilizzare il [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) restituito quando si creano ulteriori picture frame. Ciò evita di caricare ripetutamente gli stessi dati di origine e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per le grafiche che dovrebbero apparire automaticamente su molte diapositive, come un logo aziendale, considerare di posizionare il picture frame su un [slide master](/slides/it/php-java/slide-master/) o layout invece di aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo viene assegnata al riempimento della diapositiva; non è aggiunta come forma picture-frame. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto della diapositiva.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per ulteriori opzioni di sfondo, inclusi sfondi master e layout, vedere [Presentation Background](/slides/it/php-java/presentation-background/).

## **Immagini incorporate e immagini collegate**

Embedded and linked images have different portability and file-size tradeoffs:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre le dimensioni della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o URL esterno tramite [Picture::setLinkPathLong](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/) anziché incorporare i dati dell'immagine.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilizzare immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono generalmente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che dovrebbero scalare senza la stessa perdita di dettaglio delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come sorgente per forme diapositive modificabili.

### **Aggiungere un SVG come immagine**

Creare un [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/), aggiungerlo alla collezione immagini e posizionare la risorsa immagine risultante in un picture frame.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini esterne, fogli di stile o font. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) fornisce costruttori che accettano un [ExternalResourceResolver](https://reference.aspose.com/slides/it/php-java/aspose.slides/externalresourceresolver/) e un URI di base. Il resolver può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il resolver rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorporare le risorse necessarie nell'SVG stesso, ad esempio usando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limitare gli schemi, le posizioni dei file e gli host a cui il resolver può accedere. I resolver di rete dovrebbero inoltre applicare timeout, limiti di dimensione delle risposte e convalida dei contenuti.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme diapositive modificabili, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilizzare il sovraccarico [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addgroupshape/) che accetta un [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) per eseguire la conversione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilizzare la conversione SVG-in-forme quando è necessario modificare elementi vettoriali individuali come forme PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Utilizzare [PPImage::replaceImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) quando si desidera sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come i loghi.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se più picture frame, sfondi, master o layout utilizzano la stessa risorsa immagine, sostituire quella risorsa aggiorna tutti quegli utilizzi. Se deve cambiare solo un picture frame, assegnare un'immagine diversa a quel frame invece di sostituire la risorsa condivisa.

`PPImage::replaceImage` fornisce anche sovraccarichi che accettano un array di byte o un altro [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare le dimensioni della presentazione**

Le grandi immagini raster possono rendere una presentazione inutilmente grande. Utilizzare immagini sorgente con dimensioni appropriate per la loro dimensione di visualizzazione prevista, riutilizzare le risorse immagine condivise dove possibile e evitare di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per le immagini raster già inserite nei picture frame, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) può ridurre i dati immagine in base alla risoluzione selezionata e alle impostazioni di ritaglio. Questo è un’elaborazione picture-frame anziché una gestione della collezione immagini, quindi vedere [Picture Frame](/slides/it/php-java/picture-frame/) per le operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portabile perché tutti i dati immagine richiesti viaggiano con il file. Il collegamento può ridurre le dimensioni del file, ma introduce una dipendenza esterna. Utilizzare collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, utilizzare una singola risorsa immagine e riutilizzarla. Se la grafica appartiene al design della presentazione piuttosto che al contenuto della diapositiva, posizionarla su un master o layout in modo che venga ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file o risorse di rete esterne. Quando possibile, incorporare le risorse necessarie prima di importare l'SVG. Convertire SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Utilizzare l'API immagine moderna cross-platform**

Per nuovo codice PHP via Java, utilizzare le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/php-java/aspose.slides/images/) invece della vecchia API pubblica basata su `java.awt.image.BufferedImage`. Vedere [Modern API](/slides/it/php-java/modern-api/) per le indicazioni sulla migrazione.

WMF ed EMF richiedono considerazioni speciali. Quando questi formati vengono passati tramite un [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) converte il metafile in una rappresentazione PNG raster prima dell'inserimento. Se è importante preservare i dati del metafile, utilizzare invece un sovraccarico basato su stream di [ImageCollection::addImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/). Generare contenuto EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato e non rientra nell'ambito di questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione immagini e un picture frame?**

La collezione immagini memorizza risorse immagine riutilizzabili. Un picture frame è una forma della diapositiva che visualizza una di queste risorse e fornisce formattazioni specifiche per l'immagine come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una risorsa immagine, sostituire quella risorsa con [PPImage::replaceImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal suo file o URL esterno. Se quella risorsa non può essere raggiunta dall'altro computer, l'immagine collegata potrebbe non essere disponibile. Incorporare l'immagine quando la presentazione deve essere autonoma.

**Un SVG inserito può essere modificato come forme PowerPoint?**

Sì. Convertire l'SVG con [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addgroupshape/); il gruppo risultante contiene forme diapositive modificabili anziché un'unica immagine SVG.

**Come posso mantenere le presentazioni con molte immagini più piccole?**

Riutilizzare le risorse immagine condivise, evitare sorgenti raster inutilmente grandi, comprimere le immagini raster appropriate quando opportuno, mantenere il branding ripetuto su master o layout, e utilizzare immagini collegate solo quando una dipendenza esterna è accettabile.