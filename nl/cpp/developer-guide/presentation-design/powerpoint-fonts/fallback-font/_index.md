---
title: Beheer fallback-lettertypen voor presentaties in С++
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/cpp/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- glyfvervanging
- lettertype opgeven
- regel opgeven
- PowerPoint
- OpenDocument
- presentatie
- С++
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides voor С++ fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Introductie**

Fallback-lettertypen worden gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem maar geen vereist glyf bevat. In dit geval kan Aspose.Slides een van de gespecificeerde fallback-lettertypen gebruiken om het ontbrekende glyf te vervangen.

## **Fallback-lettertype**
Een fallback-lettertype wordt gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar dit lettertype geen noodzakelijk glyf bevat. In dit geval kan een van de gespecificeerde fallback-lettertypen worden gebruikt voor de vervanging van het glyf.

Aspose.Slides maakt het mogelijk om fallback-lettertypen te maken, ze toe te voegen aan de collectie van fallback-lettertypen, een fallback-lettertypecollectie in te stellen voor een bepaalde presentatie, fallback-lettertypen uit een presentatie te verwijderen, de regels te specificeren voor het toepassen van fallback-lettertypen en meer.

Om vertrouwd te raken met deze functies, gebruik de volgende links:

- [Maak fallback-lettertype](/slides/nl/cpp/create-fallback-font)
- [Maak collectie van fallback-lettertypen](/slides/nl/cpp/create-fallback-fonts-collection)
- [Render presentatie met fallback-lettertype](/slides/nl/cpp/render-presentation-with-fallback-font)

## **Veelgestelde vragen**

**Hoe verschillen fallback-lettertypen van lettertypevervanging?**

Fallback wordt toegepast per teken of per Unicode‑bereik wanneer het primaire lettertype specifieke glyfen mist; het vult alleen de ontbrekende tekens aan. [Substitutie](/slides/nl/cpp/font-substitution/) vervangt een ontbrekend of niet‑beschikbaar lettertype voor een volledige reeks of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectielogica zijn verschillend.

**Worden fallback‑instellingen opgeslagen in het presentatie‑bestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens het verwerken/renderen in de bibliotheek en wordt niet geserialiseerd in de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die zijn gemaakt door PowerPoint‑objecten (SmartArt, grafieken, WordArt)?**

Ja. Tekst binnen deze objecten doorloopt dezelfde render‑pipeline, waardoor dezelfde fallback‑regels van toepassing zijn op deze tekst als op gewone tekst.