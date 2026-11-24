---
title: Manage presentatiethema's in PHP
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/php-java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor PHP via Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente merkidentiteit."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Themagevoelige objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het presentatie‑niveau thema beschikbaar via [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Een presentatie kan ook themaoverschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia opgelost via deze overervingsketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑componenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn verwerkt.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) object maakt de kleurenschema, lettertype‑schema en opmaak‑schema van het thema bloot via [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), en [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het onderstaande voorbeeld leest de hoofdthema‑eigenschappen en meldt hoeveel achtergrond‑, vul-, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Wijzig themakleuren**

Themagevoelige vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enumeratie. Wanneer je de overeenkomstige entry in de [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen afgehandeld tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een themakleur‑update.

Het onderstaande end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, verandert de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoekje nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood na de thema‑wijziging. Wanneer je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen van `Accent4` die vulkleur niet meer beïnvloeden.

### **Gebruik kleuren uit het aanvullende palet**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) enumeratie.

![Hoofdkleuren van het thema en lichtere en donkere kleuren die gegenereerd zijn vanuit het aanvullende palet](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema.  
**2** - Lichtere en donkere varianten geproduceerd vanuit de hoofdkleuren van het thema.

Het onderstaande voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend vanuit de nieuwe `Accent4`‑waarde.

### **Map `SchemeColor`‑waarden naar `ColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) dezelfde themaposities blootlegt als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Wijzig themalettertypen**

Een themalettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor body‑tekst. De [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) en [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) methoden maken die sets beschikbaar.

PowerPoint‑compatibele themalettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` - Body‑lettertype Latin (Klein Latin‑lettertype)
* `+mj-lt` - Kop‑lettertype Latin (Groot Latin‑lettertype)
* `+mn-ea` - Body‑lettertype Oost‑Aziatisch (Klein Oost‑Aziatisch‑lettertype)
* `+mj-ea` - Kop‑lettertype Oost‑Aziatisch (Groot Oost‑Aziatisch‑lettertype)
* `+mn-cs` - Body‑lettertype Complex Script (Klein Complex Script‑lettertype)
* `+mj-cs` - Kop‑lettertype Complex Script (Groot Complex Script‑lettertype)

Het onderstaande voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens worden de themalettertypen gewijzigd en wordt het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het themalettertype‑schema wordt gewijzigd.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑mappings bevatten voor afzonderlijke schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze mappings te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑specifieke themalettertypen](/slides/nl/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatielettertypen, zie [PowerPoint‑lettertypen](/slides/nl/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Los themalettertype‑referenties op**

Bij het inspecteren van tekst kan [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) een themareferentie zoals `+mn-lt` teruggeven in plaats van een lettertype‑familienaam. Roep [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) aan met de juiste effectieve themagegevens om die referentie op te lossen. De prefixes `+mj` en `+mn` selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de suffixes `-lt`, `-ea` en `-cs` selecteren hun Latin, East Asian en Complex Script letters.

Verkrijg het effectieve thema via [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) op het object waarop het thema van toepassing is op de geïnspecteerde tekst. Voor gewone tekst op een dia roep je deze methode aan op de dia zodat de context het geërfde thema en lokale overschrijvingen van die dia bevat. Bij het inspecteren van een lay‑out of master zelf, gebruik je diens eigen effectieve thema. Ga niet uit van het feit dat het thema van de eerste master op elke dia van toepassing is.

Het onderstaande voorbeeld maakt een tekstdelen dat expliciet naar het secundaire Latin‑lettertype verwijst. Het initialiseert een dia‑lettertype‑schema via [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, waardoor het resultaat reproduceerbaar is zonder invoerbestand.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

De uitvoer is `+mn-lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt teruggegeven. Als het gedeelte `+mj-lt` had gebruikt, zou het in dit thema naar `Arial` resolven.

Het oplossen van een themareferentie identificeert het lettertype‑familie dat door het thema is gespecificeerd. Het controleert niet de beschikbaarheid van het lettertype of bepaalt welk lettertype‑bestand uiteindelijk wordt gebruikt na substitutie of glyph‑fallback tijdens het renderen. Zie [Lettertype‑selectiesequentie](/slides/nl/php-java/font-selection-sequence/) en [Lettertype‑substitutie](/slides/nl/php-java/font-substitution/) voor die afzonderlijke stappen.

## **Kopieer of pas een thema toe**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Pas een extern thema toe op dia's die afhankelijk zijn van een master**

Gebruik [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke dia wilt herstylen die afhankelijk is van een bepaalde master. Selecteer de master uit de [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) collectie, die wordt vertegenwoordigd door [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), en geef het themabestandspad door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia aan op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Kent de nieuwe master toe aan alle dia's die vóórheen afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

Het onderstaande voorbeeld past een extern thema toe op de dia's die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, handel fouten bij bestands‑systeemtoegang af, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en thema’s. Themagevoelige kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen onveranderd blijven. Lay‑out‑ en dia‑overschrijvingen kunnen eveneens voorrang krijgen op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de benodigde lettertypen, lever ze via [aangepaste lettertype‑bronnen](/slides/nl/php-java/custom-font/), of configureer [lettertype‑substitutie](/slides/nl/php-java/font-substitution/).

Dit is een directe master‑niveau werkstroom: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatig aanmaken van dia‑ of lay‑out‑thema‑overschrijvingen.

### **Pas verschillende externe thema's toe in een presentatie met meerdere masters**

Wanneer de relevante master van tevoren onbekend is, verkrijg deze dan via een representatieve dia met [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) en [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, want elke aanroep creëert een extra master in de presentatie.

Het onderstaande voorbeeld gebruikt dia’s uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep beïnvloedt alleen de dia’s die afhankelijk waren van `$firstGroupMaster`, en de tweede aanroep beïnvloedt alleen de dia’s die afhankelijk waren van `$secondGroupMaster`. Dia’s die tot een andere master behoren, worden niet hergestyled.

### **Behoud een bron‑thema bij het verplaatsen van dia's**

Als je een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master in de doelpresentatie met [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), kloon daarna de dia met [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) en de gekloonde master. Dit brengt de master, diens lay‑outs en het bijbehorende thema samen.

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

Dit is de geprefereerde werkstroom wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Pas themawaarden toe op een bestaande dia**

Wanneer de doel‑dia op haar huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau override vanuit het bron‑thema. De [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), en [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) methoden kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s wordt geërfd te wijzigen. Om de locale override te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) aan.

### **Pas een thema‑override toe op een lay‑out**

Een lay‑out‑niveau override is van toepassing op dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen override heeft. De dezelfde initialisatiemethoden kunnen via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) worden gebruikt:

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basissjabloon moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling vereist, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau overrides maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Werk themabackground‑stijlen bij**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal fysiek opgeslagen vuldefinities in deze collectie, omdat de UI themavullingen kan combineren met themakleuren en andere stijlovereenkomsten.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn themabackground‑stijlreferenties. Dit verschilt van het indexeren van de PHP‑collectie direct, waar `get_Item(0)` het eerste opgeslagen item betekent. Ga niet uit van het feit dat elke presentatie hetzelfde aantal achtergrond‑vulstijlen bevat.

Het onderstaande voorbeeld meldt het beschikbare aantal achtergrondvullingen, kent een themabackground‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die de master gebruikt en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia haar eigen achtergrond gebruikt, kan het veranderen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) wanneer je de definitieve achtergrond wilt weten na toepassing van overerving.

{{% alert color="warning" title="Warning" %}}
Behandel de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd bovendien het hard‑coderen van een stijlnummer uit één bestand en veronderstel dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentatie‑achtergrond](/slides/nl/php-java/presentation-background/).
{{% /alert %}}

## **Werk themaeffecten bij**

Een themaschema‑format bevat aparte collecties voor vul‑, lijn‑ en effectstijlen die beschikbaar worden gesteld via [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), en [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Typische Office‑thema’s bevatten vaak drie hoofdstijl‑items die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar de code moet elke collectie inspecteren in plaats van een vaste telling aan te nemen.

![Subtiele, gematigde en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in PHP benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, beschikbaar via [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het onderstaande voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenschaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze posities refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een solide bosgroen, en de derde effectstijl krijgt een buitenschaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑posities elke vorm refereert en of directe opmaak de thema‑instelling overschrijft.

![Themastijlen na wijziging van lijn-, vullings‑ en schaduwinstellingen](presentation-design_11.png)

## **Selecteer themavullings‑ en lijnstijlen voor een vorm**

Een vorm kan zijn vul‑ en omtrek onafhankelijk selecteren via [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) en [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Voor beide methoden selecteert index `1` het eerste item in de bijbehorende themacollectie (`get_Item(0)`), en selecteert index `2` het tweede (`get_Item(1)`).

Het onderstaande voorbeeld maakt twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) aan in het standaardthema van een nieuwe presentatie. Het slaat de dia in drie fasen op zodat je de resultaten in PowerPoint kunt vergelijken.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Beginstijlen | Verander de rechter rand | Bewerk de eerste themavulling |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met bijpassende dunne donkerblauwe omtrekken](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode omtrek](theme-style-line-changed.png) | ![De linkse rechthoek is nu groen en beide omtrekken zijn ongewijzigd](theme-style-fill-changed.png) |

Het selecteren van een andere lijnstijl wijzigt alleen de omtrek van de rechter rechthoek. Het bewerken van de eerste themavulling update elke vorm die die vulling gebruikt. Hier wordt alleen de linkse rechthoek groen.

Op een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte die deel van de themastijl overschrijft. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/php-java/shape-formatting/).

## **Bepaal of een effectieve egale vulling een themakleur gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd zijn van een alinea, lay‑out, master, themastijl of een ander opmaakniveau. Roep [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) aan om die hiërarchie om te zetten in onveranderlijke effectieve vuldataset. Controleer eerst het resultaat van `getFillType`. Alleen wanneer dit `FillType::Solid` is, moet je de eigenschappen van de egale vulling lezen.

Voor een egale vulling retourneert `getSolidFillColor` de uiteindelijke gerenderde RGB‑waarde na overerving, themalook‑up en kleurtransformaties. De methode `getSolidFillSchemeColor` retourneert de bijbehorende logische [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor::NotDefined` betekent dat de effectieve egale vulling niet gebaseerd is op een scheme‑kleur. In een werkstroom waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik de lokale [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) waarde niet alleen om een vulling te classificeren. Bijvoorbeeld, een tekstdelen kan geen lokaal gedefinieerde scheme‑kleur hebben, zodat de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` je welke logische themaslot de effectieve kleur heeft geproduceerd, maar het vertelt niet of die slot afkomstig is van het object, de alinea, de lay‑out, de master of een ander niveau van de opmaakhiërarchie.

Het onderstaande voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekstdelen‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende scheme‑kleur af, en markeert egale vullingen die geen themakleur‑wijzigingen zullen volgen:

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

De `NotDefined`‑tak levert een audit‑lijst van egale vullingen die niet reageren op wijzigingen in themakleur‑slots. Beoordeel die objecten wanneer een presentatie een nieuw merkpalet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde uitlegt of dat uiterlijk verbonden is met het thema.

Effectieve‑formatobjecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑override, of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees de nieuwe effectieve vuldataset voordat je kleuren vergelijkt of rapporteert.

## **Lees effectieve themawaarden**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt na overerving en lokale overschrijvingen. Voor een dia roep je [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), en voor een vulling gebruik je [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

Het onderstaande voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor renderingsdiagnostiek, validatie en vergelijkingen. Als je alleen [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) inspecteert, kun je een master-, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema effect op elke dia in de presentatie?**

Nee. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) wijst alleen de dia’s toe die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) van de dia en initialiseert haar override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s overerven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon je de bron‑master in de bestemming met [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) en kloon je de dia met [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) en de gekloonde master. Zo blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor formaatobjecten zoals [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) en [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en overschrijvingen.