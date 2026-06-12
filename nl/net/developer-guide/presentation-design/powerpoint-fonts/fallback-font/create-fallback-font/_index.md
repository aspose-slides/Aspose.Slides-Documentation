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
- ontbrekende glyf
- juiste glyf
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer Aspose.Slides voor .NET om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de tekstweergave op elk apparaat of besturingssysteem consistent blijft."
---
## **Overzicht**

Aspose.Slides stelt u in staat om fallback‑lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan één of meer lettertypen die de vereiste glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑rendervoorinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de [IFontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/iFontFallBackRule) interface en de [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) klasse om de regels op te geven die een fallback‑lettertype toepassen. De [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) klasse vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, gebruikt voor het zoeken naar ontbrekende glyphs, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Met verschillende manieren kun je een lijst met lettertypen toevoegen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [Remove()](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontfallbackrule/methods/remove) of [AddFallBackFonts()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er behoefte is om fallback‑lettertype‑vervangingsregels op te geven voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="Zie ook" %}} 
- [Maak een collectie van fallback‑lettertypen](/slides/nl/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback‑lettertype, lettertype‑vervanging en lettertype‑insluiting?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertype‑vervanging](/slides/nl/net/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Lettertype‑insluiting](/slides/nl/net/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst kunnen bekijken zoals bedoeld.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering‑ en export‑operaties](/slides/nl/net/convert-presentation/) waarbij tekens moeten worden getekend maar afwezig zijn in het bronlettertype.

**Verandert het configureren van fallback het presentatiebestand zelf, en blijft de instelling behouden bij toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑rendervoorinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de fallback‑selectie?**

Ja. De engine zoekt lettertypen op in de beschikbare systeemmappen en in alle [extra paden](/slides/nl/net/custom-font/) die u opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die hiernaar verwijst niet effect hebben.

**Werkt fallback voor WordArt, SmartArt en grafieken?**

Ja. Wanneer deze objecten tekst bevatten, wordt dezelfde glyph‑substitutiemechanisme toegepast om ontbrekende tekens weer te geven.