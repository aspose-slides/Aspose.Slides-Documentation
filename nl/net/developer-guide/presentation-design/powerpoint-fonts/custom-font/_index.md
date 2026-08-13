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

Aspose.Slides stelt u in staat aangepaste lettertypen te gebruiken in presentaties zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden uit eigen mappen, lettertypen beschikbaar stellen voor een specifieke presentatie via document‑niveau font‑bronnen, of externe lettertypen direct vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de output van de presentatie consistent te houden over verschillende omgevingen heen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave staat los van het inbedden van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruikt u expliciet de inbed‑functies voor lettertypen.

{{% alert color="info" %}} 
Aspose Slides stelt u in staat deze lettertypen te laden met de [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat lettertypen te laden die in een presentatie worden gebruikt zonder ze op het systeem te installeren. Dit heeft invloed op de export‑output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de gegenereerde documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meer mappen op die de lettertype‑bestanden bevatten.  
2. Roep de statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/)‑methode aan om de lettertypen uit die mappen te laden.  
3. Laad en render/​exporteer de presentatie.  
4. Roep [FontsLoader.ClearCache](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het lettertype‑laadproces:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieer mappen die aangepaste lettertypebestanden bevatten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laad aangepaste lettertypen vanuit de gespecificeerde mappen.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Wis de lettertypecache nadat het werk is voltooid.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Opmerking" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde waarin lettertypen worden geïnitialiseerd.  
Lettertypen worden in de volgende volgorde geïnitialiseerd:

1. Het standaard‑letterpad van het besturingssysteem.  
1. De via [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/) geladen paden.
{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/)‑methode om lettertype‑mappen te vinden. Deze methode retourneert de mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeem‑lettertype‑mappen.

Deze C#‑code laat zien hoe u [GetFontFolders](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/getfontfolders/) gebruikt:

```c#
using AspNet.Slides;

// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dit zijn mappen die via de LoadExternalFonts‑methode zijn toegevoegd en systeem‑lettertype‑mappen.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Aangepaste lettertypen opgeven die met een presentatie worden gebruikt**
Aspose.Slides biedt de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/)‑eigenschap om externe lettertypen te specificeren die met de presentatie worden gebruikt.

Deze C#‑code toont hoe u de [DocumentLevelFontSources](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/documentlevelfontsources/)‑eigenschap gebruikt:

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

Deze C#‑code demonstreert het laadproces van een lettertype via een byte‑array:

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

**Hebben aangepaste lettertypen invloed op de export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingebed in de gegenereerde PPTX?**

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het inbedden ervan in een PPTX. Als u het lettertype in het presentatie‑bestand wilt opnemen, moet u de expliciete [inbed‑functies](/slides/nl/net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font‑substitutie](/slides/nl/net/font-substitution/), [vervangingsregels](/slides/nl/net/font-replacement/) en [fallback‑sets](/slides/nl/net/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeembrede lettertype‑mappen in het container‑image.

> **Opmerking voor Linux/Docker**: Wanneer u `FontsLoader.LoadExternalFonts` aanroept, moet elk element in de `directories`‑array een niet‑lege pad naar een bestaande map bevatten. Als een omgevingsvariabele die wordt gebruikt om een lettertype‑pad op te bouwen niet gedefinieerd of leeg is, kan Aspose.Slides proberen de lege waarde als een volledig pad te interpreteren, wat resulteert in `System.ArgumentException`.

**Hoe zit het met licenties — mag ik elk aangepast lettertype zonder beperkingen inbedden?**

U bent zelf verantwoordelijk voor de naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden inbedden of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u gegenereerde bestanden distribueert.