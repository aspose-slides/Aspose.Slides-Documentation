---
title: Hantera bakgrunder för presentationer i PHP
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/php-java/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- solid färg
- gradientfärg
- bakgrundsbild
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för PHP via Java, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bakgrund för bilder. Du kan sätta bakgrunden för en **normal bild** (en enskild bild) eller en **masterbild** (gäller flera bilder samtidigt).

![PowerPoint-bakgrund](powerpoint-background.png)

## **Ställ in en solid färgbakgrund för en normal bild**

Aspose.Slides gör det möjligt att ange en solid färg som bakgrund för en specifik bild i en presentation—även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/#getSolidFillColor) på [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande PHP-exempel visar hur du ställer in en blå solid färg som bakgrund för en normal bild:

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ställ in bakgrundsfärgen för bilden till blå.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Spara presentationen till disk.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in en solid färgbakgrund för en masterbild**

Aspose.Slides gör det möjligt att ange en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/backgroundtype/) (via `getMasters`) till `OwnBackground`.
3. Ställ in masterbildens bakgrund [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/#getSolidFillColor) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande PHP-exempel visar hur du ställer in en solid färg (grön) som bakgrund för en masterbild:

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Ställ in bakgrundsfärgen för masterbilden till skogsgrön.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Spara presentationen till disk.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapas genom en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides gör det möjligt att ange en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Gradient`.
4. Använd metoden [getGradientFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/#getGradientFormat) på [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) för att konfigurera dina önskade gradientinställningar.
5. Spara den ändrade presentationen.

Följande PHP-exempel visar hur du ställer in en gradientfärg som bakgrund för en bild:

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Tillämpa en gradienteffekt på bakgrunden.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Spara presentationen till disk.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in en bild som bakgrund för en bild**

Förutom solida och gradientfyllningar gör Aspose.Slides det möjligt att använda bilder som bildbakgrunder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Picture`.
4. Läs in den bild du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd metoden [getPictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/#getPictureFillFormat) på [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den ändrade presentationen.

Följande PHP-exempel visar hur du ställer in en bild som bakgrund för en bild:

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ställ in bildbakgrundens egenskaper.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Läs in bilden.
    $image = Images::fromFile("Tulips.jpg");
    // Lägg till bilden i presentationens bildsamling.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Spara presentationen till disk.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Följande kodexempel visar hur du ställer in bakgrundsfyllnadstypen till en tilead bild och ändrar tileinställningarna:

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

    // Ange bilden som används för bakgrundsfyllningen.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Ställ in bildfyllnadsläget till Tile och justera tile-egenskaperna.
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
Läs mer: [**Tile Picture As Texture**](/slides/sv/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bilds bakgrundsbild för att få bildens innehåll att sticka ut. Följande PHP-kod visar hur du ändrar transparensen för en bilds bakgrundsbild:

```php
$transparencyValue = 30; // Till exempel.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides erbjuder klassen `BackgroundEffectiveData`class för att hämta en bilds faktiska bakgrundsvärden. Denna klass exponerar den faktiska [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) och [EffectFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effectformat/).

Genom att använda `getBackground`-metoden i klassen [BaseSlide] kan du hämta den faktiska bakgrunden för en bild.

Följande PHP-exempel visar hur du får en bilds faktiska bakgrundsvärde:

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Hämta den faktiska bakgrunden, med hänsyn till master, layout och tema.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Kan jag återställa en anpassad bakgrund och återställa tema-/layoutbakgrunden?**

Ja. Ta bort bildens anpassade fyllning, så kommer bakgrunden igen att ärvas från den motsvarande [layout](/slides/sv/php-java/slide-layout/)-/[master](/slides/sv/php-java/slide-master/)-bilden (dvs. [theme background](/slides/sv/php-java/presentation-theme/)).

**Vad händer med bakgrunden om jag ändrar presentationens tema senare?**

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/php-java/slide-layout/)-/[master](/slides/sv/php-java/slide-master/) uppdateras den för att matcha [new theme](/slides/sv/php-java/presentation-theme/).