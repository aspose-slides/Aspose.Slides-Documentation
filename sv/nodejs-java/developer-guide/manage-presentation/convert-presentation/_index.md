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
description: "Konvertera PowerPoint‑ och OpenDocument‑presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides for Node.js via Java kan läsa PowerPoint‑ och OpenDocument‑presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fasta layout‑dokument såsom PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar följer samma allmänna arbetsflöde: ladda källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementeringsdetaljer för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta JavaScript‑exempel och format‑specifika alternativ.

| Scenario | Använd när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP till PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/nodejs-java/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/nodejs-java/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/nodejs-java/save-presentation/) |
| PPTX till PPT | Spara en modern PowerPoint‑presentation i det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP till PDF | Skapa portabla, sökbara, fasta layout‑dokument för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP till PDF med anteckningar | Exportera talarnoter tillsammans med bildinnehållet. | [Konvertera PowerPoint till PDF med anteckningar](/slides/sv/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP till HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, typsnitt, anteckningar och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP till HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarat format och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP till PNG | Rendera varje bild till en PNG‑bild för förhandsgranskningar, miniatyrer eller webboutput. | [Konvertera PowerPoint till PNG](/slides/sv/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP till JPG | Rendera bilder till JPG‑filer och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/nodejs-java/convert-powerpoint-to-jpg/) |
| Bild till SVG | Exportera enskilda bilder som skalbara vektorgrafikfiler. | [Rendera bild som SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP till XPS | Generera fasta layout‑XPS‑dokument. | [Konvertera PowerPoint till XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP till TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP till TIFF med anteckningar | Spara bilder med talarnoter till TIFF. | [Konvertera PowerPoint till TIFF med anteckningar](/slides/sv/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX till Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och text‑baserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP till XML | Skapa en text‑baserad PowerPoint‑XML‑presentation för inspektion, jämförelse, felsökning eller XML‑baserade arbetsflöden. | [Konvertera PowerPoint till XML](/slides/sv/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX till animerad GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX till video | Bygg ett video‑exportarbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) |
| Presentation till XAML | Exportera bilder till XAML för JavaScript‑ eller Java‑UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/nodejs-java/export-to-xaml/) |

För en mer omfattande lista över in‑ och utdataformat, se [Stödda filformat](/slides/sv/nodejs-java/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides for Node.js via Java stöder konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara byta indatafil.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion exakt på samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska utdata och använd alternativen som beskrivs i [Konvertera OpenDocument‑presentationer](/slides/sv/nodejs-java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT till PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides for Node.js via Java stödjer hög‑fidelity‑konvertering från PPT till PPTX samtidigt som komplexa presentationsstrukturer såsom master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/nodejs-java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/nodejs-java/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur du styr efterlevnad, dolda bilder, anteckningar, bildkvalitet, komprimering, pixelformat och utdata‑storlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är praktiska för webbläsarvisning, webbpublicering och lättviktig delning. Bildexport är användbart när varje bild ska bli en separat förhandsgranskning, miniatyr eller raster‑resurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides for Node.js via Java är ett fristående bibliotek och kräver varken Microsoft PowerPoint eller Office‑automatisering.

**Kan jag konvertera många presentationer i batch?**

Ja. Ladda varje presentation, spara den till det önskade formatet och frigör presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ [multitrådning](/slides/sv/nodejs-java/multithreading/)‑anvisningarna.

**Kan jag exportera endast valda bilder?**

Ja. Flera export‑metoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) och [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/)‑konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar är tillgängliga för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras typsnitt under konvertering?**

Aspose.Slides kan använda inbäddade typsnitt, reservtypsnitt och typsnittsersättningsinställningar. Se [Inbäddat typsnitt](/slides/sv/nodejs-java/embedded-font/), [Reservtypsnitt](/slides/sv/nodejs-java/fallback-font/) och [Typsnittsersättning](/slides/sv/nodejs-java/font-substitution/).