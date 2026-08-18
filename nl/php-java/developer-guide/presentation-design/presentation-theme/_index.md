---
title: Beheer presentatiethema's in PHP
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
- themakleur
- aanvullend palet
- thema-lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor PHP via Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde verzameling kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, waardoor een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/). Een presentatie kan ook themavervangingen bevatten op lagere niveaus. Een master kan het presentatiethema vervangen via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterthememanager/), terwijl een layout of een individuele slide zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een slide bepaald via deze overervingsketen: presentatiethema, master‑override, layout‑override en slide‑override.

![Thema‑componenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderliggende secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en de effectieve waarden lezen nadat overerving en overrides zijn toegepast.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/)‑object maakt de kleurschema, lettertypeschema en formatschema van het thema bloot via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties vóórdat je ze wijzigt, is vooral nuttig wanneer een presentatie van een externe bron komt, omdat het aantal en de inhoud van stijlitems kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themagegevens en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, mag je er niet van uitgaan dat elke slide hetzelfde effectieve thema heeft. Inspecteer de master die bij de slide hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er layout‑ of slide‑overrides aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)-enumeratie. Wanneer je de overeenkomstige entry wijzigt in de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/), worden alle objecten die nog naar die themakleur verwijzen, bij het nieuwe waarde opgehaald. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schematische kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vul niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties bloot via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colortransformoperation/)-enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `ColorScheme`‑slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/schemecolor/)-enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorscheme/)-enumeratie dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een themaletterschema bevat een hoofdlettertype‑set voor koppen en een tweede lettertype‑set voor de bodytekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) maken die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofdlettertype Latin uit het thema gebruikt en één body‑regel die het secundaire Latin‑lettertype gebruikt. Daarna wijzigt het de themaletters en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de bodytekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch omschakelen wanneer het themaletterschema wijzigt.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee veelvoorkomende workflows, en ze lossen verschillende problemen op.

### **Een bron‑thema behouden bij het verplaatsen van slides**

Wil je een slide naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master naar de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/), en kloon vervolgens de slide met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) en de gekloonde master. Dit draagt de master, de layouts en het bijbehorende thema samen.

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

Dit is de voorkeur‑workflow wanneer de bron‑slide er precies hetzelfde uit moet zien in de bestemming. Het klonen van inhoud op een onbehorende doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande slide**

Moet de doel‑slide op zijn huidige master en layout blijven, initialiseert dan een slide‑niveau‑override vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat die slide gebruikt zonder het thema dat andere slides erven te veranderen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep je [OverrideTheme.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/overridetheme/) aan.

### **Een thema‑override toepassen op een layout**

Een layout‑niveau‑override geldt voor slides die die layout gebruiken, tenzij een specifieke slide een eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel layouts en slides hetzelfde basisonwerp moeten delen, een layout‑override wanneer één layoutfamilie een andere styling nodig heeft, en een slide‑override alleen voor echte uitzonderingen. Overmatige slide‑niveau‑overrides maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). PowerPoint kan meer achtergrondkeuzes tonen in de UI dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijlreferenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het indexeren van de PHP‑collectie zelf, waar `get_Item(0)` het eerst opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrondoverrides op layout‑ of slide‑niveau. Als een slide zijn eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die slide niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) wanneer je de definitieve achtergrond na overerving moet weten.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatie‑specifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondformattering en achtergrond‑overerving, zie [Presentation Background](/slides/nl/php-java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formatschema bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen die worden blootgesteld via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/php-java/aspose.slides/formatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd­stijl‑items die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar de code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in PHP benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. De style‑referentie‑indexen van een vorm vormen een apart concept, blootgesteld via [ShapeStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenschaduw in op de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buitenschaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm refereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na het wijzigen van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een slide of vorm daadwerkelijk gebruikt na overerving en lokale overrides. Voor een slide roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/), en voor een vul- of opmaakobject gebruik je [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een slide:

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) inspecteert, kun je een master, layout, slide of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Kan ik een thema toepassen op één slide zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidethememanager/) van de slide en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die slide; andere slides blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een slide verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de slide met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/). Hierdoor blijven master, layouts en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseoverridethememanager/) voor een slide‑ of layout‑thema en de corresponderende effectieve‑data‑methoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/). Deze API’s geven de geëvalueerde waarden terug nadat overerving en overrides zijn toegepast.