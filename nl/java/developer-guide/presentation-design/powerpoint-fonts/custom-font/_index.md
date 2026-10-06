---
title: Lettertypen voor PowerPoint aanpassen in Java
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
description: "Pas lettertypen in PowerPoint-dia's aan met Aspose.Slides voor Java om uw presentaties scherp en consistent op elk apparaat te houden."
---
## **Overzicht**

Met Aspose.Slides kunt u aangepaste lettertypen gebruiken in presentaties zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen leveren voor een specifieke presentatie via documentniveau‑lettertypebronnen, of externe lettertypen rechtstreeks vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluitingsfuncties voor lettertypen.

Een presentatiethema kan verschillende lettertypefamilies refereren voor afzonderlijke schriftsoorten. Deze koppelingen slaan lettertype‑namen op, maar installeren of laden de lettertypebestanden niet. Zie [Scriptspecifieke themaplettertypen](/slides/nl/java/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Note" %}}
Aspose Slides stelt u in staat deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Aangepaste lettertypen laden**

Met Aspose.Slides kunt u lettertypen die in een presentatie worden gebruikt laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien over verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld demonstreert het proces van het laden van lettertypen:

```java
import com.aspose.slides.*;

// Definieer mappen die aangepaste lettertypebestanden bevatten.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/exports de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met behulp van de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wis de lettertype-cache nadat het werk voltooid is.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de lettertype‑zoekpaden, maar verandert de volgorde van lettertype‑initialisatie niet.
Lettertypen worden in de volgende volgorde geïnitialiseerd:

1. Het standaardlettertypepad van het besturingssysteem.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/) geladen zijn.
{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) methode waarmee u lettertype‑mappen kunt vinden. Deze methode levert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze Java‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```java
import com.aspose.slides.*;

// Deze regel geeft de mappen weer waar naar lettertypebestanden wordt gezocht.
// Dat zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeem-lettertype-mappen.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Aangepaste lettertypen specificeren die bij een presentatie worden gebruikt**
Aspose.Slides biedt de eigenschap [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) waarmee u externe lettertypen kunt specificeren die met de presentatie worden gebruikt.

Deze Java‑code laat zien hoe u de [setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) eigenschap kunt gebruiken:

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
    // Werken met de presentatie
    // CustomFont1, CustomFont2, en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertypen extern beheren**
Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) methode waarmee u externe lettertypen vanuit binaire gegevens kunt laden.

Deze Java‑code demonstreert het proces van het laden van een lettertype uit een byte‑array:

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

## **Veelgestelde vragen**

### Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het inbedden in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluitings‑functies](/slides/nl/java/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [lettertype‑substitutie](/slides/nl/java/font-substitution/), [vervangingsregels](/slides/nl/java/font-replacement/) en [fallback‑sets](/slides/nl/java/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen in Linux/Docker‑containers gebruiken zonder ze systeemwijd te installeren?

Gedeeltelijk. Aspose.Slides kan lettertypen uit uw eigen mappen of uit byte‑arrays gebruiken zonder ze te installeren, maar de fonts‑ondersteuning van Java vereist nog steeds minimaal één geïnstalleerd lettertype in de image. Zonder een lettertype mislukt het laden met de fout "Fontconfig head is null, check your fonts or fonts configuration". Zie [Lettertypen implementeren](/slides/nl/java/deploy-fonts/).

### Hoe zit het met licenties — kan ik elk aangepast lettertype zonder beperkingen embedden?

U bent verantwoordelijk voor naleving van de lettertype‑licenties. De voorwaarden verschillen; sommige licenties verbieden inbedden of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output verspreidt.