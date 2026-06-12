---
title: Beheer presentatiethema's in PHP
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/php-java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- diathema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor PHP via Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Introductie**

Een presentatiethema definieert de eigenschappen van designelementen. Wanneer u een presentatiethema selecteert, kiest u in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/php-java/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/php-java/presentation-background/), en effecten.

![thema-onderdelen](theme-constituents.png)

## **Thema‑kleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, kunt u ze wijzigen door nieuwe kleuren voor het thema toe te passen. Om u een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden onder de [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SchemeColor)-enumeratie.

Deze PHP-code laat zien hoe u de accentkleur voor een thema wijzigt:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

U kunt de effectieve waarde van de resulterende kleur op deze manier bepalen:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Om de kleuraanpassing verder te demonstreren, creëren we een ander element en wijzen we de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Thema‑kleur instellen vanuit een extra palet**

Wanneer u luminantietransformaties toepast op de hoofdthemakleur (1), ontstaan kleuren uit het extra palet (2). U kunt vervolgens die themakleuren instellen en ophalen.

![extra-palet-kleuren](additional-palette-colors.png)

**1** - Hoofdthemakleuren  
**2** - Kleuren uit het extra palet.

Deze PHP-code demonstreert een bewerking waarbij extra paletkleuren worden verkregen uit de hoofdthemakleur en vervolgens worden gebruikt in vormen:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Accent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Accent 4, Lichter 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Accent 4, Lichter 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Accent 4, Lichter 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Accent 4, Donkerder 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Accent 4, Donkerder 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor` koppelen aan `ColorScheme`-kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/), merkt u misschien op dat het de volgende themakleurwaarden bevat:
`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation::getMasterTheme()::getColorScheme()` retourneert [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/), die de overeenkomstige kleuren toont als:
`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleurposities en de koppeling is vastgelegd:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit naamverschil komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities tonen als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Thema‑lettertype wijzigen**

Om u in staat te stellen lettertypen te selecteren voor thema’s en andere doeleinden, gebruikt Aspose.Slides deze speciale identifiers (gelijk aan die in PowerPoint):

* **+mn-lt** - Lichaamlettertype Latijn (Klein Latijns Lettertype)
* **+mj-lt** - Koplettertype Latijn (Groot Latijns Lettertype)
* **+mn-ea** - Lichaamlettertype Oost‑Aziatisch (Klein Oost‑Aziatisch Lettertype)
* **+mj-ea** - Lichaamlettertype Oost‑Aziatisch (Groot Oost‑Aziatisch Lettertype)

Deze PHP-code laat zien hoe u het Latijnse lettertype aan een thema‑element toewijst:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Deze PHP-code laat zien hoe u het presentatiethema‑lettertype wijzigt:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

Het lettertype in alle tekstvakken wordt bijgewerkt.
{{% alert color="primary" title="TIP" %}} 
U wilt misschien [PowerPoint‑lettertypen](/slides/nl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑app 12 vooraf gedefinieerde achtergronden, maar slechts 3 van die 12 achtergronden worden opgeslagen in een typische presentatie. 

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze PHP-code uitvoeren om het aantal vooraf gedefinieerde achtergronden in de presentatie te achterhalen:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Met behulp van de [BackgroundFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme)-klasse, kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen.
{{% /alert %}} 

Deze PHP-code laat zien hoe u de achtergrond voor een presentatie instelt:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Indexgids**: 0 wordt gebruikt voor geen opvulling. De index begint bij 1.
{{% alert color="primary" title="TIP" %}} 
U wilt misschien [PowerPoint‑achtergrond](/slides/nl/php-java/presentation-background/) bekijken.
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat doorgaans 3 waarden voor elke stijlaray. Deze arrays worden gecombineerd tot 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten worden toegepast op een specifieke vorm:
![todo:image_alt_text](presentation-design_10.png)

Door 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme#getEffectStyles--)) uit de [FormatScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FormatScheme)-klasse te gebruiken, kunt u de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).
```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

De resulterende wijzigingen in vulkleur, vultype, slagschaduw, enzovoort:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**  
Ja. Aspose.Slides ondersteunt themabijstellingen op dia‑niveau, zodat u een lokaal thema kunt toepassen op slechts die dia terwijl het master‑thema ongewijzigd blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**  
[Clone slides](/slides/nl/php-java/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay‑outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

**Hoe kan ik de 'effectieve' waarden zien na alle overerving en overschrijvingen?**  
Gebruik de ['effectieve' weergaven](/slides/nl/php-java/shape-effective-properties/) van de API voor thema/kleur/lettertype/effect. Deze geven de uiteindelijke, berekende eigenschappen terug na het toepassen van de master plus eventuele lokale overschrijvingen.