---
title: Beheer fallback-lettertypen voor presentaties in Python
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/python-net/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyph-vervanging
- lettertype opgeven
- regel opgeven
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Zie hoe Aspose.Slides voor Python via .NET fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallback-lettertypen worden gebruikt wanneer het voor tekst opgegeven lettertype wel op het systeem aanwezig is, maar niet het vereiste glyph bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback-lettertypen gebruiken om het ontbrekende glyph te vervangen.

## **Fallback-lettertype**

Aspose.Slides maakt het mogelijk om fallback-lettertypen te maken, ze toe te voegen aan de collectie van fallback-lettertypen, een fallback-lettertypecollectie in te stellen voor een bepaalde presentatie, fallback-lettertypen uit een presentatie te verwijderen, de regels op te geven die van toepassing zijn op fallback-lettertypen en meer.

Om vertrouwd te raken met deze functionaliteiten, gebruik de volgende links:

- [Maak fallback-lettertype](/slides/nl/python-net/create-fallback-font)
- [Maak collectie van fallback-lettertypen](/slides/nl/python-net/create-fallback-fonts-collection)
- [Renderen van presentatie met fallback-lettertype](/slides/nl/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Hoe verschillen fallback-lettertypen van lettertypevervanging?**

Fallback wordt toegepast per teken of per bereik van Unicode wanneer het primaire lettertype specifieke glyphs mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/python-net/font-substitution/) vervangt een ontbrekend of onbeschikbaar lettertype voor een volledige run of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun reikwijdte en selectielogica verschillen.

**Worden fallback-instellingen opgeslagen in het presentatiebestand?**

Nee. De fallback-configuratie bestaat alleen tijdens verwerking/renderen in de bibliotheek en wordt niet geserialiseerd naar het PPTX‑bestand. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die zijn aangemaakt door PowerPoint‑objecten (SmartArt, diagrammen, WordArt)?**

Ja. Tekst in deze objecten doorloopt dezelfde renderingspipeline, zodat dezelfde fallback‑regels van toepassing zijn op die tekst als op gewone tekst.