---
title: Prezentációs alakzatok kezelése Androidon
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
- alakzat beállítási pont
- előre meghatározott alakzat beállítása
- alakzat geometria
- alakzat elrendezés formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, módosíthat, klónozhat, eltávolíthat, elrejthet, újrarendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

Aspose.Slides for Android via Java egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) formájában képviseli a dián lévő alakzatokat. A gyűjtemény egyben az a hely, ahol alakzatokat találhat és módosíthat, valamint a rétegzési sorrend forrása: a `0` indexű alakzat a leghátrul lévő, míg az utolsó index a legelöl álló alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan lehet egy alakzatot megbízhatóan azonosítani és előre meghatározott alakzat‑állítási pontokat módosítani, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és újrarendezni az alakzatokat. Az utolsó szakaszok a diatervezési szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató szerkesztési és karbantartási módja alapján:

- [Name](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) hasznos fejlesztő által vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint **Selection Pane**‑jében. A nevek szerkeszthetők, de nem garantált, hogy egyediek, ezért vegyen fel egy elnevezési konvenciót, ha a kód enkre támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getAlternativeText--) akkor hasznos, ha egy hozzáférhetőségi leírás vagy egy szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható, illetve átírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben az értelmes hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) egy csak‑olvasású azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat‑azonosítónak. Használja, ha PowerPoint‑tal integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama alatt. Egy klónozott vagy újból létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getUniqueId--) metódus egy bemutató‑szintű azonosítót ad vissza, de ez az azonosító kiegészítők számára készült, és újra kiosztható. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú identitásra van szükség, tárolja a leképezést az alkalmazás‑adatokban, és ellenőrizze, hogy a várt alakzat továbbra is létezik‑e.

Az alábbi példa név szerint keres pontos egyezéssel, és a diára vonatkozó interop‑azonosítót jelzi. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti, ahelyett, hogy a hibás objektummal folytatná.

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

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze a felületet a típus‑specifikus tagok használata előtt. Ez a példa szöveget és alternatív szöveget frissít csak akkor, ha a név szerint keresett objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/).

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

## **Előre meghatározott alakzat‑állítások azonosítása és módosítása**

Az előre meghatározott geometriai alakzatok felhasználhatók olyan beállítási pontokkal, amelyek a sarokméretet, nyíl arányokat vagy ív szögeket szabályozzák. Ezeket a csak‑olvasású [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) gyűjteményén keresztül érheti el. Maga a gyűjtemény az alakzattól származik, de minden [IAdjustValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/) egy módosítható értéket tartalmaz.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Iteráljon a beállításokon, és vizsgálja meg a csak‑olvasású [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getType--) metódust, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz a beállítás. A csak‑olvasású [getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getName--) metódus további azonosító információt ad, és különösen hasznos, ha egy előre meghatározott alakzat több azonos szemantikai típussal rendelkező beállítást tartalmaz.

Használja a beállítás jelentésének megfelelő érték‑metódust:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | A lekerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Nyíl farok vastagsága | `setRawValue` |
| `ArrowheadLength` | Nyílhegy hossza | `setRawValue` |
| `ArrowheadWidth` | Nyílhegy szélessége | `setRawValue` |
| `StartAngle` | Körszelet vagy ív kezdő szöge | [setAngleValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Körszelet vagy ív záró szöge | `setAngleValue` |

A `getType` és a `getName` csak‑olvasású információt ad. A `getRawValue` és a `setRawValue` egy egész számot használ a beállítás natív geometriai egységeiben, míg a `getAngleValue` és a `setAngleValue` fokban megadott szöget kezel. A beállítások száma, sorrendje, jelentése és érvényes tartománya a beállított [ShapeType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)‑tól függ. Egy presethez érvényes érték egy másik presetnél érvénytelen lehet vagy más hatást eredményezhet.

Ha a `getType` visszaadja a `ShapeAdjustmentType.Custom` értéket, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `getName`‑et, a preset típusát és a jelenlegi értéket, és csak akkor módosítsa a beállítást, ha a várt jelentés és tartomány ismert. Még a felismert típusoknál is ellenőrizze, hogy ugyanaz a típus többször előfordul‑e, mielőtt egy értéket választana. A [Connector](/slides/hu/androidjava/connector/) cikk bemutatja ezt a helyzetet a csatlakozó‑görbületek esetén.

Az alábbi teljes példa három előre meghatározott alakzat alap‑ és módosított változatát hozza létre. Iterál minden beállításon, jelzi a nevét és típusát, `setRawValue`‑val méret‑kapcsoló értékeket, `setAngleValue`‑val szögeket változtat, és menti az eredményt. A bal oszlop az alap geometria, a jobb oszlop a módosított lekerekített téglalapot, a négyszögletű nyilat és a szelet mutatja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fejlécek hozzáadása az alapértelmezett és a módosított alakzatoszlopokhoz.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑indexnek ugyanazt a jelentést tulajdonítsuk különböző preset alakzatoknál.

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és újrarendezés metódusai azonnal a gyűjteményen hatnak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon az előzőleg rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) egy független másolatot hoz létre, és a célgyűjteményhez fűzi. [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) szintén másolatot készít, de egy meghatározott z‑sorrend‑indexhez helyezi. A koordinátákat elfogadó túlterhelések a méretet nem változtatják; a szélesség‑ és magasság‑paraméteres változatok átméretezhetik is.

A példa egy cél‑diát hoz létre, egy feliratos téglalapot klónoz elölre, és egy második klónozatot szúr be hátulra. Az egyik klónozat módosítása nem változtatja meg a forrás‑alakzatot.

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

A klónozás átmásolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A bonyolult alakzatok által használt erőforrásokat a bemutató kezeli, de a klón egy új gyűjtemény‑elem, új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) egy adott alakzat objektumot töröl a saját gyűjteményéből. Több egyező elem eltávolításakor indexelt iteráció során haladjon a vég felől, hogy a fennmaradó indexek érvényben maradjanak.

Ez a példa minden kijelölt névű alakzatot eltávolít. A jelenlegi indexnél lévő alakzatot olvassa, nem egy rögzített gyűjtemény‑elemet, és nem végez felesleges cast‑et.

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

Eltávolítás után a alakzatszám és a későbbi alakzatok indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a korábban elmentett indexek. Vegye figyelembe a csatlakozókat, animációkat és egyéb bemutató‑elemeket, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása a dia megjelenésén túl is változást idézhet elő.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés alkalmas opcionális elemekhez, amelyek később visszaállíthatók.

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

Az elrejtés nem törlés vagy biztonsági funkció. Az objektum továbbra is felfedezhető és visszakapcsolható felhasználó vagy kód által, és része marad a bemutatófájlnek.

### **Z‑rend átalakítása**

A átfedő alakzatok a gyűjtemény sorrendjében kerülnek felvitelre. [reorder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) egy meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. A `0` index a hátul, a `size() - 1` az elöl.

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

A téglalap először létrejön, és eleinte az ellipsz mögött helyezkedik el. A végső indexre mozgatásával előre kerül. Z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsa be, mivel ezek a műveletek új gyűjtemény‑elemeket fűznek hozzá vagy szúrnak be, és módosíthatják a kívánt rétegsorrendet.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, az elrendezési diák és a mester diák különálló alakzat‑gyűjteményekkel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezkedő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, amikor a formázást kell megértenie vagy módosítania, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFillFormat--) és [LineFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getLineFormat--) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több diára is hatással lehet, amelyik használja azt. Mielőtt egy elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökölte‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑ként**

[writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) egy alakzat renderelt tartalmát írja ki egy folyamra. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a bemutatót a renderelés alatt. A kimenet az alakzat formázásától, valamint a betűkészletek és képek erőforrásaitól függ. Ha a teljes kompozícióra van szükség, exportálja a diát, ne pedig az egyes alakzatot. A hívó a folyamatot felhasználja, és saját maga kell, hogy lezárja azt.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapesalignmenttype/) megadja a szél, középpont vagy elosztási módot. Az `alignToSlide`‑t `true`‑ra állítva a dia széleit használja; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszakapott alakzat‑hivatkozásokat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás pozíciókat változtat, nem a z‑rendet. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő számú alakzat kell a távolság meghatározásához. Ha a metódus hívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `getFlipH` és `getFlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/)‑t használják: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemutató egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megtart, csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) hozzárendelése felülírja a teljes keretet.

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

A mentett alakzat vízszintesen és függőlegesen tükrözve jelenik meg, miközben megőrzi a pozíciót, méretet és forgást.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat azonosítóként?**

Csak rövid életű feldolgozás esetén, amikor a gyűjtemény nem változik az index használata előtt. A szerkesztett sablonokhoz validált `Name` vagy `AlternativeText` konvenciót, a diára vonatkozó interop munkához pedig `OfficeInteropShapeId`‑t részesítsen előnyben.

**Eltávolítja-e a rejtett alakzat a z‑rendet?**

Nem. A rejtett alakzat a gyűjteményben marad ugyanazzal az indexszel. Megtalálható, újrarendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend első helye. Használja az `insertClone`‑t a kezdeti index megadásához, vagy az `reorder`‑t az összes alakzat hozzáadása után.

**Használhatok rögzített indexet egy előre meghatározott alakzat‑állítás azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény‑elrendezést előzetesen ellenőrizte. Inkább iteráljon a `IGeometryShape.getAdjustments`‑on, és ellenőrizze a `IAdjustValue.getType`‑t; ha ugyanaz a szemantikai típus többször fordul elő, használja a `IAdjustValue.getName`‑t további információként.