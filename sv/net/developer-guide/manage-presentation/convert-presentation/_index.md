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
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET kan läsa in PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT-filer till moderna PPTX, exportera presentationer till fast layout‑dokument såsom PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma allmänna arbetsflöde: läs in källfilen, välj önskat utdataformat och applicera format‑specifika alternativ när det behövs. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementationsdetaljer för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta C#‑exempel och format‑specifika alternativ.

| Scenario | Använd när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/net/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/net/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/net/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint-presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara, fast layout‑dokument för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talarnoter tillsammans med bildinnehåll. | [Konvertera PowerPoint till PDF med noter](/slides/sv/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, teckensnitt, noter och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑bild för förhandsgranskningar, miniatyrer eller webbutdata. | [Konvertera PowerPoint till PNG](/slides/sv/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑bilder och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektorgrafik. | [Rendera bild som SVG](/slides/sv/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generera fast layout‑XPS‑dokument. | [Konvertera PowerPoint till XPS](/slides/sv/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talarnoter till TIFF. | [Konvertera PowerPoint till TIFF med noter](/slides/sv/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konvertera bilder till ett Word‑dokument när du behöver dokumentformat. | [Konvertera PowerPoint till Word](/slides/sv/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och textbaserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bygg ett videoexportarbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för .NET‑UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/net/export-to-xaml/) |

För en mer omfattande lista över in- och utdataformat, se [Stödda filformat](/slides/sv/net/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides for .NET stöder konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd de alternativ som beskrivs i [Konvertera OpenDocument‑presentationer](/slides/sv/net/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides for .NET stödjer högprecision PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer såsom master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/net/convert-ppt-to-pptx/) och [PPT mot PPTX](/slides/sv/net/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. Använd [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/xpsoptions/) och [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/) för att kontrollera efterlevnad, dolda bilder, noter, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för webbläsarvisning, webbpublicering och lättviktig delning. Bildexport är användbar när varje bild måste bli en separat förhandsgranskning, miniatyr eller raster‑resurs. Använd PNG-, JPG- och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **FAQ**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides for .NET är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automation.

**Kan jag batchkonvertera många presentationer?**

Ja. Läs in varje presentation, spara den i önskat format och disponera `Presentation`‑objektet efter bearbetning. För parallell bearbetning, använd separata presentationsinstanser och följ [multitrådning](/slides/sv/net/multithreading/)‑guiden.

**Kan jag bara exportera utvalda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder när jag exporterar till PDF eller XPS?**

Ja. Använd `ShowHiddenSlides`‑egenskapen i [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) eller [XpsOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/xpsoptions/).

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga via [PdfOptions.Compliance](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/compliance/) och [PdfCompliance](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfcompliance/).

**Hur hanteras teckensnitt under konverteringen?**

Aspose.Slides kan använda inbäddade teckensnitt, reservteckensnitt och teckensnittssubstitutionsinställningar. Se [Inbäddat teckensnitt](/slides/sv/net/embedded-font/), [Reservteckensnitt](/slides/sv/net/fallback-font/), och [Teckensnittssubstitution](/slides/sv/net/font-substitution/).