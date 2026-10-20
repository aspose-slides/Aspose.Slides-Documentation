---
title: Změna velikosti tvarů na snímcích prezentace v Javě
type: docs
weight: 130
url: /cs/java/resizing-shapes-on-slide/
aliases:
  - /cs/java/re-sizing-shapes-on-slide/
  /java/re-sizing-shapes-on-slide/
keywords:
- zmenšení tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na slidech PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu—automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, může být také nutné změnit velikost a pozicovat jeho tvary tak, aby zapadly do nových rozměrů. Tento článek ukazuje, jak ručně měřít tvary a jak pracovat s tabulkami na snímcích, hlavních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Aby se zachovala relativní pozice a velikost každého tvaru, vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho svislé souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na formát A4 a výsledek uloží. Používá [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila měřítko. Poměry jsou bezrozměrné; pozice tvarů a jejich rozměry jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru nezmění velikost jeho písma.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální koeficienty měřítka.
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
Tabulky vyžadují samostatné zacházení: je třeba měřít jejich šířky sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary v hlavních snímcích a rozvrženích i v jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocník zpracovává každý [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) měřením šířek sloupců pomocí [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) a minimální výšky řádků pomocí [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Poté měří pozici tabulky, aniž by samostatně měřil její celkové rozměry.

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
    // Vypočítejte nezávislé horizontální a vertikální koeficienty měřítka.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Změňte velikost tvarů definovaných v hlavních snímcích a rozvrženích i v jednotlivých snímcích.
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

Pokud změníte velikost snímku bez měřítka tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat mimo snímek. Měření šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady nemění velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Měřte šířky sloupců poměrem šířky a minimální výšky řádků poměrem výšky, poté změňte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto měřítko fungovat i pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) a každého hlavního snímku [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. Po změně velikosti snímku a před načtením cílových rozměrů zavolejte [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-), aby faktory měřítka odrážely konečnou orientaci.

**Existuje limit pro velikost snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Podporované rozměry také závisí na formátu prezentace a aplikaci, která soubor otevírá.

**Jak mohu zabránit deformaci tvarů se závazným poměrem stran?**

Použijte stejný faktor měřítka pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší ze dvou poměrů šířky a výšky pro obě rozměry i pozice. Tím se zachovají proporce, ale může zůstat nevyužitý prostor podél jedné hrany.