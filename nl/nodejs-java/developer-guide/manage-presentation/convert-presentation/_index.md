---
title: Converteer presentaties naar meerdere formaten in JavaScript
linktitle: Converteer presentatie
type: docs
weight: 70
url: /nl/nodejs-java/convert-presentation/
keywords:
- converteer presentatie
- exporteer presentatie
- PPT naar PPTX
- PPTX naar PPT
- ODP naar PPTX
- PPT naar PDF
- PPTX naar PDF
- ODP naar PDF
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- PPT naar PNG
- PPTX naar PNG
- ODP naar PNG
- PPTX naar JPG
- ODP naar JPG
- PPT naar XPS
- PPTX naar XPS
- ODP naar XPS
- PPT naar TIFF
- PPTX naar TIFF
- ODP naar TIFF
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument‑presentaties naar PPTX, PDF, HTML, afbeeldingen, XPS, TIFF en meer met Aspose.Slides for Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan PowerPoint- en OpenDocument‑presentaties laden en opslaan of renderen naar tal van andere formaten zonder Microsoft PowerPoint, OpenOffice of LibreOffice. U kunt verouderde PPT‑bestanden omzetten naar moderne PPTX, presentaties exporteren naar vaste‑layout‑documenten zoals PDF en XPS, dia’s publiceren als HTML, of dia’s renderen als afbeeldingsbestanden voor voorbeeldweergaven, miniaturen en archieven.

De meeste documentconversies volgen dezelfde algemene workflow: laad het bronbestand, kies het gewenste uitvoerformaat en pas indien nodig formaat‑specifieke opties toe. Voor afbeeldingsformaten wordt elke dia afzonderlijk gerenderd en vervolgens opgeslagen als raster‑ of vectorafbeelding. De toegeschreven artikelen hieronder geven de implementatiedetails voor elk geval.

## **Kies een conversiescenario**

Gebruik de onderstaande artikelen voor volledige JavaScript‑voorbeelden en formaat‑specifieke opties.

| Scenario | Gebruik het wanneer u nodig heeft | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniseer verouderde PPT‑bestanden, normaliseer bestaande PPTX‑bestanden, of zet OpenDocument‑presentaties om naar PowerPoint PPTX. | [Convert PPT to PPTX](/slides/nl/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/nl/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/nl/nodejs-java/save-presentation/) |
| PPTX to PPT | Sla een moderne PowerPoint‑presentatie op in het oudere binaire PPT‑formaat voor compatibiliteit met oudere workflows. | [Convert PPTX to PPT](/slides/nl/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Maak draagbare, doorzoekbare, vaste‑layout‑documenten voor delen, afdrukken of archiveren. | [Convert PowerPoint to PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporteer spreker‑notities samen met de dia‑inhoud. | [Convert PowerPoint to PDF with Notes](/slides/nl/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publiceer presentaties als HTML‑pagina’s en beheer afbeeldingen, lettertypen, notities en responsieve lay‑outopties. | [Convert PowerPoint to HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporteer dia’s naar HTML5 voor weergave in de browser met behoud van opmaak en interactiviteit. | [Convert Presentations to HTML5](/slides/nl/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Render elke dia naar een PNG‑afbeelding voor voorbeeldweergaven, miniaturen of weboutput. | [Convert PowerPoint to PNG](/slides/nl/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Render dia’s naar JPG‑afbeeldingen en beheer afbeeldingsafmetingen en -kwaliteit. | [Convert PowerPoint to JPG](/slides/nl/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporteer individuele dia’s als schaalbare vectorafbeeldingen (SVG). | [Render Slide as SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Genereer vaste‑layout XPS‑documenten. | [Convert PowerPoint to XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Sla een presentatie op als een meer‑pagina‑TIFF‑bestand voor afdrukken, scannen, faxen of archiveringsprocessen. | [Convert PowerPoint to TIFF](/slides/nl/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Sla dia’s met spreker‑notities op als TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/nl/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extraheer presentatiewaarde naar Markdown voor documentatie en tekst‑gebaseerde workflows. | [Convert PowerPoint to Markdown](/slides/nl/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Maak een geanimeerde GIF van dia’s. | [Convert PowerPoint to Animated GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Stel een video‑export‑workflow samen vanuit presentatie‑dia’s. | [Convert PowerPoint to Video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporteer dia’s naar XAML voor JavaScript‑ of Java‑UI‑scenario’s. | [Export Presentations to XAML](/slides/nl/nodejs-java/export-to-xaml/) |

Voor een uitgebreider overzicht van invoer‑ en uitvoerformaten, zie [Supported File Formats](/slides/nl/nodejs-java/supported-file-formats/).

## **PowerPoint‑ en OpenDocument‑conversie**

Aspose.Slides for Node.js via Java ondersteunt conversie van veelgebruikte presentatieformaten zoals PPT, PPTX, PPS, PPSX, POT, POTX en ODP. Dezelfde conversie‑API wordt gebruikt voor PowerPoint‑ en OpenDocument‑bestanden, zodat een workflow die een PPTX‑bestand naar PDF opslaat meestal ook toegepast kan worden op een ODP‑bestand door alleen het invoerbestand te wijzigen. Bij het converteren van ODP‑bestanden moet u onthouden dat PowerPoint‑ en OpenDocument‑toepassingen niet elke lay‑out‑ en opmaak‑functie op exact dezelfde manier ondersteunen. Als een ODP‑bestand is aangemaakt in LibreOffice of OpenOffice Impress, controleer dan de output en gebruik de opties die beschreven staan in [Convert OpenDocument Presentations](/slides/nl/nodejs-java/convert-openoffice-odp/) wanneer u format‑specifieke begeleiding nodig hebt.

## **PPT‑naar‑PPTX‑conversie**

PPT is het oudere binaire PowerPoint‑formaat, terwijl PPTX het moderne Office Open XML‑formaat is. Aspose.Slides for Node.js via Java ondersteunt een nauwkeurige PPT‑naar‑PPTX‑conversie met behoud van complexe presentatiestructuren zoals masters, lay‑outs, dia’s, grafieken, gegroepeerde vormen, plaatsaanduidingen, tekstkaders, texturen en beeld‑vullingen. Voor details, zie [Convert PPT to PPTX](/slides/nl/nodejs-java/convert-ppt-to-pptx/) en [PPT vs PPTX](/slides/nl/nodejs-java/ppt-vs-pptx/).

## **Export met vaste lay‑out**

PDF, XPS en TIFF zijn handig wanneer de output er op alle apparaten hetzelfde moet uitzien en niet bewerkt mag worden als een presentatie. De specifieke PDF‑, XPS‑ en TIFF‑artikelen leggen uit hoe u naleving, verborgen dia’s, notities, afbeeldingskwaliteit, compressie, pixel‑formaat en uitvoergrootte kunt beheersen.

## **HTML‑ en afbeeldingsexport**

HTML‑ en HTML5‑export zijn nuttig voor weergave in de browser, webpublicatie en lichtgewicht delen. Afbeeldingsexport is handig wanneer elke dia moet worden omgezet naar een aparte voorbeeldweergave, miniatuur of raster‑asset. Raadpleeg de PNG‑, JPG‑ en SVG‑artikelen voor formaat‑specifieke renderingsrichtlijnen.

## **FAQ**

**Heb ik Microsoft PowerPoint nodig om presentaties te converteren?**

Nee. Aspose.Slides for Node.js via Java is een zelfstandige bibliotheek en vereist geen Microsoft PowerPoint of Office‑automatisering.

**Kan ik veel presentaties in batch converteren?**

Ja. Laad elke presentatie, sla deze op in het gewenste formaat en maak het presentatie‑object vrij na verwerking. Voor parallelle verwerking kunt u afzonderlijke presentatie‑instanties gebruiken en de richtlijnen in [multithreading](/slides/nl/nodejs-java/multithreading/) volgen.

**Kan ik alleen geselecteerde dia’s exporteren?**

Ja. Diverse exportmethoden laten u dia‑indexen doorgeven of individuele dia’s renderen, afhankelijk van het uitvoerformaat. Zie het specifieke artikel voor het gewenste formaat.

**Kan ik verborgen dia’s opnemen bij exporteren naar PDF of XPS?**

Ja. Gebruik de exportinstellingen voor verborgen dia’s die beschreven staan in de [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) en [XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/) conversie‑artikelen.

**Kan ik PDF/A‑output maken?**

Ja. PDF‑nalevingsinstellingen zijn beschikbaar voor PDF‑export. Zie [Convert PowerPoint to PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) voor details.

**Hoe worden lettertypen behandeld tijdens conversie?**

Aspose.Slides kan ingesloten lettertypen, font‑fallback en font‑substitutie‑instellingen gebruiken. Zie [Embedded Font](/slides/nl/nodejs-java/embedded-font/), [Fallback Font](/slides/nl/nodejs-java/fallback-font/) en [Font Substitution](/slides/nl/nodejs-java/font-substitution/).