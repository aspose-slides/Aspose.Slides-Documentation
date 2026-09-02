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
description: "Pas lettertypen in PowerPoint-dia's aan met JavaScript en Aspose.Slides voor Node.js via Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat aangepaste lettertypen in presentaties te gebruiken zonder ze te installeren op het operating-system. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voorzien voor een specifieke presentatie via document-niveau lettertype-bronnen, of externe lettertypen direct laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype-mappen kunt inspecteren en hoe u de lettertype-cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX-bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruikt u expliciet de functies voor het insluiten van lettertypen.

Een presentatiethema kan verschillende lettertype-families refereren voor afzonderlijke schrift-systemen. Deze koppelingen slaan de namen van lettertypen op maar installeren of laden de lettertype-bestanden niet. Zie [Script-Specific Theme Fonts](/slides/nl/nodejs-java/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Note" %}}

Aspose Slides stelt u in staat deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat lettertypen die in een presentatie worden gebruikt te laden zonder ze te installeren op het systeem. Dit beïnvloedt de export-output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien over omgevingen heen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef een of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en render/export de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/clearcache/) aan om de lettertype-cache te wissen.

Het volgende codevoorbeeld toont het proces van het laden van lettertypen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Definieer mappen die aangepaste lettertypebestanden bevatten.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Laad aangepaste lettertypen uit de opgegeven mappen.
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

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de lettertype-zoekpaden, maar verandert niet de initialisatievolgorde van lettertypen.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard operating-system lettertypepad.
1. De paden die geladen zijn via [FontsLoader](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype-map ophalen**
Aspose.Slides levert de [getFontFolders](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)‑methode om u in staat te stellen lettertype-mappen te vinden. Deze methode retourneert mappen die zijn toegevoegd via de `LoadExternalFonts`‑methode en systeem-lettertype-mappen.

Deze JavaScript-code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Deze regel geeft de mappen weer waar lettertypebestanden worden gezocht.
// Dit zijn de mappen die via de LoadExternalFonts‑methode zijn toegevoegd en de systeem‑lettertype‑mappen.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen voor de presentatie specificeren**
Aspose.Slides levert de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑eigenschap zodat u externe lettertypen kunt opgeven die met de presentatie gebruikt zullen worden.

Deze JavaScript-code laat zien hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑eigenschap kunt gebruiken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Werken met de presentatie
    // CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettertypen extern beheren**

Aspose.Slides levert de [loadExternalFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen te laden vanuit binaire gegevens.

Deze JavaScript-code demonstreert het proces van het laden van een byte-array-lettertype:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // extern lettertype geladen gedurende de levensduur van de presentatie
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### Beïnvloeden aangepaste lettertypen de export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle export-formaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als u wilt dat het lettertype in het presentatie-bestand wordt meegenomen, moet u expliciet de [embed-features](/slides/nl/nodejs-java/embedded-font/) gebruiken.

### Kan ik het fallback-gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [font substitution](/slides/nl/nodejs-java/font-substitution/), [replacement rules](/slides/nl/nodejs-java/font-replacement/), en [fallback sets](/slides/nl/nodejs-java/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer het aangevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker-containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype-mappen of laad lettertypen vanuit byte-arrays. Dit verwijdert elke afhankelijkheid van systeem-lettertype-directories in de container-image.

### Hoe zit het met licenties — kan ik elk aangepast lettertype insluiten zonder beperkingen?

U bent zelf verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de outputs distribueert.