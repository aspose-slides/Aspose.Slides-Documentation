---
title: Lettertypen aanpassen in PowerPoint met Java
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/java/custom-font/
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
- Java
- Aspose.Slides
description: "Pas lettertypen in PowerPoint-dia's aan met Aspose.Slides voor Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden vanuit eigen mappen, lettertypen bieden voor een specifieke presentatie via document‑niveau font‑bronnen, of externe lettertypen direct laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. In dit artikel wordt ook uitgelegd hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor rendering is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype binnen de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluitings‑functies voor lettertypen.

{{% alert color="primary" %}} 

Aspose Slides stelt u in staat om deze lettertypen te laden via de [loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collectie‑lettertypen (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef een of meer mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/​export de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```java
// Definieer mappen die aangepaste lettertype-bestanden bevatten.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met behulp van de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertype-cache nadat het werk klaar is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de initialisatievolgorde van lettertypen.
Lettertypen worden geïnitieerd in de volgende volgorde:

1. Het standaard lettertypepad van het besturingssysteem.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) methode om lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```java
// Deze regel geeft de mappen weer waar lettertypebestanden worden gezocht.
// Dat zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeembrede lettertype-mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen voor een presentatie opgeven**
Aspose.Slides biedt de eigenschap [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) om externe lettertypen op te geven die met de presentatie worden gebruikt. 

Deze Java‑code laat zien hoe u de eigenschap [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) kunt gebruiken:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Werk met de presentatie
    // CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts en global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) methode om externe lettertypen te laden vanuit binaire gegevens.

Deze Java‑code demonstreert het laadproces van een lettertype vanuit een byte‑array:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // extern lettertype geladen tijdens de levensduur van de presentatie
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. De gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Een lettertype registreren voor rendering is niet hetzelfde als het insluiten in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluitings‑functies](/slides/nl/java/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag sturen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [lettertype‑substitutie](/slides/nl/java/font-substitution/), [vervangingsregels](/slides/nl/java/font-replacement/) en [fallback‑sets](/slides/nl/java/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑mappen in de container‑image.

**Hoe zit het met licenties—kan ik elk aangepast lettertype insluiten zonder beperkingen?**

U bent zelf verantwoordelijk voor de naleving van de licenties van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de resultaten distribueert.