---
title: Hantera presentationens sidhuvuden och sidfötter i JavaScript
linktitle: Sidhuvud & Sidfot
type: docs
weight: 140
url: /sv/nodejs-java/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ange sidhuvud
- ange sidfot
- handout
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Använd JavaScript och Aspose.Slides för Node.js för att lägga till och anpassa sidhuvuden och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera inställningar för sidhuvud och sidfot i PowerPoint‑presentationer. Sidhuvuden och sidfötter hanteras på presentations‑masternivå, och API‑et erbjuder metoder för att ange sidfotstext, ändra sidfotens synlighet och uppdatera sidhuvudstext på master‑noteringsbilder.

Du kan även hantera sidhuvuden och sidfötter för utdelnings‑ och notssidor. Detta inkluderar att ändra synlighet och text för sidhuvud, sidfot, bildnummer och datum‑tid‑platshållare för notsmästaren, alla underliggande notbilder eller en enskild notbild.

## **Hantera sidhuvud och sidfot i presentation**
Anteckningar för någon specifik bild kan tas bort, som visas i exemplet nedan:

```javascript
// Läs in presentation
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Ställer in sidfot
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Åtkomst och uppdatering av sidhuvud
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Spara presentation
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Hantera sidhuvud och sidfot i utdelnings‑ och notssidor**
Aspose.Slides for Node.js via Java stöder Sidhuvud och Sidfot i utdelnings‑ och notssidor. Följ stegen nedan:

- Läs in en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller en video.
- Ändra sidhuvuds‑ och sidfotsinställningar för notsmästaren och alla notbilder.
- Gör master‑notebildens och alla underliggande sidfot‑platshållare synliga.
- Gör master‑notebildens och alla underliggande datum‑ och tid‑platshållare synliga.
- Ändra sidhuvuds‑ och sidfotsinställningar endast för den första notbilden.
- Gör notbildens sidhuvuds‑platshållare synlig.
- Ange text för notbildens sidhuvuds‑platshållare.
- Ange text för notbildens datum‑tid‑platshållare.
- Skriv den modifierade presentationsfilen.

Kodexempel tillhandahållet i exemplet nedan.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Ändra inställningar för sidhuvud och sidfot för notsmästare och alla notbilder
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// gör master‑notebilden och alla underliggande sidfot‑platshållare synliga
        headerFooterManager.setFooterAndChildFootersVisibility(true);// gör master‑notebilden och alla underliggande sidhuvud‑platshållare synliga
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// gör master‑notebilden och alla underliggande bildnummer‑platshållare synliga
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// gör master‑notebilden och alla underliggande datum‑och‑tids‑platshållare synliga
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// sätt text på master‑notebilden och alla underliggande sidhuvud‑platshållare
        headerFooterManager.setFooterAndChildFootersText("Footer text");// sätt text på master‑notebilden och alla underliggande sidfot‑platshållare
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// sätt text på master‑notebilden och alla underliggande datum‑och‑tids‑platshållare
    }
    // Ändra inställningar för sidhuvud och sidfot endast för den första notbilden
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// gör denna notbilds sidhuvud‑platshållare synlig
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// gör denna notbilds sidfot‑platshållare synlig
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// gör denna notbilds bildnummer‑platshållare synlig
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// gör denna notbilds datum‑tids‑platshållare synlig
        headerFooterManager.setHeaderText("New header text");// sätt text på notbildens sidhuvud‑platshållare
        headerFooterManager.setFooterText("New footer text");// sätt text på notbildens sidfot‑platshållare
        headerFooterManager.setDateTimeText("New date and time text");// sätt text på notbildens datum‑tids‑platshållare
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag lägga till ett "sidhuvud" på vanliga bilder?**

I PowerPoint finns "Header" bara för anteckningar och utdelningar; på vanliga bilder är de stödja elementen sidfot, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: sidhuvud endast för anteckningar/utdelning, och på bilder — sidfot/datum‑tid/bildnummer.

**Vad händer om layouten inte innehåller ett sidfot‑område—kan jag "aktivera" dess synlighet?**

Ja. Kontrollera synligheten via sidhuvud-/sidfot‑hanteraren och aktivera den om det behövs. Dessa API‑indikatorer och metoder är avsedda för situationer när platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ställ in presentationens [first slide number](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/setfirstslidenumber/); därefter räknas alla numreringar om. Till exempel kan du börja på 0 eller 10, och dölja numret på titeldbilden.

**Vad händer med sidhuvuden/sidfötter vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det betyder att om elementen är synliga på bilder/anteckningssidor, så kommer de även att visas i exportformatet tillsammans med övrigt innehåll.