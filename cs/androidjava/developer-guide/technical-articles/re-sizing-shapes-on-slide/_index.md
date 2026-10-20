---
title: Změna velikosti tvarů na snímcích prezentace v Androidu
type: docs
weight: 130
url: /cs/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Android
- Aspose.Slides
description: "Snadno změňte velikost tvarů na snímcích PowerPoint a OpenDocument s Aspose.Slides pro Android pomocí Javy – automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, možná budete také muset změnit velikost a upravit umístění jejích tvarů, aby se vešly do nových rozměrů. Tento článek ukazuje, jak ručně měřit tvaru a jak zacházet s tabulkami na snímcích, předlohách a rozvrženích.

## **Změna velikosti tvarů**

Aby se zachovala relativní pozice a velikost každého tvaru, vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šířce. Na svislé souřadnice a výšku použijte odpovídající poměr výšky.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na A4 a uloží výsledek. Používá [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila škálování. Poměry jsou bez jednotek; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikost písma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
Tabulky vyžadují samostatné zpracování: škálujte šířky jejich sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na předlohách a rozvrženích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocná metoda zpracovává každý [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) škálováním šířek sloupců pomocí [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) a minimálních výšek řádků pomocí [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Poté škáluje pozici tabulky, aniž by samostatně škálovala její celkové rozměry.

```java
import com.aspose.slides.*;

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
    // Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Změňte velikost tvarů definovaných na hlavních snímcích a rozvrzích i na jednotlivých snímcích.
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

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat přes snímek. Škálování šířky a výšky odlišnými poměry může také tvary deformovat.

**Funguje poskytovaný kód pro všechny typy tvarů?**

První příklad mění ohraničení tvarů přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změnit velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců podle poměru šířky a minimální výšky řádků podle poměru výšky, poté škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto škálování fungovat pro hlavní snímky a rozvržené snímky?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) a každou předlohu pomocí [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. Zavolejte [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) po změně velikosti snímku a před načtením cílových rozměrů, aby faktory škálování odrážely finální orientaci.

**Existuje omezení velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Podporované rozměry také závisí na formátu prezentace a na aplikaci použité k otevření souboru.

**Jak zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný škálovací faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro obě rozměry i pozice. To zachová proporce, ale může zanechat nevyužité místo podél jedné hrany.