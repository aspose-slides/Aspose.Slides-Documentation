---
title: Převod prezentací do více formátů v PHP
linktitle: Převod prezentace
type: docs
weight: 70
url: /cs/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument do PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších formátů pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java může načítat prezentace PowerPoint a OpenDocument a ukládat nebo renderovat je do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozložením jako PDF a XPS, publikovat snímky jako HTML nebo renderovat snímky jako obrázkové soubory pro náhledy, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, vybrat požadovaný výstupní formát a v případě potřeby použít možnosti specifické pro formát. Pro obrazové formáty je každý snímek renderován samostatně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené věnované články poskytují podrobnosti o implementaci pro každý případ.

## **Vyberte scénář konverze**

Použijte níže uvedené články pro kompletní PHP příklady a možnosti specifické pro formát.

| Scénář | Použít, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/php-java/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/php-java/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/php-java/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími workflow. | [Převést PPTX na PPT](/slides/cs/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenositelné, prohledávatelné dokumenty s pevnou rozložením pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky přednášejícího spolu s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozložení. | [Převést PowerPoint na HTML](/slides/cs/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči s zachovaným formátováním a interaktivitou. | [Exportovat prezentace do HTML5](/slides/cs/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderovat každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderovat snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Renderovat snímek jako SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generovat dokumenty XPS s pevnou rozložením. | [Převést PowerPoint na XPS](/slides/cs/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové workflow. | [Převést PowerPoint na Markdown](/slides/cs/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Sestavit workflow pro export videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře PHP nebo Java UI. | [Exportovat prezentace do XAML](/slides/cs/php-java/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Supported File Formats](/slides/cs/php-java/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides for PHP via Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejná konverzní API je používána pro soubory PowerPoint i OpenDocument, takže workflow, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP pouhou změnou vstupního souboru.

Při konverzi ODP souborů pamatujte, že aplikace PowerPoint a OpenDocument nepodporují všechny rozložení a formátovací funkce stejným způsobem. Pokud byl ODP soubor vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Convert OpenDocument Presentations](/slides/cs/php-java/convert-openoffice-odp/) podle potřeby.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for PHP via Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou mistry, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textová pole, textury a výplně obrázků.

Podrobnosti najdete v [Convert PPT to PPTX](/slides/cs/php-java/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/php-java/ppt-vs-pptx/).

## **Export s pevnou rozložením**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na všech zařízeních a neměl by být editovatelný jako prezentace. Věnované články o PDF, XPS a TIFF vysvětlují, jak řídit kompatibilitu, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když má každý snímek být samostatným náhledem, miniaturou nebo rastrovým aktivem. Použijte články o PNG, JPG a SVG pro vedení specifické pro renderování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides for PHP via Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentace a řiďte se pokyny v [multithreading](/slides/cs/php-java/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik metod exportu umožňuje předat indexy snímků nebo renderovat jednotlivé snímky, v závislosti na výstupním formátu. Viz věnovaný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/php-java/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF jsou k dispozici pro export PDF. Podrobnosti najdete v [Convert PowerPoint to PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/).

**Jak jsou během konverze zpracovávána písma?**

Aspose.Slides může používat vložená písma, náhradní písma a nastavení substituce písma. Viz [Embedded Font](/slides/cs/php-java/embedded-font/), [Fallback Font](/slides/cs/php-java/fallback-font/) a [Font Substitution](/slides/cs/php-java/font-substitution/).