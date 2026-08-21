---
title: Nízkokódové operace s prezentacemi v Pythonu
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/python-net/low-code-presentation-operations/
keywords:
- low-code prezentační API
- převod prezentace
- sloučení prezentací
- sběr tvarů
- komprese prezentace
- odstranění nepoužívaných master snímků
- odstranění nepoužívaných layout snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v Pythonu k převodu a sloučení prezentací, sběru tvarů a snížení velikosti prezentace."
---
## **Přehled**

Modul [aspose.slides.lowcode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/) poskytuje pomocné třídy pro běžné operace s prezentacemi. Tyto pomůcky zabalí často používané workflow objektového modelu do cílených metod, takže můžete konvertovat nebo slučovat soubory, sbírat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Low-code pomůcky jsou nejužitečnější, když operace se vztahuje na celý soubor nebo prezentaci a výchozí workflow splňuje vaše požadavky. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/python-net/aspose.slides/) když potřebujete jemnou kontrolu nad jednotlivými snímky, hlavními šablonami, rozvrženími, tvary, nastavením exportu nebo vztahy mezi elementy prezentace.

Následující tabulka shrnuje dostupné pomůcky:

| Pomůcka | K čemu |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [Collect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných hlavních šablon a rozvržení a snížení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.auto_by_extension](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/auto_by_extension/) když je přípona výstupního souboru postačující pro výběr exportního formátu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Třída [Convert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/) také poskytuje dedikované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem inspektovat nebo upravit prezentaci nebo konfigurovat volbu exportu, která není v rámci vybrané pomůcky exponována. Viz [Convert Presentation](/python-net/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/process/) k kombinaci kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Pomůcka je vhodná, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílovou hlavní šablonu nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/python-net/merge-presentation/) pro tyto scénáře.

## **Sběr tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/shapes/) když potřebujete kolekci všech tvarů v prezentaci. To je užitečné, pokud bude stejná množina filtrována, počítána nebo zpracovávána vícekrát.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Použijte přímé smyčky sběru, když je důležitý pořadí procházení, předčasný ukončení, filtrování před zpracováním nebo podrobná kontrola rodič‑potomek vztahu.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) může odstranit nepoužívané strukturační elementy a snížit vložená data fontů:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) odstraňuje snímky rozvržení, na které neodkazuje žádný běžný snímek.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) odstraňuje hlavní šablony, které již nejsou použity.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) odstraňuje nepoužívané znaky z vložených fontů.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Odstraňujte nejprve nepoužívaná rozvržení před nevyužitými hlavními šablonami, aby mohla být po vyčištění rozvržení také odstraněna hlavní šablona, která se stane neodkazovanou. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat původní hlavní šablony, rozvržení nebo kompletní vložená data fontů. Pro podrobnosti viz [Slide Master](/python-net/slide-master/) a [Embedded Font](/python-net/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl používat low-code API místo úplného objektového modelu?**

Používejte low-code pomůcky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými elementy. Použijte úplný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy hlavních šablon a rozvržení, sledovat mezistavy nebo konfigurovat chování, které pomůcka neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/process/) vyžaduje vstupní prezentace ve stejném formátu. Nejprve konvertujte vstupní soubory do společného formátu, například pomocí [Convert.auto_by_extension](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/auto_by_extension/), a pak sloučte převedené soubory.

**Co zahrnuje Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/shapes/) získává tvary z prezentace, aby mohly být zachovány, filtrovány, počítány nebo procházeny vícekrát. Použijte přímé smyčky sběru, když potřebujete přesnou kontrolu nad tím, které typy snímků nebo vnořené objekty jsou navštíveny.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané hlavní šablony nebo vložené fonty s nepoužívanými znaky. Pokud žádné z těchto prvků neexistují, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) nemusí velikost souboru snížit.

**Ukládají se změny provedené pomocí Compress automaticky?**

Ne. Tyto pomůcky pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) v paměti. Po spuštění [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k zapsání výsledku.

## **Související články**

- [Převod prezentace](/python-net/convert-presentation/)
- [Sloučení prezentací](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)