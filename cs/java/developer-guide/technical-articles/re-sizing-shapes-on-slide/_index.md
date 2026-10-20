---
title: Změna velikosti tvarů na snímcích prezentace v Javě
type: docs
weight: 130
url: /cs/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /cs/java/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java—automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, možná budete muset také změnit velikost a přemístit její tvary, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně škálovat tvary a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Pro zachování relativní polohy a velikosti každého tvaru vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na A4 a výsledek uloží. Používá [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila škálování. Poměry jsou bez jednotek; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikost písma.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Vypočítat nezávislé horizontální a vertikální škálovací faktory.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují zvláštní zacházení: škálujte šířky jejich sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na hlavních snímcích a rozvrženích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocník zpracovává každý [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) škálováním šířek sloupců pomocí [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) a minimálních výšek řádků pomocí [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Poté škáluje pozici tabulky bez samostatného škálování jejích celkových rozměrů.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Vypočítat nezávislé horizontální a vertikální škálovací faktory.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Změnit velikost tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zachází s tabulkami samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců podle poměru šířky a minimální výšky řádků podle poměru výšky, poté škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto škálování fungovat pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) a [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) každého hlavního snímku a používá stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku / na šířku) spolu se změnou velikosti?**

Ano. Po změně velikosti snímku a před načtením cílových rozměrů zavolejte [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-), aby škálovací faktory odrážely konečnou orientaci.

**Existuje limit na velikost snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Podporované rozměry také závisí na formátu prezentace a na aplikaci, která soubor otevře.

**Jak zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný škálovací faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro oba rozměry i pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.