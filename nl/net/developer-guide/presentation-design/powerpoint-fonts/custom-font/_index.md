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
description: "Pas lettertypen in PowerPoint-dia's aan met Aspose.Slides voor .NET om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie via documentniveau-lettertypebronnen beschikbaar stellen, of externe lettertypen rechtstreeks uit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave staat los van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype binnen de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluit‑functies voor lettertypen.

{{% alert color="primary" %}} 

Aspose Slides stelt u in staat deze lettertypen te laden met de [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien over verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meer mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/​exporteer de presentatie.
4. Roep [FontsLoader.ClearCache](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```cs
// Definieer de mappen die aangepaste lettertypebestanden bevatten.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met behulp van de geladen lettertypen.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wis de lettertype-cache nadat het werk voltooid is.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert de initialisatievolgorde van lettertypen niet.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard lettertypepad van het besturingssysteem.
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) methode waarmee u lettertype‑mappen kunt vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze C#‑code laat zien hoe u [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) gebruikt:

```c#
// Deze regel geeft de mappen weer die gecontroleerd worden op lettertypebestanden.
// Dit zijn mappen die zijn toegevoegd via de LoadExternalFonts‑methode en systeem‑lettertype‑mappen.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Aangepaste lettertypen opgeven die met een presentatie worden gebruikt**
Aspose.Slides biedt de eigenschap [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/) waarmee u externe lettertypen kunt opgeven die met de presentatie worden gebruikt.

Deze C#‑code laat zien hoe u de eigenschap [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/) gebruikt:

```c#
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

Aspose.Slides biedt de [LoadExternalFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) methode zodat u externe lettertypen kunt laden vanuit binaire gegevens.

Deze C#‑code demonstreert het proces van het laden van een lettertype uit een byte‑array: 

```c#
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

## **Veelgestelde vragen**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het insluiten ervan in een PPTX. Als u het lettertype in het presentatie‑bestand wilt opnemen, moet u de expliciete [insluit‑functies](/slides/nl/net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [lettertype‑substitutie](/slides/nl/net/font-substitution/), [vervangingsregels](/slides/nl/net/font-replacement/) en [fallback‑sets](/slides/nl/net/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen uit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑mappen in het container‑image.

**Wat betreft licenties — kan ik elk aangepast lettertype zonder beperkingen insluiten?**

U bent verantwoordelijk voor de naleving van de lettertype‑licenties. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u resultaten verspreidt.