---
title: Beheer fallback-lettertypen voor presentaties op Android
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/androidjava/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyphvervanging
- lettertype opgeven
- regel opgeven
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Zie hoe Aspose.Slides voor Android via Java fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallback‑lettertype wordt gebruikt wanneer het opgegeven lettertype voor tekst aanwezig is in het systeem, maar dit lettertype niet het benodigde teken bevat. In dat geval is het mogelijk om een van de opgegeven fallback‑lettertypen te gebruiken voor de vervanging van het teken.

## **Reservelettertype**

Aspose.Slides maakt het mogelijk om fallback‑lettertypen aan te maken, toe te voegen aan een collectie van fallback‑lettertypen, een fallback‑lettertypecollectie in te stellen voor een bepaalde presentatie, fallback‑lettertypen uit een presentatie te verwijderen, de regels te specificeren die op fallback‑lettertypen worden toegepast en meer.

Om vertrouwd te raken met deze functies, gebruik de volgende links:

- [Reservelettertype maken](/slides/nl/androidjava/create-fallback-font)
- [Collectie van reservelettertypen maken](/slides/nl/androidjava/create-fallback-fonts-collection)
- [Presentatie renderen met reservelettertype](/slides/nl/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**Hoe verschillen fallback‑lettertypen van lettertypevervanging?**

Fallback wordt per teken of per Unicode‑bereik toegepast wanneer het primaire lettertype specifieke tekens mist; het vult alleen de ontbrekende tekens aan. [Vervanging](/slides/nl/androidjava/font-substitution/) vervangt een ontbrekend of onbeschikbaar lettertype voor een hele run of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectielogica zijn verschillend.

**Worden fallback‑instellingen opgeslagen in het presentatiebestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens de verwerking/rendering in de bibliotheek en wordt niet geserialiseerd naar de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die door PowerPoint‑objecten (SmartArt, grafieken, WordArt) zijn aangemaakt?**

Ja. Tekst binnen deze objecten gaat door dezelfde renderpijplijn, dus dezelfde fallback‑regels zijn van toepassing op die tekst als op gewone tekst.