---
title: Beheer SmartArt-afbeeldingen in presentaties met PHP
linktitle: SmartArt-afbeeldingen
type: docs
weight: 20
url: /nl/php-java/manage-smartart-shape/
keywords:
- SmartArt-object
- SmartArt-afbeelding
- SmartArt-stijl
- SmartArt-kleur
- SmartArt maken
- SmartArt verwijderen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt lay-outtype
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Automatiseer het maken, bewerken en stylen van PowerPoint SmartArt in PHP met Aspose.Slides, met beknopte code-voorbeelden en prestatiegerichte begeleiding."
---
## **Overzicht**

Aspose.Slides stelt u in staat om programmatisch SmartArt‑afbeeldingen te maken en te beheren in PowerPoint‑presentaties. Deze artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek lay‑outtype en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe u met SmartArt‑vormen werkt via de vormcollectie van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen wijzigt of inspecteert.

## **Maak een SmartArt‑vorm**

Aspose.Slides for PHP via Java biedt een API om SmartArt‑vormen te maken. Volg de onderstaande stappen om een SmartArt‑vorm in een dia te maken:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation).
1. Verkrijg de referentie van een dia door gebruik te maken van de Index.
1. [Voeg een SmartArt‑vorm toe](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addSmartArt) door het [LayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtLayoutType) in te stellen.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een SmartArt-vorm toe
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Sla de presentatie op
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm toegevoegd aan de dia**|

## **Toegang tot een SmartArt‑vorm op een dia**

De volgende code wordt gebruikt om de SmartArt‑vormen die aan de presentatiedia zijn toegevoegd te benaderen. In de voorbeeldcode lopen we door elke vorm in de dia en controleren we of het een [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt)‑vorm is. Als de vorm van het type SmartArt is, casten we deze naar een [**SmartArt**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt)‑instantie.

```php
  # Laad de gewenste presentatie
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast de vorm naar SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Toegang tot een SmartArt‑vorm met een specifiek lay‑outtype**

De volgende voorbeeldcode helpt om de [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt)‑vorm met een bepaald LayoutType te benaderen. Houd er rekening mee dat u het LayoutType van de SmartArt niet kunt wijzigen, omdat het alleen‑lezen is en alleen wordt ingesteld wanneer de [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt)‑vorm wordt toegevoegd.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt als het SmartArt is.
1. Controleer de SmartArt‑vorm met het specifieke LayoutType en voer daarna de benodigde handelingen uit.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast de vorm naar SmartArtEx
        $smart = $shape;
        # Controle van SmartArt-layout
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wijzig de stijl van een SmartArt‑vorm**

In dit voorbeeld leren we hoe we de snelle stijl van een SmartArt‑vorm kunnen wijzigen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt als het SmartArt is.
1. Zoek de SmartArt‑vorm met een specifieke stijl.
1. Stel de nieuwe stijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Haal de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Doorloop elke vorm in de eerste dia
    foreach($slide->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast de vorm naar SmartArtEx
        $smart = $shape;
        # Controle van SmartArt-stijl
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Wijziging van SmartArt-stijl
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Sla de presentatie op
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde stijl**|

## **Wijzig de kleurstijl van een SmartArt‑vorm**

In dit voorbeeld leren we hoe we de kleurstijl van een SmartArt‑vorm kunnen wijzigen. In de volgende voorbeeldcode benaderen we de SmartArt‑vorm met een specifieke kleurstijl en wijzigen we deze.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt als het SmartArt is.
1. Zoek de SmartArt‑vorm met een specifieke kleurstijl.
1. Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Haal de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Doorloop elke vorm in de eerste dia
    foreach($slide->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Cast de vorm naar SmartArtEx
        $smart = $shape;
        # Controle van SmartArt-kleurtype
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Wijziging van SmartArt-kleurtype
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Sla de presentatie op
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde kleurstijl**|

## **FAQ**

**Kan ik SmartArt als één object animeren?**

Ja. SmartArt is een vorm, dus u kunt [standaardanimaties](/slides/nl/php-java/powerpoint-animation/) toepassen via de animaties‑API (invoer, uitgang, nadruk, bewegingspaden) net als bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de alternatieve tekst (AltText) in en gebruik deze om naar de vorm te zoeken—dit is een aanbevolen manier om de doelvorm te vinden.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de groep [manipuleren](/slides/nl/php-java/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijvoorbeeld voor een voorbeeld of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/php-java/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de hele presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwheid voor [PDF‑export](/slides/nl/php-java/convert-powerpoint-to-pdf/), met diverse kwaliteits‑ en compatibiliteitsopties.