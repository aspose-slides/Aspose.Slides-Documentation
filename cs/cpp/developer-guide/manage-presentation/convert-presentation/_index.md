---
title: Převod prezentací do více formátů v C++
linktitle: Převod prezentace
type: docs
weight: 70
url: /cs/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "Převod prezentací PowerPoint a OpenDocument do formátů PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ může načíst prezentace PowerPoint a OpenDocument a uložit nebo vykreslit je do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést starší soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou oblastí, jako jsou PDF a XPS, publikovat snímky jako HTML, nebo vykreslit snímky do obrazových souborů pro náhledy, miniatury a archivaci.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít možnosti specifické pro formát. Pro obrazové formáty je každý snímek vykreslen samostatně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené konkrétní články poskytují podrobnosti o implementaci pro každý případ.

## **Vyberte scénář konverze**

Použijte níže uvedené články pro kompletní příklady v C++ a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument na PowerPoint PPTX. | [Převod PPT na PPTX](/slides/cs/cpp/convert-ppt-to-pptx/), [Převod ODP na PPTX](/slides/cs/cpp/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/cpp/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převod PPTX na PPT](/slides/cs/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou oblastí pro sdílení, tisk nebo archivaci. | [Převod PowerPointu na PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky řečníka spolu s obsahem snímků. | [Převod PowerPointu na PDF s poznámkami](/slides/cs/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převod PowerPointu na HTML](/slides/cs/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Převod prezentací na HTML5](/slides/cs/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Vykreslit každý snímek do PNG obrazu pro náhledy, miniatury nebo webový výstup. | [Převod PowerPointu na PNG](/slides/cs/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Vykreslit snímky do JPG obrazů a řídit rozměry a kvalitu obrazu. | [Převod PowerPointu na JPG](/slides/cs/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Vykreslit snímek jako SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generovat dokumenty XPS s pevnou oblastí. | [Převod PowerPointu na XPS](/slides/cs/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivní pracovní postupy. | [Převod PowerPointu na TIFF](/slides/cs/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami řečníka do TIFF. | [Převod PowerPointu na TIFF s poznámkami](/slides/cs/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převod PowerPointu na Word](/slides/cs/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převod PowerPointu na Markdown](/slides/cs/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převod PowerPointu na animovaný GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Vytvořit workflow pro export videa ze snímků prezentace. | [Převod PowerPointu na video](/slides/cs/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro C++ UI scénáře. | [Exportovat prezentace do XAML](/slides/cs/cpp/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/cpp/supported-file-formats/).

## **PowerPoint a OpenDocument konverze**

Aspose.Slides pro C++ podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné konverzní API se používá pro soubory PowerPoint i OpenDocument, takže workflow, který ukládá soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při konverzi souborů ODP pamatujte, že aplikace PowerPoint a OpenDocument nepodporují všechny rozložení a formátovací funkce přesně stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převod OpenDocument prezentací](/slides/cs/cpp/convert-openoffice-odp/) když potřebujete vedení specifické pro formát.

## **PPT na PPTX konverze**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides pro C++ podporuje konverzi PPT na PPTX s vysokou věrností a zachovává komplexní struktury prezentace, jako jsou master snímky, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

Pro podrobnosti viz [Převod PPT na PPTX](/slides/cs/cpp/convert-ppt-to-pptx/).

## **Export s pevnou oblastí**

PDF, XPS a TIFF jsou užitečné, když výstup má vypadat stejně na všech zařízeních a neměl by být upravován jako prezentace. Vyhrazené články o PDF, XPS a TIFF vysvětlují, jak ovládat shodu, skryté snímky, poznámky, kvalitu obrazu, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když každý snímek musí být samostatný náhled, miniatura nebo rastrový soubor. Použijte články o PNG, JPG a SVG pro pokyny specifické pro formát.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides pro C++ je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentace a řiďte se pokyny pro [multithreading](/slides/cs/cpp/multithreading/).

**Mohu exportovat pouze vybrané snímky?**

Ano. Několik metod exportu vám umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz vyhrazený článek pro daný formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení shody PDF jsou k dispozici pro export do PDF. Pro podrobnosti viz [Převod PowerPointu na PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/).

**Jak jsou písma při konverzi zpracovávána?**

Aspose.Slides může používat vložená písma, náhradní písma a nastavení substituce písem. Viz [Vložené písmo](/slides/cs/cpp/embedded-font/), [Náhradní písmo](/slides/cs/cpp/fallback-font/), a [Substituce písma](/slides/cs/cpp/font-substitution/).