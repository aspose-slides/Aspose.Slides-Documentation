---
title: Konvertera presentationer till flera format på Android
linktitle: Konvertera presentation
type: docs
weight: 70
url: /sv/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java kan läsa PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fasta layout‑dokument som PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsvisningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma generella arbetsflöde: läs in källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementationsdetaljer för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta Java‑exempel och format‑specifika alternativ.

| Scenario | Använd den när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/androidjava/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/androidjava/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/androidjava/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint‑presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara, fast‑layout‑dokument för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talarnoter tillsammans med bildinnehållet. | [Konvertera PowerPoint till PDF med noter](/slides/sv/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, typsnitt, noter och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑bild för förhandsvisningar, miniatyrer eller webboutput. | [Konvertera PowerPoint till PNG](/slides/sv/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bilder till JPG‑filer och kontrollera bildens dimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektorgrafik. | [Rendera bild som SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Skapa fasta layout‑XPS‑dokument. | [Konvertera PowerPoint till XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, scanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talarnoter till TIFF. | [Konvertera PowerPoint till TIFF med noter](/slides/sv/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konvertera bilder till ett Word‑dokument när du behöver dokument‑lik output. | [Konvertera PowerPoint till Word](/slides/sv/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och text‑baserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bygg ett videokonverteringsarbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för Android‑ eller Java‑UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/androidjava/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Stödda filformat](/slides/sv/androidjava/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides för Android via Java stöder konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF vanligtvis kan tillämpas på en ODP‑fil genom att bara ändra indatasfilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd de alternativ som beskrivs i [Konvertera OpenDocument‑presentationer](/slides/sv/androidjava/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för Android via Java stöder högkvalitativ PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer som master‑bilder, layouter, slides, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/androidjava/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/androidjava/ppt-vs-pptx/).

## **Export av fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. De dedikerade artiklarna för PDF, XPS och TIFF förklarar hur man styr efterlevnad, dolda bilder, noter, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för visning i webbläsare, webbpublicering och lättviktig delning. Bildexport är praktisk när varje bild måste bli en separat förhandsvisning, miniatyr eller raster‑resurs. Använd artiklarna för PNG, JPG och SVG för format‑specifik renderingsvägledning.

## **FAQ**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för Android via Java är ett fristående bibliotek och kräver varken Microsoft PowerPoint eller Office‑automation.

**Kan jag batch‑konvertera många presentationer?**

Ja. Läs in varje presentation, spara den i önskat format och frigör presentationsobjektet efter bearbetning. För parallell bearbetning, använd separata presentationsinstanser och följ [multithreading](/slides/sv/androidjava/multithreading/)‑vägledningen.

**Kan jag exportera endast valda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/) och [XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/) konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt under konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, teckensnitt som reserv och teckensnittssubstitutionsinställningar. Se [Inbäddat teckensnitt](/slides/sv/androidjava/embedded-font/), [Reservteckensnitt](/slides/sv/androidjava/fallback-font/), och [Teckensnittssubstitution](/slides/sv/androidjava/font-substitution/).