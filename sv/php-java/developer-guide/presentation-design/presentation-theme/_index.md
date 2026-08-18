---
title: Hantera presentationsteman i PHP
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/php-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
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
description: "Behärska presentationsteman i Aspose.Slides för PHP via Java för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt refererar till dessa delade definitioner istället för att lagra varje visuell egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). En presentation kan också innehålla temaarv på lägre nivåer. En master kan överskrida presentations-temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan överskrida sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild upp genom denna arvskedja: presentations-tema, master‑överskrivning, layout‑överskrivning och bild‑överskrivning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa av effektiva värden efter att arv och överskrivningar har lösts.

## **Inspektera ett tema**

[MasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/)‑objektet exponerar temats färgschema, teckensnittsschema och format‑schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är speciellt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stil‑poster kan variera.

Följande exempel läser huvud‑tema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Om en fil använder flera master‑bilder, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden, och använd arbetsflödet för effektiva teman som visas senare i den här artikeln när layout‑ eller bild‑överskrivningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från [SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/schemecolor/)-enumerationen. När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Eftersom rektangeln fortfarande är kopplad till `Accent4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schema‑färgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformationer. Aspose.Slides exponerar dessa transformationer via [ColorTransformOperation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colortransformoperation/)-enumerationen.

![Huvudtemafärger och ljusare samt mörkare färger som genereras från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformationer på fem av dem och sparar resultatet:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `ColorScheme`‑platser**

[SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/schemecolor/)-enumerationen använder `Text1`, `Background1`, `Text2` och `Background2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorscheme/)-klassen exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller ett huvudteckensnitt för rubriker och ett mindre teckensnitt för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/) exponerar dessa uppsättningar.

PowerPoint‑kompatibla temateckensnittsidenterare kan användas i textformatering:

* `+mn-lt` – Brödtext‑Latin (Minor Latin Font)
* `+mj-lt` – Rubrik‑Latin (Major Latin Font)
* `+mn-ea` – Brödtext‑Östasiatisk (Minor East Asian Font)
* `+mj-ea` – Rubrik‑Östasiatisk (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora latin‑temateckensnittet och en brödtextrad som använder det lilla latin‑temateckensnittet. Därefter ändras temateckensnitten och resultatet sparas:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rubriken följer det stora teckensnittet och brödtexten följer det lilla teckensnittet. Text som har ett explicit teckensnittsnamn istället för en temaidentifierare byter inte automatiskt när temateckensnittsschemat förändras.

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern in i mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/) och den klonade mastern. Detta för med sig mastern, dess layouter och det associerade temat tillsammans.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll på en orelaterad destinations‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste behålla sin nuvarande master och layout, initiera en bildnivå‑överskrivning från källtemat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/) kopierar de tre huvudtema‑komponenterna till överskrivningen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala överskrivningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/).

### **Tillämpa en temaöverskrivning på en layout**

En layout‑nivå‑överskrivning gäller för bilder som använder den layouten, såvida inte en viss bild har sin egen överskrivning. De samma initierings‑metoderna kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑överskrivning när en layout‑familj behöver annan styling, och en bild‑överskrivning endast för egentliga undantag. Överdrivna bild‑nivå‑överskrivningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstilsgalleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/). Ett stil‑index på `0` betyder ingen temafyllning; positiva värden är temabakgrund‑stilreferenser. Detta skiljer sig från att indexera PHP‑samlingen direkt, där `get_Item(0)` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första mastern och sparar presentationen:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Det synliga resultatet beror på temaposten som mastern refererar till samt eventuella bakgrunds‑överskrivningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av endast master‑bakgrunden lämna bilden oförändrad. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}
Behandla inte stil‑indexet som ett nollbaserat samlings‑index. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/php-java/presentation-background/).
{{% /alert %}}

## **Uppdatera temats effekter**

Ett temafor‑schema innehåller separata samlingar för fyllning, linje och effektstil som exponeras via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/) och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i PHP är samlings‑indexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En forms stil‑referens‑index är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapestyle/). Att ändra en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakt visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje-, fyllnings‑ och skugginställningar](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temaobjekt berättar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala överskrivningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Använd effektiva data för rendering‑diagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), kan du missa en master‑, layout‑, bild‑ eller form‑överskrivning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidethememanager/) och initiera dess överskrivningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona käll‑mastern in i destinationen och klona bilden med den mastern med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/). Detta behåller mastern, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och överskrivningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑datametoderna för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och överskrivningar har tillämpats.