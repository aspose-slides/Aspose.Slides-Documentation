---
title: Konvertera presentationer till flera format i .NET
linktitle: Konvertera presentation
type: docs
weight: 70
url: /sv/net/convert-presentation/
keywords:
- konvertera presentation
- exportera presentation
- PPT till PPTX
- PPTX till PPT
- ODP till PPTX
- PPT till PDF
- PPTX till PDF
- ODP till PDF
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- PPT till PNG
- PPTX till PNG
- ODP till PNG
- PPTX till JPG
- ODP till JPG
- PPT till XPS
- PPTX till XPS
- ODP till XPS
- PPT till TIFF
- PPTX till TIFF
- ODP till TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint‑ och OpenDocument‑presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET kan läsa PowerPoint‑ och OpenDocument‑presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fast layout‑dokument såsom PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma generella arbetsflöde: läs in källfilen, välj önskat utdataformat och ange format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementationsdetaljer för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta C#‑exempel och format‑specifika alternativ.

| Scenario | Använd det när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Convert PPT to PPTX](/slides/sv/net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/sv/net/convert-odp-to-pptx/),[Save Presentations](/slides/sv/net/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint‑presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Convert PPTX to PPT](/slides/sv/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara, fast layout‑dokument för delning, utskrift eller arkivering. | [Convert PowerPoint to PDF](/slides/sv/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talarnoter tillsammans med bildinnehållet. | [Convert PowerPoint to PDF with Notes](/slides/sv/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, teckensnitt, anteckningar och responsiva layoutalternativ. | [Convert PowerPoint to HTML](/slides/sv/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Convert Presentations to HTML5](/slides/sv/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑fil för förhandsgranskningar, miniatyrer eller webboutput. | [Convert PowerPoint to PNG](/slides/sv/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑filer och kontrollera bildstorlek och kvalitet. | [Convert PowerPoint to JPG](/slides/sv/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektor‑grafikfiler. | [Render Slide as SVG](/slides/sv/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Skapa fast layout‑XPS‑dokument. | [Convert PowerPoint to XPS](/slides/sv/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Convert PowerPoint to TIFF](/slides/sv/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talarnoter till TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/sv/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konvertera bilder till ett Word‑dokument när du behöver dokument‑stil utdata. | [Convert PowerPoint to Word](/slides/sv/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och text‑baserade arbetsflöden. | [Convert PowerPoint to Markdown](/slides/sv/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Skapa en text‑baserad PowerPoint XML‑presentation för granskning, jämförelse, felsökning eller XML‑baserade arbetsflöden. | [Convert PowerPoint to XML](/slides/sv/net/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Convert PowerPoint to Animated GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bygg ett videokonverteringsflöde från presentationsbilder. | [Convert PowerPoint to Video](/slides/sv/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för .NET‑UI‑scenarier. | [Export Presentations to XAML](/slides/sv/net/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Supported File Formats](/slides/sv/net/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides for .NET stöder konvertering från vanliga presentationsformat som PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara byta indatafil.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑applikationer inte stödjer varje layout‑ och formateringsfunktion exakt på samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd alternativen beskrivna i [Convert OpenDocument Presentations](/slides/sv/net/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides for .NET stöder hög‑fidelity PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer såsom master‑bilder, layouter, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Convert PPT to PPTX](/slides/sv/net/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/net/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadan ut på alla enheter och inte ska redigeras som en presentation. Använd [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/xpsoptions/) och [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/) för att kontrollera efterlevnad, dolda bilder, anteckningar, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för webbläsarvisning, webbpublicering och lättviktiga delningar. Bildexport är användbart när varje bild måste bli en separat förhandsgranskning, miniatyr eller raster‑resurs. Använd artiklarna för PNG, JPG och SVG för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides for .NET är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automatisering.

**Kan jag konvertera många presentationer i batch?**

Ja. Läs in varje presentation, spara den till önskat format och frigör `Presentation`‑objektet efter bearbetning. För parallell bearbetning, använd separata presentationsinstanser och följ [multithreading](/slides/sv/net/multithreading/)‑vägledningen.

**Kan jag exportera endast utvalda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd egenskapen `ShowHiddenSlides` i [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) eller [XpsOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/xpsoptions/).

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns via [PdfOptions.Compliance](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/compliance/) och [PdfCompliance](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfcompliance/).

**Hur hanteras teckensnitt vid konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, teckensnittsfallback och teckensnittssubstitution. Se [Embedded Font](/slides/sv/net/embedded-font/),[Fallback Font](/slides/sv/net/fallback-font/),[Font Substitution](/slides/sv/net/font-substitution/).