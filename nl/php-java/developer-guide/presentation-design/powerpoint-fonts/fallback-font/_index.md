---
title: Beheer fallback-lettertypen voor presentaties in PHP
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/php-java/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyphvervanging
- lettertype specificeren
- regel specificeren
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Zie hoe Aspose.Slides voor PHP fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallback-lettertypen worden gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar niet de benodigde glyfe bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback-lettertypen gebruiken om de ontbrekende glyfe te vervangen.

## **Fallback-lettertype**
Een fallback-lettertype wordt gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar dit lettertype bevat niet de benodigde glyfe. In dat geval kan een van de opgegeven fallback-lettertypen worden gebruikt voor de vervanging van de glyfe.

Aspose.Slides maakt het mogelijk om fallback-lettertypen te maken, ze toe te voegen aan de fallback-lettertypencollectie, de fallback-lettertypencollectie voor een bepaalde presentatie in te stellen, fallback-lettertypen uit een presentatie te verwijderen, de regels te specificeren voor het toepassen van fallback-lettertypen en meer.

Om vertrouwd te raken met deze functionaliteiten, gebruik de volgende links:

- [Maak fallback-lettertype](/slides/nl/php-java/create-fallback-font)
- [Maak fallback-lettertypencollectie](/slides/nl/php-java/create-fallback-fonts-collection)
- [Presentatie renderen met fallback-lettertype](/slides/nl/php-java/render-presentation-with-fallback-font)

## **FAQ**

**Hoe verschillen fallback-lettertypen van lettertype-substitutie?**

Fallback wordt per teken of per Unicode-bereik toegepast wanneer het primaire lettertype bepaalde glyphs mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/php-java/font-substitution/) vervangt een ontbrekend of niet beschikbaar lettertype voor een volledige reeks of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectie‑logica verschillen.

**Worden fallback-instellingen opgeslagen in het presentatiedocument?**

Nee. De fallback‑configuratie bestaat alleen tijdens het verwerken/renderen in de bibliotheek en wordt niet geserialiseerd naar de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die door PowerPoint‑objecten (SmartArt, grafieken, WordArt) zijn gemaakt?**

Ja. Tekst in deze objecten doorloopt dezelfde renderpipeline, waardoor dezelfde fallback‑regels van toepassing zijn op deze tekst als op gewone tekst.