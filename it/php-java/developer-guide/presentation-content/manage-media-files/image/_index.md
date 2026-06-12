---
title: Ottimizzare la gestione delle immagini nelle presentazioni usando PHP
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/php-java/image/
keywords:
- aggiungi immagine
- aggiungi immagine
- aggiungi bitmap
- sostituisci immagine
- sostituisci immagine
- da web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
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
description: "Snellire la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per PHP via Java, ottimizzando le prestazioni e automatizzando il flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive delle proprie presentazioni mediante diverse procedure. 

{{% alert  title="Suggerimento" color="primary" %}} 

Aspose offre convertitori gratuiti—[JPEG in PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG in PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che permettono di creare rapidamente presentazioni a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come oggetto frame—soprattutto se intendi utilizzare le opzioni di formattazione standard per modificarne la dimensione, aggiungere effetti, ecc.—consulta [Quadro immagine](/slides/it/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

È possibile manipolare le operazioni di input/output che coinvolgono immagini e presentazioni PowerPoint per convertire un'immagine da un formato all'altro. Vedi queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/php-java/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-png/), converti [PNG in JPG](https://products.aspose.com/slides/it/php-java/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/php-java/conversion/png-to-svg/), converti [SVG in PNG](https://products.aspose.com/slides/it/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta operazioni con immagini in questi formati popolari: JPEG, PNG, GIF e altri. 

## **Aggiungere immagini memorizzate localmente alle diapositive**

È possibile aggiungere una o più immagini presenti sul proprio computer a una diapositiva di una presentazione. Questo esempio di codice mostra come aggiungere un'immagine a una diapositiva:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi aggiungerla direttamente dal Web. 

Questo esempio di codice mostra come aggiungere un'immagine dal Web a una diapositiva :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere immagini ai master delle diapositive**

Un master della diapositiva è la diapositiva superiore che memorizza e controlla le informazioni (tema, layout, ecc.) di tutte le diapositive al di sotto di essa. Pertanto, quando aggiungi un'immagine a un master della diapositiva, tale immagine appare su ogni diapositiva sotto quel master. 

Questo esempio di codice Java mostra come aggiungere un'immagine a un master della diapositiva:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere immagini come sfondo della diapositiva**

Puoi decidere di utilizzare un'immagine come sfondo per una diapositiva specifica o per diverse diapositive. In tal caso, devi vedere come [Imposta un'immagine come sfondo della diapositiva](/slides/it/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Aggiungere SVG alle presentazioni**
È possibile aggiungere o inserire qualsiasi immagine in una presentazione utilizzando il metodo [addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/) appartenente alla classe [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/). 

Per creare un oggetto immagine basato su un'immagine SVG, è possibile procedere in questo modo:

1. Creare un oggetto SvgImage per inserirlo nella ImageShapeCollection  
2. Creare un oggetto PPImage da ISvgImage  
3. Creare un oggetto PictureFrame usando la classe PPImage  

Questo esempio di codice mostra come implementare i passaggi sopra indicati per aggiungere un'immagine SVG a una presentazione:
```php
  # Istanziare la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertire SVG in un set di forme**
La conversione di SVG in un set di forme di Aspose.Slides è simile alla funzionalità di PowerPoint utilizzata per lavorare con immagini SVG:

![Menu a comparsa di PowerPoint](img_01_01.png)

La funzionalità è fornita da una delle overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addgroupshape/) della classe [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) che accetta un oggetto [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un set di forme:

```php
  # Crea una nuova presentazione
  $presentation = new Presentation();
  try {
    # Leggi il contenuto del file SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Crea oggetto SvgImage
    $svgImage = new SvgImage($svgContent);
    # Ottieni le dimensioni della diapositiva
    $slideSize = $presentation->getSlideSize()->getSize();
    # Converte l'immagine SVG in un gruppo di forme scalandola alle dimensioni della diapositiva
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Salva la presentazione in formato PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Aggiungere immagini come EMF alle diapositive**
Aspose.Slides per PHP via Java consente di generare immagini EMF da fogli Excel e aggiungere le immagini come EMF nelle diapositive con Aspose.Cells. 

Questo esempio di codice mostra come eseguire l'operazione descritta:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Salva la cartella di lavoro in stream
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sostituire immagini nella raccolta di immagini**

Aspose.Slides permette di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione (incluse quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella raccolta. L'API fornisce metodi semplici per sostituire un'immagine usando dati byte grezzi, un'istanza di [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) o un'altra immagine già presente nella raccolta.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).  
1. Carica una nuova immagine da un file in un array di byte.  
1. Sostituisci l'immagine di destinazione con la nuova immagine usando l'array di byte.  
1. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) e sostituisci l'immagine di destinazione con quell'oggetto.  
1. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine già presente nella raccolta di immagini della presentazione.  
1. Scrivi la presentazione modificata come file PPTX.  

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation("sample.pptx");
try {
    // Il primo modo.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Il secondo modo.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Il terzo modo.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Salva la presentazione in un file.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Utilizzando il convertitore gratuito Aspose FREE [Testo in GIF](https://products.aspose.app/slides/it/text-to-gif), è possibile animare facilmente i testi, creare GIF da testi, ecc. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali sono conservati, ma l'aspetto finale dipende da come il [picture](/slides/it/php-java/picture-frame/) è scalato nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta di immagini della presentazione: gli aggiornamenti si propageranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopodiché le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/php-java/presentation-background/) sul master della diapositiva o sul layout pertinente: tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come posso evitare che la presentazione "aumenti" di dimensioni a causa di troppe immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master dove opportuno.