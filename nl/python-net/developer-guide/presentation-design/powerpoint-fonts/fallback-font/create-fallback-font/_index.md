---
title: Specificeer fallback-lettertypen voor presentaties in Python
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Beheers Aspose.Slides voor Python via .NET om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, waardoor consistente tekstweergave op elk apparaat of besturingssysteem wordt gewaarborgd."
---
## **Overzicht**

Aspose.Slides stelt je in staat om fallback-lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback-lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan één of meer lettertypen die de vereiste glyphs kunnen bevatten. Je kunt regels definiëren voor verschillende tekenbereiken, fallback-lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Specificeer fallback-lettertypen**

Aspose.Slides ondersteunt de class [FontFallBackRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/FontFallBackRule/) om de regels op te geven die een fallback-lettertype toepassen. De class [FontFallBackRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/FontFallBackRule/) stelt een associatie voor tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om ontbrekende glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Meerdere manieren om een lijst met lettertypen toe te voegen:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Het is ook mogelijk om een fallback-lettertype te [verwijderen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrule/remove/) of [add_fall_back_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/FontFallBackRule/)‑object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrulescollection/) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/FontFallBackRule/)‑objecten te organiseren, wanneer er een behoefte is om fallback‑lettertype‑vervangingsregels op te geven voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="Zie ook" %}} 
- [Maak fallback-lettertypen-collectie](/slides/nl/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback-lettertype, lettertypevervanging en lettertype‑embedding?**

Een fallback-lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/python-net/font-substitution/) vervangt het volledig gespecificeerde lettertype door een ander lettertype. [Font embedding](/slides/nl/python-net/embedded-font/) verpakt de lettertypen in het output‑bestand zodat ontvangers de tekst zien zoals bedoeld.

**Worden fallback-lettertypen toegepast tijdens exports zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering and export operations](/slides/nl/python-net/convert-presentation/) waarbij tekens getekend moeten worden maar afwezig zijn in het bronlettertype.

**Wijzigt het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling behouden voor toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen in je code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de fallback‑selectie?**

Ja. De engine zoekt lettertypen op in de beschikbare systeemmappen en in eventuele [additional paths](/slides/nl/python-net/custom-font/) die je opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst geen effect hebben.

**Werkt fallback voor WordArt, SmartArt en diagrammen?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme toegepast om ontbrekende tekens weer te geven.