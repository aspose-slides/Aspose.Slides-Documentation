---
title: Převod prezentací do více formátů v .NET
linktitle: Převést prezentaci
type: docs
weight: 70
url: /cs/net/convert-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument na PPTX, PDF, HTML, obrázky, XPS, TIFF a další pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides for .NET může načíst prezentace PowerPoint a OpenDocument a uložit je nebo vykreslit do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozlohou, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslit snímky do obrazových souborů pro náhledy, miniatury a archivy.

Většina převodů dokumentů používá stejný obecný postup: načíst zdrojový soubor, zvolit požadovaný výstupní formát a v případě potřeby aplikovat možnosti specifické pro formát. Pro formáty obrázků je každý snímek vykreslen samostatně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené články poskytují podrobnosti o implementaci pro jednotlivé případy.

## **Vyberte scénář převodu**

Použijte níže uvedené články pro úplné příklady v C# a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP na PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést OpenDocument prezentace na PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/net/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/net/save-presentation/) |
| PPTX na PPT | Uložit moderní PowerPoint prezentaci do staršího binárního formátu PPT pro kompatibilitu se staršími workflow. | [Převést PPTX na PPT](/slides/cs/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP na PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou rozlohou pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP na PDF s poznámkami | Exportovat poznámky řečníka spolu s obsahem snímku. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP na HTML | Publikovat prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP na HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Exportovat prezentace do HTML5](/slides/cs/net/export-to-html5/) |
| PPT/PPTX/ODP na PNG | Vykreslit každý snímek do PNG obrázku pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP na JPG | Vykreslit snímky do JPG obrázků a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/net/convert-powerpoint-to-jpg/) |
| Snímek na SVG | Exportovat jednotlivé snímky jako škálovatelné vektorové grafiky. | [Vykreslit snímek jako SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP na XPS | Generovat dokumenty XPS s pevnou rozlohou. | [Převést PowerPoint na XPS](/slides/cs/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP na TIFF | Uložit prezentaci jako více-stránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP na TIFF s poznámkami | Uložit snímky s poznámkami řečníka do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX na Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/net/convert-powerpoint-to-word/) |
| PPT/PPTX na Markdown | Extrahovat obsah prezentace do Markdownu pro dokumentaci a textové workflow. | [Převést PowerPoint na Markdown](/slides/cs/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP na XML | Vytvořit textově založený PowerPoint XML Presentation pro inspekci, porovnání, řešení problémů nebo XML workflow. | [Převést PowerPoint na XML](/slides/cs/net/convert-powerpoint-to-xml/) |
| PPT/PPTX na animovaný GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX na video | Vytvořit workflow pro export videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/net/convert-powerpoint-to-video/) |
| Prezentace na XAML | Exportovat snímky do XAML pro .NET UI scénáře. | [Exportovat prezentace do XAML](/slides/cs/net/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů viz [Podporované formáty souborů](/slides/cs/net/supported-file-formats/).

## **Převod PowerPoint a OpenDocument**

Aspose.Slides for .NET podporuje převod z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejná API pro převod se používá pro soubory PowerPoint i OpenDocument, takže workflow, který uloží soubor PPTX do PDF, lze obvykle aplikovat i na soubor ODP pouhou změnou vstupního souboru.

Při převodu ODP souborů pamatujte, že aplikace PowerPoint a OpenDocument nepodporují každý rozvrh a formátovací prvek přesně stejným způsobem. Pokud byl ODP soubor vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/net/convert-openoffice-odp/), když potřebujete vedení specifické pro formát.

## **Převod PPT na PPTX**

PPT je starší binární formát PowerPointu, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides for .NET podporuje vysoce věrný převod PPT na PPTX při zachování složitých struktur prezentace, jako jsou mastery, rozvržení, snímky, grafy, seskupené tvary, placeholdery, textové rámečky, textury a výplně obrázky.

Podrobnosti naleznete v [Převést PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/net/ppt-vs-pptx/).

## **Export s pevnou rozlohou**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na různých zařízeních a nemá být upravován jako prezentace. Použijte [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/) k řízení souladu, skrytých snímků, poznámek, kvality obrázku, komprese, formátu pixelů a velikosti výstupu.

## **Export HTML a obrázků**

Export HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když má každý snímek vytvořit samostatný náhled, miniaturu nebo rastrový zdroj. Použijte články o PNG, JPG a SVG pro vedení specifické pro formát vykreslování.

## **Často kladené otázky**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides for .NET je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani Office automatizaci.

**Mohu dávkově převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt `Presentation`. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny v [multithreading](/slides/cs/net/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik metod exportu umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz příslušný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte vlastnost `ShowHiddenSlides` v [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) nebo [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení souladu PDF je dostupné prostřednictvím [PdfOptions.Compliance](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/compliance/) a [PdfCompliance](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfcompliance/).

**Jak jsou během převodu zacházeno s fonty?**

Aspose.Slides může používat vložené fonty, náhradní fonty a nastavení substituce fontů. Viz [Embedded Font](/slides/cs/net/embedded-font/), [Fallback Font](/slides/cs/net/fallback-font/) a [Font Substitution](/slides/cs/net/font-substitution/).