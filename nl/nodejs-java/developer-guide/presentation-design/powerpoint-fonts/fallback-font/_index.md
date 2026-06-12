---
title: Beheer fallback-lettertypen voor presentaties in JavaScript
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/nodejs-java/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyphvervanging
- lettertype opgeven
- regel opgeven
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Zie hoe Aspose.Slides voor Node.js fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Inleiding**

Fallback-lettertypen worden gebruikt wanneer het voor tekst opgegeven lettertype wel beschikbaar is in het systeem, maar niet het vereiste glyph bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback-lettertypen gebruiken om het ontbrekende glyph te vervangen.

## **Fallback-lettertype**

Aspose.Slides maakt het mogelijk om fallback-lettertypen te creëren, ze toe te voegen aan de collectie van fallback-lettertypen, een fallback-lettertypecollectie in te stellen voor een bepaalde presentatie, fallback-lettertypen uit een presentatie te verwijderen, de regels te specificeren voor het toepassen van fallback-lettertypen en meer.

Om vertrouwd te raken met deze functionaliteit, gebruik de volgende links:

- [Fallback-lettertype maken](/slides/nl/nodejs-java/create-fallback-font)
- [Collectie van fallback-lettertypen maken](/slides/nl/nodejs-java/create-fallback-fonts-collection)
- [Presentatie renderen met fallback-lettertype](/slides/nl/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Hoe verschillen fallback-lettertypen van fontvervanging?**

Fallback wordt per teken of per Unicode-bereik toegepast wanneer het primaire lettertype specifieke glyphs mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/nodejs-java/font-substitution/) vervangt een ontbrekend of niet beschikbaar lettertype voor een volledige tekstreeks of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectielogica zijn verschillend.

**Worden fallback-instellingen opgeslagen in het presentatie‑bestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens verwerking/rendering in de bibliotheek en wordt niet geserialiseerd naar de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die door PowerPoint‑objecten (SmartArt, grafieken, WordArt) zijn gemaakt?**

Ja. Tekst binnen deze objecten doorloopt dezelfde renderpipeline, zodat dezelfde fallback‑regels van toepassing zijn op die tekst als op gewone tekst.