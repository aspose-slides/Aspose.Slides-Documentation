---
title: Operace s prezentacemi s nízkým kódem v Pythonu přes Java
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/python-java/low-code-presentation-operations/
keywords:
- low-code prezentační API
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- sběr tvarů
- komprese prezentace
- odstranění nepoužívaných master snímků
- odstranění nepoužívaných layout snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v Pythonu přes Java k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a zmenšení velikosti prezentace."
---
## **Přehled**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/cs/python-java/aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouštějí často používané workflow objektového modelu do zaměřených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Low‑code pomocníky jsou nejvíce užitečné, když se operace vztahuje na celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides objektový model](https://reference.aspose.com/slides/cs/python-java/aspose.slides/), pokud potřebujete podrobnou kontrolu nad jednotlivými snímky, mistry, rozvrženími, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | Použít pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/python-java/aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/python-java/aspose.slides/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/) | Provedení akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) | Odstranění nepoužívaných mistrů a rozvržení a zmenšení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/python-java/aspose.slides/convert/#autoByExtension), pokud je přípona výstupního souboru dostatečná pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Třída [Convert](https://reference.aspose.com/slides/cs/python-java/aspose.slides/convert/) také poskytuje specializované metody pro výstup PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, pokud potřebujete před exportem prezentaci zkontrolovat nebo upravit, nebo nastavit volbu exportu, která není v daném pomocníkovi vystavena. Viz [Convert Presentation](/slides/cs/python-java/convert-presentation/) pro workflow a možnosti specifické pro formáty.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/python-java/aspose.slides/merger/#process) pro kombinaci kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, pokud potřebujete sloučit vybrané snímky, použít cílový mistr nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/python-java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/) volá zpětný volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám sbírek a je pohodlná pro kontrolu nebo formátování na úrovni celé prezentace.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#portion) ke kontrole odpovídajících prvků:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Ve výchozím nastavení zahrnuje procházení tvarů a textu napříč celé prezentací normální, mistr‑ a rozvržovací snímky. Přetížení s parametrem `includeNotes` může také zpracovat snímky poznámek. Použijte přímé smyčky sbírek, pokud je důležitý pořadí průchodu, předčasné ukončení, filtrování před voláním zpětného volání nebo detailní kontrola rodič‑dítě vztahu.

## **Sbírání tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/collect/#shapes), pokud potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, když bude stejná sada filtrována, počítána nebo zpracována více než jednou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Použijte místo toho [ForEach.shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#shape), když může být každý tvar zpracován okamžitě a není potřeba uchovávat sesbíraný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) může odstranit nepoužívané strukturální prvky a zmenšit vložená data fontů:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) odstraňuje rozvržovací snímky, na které neodkazuje žádný normální snímek.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedMasterSlides) odstraňuje mistr‑snímky, které již nejsou použity.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#compressEmbeddedFonts) odstraňuje nepoužívané znaky z vložených fontů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nejprve odstraňte nepoužívaná rozvržení, pak nepoužívané mistry, aby mohl být mistr, který se po úklidu rozvržení stane neodkazovaným, také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud můžete později potřebovat původní mistry, rozvržení nebo kompletní data vložených fontů. Více podrobností viz [Slide Master](/slides/cs/python-java/slide-master/) a [Embedded Font](/slides/cs/python-java/embedded-font/).

## **FAQ**

**Kdy bych měl použít low-code API místo plného objektového modelu?**

Používejte low‑code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje podrobnou kontrolu jednotlivých prvků. Použijte plný objektový model, pokud potřebujete vybrat konkrétní snímky, řídit vztahy mistr‑rozvržení, zkontrolovat mezistav nebo nastavit chování, které pomocník neodhaluje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/python-java/aspose.slides/merger/#process) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převeďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/python-java/aspose.slides/convert/#autoByExtension), a poté sloučte převedené soubory.

**Zpracovává ForEach mistry, rozvržení a snímky poznámek?**

[ForEach.slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#slide) iteruje přes normální snímky prezentace. Operace napříč celou prezentací [ForEach.shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#portion) zahrnují ve výchozím nastavení normální, mistr‑ a rozvržovací snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `True`, pokud chcete zahrnout i snímky poznámek.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/#shape) k okamžitému zpracování každého tvaru pomocí zpětného volání. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/collect/#shapes), když potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenší Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané mistry nebo vložené fonty s nepoužívanými znaky. Pokud žádné z těchto prvků nejsou, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) nemusí soubor zmenšit.

**Ukládají změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tito pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) v paměti. Po změně prvků v callbacku [ForEach](https://reference.aspose.com/slides/cs/python-java/aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) pro zápis výsledku.

## **Související články**

- [Convert Presentation](/slides/cs/python-java/convert-presentation/)
- [Merge Presentations](/slides/cs/python-java/merge-presentation/)
- [Slide Master](/slides/cs/python-java/slide-master/)
- [Manage Text Box](/slides/cs/python-java/manage-textbox/)
- [Embedded Font](/slides/cs/python-java/embedded-font/)