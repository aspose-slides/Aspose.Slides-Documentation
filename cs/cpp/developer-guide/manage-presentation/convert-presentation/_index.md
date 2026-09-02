---
title: Převést prezentace do více formátů v C++
linktitle: Převést prezentaci
type: docs
weight: 70
url: /cs/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument do PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších formátů pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ může načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozložení, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslovat snímky do obrazových souborů pro náhledy, miniatury a archivy.

Většina převodů dokumentů používá stejný obecný postup: načíst zdrojový soubor, vybrat požadovaný výstupní formát a podle potřeby aplikovat možnosti specifické pro formát. Pro formáty obrázků je každý snímek vykreslen samostatně a následně uložen jako rastrový nebo vektorový obrázek. Níže uvedené specializované články poskytují podrobnosti o implementaci pro každý případ.

## **Vyberte scénář převodu**

Použijte níže uvedené články pro kompletní příklady v C++ a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/cpp/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/cpp/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/cpp/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími procesy. | [Převést PPTX na PPT](/slides/cs/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou rozložením pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky přednášejícího spolu s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozložení. | [Převést PowerPoint na HTML](/slides/cs/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Převést prezentace na HTML5](/slides/cs/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Vykreslit každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelnou vektorovou grafiku. | [Vykreslit snímek jako SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Vytvořit dokumenty XPS s pevnou rozložením. | [Převést PowerPoint na XPS](/slides/cs/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivní procesy. | [Převést PowerPoint na TIFF](/slides/cs/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Vytvořit textovou PowerPoint XML prezentaci pro inspekci, porovnání, řešení problémů nebo XML‑založené pracovní postupy. | [Převést PowerPoint na XML](/slides/cs/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Vytvořit pracovní postup exportu do videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře UI v C++. | [Exportovat prezentace do XAML](/slides/cs/cpp/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/cpp/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides pro C++ podporuje převod z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné API pro převod se používá pro soubory PowerPoint i OpenDocument, takže pracovní postup, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při převodu souborů ODP si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují všechny rozložení a formátovací funkce stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/cpp/convert-openoffice-odp/), když potřebujete rady specifické pro formát.

## **Převod PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides pro C++ podporuje vysoce věrný převod PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

Pro podrobnosti viz [Převést PPT na PPTX](/slides/cs/cpp/convert-ppt-to-pptx/).

## **Export s pevnou rozložením**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na různých zařízeních a neměl by být upravován jako prezentace. Účelové články o PDF, XPS a TIFF vysvětlují, jak řídit shodu, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když každý snímek musí být samostatný náhled, miniatura nebo rastrový asset. Použijte články o PNG, JPG a SVG pro konkrétní pokyny k vykreslování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides pro C++ je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentace a řiďte se pokyny pro [vícevláknové zpracování](/slides/cs/cpp/multithreading/).

**Mohu exportovat pouze vybrané snímky?**

Ano. Několik metod exportu vám umožní předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz specializovaný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení shody PDF jsou k dispozici pro export do PDF. Podrobnosti najdete v [Převést PowerPoint na PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/).

**Jak jsou během převodu zacházeno s písmy?**

Aspose.Slides může používat vložená písma, záložní písmo a nastavení substituce písma. Viz [Vložené písmo](/slides/cs/cpp/embedded-font/), [Záložní písmo](/slides/cs/cpp/fallback-font/), a [Substituce písma](/slides/cs/cpp/font-substitution/).