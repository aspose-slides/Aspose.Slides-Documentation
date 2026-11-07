---
title: Aangepaste PowerPoint-lettertypen in .NET
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Pas lettertypen aan in PowerPoint-dia's met Aspose.Slides voor .NET om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie leveren via document‑niveau lettertypebronnen, of externe lettertypen direct vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden over verschillende omgevingen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave staat los van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluit‑functies voor lettertypen.

Een presentatie‑thema kan verschillende lettertypefamilies verwijzen voor individuele schriftsystemen. Deze koppelingen slaan lettertypenamen op, maar installeren of laden de lettertypebestanden niet. Zie [Script‑Specifieke Thema‑Lettertypen](/slides/nl/net/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de genoemde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Note" %}}
Aspose Slides stelt u in staat deze lettertypen te laden met de [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collectie (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze te installeren op het systeem. Dit beïnvloedt de exportoutput—zoals PDF, afbeeldingen en andere ondersteunde formaten—zodat de resulterende documenten er consistent uitzien over verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/​exporteer de presentatie.
4. Roep [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieer mappen die aangepaste lettertypebestanden bevatten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wis de lettertype-cache nadat het werk voltooid is.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de lettertype‑zoekpaden, maar wijzigt niet de volgorde van lettertype‑initialisatie.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard lettertypepad van het besturingssysteem.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) zijn geladen.
{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**

Aspose.Slides biedt de [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) methode om u lettertype‑mappen te laten vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeemlettertype‑mappen.

Deze C#‑code toont hoe u [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) gebruikt:

```c#
using Aspose.Slides;

// Deze regel geeft de mappen weer die gecontroleerd worden op lettertypebestanden.
// Dit zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeemlettertype-mappen.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Aangepaste lettertypen opgeven voor een presentatie**

Aspose.Slides biedt de eigenschap [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) waarmee u externe lettertypen kunt opgeven die met de presentatie gebruikt worden.

Deze C#‑code toont hoe u de [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) eigenschap gebruikt:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Werk met de presentatie
    // CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) methode waarmee u externe lettertypen uit binaire gegevens kunt laden.

Deze C#‑code toont het proces van het laden van een lettertype vanuit een byte‑array:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // extern lettertype geladen tijdens de levensduur van de presentatie
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Om een overeenkomend geregistreerd lettertype de voorkeur te geven tijdens export zonder het ingesloten lettertype te verwijderen, zie [Voorkeur voor geregistreerde lettertypen boven ingesloten lettertypen](/slides/nl/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 of later).

## **FAQ**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**  
Ja. De gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**  
Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als u het lettertype in het presentatie‑bestand wilt opnemen, moet u expliciet de [insluitfuncties](/slides/nl/net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**  
Ja. Configureer [font substitution](/slides/nl/net/font-substitution/), [vervangingsregels](/slides/nl/net/font-replacement/) en [fallback sets](/slides/nl/net/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**  
Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Hierdoor ontstaat geen afhankelijkheid van systeemlettertype‑mappen in het container‑image.

> **Opmerking voor Linux/Docker**: Bij het aanroepen van `FontsLoader.LoadExternalFonts` moet u ervoor zorgen dat elk item in de `directories`‑array een niet‑lege pad bevat naar een bestaande map. Als een omgevingsvariabele die wordt gebruikt om een lettertype‑pad op te bouwen niet is gedefinieerd of leeg is, kan Aspose.Slides proberen de lege waarde als een volledig pad te interpreteren, wat resulteert in `System.ArgumentException`.

**Hoe zit het met licenties—kan ik elk aangepast lettertype zonder beperkingen insluiten?**  
U bent zelf verantwoordelijk voor naleving van de lettertype‑licenties. De voorwaarden variëren; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de resultaten distribueert.