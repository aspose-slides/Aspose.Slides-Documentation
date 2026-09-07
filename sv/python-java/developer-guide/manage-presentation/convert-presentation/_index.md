---
title: Konvertera presentationer till flera format i Python
linktitle: Konvertera presentation
type: docs
weight: 70
url: /sv/python-java/convert-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides för Python via Java kan läsa PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT-filer till moderna PPTX, exportera presentationer till fast layout‑dokument som PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsvisningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma generella arbetsflöde: ladda källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan länkar till implementationsdetaljerna för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta Python‑exempel och format‑specifika alternativ.

| Scenario | Använd den när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT-filer, normalisera befintliga PPTX-filer eller konvertera OpenDocument-presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/python-java/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/python-java/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/python-java/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint-presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara, fast layout‑dokument för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talarnoter tillsammans med bildinnehållet. | [Konvertera PowerPoint till PDF med noteringar](/slides/sv/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, typsnitt, noteringar och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/python-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑fil för förhandsvisningar, miniatyrer eller webboutput. | [Konvertera PowerPoint till PNG](/slides/sv/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑filer och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/python-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektorgrafikfiler. | [Rendera bild som SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generera fast layout‑XPS-dokument. | [Konvertera PowerPoint till XPS](/slides/sv/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talarnoter till TIFF. | [Konvertera PowerPoint till TIFF med noteringar](/slides/sv/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konvertera bilder till ett Word‑dokument när du behöver dokument‑stil utdata. | [Konvertera PowerPoint till Word](/slides/sv/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och text‑baserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Skapa en textbaserad PowerPoint XML‑presentation för inspektion, jämförelse, felsökning eller XML‑baserade arbetsflöden. | [Konvertera PowerPoint till XML](/slides/sv/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Skapa ett videoexport‑arbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/python-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för användning i WPF‑applikationer. | [Exportera presentationer till XAML](/slides/sv/python-java/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Stödda filformat](/slides/sv/python-java/supported-file-formats/).

## **PowerPoint- och OpenDocument‑konvertering**

Aspose.Slides för Python via Java stöder konvertering från vanliga presentationsformat som PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stöder varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska utdata och använd alternativen som beskrivs i [Konvertera OpenDocument-presentationer](/slides/sv/python-java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för Python via Java stöder hög‑fidelitetsk konvertering från PPT till PPTX samtidigt som komplexa presentationsstrukturer som master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För mer information, se [Konvertera PPT till PPTX](/slides/sv/python-java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/python-java/ppt-vs-pptx/).

## **Export av fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur man styr efterlevnad, dolda bilder, noteringar, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för webbläsarvisning, webbpublicering och lättviktig delning. Bildexport är användbar när varje bild måste bli en separat förhandsvisning, miniatyr eller raster‑resurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för Python via Java är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automation.

**Kan jag batch‑konvertera många presentationer?**

Ja. Läs in varje presentation, spara den till önskat format och frigör presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ [multithreading](/slides/sv/python-java/multithreading/)‑riktlinjerna.

**Kan jag exportera endast utvalda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/)‑ och [XPS](/slides/sv/python-java/convert-powerpoint-to-xps/)‑konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt under konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, reservteckensnitt och teckensnitts‑substitution. Se [Embedded Font](/slides/sv/python-java/embedded-font/), [Fallback Font](/slides/sv/python-java/fallback-font/) och [Font Substitution](/slides/sv/python-java/font-substitution/).