---
title: Hantera presentationsteman i PHP
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/php-java/presentation-theme/
keywords:
- PowerPoint tema
- presentationstema
- bildtema
- ställ in tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera presentationsteman i Aspose.Slides för PHP via Java för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar egenskaperna för designelement. När du väljer ett presentationstema väljer du i praktiken en specifik uppsättning visuella element och deras egenskaper.

I PowerPoint består ett tema av färger, [teckensnitt](/slides/sv/php-java/powerpoint-fonts/), [bakgrundsstilar](/slides/sv/php-java/presentation-background/), och effekter.

![theme-constituents](theme-constituents.png)

## **Ändra temafärg**

Ett PowerPoint‑tema använder en specifik uppsättning färger för olika element på en bild. Om du inte gillar färgerna kan du ändra dem genom att tillämpa nya färger för temat. För att du ska kunna välja en ny temafärg tillhandahåller Aspose.Slides värden i [SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SchemeColor)‑enumerationen.

Den här PHP‑koden visar hur du ändrar accentfärgen för ett tema:

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

Du kan på detta sätt bestämma den resulterande färgens effektiva värde:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

För att ytterligare demonstrera färgändringsoperationen skapar vi ett annat element och tilldelar accentfärgen (från den första operationen) till det. Sedan ändrar vi färgen i temat:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Den nya färgen tillämpas automatiskt på båda elementen.

### **Ställ in temafärg från ett extra färgpalett**

När du tillämpar luminans‑transformationer på huvudtemafärgen(1) bildas färger från den extra paletten(2). Du kan sedan ställa in och hämta dessa temafärger. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Huvudtemafärger

**2** - Färger från den extra paletten.

Den här PHP‑koden demonstrerar en operation där extra palettfärger hämtas från huvudtemafärgen och sedan används i former:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Accent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Accent 4, Ljusare 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Accent 4, Ljusare 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Accent 4, Ljusare 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Accent 4, Mörkare 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Accent 4, Mörkare 50%
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

### **Mappa `SchemeColor` till `ColorScheme`‑färger**

När du arbetar med [SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/schemecolor/), kan du märka att den innehåller följande temafärgvärden:

`Background1`, `Background2`, `Text1` och `Text2`.

Dock returnerar `Presentation::getMasterTheme()::getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorscheme/), som visar motsvarande färger som:

`Dark1`, `Dark2`, `Light1` och `Light2`.

Denna skillnad är bara i namngivning. Dessa värden hänvisar till samma temafärgsplatser och mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Det finns ingen dynamisk konvertering mellan `Text`/`Background` och `Dark`/`Light`. De är helt enkelt alternativa namn för samma temafärger.

Denna namnskillnad kommer från Microsoft Office‑terminologi. Äldre Office‑versioner använde `Dark 1`, `Light 1`, `Dark 2` och `Light 2`, medan nyare UI‑versioner visar samma fack som `Text 1`, `Background 1`, `Text 2` och `Background 2`.

## **Ändra temateckensnitt**

För att du ska kunna välja teckensnitt för teman och andra ändamål använder Aspose.Slides dessa speciella identifierare (liknande de som används i PowerPoint):

* **+mn-lt** – Kroppstext‑teckensnitt Latin (Minor Latin Font)
* **+mj-lt** – Rubrik‑teckensnitt Latin (Major Latin Font)
* **+mn-ea** – Kroppstext‑teckensnitt Östasiatiskt (Minor East Asian Font)
* **+mj-ea** – Rubrik‑teckensnitt Östasiatiskt (Major East Asian Font)

Den här PHP‑koden visar hur du tilldelar det latinska teckensnittet till ett temaelement:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Den här PHP‑koden visar hur du ändrar presentationens temateckensnitt:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Teckensnittet i alla textrutor kommer att uppdateras.

{{% alert color="primary" title="TIP" %}} 
Du kan vilja se [PowerPoint‑teckensnitt](/slides/sv/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Ändra temats bakgrundsstil**

Som standard erbjuder PowerPoint‑appen 12 fördefinierade bakgrunder men bara 3 av dessa 12 bakgrunder sparas i en typisk presentation. 

![todo:image_alt_text](presentation-design_8.png)

Till exempel, efter att du sparat en presentation i PowerPoint‑appen kan du köra den här PHP‑koden för att ta reda på antalet fördefinierade bakgrunder i presentationen:

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
Genom att använda [BackgroundFillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) egenskapen från [FormatScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FormatScheme)‑klassen kan du lägga till eller komma åt bakgrundsstilen i ett PowerPoint‑tema.
{{% /alert %}} 

Den här PHP‑koden visar hur du anger bakgrunden för en presentation:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Indexguide**: 0 används för ingen fyllning. Indexet startar från 1.

{{% alert color="primary" title="TIP" %}} 
Du kan vilja se [PowerPoint‑bakgrund](/slides/sv/php-java/presentation-background/).
{{% /alert %}}

## **Ändra temaeffekt**

Ett PowerPoint‑tema innehåller vanligtvis 3 värden för varje stilarray. Dessa arrayer kombineras till de 3 effekterna: subtil, måttlig och intensiv. Till exempel så ser resultatet ut när effekterna tillämpas på en specifik form:

![todo:image_alt_text](presentation-design_10.png)

Genom att använda 3 egenskaper ([FillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FormatScheme#getEffectStyles--)) från klassen [FormatScheme] kan du ändra element i ett tema (ännu mer flexibelt än alternativen i PowerPoint).

Den här PHP‑koden visar hur du ändrar en temaeffekt genom att modifiera delar av element:

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

De resulterande förändringarna i fyllningsfärg, fyllningstyp, skuggeffekt osv:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Aspose.Slides stöder tema‑överskrivningar på bildnivå, så du kan tillämpa ett lokalt tema på just den bilden samtidigt som du behåller mastern temat intakt (via [SlideThemeManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidethememanager/)).

**Vad är det säkraste sättet att överföra ett tema från en presentation till en annan?**

Klona bilder tillsammans med deras master till mål­presentationen. Detta bevarar den ursprungliga master‑layouten och det tillhörande temat så att utseendet förblir konsekvent.

**Hur kan jag se de ”effektiva” värdena efter all arv och överskrivningar?**

Använd API‑ets ["effective"](/slides/sv/php-java/shape-effective-properties/)‑vyer för tema/färg/teckensnitt/effekt. Dessa returnerar de lösta, slutliga egenskaperna efter att mastern och eventuella lokala överskrivningar har tillämpats.