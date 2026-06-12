---
title: Gestire gli sfondi delle presentazioni in PHP
linktitle: Sfondo della diapositiva
type: docs
weight: 20
url: /it/php-java/presentation-background/
keywords:
- sfondo della presentazione
- sfondo della diapositiva
- colore solido
- colore a gradiente
- sfondo immagine
- trasparenza dello sfondo
- proprietà dello sfondo
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument utilizzando Aspose.Slides per PHP tramite Java, con consigli di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, i gradienti e le immagini sono comunemente usati per gli sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o per una **diapositiva master** (applicata a più diapositive contemporaneamente).

![Sfondo PowerPoint](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione—anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/php-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType] dello sfondo della diapositiva su `Solid`.
4. Usa il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/#getSolidFillColor) su [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio PHP mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Imposta il colore di sfondo della diapositiva a blu.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Salva la presentazione su disco.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta uno sfondo a colore solido per una diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master funge da modello che controlla la formattazione di tutte le diapositive, quindi quando scegli un colore solido per lo sfondo della diapositiva master, viene applicato a tutte le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/php-java/aspose.slides/backgroundtype/) della diapositiva master (tramite `getMasters`) su `OwnBackground`.
3. Imposta il [FillType] dello sfondo della diapositiva master su `Solid`.
4. Usa il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/#getSolidFillColor) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio PHP mostra come impostare un colore solido (verde) come sfondo per una diapositiva master:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Imposta il colore di sfondo della diapositiva Master a verde foresta.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Salva la presentazione su disco.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta uno sfondo a gradiente per una diapositiva**

Un gradiente è un effetto grafico creato da una variazione graduale del colore. Quando usato come sfondo della diapositiva, i gradienti possono rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore a gradiente come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/php-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType] dello sfondo della diapositiva su `Gradient`.
4. Usa il metodo [getGradientFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/#getGradientFormat) su [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) per configurare le impostazioni del gradiente desiderate.
5. Salva la presentazione modificata.

Il seguente esempio PHP mostra come impostare un colore a gradiente come sfondo per una diapositiva:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Applica un effetto gradiente allo sfondo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Salva la presentazione su disco.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre a riempimenti solidi e a gradiente, Aspose.Slides consente di utilizzare immagini come sfondi delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/php-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType] dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine che desideri utilizzare come sfondo della diapositiva.
5. Aggiungi l'immagine alla raccolta di immagini della presentazione.
6. Usa il metodo [getPictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/#getPictureFillFormat) su [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio PHP mostra come impostare un'immagine come sfondo per una diapositiva:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Imposta le proprietà dell'immagine di sfondo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Carica l'immagine.
    $image = Images::fromFile("Tulips.jpg");
    // Aggiungi l'immagine alla raccolta immagini della presentazione.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Salva la presentazione su disco.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento dello sfondo a immagine affiancata e modificare le proprietà di tiling:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Imposta l'immagine utilizzata per il riempimento dello sfondo.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Imposta la modalità di riempimento dell'immagine su Tile e regola le proprietà del tassello.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Leggi di più: [**Immagine a tasselli come texture**](/slides/it/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare il contenuto della diapositiva. Il seguente codice PHP mostra come modificare la trasparenza dell'immagine di sfondo di una diapositiva:

```php
$transparencyValue = 30; // Ad esempio.

// Ottieni la raccolta delle operazioni di trasformazione dell'immagine.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Trova un effetto di trasparenza a percentuale fissa esistente.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Imposta il nuovo valore di trasparenza.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Ottieni il valore dello sfondo della diapositiva**

Aspose.Slides fornisce la classe `BackgroundEffectiveData` per recuperare i valori effettivi dello sfondo di una diapositiva. Questa classe espone il [FillFormat] e il [EffectFormat] effettivi.

Utilizzando il metodo `getBackground` della classe [BaseSlide], è possibile ottenere lo sfondo effettivo di una diapositiva.

Il seguente esempio PHP mostra come ottenere il valore effettivo dello sfondo di una diapositiva:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Recupera lo sfondo efficace, tenendo conto di master, layout e tema.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso ripristinare uno sfondo personalizzato e ristabilire lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo sarà nuovamente ereditato dalla diapositiva [layout](/slides/it/php-java/slide-layout/)/[master](/slides/it/php-java/slide-master/) corrispondente (cioè dallo [sfondo del tema](/slides/it/php-java/presentation-theme/)).

**Cosa succede allo sfondo se cambio più tardi il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/php-java/slide-layout/)/[master](/slides/it/php-java/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/php-java/presentation-theme/).