---
title: Alakzatok átméretezése a prezentációs diákon
type: docs
weight: 110
url: /hu/java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Java segítségével—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Az Aspose.Slides for Java ügyfelei leggyakrabban azt kérdezik, hogyan lehet átméretezni az alakzatokat úgy, hogy a dia méretének változása esetén az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan lehet ezt megvalósítani.

## **Alakzatok átméretezése**

Az alakzatok eltolódásának elkerülése érdekében, amikor a dia mérete változik, frissíteni kell minden alakzat pozícióját és méreteit, hogy azok megfeleljenek az új diaelrendezésnek.

```java
// Töltsd be a prezentációs fájlt.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Szerezd meg az eredeti dia méretét.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Módosítsd a dia méretét a meglévő alakzatok skálázása nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Szerezd meg az új dia méretét.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Átméretezd és áthelyezd az alakzatokat minden dián.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Skálázd az alakzat méretét.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skálázd az alakzat pozícióját.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
Ha egy dián táblázat is szerepel, a fenti kód nem fog helyesen működni. Ebben az esetben a táblázat minden celláját át kell méretezni.
{{% /alert %}} 

Használja a következő kódot a saját oldalon a táblázatot tartalmazó diák átméretezéséhez. A táblázatoknál a szélesség vagy magasság beállítása speciális eset: egyedi sormagasságokat és oszlopszélességeket kell módosítani a táblázat teljes méretének megváltoztatásához.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Szerezd meg az eredeti dia méretét.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Módosítsd a dia méretét a meglévő alakzatok skálázása nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Szerezd meg az új dia méretét.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Skálázd az alakzat méretét.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skálázd az alakzat pozícióját.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Skálázd az alakzat méretét.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Skálázd az alakzat pozícióját.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Skálázd az alakzat méretét.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skálázd az alakzat pozícióját.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

A dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezést nem módosítják kifejezetten. Ez tartalomlevágáshoz vagy alakzatok eltolódásához vezethet.

**Működik a megadott kód minden alakzattípusra?**

Az egyszerű példa a legtöbb alakzattípusra (szövegdobozok, képek, diagramok stb.) alkalmazható. Azonban táblázatok esetén a sorokat és oszlopokat külön kell kezelni, mivel a táblázat magassága és szélessége az egyes cellák méreteiből adódik.

**Hogyan lehet átméretezni a táblázatokat a dia átméretezésekor?**

A táblázat összes sorát és oszlopát át kell iterálni, és a magasságukat illetve szélességüket arányosan kell átméretezni, ahogyan a második kódrészletben látható.

**Ez az átméretezés működik-e mesterdiákon és elrendezési diákon?**

Igen, de a [Mesterek](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasters--) és a [Elrendezési diák](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getLayoutSlides--) is be kell járni, és ugyanazt a méretezési logikát alkalmazni kell az ő alakzataikra is, hogy a teljes bemutató konzisztens maradjon.

**Megváltoztathatom a dia tájolását (álló/landscape) az átméretezés közben?**

Igen. Használhatja a [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#setOrientation-int-) metódust a tájolás módosításához. Győződjön meg róla, hogy a méretezési logikát ennek megfelelően állítja be a layout megőrzéséhez.

**Van korlátozás a beállítható dia méretre?**

Az Aspose.Slides egyéni méreteket támogat, de a nagyon nagy méretek befolyásolhatják a teljesítményt vagy a kompatibilitást egyes PowerPoint-verziókkal.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

A méretezés előtt ellenőrizze a forma `getAspectRatioLocked` metódusát. Ha zárolt, a szélességet vagy magasságot arányosan kell módosítani, ahelyett, hogy egyenként skálázná őket.