---
title: Beheer fallback-lettertypen voor presentaties in .NET
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/net/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyphvervanging
- lettertype specificeren
- regel specificeren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Zie hoe Aspose.Slides voor .NET fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallbacklettertypen worden gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar niet de vereiste glyph bevat. In dat geval kan Aspose.Slides een van de opgegeven fallbacklettertypen gebruiken om de ontbrekende glyph te vervangen.

## **Fallback-lettertype**

Aspose.Slides stelt u in staat om fallbacklettertypen te maken, ze toe te voegen aan de collectie van fallbacklettertypen, een collectie fallbacklettertypen in te stellen voor een bepaalde presentatie, fallbacklettertypen uit een presentatie te verwijderen, de regels te specificeren om fallbacklettertypen toe te passen en meer.

Om vertrouwd te raken met deze functionaliteiten, gebruik de volgende links:
- [Fallback-lettertype maken](/slides/nl/net/create-fallback-font)
- [Collectie van fallback-lettertypen maken](/slides/nl/net/create-fallback-fonts-collection)
- [Presentatie renderen met fallback-lettertype](/slides/nl/net/render-presentation-with-fallback-font)

## **FAQ**

**Hoe verschillen fallback-lettertypen van lettertypevervanging?**

Fallback wordt toegepast per teken of per Unicode-bereik wanneer het primaire lettertype specifieke glyphs mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/net/font-substitution/) vervangt een ontbrekend of onbeschikbaar lettertype voor een volledige reeks of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectie-logica zijn verschillend.

**Worden fallback-instellingen opgeslagen in het presentatiedocument?**

Nee. De fallback-configuratie bestaat alleen tijdens de verwerking/rendering in de bibliotheek en wordt niet geserialiseerd in de PPTX. De presentatie slaat uw fallback-regels niet op.

**Heeft fallback invloed op elementen die gemaakt zijn door PowerPoint-objecten (SmartArt, diagrammen, WordArt)?**

Ja. Tekst binnen deze objecten doorloopt dezelfde render-pipeline, zodat dezelfde fallback-regels van toepassing zijn op die tekst als op gewone tekst.