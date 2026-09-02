---
title: Aangepaste PowerPoint-lettertypen in Java
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

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie via document‑niveau lettertypebronnen beschikbaar stellen, of externe lettertypen direct uit binaire data laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is afzonderlijk van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluit‑functies.

Een presentatiethema kan verschillende lettertypefamilies verwijzen voor afzonderlijke schrijfsystemen. Deze mappings slaan lettertype‑namen op, maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑specifieke themalettertypen](/slides/nl/java/script-specific-font-mappings/) om de mappings te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Opmerking" %}}

Aspose Slides maakt het mogelijk om deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType‑ ( .ttf ) en TrueType‑collectie‑lettertypen ( .ttc ). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen ( .otf ). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze te installeren op het systeem. Dit beïnvloedt de export‑output – zoals PDF, afbeeldingen en andere ondersteunde formaten – zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meer mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode aan om de lettertypen uit die mappen te laden.  
3. Laad en render/​exporteer de presentatie.  
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader#clearCache--) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```java
import com.aspose.slides.*;

// Definieer de mappen die aangepaste lettertype‑bestanden bevatten.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/​exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertype‑cache nadat het werk voltooid is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de initialisatievolgorde van lettertypen.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑pad van het besturingssysteem voor lettertypen.  
1. De paden die worden geladen via [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**

Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--)‑methode zodat u lettertype‑mappen kunt vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) gebruikt:

```java
import com.aspose.slides.*;

// Deze regel geeft de mappen weer waar naar lettertype-bestanden wordt gezocht.
// Dat zijn de mappen die via de LoadExternalFonts-methode zijn toegevoegd en de systeem-lettertype-mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen opgeven die bij een presentatie worden gebruikt**

Aspose.Slides biedt de eigenschap [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) zodat u externe lettertypen kunt opgeven die bij de presentatie gebruikt worden.

Deze Java‑code toont hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) eigenschap gebruikt:

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
    // CustomFont1, CustomFont2, en lettertypen uit assets\fonts & global\fonts mappen en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de methode [loadExternalFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) zodat u externe lettertypen vanuit binaire data kunt laden.

Deze Java‑code demonstreert het laden van een lettertype vanuit een byte‑array:

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

### Hebben aangepaste lettertypen invloed op de export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten ervan in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u expliciet de [insluit‑functies](/slides/nl/java/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [lettertype‑substitutie](/slides/nl/java/font-substitution/), [vervangingsregels](/slides/nl/java/font-replacement/) en [fallback‑sets](/slides/nl/java/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeem‑wijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Hiermee wordt elke afhankelijkheid van systeem‑lettertype‑mappen in de container‑image verwijderd.

### Hoe zit het met licenties – mag ik elk aangepast lettertype insluiten zonder beperkingen?

U bent zelf verantwoordelijk voor de naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.