---
title: Převod prezentací do více formátů v Java
linktitle: Převést prezentaci
type: docs
weight: 70
url: /cs/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint a OpenDocument do PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides for Java může načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozložením, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslit snímky do obrazových souborů pro náhledy, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít možnosti specifické pro formát. Pro formáty obrázků je každý snímek vykreslen samostatně a následně uložen jako rastrový nebo vektorový obrázek. Vyhrazené články uvedené níže poskytují podrobnosti o implementaci pro každý případ.

## **Vyberte scénář konverze**

Použijte níže uvedené články pro kompletní Java příklady a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP na PPTX | Modernizujte staré soubory PPT, normalizujte existující soubory PPTX nebo převeďte prezentace OpenDocument na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/java/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/java/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/java/save-presentation/) |
| PPTX na PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími procesy. | [Převést PPTX na PPT](/slides/cs/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP na PDF | Vytvořit přenosné, prohledávané dokumenty s pevnou rozložením pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP na PDF s poznámkami | Exportovat poznámky přednášejícího spolu s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP na HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozložení. | [Převést PowerPoint na HTML](/slides/cs/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP na HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachováním formátování a interaktivity. | [Převést prezentace do HTML5](/slides/cs/java/export-to-html5/) |
| PPT/PPTX/ODP na PNG | Vykreslit každý snímek jako PNG obrázek pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP na JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/java/convert-powerpoint-to-jpg/) |
| Snímek na SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Vykreslit snímek jako SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP na XPS | Vytvořit dokumenty XPS s pevnou rozložením. | [Převést PowerPoint na XPS](/slides/cs/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP na TIFF | Uložit prezentaci jako více-stránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP na TIFF s poznámkami | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX na Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/java/convert-powerpoint-to-word/) |
| PPT/PPTX na Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové workflow. | [Převést PowerPoint na Markdown](/slides/cs/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP na XML | Vytvořit textovou PowerPoint XML prezentaci pro inspekci, porovnání, řešení problémů nebo XML workflow. | [Převést PowerPoint na XML](/slides/cs/java/convert-powerpoint-to-xml/) |
| PPT/PPTX na animovaný GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX na video | Vytvořit workflow exportu videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/java/convert-powerpoint-to-video/) |
| Prezentace na XAML | Exportovat snímky do XAML pro Java UI scénáře. | [Exportovat prezentace do XAML](/slides/cs/java/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované souborové formáty](/slides/cs/java/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides for Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné konverzní API se používá pro soubory PowerPoint i OpenDocument, takže workflow, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP pouhou změnou vstupního souboru.

Při konverzi ODP souborů mějte na paměti, že aplikace PowerPoint a OpenDocument nepodporují všechny rozložení a formátovací funkce přesně stejným způsobem. Pokud byl ODP soubor vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/java/convert-openoffice-odp/), když potřebujete konkrétní pokyny pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozložení, snímky, grafy, seskupené tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

Pro podrobnosti viz [Převést PPT na PPTX](/slides/cs/java/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/java/ppt-vs-pptx/).

## **Export s pevnou rozložením**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na všech zařízeních a neměl by být editován jako prezentace. Vyhrazené články o PDF, XPS a TIFF vysvětlují, jak řídit kompatibilitu, skryté snímky, poznámky, kvalitu obrázků, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, publikování na webu a lehké sdílení. Export obrázků je užitečný, když každý snímek musí být samostatný náhled, miniatura nebo rastrový zdroj. Použijte články o PNG, JPG a SVG pro pokyny specifické pro rendering formátu.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint pro konverzi prezentací?**

Ne. Aspose.Slides for Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny pro [vícevláknové zpracování](/slides/cs/java/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik exportních metod umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz vyhrazený článek pro daný formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/java/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF jsou k dispozici pro export do PDF. Viz [Převést PowerPoint na PDF](/slides/cs/java/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou písma během konverze zpracovávána?**

Aspose.Slides může použít vložená písma, záložní písma a nastavení substituce písma. Viz [Vložené písmo](/slides/cs/java/embedded-font/), [Záložní písmo](/slides/cs/java/fallback-font/) a [Substituce písma](/slides/cs/java/font-substitution/).