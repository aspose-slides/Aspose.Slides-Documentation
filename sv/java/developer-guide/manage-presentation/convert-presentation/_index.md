---
title: "Konvertera presentationer till flera format i Java"
linktitle: "Konvertera presentation"
type: docs
weight: 70
url: /sv/java/convert-presentation/
keywords:
- "konvertera presentation"
- "exportera presentation"
- "PPT till PPTX"
- "PPTX till PPT"
- "ODP till PPTX"
- "PPT till PDF"
- "PPTX till PDF"
- "ODP till PDF"
- "PPT till HTML"
- "PPTX till HTML"
- "ODP till HTML"
- "PPT till PNG"
- "PPTX till PNG"
- "ODP till PNG"
- "PPTX till JPG"
- "ODP till JPG"
- "PPT till XPS"
- "PPTX till XPS"
- "ODP till XPS"
- "PPT till TIFF"
- "PPTX till TIFF"
- "ODP till TIFF"
- "PowerPoint"
- "OpenDocument"
- "Java"
- "Aspose.Slides"
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides för Java kan läsa in PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT-filer till moderna PPTX, exportera presentationer till fasta layoutdokument som PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma allmänna arbetsflöde: läs in källfilen, välj önskat utdataformat och använd format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementationsdetaljer för varje scenario.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta Java‑exempel och format‑specifika alternativ.

| Scenario | Använd den när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT-filer, normalisera befintliga PPTX-filer eller konvertera OpenDocument-presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/java/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/java/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/java/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint-presentation till det äldre binära PPT-formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa bärbara, sökbara dokument med fast layout för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talaranteckningar tillsammans med bildinnehåll. | [Konvertera PowerPoint till PDF med anteckningar](/slides/sv/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, teckensnitt, anteckningar och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑bild för förhandsgranskningar, miniatyrer eller webbutmatning. | [Konvertera PowerPoint till PNG](/slides/sv/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑filer och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera individuella bilder som skalbara vektorgrafik. | [Rendera bild som SVG](/slides/sv/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Skapa XPS‑dokument med fast layout. | [Konvertera PowerPoint till XPS](/slides/sv/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talaranteckningar till TIFF. | [Konvertera PowerPoint till TIFF med anteckningar](/slides/sv/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konvertera bilder till ett Word‑dokument när du behöver dokumentstilutdata. | [Konvertera PowerPoint till Word](/slides/sv/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och textbaserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bygg ett videoutexportarbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för Java UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/java/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Filformat som stöds](/slides/sv/java/supported-file-formats/).

## **PowerPoint- och OpenDocument‑konvertering**

Aspose.Slides för Java stödjer konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara byta indatafil.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska utdata och använd de alternativ som beskrivs i [Convert OpenDocument Presentations](/slides/sv/java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT till PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för Java stödjer hög‑fidelitets‑konvertering från PPT till PPTX samtidigt som komplexa presentationsstrukturer såsom mastrar, layouter, bilder, diagram, gruppera former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/java/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur du styr efterlevnad, dolda bilder, anteckningar, bildkvalitet, komprimering, pixelformat och utdata‑storlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för webbläsarvisning, webbpublicering och lättviktig delning. Bildexport är användbart när varje bild måste bli en separat förhandsgranskning, miniatyr eller raster‑resurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för Java är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automatisering.

**Kan jag konvertera många presentationer i batch?**

Ja. Läs in varje presentation, spara den i önskat format och frigör presentationsobjektet efter bearbetning. För parallell bearbetning, använd separata presentationsinstanser och följ [multitrådad](/slides/sv/java/multithreading/)‑guiden.

**Kan jag exportera endast valda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera individuella bilder, beroende på utdataformatet. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/java/convert-powerpoint-to-pdf/) och [XPS](/slides/sv/java/convert-powerpoint-to-xps/)‑konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt under konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, reservteckensnitt och teckensnittsbytesinställningar. Se [Inbäddat teckensnitt](/slides/sv/java/embedded-font/), [Reservteckensnitt](/slides/sv/java/fallback-font/) och [Teckensnittsbyte](/slides/sv/java/font-substitution/).