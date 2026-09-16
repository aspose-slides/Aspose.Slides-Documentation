---
title: Hantera presentationshyperlänkar i JavaScript
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/nodejs-java/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- hyperlänk i text
- hyperlänk på bild
- hyperlänk på form
- hyperlänk för bild
- hyperlänk för video
- ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java, med JavaScript-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller ett mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides för Node.js via Java låter dig lägga till dessa länkar, kontrollera deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textram‑nivå.

{{% alert color="info" title="Note" %}}
Du kan också redigera presentationer med den [gratis online Aspose PowerPoint‑redigeraren](https://products.aspose.app/slides/sv/editor).
{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller ett mediaram. Det element som du tilldelar hyperlänken bestämmer det klickbara området: ett textavsnitt länkar den markerade texten, medan en form eller ett ram länkar bildobjektet.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, skicka en [Hyperlink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink) till textavsnittets [setHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick)-metod, som visas nedan. Endast det textavsnittet blir klickbart.

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

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ett ram klickbart, anropa dess [setHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setHyperlinkClick)-metod. Hyperlänken tillhör själva objektet snarare än ett textavsnitt inuti det.

Samma tillvägagångssätt gäller för bild‑, ljud‑ och videoram: tilldela hyperlänken till ramen och anropa [setTooltip](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setTooltip) om det behövs.

Följande exempel gör en rektangel klickbar:

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

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [setInternalHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) för att länka texten “Page 2” på den första bilden till den andra bilden.

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

## **Formatera hyperlänkar**

### **Färg**

Metoden [setColorSource](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setColorSource) för [Hyperlink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textavsnittets formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkColorSource) och ange avsnittets fyllnadsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

Följande exempel lägger till två texthyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standardhyperlänkfärgen.

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
### **Ljud**

En hyperlänk kan spela ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande metoder för att konfigurera dessa beteenden:

- [Hyperlink.setSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setSound) specificerar ljudet som är kopplat till hyperlänken.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) styr om aktivering av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Följande exempel laddar `sampleaudio.wav` och kopplar den till en knapp på den första bilden. När knappen klickas spelas ljudet och navigerar till nästa bild. En andra form på samma bild stoppar det föregående ljudet när den klickas, utan att utföra någon navigationsåtgärd.

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

#### **Extrahera ett hyperlänksljud**

Följande exempel öppnar presentationen som skapades ovan och läser hyperlänksljudet för den första formen till minnet via [getSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getSound) och [getBinaryData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **Verktygstips‑ och interaktionsinställningar**

Du kan anropa följande [Hyperlink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink)-metoder efter att ha tilldelat en hyperlänk till text eller en form:

- [setTooltip](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setTooltip) anger den text som en visare kan visa som ett tips för länken.
- [setTargetFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) specificerar mål‑ramen inom ett föräldra‑HTML‑frameset, när det är tillämpligt.
- [setHistory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setHistory) styr om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [setHighlightClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [getAnyHyperlinks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) för att samla in hyperlänksbehållare, inklusive länkar för textavsnitt, innan de ändras. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att ta bort endast en typ, anropa bara [removeHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) eller [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); borttagning av en klickåtgärd tar inte bort motsvarande mus‑över‑åtgärd.

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

För ovillkorlig borttagning tar [removeAllHyperlinks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av master‑bilder, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett komplett hyperlänkinventarium**

Innan en presentation distribueras, inventera dess interaktiva åtgärder samt dess webblänkar. [getAnyHyperlinks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) returnerar hyperlänksbehållare, inte en platt lista med URL‑strängar. Inspektera både [getHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getHyperlinkClick) och [getHyperlinkMouseOver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) för varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att skanna endast hyperlänkar på formnivå kan missa länkar som är fästa vid textavsnitt. Fråga istället rätt omfång och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation‑, bild‑ och textram‑omfång**

[HyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries)-klassen är tillgänglig via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) och [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Varje omfång stöder samma frågor:

- [getHyperlinkClicks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) returnerar behållare med en klickåtgärd.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) returnerar behållare med en mus‑över‑åtgärd.
- [getAnyHyperlinks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) returnerar behållare med antingen en eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klicklänk, en fil‑mus‑över‑länk, intern bildnavigering, en text‑mus‑över‑länk och en makroåtgärd. Det kör inte någon av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räknarna beskriver behållare, inte totalt antal åtgärder. Textram‑omfånget exkluderar den omgivande formens egna länkar.

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

För detta exempel rapporterar presentation‑ och bild‑frågor var och en tre klickbehållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [Hyperlink.getActionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getActionType) för att tolka en åtgärd innan du tolkar dess destination. [HyperlinkActionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkActionType)-värdena omfattar mer än webb‑navigering:

| Värden | Betydelse för en revision |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; granska URL‑en och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigering, löst i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta det aktuella bildspelet eller starta ett anpassat bildspel. |
| `StartMacro` | Kör ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från web‑URL:er. |
| `StartStopMedia` | Starta eller stoppa mediaplayback. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [getExternalUrl](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) och specifika interna destinationer från [getTargetSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara värdet som returneras av [getExternalUrlOriginal](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) när det skiljer sig från den normaliserade URL:en, och inkludera verktygstipset som returneras av [getTooltip](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#getTooltip) när det finns tillgängligt.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande JavaScript‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna på nytt. Det samlar in behållare innan de ändras och använder referenslikhet för att undvika att bearbeta samma behållare två gånger. Presentationsfrågor täcker vanliga bilder; för ett paket‑omfattande inventarium frågar det också explicit efter master‑bilder, layouter, anteckningar samt antecknings‑ och utskrifts‑master‑bilder när de finns.

Rapporten sparar ett en‑baserat bildindex och [getSlideId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide#getSlideId) där det finns tillgängligt. [getSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getSlide) ger den ägande bilden för stödda behållare. Master‑bilder, layouter och anteckningar har inget vanligt bildindex och identifieras efter deras omfång. Form‑behållare och formateringsbehållare för textavsnitt märks separat; andra behållartyper behåller sitt kör‑tids‑typenamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras. Rapporten lagrar åtgärdstyper som de heltalskonstanter som definieras av HyperlinkActionType‑enumerationen.

Denna avsiktligt restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, filåtgärder, andra bildspelsåtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policybeslut, inte ett säkerhetsvärde från Aspose.Slides. Enbart HTTPS etablerar inte förtroende: lägg till värdlistor och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För åtgärd kan behållarens [getHyperlinkManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getHyperlinkManager) stödja [setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) och [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick och förbjudna mus‑över‑åtgärder tas bort oberoende. Sätt `replaceExternalClicks` till `false` för att istället ta bort alla policy‑överträdningar. Välj en applikationsägd ersättningssida innan distribution.

Rapportens export‑flagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifik bildhopp som potentiellt ej stödd. Det är en granskningshint, inte ett kapacitetstest eller en garanti för att oflagade länkar överlever export. Stödda [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärd, exportalternativ och visare. Raster‑[bilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/) och [video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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

Med den indata som skapades ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makroklicken tas bort, medan HTTPS‑länkarna och den interna bildnavigeringen kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En indata som innehåller en förbjuden extern klick‑URL testar även ersättningsgrenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑åtgärd behåller sin klickåtgärd.

Denna selektiva rensning skiljer sig från [removeAllHyperlinks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar endast hyperlänksåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till en sektion eller dess första bild?**

Sektioner i PowerPoint grupperar bilder, men en intern hyperlänk pekar på en enskild bild. För att skapa navigering till en sektion, länka till den första bilden i den sektionen.

**Kan jag bifoga en hyperlänk till master‑bild‑element så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på bilder som använder motsvarande master eller layout.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan inte. Se export­övervägandena i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).