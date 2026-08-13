---
title: Specificeer fallback-lettertypen voor presentaties in .NET
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/net/create-fallback-font/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype toepassen
- lettertype vervangen
- Unicode-bereik
- ontbrekende glyph
- juiste glyph
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheers Aspose.Slides voor .NET om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de weergave van tekst consistent blijft op elk apparaat of besturingssysteem."
---
## **Overzicht**

Aspose.Slides maakt het u mogelijk om fallback-lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback-lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs voor bepaalde tekens bevat.

Fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan één of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback-lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn instellingen voor rendering tijdens runtime. Ze wijzigen het presentatiedocument zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de interface [IFontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/iFontFallBackRule) en de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) om de regels op te geven die een fallback-lettertype toepassen. De klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, gebruikt om ontbrekende glyphs te zoeken, en een lijst met lettertypen die de juiste glyphs kunnen bevatten:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Met verschillende methoden kun je een lijst met lettertypen toevoegen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback-lettertype te [Remove()](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontfallbackrule/methods/remove) of [AddFallBackFonts()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection) kan worden gebruikt om een lijst met [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er behoefte is aan het specificeren van fallback-lettertype‑vervangingsregels voor meerdere Unicode‑bereiken.

{{% alert color="info" title="Zie ook" %}} 
- [Maak fallback-lettertypencollectie](/slides/nl/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Wat is het verschil tussen een fallback-lettertype, lettertype‑substitutie en lettertype‑embedden?

Een fallback-lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/net/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Font embedding](/slides/nl/net/embedded-font/) verpak de lettertypen in het uitvoerbestand zodat ontvangers de tekst zoals bedoeld kunnen bekijken.

### Worden fallback-lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?

Ja. Fallback beïnvloedt alle [rendering and export operations](/slides/nl/net/convert-presentation/) waarbij tekens getekend moeten worden maar ontbreken in het bronlettertype.

### Verandert het configureren van fallback het presentatiedocument zelf, en blijft de instelling behouden voor toekomstige openingen?

Nee. Fallback‑regels zijn instellingen voor rendering tijdens runtime in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

### Heeft het besturingssysteem (Windows/Linux/macOS) en de verzameling lettertype‑mappen invloed op de fallback‑selectie?

Ja. De engine zoekt lettertypen op in beschikbare systeemfolders en alle [additional paths](/slides/nl/net/custom-font/) die u opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst geen effect hebben.

### Werkt fallback voor WordArt, SmartArt en diagrammen?

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme gebruikt om ontbrekende tekens weer te geven.