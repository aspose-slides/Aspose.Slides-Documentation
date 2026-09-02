---
title: Androidra vonatkozó prezentációs alakzatok kezelése
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/androidjava/shape-manipulations/
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
- alakzat SVG-re
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet azonosítani, klónozni, eltávolítani, elrejteni, átrendezni, exportálni, igazítani és tükrözni a prezentációs alakzatokat az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Android via Java a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) formájában reprezentálja. A gyűjtemény egyben azon a hely, ahol alakzatokat kereshet és módosíthat, valamint a rétegezési sorrend forrása: a `0` indexű alakzat a legháttalibb, míg az utolsó indexű a legelőlibb.

Ez a cikk e modell szerint jár el. Először bemutatja, hogyan lehet megbízhatóan azonosítani egy alakzatot, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. A végső szakaszok a layout szintű formázást, SVG exportot, igazítást és tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

Gyűjtemény indexek kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon egy azonosítót a bemutató létrehozásának és karbantartásának módja szerint:

- [Name](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) hasznos fejlesztő-vezérelt sablonoknál, és könnyen ellenőrizhető a PowerPoint Kijelölés panelen. A nevek szerkeszthetők és nem garantált a egyediség, ezért állítson fel egy elnevezési konvenciót, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getAlternativeText--) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átfogalmazható a hozzáférhetőség miatt, és nem garantált a egyediség. Ne használja csendben jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) egy csak olvasható azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzatazonosítónak. Használja, ha PowerPointtal integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat életciklusa során. Egy klónozott vagy újra létrehozott alakzat másik alakzat, és saját azonosítót kap.

Az ehhez kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getUniqueId--) metódus egy, a bemutatóra vonatkozó azonosítót ad vissza, de ez az azonosító kiegészítők számára készült, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú identitásra van szükség, tartsa a leképezést az alkalmazás adataiban, és ellenőrizze, hogy a várt alakzat még létezik-e.

Az alábbi példa név alapján pontos összehasonlítással keres, és visszaadja a diára vonatkozó interop ID-t. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi, ahelyett, hogy a hibás objektummal folytatná.

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

Amikor egy művelet alakzattípustól függ, ellenőrizze az interfészt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a név alapján megtalált objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/).

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

## **Alakzatgyűjtemény módosítása**

Az add, clone, remove és reorder metódusok azonnal a gyűjteményen működnek. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább az előzőleg rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) szintén másolatot hoz létre, de egy megadott z‑sorrend indexre helyezi. A koordinátákat elfogadó túlterhelések a klónt áthelyezik a méret változtatása nélkül; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa létrehoz egy cél diát, egy címkézett téglalapot klónoz a frontra, és a hátulra helyez egy második klónt. Bármely klón változtatása nem módosítja a forrás alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek egyedinek kell lenniük, új logikai azonosítókat kell adni a klónnak. A komplex alakzatok által használt erőforrásokat a bemutató kezeli, de a klón egy új gyűjteményelemként új alakzatidentitással jelenik meg.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) egy adott alakzat objektumot töröl a gyűjteményéből. Több egyező eltávolításakor indexelt iteráció során haladjon a vég felől, hogy a maradt indexek érvényesek maradjanak.

Ez a példa eltávolít minden olyan alakzatot, amely meghatározott névvel rendelkezik. A jelenlegi indexnél lévő alakzatot olvassa, nem egy fix gyűjteményelemnél, és nem végez felesleges castot.

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

Eltávolítás után az alakzatok száma és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye számításba továbbá a kapcsolókat, animációkat és egyéb bemutatóelemeket, amelyek a eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több változást is okozhat, mint csak a dia megjelenését.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) `true` értékre állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál előadásban megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kódból, ezért az elrejtés alkalmas opcionális elemek számára, amelyek később visszaállíthatók.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és visszafejthető felhasználó vagy kód által, és része marad a bemutató fájlnak.

### **Z‑sorrend módosítása**

A átfedő alakzatok a gyűjtemény sorrendje szerint vannak megrajzolva. A [reorder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) egy meglévő alakzatot a cél indexre mozgat klónozás nélkül. A `0` index a hátul, a `size() - 1` az elöl.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A téglalap először létre van hozva, és kezdetben az ellipszis mögött helyezkedik el. A végső indexre történő áthelyezése az elől szerepléshez vezet. A z‑sorrendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsa be, mivel ezek a műveletek új gyűjteményelemeket fűznek hozzá vagy szúrnak be, és módosíthatják a kívánt halmozást.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, az elrendezési diák és a mesterdiák külön alakzategyüttesekkel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló helyen lévő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha meg kell érteni vagy meg kell változtatni egy elrendezés által biztosított formázást.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFillFormat--) és [LineFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getLineFormat--) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

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

Az elrendezés szerkesztése több diát is érinthet, amelyik használja. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örököl‑e az objektumot vagy helyi felülbírálást tartalmaz, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑be**

[writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) egy alakzat renderelt tartalmát írja ki egy streambe. Az eredmény csak az alakzatot tartalmazza, nem az egész dia háttérét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a bemutatót a renderelés közben. A kimenet az alakzat formázásától és olyan erőforrásoktól függ, mint a betűtípusok és képek. Ha a teljes kompozícióra van szükség, exportálja a diát, nem egyetlen alakzatot. A hívó sajátja a streamet, és be kell zárnia.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapesalignmenttype/) meghatározza a szél, középvonal vagy elosztási módot. Állítsa az `alignToSlide` értékét `true`‑ra, hogy a dia széleit használja; `false` esetén a kiválasztott alakzatokat egymáshoz viszonyítva igazítja.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszaadott alakzathivatkozásokat közvetlenül igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás a pozíciókat változtatja, nem a z‑sorrendet. A relatív igazítás általában legalább két alakzatot igényel, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell legyen a távolság meghatározásához. Számolja újra az indexeket, ha a gyűjteményt módosítja a metódus hívása előtt.

## **Alakzat tükrözése**

[ShapeFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `getFlipH` és `getFlipV` értékei a [NullableBool](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/) használatával működnek: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemeneti bemutató egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa megőrzi minden egyéb keretértéket, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény indexet alakzatazonosítóként?**

Csak rövid életű feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítsen egy ellenőrzött `Name` vagy `AlternativeText` konvenciót a szerkesztett sablonoknál, vagy `OfficeInteropShapeId`‑t a diára vonatkozó interop munkához.

**Eltávolítja-e a rejtett alakzat a z‑sorrendből?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑sorrend eleje. Használja az `insertClone`‑t a kezdeti index kiválasztásához, vagy a `reorder`‑t minden alakzat hozzáadása után.