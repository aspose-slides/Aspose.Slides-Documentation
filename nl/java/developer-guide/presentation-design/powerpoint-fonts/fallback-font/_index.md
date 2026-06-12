---
title: Beheer fallback-lettertypen voor presentaties in Java
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/java/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyfvervanging
- lettertype specificeren
- regel specificeren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides voor Java fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer originele lettertypen niet beschikbaar zijn."
---
## **Inleiding**

Fallback‑lettertypen worden gebruikt wanneer het opgegeven lettertype voor tekst aanwezig is in het systeem, maar niet de vereiste glyf bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback‑lettertypen gebruiken om de ontbrekende glyf te vervangen.

## **Fallback‑lettertype**

Aspose.Slides maakt het mogelijk om fallback‑lettertypen te maken, ze toe te voegen aan de collectie van fallback‑lettertypen, een fallback‑lettertypecollectie in te stellen voor een bepaalde presentatie, fallback‑lettertypen uit een presentatie te verwijderen, de regels voor het toepassen van fallback‑lettertypen op te geven en meer.

Om vertrouwd te raken met deze functies, gebruik de volgende links:

- [Maak fallback‑lettertype](/slides/nl/java/create-fallback-font)
- [Maak collectie van fallback‑lettertypen](/slides/nl/java/create-fallback-fonts-collection)
- [Render de presentatie met een fallback‑lettertype](/slides/nl/java/render-presentation-with-fallback-font)

## **Veelgestelde vragen**

**Hoe verschillen fallback‑lettertypen van lettertype‑substitutie?**

Fallback wordt toegepast per teken of per bereik van Unicode wanneer het primaire lettertype specifieke glyphs mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/java/font-substitution/) vervangt een ontbrekend of onbeschikbaar lettertype voor een volledige run of tekstdelen door een ander lettertype. Ze kunnen gecombineerd worden, maar hun reikwijdte en selectie‑logica zijn verschillend.

**Worden fallback‑instellingen opgeslagen in het presentatie‑bestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens het verwerken/renderen in de bibliotheek en wordt niet geserialiseerd naar de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die zijn gemaakt door PowerPoint‑objecten (SmartArt, grafieken, WordArt)?**

Ja. Tekst binnen deze objecten doorloopt dezelfde render‑pipeline, zodat dezelfde fallback‑regels op deze tekst worden toegepast als op gewone tekst.