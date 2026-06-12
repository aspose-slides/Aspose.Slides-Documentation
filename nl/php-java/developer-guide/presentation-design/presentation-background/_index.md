---
title: Beheer presentatie‑achtergronden in PHP
linktitle: Dia‑achtergrond
type: docs
weight: 20
url: /nl/php-java/presentation-background/
keywords:
- presentatie‑achtergrond
- dia‑achtergrond
- effen kleur
- verloopkleur
- afbeeldings‑achtergrond
- achtergrondtransparantie
- achtergrond‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden kunt instellen in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor PHP via Java, met code‑tips om uw presentaties te verbeteren."
---
## **Introductie**

Solide kleuren, verlopen en afbeeldingen worden vaak gebruikt voor dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **masterdia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint background](powerpoint-background.png)

## **Een effenkleurige achtergrond instellen voor een normale dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie—zelfs als de presentatie een masterdia gebruikt. De wijziging is alleen van toepassing op de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de achtergrond van de dia [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/#getSolidFillColor) methode op [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende PHP‑voorbeeld laat zien hoe je een blauwe effen kleur als achtergrond voor een normale dia instelt:

```php
// Maak een instantie van de Presentation‑klasse aan.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Stel de achtergrondkleur van de dia in op blauw.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Sla de presentatie op schijf.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Effenkleurige achtergrond instellen voor een masterdia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor de masterdia in een presentatie. De masterdia fungeert als een sjabloon die de opmaak voor alle dia’s beheert, dus wanneer je een effen kleur kiest voor de achtergrond van de masterdia, wordt deze op elke dia toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/backgroundtype/) van de masterdia (via `getMasters`) in op `OwnBackground`.
3. Stel de achtergrond van de masterdia [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/#getSolidFillColor) methode om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende PHP‑voorbeeld laat zien hoe je een effen kleur (groen) als achtergrond voor een masterdia instelt:

```php
// Maak een instantie van de Presentation‑klasse aan.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Stel de achtergrondkleur van de masterdia in op bosgroen.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Sla de presentatie op schijf.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een verlopen achtergrond instellen voor een dia**

Een verloop is een grafisch effect dat wordt gecreëerd door een geleidelijke kleurverandering. Wanneer het wordt gebruikt als dia‑achtergrond, kunnen verlopen presentaties er artistieker en professioneler uit laten zien. Aspose.Slides stelt je in staat om een verloopkleur als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de achtergrond van de dia [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/#getGradientFormat) methode op [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) om je gewenste verloopinstellingen te configureren.
5. Sla de aangepaste presentatie op.

Het volgende PHP‑voorbeeld laat zien hoe je een verloopkleur als achtergrond voor een dia instelt:

```php
// Maak een instantie van de Presentation‑klasse aan.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Pas een verloop‑effect toe op de achtergrond.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Sla de presentatie op schijf.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een afbeelding als dia‑achtergrond instellen**

Naast effen en verlopen opvullingen stelt Aspose.Slides je in staat om afbeeldingen als dia‑achtergronden te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de achtergrond van de dia [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) in op `Picture`.
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/#getPictureFillFormat) methode op [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de aangepaste presentatie op.

Het volgende PHP‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia instelt:

```php
// Maak een instantie van de Presentation‑klasse aan.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Stel de achtergrond‑afbeeldings‑eigenschappen in.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Laad de afbeelding.
    $image = Images::fromFile("Tulips.jpg");
    // Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Sla de presentatie op schijf.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De volgende codevoorbeeld laat zien hoe je het achtergrond‑opvultype instelt op een betegelde afbeelding en de tegelings‑eigenschappen wijzigt:

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

    // Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Stel de picture fill mode in op Tile en pas de tegel‑eigenschappen aan.
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
Lees meer: [**Tile Picture As Texture**](/slides/nl/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparantie van de achtergrondafbeelding wijzigen**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter opvalt. De volgende PHP‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding wijzigt:

```php
$transparencyValue = 30; // Bijvoorbeeld.

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

## **De achtergrondwaarde van de dia ophalen**

Aspose.Slides biedt de `BackgroundEffectiveData`class voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze class maakt de effectieve [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effectformat/) beschikbaar.

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/) class kun je de effectieve achtergrond van een dia verkrijgen.

Het volgende PHP‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```php
// Maak een instantie van de Presentation-klasse aan.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Haal de effectieve achtergrond op, rekening houdend met master, lay-out en thema.
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

**Kan ik een aangepaste achtergrond resetten en het thema/lay-out achtergrond herstellen?**

Ja. Verwijder de aangepaste opvulling van de dia, dan wordt de achtergrond opnieuw geërfd van de bijbehorende [layout](/slides/nl/php-java/slide-layout/)/[master](/slides/nl/php-java/slide-master/) dia (d.w.z. de [thema‑achtergrond](/slides/nl/php-java/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia zijn eigen opvulling heeft, blijft deze ongewijzigd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/php-java/slide-layout/)/[master](/slides/nl/php-java/slide-master/), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/php-java/presentation-theme/).