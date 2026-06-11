---
title: Konvertera presentationer till flera format i PHP
linktitle: Konvertera presentation
type: docs
weight: 70
url: /sv/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java kan läsa in PowerPoint- och OpenDocument‑presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fasta layout‑dokument såsom PDF och XPS, publicera bilder som HTML eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrbilder och arkiv.

De flesta dokumentkonverteringar använder samma allmänna arbetsflöde: läs in källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna som länkas nedan ger implementationsdetaljerna för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta PHP‑exempel och format‑specifika alternativ.

| Scenario | Använd den när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP till PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer, eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/php-java/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/php-java/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/php-java/save-presentation/) |
| PPTX till PPT | Spara en modern PowerPoint‑presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP till PDF | Skapa bärbara, sökbara dokument med fast layout för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP till PDF med noteringar | Exportera talarnoteringar tillsammans med bildinnehållet. | [Konvertera PowerPoint till PDF med noteringar](/slides/sv/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP till HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, teckensnitt, noteringar och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP till HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Konvertera presentationer till HTML5](/slides/sv/php-java/export-to-html5/) |
| PPT/PPTX/ODP till PNG | Rendera varje bild till en PNG‑bild för förhandsgranskningar, miniatyrer eller webboutput. | [Konvertera PowerPoint till PNG](/slides/sv/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP till JPG | Rendera bilder till JPG‑bilder och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/php-java/convert-powerpoint-to-jpg/) |
| Bild till SVG | Exportera enskilda bilder som skalbara vektorgrafik. | [Rendera bild som SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP till XPS | Skapa XPS‑dokument med fast layout. | [Konvertera PowerPoint till XPS](/slides/sv/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP till TIFF | Spara en presentation som en fler‑sidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Konvertera PowerPoint till TIFF](/slides/sv/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP till TIFF med noteringar | Spara bilder med talarnoteringar till TIFF. | [Konvertera PowerPoint till TIFF med noteringar](/slides/sv/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX till Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och textbaserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX till animerad GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX till video | Bygg ett videoexport‑arbetsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/php-java/convert-powerpoint-to-video/) |
| Presentation till XAML | Exportera bilder till XAML för PHP‑ eller Java‑UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/php-java/export-to-xaml/) |

För en mer omfattande lista över in‑ och utdataformat, se [Understödda filformat](/slides/sv/php-java/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides för PHP via Java stödjer konvertering från vanligt använda presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd alternativen som beskrivs i [Konvertera OpenDocument‑presentationer](/slides/sv/php-java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för PHP via Java stödjer högkvalitativ PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer såsom master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/php-java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/php-java/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när resultatet ska se likadant ut på olika enheter och inte ska redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur man styr efterlevnad, dolda bilder, noteringar, bildkvalitet, komprimering, pixelformat och utdata‑storlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för visning i webbläsare, webbpublicering och lätt delning. Bildexport är praktisk när varje bild måste bli en separat förhandsgranskning, miniatyr eller raster‑resurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **FAQ**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för PHP via Java är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automatisering.

**Kan jag konvertera många presentationer batchvis?**

Ja. Läs in varje presentation, spara den till önskat format och disponera presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ [multithreading](/slides/sv/php-java/multithreading/)-vägledningen.

**Kan jag exportera endast utvalda bilder?**

Ja. Flera exportmetoder låter dig ange bild‑index eller rendera enskilda bilder, beroende på utdataformatet. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/)‑ och [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/)‑konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. Inställningar för PDF‑efterlevnad finns för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt vid konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, fallback‑teckensnitt och teckensnittssubstitutionsinställningar. Se [Inbäddade teckensnitt](/slides/sv/php-java/embedded-font/), [Fallback Font](/slides/sv/php-java/fallback-font/), och [Font Substitution](/slides/sv/php-java/font-substitution/).