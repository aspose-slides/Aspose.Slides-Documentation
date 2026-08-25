---
title: Aangepaste PowerPoint-lettertypen op Android
linktitle: Aangepast Lettertype
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

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen aanbieden voor een specifieke presentatie via document‑niveau font‑bronnen, of externe lettertypen rechtstreeks vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de output van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor renderen is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype opgeslagen moet worden binnen de presentatie zelf, gebruik dan expliciet de functies voor het insluiten van lettertypen.

Een presentatiethema kan verschillende lettertype‑families refereren voor afzonderlijke schrijfsystemen. Deze toewijzingen slaan alleen lettertype‑namen op maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑Specific Theme Fonts](/slides/nl/androidjava/script-specific-font-mappings/) om de toewijzingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Opmerking" %}}

Aspose Slides stelt u in staat deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef een of meer mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsLoader#clearCache--) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```java
import com.aspose.slides.*;

// Definieer mappen die aangepaste lettertypebestanden bevatten.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/exporteer de presentatie (bv. naar PDF, afbeeldingen of andere formats) met de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertypecache nadat het werk voltooid is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde waarin lettertypen worden geïnitialiseerd.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑operating‑system‑pad voor lettertypen.  
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```java
import com.aspose.slides.*;

// Deze regel geeft de mappen weer waar lettertypebestanden worden gezocht.
// Dit zijn de mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeemlettertype‑mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**
Aspose.Slides biedt de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) eigenschap om u in staat te stellen externe lettertypen op te geven die met de presentatie worden gebruikt.

Deze Java‑code laat zien hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) eigenschap kunt gebruiken:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Werk met de presentatie
    // CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) methode om externe lettertypen te laden vanuit binaire gegevens.

Deze Java‑code toont het proces van het laden van een lettertype uit een byte‑array:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // extern lettertype geladen gedurende de levensduur van de presentatie
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Een lettertype registreren voor renderen is niet hetzelfde als het insluiten in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluitings‑features](/slides/nl/androidjava/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag sturen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [font substitution](/slides/nl/androidjava/font-substitution/), [replacement rules](/slides/nl/androidjava/font-replacement/) en [fallback sets](/slides/nl/androidjava/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen uit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑directories in de container‑image.

### Hoe zit het met licenties — kan ik elk aangepast lettertype zonder restricties insluiten?

U bent zelf verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.