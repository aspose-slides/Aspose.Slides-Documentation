---
title: Převod prezentací do více formátů v Javě
linktitle: Převod prezentace
type: docs
weight: 70
url: /cs/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint a OpenDocument do formátů PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides for Java dokáže načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice ani LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozložením, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslovat snímky jako obrazové soubory pro ukázky, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít možnosti specifické pro formát. Pro obrazové formáty je každý snímek vykreslen samostatně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené články poskytují podrobnosti o implementaci pro každý případ.

## **Zvolte scénář konverze**

Použijte níže uvedené články pro kompletní příklady v Javě a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/java/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/java/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/java/save-presentation/) |
| PPTX to PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převést PPTX na PPT](/slides/cs/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou rozložením pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportovat poznámky prednášejícího společně s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Exportovat prezentace do HTML5](/slides/cs/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Vykreslit každý snímek do PNG obrázku pro ukázky, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportovat jednotlivé snímky jako škálovatelnou vektorovou grafiku. | [Vykreslit snímek jako SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generovat dokumenty XPS s pevnou rozložením. | [Převést PowerPoint na XPS](/slides/cs/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Uložit snímky s poznámkami řečníka do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Převést snímky do dokumentu Word, když potřebujete výstup ve formátu dokumentu. | [Převést PowerPoint na Word](/slides/cs/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Vytvořit pracovní postup pro export videa z prezentačních snímků. | [Převést PowerPoint na video](/slides/cs/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportovat snímky do XAML pro scénáře Java UI. | [Exportovat prezentace do XAML](/slides/cs/java/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/java/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides for Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné rozhraní pro konverzi se používá pro soubory PowerPoint i OpenDocument, takže pracovní postup, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při konverzi souborů ODP pamatujte, že aplikace PowerPoint a OpenDocument nepodporují každé rozložení a formátování úplně stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/java/convert-openoffice-odp/) když potřebujete konkrétní pokyny pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

Pro podrobnosti viz [Převést PPT na PPTX](/slides/cs/java/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/java/ppt-vs-pptx/).

## **Export s pevnou rozložením**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na všech zařízeních a neměl by být upravován jako prezentace. Samostatné články o PDF, XPS a TIFF vysvětlují, jak řídit shodu, skryté snímky, poznámky, kvalitu obrázků, kompresi, pixelový formát a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když má každý snímek být samostatnou ukázkou, miniaturou nebo rastrovým zdrojem. Pro pokyny k vykreslování specifické pro formát použijte články o PNG, JPG a SVG.

## **FAQ**

**Potřebuji Microsoft PowerPoint pro konverzi prezentací?**

Ne. Aspose.Slides for Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně konvertovat mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny [multithreading](/slides/cs/java/multithreading/) .

**Mohu exportovat pouze vybrané snímky?**

Ano. Několik metod exportu vám umožní předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz příslušný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/java/convert-powerpoint-to-xps/) .

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení shody PDF jsou k dispozici pro export PDF. Viz [Převést PowerPoint na PDF](/slides/cs/java/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou během konverze zpracovány písma?**

Aspose.Slides může používat vložená písma, záložní písma a nastavení substituce písem. Viz [Embedded Font](/slides/cs/java/embedded-font/), [Fallback Font](/slides/cs/java/fallback-font/) a [Font Substitution](/slides/cs/java/font-substitution/).