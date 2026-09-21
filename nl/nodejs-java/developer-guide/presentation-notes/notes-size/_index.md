---
title: Wijzig notitiepagina grootte en oriëntatie in JavaScript
linktitle: Notitiepagina-grootte
type: docs
weight: 10
url: /nl/nodejs-java/notes-size/
keywords:
- notitiepagina grootte
- notitie-oriëntatie
- liggende notities
- staande notities
- hand-out grootte
- PowerPoint
- presentatie
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lees en wijzig de notitiepagina-afmetingen in Aspose.Slides voor Node.js via Java, verander de oriëntatie, controleer de opgeslagen maten en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getnotessize/) om de notitiepagina‑instellingen van de presentatie te benaderen. Het retourneert een [NotesSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notessize/) object waarvan de [setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notessize/setsize/) methode de paginadimensies instelt. Hoewel het instellingenobject zelf niet kan worden vervangen, kun je via deze methode nieuwe afmetingen toewijzen.

Breedte en hoogte worden opgegeven in **punten**, met 72 punten per duim. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8⅓ inch. Deze instellingen gelden voor de hele presentatie, niet voor de notities van een individuele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getnotessize/) | Beheert de afmetingen van de notitiepagina en de afmetingen die worden gebruikt voor de hand‑out export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslidesize/) | Beheert de reguliere dia‑afmetingen van de presentatie via [SlideSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/). |

Het wijzigen van een van beide instellingen verandert de andere niet automatisch. Het wijzigen van de oriëntatie van de notitiepagina draait de reguliere dia's ook niet. Zie [Slide Size](/slides/nl/nodejs-java/slide-size/) om de reguliere dia's van grootte te wijzigen.

De voorbeelden hieronder gebruiken een bestaand `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met minimaal één dia met spreker‑notities. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **Lees de grootte en oriëntatie van de notitiepagina**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen duiden op een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen uit in punten, zonder een standaardpapierformaat aan te nemen.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Schakel over naar liggend zonder het papieren formaat te wijzigen**

Om alleen de oriëntatie te wijzigen, verwissel je de bestaande breedte en hoogte. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De onderstaande voorwaarde voorkomt dat een reeds liggende pagina terug naar staand wordt geschakeld en laat een vierkante pagina ongewijzigd.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.getWidth() > size.getHeight()`. Vervang de afmetingen van A4 of Letter niet, tenzij je ook het papieren formaat wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en controleer deze**

Ken beide afmetingen tegelijk toe en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/save/) om de presentatie op te slaan. Dit voorbeeld stelt een liggende pagina van 900 × 600 punten in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de bewaarde waarden te controleren. De vergelijking staat een tolerantie van 0,01 punt toe voor zwevend‑komma waarden; dit is geen garantie voor precisie voor elk bestandsformaat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Het verwachte resultaat is `900 x 600 points` en `Size preserved: true`. Het controleren van een nieuw geopende presentatie verifieert het opgeslagen bestand, in plaats van alleen de instellingen in het geheugen.

## **Exporteer notities en hand‑outs**

De paginadimensies bepalen het beschikbare gebied voor notities of hand‑out‑lay‑outs. Ze activeren die lay‑-outs niet automatisch: configureer ook de exportopties. Export van reguliere dia's blijft de dia‑afmetingen gebruiken.

### **Exporteer notities naar PDF en PNG**

Ken [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) toe aan [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) om notities in de PDF op te nemen. Dit voorbeeld rendert daarnaast de eerste dia met notities naar PNG met behulp van [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) en [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/).

De modus [BottomTruncated](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notespositions/) houdt de notities op één pagina; notities die niet passen kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punten. Bij de hieronder gebruikte afbeeldingsschaal van 1 × 1 is de PNG 900 × 600 pixels. Punten beschrijven de paginageometrie; pixels beschrijven de rasteruitvoer, waarvan de afmetingen ook afhankelijk zijn van de renderingschaal.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Voor PDF‑export met lange notities maakt [BottomFull](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notespositions/) extra pagina’s mogelijk indien nodig. Gebruik die modus niet met de bovenstaande single‑slide‑afbeeldingsaanroep, die deze niet ondersteunt. Na het wijzigen van de afmetingen, inspecteer je de output op afgekapte notities en de plaatsing van bestaande notes‑master‑objecten; het alleen wijzigen van de paginagrootte mag niet worden beschouwd als een garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/nodejs-java/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Exporteer hand‑outs naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/handoutlayoutingoptions/) voor meerdere diapresentaties op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punten in en gebruikt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/handouttype/) om tot vier dia's per pagina te rangschikken. De horizontale preset bepaalt de volgorde van de dia's; de paginoriëntatie wordt bepaald door de breedte en hoogte.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het hand‑out‑rooster zonder de afmetingen van de bron‑dia's aan te passen. Voor hand‑out‑afbeeldingen gebruik je [Presentation.getImages](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getimages/) met de hand‑out‑lay‑out, in plaats van de afbeeldingsmethode van een individuele dia. In Aspose.Slides gebruikt de rendering van hand‑outs op presentatieniveau de notitiepagina‑dimensies, terwijl de afbeelding van een individuele dia geen hand‑out‑pagina oplevert. Zie [Handout Mode](/slides/nl/nodejs-java/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Pagina‑grootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiegrootte, de geëxporteerde paginagrootte en de afgedrukte papergrootte gescheiden:

- **Presentation viewers:** Een viewer kan notities weergeven of afdrukken volgens zijn eigen lay‑outrichtlijnen. Als een andere applicatie het bestand opslaat, open het opnieuw en controleer de afmetingen; de bestandsconversie van die applicatie kan ze normaliseren.
- **Export formats:** De notitie‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Rasterafbeeldingen gebruiken gehele pixel‑dimensies en een renderingschaal, waardoor decimale puntwaarden in de afbeelding kunnen worden afgerond. Het exporteren van reguliere dia's maakt geen gebruik van de notitiepagina‑grootte.
- **Printer drivers:** Papierselectie, automatische rotatie en fit‑to‑page‑instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat stem je de printerinstellingen af en controleer je de afdrukvoorbeeld.

## **Veelgestelde vragen**

**Kan ik de notitiegrootte alleen voor één dia instellen?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia's kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen afzonderlijke paginagrootte per dia.

**Waarom heeft het wijzigen van de notitie‑oriëntatie mijn dia's niet gewijzigd?**

Notitiepagina's en reguliere dia's hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia's zelf wilt herschalen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die zijn gewijzigd, controleer dan of het opslaan of converteren van het bestand in een andere applicatie de pagina‑instellingen heeft aangepast. Als dat niet het geval is, controleer dan de export‑lay‑out, afbeeldingsschaal, viewer‑instellingen en printer‑papierselectie.