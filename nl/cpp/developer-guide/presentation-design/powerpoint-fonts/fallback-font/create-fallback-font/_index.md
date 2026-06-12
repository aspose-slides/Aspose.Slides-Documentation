---
title: Specificeer fallback-lettertypen voor presentaties in C++
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "Beheers Aspose.Slides voor C++ om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat tekst consistent wordt weergegeven op elk apparaat of elk OS."
---
## **Overzicht**

Aspose.Slides stelt u in staat fallback‑lettertypen op te geven voor het weergeven en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderingsinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de [IFontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/) interface en [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) klasse om de regels op te geven die een fallback‑lettertype moeten toepassen. De [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) klasse vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, gebruikt voor het zoeken naar missende glyphs, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Met verschillende methoden kun je een lijst met lettertypen toevoegen:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Het is ook mogelijk om [Remove()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/remove/) fallback‑lettertype te verwijderen of [AddFallBackFonts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) toe te voegen aan een bestaande [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrulescollection/) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) objecten te organiseren, wanneer er behoefte is aan het opgeven van fallback‑lettertype‑vervangingsregels voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="Zie ook" %}} 
- [Maak fallback‑lettertype‑collectie](/slides/nl/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback‑lettertype, lettertype‑vervanging en lettertype‑inbedding?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertype‑vervanging](/slides/nl/cpp/font-substitution/) vervangt het opgegeven lettertype volledig door een ander lettertype. [Lettertype‑inbedding](/slides/nl/cpp/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst kunnen bekijken zoals bedoeld.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering en exportbewerkingen](/slides/nl/cpp/convert-presentation/) waar tekens moeten worden getekend maar afwezig zijn in het bronlettertype.

**Wijzigt het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling behouden bij toekomstige geopende bestanden?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Beïnvloedt het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen de keuze van fallback?**

Ja. De engine zoekt lettertypen in beschikbare systeemmappen en eventuele [extra paden](/slides/nl/cpp/custom-font/) die u opgeeft. Als een lettertype fysiek niet beschikbaar is, kan een regel die hiernaar verwijst geen effect hebben.

**Werkt fallback voor WordArt, SmartArt en grafieken?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑vervangingsmechanisme toegepast om missende tekens weer te geven.