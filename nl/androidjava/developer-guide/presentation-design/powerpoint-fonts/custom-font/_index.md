---
title: Aangepaste PowerPoint-lettertypen op Android
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Pas lettertypen in PowerPoint-dia's aan met Aspose.Slides voor Android via Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen aan een specifieke presentatie leveren via document‑niveau font‑bronnen, of externe lettertypen rechtstreeks laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden tussen verschillende omgevingen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt opruimen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype moet worden opgeslagen binnen de presentatie zelf, gebruikt u de insluit‑functies expliciet.

{{% alert color="primary" %}} 

Aspose Slides stelt u in staat deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste Lettertypen Laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output—zoals PDF, afbeeldingen en andere ondersteunde formaten—zodat de resulterende documenten er consistent uitzien tussen omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meerdere mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/­exporteer de presentatie.  
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsLoader#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het lettertype‑laadproces:

```java
// Definieer mappen die aangepaste lettertypebestanden bevatten.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Leeg de lettertypecache nadat het werk voltooid is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de initiatie‑volgorde van lettertypen.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑pad van het besturingssysteem.  
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste Lettertype‑Mappen Ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)‑methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeembrede lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```java
// Deze regel geeft de mappen weer waar naar lettertypebestanden wordt gezocht.
// Dit zijn de mappen die via de LoadExternalFonts-methode zijn toegevoegd en de systeembrede lettertype-mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste Lettertypen Opgeven voor een Presentatie**
Aspose.Slides biedt de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑eigenschap om externe lettertypen op te geven die met de presentatie worden gebruikt.

Deze Java‑code laat zien hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑eigenschap kunt gebruiken:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Werk met de presentatie
    // CustomFont1, CustomFont2, en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertypen Extern Beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen te laden vanuit binaire gegevens.

Deze Java‑code demonstreert het laden van een lettertype uit een byte‑array:

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

Ja. Verbonden lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?**

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het insluiten in een PPTX. Als u het lettertype in het presentatie‑bestand wilt opnemen, moet u de expliciete [insluit‑functies](/slides/nl/androidjava/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font substitution](/slides/nl/androidjava/font-substitution/), [replacement rules](/slides/nl/androidjava/font-replacement/) en [fallback sets](/slides/nl/androidjava/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeem‑breed te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeembrede lettertype‑mappen in het container‑image.

**Wat betreft licenties—mag ik elk aangepast lettertype zonder beperkingen insluiten?**

U bent verantwoordelijk voor naleving van de lettertype‑licenties. De voorwaarden variëren; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.