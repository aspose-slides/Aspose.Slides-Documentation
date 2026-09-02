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

Aspose.Slides for PHP via Java kan läsa PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT‑filer till moderna PPTX, exportera presentationer till fast‑layout‑dokument som PDF och XPS, publicera bilder som HTML, eller rendera bilder som bildfiler för förhandsgranskningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar följer samma allmänna arbetsflöde: läs in källfilen, välj önskat utdataformat och tillämpa format‑specifika alternativ när det behövs. För bildformat renderas varje bild separat och sparas sedan som raster‑ eller vektorbild. De dedikerade artiklarna nedan ger implementationsdetaljer för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta PHP‑exempel och format‑specifika alternativ.

| Scenario | Använd när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP till PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument‑presentationer till PowerPoint PPTX. | [Convert PPT to PPTX](/slides/sv/php-java/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/sv/php-java/convert-odp-to-pptx/),[Save Presentations](/slides/sv/php-java/save-presentation/) |
| PPTX till PPT | Spara en modern PowerPoint-presentation till det äldre binära PPT-formatet för kompatibilitet med äldre arbetsflöden. | [Convert PPTX to PPT](/slides/sv/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP till PDF | Skapa portabla, sökbara, fast layout-dokument för delning, utskrift eller arkivering. | [Convert PowerPoint to PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP till PDF med anteckningar | Exportera föreläsaranteckningar tillsammans med bildinnehållet. | [Convert PowerPoint to PDF with Notes](/slides/sv/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP till HTML | Publicera presentationer som HTML-sidor och styra bilder, teckensnitt, anteckningar och responsiva layoutalternativ. | [Convert PowerPoint to HTML](/slides/sv/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP till HTML5 | Exportera bilder till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Convert Presentations to HTML5](/slides/sv/php-java/export-to-html5/) |
| PPT/PPTX/ODP till PNG | Rendera varje bild till en PNG-bild för förhandsgranskningar, miniatyrer eller webboutput. | [Convert PowerPoint to PNG](/slides/sv/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP till JPG | Rendera bilder till JPG-bilder och styra bildens dimensioner och kvalitet. | [Convert PowerPoint to JPG](/slides/sv/php-java/convert-powerpoint-to-jpg/) |
| Bild till SVG | Exportera enskilda bilder som skalbara vektorgrafik. | [Render Slide as SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP till XPS | Generera XPS-dokument med fast layout. | [Convert PowerPoint to XPS](/slides/sv/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP till TIFF | Spara en presentation som en flersidig TIFF-fil för utskrift, skanning, fax eller arkiveringsarbetsflöden. | [Convert PowerPoint to TIFF](/slides/sv/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP till TIFF med anteckningar | Spara bilder med föreläsaranteckningar till TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/sv/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX till Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och textbaserade arbetsflöden. | [Convert PowerPoint to Markdown](/slides/sv/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP till XML | Skapa en textbaserad PowerPoint XML-presentation för inspektion, jämförelse, felsökning eller XML-baserade arbetsflöden. | [Convert PowerPoint to XML](/slides/sv/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX till animerad GIF | Skapa en animerad GIF från bilder. | [Convert PowerPoint to Animated GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX till video | Bygg ett videoexportarbetsflöde från presentationsbilder. | [Convert PowerPoint to Video](/slides/sv/php-java/convert-powerpoint-to-video/) |
| Presentation till XAML | Exportera bilder till XAML för PHP- eller Java UI-scenarier. | [Export Presentations to XAML](/slides/sv/php-java/export-to-xaml/) |

För en bredare lista över in- och utdataformat, se [Supported File Formats](/slides/sv/php-java/supported-file-formats/).

## **PowerPoint- och OpenDocument-konvertering**

Aspose.Slides for PHP via Java stöder konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. Samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att endast ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd de alternativ som beskrivs i [Convert OpenDocument Presentations](/slides/sv/php-java/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT till PPTX-konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides for PHP via Java stöder högkvalitativ PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer som master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Convert PPT to PPTX](/slides/sv/php-java/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/php-java/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när resultatet ska se likadant ut på olika enheter och inte bör redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur man styr efterlevnad, dolda bilder, anteckningar, bildkvalitet, komprimering, pixelformat och utskriftsstorlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för visning i webbläsare, webbpublicering och lättviktigt delande. Bildexport är praktisk när varje bild ska bli en separat förhandsgranskning, miniatyr eller rasterresurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides for PHP via Java är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automation.

**Kan jag batch‑konvertera många presentationer?**

Ja. Ladda varje presentation, spara den till det önskade formatet och frigör presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ vägledningen för [multithreading](/slides/sv/php-java/multithreading/).

**Kan jag exportera endast valda bilder?**

Ja. Flera exportmetoder låter dig ange bild‑index eller rendera enskilda bilder, beroende på utdataformatet. Se den dedikerade artikeln för det aktuella formatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) och [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/) konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns tillgängliga för PDF‑export. Se [Convert PowerPoint to PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras teckensnitt vid konvertering?**

Aspose.Slides kan använda inbäddade teckensnitt, teckensnittsfallback och teckensnittssubstitutionsinställningar. Se [Embedded Font](/slides/sv/php-java/embedded-font/), [Fallback Font](/slides/sv/php-java/fallback-font/) och [Font Substitution](/slides/sv/php-java/font-substitution/).