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
description: "Převod prezentací PowerPoint a OpenDocument do formátů PPTX, PDF, HTML, obrázků, XPS, TIFF a dalších pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides pro .NET může načíst prezentace PowerPoint a OpenDocument a uložit nebo vykreslit je do mnoha dalších formátů bez Microsoft PowerPoint, OpenOffice nebo LibreOffice. Můžete převést staré soubory PPT na moderní PPTX, exportovat prezentace do dokumentů s pevnou rozlohou, jako jsou PDF a XPS, publikovat snímky jako HTML nebo vykreslit snímky do souborů obrázků pro náhledy, miniatury a archivy.

Většina konverzí dokumentů používá stejný obecný postup: načíst vstupní soubor, zvolit požadovaný výstupní formát a podle potřeby použít možnosti specifické pro formát. U formátů obrázků je každý snímek vykreslen odděleně a poté uložen jako rastrový nebo vektorový obrázek. Níže uvedené články poskytují podrobnosti implementace pro jednotlivé případy.

## **Vyberte scénář konverze**

Použijte níže uvedené články pro kompletní příklady v C# a možnosti specifické pro formát.

| Scénář | Použijte, když potřebujete | Článek |
| --- | --- | --- |
| PPT/PPTX/ODP na PPTX | Modernizovat staré soubory PPT, normalizovat existující soubory PPTX nebo převést prezentace OpenDocument do PowerPoint PPTX. | [Převést PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/), [Převést ODP na PPTX](/slides/cs/net/convert-odp-to-pptx/), [Uložit prezentace](/slides/cs/net/save-presentation/) |
| PPTX na PPT | Uložit moderní prezentaci PowerPoint do staršího binárního formátu PPT pro kompatibilitu se staršími pracovními postupy. | [Převést PPTX na PPT](/slides/cs/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP na PDF | Vytvořit přenosné, prohledávatelné dokumenty s pevnou rozlohou pro sdílení, tisk nebo archivaci. | [Převést PowerPoint na PDF](/slides/cs/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP na PDF s poznámkami | Exportovat poznámky přednášejícího spolu s obsahem snímků. | [Převést PowerPoint na PDF s poznámkami](/slides/cs/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP na HTML | Zveřejnit prezentace jako HTML stránky a řídit obrázky, písma, poznámky a možnosti responzivního rozvržení. | [Převést PowerPoint na HTML](/slides/cs/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP na HTML5 | Exportovat snímky do HTML5 pro prohlížení v prohlížeči se zachovaným formátováním a interaktivitou. | [Exportovat prezentace do HTML5](/slides/cs/net/export-to-html5/) |
| PPT/PPTX/ODP na PNG | Vykreslit každý snímek do PNG obrazu pro náhledy, miniatury nebo webový výstup. | [Převést PowerPoint na PNG](/slides/cs/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP na JPG | Vykreslit snímky do JPG obrazů a řídit rozměry a kvalitu obrázku. | [Převést PowerPoint na JPG](/slides/cs/net/convert-powerpoint-to-jpg/) |
| Snímek na SVG | Exportovat jednotlivé snímky jako škálovatelnou vektorovou grafiku. | [Vykreslit snímek jako SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP na XPS | Generovat dokumenty XPS s pevnou rozlohou. | [Převést PowerPoint na XPS](/slides/cs/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP na TIFF | Uložit prezentaci jako vícestránkový TIFF soubor pro tisk, skenování, fax nebo archivaci. | [Převést PowerPoint na TIFF](/slides/cs/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP na TIFF s poznámkami | Uložit snímky s poznámkami přednášejícího do TIFF. | [Převést PowerPoint na TIFF s poznámkami](/slides/cs/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX do Word | Převést snímky do dokumentu Word, když potřebujete výstup ve stylu dokumentu. | [Převést PowerPoint na Word](/slides/cs/net/convert-powerpoint-to-word/) |
| PPT/PPTX do Markdown | Extrahovat obsah prezentace do Markdown pro dokumentaci a textové pracovní postupy. | [Převést PowerPoint na Markdown](/slides/cs/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX na animovaný GIF | Vytvořit animovaný GIF ze snímků. | [Převést PowerPoint na animovaný GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX na video | Vytvořit workflow exportu videa ze snímků prezentace. | [Převést PowerPoint na video](/slides/cs/net/convert-powerpoint-to-video/) |
| Prezentace do XAML | Exportovat snímky do XAML pro .NET UI scénáře. | [Exportovat prezentace do XAML](/slides/cs/net/export-to-xaml/) |

Pro širší seznam vstupních a výstupních formátů, viz [Podporované souborové formáty](/slides/cs/net/supported-file-formats/).

## **Konverze PowerPoint a OpenDocument**

Aspose.Slides pro .NET podporuje konverzi z běžně používaných formátů prezentací, jako jsou PPT, PPTX, PPS, PPSX, POT, POTX a ODP. Stejné konverzní API se používá pro soubory PowerPoint i OpenDocument, takže pracovní postup, který uloží soubor PPTX do PDF, lze obvykle použít i pro soubor ODP změnou pouze vstupního souboru.

Při konverzi souborů ODP si uvědomte, že aplikace PowerPoint a OpenDocument nepodporují každé rozvržení a formátovací funkce přesně stejným způsobem. Pokud byl soubor ODP vytvořen v LibreOffice nebo OpenOffice Impress, zkontrolujte výstup a použijte možnosti popsané v [Převést OpenDocument prezentace](/slides/cs/net/convert-openoffice-odp/) když potřebujete specifické pokyny pro formát.

## **Konverze PPT na PPTX**

PPT je starší binární formát PowerPoint, zatímco PPTX je moderní formát Office Open XML. Aspose.Slides pro .NET podporuje vysoce věrnou konverzi PPT na PPTX při zachování komplexních struktur prezentace, jako jsou master slajdy, rozvržení, snímky, grafy, seskupené tvary, zástupné objekty, textové rámečky, textury a výplně obrázků.

Pro podrobnosti viz [Převést PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/) a [PPT vs PPTX](/slides/cs/net/ppt-vs-pptx/).

## **Export s pevnou rozlohou**

PDF, XPS a TIFF jsou užitečné, když má výstup vypadat stejně na různých zařízeních a neměl by být upravován jako prezentace. Použijte [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/), a [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/), abyste řídili shodu, skryté snímky, poznámky, kvalitu obrázku, kompresi, formát pixelu a velikost výstupu.

## **Export HTML a obrázků**

Export do HTML a HTML5 je užitečný pro prohlížení v prohlížeči, webové publikování a lehké sdílení. Export obrázků je užitečný, když každý snímek musí být samostatným náhledem, miniaturou nebo rastrovým prvkem. Použijte články o PNG, JPG a SVG pro specifické pokyny k vykreslování.

## **FAQ**

**Potřebuji Microsoft PowerPoint k převodu prezentací?**

Ne. Aspose.Slides pro .NET je samostatná knihovna a nevyžaduje Microsoft PowerPoint ani automatizaci Office.

**Mohu hromadně převádět mnoho prezentací?**

Ano. Načtěte každou prezentaci, uložte ji do požadovaného formátu a po zpracování uvolněte objekt `Presentation`. Pro paralelní zpracování použijte samostatné instance prezentací a řiďte se pokyny pro [vícevláknové zpracování](/slides/cs/net/multithreading/).

**Mohu exportovat jen vybrané snímky?**

Ano. Několik exportních metod umožňuje předat indexy snímků nebo vykreslit jednotlivé snímky, v závislosti na výstupním formátu. Viz příslušný článek pro cílový formát.

**Mohu zahrnout skryté snímky při exportu do PDF nebo XPS?**

Ano. Použijte vlastnost `ShowHiddenSlides` v [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) nebo [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/).

**Mohu vytvořit výstup PDF/A?**

Ano. Nastavení shody PDF jsou k dispozici přes [PdfOptions.Compliance](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/compliance/) a [PdfCompliance](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfcompliance/).

**Jak jsou během konverze zpracovány fonty?**

Aspose.Slides může používat vložené fonty, záložní fonty a nastavení substituce fontů. Viz [Vložený font](/slides/cs/net/embedded-font/), [Záložní font](/slides/cs/net/fallback-font/), a [Substituce fontu](/slides/cs/net/font-substitution/).