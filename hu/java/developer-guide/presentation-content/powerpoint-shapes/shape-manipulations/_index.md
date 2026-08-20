---
title: Prezentációs alakzatok kezelése Java-ban
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, klónozhat, eltávolíthat, elrejthet, átrendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) képviseli. A gyűjtemény egyben az a hely, ahol az alakzatokat megtalálja és módosítja, valamint a rétegzési sorrend forrása: a `0` indexű alakzat a leghátrább, míg az utolsó index a legelöl lévő alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan lehet megbízhatóan azonosítani egy alakzatot, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. Az utolsó szakaszok a sablon szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak az Ön munkafolyamatához szükséges műveleteket kell használnia.

## **Az alakzatok azonosítása és keresése**

A gyűjteményindexek hasznosak egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció elkészítési és karbantartási módja szerint:

- [Name](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) hasznos fejlesztő által kezelt sablonokhoz, és könnyen ellenőrizhető a PowerPoint Kijelölő ablaktáblájában. A neveket szerkeszthető, és nem garantált, hogy egyediek, ezért érdemes elnevezési konvenciót kialakítani, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getAlternativeText--) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy hozzáférhetőség-érdekében átírható, és nem garantált, hogy egyedi. Ne használja csendben a jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) egy csak olvasható azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat-azonosítónak. Használja, ha PowerPointtel integrál, vagy ha a forma életciklusa alatt egyértelmű hivatkozásra van szükség. Egy klónozott vagy újra létrehozott alakzat egy másik alakzat, és saját azonosítót kap.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getUniqueId--) metódus egy prezentáció-szintű azonosítót ad vissza, de ez az azonosító kiegészítőkhöz készült, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazás adataiban, és ellenőrizze, hogy a várt alakzat továbbra is létezik-e.

A következő példa név szerint keres pontos összehasonlítással, és a diára vonatkozó interop ID-t jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi, ahelyett, hogy a helytelen objektummal folytatná.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Amikor egy művelet alakzattípusra specifikus, ellenőrizze az interfészt, mielőtt típus-specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a névhez tartozó objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) típusú.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Az alakzatgyűjtemény módosítása**

A hozzáad, klónoz, eltávolít és átrendez módszerek azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) szintén másolatot készít, de egy meghatározott z-sorrend indexre helyezi. Az olyan túlterhelések, amelyek koordinátákat fogadnak, a klónt méret változtatása nélkül helyezik el; a szélesség és magasságot megadók átméretezhetik is.

A példa egy cél diát hoz létre, egy feliratot tartalmazó téglalapot klónoz a frontra, és egy második klónt illeszt be a hátulra. Bármelyik klón módosítása nem változtatja meg a forrás alakzatot.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A klónozás lemásolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, új logikai azonosítókat kell rendelni a klónhoz. Az összetett alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjteményelemként új alakzat-azonosítással jelenik meg.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) töröl egy konkrét alakzat objektumot a gyűjteményéből. Ha indexelt iteráció során több egyezést távolít el, járjon végig a gyűjteményen a végéről, hogy minden megmaradt index érvényes maradjon.

Ez a példa minden, a megadott névvel ellátott alakzatot eltávolít. Az aktuális indexnél lévő alakzatot olvassa, nem egy rögzített gyűjteményelemet, és nem kényszeríti a típuskonverziót feleslegesen.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eltávolítás után az alakzatok száma és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak a mentett indexeknél. Vegye számításba a csatlakozókat, animációkat és egyéb prezentációs elemeket is, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több változást is okozhat, mint csak a dia megjelenése.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setHidden-boolean-) `true` értékre állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma a kód számára továbbra is elérhető, így az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és újra láthatóvá tehető felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **A Z-sorrend módosítása**

Egymásra fedő alakzatok a gyűjteménysorrendben vannak megrajzolva. A [reorder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) meglévő alakzatot egy célindexre helyezi klónozás nélkül. A `0` index a hátul; a `size() - 1` az elöl.
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A téglalap először jön létre, és eleinte az ellipszis mögött helyezkedik el. A végső indexre mozgatva a frontra kerül. A Z-sorrendet az összes kapcsolódó alakzat hozzáadása vagy klónozása után kell befejezni, mivel ezek a műveletek új gyűjteményelemeket fűznek hozzá vagy illesztenek be, és megváltoztathatják a kívánt rétegelést.

## **Elrendezési diák alakzatainak vizsgálata**

A normál diák, az elrendezési diák és a mesterdiák külön alkotzatgyűjteménnyel rendelkeznek. Egy alakzat az elrendezési gyűjteményben nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Az elrendezési alakzatokat akkor kell vizsgálni, amikor meg kell érteni vagy megváltoztatni a layout által biztosított formázást.

A következő példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFillFormat--) és [LineFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getLineFormat--) értékét olvassa anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Egy elrendezés szerkesztése több diát is befolyásolhat, amely használja azt. Az elrendezési alakzat módosítása előtt határozza meg, hogy egy normál dia örökli-e az objektumot vagy helyi felülírással rendelkezik-e, és tesztelje az összes olyan diát, amely az adott elrendezést használja.

## **Alakzat exportálása SVG-be**

[writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) egy alakzat renderelt tartalmát írja egy streambe. Az eredmény az alakzatot tartalmazza, nem az egész dia háttérjét vagy a környező alakzatokat.
```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

A renderelés közben tartsa nyitva a prezentációt. A kimenet az alakzat formázását és olyan erőforrásokat, mint betűtípusok és képek, függő. Ha a teljes kompozícióra van szükség, exportálja a diát, nem egyetlen alakzatot. A hívó birtokolja a streamet, és be kell zárnia azt.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) túlterhelései vagy az összes alakzatot, vagy a kijelölt gyűjtemény indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapesalignmenttype/) meghatározza a szélt, középső vonalat vagy elosztási módot. A `alignToSlide` beállítás `true` értéke a diák széleit használja; `false` esetén a kijelölt alakzatok egymáshoz viszonyított igazítását végzi.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszakapott alakzatreferenciákat az igazítás előtt az aktuális indexeikre konvertálja.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az igazítás a pozíciókat változtatja, nem a Z-sorrendet. A relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell a távolság meghatározásához. Ha a gyűjteményt módosítja a metódus hívása előtt, újra kell számolnia az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `getFlipH` és `getFlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/java/com.aspose.slides/nullablebool/) használatával: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megtartja a nem definiált/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.
![A forma a tükrözés előtt](shape_to_be_flipped.png)

A példa megőrzi az összes többi keretértéket, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) hozzárendelése a teljes keretet felülírja.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megőrzi a pozícióját, méretét és forgását.
![A forma a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjteményindexet alakzat-azonosítóként?**

Csak rövid élettartamú feldolgozáshoz, amikor a gyűjtemény nem változik az index használata előtt. Inkább egy ellenőrzött `Name` vagy `AlternativeText` konvenciót használjon szerkesztett sablonokhoz, vagy `OfficeInteropShapeId`-t a dia‑szintű interop munkához.

**Eltávolítja-e az elrejtett alakzat a Z-sorrendből?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

`addClone` a klónt a gyűjtemény végére fűzi, ami a Z-sorrend frontjának felel meg. Használja az `insertClone`‑t a kezdeti index kiválasztásához, vagy a `reorder`‑t az összes alakzat hozzáadása után.