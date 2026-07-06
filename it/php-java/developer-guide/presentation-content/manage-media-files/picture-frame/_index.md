---
title: Gestisci i riquadri immagine nelle presentazioni con PHP
linktitle: Riquadro immagine
type: docs
weight: 10
url: /it/php-java/picture-frame/
keywords:
- riquadro immagine
- aggiungi riquadro immagine
- crea riquadro immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione riquadro immagine
- proprietà riquadro immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi riquadri immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java. Ottimizza il tuo flusso di lavoro e migliora il design delle diapositive."
---
## **Introduzione**

Un riquadro immagine è una forma che contiene un'immagine—è come un'immagine in una cornice. 

Puoi aggiungere un'immagine a una diapositiva tramite un riquadro immagine. In questo modo, puoi formattare l'immagine formattando il riquadro immagine.

{{% alert  title="Suggerimento" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente dalle immagini. 

{{% /alert %}} 

## **Crea un riquadro immagine**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) associata all'oggetto presentation che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) basato sulla larghezza e sull'altezza dell'immagine mediante il metodo `addPictureFrame` esposto dall'oggetto shape associato alla diapositiva di riferimento.
6. Aggiungi un riquadro immagine (contenente l'immagine) alla diapositiva.
7. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP mostra come creare un riquadro immagine:

```php
  # Istanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Istanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiunge un riquadro immagine con l'altezza e la larghezza equivalenti dell'immagine
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

I riquadri immagine consentono di creare rapidamente diapositive di presentazione basate su immagini. Quando combini un riquadro immagine con le opzioni di salvataggio di Aspose.Slides, puoi manipolare le operazioni di input/output per convertire le immagini da un formato all'altro. Potresti voler vedere queste pagine: converti [immagine a JPG](https://products.aspose.com/slides/it/php-java/conversion/image-to-jpg/); converti [JPG a immagine](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-image/); converti [JPG a PNG](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-png/), converti [PNG a JPG](https://products.aspose.com/slides/it/php-java/conversion/png-to-jpg/); converti [PNG a SVG](https://products.aspose.com/slides/it/php-java/conversion/png-to-svg/), converti [SVG a PNG](https://products.aspose.com/slides/it/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Crea un riquadro immagine con scala relativa**

Modificando la scala relativa di un'immagine, puoi creare un riquadro immagine più complesso. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungi un'immagine alla collezione immagini della presentazione.
4. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) associata all'oggetto presentation che verrà usato per riempire la forma.
5. Specifica la larghezza e l'altezza relative dell'immagine nel riquadro immagine.
6. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP mostra come creare un riquadro immagine con scala relativa:

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Istanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiungi un riquadro immagine con altezza e larghezza equivalenti dell'immagine
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Impostazione della scala relativa per larghezza e altezza
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Scrivi il file PPTX su disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Estrai immagini raster dai riquadri immagine**

Puoi estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) e salvarle in PNG, JPG e altri formati. L'esempio di codice qui sotto dimostra come estrarre un'immagine dal documento "sample.pptx" e salvarla in formato PNG.

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

## **Estrai immagini SVG dai riquadri immagine**

Quando una presentazione contiene grafiche SVG posizionate all'interno di forme [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/), Aspose.Slides per PHP tramite Java ti consente di recuperare le immagini vettoriali originali con piena fedeltà. Attraverso l'analisi della collezione forme della diapositiva, puoi identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/), verificare se l'oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) sottostante contiene contenuto SVG, e quindi salvare quell'immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un'immagine SVG da un riquadro immagine:

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

## **Ottieni la trasparenza di un'immagine**

Aspose.Slides consente di ottenere l'effetto trasparenza applicato a un'immagine. Questo codice PHP dimostra l'operazione:

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

## **Ottieni luminosità e contrasto di un'immagine**

Aspose.Slides consente di ottenere l'effetto luminosità e contrasto applicato a un'immagine. La classe [Luminance](https://reference.aspose.com/slides/it/php-java/aspose.slides/luminance/) rappresenta questo effetto di trasformazione dell'immagine.

Questo codice PHP mostra come ottenere le impostazioni di luminosità e contrasto da un riquadro immagine:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Formattazione del riquadro immagine**

Aspose.Slides fornisce molte opzioni di formattazione che possono essere applicate a un riquadro immagine. Utilizzando tali opzioni, puoi modificare un riquadro immagine per farlo corrispondere a requisiti specifici.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) aggiungendo un'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) associata all'oggetto presentation che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un `PictureFrame` basato sulla larghezza e sull'altezza dell'immagine mediante il metodo [addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) associato alla diapositiva di riferimento.
6. Aggiungi il riquadro immagine (contenente l'immagine) alla diapositiva.
7. Imposta il colore della linea del riquadro immagine.
8. Imposta lo spessore della linea del riquadro immagine.
9. Ruota il riquadro immagine fornendogli un valore positivo o negativo.
   * Un valore positivo ruota l'immagine in senso orario. 
   * Un valore negativo ruota l'immagine in senso antiorario.
10. Aggiungi il riquadro immagine (contenente l'immagine) alla diapositiva.
11. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP dimostra il processo di formattazione del riquadro immagine:

```php
  # Instanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instanzia la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Aggiunge un riquadro immagine con altezza e larghezza equivalenti dell'immagine
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

Aspose ha recentemente sviluppato un [Collage Maker gratuito](https://products.aspose.app/slides/it/collage). Se hai mai bisogno di [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o immagini PNG, [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi usare questo servizio. 

{{% /alert %}}

## **Aggiungi un'immagine come collegamento**

Per evitare dimensioni elevate della presentazione, puoi aggiungere immagini (o video) tramite collegamenti invece di incorporare direttamente i file nelle presentazioni. Questo codice PHP mostra come aggiungere un'immagine e un video in un segnaposto:

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

## **Ritaglia immagini**

Questo codice PHP mostra come ritagliare un'immagine esistente su una diapositiva:

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

## **Elimina aree ritagliate di un'immagine**

Se desideri eliminare le aree ritagliate di un'immagine contenuta in un riquadro, puoi utilizzare il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Questo metodo restituisce l'immagine ritagliata o l'immagine originale se il ritaglio non è necessario.

Questo codice PHP dimostra l'operazione:

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

Il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) aggiunge l'immagine ritagliata alla collezione immagini della presentazione. Se l'immagine è utilizzata solo nel [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) elaborato, questa impostazione può ridurre le dimensioni della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafile WMF/EMF in immagini PNG raster durante l'operazione di ritaglio. 

{{% /alert %}}

## **Comprimi immagini**

Puoi comprimere un'immagine in una presentazione utilizzando il metodo [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Questo metodo comprime un'immagine riducendone la dimensione in base alla taille della forma e alla risoluzione specificata, con l'opzione di eliminare le aree ritagliate.

Regola la dimensione e la risoluzione dell'immagine in modo simile alla funzionalità **Formato immagine → Comprimi immagini → Risoluzione** di PowerPoint.

I seguenti esempi PHP mostrano come comprimere un'immagine in una presentazione specificando una risoluzione target e, opzionalmente, rimuovendo le aree ritagliate:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione web) e rimuovi le aree ritagliate.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Controlla il risultato della compressione.
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

Oppure usando direttamente un valore DPI personalizzato:

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

Il metodo converte l'immagine a una risoluzione inferiore in base alla taille della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare le dimensioni del file.  
Se l'immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG viene conservata o leggermente ridotta in base alla risoluzione, similmente a quanto fa PowerPoint con JPEG ad alta risoluzione.

{{% /alert %}}

## **Blocca proporzioni**

Se desideri che una forma che contiene un'immagine mantenga le sue proporzioni anche dopo aver modificato le dimensioni dell'immagine, puoi utilizzare il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) per impostare l'opzione *Lock Aspect Ratio*.

Questo codice PHP mostra come bloccare le proporzioni di una forma:

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
    # imposta la forma per preservare il rapporto d'aspetto durante il ridimensionamento
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTA" color="warning" %}} 

Questa impostazione *Lock Aspect Ratio* preserva solo le proporzioni della forma e non l'immagine contenuta.

{{% /alert %}}

## **Usa la proprietà StretchOff**

Utilizzando i metodi [setStretchOffsetLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) e [setStretchOffsetBottom](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) della classe [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/), puoi specificare un rettangolo di riempimento.

Quando si specifica lo stretching per un'immagine, un rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento specificato. Cada bordo del rettangolo di riempimento è definito da un offset percentuale dal corrispondente bordo del riquadro delimitante della forma. Una percentuale positiva indica un inset, mentre una percentuale negativa indica un outset.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un rettangolo `AutoShape`. 
4. Crea un'immagine.
5. Imposta il tipo di riempimento della forma.
6. Imposta la modalità di riempimento immagine della forma.
7. Aggiungi un'immagine di riempimento alla forma.
8. Specifica gli offset dell'immagine dal corrispondente bordo del riquadro delimitante della forma.
9. Scrivi la presentazione modificata come file PPTX.

Questo codice PHP dimostra un processo in cui viene utilizzata la proprietà StretchOff:

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
    # Aggiunge un AutoShape impostato a Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Imposta il tipo di riempimento della forma
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Imposta la modalità di riempimento immagine della forma
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Imposta l'immagine per riempire la forma
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Specifica gli offset dell'immagine dal corrispondente bordo del riquadro delimitante della forma
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

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l'oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/). L'elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione di diapositive e immagini.

**Come influisce l'aggiunta di decine di immagini di grandi dimensioni sulla dimensione e sulle prestazioni del PPTX?**

Incorporare immagini di grandi dimensioni aumenta la dimensione del file e l'utilizzo della memoria; collegare le immagini aiuta a mantenere ridotte le dimensioni della presentazione ma richiede che i file esterni rimangano accessibili. Aspose.Slides offre la possibilità di aggiungere immagini tramite collegamento per ridurre la dimensione del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti/ridimensionamenti accidentali?**

Usa i [blocco forme](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/getpictureframelock/) per un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) (ad esempio, disabilita lo spostamento o il ridimensionamento). Il meccanismo di blocco è supportato per vari tipi di forma, incluso [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG viene preservata quando si esporta una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/php-java/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l'SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.