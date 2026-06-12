---
title: Gestisci i Frame Immagine nelle Presentazioni usando PHP
linktitle: Frame Immagine
type: docs
weight: 10
url: /it/php-java/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione frame immagine
- proprietà frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi frame immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP via Java. Semplifica il tuo flusso di lavoro e migliora i design delle diapositive."
---
## **Introduzione**

Un frame immagine è una forma che contiene un’immagine—è come una foto in una cornice.  

È possibile aggiungere un’immagine a una diapositiva tramite un frame immagine. In questo modo, è possibile formattare l’immagine formattando il frame immagine.

{{% alert  title="Suggerimento" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che permettono di creare presentazioni rapidamente a partire da immagini. 

{{% /alert %}} 

## **Crea un Frame Immagine**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un’immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) associata all'oggetto presentazione che verrà usata per riempire la forma.
4. Specifica la larghezza e l’altezza dell’immagine.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) basato sulla larghezza e altezza dell’immagine tramite il metodo `addPictureFrame` esposto dall'oggetto shape associato alla diapositiva di riferimento.
6. Aggiungi un frame immagine (contenente l’immagine) alla diapositiva.
7. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP mostra come creare un frame immagine:

```php
  # Istanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Istanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiunge un frame immagine con l'altezza e la larghezza equivalenti dell'immagine
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Scrive il file PPTX su disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

I frame immagine consentono di creare rapidamente diapositive di presentazione basate su immagini. Quando combini il frame immagine con le opzioni di salvataggio di Aspose.Slides, puoi gestire le operazioni di input/output per convertire le immagini da un formato all’altro. Potresti voler consultare queste pagine: converti [image to JPG](https://products.aspose.com/slides/it/php-java/conversion/image-to-jpg/); converti [JPG to image](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-image/); converti [JPG to PNG](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-png/), converti [PNG to JPG](https://products.aspose.com/slides/it/php-java/conversion/png-to-jpg/); converti [PNG to SVG](https://products.aspose.com/slides/it/php-java/conversion/png-to-svg/), converti [SVG to PNG](https://products.aspose.com/slides/it/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Crea un Frame Immagine con Scala Relativa**

Modificando la scala relativa di un’immagine, è possibile creare un frame immagine più complesso. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungi un’immagine alla collezione immagini della presentazione.
4. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un’immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) associata all'oggetto presentazione che verrà usata per riempire la forma.
5. Specifica la larghezza e altezza relative dell’immagine nel frame immagine.
6. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP mostra come creare un frame immagine con scala relativa:

```php
  # Instanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Recupera la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiunge un Frame Immagine con altezza e larghezza equivalenti dell'immagine
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Imposta larghezza e altezza della scala relativa
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Scrive il file PPTX su disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Estrai Immagini Raster da Frame Immagine**

È possibile estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) e salvarle in PNG, JPG e altri formati. L’esempio di codice seguente dimostra come estrarre un’immagine dal documento “sample.pptx” e salvarla in formato PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Estrai Immagini SVG da Frame Immagine**

Quando una presentazione contiene grafiche SVG collocate all’interno di forme [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/), Aspose.Slides per PHP tramite Java consente di recuperare le immagini vettoriali originali con piena fedeltà. Attraverso l’iterazione della raccolta forme della diapositiva, è possibile identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/), verificare se il relativo [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) contiene contenuto SVG, e quindi salvare quell’immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un’immagine SVG da un frame immagine:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ottieni la Trasparenza di un'Immagine**

Aspose.Slides consente di ottenere l’effetto di trasparenza applicato a un’immagine. Questo codice PHP dimostra l’operazione:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Formattazione del Frame Immagine**

Aspose.Slides offre numerose opzioni di formattazione che possono essere applicate a un frame immagine. Utilizzando tali opzioni, è possibile modificare un frame immagine per soddisfare requisiti specifici.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un’immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) collegata all’oggetto presentazione che verrà usata per riempire la forma.
4. Specifica la larghezza e l’altezza dell’immagine.
5. Crea un `PictureFrame` basato sulla larghezza e altezza dell’immagine tramite il metodo [addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) associato alla diapositiva di riferimento.
6. Aggiungi il frame immagine (contenente l’immagine) alla diapositiva.
7. Imposta il colore della linea del frame immagine.
8. Imposta la larghezza della linea del frame immagine.
9. Ruota il frame immagine assegnandogli un valore positivo o negativo.  
   * Un valore positivo ruota l’immagine in senso orario.  
   * Un valore negativo ruota l’immagine in senso antiorario.
10. Aggiungi nuovamente il frame immagine (contenente l’immagine) alla diapositiva.
11. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP dimostra il processo di formattazione del frame immagine:

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Istanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiunge un Frame Immagine con altezza e larghezza equivalenti dell'immagine
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Applica alcune formattazioni a PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Scrive il file PPTX su disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Suggerimento" color="primary" %}}

Aspose ha recentemente sviluppato un [free Collage Maker](https://products.aspose.app/slides/it/collage). Se hai bisogno di [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o PNG, oppure di [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi utilizzare questo servizio. 

{{% /alert %}}

## **Aggiungi un'Immagine come Collegamento**

Per ridurre le dimensioni della presentazione, è possibile inserire immagini (o video) tramite collegamenti invece di incorporare direttamente i file nella presentazione. Questo codice PHP mostra come aggiungere un’immagine e un video in un segnaposto:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ritaglia le Immagini**

Questo codice PHP mostra come ritagliare un’immagine esistente su una diapositiva:

```php
  $pres = new Presentation();
  # Crea un nuovo oggetto immagine
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Aggiunge un PictureFrame a una diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Ritaglia l'immagine (valori percentuali)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Salva il risultato
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Elimina Aree Ritagliate di un'Immagine**

Se vuoi eliminare le aree ritagliate di un’immagine contenuta in un frame, puoi usare il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Questo metodo restituisce l’immagine ritagliata o l’immagine originale se il ritaglio non è necessario.

Questo codice PHP dimostra l’operazione:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Ottiene il PictureFrame dalla prima diapositiva
    $picFrame = $slide->getShapes()->get_Item(0);
    # Elimina le aree ritagliate dell'immagine del PictureFrame e restituisce l'immagine ritagliata
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Salva il risultato
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTA" color="warning" %}} 

Il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) aggiunge l’immagine ritagliata alla collezione immagini della presentazione. Se l’immagine è utilizzata solo nel [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) elaborato, questa impostazione può ridurre le dimensioni della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafili WMF/EMF in immagini PNG raster durante l’operazione di ritaglio. 

{{% /alert %}}

## **Comprimi le Immagini**

È possibile comprimere un’immagine in una presentazione utilizzando il metodo [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Questo metodo comprime un’immagine riducendone le dimensioni in base alla dimensione della forma e alla risoluzione specificata, con l’opzione di eliminare le aree ritagliate.

Regola la dimensione e la risoluzione dell’immagine in modo simile alla funzionalità **Picture Format → Compress Pictures → Resolution** di PowerPoint.

I seguenti esempi PHP mostrano come comprimere un’immagine in una presentazione specificando una risoluzione target e, opzionalmente, rimuovendo le aree ritagliate:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione web) e rimuovi le aree ritagliate.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Verifica il risultato della compressione.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Oppure utilizzando direttamente un valore DPI personalizzato:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Comprimi l'immagine a 150 DPI (risoluzione web), rimuovendo le aree ritagliate.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTA" color="warning" %}} 

Il metodo converte l’immagine a una risoluzione inferiore in base alla dimensione della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare le dimensioni del file.  
Se l’immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG viene mantenuta o leggermente ridotta in base alla risoluzione, analogamente a quanto fa PowerPoint con i JPEG ad alta risoluzione.

{{% /alert %}}

## **Blocca il Rapporto d'Aspetto**

Se desideri che una forma contenente un’immagine mantenga il suo rapporto d’aspetto anche dopo aver modificato le dimensioni dell’immagine, puoi usare il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) per impostare l’opzione *Lock Aspect Ratio*.

Questo codice PHP mostra come bloccare il rapporto d’aspetto di una forma:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # imposta la forma affinché mantenga il rapporto d'aspetto durante il ridimensionamento
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTA" color="warning" %}} 

Questa impostazione *Lock Aspect Ratio* conserva solo il rapporto d’aspetto della forma e non quello dell’immagine contenuta.

{{% /alert %}}

## **Usa la Proprietà StretchOff**

Utilizzando i metodi [setStretchOffsetLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) e [setStretchOffsetBottom](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) della classe [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/), è possibile specificare un rettangolo di riempimento.

Quando lo stretching è impostato per un’immagine, un rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento specificato. Ogni bordo del rettangolo di riempimento è definito da un offset percentuale rispetto al bordo corrispondente della bounding box della forma. Una percentuale positiva indica un rientro, mentre una percentuale negativa indica un’estensione.

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) class.
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un rettangolo `AutoShape`. 
4. Crea un’immagine.
5. Imposta il tipo di riempimento della forma.
6. Imposta la modalità di riempimento immagine della forma.
7. Aggiungi un’immagine da usare per riempire la forma.
8. Specifica gli offset dell’immagine rispetto al bordo corrispondente della bounding box della forma.
9. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP dimostra un processo in cui viene usata la proprietà StretchOff:

```php
  # Istanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Istanzia la classe ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Aggiunge un AutoShape impostato su Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Imposta il tipo di riempimento della forma
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Imposta la modalità di riempimento immagine della forma
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Imposta l'immagine per riempire la forma
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Specifica gli offset dell'immagine rispetto al bordo corrispondente della bounding box della forma
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Scrive il file PPTX su disco
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso scoprire quali formati immagine sono supportati per PictureFrame?**

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l’oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/). L’elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione di diapositive e immagini.

**Come influenzerà l’aggiunta di decine di immagini di grandi dimensioni la dimensione e le prestazioni del PPTX?**

L’incorporamento di immagini di grandi dimensioni aumenta le dimensioni del file e l’utilizzo di memoria; collegare le immagini aiuta a mantenere ridotte le dimensioni della presentazione, ma richiede che i file esterni rimangano accessibili. Aspose.Slides offre la possibilità di aggiungere immagini tramite collegamento per ridurre le dimensioni del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti o ridimensionamenti accidentali?**

Utilizza i [bloccaggi della forma](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/getpictureframelock/) per un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) (ad esempio, disabilitando lo spostamento o il ridimensionamento). Il meccanismo di blocco è supportato per vari tipi di forma, inclusi i [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG viene preservata durante l’esportazione di una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/php-java/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l’SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.