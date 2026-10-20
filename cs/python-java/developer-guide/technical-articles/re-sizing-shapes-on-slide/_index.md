---
title: Změna velikosti tvarů na snímcích prezentace v Pythonu přes Java
type: docs
weight: 110
url: /cs/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/zmensovani-tvaru-na-snimku/
  - /cs/python-java/re-sizing-shapes-on-slide/
keywords:
- zmenšit tvar
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java—automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, možná budete také potřebovat změnit velikost a přesunout její tvary, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně měnit velikost tvarů a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Chcete‑li zachovat relativní polohu a velikost každého tvaru, vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na A4 a výsledek uloží. Používá [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila měřítko. Poměry jsou bez jednotek; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru nemění měřítko velikosti písma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Vypočítejte nezávislé horizontální a vertikální faktory měřítka.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují samostatné zpracování: měřte šířky jejich sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší než požadované, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na hlavních snímcích a rozvrženích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocník zpracovává každou [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) měřením šířek sloupců pomocí [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) a minimální výšky řádků pomocí [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Poté měří pozici tabulky, aniž by samostatně měřil její celkové rozměry.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Vypočítejte nezávislé horizontální a vertikální faktory měřítka.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Změňte velikost tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformovány nebo oříznuty?**

Pokud změníte velikost snímku bez měřítka tvarů, zachovají si své původní polohy a rozměry a mohou přesahovat přes okraj snímku. Měřítko šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady nemění velikost písma a obsah tabulky může omezovat výšku řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Změřte šířky sloupců pomocí poměru šířky a minimální výšky řádků pomocí poměru výšky, poté změřte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat i pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) a [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) každého hlavního snímku a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/na šířku) spolu se změnou velikosti?**

Ano. Po změně velikosti snímku a před načtením cílových rozměrů zavolejte [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation), aby měřítkové faktory odrážely konečnou orientaci.

**Existuje omezení velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Podporované rozměry také závisí na formátu prezentace a na aplikaci použité k otevření souboru.

**Jak mohu zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný měřítkový faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší ze šířkových a výškových poměrů pro obě rozměry a pozice. To zachová proporce, ale může zanechat nevyužitou oblast podél jedné hrany.