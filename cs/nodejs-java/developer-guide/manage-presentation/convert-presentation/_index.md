---
title: Převést prezentace do více formátů v JavaScriptu
linktitle: Převést prezentaci
type: docs
weight: 70
url: /cs/nodejs-java/convert-presentation/
keywords:
- převést prezentaci
- exportovat prezentaci
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
description: "Převádějte prezentace PowerPoint a OpenDocument do PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java dokáže načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice ani LibreOffice. Můžete převést starší soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou stránkou, jako jsou PDF a XPS, publikovat snímky jako HTML, nebo vykreslit snímky jako obrázkové soubory pro náhledy, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít možnosti specifické pro formát. Pro formáty obrázků se každý snímek vykreslí samostatně a poté uloží jako rastrový nebo vektorový obrázek. Vyhrazené články uvedené níže poskytují podrobnosti o implementaci pro každý případ.

## **Zvolte scénář konverze**

Použijte níže uvedené články pro kompletní příklady JavaScriptu a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizujte staré soubory PPT, normalizujte existující soubory PPTX nebo převádějte prezentace OpenDocument na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/nodejs-java/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/nodejs-java/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/nodejs-java/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převést PPTX na PPT](/slides/cs/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou stránkou pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky přednášejícího společně s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a ovládat obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Převést prezentace na HTML5](/slides/cs/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Vykreslit každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Vykreslit snímky do JPG obrázků a ovládat rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelnou vektorovou grafiku. | [Vykreslit snímek jako SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Vytvářet dokumenty XPS s pevnou stránkou. | [Převést PowerPoint na XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako více stránkový TIFF soubor pro tisk, skenování, fax nebo archivní procesy. | [Převést PowerPoint na TIFF](/slides/cs/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Vytvořit textovou PowerPoint XML prezentaci pro inspekci, porovnání, odstraňování problémů nebo pracovní postupy založené na XML. | [Převést PowerPoint na XML](/slides/cs/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Vytvořit pracovní postup exportu videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře UI v JavaScriptu nebo Javě. | [Exportovat prezentace do XAML](/slides/cs/nodejs-java/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/nodejs-java/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides pro Node.js přes Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné API pro konverzi se používá pro soubory PowerPoint i OpenDocument, takže pracovní postup, který uloží soubor PPTX do PDF, lze obvykle aplikovat i na soubor ODP změnou pouze vstupního souboru.

Při konverzi souborů ODP si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují každé rozložení a formátovací funkce přesně stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/nodejs-java/convert-openoffice-odp/) když potřebujete konkrétní rady pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides pro Node.js přes Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozvržení, snímky, grafy, skupinové tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

For details, see [Převést PPT na PPTX](/slides/cs/nodejs-java/convert-ppt-to-pptx/) and [PPT vs PPTX](/slides/cs/nodejs-java/ppt-vs-pptx/).

## **Export s pevnou stránkou**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na různých zařízeních a neměl by být upravován jako prezentace. Vyhrazené články o PDF, XPS a TIFF vysvětlují, jak řídit soulad, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když má každý snímek být samostatným náhledem, miniaturou nebo rastrovým zdrojem. Použijte články o PNG, JPG a SVG pro konkrétní pokyny k vykreslování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides pro Node.js přes Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu dávkově převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentace a řiďte se pokyny pro [vícevláknové zpracování](/slides/cs/nodejs-java/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik exportních metod vám umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz vyhrazený článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF jsou k dispozici pro export do PDF. Viz [Převést PowerPoint na PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou fonty během konverze zpracovávány?**

Aspose.Slides může používat vložená písma, záložní písma a nastavení náhrady písma. Viz [Vložené písmo](/slides/cs/nodejs-java/embedded-font/), [Záložní písmo](/slides/cs/nodejs-java/fallback-font/), a [Náhrada písma](/slides/cs/nodejs-java/font-substitution/).