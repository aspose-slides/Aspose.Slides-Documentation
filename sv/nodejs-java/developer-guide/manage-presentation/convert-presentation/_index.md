---
title: Konvertera presentationer till flera format i JavaScript
linktitle: Konvertera presentation
type: docs
weight: 70
url: /sv/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan läsa PowerPoint‑ och OpenDocument‑presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fast layout‑dokument såsom PDF och XPS, publicera bilder som HTML, eller rendera bilder som bildfiler för förhandsvisningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma generella arbetsflöde: ladda källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan länkar till implementeringsdetaljerna för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta JavaScript‑exempel och format‑specifika alternativ.

| Scenario | Använd den när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Convert PPT to PPTX](/slides/sv/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/sv/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/sv/nodejs-java/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint‑presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Convert PPTX to PPT](/slides/sv/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara, fast layout‑dokument för delning, utskrift eller arkivering. | [Convert PowerPoint to PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talar‑anteckningar tillsammans med bildinnehåll. | [Convert PowerPoint to PDF with Notes](/slides/sv/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och styr bilder, teckensnitt, anteckningar samt responsiva layout‑alternativ. | [Convert PowerPoint to HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Convert Presentations to HTML5](/slides/sv/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑fil för förhandsvisningar, miniatyrer eller webboutput. | [Convert PowerPoint to PNG](/slides/sv/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑filer och styr bilddimensioner och kvalitet. | [Convert PowerPoint to JPG](/slides/sv/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektorgrafik (SVG). | [Render Slide as SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generera XPS‑dokument med fast layout. | [Convert PowerPoint to XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Convert PowerPoint to TIFF](/slides/sv/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talar‑anteckningar till TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/sv/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och text‑baserade arbetsflöden. | [Convert PowerPoint to Markdown](/slides/sv/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Convert PowerPoint to Animated GIF](/slides/sv/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bygg ett videoexport‑arbetsflöde från presentationsbilder. | [Convert PowerPoint to Video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för JavaScript‑ eller Java‑UI‑scenarier. | [Export Presentations to XAML](/slides/sv/nodejs-java/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Supporterade filformat](/slides/sv/nodejs-java/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides för Node.js via Java stödjer konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑applikationer inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd de alternativ som beskrivs i [Convert OpenDocument Presentations](/slides/sv/nodejs-java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för Node.js via Java stödjer hög‑kvalitativ PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer såsom master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Convert PPT to PPTX](/slides/sv/nodejs-java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/nodejs-java/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på olika enheter och inte ska redigeras som en presentation. De dedikerade artiklarna för PDF, XPS och TIFF förklarar hur man styr efterlevnad, dolda bilder, anteckningar, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för visning i webbläsare, webbpublicering och lättviktig delning. Bildexport är praktisk när varje bild ska bli en separat förhandsvisning, miniatyr eller raster‑resurs. Använd artiklarna för PNG, JPG och SVG för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för Node.js via Java är ett fristående bibliotek och kräver varken Microsoft PowerPoint eller Office‑automatisering.

**Kan jag konvertera många presentationer i batch?**

Ja. Ladda varje presentation, spara den till önskat format och frisläpp presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ [multithreading](/slides/sv/nodejs-java/multithreading/)‑vägledningen.

**Kan jag exportera endast utvalda bilder?**

Ja. Flera exportmetoder låter dig ange bild‑index eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i artiklarna för [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) och [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/).

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga för PDF‑export. Se [Convert PowerPoint to PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt vid konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, teckensnittsfallback och teckensnitts‑utbytesinställningar. Se [Embedded Font](/slides/sv/nodejs-java/embedded-font/), [Fallback Font](/slides/sv/nodejs-java/fallback-font/) och [Font Substitution](/slides/sv/nodejs-java/font-substitution/).