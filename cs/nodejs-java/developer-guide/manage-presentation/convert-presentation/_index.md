---
title: Převod prezentací do více formátů v JavaScriptu
linktitle: Převod prezentace
type: docs
weight: 70
url: /cs/nodejs-java/convert-presentation/
keywords:
- převod prezentace
- export prezentace
- PPT na PPTX
- PPTX na PPT
- ODP na PPTX
- PPT na PDF
- PPTX na PDF
- ODP na PDF
- PPT na HTML
- PPTX na HTML
- ODP na HTML
- PPT na PNG
- PPTX na PNG
- ODP na PNG
- PPTX na JPG
- ODP na JPG
- PPT na XPS
- PPTX na XPS
- ODP na XPS
- PPT na TIFF
- PPTX na TIFF
- ODP na TIFF
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument do formátů PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java může načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést starší soubory PPT na moderní PPTX, exportovat prezentace do dokumentů se stálým rozložením, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslit snímky jako obrazové soubory pro náhledy, miniatury a archivaci.

Většina převodů dokumentů používá stejný obecný postup: načíst zdrojový soubor, vybrat požadovaný výstupní formát a podle potřeby použít možnosti specifické pro formát. U obrazových formátů je každý snímek vykreslen samostatně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené články poskytují podrobnosti o implementaci pro jednotlivé případy.

## **Zvolte scénář převodu**

Použijte níže uvedené články pro kompletní příklady v JavaScriptu a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument na PowerPoint PPTX. | [Convert PPT to PPTX](/slides/cs/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/cs/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/cs/nodejs-java/save-presentation/) |
| PPTX to PPT | Uložit moderní PowerPoint prezentaci do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Convert PPTX to PPT](/slides/cs/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty se stálým rozložením pro sdílení, tisk nebo archivaci. | [Convert PowerPoint to PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky prezentujícího spolu s obsahem snímků. | [Convert PowerPoint to PDF with Notes](/slides/cs/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozložení. | [Convert PowerPoint to HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachováním formátování a interaktivity. | [Convert Presentations to HTML5](/slides/cs/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Vykreslit každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Convert PowerPoint to PNG](/slides/cs/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Convert PowerPoint to JPG](/slides/cs/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Render Slide as SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Vytvořit dokumenty XPS se stálým rozložením. | [Convert PowerPoint to XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivní pracovní postupy. | [Convert PowerPoint to TIFF](/slides/cs/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami prezentujícího do TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/cs/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Convert PowerPoint to Markdown](/slides/cs/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Convert PowerPoint to Animated GIF](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Vytvořit pracovní postup exportu videa ze snímků prezentace. | [Convert PowerPoint to Video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře JavaScript nebo Java UI. | [Export Presentations to XAML](/slides/cs/nodejs-java/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Supported File Formats](/slides/cs/nodejs-java/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides pro Node.js přes Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné API pro konverzi se používá pro soubory PowerPoint i OpenDocument, takže pracovní postup, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při konverzi souborů ODP si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují každé rozložení a formátovací funkce přesně stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Convert OpenDocument Presentations](/slides/cs/nodejs-java/convert-openoffice-odp/) když potřebujete specifické pokyny pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides pro Node.js přes Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou master snímky, rozložení, snímky, grafy, seskupené tvary, zástupné prvky, textová pole, textury a výplně obrázků.

Podrobnosti naleznete v [Convert PPT to PPTX](/slides/cs/nodejs-java/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/nodejs-java/ppt-vs-pptx/).

## **Export se stálým rozložením**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na různých zařízeních a neměl by být upravován jako prezentace. Samostatné články o PDF, XPS a TIFF vysvětlují, jak řídit soulad, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelů a velikost výstupu.

## **Export do HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když každý snímek musí být samostatný náhled, miniatura nebo rastrový asset. Použijte články o PNG, JPG a SVG pro pokyny specifické pro formát.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides pro Node.js přes Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentace a řiďte se pokyny pro [multithreading](/slides/cs/nodejs-java/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik metod exportu umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz samostatný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsané v článcích o [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF jsou k dispozici pro export do PDF. Viz [Convert PowerPoint to PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou písma při konverzi zpracovávána?**

Aspose.Slides může používat vložená písma, náhradní písma a nastavení substituce písem. Viz [Embedded Font](/slides/cs/nodejs-java/embedded-font/), [Fallback Font](/slides/cs/nodejs-java/fallback-font/) a [Font Substitution](/slides/cs/nodejs-java/font-substitution/).