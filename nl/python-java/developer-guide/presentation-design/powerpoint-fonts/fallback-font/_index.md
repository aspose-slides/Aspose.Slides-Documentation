---
title: Beheer fallback-lettertypen voor presentaties in Python via Java
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/python-java/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyfvervanging
- lettertype specificeren
- regel specificeren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides voor Python via Java fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallback-lettertypen worden gebruikt wanneer het voor de tekst opgegeven lettertype wel op het systeem aanwezig is, maar niet het vereiste glyf bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback-lettertypen gebruiken om het ontbrekende glyf te vervangen.

## **Fallback-lettertype**

Aspose.Slides stelt u in staat fallback-lettertypen aan te maken, ze toe te voegen aan een fallback-lettertypecollectie, de fallback-lettertypecollectie voor een bepaalde presentatie in te stellen, fallback-lettertypen uit de presentatie te verwijderen, de regels voor het toepassen van fallback-lettertypen op te geven, en andere verwante bewerkingen uit te voeren.

Om vertrouwd te raken met deze functies, gebruik de volgende koppelingen:

- [Maak fallback-lettertype](/slides/nl/python-java/create-fallback-font/)
- [Maak fallback-lettertypencollectie](/slides/nl/python-java/create-fallback-fonts-collection/)
- [Render presentatie met fallback-lettertype](/slides/nl/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Hoe verschillen fallback-lettertypen van lettertypevervanging?**

Fallback wordt per teken of per Unicode‑bereik toegepast wanneer het primaire lettertype specifieke glyfen mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/python-java/font-substitution/) vervangt een ontbrekend of onbeschikbaar lettertype voor een hele tekstloop of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun reikwijdte en selectie‑logica zijn verschillend.

**Worden fallback‑instellingen opgeslagen in het presentatie‑bestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens het verwerken/renderen in de bibliotheek en wordt niet geserialiseerd naar de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die door PowerPoint‑objecten (SmartArt, diagrammen, WordArt) zijn aangemaakt?**

Ja. Tekst binnen deze objecten doorloopt dezelfde render‑pipeline, dus dezelfde fallback‑regels worden erop toegepast als op gewone tekst.