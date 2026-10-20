---
title: Změna velikosti tvarů na snímcích prezentace v Node.js
type: docs
weight: 130
url: /cs/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/zmenovani-tvaru-na-snimku/
keywords:
- změnit velikost tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Java – automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, možná budete také muset změnit velikost a přesunout její tvary, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně měřítkovat tvary a jak pracovat s tabulkami na snímcích, předlohách a rozvrženích.

## **Změna velikosti tvarů**

Aby se zachovala relativní poloha a velikost každého tvaru, vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šířce. Na svislé souřadnice a výšku použijte odpovídající poměr výšky.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na A4 a uloží výsledek. Používá [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila měřítko. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru nemění měřítko velikosti písma.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují samostatné zpracování: škálujte jejich šířky sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na předlohách a rozvrženích i na jednotlivých snímcích před uložením upravené prezentace. Jeho pomocná metoda zpracovává každou [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) škálováním šířek sloupců pomocí [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) a minimální výšky řádků pomocí [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Poté škáluje pozici tabulky, aniž by samostatně měřil její celkové rozměry.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Změňte velikost tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Pokud změníte velikost snímku bez měřítkování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat okraj snímku. Měřítkování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvarů přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady nemění velikost písma a obsah tabulky může omezit výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců pomocí poměru šířky a minimální výšky řádků pomocí poměru výšky, pak škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto měřítko fungovat i pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) a každou [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. Volání [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) po změně velikosti snímku a před načtením cílových rozměrů zajistí, že měřítka odrážejí finální orientaci.

**Existuje limit pro velikost snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Podporované rozměry také závisí na formátu prezentace a aplikaci použité k otevření souboru.

**Jak mohu zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný měřítkový faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů použijte menší z poměrů šířky a výšky pro obě rozměry a pozice. To zachová proporce, ale může ponechat nevyužité místo podél jedné hrany.