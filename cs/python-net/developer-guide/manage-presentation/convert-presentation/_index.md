---
title: Převod prezentací do více formátů v Pythonu
linktitle: Převod prezentací
type: docs
weight: 70
url: /cs/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Python via .NET."
---
## **Přehled**

Aspose.Slides for Python via .NET může načítat prezentace PowerPoint a OpenDocument a ukládat je nebo renderovat do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnými rozvržením, jako jsou PDF a XPS, publikovat snímky jako HTML, nebo renderovat snímky jako soubory obrázků pro náhledy, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít formátově specifické možnosti. Pro formáty obrázků je každý snímek renderován samostatně a následně uložen jako rastrový nebo vektorový obrázek. Níže uvedené články poskytují podrobnosti o implementaci pro každý případ.

## **Zvolte scénář konverze**

Použijte níže uvedené články pro kompletní příklady v Pythonu a formátově specifické možnosti.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést OpenDocument prezentace na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/python-net/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/python-net/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/python-net/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převést PPTX na PPT](/slides/cs/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou strukturou pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky přednášejícího společně s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a ovládat obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči s zachovaným formátováním a interaktivitou. | [Převést prezentace do HTML5](/slides/cs/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderovat každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderovat snímky do JPG obrázků a ovládat rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Renderovat snímek jako SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generovat dokumenty XPS s pevnou strukturou. | [Převést PowerPoint na XPS](/slides/cs/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako více-stránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | Vytvořit workflow exportu videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře UI v Pythonu nebo .NET. | [Exportovat prezentace do XAML](/slides/cs/python-net/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů, viz [Podporované formáty souborů](/slides/cs/python-net/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides for Python via .NET podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné konverzní API se používá pro soubory PowerPoint i OpenDocument, takže workflow, který ukládá soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při konverzi ODP souborů si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují všechny rozložení a formátovací funkce stejným způsobem. Pokud byl ODP soubor vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/python-net/convert-openoffice-odp/) když potřebujete formátově specifické pokyny.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for Python via .NET podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou master slidy, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textová pole, textury a výplně obrázků.

Pro podrobnosti viz [Převést PPT na PPTX](/slides/cs/python-net/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/python-net/ppt-vs-pptx/).

## **Export s pevnou strukturou**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na všech zařízeních a neměl by být upravován jako prezentace. Vyhrazené články o PDF, XPS a TIFF vysvětlují, jak řídit kompatibilitu, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, publikování na webu a lehké sdílení. Export obrázků je užitečný, když každý snímek má být samostatný náhled, miniatura nebo rastrový asset. Použijte články o PNG, JPG a SVG pro formátově specifické pokyny k renderování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides for Python via .NET je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny pro [vícevláknové zpracování](/slides/cs/python-net/multithreading/).

**Mohu exportovat pouze vybrané snímky?**

Ano. Několik metod exportu umožňuje předat indexy snímků nebo renderovat jednotlivé snímky, v závislosti na výstupním formátu. Viz vyhrazený článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/python-net/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení kompatibility PDF jsou k dispozici pro export PDF. Viz [Převést PowerPoint na PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou písma při konverzi zpracovávána?**

Aspose.Slides může používat vložená písma, náhradní písma a nastavení substituce fontů. Viz [Vložené písmo](/slides/cs/python-net/embedded-font/), [Náhradní písmo](/slides/cs/python-net/fallback-font/), a [Substituce písma](/slides/cs/python-net/font-substitution/).