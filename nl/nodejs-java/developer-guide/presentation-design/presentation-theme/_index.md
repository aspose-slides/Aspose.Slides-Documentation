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
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatiethema's in JavaScript met Aspose.Slides voor Node.js om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Inleiding**

Een presentatie‑thema definieert een gecoördineerde verzameling van kleuren, lettertypes, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/). Een presentatie kan ook thema‑overrides op lagere niveaus bevatten. Een master kan het presentatie‑thema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfenisketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Thema‑onderdelen: kleuren, lettertypes, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypes wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfelijkheid en overrides zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/) object geeft toegang tot het kleuren‑schema, lettertype‑schema en opmaak‑schema van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mastertheme/). Deze collecties inspecteren voordat je ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themagegevens en rapporteert hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/schemecolor/) opsomming verwijzen. Wanneer je de overeenkomstige vermelding in het [ColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet veranderd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoekje gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood na de thema‑wijziging. Als je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint maakt lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides biedt deze transformaties via de opsomming [ColorTransformOperation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkerdere varianten die van de hoofdkleuren zijn afgeleid.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op er vijf, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden koppelen aan `ColorScheme`‑posities**

De opsomming [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/schemecolor/) gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl het [ColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorscheme/) dezelfde themaposities exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De koppeling is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor hoofdtekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) geven deze sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Hoofdtekstlettertype Latijn (Minor Latin Font)
* `+mj-lt` – Koplettertype Latijn (Major Latin Font)
* `+mn-ea` – Hoofdtekstlettertype Oost‑Azia (Minor East Asian Font)
* `+mj-ea` – Koplettertype Oost‑Azia (Major East Asian Font)

Het volgende voorbeeld maakt een kop die het hoofdlettertype Latijn gebruikt en een alinea die het secundaire lettertype Latijn gebruikt. Vervolgens wijzigt het de thema‑lettertypes en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch schakelen wanneer het thema‑lettertypeschema wijzigt.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertype‑mappingen bevatten voor individuele schrijfsystemen, zoals Cyrillic, Arabisch, Japans, Georgisch en Thaana. Om deze mappingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die van een master afhangen**

Gebruik [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) wanneer je een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die van een bepaalde master afhangt wilt restylen. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) collectie, die wordt vertegenwoordigd door [MasterSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslidecollection/), en geef het themabestandspad door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.  
1. Past het externe thema toe op de nieuwe master.  
1. Koppelt de nieuwe master aan alle dia's die voorheen van de geselecteerde master afhingen.  
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die van de eerste master afhangen en slaat de presentatie op:

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

Een ongeldig, corrupt of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestandssysteem‑toegang, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die van de geselecteerde master afhingen, worden opnieuw gekoppeld. Dia's die bij andere masters horen behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypes, vullingen, lijnen, achtergronden en effecten worden afgehandeld volgens het externe thema. Direct toegewezen kleuren, lettertypes, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑ of dia‑niveau kunnen eveneens voorrang hebben op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypes verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypes, biedt ze aan via [custom font sources](/slides/nl/nodejs-java/custom-font/), of configureer [font substitution](/slides/nl/nodejs-java/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑overrides.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet vooraf bekend is, haal deze dan op via een representatieve dia met [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, want elke aanroep creëert een extra master in de presentatie.

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

De eerste aanroep beïnvloedt alleen dia’s die van `firstGroupMaster` afhingen, de tweede alleen dia’s die van `secondGroupMaster` afhingen. Dia’s die bij een andere master horen, worden niet restyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslidecollection/), kloon daarna de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) en de gekloonde master. Dit draagt de master, diens lay‑outs en het bijbehorende thema mee.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypes, achtergronden en effecten wijzigen.

### **Themawaarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseer dan een dia‑niveau override vanaf het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de override.

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

Dit verandert het thema dat die dia gebruikt zonder het thema dat andere dia’s erven te wijzigen. Om de lokale override te verwijderen en terug te keren naar de geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/overridetheme/) aan.

### **Een thema‑override op een lay‑out toepassen**

Een lay‑out‑niveau override is van toepassing op dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen override heeft. Dezelfde initialisatiemethoden kunnen via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslidethememanager/) worden aangeroepen:

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een dia‑override alleen voor ware uitzonderingen. Overmatige dia‑overrides maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/). PowerPoint kan meer achtergrondkeuzes tonen in de UI dan het aantal vuldefinities dat fysiek in deze collectie staat, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint galerij voor achtergrondstijlen van een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het indexeren van de JavaScript‑collectie zelf, waar index `0` het eerste opgeslagen item is. Neem niet aan dat elke presentatie evenveel achtergrondvulstijlen bevat.

Het volgende voorbeeld rapporteert het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themaverwijzing die door de master wordt gebruikt en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/) wanneer je de uiteindelijke achtergrond na erfelijkheid wilt weten.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een index op nul gebaseerd. Vermijd bovendien een stijlnummer uit één bestand hard‑coded te gebruiken en te veronderstellen dat het er hetzelfde uitziet in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfelijkheid, zie [Presentation Background](/slides/nl/nodejs-java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formatschema bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen, beschikbaar via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/formatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar de code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal items.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in JavaScript benadert, is de collectie‑index nul‑gebaseerd: index `0` is de eerste opgeslagen stijl en index `2` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, beschikbaar via [ShapeStyle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven ongewijzigd.

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl ondoorzichtig bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke stijl‑slots elke vorm referereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na het wijzigen van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten laten zien wat op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een dia of vorm werkelijk gebruikt nadat erfelijkheid en lokale overrides zijn verwerkt. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/), en voor een vul, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor render‑diagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) kent alleen de dia’s opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslidecollection/) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/). Hierdoor blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfelijkheid en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de corresponderende effectieve‑datamethoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/). Deze API’s geven de waarden terug die na erfelijkheid en overrides zijn berekend.