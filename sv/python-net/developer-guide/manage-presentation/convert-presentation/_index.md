---
title: Konvertera presentationer till flera format i Python
linktitle: Konvertera presentationer
type: docs
weight: 70
url: /sv/python-net/convert-presentation/
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
- Aspose.Slides
description: "Konvertera PowerPoint‑ och OpenDocument‑presentationer till PPTX, PDF, HTML, bilder, XPS, TIFF och mer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET kan läsa in PowerPoint- och OpenDocument-presentationer och spara eller rendera dem till många andra format utan Microsoft PowerPoint, OpenOffice eller LibreOffice. Du kan konvertera äldre PPT-filer till moderna PPTX, exportera presentationer till fast layout‑dokument såsom PDF och XPS, publicera bildspel som HTML eller rendera bildspel som bildfiler för förhandsvisningar, miniatyrer och arkiv.

De flesta dokumentkonverteringar använder samma generella arbetsflöde: läs in källfilen, välj önskat output‑format och tillämpa format‑specifika alternativ vid behov. För bildformat renderas varje bild separat och sparas sedan som en raster‑ eller vektorbild. De dedikerade artiklarna som länkas nedan ger implementationsdetaljerna för varje fall.

## **Välj ett konverteringsscenario**

Använd artiklarna nedan för kompletta Python‑exempel och format‑specifika alternativ.

| Scenario | Använd när du behöver | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisera äldre PPT‑filer, normalisera befintliga PPTX‑filer eller konvertera OpenDocument-presentationer till PowerPoint PPTX. | [Konvertera PPT till PPTX](/slides/sv/python-net/convert-ppt-to-pptx/), [Konvertera ODP till PPTX](/slides/sv/python-net/convert-odp-to-pptx/), [Spara presentationer](/slides/sv/python-net/save-presentation/) |
| PPTX to PPT | Spara en modern PowerPoint-presentation till det äldre binära PPT‑formatet för kompatibilitet med äldre arbetsflöden. | [Konvertera PPTX till PPT](/slides/sv/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Skapa portabla, sökbara dokument med fast layout för delning, utskrift eller arkivering. | [Konvertera PowerPoint till PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportera talarnoter tillsammans med bildinnehållet. | [Konvertera PowerPoint till PDF med noteringar](/slides/sv/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicera presentationer som HTML‑sidor och kontrollera bilder, typsnitt, noteringar och responsiva layoutalternativ. | [Konvertera PowerPoint till HTML](/slides/sv/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportera bildspel till HTML5 för webbläsarbaserad visning med bevarad formatering och interaktivitet. | [Exportera presentationer till HTML5](/slides/sv/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendera varje bild till en PNG‑bild för förhandsvisningar, miniatyrer eller webboutput. | [Konvertera PowerPoint till PNG](/slides/sv/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendera bildspel till JPG‑bilder och kontrollera bilddimensioner och kvalitet. | [Konvertera PowerPoint till JPG](/slides/sv/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportera enskilda bilder som skalbara vektor‑grafik. | [Rendera bild som SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Skapa XPS‑dokument med fast layout. | [Konvertera PowerPoint till XPS](/slides/sv/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Spara en presentation som en flersidig TIFF‑fil för utskrift, skanning, fax eller arkiveringsprocesser. | [Konvertera PowerPoint till TIFF](/slides/sv/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Spara bilder med talarnoter till TIFF. | [Konvertera PowerPoint till TIFF med noteringar](/slides/sv/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | Konvertera bilder till ett Word‑dokument när du behöver dokumentstil output. | [Konvertera PowerPoint till Word](/slides/sv/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | Extrahera presentationsinnehåll till Markdown för dokumentation och textbaserade arbetsflöden. | [Konvertera PowerPoint till Markdown](/slides/sv/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | Skapa en animerad GIF från bilder. | [Konvertera PowerPoint till animerad GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | Bygg ett videoutmatningsflöde från presentationsbilder. | [Konvertera PowerPoint till video](/slides/sv/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportera bilder till XAML för Python- eller .NET‑UI‑scenarier. | [Exportera presentationer till XAML](/slides/sv/python-net/export-to-xaml/) |

För en bredare lista över in‑ och utdataformat, se [Stödda filformat](/slides/sv/python-net/supported-file-formats/).

## **PowerPoint‑ och OpenDocument‑konvertering**

Aspose.Slides för Python via .NET stödjer konvertering från vanliga presentationsformat såsom PPT, PPTX, PPS, PPSX, POT, POTX och ODP. samma konverterings‑API används för PowerPoint‑ och OpenDocument‑filer, så ett arbetsflöde som sparar en PPTX‑fil till PDF kan vanligtvis tillämpas på en ODP‑fil genom att bara ändra indatafilen.

När du konverterar ODP‑filer, kom ihåg att PowerPoint‑ och OpenDocument‑program inte stödjer varje layout‑ och formateringsfunktion på exakt samma sätt. Om en ODP‑fil skapades i LibreOffice eller OpenOffice Impress, granska resultatet och använd de alternativ som beskrivs i [Konvertera OpenDocument‑presentationer](/slides/sv/python-net/convert-openoffice-odp/) när du behöver format‑specifik vägledning.

## **PPT‑till‑PPTX‑konvertering**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det moderna Office Open XML‑formatet. Aspose.Slides för Python via .NET stödjer högkvalitativ PPT‑till‑PPTX‑konvertering samtidigt som komplexa presentationsstrukturer som master‑bilder, layouter, bilder, diagram, grupperade former, platshållare, textramar, texturer och bildfyllningar bevaras.

För detaljer, se [Konvertera PPT till PPTX](/slides/sv/python-net/convert-ppt-to-pptx/) och [PPT vs PPTX](/slides/sv/python-net/ppt-vs-pptx/).

## **Export med fast layout**

PDF, XPS och TIFF är användbara när utdata ska se likadant ut på alla enheter och inte ska redigeras som en presentation. De dedikerade PDF‑, XPS‑ och TIFF‑artiklarna förklarar hur du styr efterlevnad, dolda bilder, noteringar, bildkvalitet, komprimering, pixelformat och utdata‑storlek.

## **HTML‑ och bildexport**

HTML‑ och HTML5‑export är användbara för visning i webbläsare, webbpublicering och lättviktig delning. Bildexport är användbar när varje bild ska bli en separat förhandsvisning, miniatyr eller raster‑resurs. Använd PNG‑, JPG‑ och SVG‑artiklarna för format‑specifik renderingsvägledning.

## **FAQ**

**Behöver jag Microsoft PowerPoint för att konvertera presentationer?**

Nej. Aspose.Slides för Python via .NET är ett fristående bibliotek och kräver inte Microsoft PowerPoint eller Office‑automatisering.

**Kan jag batch‑konvertera många presentationer?**

Ja. Läs in varje presentation, spara den till önskat format och frigör presentations‑objektet efter bearbetning. För parallell bearbetning, använd separata presentations‑instanser och följ [multitrådning](/slides/sv/python-net/multithreading/)‑vägledningen.

**Kan jag exportera endast valda bilder?**

Ja. Flera exportmetoder låter dig ange bildindex eller rendera enskilda bilder, beroende på utdataformat. Se den dedikerade artikeln för målformatet.

**Kan jag inkludera dolda bilder vid export till PDF eller XPS?**

Ja. Använd exportinställningarna för dolda bilder som beskrivs i [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/)‑ och [XPS](/slides/sv/python-net/convert-powerpoint-to-xps/)‑konverteringsartiklarna.

**Kan jag skapa PDF/A‑utdata?**

Ja. PDF‑efterlevnadsinställningar finns för PDF‑export. Se [Konvertera PowerPoint till PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) för detaljer.

**Hur hanteras typsnitt vid konvertering?**

Aspose.Slides kan använda inbäddade typsnitt, typsnitts‑fallback och typsnittssubstitutionsinställningar. Se [Inbäddat typsnitt](/slides/sv/python-net/embedded-font/), [Fallback‑typsnitt](/slides/sv/python-net/fallback-font/) och [Typsnittssubstitution](/slides/sv/python-net/font-substitution/).