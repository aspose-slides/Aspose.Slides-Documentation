---
title: PowerPoint-lettertypen aanpassen in .NET
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
- lettertypefolder
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas lettertypen in PowerPoint‑dia's aan met Aspose.Slides voor .NET om je presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. Je kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie beschikbaar stellen via document‑level font sources, of externe lettertypen direct uit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden tussen verschillende omgevingen. Het artikel legt ook uit hoe je de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe je de lettertype‑cache kunt legen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluit‑functies.

Een presentatiethema kan verschillende lettertypefamilies refereren voor individuele schrijfsystemen. Deze koppelingen slaan alleen lettertype‑namen op, maar installeren of laden de lettertypebestanden niet. Zie [Script‑Specific Theme Fonts](/slides/nl/net/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Opmerking" %}}

Aspose Slides stelt je in staat deze lettertypen te laden met de [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides maakt het mogelijk lettertypen te laden die in een presentatie worden gebruikt zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output – zoals PDF, afbeeldingen en andere ondersteunde formaten – zodat de resulterende documenten er consistent uitzien tussen omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meerdere mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/)‑methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/­exporteer de presentatie.  
4. Roep [FontsLoader.ClearCache](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieer de mappen die aangepaste lettertypebestanden bevatten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/en exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wis de lettertypecache nadat het werk voltooid is.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert de volgorde van initialisatie niet.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑lettertypepad van het besturingssysteem.  
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertypefolders ophalen**
Aspose.Slides biedt de [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/)‑methode om je lettertypefolders te laten vinden. Deze methode retourneert de folders die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeembrede lettertypefolders.

Deze C#‑code laat zien hoe je [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) gebruikt:

```c#
using Aspose.Slides;

// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dit zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeembrede lettertype-mappen.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**
Aspose.Slides biedt de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/)‑eigenschap om externe lettertypen op te geven die bij de presentatie worden gebruikt.

Deze C#‑code laat zien hoe je de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/)‑eigenschap gebruikt:

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

Aspose.Slides biedt de [LoadExternalFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)‑methode om externe lettertypen vanuit binaire gegevens te laden.

Deze C#‑code toont het proces van het laden van een lettertype‑byte‑array:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // extern lettertype geladen gedurende de levensduur van de presentatie
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Veelgestelde vragen**

**Beïnvloeden aangepaste lettertypen de export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. De verbonden lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?**

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het insluiten in een PPTX. Als je wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet je de expliciete [insluit‑functies](/slides/nl/net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font‑substitutie](/slides/nl/net/font-substitution/), [vervangingsregels](/slides/nl/net/font-replacement/) en [fallback‑sets](/slides/nl/net/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyph afwezig is.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar je eigen lettertypefolders of laad lettertypen vanuit byte‑arrays. Hiermee vermijd je elke afhankelijkheid van systeembrede lettertype‑directories in de container‑image.

> **Opmerking voor Linux/Docker**: Bij het aanroepen van `FontsLoader.LoadExternalFonts` moet elk item in de `directories`‑array een niet‑lege pad naar een bestaande map bevatten. Als een omgevingsvariabele die wordt gebruikt om een lettertypepad samen te stellen niet is gedefinieerd of leeg is, kan Aspose.Slides proberen de lege waarde als een volledig pad op te lossen, wat leidt tot `System.ArgumentException`.

**Hoe zit het met licenties – kan ik elk aangepast lettertype zonder beperkingen insluiten?**

Jij bent verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat je de resultaten verspreidt.