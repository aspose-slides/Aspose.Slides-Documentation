---
title: Beheer presentatielinks in JavaScript
linktitle: Beheer hyperlinks
type: docs
weight: 20
url: /nl/nodejs-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst hyperlink
- dia hyperlink
- vorm hyperlink
- afbeelding hyperlink
- video hyperlink
- wijzigbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java, met JavaScript‑voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt presentatietekst met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks doorgaans twee doelen:

* Een website openen via tekst, een vorm of een mediakader.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Node.js via Java stelt u in staat deze koppelingen toe te voegen, hun uiterlijk en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden laten zien hoe u met hyperlinks op individuele elementen werkt en hoe u hyperlinks op presentatie‑, dia‑ of tekstkader‑niveau kunt benaderen.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstdelen linkt de geselecteerde tekst, terwijl een vorm of kader de dia‑object linkt.

### **URL‑hyperlinks aan tekst toevoegen**

Om tekst aan een website te koppelen, geeft u een [Hyperlink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink) door aan de [setHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick)‑methode van het tekstdelen, zoals hieronder getoond. Alleen dat deel van de tekst wordt klikbaar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL‑hyperlinks aan vormen en mediakaders toevoegen**

Om een vorm of kader klikbaar te maken, roept u de [setHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setHyperlinkClick)‑methode aan. De hyperlink behoort tot het object zelf en niet tot een tekstdelen erin.

Dezezelfde aanpak geldt voor afbeelding‑, audio‑ en videokaders: wijs de hyperlink toe aan het kader en roep indien nodig [setTooltip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setTooltip) aan.

Het volgende voorbeeld maakt een rechthoek klikbaar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) om de tekst “Page 2” op de eerste dia te linken naar de tweede dia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks opmaken**

### **Kleur**

De [setColorSource](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setColorSource)‑methode van [Hyperlink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie of de opmaak van het tekstdelen gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkColorSource) en stelt u de vulkleur van het deel in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlink‑kleur behoudt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Geluid**

Een hyperlink kan een geluid afspelen bij activering of een reeds afspelend geluid stoppen. Gebruik de volgende methoden om dit gedrag te configureren:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setSound) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlinkgeluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Op de knop klikken speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid bij klikken, zonder een navigatie‑actie uit te voeren.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Een hyperlinkgeluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het hyperlink‑audio van de eerste vorm in het geheugen via [getSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getSound) en [getBinaryData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [Hyperlink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink)‑methoden aanroepen nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [setTooltip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setTooltip) stelt de tekst in die een kijker kan zien als hint voor de koppeling.
- [setTargetFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) specificeert het doelkader binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setHistory) bepaalt of het activeren van de koppeling de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) bepaalt of de hyperlink wordt gemarkeerd bij klikken.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) om hyperlink‑containers, inclusief tekstdelen‑links, te verzamelen voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activerings‑typen van de eerste dia. Om slechts één type te verwijderen, roep alleen [removeHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) aan; het verwijderen van een klik‑actie verwijdert niet de muis‑over‑tegenhanger.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) beide activerings‑typen in de geselecteerde reikwijdte in één aanroep. Voor selectieve opschoning en dekking van masters, layouts en notities, zie [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat u een presentatie verspreidt, inventariseer de interactieve acties en de webkoppelingen. [getAnyHyperlinks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) retourneert hyperlink‑containers, geen platte lijst van URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getHyperlinkClick) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) voor elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties hebben, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperlinks op vormniveau scannen kan links op tekstdelen missen. Vraag in plaats daarvan de juiste reikwijdte op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekstkader‑reikwijdten opvragen**

De klasse [HyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries) is beschikbaar via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) en [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Elke reikwijdte ondersteunt dezelfde queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) retourneert containers met een klik‑actie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) retourneert containers met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestands‑muisknop‑link, interne dia‑navigatie, een tekst‑muisknop‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken in elke reikwijdte; de aantallen beschrijven containers, niet het totaal aantal acties. De tekstkader‑reikwijdte sluit de eigen links van de omvattende vorm uit.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met één van de acties. De tekstkader‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [Hyperlink.getActionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getActionType) om een actie te interpreteren voordat u de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkActionType) omvatten meer dan alleen webnavigatie:

| Values | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, geëvalueerd in de context van de diavoorstelling. |
| `JumpEndShow`, `StartCustomSlideShow` | Het huidige venster beëindigen of een aangepaste diavoorstelling starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; apart beoordelen van web‑URL’s. |
| `StartStopMedia` | Media‑afspelen starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die herzien moet worden. |

Lees externe bestemmingen via [getExternalUrl](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) en specifieke interne bestemmingen via [getTargetSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Interne acties en ingebouwde commando’s kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Behoud de waarde die wordt geretourneerd door [getExternalUrlOriginal](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) wanneer deze verschilt van de genormaliseerde URL, en voeg de tooltip toe die wordt geretourneerd door [getTooltip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#getTooltip) indien beschikbaar.

### **Hyperlinks rapporteren, zuiveren en verifiëren**

Het volgende JavaScript‑voorbeeld leest een bestaande presentatie (gebruik het hierboven gemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activerings‑typen opnieuw te controleren. Het verzamelt containers voordat ze worden gewijzigd en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container twee keer wordt verwerkt. Presentatie‑queries bestrijken gewone dia’s; voor een pakket‑brede inventaris vraagt het ook expliciet masters, layouts, notities en de notitie‑ en handout‑masters op wanneer die aanwezig zijn.

Het rapport noteert een één‑gebaseerde dia‑index en [getSlideId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide#getSlideId) waar beschikbaar. [getSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getSlide) levert de eigende dia voor ondersteunde containers. Masters, layouts en notities hebben geen gewone dia‑index en worden geïdentificeerd aan de hand van hun reikwijdte. Vorm‑containers en tekstdeel‑opmaakcontainers worden apart gelabeld; andere containertypen behouden hun runtime‑typenaam. Elke container krijgt een lokaal rapport‑ID zodat de twee acties kunnen worden gecorreleerd. Het rapport slaat actietypen op als de geheel‑cijfer‑constanten gedefinieerd door de enumeratie HyperlinkActionType.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestand‑acties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheids­beoordeling van Aspose.Slides. HTTPS alleen biedt geen vertrouwen: voeg host‑whitelists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor herstel ondersteunt de container‑[getHyperlinkManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een door de toepassing beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑reviewbeleid: markeer muis‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel niet‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/) exporten kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[afbeeldingen](/slides/nl/nodejs-java/convert-powerpoint-to-png/) en [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditen voor die uitvoerformaten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestands‑muisknop‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL test ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), die beide activerings‑typen verwijdert binnen de geselecteerde reikwijdte, ongeacht het beleid. Verificatie controleert hier alleen hyperlink‑acties; het verwijdert niet ingebedde VBA‑projecten, OLE‑objecten of andere actieve content, en valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **Veelgestelde vragen**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op één dia. Om naar een sectie te navigeren, linkt u naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de masterdia koppelen zodat deze op alle dia’s werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de betreffende master‑ of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exporten kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).