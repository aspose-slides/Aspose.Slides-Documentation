---
title: Specificeer fallback-lettertypen voor presentaties in Python via Java
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/python-java/create-fallback-font/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype toepassen
- lettertype vervangen
- Unicode-bereik
- ontbrekende glyph
- correcte glyph
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheers Aspose.Slides voor Python via Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, waardoor consistente weergave van tekst op elk apparaat of besturingssysteem wordt gegarandeerd."
---
## **Overzicht**

Aspose.Slides stelt je in staat om fallback‑lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan één of meer lettertypen die de benodigde glyphs kunnen bevatten. Je kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderingsinstellingen. Ze wijzigen het presentatiedocument zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides biedt de [FontFallBackRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/)‑klasse om regels op te geven voor het toepassen van fallback‑lettertypen. Deze klasse vertegenwoordigt een associatie tussen een Unicode‑bereik dat wordt gebruikt om ontbrekende glyphs te zoeken en een lijst van lettertypen die de vereiste glyphs kunnen bevatten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Gebruik verschillende manieren om een lijst van lettertypen te specificeren.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Je kunt ook een fallback‑lettertype verwijderen met [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/#remove) of fallback‑lettertypen toevoegen met [addFallBackFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) in een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/)-object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrulescollection/) kan een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/)-objecten organiseren wanneer je fallback‑lettertype‑vervangingsregels moet opgeven voor meerdere Unicode‑bereiken.

{{% alert color="info" title="Zie ook" %}} 
- [Maak fallback-lettertypecollectie](/slides/nl/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback‑lettertype, lettertype‑substitutie en lettertype‑insluiting?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Lettertype‑insluiting](/slides/nl/python-java/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst zoals bedoeld kunnen bekijken.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering en exportoperaties](/slides/nl/python-java/convert-presentation/) waarbij tekens moeten worden getekend maar niet aanwezig zijn in het bronlettertype.

**Verandert het configureren van fallback het presentatiedocument zelf, en blijft de instelling behouden voor toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen in je code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Heeft het besturingssysteem (Windows/Linux/macOS) en de verzameling lettertype‑folders invloed op de fallback‑selectie?**

Ja. De engine zoekt lettertypen op in de beschikbare systeembestanden en eventuele [extra paden](/slides/nl/python-java/custom-font/) die je opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst niet effect hebben.

**Werkt fallback voor WordArt, SmartArt en grafieken?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme toegepast om ontbrekende tekens weer te geven.