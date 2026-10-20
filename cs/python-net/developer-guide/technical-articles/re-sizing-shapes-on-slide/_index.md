---
title: Změna velikosti tvarů na snímcích prezentace v Pythonu
type: docs
weight: 130
url: /cs/python-net/resizing-shapes-on-slide/
aliases:
  - /cs/python-net/re-sizing-shapes-on-slide/
keywords:
- zmenit velikost tvaru
- zmenit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET - automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, možná budete také potřebovat změnit velikost a přemístit jeho tvary, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně škálovat tvary a jak zacházet s tabulkami na snímcích, předlohách a rozvrzích.

## **Změna velikosti tvarů**

Aby se zachovala relativní poloha a velikost každého tvaru, vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na A4 a výsledek uloží. Používá [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) s [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/), aby následná smyčka řídila škálování. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikosti písma.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují samostatné zpracování: škálujte jejich šířky sloupců a výšky řádků místo přiřazování celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na předlohách a rozvrzích stejně jako jednotlivé snímky před uložením změněné velikosti prezentace. Jeho pomocná funkce zpracovává každou [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) škálováním [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) a [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Poté škáluje pozici tabulky, aniž by samostatně škálovala její celkové rozměry.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Změňte velikost tvarů definovaných na hlavních snímcích a rozvrzích i na jednotlivých snímcích.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformovány nebo oříznuty?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat mimo snímek. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění hranice tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikosti písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců poměrem šířky a minimální výšky řádků poměrem výšky, poté škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto změnění velikosti fungovat pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) a každou [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/na šířku) spolu s změnou velikosti?**

Ano. Nastavte [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby škálovací faktory odrážely konečnou orientaci.

**Existuje limit velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Podporované rozměry také závisí na formátu prezentace a na aplikaci použité k otevření souboru.

**Jak mohu zabránit, aby tvary s pevným poměrem stran byly deformovány?**

Použijte stejný škálovací faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky jak pro rozměry, tak pro pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.