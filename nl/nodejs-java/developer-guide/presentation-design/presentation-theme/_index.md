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
- extern thema
- THMX
- themakleur
- extra palet
- thema-lettertype
- thema-stijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer master‑presentatiethema's in JavaScript met Aspose.Slides voor Node.js om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging vele objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). Een presentatie kan ook overrides op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overrides zijn opgelost.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)‑object maakt het kleurenschema, lettertype‑schema en formaat‑schema van het thema bloot via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren Wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)‑enumeratie. Wanneer je de corresponderende entry in het [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog steeds die themakleur refereren, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑kleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoekje gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is veranderd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren Gebruiken uit het Extra Palet**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  

**2** – Lichtere en donkerdere varianten die uit de hoofdkleuren zijn afgeleid.

Het volgende voorbeeld maakt zes rechthoeken op basis van `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanaf de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑Waarden Toewijzen aan `ColorScheme`‑Slots**

De [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl het [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themale Lettertypen Wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de bodytekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑thema‑lettertype gebruikt en één body‑regel die het secundaire Latin‑thema‑lettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de bodytekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch schakelen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertype‑mappings bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze mappings te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekstlettertypen, zie [PowerPoint Fonts](/slides/nl/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

### **Thema‑Lettertype‑Referenties Oplossen**

Bij het inspecteren van tekst kan [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) een thema‑referentie zoals `+mn-lt` teruggeven in plaats van een lettertype‑familienaam. Roep [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) aan met het juiste effectieve thema om die referentie op te lossen. De prefixes `+mj` en `+mn` selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de suffixes `-lt`, `-ea` en `-cs` kiezen hun Latin, East Asian en Complex Script letters.

Verkrijg het effectieve thema via [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) op het object waarvan het thema van toepassing is op de geïnspecteerde tekst. Voor gewone tekst op een dia, roep deze methode aan op de dia zodat de context het geërfde thema van die dia en lokale overrides bevat. Bij inspectie van een lay‑out of master zelf, gebruik diens eigen effectieve thema. Ga niet ervan uit dat het thema van de eerste master op elke dia van toepassing is.

Het volgende voorbeeld maakt een tekstdeel dat expliciet verwijst naar het secundaire Latin‑lettertype. Het initialiseert een dia‑lettertype‑schema via [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, waardoor het resultaat reproduceerbaar is zonder invoerbestand.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

De uitvoer is `+mn-lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt geretourneerd. Als het deel `+mj-lt` had gebruikt, zou het naar `Arial` resolven in dit thema.

Het oplossen van een thema‑referentie identificeert de lettertype‑familie die door het thema is opgegeven. Het controleert niet de beschikbaarheid van het lettertype of bepaalt het lettertype‑bestand dat uiteindelijk wordt gebruikt na substitutie of glyph‑fallback tijdens rendering. Zie [Font Selection Sequence](/slides/nl/nodejs-java/font-selection-sequence/) en [Font Substitution](/slides/nl/nodejs-java/font-substitution/) voor die afzonderlijke stappen.

## **Een Thema Kopiëren of Toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een Extern Thema Toepassen op Dia’s die van een Master Afhangen**

Gebruik [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die van een bepaalde master afhangt wilt herstylen. Selecteer de gewenste master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑collectie, die wordt weergegeven door [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende stappen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Koppelt de nieuwe master aan alle dia’s die eerder van de geselecteerde master afhingen.
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die van de eerste master afhangen en slaat de presentatie op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden resolved tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑ en dia‑niveau kunnen eveneens voorrang hebben op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente rendering en export, installeer de benodigde lettertypen, lever ze via [custom font sources](/slides/nl/nodejs-java/custom-font/), of configureer [font substitution](/slides/nl/nodejs-java/font-substitution/).

Dit is een directe master‑level workflow: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑thema‑overrides.

### **Verschillende Externe Thema’s Toepassen in een Multi‑Master Presentatie**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze via een representatieve dia met [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). Sla de originele master‑referenties op vóór het toepassen van thema’s, want elke aanroep creëert een nieuwe master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

De eerste aanroep beïnvloedt alleen de dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede alleen de dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die tot een andere master behoren, worden niet hergestyled.

### **Een Bronthema Behouden bij Het Verplaatsen van Dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), en kloon vervolgens de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) en de gekloonde master. Dit draagt de master, de lay‑outs en het bijbehorende thema mee.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming exact hetzelfde uit moet zien. Louter inhoud klonen naar een ongerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑Waarden Toepassen op een Bestaande Dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert dan een dia‑level override vanuit het bronthema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s is geërfd te wijzigen. Om de lokale override te verwijderen en terug te gaan naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) aan.

### **Een Thema‑Override Toepassen op een Lay‑out**

Een lay‑out‑level override geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑level overrides maken latere globale thema‑wijzigingen moeilijker voorspelbaar.


<!-- visual-explanation:presentation-theme:start -->
[![Een master‑thema voedt twee lay‑outs; een lay‑out‑override beïnvloedt zijn dia’s behalve een dia met een meer lokale override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Een lay‑out‑override geldt voor dia’s die die lay‑out gebruiken tenzij een dia een eigen override levert. Thema‑gebaseerde waarden volgen hun opgeloste schema; expliciet geformatteerde objecten kunnen hun lokale uiterlijk behouden. Houd overrides zo smal mogelijk, overeenkomstig de beoogde ontwerp‑uitzondering.*
<!-- visual-explanation:presentation-theme:end -->

## **Achtergrondstijlen van het Thema Bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan meer achtergrondkeuzes in de UI presenteren dan het aantal vul‑definities dat feitelijk in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van de indexering van de JavaScript‑collectie zelf, waar index `0` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie hetzelfde aantal achtergrondvul‑stijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrond‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, verandert het wijzigen van alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) wanneer je de definitieve achtergrond na overerving moet weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectienaam. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondformattering en achtergrond‑overerving, zie [Presentation Background](/slides/nl/nodejs-java/presentation-background/).
{{% /alert %}}

## **Thema‑Effecten Bijwerken**

Een thema‑formaatschema bevat aparte collecties voor vul‑, lijn‑ en effectstijlen, bloot via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑items die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in JavaScript benadert, is de collectie‑index nul‑gebaseerd: index `0` is de eerste opgeslagen stijl en index `2` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, bloot via [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de benodigde stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een egale bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm gebruikt en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Vul‑ en Lijnstijlen voor een Vorm Selecteren**

Een vorm kan zijn vul‑ en contour onafhankelijk kiezen via [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) en [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). Voor beide methoden selecteert index `1` het eerste item in de betreffende themacollectie (`get_Item(0)`) en index `2` het tweede (`get_Item(1)`).

Het volgende voorbeeld maakt twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) in het standaardthema van een nieuwe presentatie. Het slaat de dia in drie fasen op zodat je de resultaten in PowerPoint kunt vergelijken.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Initiële stijlen | Lijn rechts wijzigen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met bijpassende dunne donkerblauwe randen](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode rand](theme-style-line-changed.png) | ![De linkse rechthoek is nu groen en beide randen blijven ongewijzigd](theme-style-fill-changed.png) |

Het kiezen van een andere lijnstijl verandert alleen de contour van de rechthoek rechts. Het bewerken van de eerste themavulling werkt alle vormen die die stijl gebruiken bij. Hier wordt alleen de linkse rechthoek groen.

Op een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte die deel van de themastijl overschrijven. Als het wijzigen van een stijl‑index geen visueel effect heeft, controleer dan de [directe opmaak](/slides/nl/nodejs-java/shape-formatting/) van de vorm.

## **Bepalen of een Effectieve Eenheidsvulling een Thematiek Kleur Gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl of een ander formatieniveau. Roep [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) aan om die hiërarchie op te lossen tot een onveranderlijke effectieve‑vullings‑snapshot. Controleer eerst de waarde van `getFillType`. Alleen wanneer deze `FillType.Solid` is, moet je de eigenschappen van een effen vulling lezen.

Voor een effen vulling geeft `getSolidFillColor` de uiteindelijke gerenderde RGB‑waarde terug na overerving, themalook‑up en kleurtransformaties. De methode `getSolidFillSchemeColor` retourneert de corresponderende logische [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)‑slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vulling niet is gebaseerd op een scheme‑kleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik de lokale [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) waarde niet alleen om een vulling te classificeren. Bijvoorbeeld, een tekstdeel kan geen lokaal gedefinieerde scheme‑kleur hebben, zodat de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, lay‑out, master, enz.) die slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, audit zowel vorm‑vullingen als tekst‑deel‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende scheme‑kleur af, en markeert effen vullingen die geen thema‑kleurwijzigingen zullen volgen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De `NotDefined`‑tak levert een audit‑lijst van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Controleer die objecten wanneer een presentatie een nieuw merkkleurenpalet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds de huidige weergave, terwijl de scheme‑waarde uitlegt of die weergave aan het thema gekoppeld is.

Effectieve‑format‑objecten zijn snapshots. Na het wijzigen van het presentatiethema, een thema‑override of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees een nieuw effectief‑vulobject voordat je kleuren vergelijkt of rapporteert.

## **Effectieve Thema‑Waarden Lezen**

Ruwe thema‑objecten vertellen je wat op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt na overerving en lokale overrides. Voor een dia roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), en voor een vulling [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor diagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) inspecteert, kun je een master, lay‑out, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) wijzigt alleen de dia’s die van de geselecteerde master afhangen. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema op één enkele dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en de bron‑uitstraling wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). Zo blijf je de master, lay‑outs en het thema behouden.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en overrides.