---
title: Aangepaste PowerPoint-lettertypen in JavaScript
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/nodejs-java/custom-font/
keywords:
- lettertype
- aangepast lettertype
- extern lettertype
- lettertype laden
- lettertypen beheren
- lettertype map
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Aangepaste lettertypen in PowerPoint-dia’s met JavaScript en Aspose.Slides voor Node.js via Java om je presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt je in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. Je kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie leveren via document‑niveau lettertypebronnen, of externe lettertypen direct laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe je de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe je de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave staat los van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de functies voor het insluiten van lettertypen.

{{% alert color="primary" %}} 

Aspose Slides stelt je in staat om deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt je in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output—zoals PDF, afbeeldingen en andere ondersteunde formaten—zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef één of meer mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)‑methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/​exporteer de presentatie.  
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld laat het lettertype‑laadproces zien:

```js
// Definieer mappen die aangepaste lettertypebestanden bevatten.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Laad aangepaste lettertypen van de opgegeven mappen.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertype-cache nadat het werk is voltooid.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de initialisatievolgorde van lettertypen.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑operating‑system‑lettertypepad.  
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑map ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)‑methode om je in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze JavaScript‑code laat zien hoe je [getFontFolders](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) gebruikt:

```javascript
// Deze regel geeft de mappen weer waar lettertypebestanden worden gezocht.
// Dat zijn de mappen die via de LoadExternalFonts‑methode zijn toegevoegd en systeembrede lettertype‑mappen.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen specificeren die met de presentatie worden gebruikt**
Aspose.Slides biedt de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑eigenschap om externe lettertypen op te geven die met de presentatie zullen worden gebruikt.

Deze JavaScript‑code laat zien hoe je de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑eigenschap gebruikt:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Werk met de presentatie
    // CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts en global\fonts en hun subfolders zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen te laden vanuit binaire gegevens.

Deze JavaScript‑code demonstreert het laden van een lettertype via een byte‑array:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // extern lettertype geladen tijdens de levensduur van de presentatie
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt in alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als je wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet je expliciet de [insluit‑functies](/slides/nl/nodejs-java/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font substitution](/slides/nl/nodejs-java/font-substitution/), [replacement rules](/slides/nl/nodejs-java/font-replacement/) en [fallback sets](/slides/nl/nodejs-java/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar je eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑mappen in het container‑image.

**Wat betreft licenties—mag ik elk aangepast lettertype zonder restricties insluiten?**

Jij bent verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat je de output distribueert.