---
title: Beheer presentatiethema's in JavaScript
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatiethema's in JavaScript met Aspose.Slides voor Node.js om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypes, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het themaniveau van de presentatie beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/). Een presentatie kan ook themaisolering op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterthememanager/), terwijl een lay-out of een individuele slide zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een slide bepaald via deze erfenisketen: presentatiethema, master‑override, lay‑out‑override en slide‑override.

![Thema‑onderdelen: kleuren, lettertypes, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypes wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overrides zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/)‑object geeft toegang tot het kleurenschema, lettertypeschema en formaat‑schema van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties vóórdat je ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themapropunten en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Als een bestand meerdere masters gebruikt, mag je niet aannemen dat elke slide hetzelfde effectieve thema heeft. Inspecteer de master die bij de slide hoort en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of slide‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/schemecolor/). Wanneer je de overeenkomstige entry wijzigt in de [ColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorscheme/), worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw en geeft de effectieve vulkleur weer:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Omdat het rechthoek nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is veranderd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint afgeleide lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties beschikbaar via de enumeratie [ColorTransformOperation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan en slaat het resultaat op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanuit de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `ColorScheme`‑slots**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/schemecolor/) maakt gebruik van `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Themalettertypes wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een bijschrift‑set voor body‑tekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) geven die sets bloot.

PowerPoint‑compatibele themalettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn‑lt` – Body‑lettertype Latin (Minor Latin Font)  
* `+mj‑lt` – Kop‑lettertype Latin (Major Latin Font)  
* `+mn‑ea` – Body‑lettertype East Asian (Minor East Asian Font)  
* `+mj‑ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het bijschrift‑Latin‑themalettertype gebruikt. Vervolgens wijzigt het de themalettertypes en slaat het resultaat op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De kop volgt het hoofdlettertype en de body‑tekst volgt het bijschriftlettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch overschakelen wanneer het themalettertype‑schema verandert.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatielettertypes, zie [PowerPoint Fonts](/slides/nl/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee gangbare workflows, en ze lossen verschillende problemen op.

### **Een bron‑thema behouden bij het verplaatsen van slides**

Wil je een slide naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslidecollection/), en kloon vervolgens de slide met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) en de gekloonde master. Hiermee worden de master, de lay‑outs en het bijbehorende thema samen meegenomen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dit is de voorkeursworkflow wanneer de bron‑slide er in de bestemming exact hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde bestemming‑master kan thema‑gedreven kleuren, lettertypes, achtergronden en effecten veranderen.

### **Themawaarden toepassen op een bestaande slide**

Moet de doel‑slide op zijn huidige master en lay‑out blijven, initialiseert dan een slide‑niveau‑override vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de override.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dit wijzigt het thema dat die slide gebruikt zonder het door andere slides geërfde thema te wijzigen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep je [OverrideTheme.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑niveau‑override geldt voor alle slides die die lay‑out gebruiken, tenzij een specifieke slide een eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Gebruik een master‑ of presentatiethema‑niveau wanneer veel lay‑outs en slides hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een slide‑override alleen voor echte uitzonderingen. Overmatige slide‑niveau‑overrides maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar thema‑achtergrondstijlen. Dit verschilt van het rechtstreeks indexeren van de JavaScript‑collectie, waarbij index `0` het eerste opgeslagen item aangeeft. Neem niet aan dat elke presentatie evenveel achtergrond‑vullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het zichtbare resultaat hangt af van de thema‑entry waarnaar de master verwijst en van eventuele achtergrond‑overrides op lay‑out‑ of slide‑niveau. Als een slide een eigen achtergrond gebruikt, wijzigt het aanpassen van alleen de master‑achtergrond die slide mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/) wanneer je de uiteindelijke achtergrond na erfenis moet weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd bovendien het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn specifiek per presentatie.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/nodejs-java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formaatschema bevat afzonderlijke verzamelingen van vul‑, lijn‑ en effectstijlen, toegankelijk via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/). Typische Office‑thema's bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intensieve thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in JavaScript benadert, is de collectie‑index nul‑gebaseerd: index `0` is de eerste opgeslagen stijl en index `2` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgesteld via [ShapeStyle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die themastijl verwijzen; vormen met directe opmaak blijven onveranderd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenschaduw in de derde effectstijl en slaat het resultaat op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor vormen die naar deze slots verwijzen, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een egale bosgroen en krijgt de derde effectstijl een buitenschaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke stijl‑slots elke vorm verwijst en of directe opmaak de themastijl overschrijft.

![Themabeeffectstijlen na wijziging van lijn-, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe themobjecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een slide of vorm werkelijk gebruikt nadat erfenis en lokale overrides zijn verwerkt. Voor een slide roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/), en voor een vulopmaak [FillFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vorm‑vulling van een slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/) inspecteert, kun je een master‑, lay‑out‑, slide‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Kan ik een thema op één slide toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidethememanager/) van de slide en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die slide; andere slides blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een slide verplaatst en de oorspronkelijke weergave wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de slide met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/). Hiermee blijven de master, lay‑outs en het thema gezamenlijk behouden.

**Hoe kan ik de effectieve waarden zien na erfenis en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/) voor een slide‑ of lay‑out‑thema en de overeenkomstige effectieve‑datamethodes voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/). Deze API's retourneren de opgeloste waarden nadat erfenis en overrides zijn toegepast.