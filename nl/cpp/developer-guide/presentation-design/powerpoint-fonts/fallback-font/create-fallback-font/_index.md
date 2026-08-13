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
description: "Beheer Aspose.Slides voor C++ om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat tekstconsistentie gegarandeerd is op elk apparaat of besturingssysteem."
---
## **Overzicht**

Aspose.Slides stelt u in staat om fallback‑lettertypen te specificeren voor het renderen en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderingsinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de interface [IFontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/) en de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) om de regels te specificeren die een fallback‑lettertype toepassen. De klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) vertegenwoordigt een koppeling tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om missende glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [Remove()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/remove/) of [AddFallBackFonts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrulescollection/) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/)‑objecten te organiseren wanneer er een behoefte is om fallback‑lettertypevervangingsregels voor meerdere Unicode‑bereiken te specificeren.

{{% alert color="info" title="Zie ook" %}} 
- [Maak fallback‑lettertype‑collectie](/slides/nl/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Wat is het verschil tussen een fallback‑lettertype, lettertype‑substitutie en lettertype‑insluiting?

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertype‑substitutie](/slides/nl/cpp/font-substitution/) vervangt het volledig gespecificeerde lettertype door een ander lettertype. [Lettertype‑insluiting](/slides/nl/cpp/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst kunnen zien zoals bedoeld.

### Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?

Ja. Fallback beïnvloedt alle [render‑ en exportbewerkingen](/slides/nl/cpp/convert-presentation/) waarbij tekens moeten worden getekend maar ontbreken in het bronlettertype.

### Wijzigt het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling behouden voor toekomstige openingen?

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

### Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de fallback‑selectie?

Ja. De engine zoekt lettertypen op in de beschikbare systeemmappen en alle [extra paden](/slides/nl/cpp/custom-font/) die u opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst niet van kracht worden.

### Werkt fallback voor WordArt, SmartArt en grafieken?

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiesysteem toegepast om missende tekens weer te geven.