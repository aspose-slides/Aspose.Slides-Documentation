---
title: Převod prezentací do více formátů na Androidu
linktitle: Převést prezentaci
type: docs
weight: 70
url: /cs/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument do formátů PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

Aspose.Slides for Android via Java může načíst prezentace PowerPoint a OpenDocument a uložit je nebo je vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést starší soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozložením, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslit snímky do obrazových souborů pro náhledy, náhledové miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby použít formátově specifické možnosti. Pro obrazové formáty je každý snímek vykreslen samostatně a poté uložen jako rastrový nebo vektorový obrázek. Vyhrazené články uvedené níže poskytují podrobnosti o implementaci pro každý případ.

## **Vyberte scénář konverze**

Použijte níže uvedené články pro kompletní příklady v Javě a formátově specifické možnosti.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP na PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést OpenDocument prezentace na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/androidjava/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/androidjava/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/androidjava/save-presentation/) |
| PPTX na PPT | Uložit moderní PowerPoint prezentaci do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převést PPTX na PPT](/slides/cs/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP na PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou rozložením pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP na PDF s poznámkami | Exportovat poznámky přednášejícího spolu s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP na HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP na HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči s zachovaným formátováním a interaktivitou. | [Exportovat prezentace do HTML5](/slides/cs/androidjava/export-to-html5/) |
| PPT/PPTX/ODP na PNG | Vykreslit každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP na JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/androidjava/convert-powerpoint-to-jpg/) |
| Snímek na SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Vykreslit snímek jako SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP na XPS | Generovat dokumenty XPS s pevnou rozložením. | [Převést PowerPoint na XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP na TIFF | Uložit prezentaci jako více-stránkový TIFF soubor pro tisk, skenování, fax nebo archivní pracovní postupy. | [Převést PowerPoint na TIFF](/slides/cs/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP na TIFF s poznámkami | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX na Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX na Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX na animovaný GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX na video | Vytvořit pracovní postup pro export videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/androidjava/convert-powerpoint-to-video/) |
| Prezentace na XAML | Exportovat snímky do XAML pro scénáře Android nebo Java UI. | [Exportovat prezentace do XAML](/slides/cs/androidjava/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/androidjava/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides for Android via Java podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Pro soubory PowerPoint i OpenDocument se používá stejné API, takže workflow, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP pouhou změnou vstupního souboru.

Při konverzi souborů ODP si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují každé rozvržení a formátování stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Convert OpenDocument Presentations](/slides/cs/androidjava/convert-openoffice-odp/), pokud potřebujete specifické pokyny pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for Android via Java podporuje vysoce věrnou konverzi PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozvržení, snímky, grafy, seskupené tvary, zástupné prvky, textové rámečky, textury a výplně obrázky.

Podrobnosti najdete v [Convert PPT to PPTX](/slides/cs/androidjava/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/androidjava/ppt-vs-pptx/).

## **Export s pevnou rozložením**

PDF, XPS a TIFF jsou užitečné, když výstup má vypadat stejně na všech zařízeních a neměl by být upravován jako prezentace. Vyhrazené články o PDF, XPS a TIFF vysvětlují, jak řídit kompatibilitu, skryté snímky, poznámky, kvalitu obrázků, kompresi, formát pixelů a velikost výstupu.

## **Export HTML a obrázků**

Export HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když má každý snímek stát se samostatným náhledem, miniaturou nebo rastrovým aktivem. Použijte články o PNG, JPG a SVG pro formátově specifické pokyny k vykreslování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides for Android via Java je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt prezentace. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny v [multithreading](/slides/cs/androidjava/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik metod exportu vám umožní předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz vyhrazený článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte nastavení exportu skrytých snímků popsaná v článcích o [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) a [XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF jsou k dispozici pro export PDF. Podívejte se na [Convert PowerPoint to PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) pro podrobnosti.

**Jak jsou písma během konverze zpracovávána?**

Aspose.Slides může používat vložená písma, náhradní písma a nastavení substituce písma. Viz [Embedded Font](/slides/cs/androidjava/embedded-font/), [Fallback Font](/slides/cs/androidjava/fallback-font/) a [Font Substitution](/slides/cs/androidjava/font-substitution/).