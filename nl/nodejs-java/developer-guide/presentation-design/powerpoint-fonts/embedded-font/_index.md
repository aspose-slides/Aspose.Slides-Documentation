---
title: Lettertypen insluiten in presentaties met JavaScript
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/nodejs-java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Insluit TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java, waardoor nauwkeurige weergave op alle platforms wordt gegarandeerd."
---
## **Inleiding**

**Ingebedde lettertypen in PowerPoint** zijn handig wanneer u wilt dat uw presentatie er op elk systeem of apparaat correct uitziet. Als u een lettertype van een derde partij of een niet‑standaard lettertype hebt gebruikt omdat u creatief bent geweest, dan hebt u nog meer redenen om uw lettertype in te sluiten. Anders (zonder ingesloten lettertypen) kunnen de teksten of cijfers op uw dia’s, de lay‑out, opmaak, enz. veranderen of zich omzetten in verwarrende rechthoeken. 

De [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager) klasse, de [FontData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontdata/) klasse, de [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) klasse en hun klassen bevatten het grootste deel van de eigenschappen en methoden die u nodig hebt om met ingesloten lettertypen in PowerPoint‑presentaties te werken.

## **Ingesloten lettertypen ophalen of verwijderen uit een presentatie**

Aspose.Slides biedt de [getEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) methode (uitgebracht door de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager) klasse) om u de ingesloten lettertypen in een presentatie te laten ophalen (of te ontdekken). Om lettertypen te verwijderen, wordt de [removeEmbeddedFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) methode (uitgebracht door dezelfde klasse) gebruikt.

Deze JavaScript‑code toont hoe u ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```javascript
// Instantieert een Presentation‑object dat een presentatiedocument vertegenwoordigt
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderen van een dia met een tekstvak dat het ingesloten "FunSized"-lettertype gebruikt
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Sla de afbeelding op schijf in JPEG‑formaat
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Haal alle ingesloten lettertypen op
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Zoek het "Calibri"-lettertype
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Verwijder het "Calibri"-lettertype
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Render de presentatie; het "Calibri"-lettertype wordt vervangen door een bestaand lettertype
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Sla de afbeelding op schijf in JPEG‑formaat
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Sla de presentatie op zonder ingesloten "Calibri"-lettertype op schijf
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ingesloten lettertypen toevoegen aan een presentatie**

Met behulp van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/embedfontcharacters/) enumeratie en twee overloads van de [addEmbeddedFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) methode, kunt u de door u gewenste (insluit‑)regel selecteren om de lettertypen in een presentatie in te sluiten. Deze JavaScript‑code laat zien hoe u lettertypen kunt insluiten en toevoegen aan een presentatie:

```javascript
// Laadt de presentatie
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Slaat de presentatie op schijf
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ingesloten lettertypen comprimeren**

Om u in staat te stellen de ingesloten lettertypen in een presentatie te comprimeren en de bestandsgrootte te verkleinen, biedt Aspose.Slides de [compressEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) methode (uitgebracht door de [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) klasse).

Deze JavaScript‑code laat zien hoe u ingesloten PowerPoint‑lettertypen kunt comprimeren:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hoe kan ik zien dat een specifiek lettertype in de presentatie toch wordt vervangen tijdens het renderen, ondanks het insluiten?**

Controleer de [substitution information](/slides/nl/nodejs-java/font-substitution/) in de lettertype‑manager en de [fallback/substitution rules](/slides/nl/nodejs-java/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt een fallback gebruikt.

**Is het de moeite waard om “systeem”‑lettertypen zoals Arial/Calibri in te sluiten?**

Meestal niet — ze zijn vrijwel altijd beschikbaar. Maar voor volledige draagbaarheid in “dunne” omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeem‑lettertypen het risico op onverwachte substituties wegnemen.