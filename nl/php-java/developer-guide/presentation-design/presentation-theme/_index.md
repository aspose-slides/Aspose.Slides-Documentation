---
title: Thema's voor presentaties beheren in PHP
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
- extern thema
- THMX
- themakleur
- extra palet
- themaletters
- themastijl
- thema‑effect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer master‑presentatiethema's in Aspose.Slides voor PHP via Java om PowerPoint‑bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging vele objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/). Een presentatie kan ook themaunderbrekingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themacomponenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties laten de meest voorkomende thema‑workflows zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat er geërfd en onderbroken is.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/)‑object geeft toegang tot het kleuren‑, lettertype‑ en opmaakschema van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties vóór wijziging is vooral handig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de hoofdthema‑eigenschappen en meldt hoeveel achtergrond‑, vullings‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort en gebruik de later in dit artikel getoonde effectieve‑thema‑workflow wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)-enumeratie. Wanneer u de bijbehorende vermelding in de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, opgelost tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een themakleur‑update.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoekje nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen in `Accent4` die vulkleur niet meer beïnvloeden.

### **Gebruik kleuren uit het extra palet**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colortransformoperation/)-enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanaf de nieuwe `Accent4`‑waarde.

### **Map `SchemeColor`‑waarden naar `ColorScheme`‑slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)-enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/)-enumeratie dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de bodytekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identificatoren kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Bodylettertype Latin (Minor Latin Font)
* `+mj-lt` – Koplettertype Latin (Major Latin Font)
* `+mn-ea` – Bodylettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Koplettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de bodytekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identificator zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor afzonderlijke schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Zie [Script‑Specific Theme Fonts](/slides/nl/php-java/script-specific-font-mappings/) om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatielettertypen, zie [PowerPoint Fonts](/slides/nl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Pas een extern thema toe op dia's die afhankelijk zijn van een master**

Gebruik [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) heeft en elke dia die afhankelijk is van een bepaalde master wilt restylen. Selecteer de master uit de [Presentation::getMasters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)-collectie, die wordt vertegenwoordigd door [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/), en geef het pad van het themabestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe master‑dia gebaseerd op de geselecteerde master.
2. Past het externe thema toe op de nieuwe master.
3. Koppelt de nieuwe master aan alle dia's die voorheen afhankelijk waren van de geselecteerde master.
4. Retourneert de nieuw gemaakte [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer door gebruikers opgegeven paden, behandel fouten bij bestands‑systeemtoegang en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden opgelost tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑ en dia‑niveau kunnen ook voorrang hebben op waarden die zijn geërfd van de nieuwe master.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Installeer voor consistente weergave en export de benodigde lettertypen, maak ze beschikbaar via [custom font sources](/slides/nl/php-java/custom-font/), of configureer [font substitution](/slides/nl/php-java/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van thema‑overrides op dia‑ of lay‑out‑niveau.

### **Pas verschillende externe thema’s toe in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, haal deze dan op via een representatieve dia met [Slide::getLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) en [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/). Sla de oorspronkelijke master‑referenties op vóór het toepassen van thema’s, want elke aanroep maakt een extra master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep heeft alleen invloed op dia’s die afhankelijk waren van `$firstGroupMaster`, en de tweede aanroep alleen op dia’s die afhankelijk waren van `$secondGroupMaster`. Dia’s die bij een andere master horen, worden niet opnieuw gestyled.

### **Behoud een bronthema bij het verplaatsen van dia’s**

Als u een dia wilt verplaatsen naar een andere presentatie en het oorspronkelijke ontwerp wilt behouden, kloont u de bron‑master in de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/), en kloont u vervolgens de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) en de gekloonde master. Hierdoor worden de master, de lay‑outs en het bijbehorende thema meegenomen.

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

Dit is de voorkeur‑workflow wanneer de bron‑dia er in de bestemming exact hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Pas themawaarden toe op een bestaande dia**

Als de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau override vanuit het bronthema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat die dia gebruikt zonder het thema dat andere dia’s erven te wijzigen. Roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) aan om de lokale override te verwijderen en terug te keren naar de geërfde waarden.

### **Pas een thema‑override toe op een lay‑out**

Een lay‑out‑niveau override is van toepassing op dia’s die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau overrides maken latere globale themawijzigingen moeilijker te voorspellen.

## **Thema‑achtergrondstijlen bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). PowerPoint kan in de UI meer achtergrondopties tonen dan het aantal vullingdefinities dat feitelijk in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint-achtergrondstijlgalerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het indexeren van de PHP‑collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themavermelding waar de master naar verwijst en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, verandert alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) wanneer u de uiteindelijke achtergrond na erf‑ en override‑toepassing moet weten.

{{% alert color="warning" title="Waarschuwing" %}}
Behandel de stijl‑index niet als een nulgebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erf kun je [Presentation Background](/slides/nl/php-java/presentation-background/) raadplegen.
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een themaschema bevat gescheiden collecties voor vul‑, lijn‑ en effectstijlen, toegankelijk via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). Veel Office‑thema’s bevatten drie hoofdstijl‑items die visueel overeenkomen met subtiele, matige en intense opmaak, maar code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal items.

![Subtiele, matige en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in PHP benadert, is de collectie‑index nulgebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Indexen die een vorm‑stijl‑referentie aangeven, vormen een apart concept, toegankelijk via [ShapeStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die stijl verwijzen; vormen met directe opmaak blijven mogelijk onveranderd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een externe schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze slots verwijzen, wordt de eerste themalijnstijl rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een externe schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke stijl‑slots elke vorm raadpleegt en of directe opmaak de themastijl overschrijft.

![Thematische effectstijlen na wijziging van lijn-, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Bepalen of een effectieve effen vulkleur een themakleur gebruikt**

Een vul kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl of een ander formatieniveau. Roep [FillFormat::getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) aan om die hiërarchie op te lossen tot een onveranderlijke effectieve vuldata. Controleer eerst het resultaat van `getFillType`. Alleen wanneer dit `FillType::Solid` is, lees je de eigenschappen van de effen vul.

Voor een effen vul geeft `getSolidFillColor` de definitieve RGB‑waarde terug na erf‑, themazoek‑ en kleurtransformatietoepassingen. De methode `getSolidFillSchemeColor` geeft de bijbehorende logische [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)-slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor::NotDefined` betekent dat de effectieve effen vul niet gebaseerd is op een scheme‑kleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vul.

Gebruik de lokale [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorformat/)‑waarde niet alleen om een vul te classificeren. Bijvoorbeeld, een tekstdeel kan geen lokaal gedefinieerde scheme‑kleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vul een themakleur erft en zich vertaalt naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` u welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, lay‑out, master, etc.) deze afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekst‑deel‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende scheme‑kleur af, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

De `NotDefined`‑tak levert een audit‑lijst van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Bekijk die objecten wanneer een presentatie een nieuw merkpallet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde verklaart of dat uiterlijk gekoppeld is aan het thema.

Effectieve‑formatobjecten zijn momentopnames. Nadat u het presentatiethema, een thema‑override of enige geërfde opmaak hebt gewijzigd, roep opnieuw `getEffective` aan en lees de nieuwe effectieve vuldata vóór vergelijking of rapportage.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen u wat een dia of vorm werkelijk gebruikt na erf‑ en lokale overrides. Voor een dia roept u [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruikt u [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/), en voor een vul [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvul van een dia:

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) inspecteert, kunt u een master, lay‑out, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één dia zonder de master te veranderen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de oorspronkelijke opmaak wilt behouden, kloont u de bron‑master in de bestemming en kloont u de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/). Zo blijven de master, lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na erf‑ en override‑toepassingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/). Deze API’s geven de geresolueerde waarden na erf‑ en override‑toepassingen.