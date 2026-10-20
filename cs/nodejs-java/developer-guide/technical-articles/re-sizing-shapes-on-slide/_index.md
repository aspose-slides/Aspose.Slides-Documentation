---
title: Změna velikosti tvarů na slidech prezentace v Node.js
type: docs
weight: 130
url: /cs/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /cs/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- úprava velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na slidech PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js v Javě — automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku v prezentaci, možná budete také muset změnit velikost a umístění jejích tvarů, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně škálovat tvary a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrzích.

## **Změna velikosti tvarů**

Pro zachování relativní polohy a velikosti každého tvaru vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují žádné tabulky, změní velikost snímku na formát A4 a výsledek uloží. Používá [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale), aby následná smyčka řídila škálování. Poměry jsou bez jednotek; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary zkreslit a změna rozměrů tvaru neskaluje velikost písma.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
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
Tabulky vyžadují zvláštní zpracování: škálujte jejich šířky sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na hlavních snímcích a rozvrzích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocná metoda zpracovává každou [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) škálováním šířek sloupců pomocí [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) a minimálních výšek řádků pomocí [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Poté škáluje pozici tabulky, aniž by samostatně škálovala její celkové rozměry.

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
    // Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Změňte velikost tvarů definovaných na hlavních snímcích a rozvrzích i na jednotlivých snímcích.
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

**Proč jsou tvary po změně velikosti snímku zkreslené nebo oříznuté?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary zkreslit.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky odděleně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikosti písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Šířky sloupců škálujte pomocí poměru šířky a minimální výšky řádků pomocí poměru výšky, poté škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat pro hlavní snímky a rozvrhové snímky?**

Ano. Druhý příklad prochází [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) a [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) každého hlavního snímku a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/v šířku) spolu se změnou velikosti?**

Ano. Zavolejte [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) po změně velikosti snímku a před načtením cílových rozměrů, aby faktory měřítka odrážely konečnou orientaci.

**Existuje limit velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Podporované rozměry také závisí na formátu prezentace a aplikaci používané k otevření souboru.

**Jak mohu zabránit tomu, aby tvary s pevným poměrem stran byly zkreslené?**

Použijte stejný faktor měřítka pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro oba rozměry a pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.