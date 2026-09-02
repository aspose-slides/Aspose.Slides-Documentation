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
- ange tema
- ändra tema
- hantera tema
- externt tema
- THMX
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

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuell egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides finns temat på presentationsnivå tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). En presentation kan också innehålla temaarbeten på lägre nivåer. En master kan åsidosätta presentationstemat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterthememanager/), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/). I praktiken löses det effektiva temat för en bild upp genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/) exponerar temats färgschema, teckensnittsschema och format‑schema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposterna kan variera.

Det följande exemplet läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och efektsstilar som lagras i temat:

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

Om en fil använder flera mästare, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden och använd det effektiva temaarbetsflödet som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/schemecolor/). När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

Det följande end‑to‑end‑exemplet skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schema‑färgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare och mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** - Huvudtemafärger.

**2** - Ljusare och mörkare varianter genererade från huvudtemafärgerna.

Det följande exemplet skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare räknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Kartlägg `SchemeColor`‑värden till `ColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssats för rubriker och en sekundär teckensnittssats för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/) exponerar dessa satser.

PowerPoint‑kompatibla temateckensnittsidentifierare kan användas i textformatering:

* `+mn-lt` - Kroppteckensnitt Latin (Minor Latin Font)
* `+mj-lt` - Rubrikteckensnitt Latin (Major Latin Font)
* `+mn-ea` - Kroppteckensnitt Östasiatiskt (Minor East Asian Font)
* `+mj-ea` - Rubrikteckensnitt Östasiatiskt (Major East Asian Font)

Det följande exemplet skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtextlinje som använder sekundärt Latin‑temateckensnitt. Det ändrar därefter temateckensnitten och sparar resultatet:

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

Rubriken följer huvudteckensnittet och brödtexten följer det mindre teckensnittet. Text som har ett explicit teckensnittsnamn istället för ett tematiskt identifierare byts inte automatiskt när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script-Specific Theme Fonts](/slides/sv/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
För mer information om presentationsteckensnitt, se [PowerPoint Fonts](/slides/sv/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en mästares beroende bilder**

Använd [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) när du har en PowerPoint‑temafil (`.thmx`) och vill omdesigna varje bild som beror på en viss master. Välj master från [Presentation::getMasters](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑samlingen, som representeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar ett nytt mästarbildspel baserat på den valda master.
2. Tillämpa det externa temat på den nya master.
3. Tilldela den nya master till alla bilder som tidigare berodde på den valda master.
4. Returnerar den nyss skapade [MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/).

Det följande exemplet tillämpar ett externt tema på de bilder som beror på den första master‑bilden och sparar presentationen:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ett ogiltigt, korrupt eller ej stödjande tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxreadexception/). Validera sökvägar som anges av användare, hantera filsystemsåtkomstfel och spara presentationen först när temat har tillämpats utan problem.

Endast de bilder som berodde på den valda master‑bilden omplaceras. Bilder som är kopplade till andra mästare behåller sina befintliga mästare och teman. Temamedvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvs från den nya master‑bilden.

Temat kan referera till teckensnitt som inte finns i runtime‑miljön. För enhetlig rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/php-java/custom-font/), eller konfigurera [font substitution](/slides/sv/php-java/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver ingen manuell skapning av bild‑ eller layout‑återskrivningar.

### **Tillämpa olika externa teman i en presentation med flera mästare**

När den relevanta master‑bilden inte är känd i förväg, hämta den från en representativ bild via [Slide::getLayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/) och [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Det följande exemplet använder bilder från två sektioner för att lokalisera deras master‑bilder och tillämpar ett annat externt tema på varje grupp:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Det första anropet påverkar endast de bilder som beror på `$firstGroupMaster`, och det andra anropet påverkar endast de bilder som beror på `$secondGroupMaster`. Bilder som tillhör någon annan master‑bild omdesignas inte.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑master‑bilden till mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/) och den klonade master‑bilden. Detta överför master‑bilden, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destination‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste stanna på sin nuvarande master‑ och layout‑bild, initiera en bild‑nivå‑åsidosättning från käll‑temat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/) kopierar de tre huvudtemakomponenterna till åsidosättningen.

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

Detta ändrar temat som den bilden använder utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/overridetheme/).

### **Tillämpa ett temaarv på en layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen åsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layout‑familj behöver annan stil, och en bild‑åsidosättning bara för verkliga undantag. Överdrivna bild‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint-galleriet för bakgrundsstilar för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/). En stilindex på `0` betyder ingen temafylld bakgrund; positiva värden är referenser till temats bakgrundsstilar. Detta skiljer sig från att indexera PHP‑samlingen direkt, där `get_Item(0)` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Det följande exemplet rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första master‑bilden och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av master‑bilden och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av bara master‑bakgrunden lämna bilden oförändrad. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}
Behandla inte stil‑indexet som ett nollbaserat samlingsindex. Undvik dessutom att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/php-java/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temats format‑schema innehåller separata samlingar för fyllnings‑, linje‑ och effekstilar som exponeras via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/) och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/php-java/aspose.slides/formatscheme/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i PHP är samlingsindexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En formes stil‑referensindex är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapestyle/). Att ändra en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön och den tredje effektstilen får en utskugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter att ha ändrat linje-, fyllnings- och skugginställningar](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temobjekt berättar vad som definierats på en viss nivå. Effektiva värden berättar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/).

Det följande exemplet läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) omfördelar bara de bilder som beror på den valda master‑bilden. Bilder som använder andra mästare behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mästaren?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidethememanager/) och initiera dess åsidosättningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

När du flyttar en bild och vill bevara dess ursprungliga utseende, klona käll‑master‑bilden till destinationen och klona bilden med den master‑bilden med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/). Detta behåller master‑bilden, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseoverridethememanager/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑datametoderna för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/background/) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.