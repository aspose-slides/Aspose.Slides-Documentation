---
title: Operace prezentací s nízkým kódem v Pythonu
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/python-net/low-code-presentation-operations/
keywords:
- API pro prezentace s nízkým kódem
- konverze prezentace
- sloučení prezentací
- sběr tvarů
- komprese prezentace
- odstranění nepoužívaných master snímků
- odstranění nepoužívaných rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v Pythonu pro konverzi a sloučení prezentací, sběr tvarů a snížení velikosti prezentace."
---
## **Přehled**

Modul [aspose.slides.lowcode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/) poskytuje pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané workflow objektového modelu do cílených metod, takže můžete konvertovat nebo slučovat soubory, shromažďovat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Low‑code pomocníky jsou nejvíce užitečné, když operace platí pro celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides objektový model](https://reference.aspose.com/slides/cs/python-net/aspose.slides/) pokud potřebujete jemno‑dílnou kontrolu nad jednotlivými snímky, mastery, rozvrženími, tvary, nastaveními exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | Použít pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/) | Konverze prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/) | Kombinace kompletních souborů prezentací stejného formátu. |
| [Collect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných masterů a rozvržení a zmenšení vložených dat fontů. |

## **Convert a Presentation**

Použijte [Convert.auto_by_extension](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/auto_by_extension/) když je přípona výstupního souboru dostačující k určení exportního formátu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Třída [Convert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/) také poskytuje specializované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, pokud potřebujete před exportem prezentaci prozkoumat nebo upravit, nebo nastavit exportní volbu, která není v daném pomocníkovi vystavena. Viz [Convert Presentation](/slides/cs/python-net/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Merge Presentations**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/process/) pro sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, pokud potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/python-net/merge-presentation/) pro tyto scénáře.

## **Collect Shapes**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/shapes/) když potřebujete kolekci všech tvarů v prezentaci. To je užitečné, pokud bude stejná množina filtrů, počítána nebo zpracovávána vícekrát.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Použijte přímé smyčky sběru, když je důležitý pořadí průchodu, předčasný odchod, filtrování před zpracováním nebo podrobná kontrola rodič‑dítě.

## **Compress Presentation Content**

Třída [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) může odstranit nepoužívané strukturální elementy a zmenšit vložená data fontů:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) odstraňuje rozvržení snímků, na které neodkazuje žádný běžný snímek.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) odstraňuje master snímky, které již nejsou použity.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) odstraňuje nepoužívané znaky z vložených fontů.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Nejprve odstraňujte nepoužívaná rozvržení, až potom nepoužívané mastery, aby mohl být master, který se po úklidu rozvržení stane nepoužívaným, také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud můžete později potřebovat originální mastery, rozvržení nebo kompletní data vložených fontů. Pro podrobnosti viz [Slide Master](/slides/cs/python-net/slide-master/) a [Embedded Font](/slides/cs/python-net/embedded-font/).

## **FAQ**

**Kdy bych měl použít low‑code API místo plného objektového modelu?**

Používejte low‑code pomocníky, když standardní operace platí pro kompletní soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte plný objektový model, pokud potřebujete vybrat konkrétní snímky, řídit vztahy mezi mastery a rozvrženími, prozkoumat mezistavy nebo nastavit chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/merger/process/) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.auto_by_extension](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/convert/auto_by_extension/), a pak sloučte převedené soubory.

**Co zahrnuje Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/collect/shapes/) získává tvary z prezentace, aby mohly být zachovány, filtrovány, počítány nebo procházeny opakovaně. Použijte přímé smyčky sběru, když potřebujete přesnou kontrolu nad tím, které typy snímků nebo vnořené objekty jsou navštíveny.

**Zmenší Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané mastery nebo vložené fonty s nepoužívanými znaky. Pokud žádné z těchto prvků nejsou přítomny, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) nemusí soubor zmenšit.

**Ukládají se změny provedené Compress automaticky?**

Ne. Tito pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) v paměti. Po spuštění [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) pro zápis výsledku.

## **Related Articles**

- [Convert Presentation](/slides/cs/python-net/convert-presentation/)
- [Merge Presentations](/slides/cs/python-net/merge-presentation/)
- [Slide Master](/slides/cs/python-net/slide-master/)
- [Manage Text Box](/slides/cs/python-net/manage-textbox/)
- [Embedded Font](/slides/cs/python-net/embedded-font/)