---
title: Aangepaste PowerPoint-lettertypen in .NET
linktitle: Aangepast Lettertype
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

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen aanbieden voor een specifieke presentatie via document‑niveau‑font‑bronnen, of externe lettertypen rechtstreeks uit binaire data laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in het presentatie‑bestand zelf moet worden opgeslagen, gebruikt u de insluit‑functionaliteit expliciet.

{{% alert color="primary" %}} 

Aspose Slides stelt u in staat deze lettertypen te laden met de [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) methode:

* TrueType (.ttf) en TrueType‑collectie (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de gegenereerde documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen uit aangepaste mappen.

1. Geef een of meer mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/expoteer de presentatie.  
4. Roep [FontsLoader.ClearCache](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld toont het lettertype‑laadproces:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieer mappen die aangepaste lettertypebestanden bevatten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/Exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wis de lettertype-cache nadat het werk is voltooid.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde waarin lettertypen worden geïnitialiseerd.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑pad voor lettertypen van het besturingssysteem.  
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert de mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeem‑lettertype‑mappen.

Deze C#‑code laat zien hoe u [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) gebruikt:

```c#
using Aspose.Slides;

// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dit zijn de mappen die via de LoadExternalFonts-methode zijn toegevoegd en de systeemlettertype-mappen.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Aangepaste lettertypen voor een presentatie specificeren**
Aspose.Slides biedt de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/) eigenschap om u in staat te stellen externe lettertypen te specificeren die met de presentatie worden gebruikt.

Deze C#‑code laat zien hoe u de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/) eigenschap gebruikt:

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
    // CustomFont1, CustomFont2, en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [LoadExternalFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) methode om externe lettertypen vanuit binaire data te laden.

Deze C#‑code demonstreert het laden van een lettertype via een byte‑array:

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

## **FAQ**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Aangesloten lettertypen worden door de renderer gebruikt bij alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het in te sluiten in een PPTX. Als u het lettertype in het presentatie‑bestand wilt behouden, moet u de expliciete [embedding features](/slides/nl/net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font substitution](/slides/nl/net/font-substitution/), [replacement rules](/slides/nl/net/font-replacement/) en [fallback sets](/slides/nl/net/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑mappen in het container‑image.

> **Opmerking voor Linux/Docker**: Wanneer u `FontsLoader.LoadExternalFonts` aanroept, zorgt u ervoor dat elk item in de `directories`‑array een niet‑lege pad naar een bestaande map bevat. Als een omgevingsvariabele die wordt gebruikt om een lettertype‑pad samen te stellen niet is gedefinieerd of leeg is, kan Aspose.Slides proberen de lege waarde te resolveren als een volledig pad, wat resulteert in `System.ArgumentException`.

**Wat betreft licenties — kan ik elk aangepast lettertype insluiten zonder restricties?**

U bent zelf verantwoordelijk voor naleving van de licentie van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de resultaten verspreidt.