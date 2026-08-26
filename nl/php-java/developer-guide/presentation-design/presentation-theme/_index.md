---
title: Thema's van presentaties beheren in PHP
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
- extra palet
- themalettertype
- themastijl
- themeffect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer master-presentatiethema's in Aspose.Slides voor PHP via Java om PowerPoint-bestanden te creëren, aanpassen en converteren met consistente branding."
---
## **Introductie**

Een presentatie‑thema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, waardoor een thema‑wijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatie‑niveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/). Een presentatie kan ook thema‑overschrijvingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfenisketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑componenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overschrijvingen zijn verwerkt.

## **Een thema inspecteren**

De [MasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/) object maakt het kleurenpalet, lettertypepalet en formatpalet van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/), en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijlitems kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond-, vul-, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer er lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Theme‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/) enumeratie. Wanneer u het overeenkomende item in de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog steeds naar die themakleur verwijzen, herberekend op basis van de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schemacleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen van `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren gebruiken uit het extra palet**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colortransformoperation/) enumeratie.

![Hoofdkleuren van het thema en lichtere en donkere kleuren gegenereerd vanuit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkere varianten geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `ColorScheme`‑slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertypepalet bevat een hoofdlettertype‑set voor koppen en een onderlettertype‑set voor body‑tekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt een kop die het hoofd‑Latin‑themalettertype gebruikt en een body‑regel die het onder‑Latin‑themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het onderlettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch wisselen wanneer het thema‑lettertype‑palet verandert.

De hoofd‑ en onder‑lettertypecollecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekstlettertypen, zie [PowerPoint Fonts](/slides/nl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) wanneer u een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master opnieuw wilt stijlen. Selecteer de master uit de [Presentation::getMasters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑collectie, die wordt weergegeven door [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/), en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe masterslide aan op basis van de geselecteerde master.
2. Past het externe thema toe op de nieuwe master.
3. Wijst de nieuwe master toe aan alle dia's die voorheen afhankelijk waren van de geselecteerde master.
4. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/).

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan [PptxReadException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, verwerk fouten bij bestands‑systeemtoegang, en sla de presentatie pas op nadat het thema met succes is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's die zijn gekoppeld aan andere masters behouden hun bestaande masters en thema's. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op lay‑out‑niveau en dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de benodigde lettertypen, lever ze via [custom font sources](/slides/nl/php-java/custom-font/), of configureer [font substitution](/slides/nl/php-java/font-substitution/).

Dit is een directe workflow op master‑niveau: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑thema‑overschrijvingen.

### **Verschillende externe thema's toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze dan via een representatieve dia met [Slide::getLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) en [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/). Sla de oorspronkelijke master‑referenties op voordat u thema's toepast, omdat elke aanroep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia's uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep beïnvloedt alleen dia's die afhankelijk waren van `$firstGroupMaster`, en de tweede aanroep beïnvloedt alleen dia's die afhankelijk waren van `$secondGroupMaster`. Dia's die tot een andere master behoren, worden niet opnieuw gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia's**

Als u een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloont u de bron‑master naar de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/), kloont u vervolgens de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) en de gekloonde master. Hiermee wordt de master, zijn lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de voorkeur‑workflow wanneer de bron‑dia er in de doelpresentatie precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde bestemming‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Als de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/), en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) kopi­eren de drie belangrijkste thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia's erven te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau‑overschrijving geldt voor dia's die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau‑thema wanneer veel lay‑outs en dia's hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑outfamilie een andere opmaak nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau‑overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Thematische achtergrondstijlen bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). PowerPoint kan meer achtergrondkeuzes weergeven in de UI dan het aantal vullingsdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het rechtstreeks indexeren van de PHP‑collectie, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie hetzelfde aantal achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, wijst een thematische achtergrond‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themavermelding die door de master wordt gerefereerd en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia niet veranderen. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) wanneer u de uiteindelijke achtergrond wilt weten nadat erfenis is toegepast.

{{% alert color="warning" title="Waarschuwing" %}}
Behandel de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijl‑nummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; thema‑stijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/php-java/presentation-background/).
{{% /alert %}}

## **Thematische effecten bijwerken**

Een thema‑formatschema bevat aparte vul-, lijn- en effect‑stijlcollecties, beschikbaar via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/), en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). Typische Office‑thema's bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, matige en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, matige en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in PHP benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` is de derde. De stijl‑referentie‑indexen van een vorm zijn een apart concept, blootgesteld via [ShapeStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenschaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een solide bosgroen, en de derde effectstijl krijgt een buitenschaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na het wijzigen van lijn-, vul- en schaduwinstellingen](presentation-design_11.png)

## **Effectieve thema‑waarden lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen wat een dia of vorm werkelijk gebruikt nadat erfenis en lokale overschrijvingen zijn verwerkt. Voor een dia roept u [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruikt u [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/), en voor een vul gebruikt u [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

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

Gebruik effectieve gegevens voor weergave‑diagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema effect op elke dia in de presentatie?**

Nee. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) wijst alleen de dia's opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia's die andere masters gebruiken behouden hun bestaande thema's.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidethememanager/) van de dia en initialiseert zijn overschrijvingsthema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema's erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk behoudt, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/). Hiermee blijft de master, de lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de corresponderende effectieve‑datamethoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/). Deze API's retourneren de verwerkte waarden nadat erfenis en overschrijvingen zijn toegepast.