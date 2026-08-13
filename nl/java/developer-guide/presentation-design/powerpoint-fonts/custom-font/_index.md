---
title: "Pas PowerPoint-lettertypen aan in Java"
linktitle: "Aangepast lettertype"
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
description: "Pas lettertypen aan in PowerPoint-dia's met Aspose.Slides voor Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie via document‑niveau fontbronnen aanbieden, of externe lettertypen direct laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor rendering is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype moet worden opgeslagen binnen de presentatie zelf, gebruik dan expliciet de insluitings‑features.

{{% alert color="info" %}} 

Aspose Slides stelt u in staat om deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef één of meerdere mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en render/ exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende codevoorbeeld laat het laadproces van lettertypen zien:

```java
import com.aspose.slides.*;

// Definieer de mappen die aangepaste lettertypebestanden bevatten.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertype-cache nadat het werk voltooid is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde van lettertype‑initialisatie.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard besturingssysteem‑lettertypepad.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--)‑methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```java
import com.aspose.slides.*;

// Deze regel geeft de mappen weer waar lettertypebestanden worden gezocht.
// Dit zijn mappen die via de LoadExternalFonts‑methode zijn toegevoegd en systeem‑lettertype‑mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen opgeven die met een presentatie worden gebruikt**
Aspose.Slides biedt de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑eigenschap om externe lettertypen op te geven die met de presentatie worden gebruikt. 

Deze Java‑code laat zien hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑eigenschap gebruikt:

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

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen te laden vanuit binaire gegevens.

Deze Java‑code demonstreert het laadproces van een lettertype via een byte‑array:

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

Ja. Verbonden lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?

Nee. Het registreren van een lettertype voor rendering is niet hetzelfde als het insluiten ervan in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluitings‑features](/slides/nl/java/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [lettertype‑substitutie](/slides/nl/java/font-substitution/), [vervangingsregels](/slides/nl/java/font-replacement/) en [fallback‑sets](/slides/nl/java/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑directories in de container‑image.

### Hoe zit het met licenties — mag ik elk aangepast lettertype insluiten zonder restricties?

U bent verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.