---
title: Beheer fallback-lettertypen voor presentaties in C++
linktitle: Fallback-lettertype
type: docs
weight: 50
url: /nl/cpp/fallback-font/
keywords:
- fallback-lettertype
- beschikbaar lettertype
- tekenvervanging
- lettertype specificeren
- regel specificeren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides voor C++ fallback-lettertypen gebruikt om tekst leesbaar te houden in PowerPoint- en OpenDocument-presentaties wanneer de oorspronkelijke lettertypen niet beschikbaar zijn."
---
## **Inleiding**

Fallback-lettertypen worden gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar niet het vereiste teken bevat. In dat geval kan Aspose.Slides een van de opgegeven fallback-lettertypen gebruiken om het ontbrekende teken te vervangen.

## **Fallback-lettertype**
Een fallback-lettertype wordt gebruikt wanneer het opgegeven lettertype voor tekst beschikbaar is in het systeem, maar dit lettertype niet over een noodzakelijk teken beschikt. In dat geval kan een van de opgegeven fallback-lettertypen worden gebruikt voor de vervanging van het teken.

Met Aspose.Slides kunt u fallback-lettertypen maken, ze toevoegen aan een verzameling fallback-lettertypen, een fallback-lettertypeverzameling instellen voor een bepaalde presentatie, fallback-lettertypen uit een presentatie verwijderen, de regels specificeren die van toepassing zijn op fallback-lettertypen en meer.

Om vertrouwd te raken met deze functionaliteiten, kunt u de volgende links gebruiken:

- [Maak fallback-lettertype](/slides/nl/cpp/create-fallback-font)
- [Collectie van fallback-lettertypen maken](/slides/nl/cpp/create-fallback-fonts-collection)
- [Presentatie renderen met fallback-lettertype](/slides/nl/cpp/render-presentation-with-fallback-font)

## **Veelgestelde vragen**

**Hoe verschillen fallback-lettertypen van lettertypevervanging?**

Fallback wordt per teken of per Unicode‑bereik toegepast wanneer het primaire lettertype bepaalde tekens niet bevat; het vult alleen de ontbrekende tekens aan. [Vervanging](/slides/nl/cpp/font-substitution/) vervangt een ontbrekend of niet‑beschikbaar lettertype voor een volledige tekenreeks of tekstgedeelte door een ander lettertype. Ze kunnen gecombineerd worden, maar hun bereik en selectielogica verschillen.

**Worden fallback-instellingen opgeslagen in het presentatie‑bestand?**

Nee. De fallback‑configuratie bestaat alleen tijdens het verwerken/renderen in de bibliotheek en wordt niet geserialiseerd in de PPTX. De presentatie slaat uw fallback‑regels niet op.

**Heeft fallback invloed op elementen die zijn aangemaakt door PowerPoint‑objecten (SmartArt, grafieken, WordArt)?**

Ja. Tekst binnen deze objecten doorloopt dezelfde render‑pipeline, waardoor dezelfde fallback‑regels van toepassing zijn op die tekst als op gewone tekst.