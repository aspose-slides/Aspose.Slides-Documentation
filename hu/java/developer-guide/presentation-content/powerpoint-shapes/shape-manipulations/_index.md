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
- alakzat korrekciós pontja
- előre definiált alakzat korrekció
- alakzat geometriája
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthatja, módosíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentációs alakzatokat az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Java a dián található alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/)‑ként ábrázolja. A gyűjtemény egyszerre a hely, ahol alakzatokat keresünk és módosítunk, és a rétegezési sorrend forrása: a `0` indexű alakzat a leghátsó, míg az utolsó indexű a legelülső.

Ez a cikk ezen a modell alapján épül fel. Először bemutatja, hogyan azonosíthatunk egy alakzatot megbízhatóan és módosíthatjuk az előre beállított alakzat‑korrekciós pontokat, majd megmutatja, hogyan klónozhatunk, távolíthatunk el, rejthetünk el és rendezhetünk át alakzatokat. Az utolsó szakaszok a layout‑szintű formázást, az SVG‑exportálást, a igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatodhoz szükséges műveleteket használhatod.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válassz azonosítót a prezentáció elkészítésének és karbantartásának módja alapján:

- [Name](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) hasznos fejlesztői irányítású sablonoknál, és könnyen ellenőrizhető a PowerPoint Kijelölés ablaktáblájában. A neveket szerkesztheted, de nem garantált a egyediségük, ezért ha a kód rá támaszkodik, alakíts ki egy elnevezési konvenciót.
- [AlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getAlternativeText--) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átirható a hozzáférhetőség javítása érdekében, és nem garantált az egyediség. Ne használd csendben adatbáziskulcsként egy jelentős hozzáférhetőségi szöveget.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) egy csak‑olvasású azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat‑azonosítónak. Használd, ha PowerPoint‑integrációt valósítasz meg, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama alatt. Egy klónozott vagy újra‑létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getUniqueId--) metódus egy prezentáció‑szintű azonosítót ad vissza, de azt a kiegészítők használják, és újra‑hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tárold a leképezést az alkalmazás adataiban, és ellenőrizd, hogy a várt alakzat még létezik‑e.

Az alábbi példa név szerint keres egy pontos egyezést, és a diára vonatkozó interop‑azonosítót adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt jelzi, ahelyett, hogy a hibás objektummal folytatná.

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

Ha egy művelet alakzat‑típus‑specifikus, ellenőrizd a felületet, mielőtt típus‑specifikus tagokat használnál. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a név‑szerint megtalált objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/).

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

## **Előre definiált alakzat‑korrekciók azonosítása és módosítása**

Az előre definiált geometriai alakzatok olyan korrekciós pontokat fedhetnek fel, amelyek például a sarokméretet, a nyíl arányait vagy az ív szögeit vezérlik. Ezeket a csak‑olvasású [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igeometryshape/#getAdjustments--) gyűjteményen keresztül érheted el. A gyűjteményt maga az alakzat biztosítja, de minden [IAdjustValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/) tartalmaz egy módosítható értéket.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodj. Iterálj a korrekciókon, és vizsgáld meg a csak‑olvasású [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getType--) metódust, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz a korrekció. A csak‑olvasású [getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getName--) metódus további azonosítási információt ad, és különösen hasznos, ha egy előre definiált alakzat több azonos szemantikai típusú korrekciót tartalmaz.

Használd a korrekció jelentésének megfelelő értékmódszert:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Size of rounded corners | [setRawValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Thickness of an arrow tail | `setRawValue` |
| `ArrowheadLength` | Length of an arrowhead | `setRawValue` |
| `ArrowheadWidth` | Width of an arrowhead | `setRawValue` |
| `StartAngle` | Start angle of a pie or arc | [setAngleValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | End angle of a pie or arc | `setAngleValue` |

A `getType` és a `getName` csak‑olvasású információkat ad. A `getRawValue` és a `setRawValue` egész számot használ a beállított geometriai egységekben, míg a `getAngleValue` és a `setAngleValue` fokban megadott szöget. A korrekciók száma, sorrendje, jelentése és érvényes tartománya a beállított [ShapeType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igeometryshape/#getShapeType--)‑tól függ. Egy preset‑hez érvényes érték egy másik preset‑nél érvénytelen lehet vagy más hatást érhet el.

Ha a `getType` visszaadja a `ShapeAdjustmentType.Custom` értéket, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgáld meg a `getName`‑et, a preset típusát és a meglévő értéket, és csak akkor módosítsd a korrekciót, ha a várt jelentés és tartomány ismert. Még a felismert típusoknál is ellenőrizd, hogy ugyanaz a típus többször előfordul‑e, mielőtt értéket választanál. A [Connector](/slides/hu/java/connector/) cikk bemutatja ezt a helyzetet a csatlakozó ívek korrekcióival.

Az alábbi teljes példa három előre definiált alakzat alapértelmezett és módosított változatát hozza létre. Iterál minden korrekción, kiírja a nevét és típusát, a méret‑változtató értékeket `setRawValue`‑val módosítja, a szögeket `setAngleValue`‑val, és elmenti az eredményt. A bal oszlop az alapértelmezett geometriát tartja; a jobb oszlop a módosított lekerekített téglalapot, a négysávú nyilat és a tortát mutatja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáadja az alapértelmezett és a módosított alakzat oszlopok fejlécét.
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

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑indexet minden preset alakzatra ugyanazzal a jelentéssel feltételezzünk.

## **Alakzatgyűjtemény módosítása**

A hozzáadási, klónozási, eltávolítási és átrendezési metódusok azonnal a gyűjteményen hajtódnak végre. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodj a korábban rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) szintén másolatot készít, de egy megadott z‑rendi indexre helyezi. A koordinátákat elfogadó túlterhelések a másolat méretét változtatás nélkül mozdítják; a szélességgel és magassággal ellátott túlterhelések méretet is módosíthatnak.

A példa egy cél‑diát hoz létre, egy címkézett téglalapot a fronthoz klónoz, majd egy második klónot a háttérbe illeszt be. Bármelyik klón módosítása nem változtatja meg a forrás‑alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, rendelj új logikai azonosítókat a klónnak. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón új gyűjtemény‑elemként és új alakzat‑identitással jelenik meg.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) egy konkrét alakzat‑objektumot töröl a saját gyűjteményéből. Több egyezést kell eltávolítani indexelt iteráció során, akkor a végéről haladva kell bejárni, hogy a maradt indexek érvényben maradjanak.

Ez a példa minden megnevezett nevű alakzatot eltávolít. A jelenlegi indexen olvassa az alakzatot, nem egy rögzített gyűjtemény‑elemet, és nem kényszeríti le feleslegesen a típust.

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

Eltávolítás után az alakzatok száma és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vedd figyelembe a csatlakozókat, animációkat és más prezentáció‑elemeket, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint csak a dia kinézetét változtathatja meg.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setHidden-boolean-) értékének `true`‑ra állítása a alakzatot a gyűjteményben tartja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma a kód számára továbbra is elérhető, így az elrejtés megfelelő opcionális elemeknél, amelyeket később vissza lehet hozni.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és visszavonható egy felhasználó vagy kód által, és része marad a prezentációs fájlnak.

### **Z‑rend módosítása**

Átfedő alakzatok a gyűjtemény sorrendjében kerülnek kirajzolásra. A [reorder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) egy meglévő alakzatot egy cél‑indexre helyez át klónozás nélkül. A `0` index a hátul, a `size() - 1` az elöl.

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

A téglalap először létrejön, és eleinte az ellipsz mögött helyezkedik el. A végső indexre mozgatásával előre kerül. A z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsd be, mivel ezek a műveletek új gyűjtemény‑elemeket fűznek hozzá vagy illesztenek be, és megváltoztathatják a tervezett sorrendet.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, az elrendezési diák és a mesterdiák külön alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló pozícióban lévő alakzat egy normál dián. Vizsgáld meg az elrendezési alakzatokat, ha a formázást kell megérteni vagy módosítani, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFillFormat--) és [LineFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getLineFormat--) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több diát is érinthet, amely használja. Mielőtt egy elrendezési alakzatot módosítanál, határozd meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülbírálást tartalmaz‑e, és teszteld minden olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑ként**

[writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) egy alakzat renderelt tartalmát írja egy streambe. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

Tartsd nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűtípusok és képek erőforrásaitól függ. Ha a teljes összetételre van szükséged, exportáld a diát az egyes alakzat helyett. A hívó rendelkezik a streammel, és köteles azt lezárni.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapesalignmenttype/) megadja a szélek, a középső vonalak vagy az elosztási módot. Az `alignToSlide` értéke `true`, ha a dia szélét akarod használni; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását alkalmazza.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszaadott alakzat‑referenciákat a megfelelő indexeikre alakítja át közvetlenül az igazítás előtt.

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

Az igazítás a pozíciókat, nem a z‑rendet változtatja. Relatív igazításhoz általában legalább két alakzatra van szükség, míg a vízszintes vagy függőleges elosztáshoz elegendő számú alakzat kell a térköz meghatározásához. Ha a gyűjteményt módosítod a metódus hívása előtt, számold újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `getFlipH` és `getFlipV` értékei a [NullableBool](https://reference.aspose.com/slides/hu/java/com.aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nincs meghatározott / alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden többi keret‑értéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen is tükröződik, miközben a pozíciója, mérete és forgása változatlan marad.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzatazonosítóként?**

Csak rövid életű feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. A szerzői sablonoknál előnyösebb egy validált `Name` vagy `AlternativeText` konvenció, a diára vonatkozó interop munkához pedig az `OfficeInteropShapeId`.

**Eltávolítja-e egy elrejtett alakzat a z‑rendet?**

Nem. Egy elrejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rendet tekintve a front. Használd az `insertClone`‑t a kezdeti index megadásához, vagy a `reorder`‑t az összes alakzat hozzáadása után.

**Használhatok rögzített indexet egy előre definiált alakzat‑korrekció azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény felépítését validáltad. Inkább iterálj a `IGeometryShape.getAdjustments`‑on, és ellenőrizd a `IAdjustValue.getType`‑t; ha ugyanaz a szemantikai típus többször előfordul, használd a `IAdjustValue.getName`‑t további információként.