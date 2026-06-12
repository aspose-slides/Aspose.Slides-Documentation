---
title: Presentaties converteren naar meerdere formaten in .NET
linktitle: Presentatie converteren
type: docs
weight: 70
url: /nl/net/convert-presentation/
keywords:
- presentatie converteren
- presentatie exporteren
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties naar PPTX, PDF, HTML, afbeeldingen, XPS, TIFF en meer met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides voor .NET kan PowerPoint- en OpenDocument-presentaties laden en opslaan of renderen naar talrijke andere formaten zonder Microsoft PowerPoint, OpenOffice of LibreOffice. Je kunt verouderde PPT‑bestanden converteren naar moderne PPTX, presentaties exporteren naar vaste‑layoutdocumenten zoals PDF en XPS, dia’s publiceren als HTML, of dia’s renderen als afbeeldingsbestanden voor voorbeeldweergaven, miniaturen en archieven.

De meeste documentconversies volgen dezelfde algemene werkwijze: laad het bronbestand, kies het gewenste uitvoerformaat en pas desgewenst formaat‑specifieke opties toe. Voor beeldformaten wordt elke dia afzonderlijk gerenderd en vervolgens opgeslagen als een raster‑ of vectorafbeelding. De hieronder gekoppelde artikelen bieden de implementatiedetails voor elk geval.

## **Kies een conversiescenario**

Gebruik de onderstaande artikelen voor volledige C#‑voorbeelden en formaat‑specifieke opties.

| Scenario | Gebruik het wanneer je | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniseer verouderde PPT‑bestanden, normaliseer bestaande PPTX‑bestanden, of converteer OpenDocument‑presentaties naar PowerPoint PPTX. | [Converteer PPT naar PPTX](/slides/nl/net/convert-ppt-to-pptx/), [Converteer ODP naar PPTX](/slides/nl/net/convert-odp-to-pptx/), [Presentaties opslaan](/slides/nl/net/save-presentation/) |
| PPTX to PPT | Bewaar een moderne PowerPoint‑presentatie in het oudere binaire PPT‑formaat voor compatibiliteit met oudere werkwijzen. | [Converteer PPTX naar PPT](/slides/nl/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Maak draagbare, doorzoekbare, vaste‑layoutdocumenten voor delen, afdrukken of archiveren. | [Converteer PowerPoint naar PDF](/slides/nl/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporteer spreker‑notities samen met de dia‑inhoud. | [Converteer PowerPoint naar PDF met notities](/slides/nl/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publiceer presentaties als HTML‑pagina’s en beheer afbeeldingen, lettertypen, notities en responsieve lay‑outopties. | [Converteer PowerPoint naar HTML](/slides/nl/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporteer dia’s naar HTML5 voor weergave in de browser met behoud van opmaak en interactiviteit. | [Converteer presentaties naar HTML5](/slides/nl/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Render elke dia naar een PNG‑afbeelding voor voorbeeldweergaven, miniaturen of weboutput. | [Converteer PowerPoint naar PNG](/slides/nl/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Render dia’s naar JPG‑afbeeldingen en beheer afmetingen en kwaliteit. | [Converteer PowerPoint naar JPG](/slides/nl/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporteer individuele dia’s als schaalbare vectorafbeeldingen. | [Render dia als SVG](/slides/nl/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Genereer vaste‑layout XPS‑documenten. | [Converteer PowerPoint naar XPS](/slides/nl/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Bewaar een presentatie als een meer‑pagina‑TIFF‑bestand voor afdrukken, scannen, faxen of archiveringsprocessen. | [Converteer PowerPoint naar TIFF](/slides/nl/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Bewaar dia’s met spreker‑notities als TIFF. | [Converteer PowerPoint naar TIFF met notities](/slides/nl/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Converteer dia’s naar een Word‑document wanneer je document‑stijl output nodig hebt. | [Converteer PowerPoint naar Word](/slides/nl/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Haal presentatiewaarde uit naar Markdown voor documentatie en tekstgebaseerde werkwijzen. | [Converteer PowerPoint naar Markdown](/slides/nl/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Maak een geanimeerde GIF van dia’s. | [Converteer PowerPoint naar geanimeerde GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Stel een video‑exportworkflow samen vanuit presentatiedia’s. | [Converteer PowerPoint naar video](/slides/nl/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporteer dia’s naar XAML voor .NET UI‑scenario’s. | [Exporteer presentaties naar XAML](/slides/nl/net/export-to-xaml/) |

Voor een uitgebreidere lijst van invoer‑ en uitvoerformaten, zie [Ondersteunde bestandsformaten](/slides/nl/net/supported-file-formats/).

## **PowerPoint- en OpenDocument-conversie**

Aspose.Slides voor .NET ondersteunt conversie van veelgebruikte presentatieformaten zoals PPT, PPTX, PPS, PPSX, POT, POTX en ODP. dezelfde conversie‑API wordt gebruikt voor PowerPoint‑ en OpenDocument‑bestanden, zodat een workflow die een PPTX‑bestand naar PDF opslaat meestal ook kan worden toegepast op een ODP‑bestand door alleen het invoerbestand te wijzigen.

Bij het converteren van ODP‑bestanden, onthoud dat PowerPoint‑ en OpenDocument‑toepassingen niet elke lay‑out‑ en opmaakfunctie op precies dezelfde manier ondersteunen. Als een ODP‑bestand is aangemaakt in LibreOffice of OpenOffice Impress, controleer dan de uitvoer en gebruik de opties beschreven in [Converteer OpenDocument‑presentaties](/slides/nl/net/convert-openoffice-odp/) wanneer je format‑specifieke begeleiding nodig hebt.

## **PPT‑naar‑PPTX-conversie**

PPT is het oudere binaire PowerPoint‑formaat, terwijl PPTX het moderne Office Open XML‑formaat is. Aspose.Slides voor .NET ondersteunt een nauwkeurige PPT‑naar‑PPTX‑conversie terwijl complexe presentatiestructuren worden behouden, zoals masters, lay‑outs, dia’s, diagrammen, gegroepeerde vormen, placeholders, tekstframes, texturen en afbeelding‑vullingen.

Voor details, zie [Converteer PPT naar PPTX](/slides/nl/net/convert-ppt-to-pptx/) en [PPT vs PPTX](/slides/nl/net/ppt-vs-pptx/).

## **Export van vaste‑layout**

PDF, XPS en TIFF zijn handig wanneer de uitvoer er op alle apparaten hetzelfde moet uitzien en niet bewerkt mag worden als een presentatie. Gebruik [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/), en [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/) om naleving, verborgen dia’s, notities, beeldkwaliteit, compressie, pixelindeling en uitvoergrootte te beheren.

## **HTML‑ en afbeelding‑export**

HTML‑ en HTML5‑export zijn nuttig voor weergave in de browser, webpublicatie en lichtgewicht delen. Afbeeldingsexport is handig wanneer elke dia een apart voorbeeld, miniatuur of raster‑asset moet worden. Gebruik de PNG, JPG en SVG‑artikelen voor format‑specifieke renderingsrichtlijnen.

## **FAQ**

**Heb ik Microsoft PowerPoint nodig om presentaties te converteren?**

Nee. Aspose.Slides voor .NET is een zelfstandige bibliotheek en vereist geen Microsoft PowerPoint of Office‑automatisering.

**Kan ik veel presentaties in batch omzetten?**

Ja. Laad elke presentatie, sla deze op in het gewenste format, en maak het `Presentation`‑object vrij na verwerking. Voor parallelle verwerking, gebruik afzonderlijke presentatie‑instances en volg de [multithreading](/slides/nl/net/multithreading/) richtlijnen.

**Kan ik alleen geselecteerde dia’s exporteren?**

Ja. Verschillende exportmethoden laten je dia‑indexes doorgeven of individuele dia’s renderen, afhankelijk van het uitvoerformaat. Zie het toegewijde artikel voor het doelformaat.

**Kan ik verborgen dia’s opnemen bij export naar PDF of XPS?**

Ja. Gebruik de eigenschap `ShowHiddenSlides` in [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) of [XpsOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/).

**Kan ik PDF/A‑output aanmaken?**

Ja. PDF‑nalevingsinstellingen zijn beschikbaar via [PdfOptions.Compliance](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/compliance/) en [PdfCompliance](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfcompliance/).

**Hoe worden lettertypen behandeld tijdens conversie?**

Aspose.Slides kan ingebedde lettertypen, fallback‑lettertypen en substitutie‑instellingen voor lettertypen gebruiken. Zie [Embedded Font](/slides/nl/net/embedded-font/), [Fallback Font](/slides/nl/net/fallback-font/), en [Font Substitution](/slides/nl/net/font-substitution/).