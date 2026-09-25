---
title: Prezentációs alakzatok kezelése Androidon
linktitle: Alakzatmanipuláció
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
- alakzat igazítási pontja
- előre beállított alakzat igazítása
- alakzat geometriai adatai
- alakzat elrendezési formátumok
- alakzat SVG‑ként
- alakzat SVG‑be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, módosíthat, klónozhat, eltávolíthat, elrejthet, újrarendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Android via Java a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/)‑ként ábrázolja. A gyűjtemény egyszerre a hely, ahol megtalálja és módosíthatja az alakzatokat, valamint az egymásra helyezés sorrendjének forrása: a `0`‑es index a leghátsó alakzat, míg az utolsó index a legelső alakzat.

Ez a cikk ezt a modellt követi. Először azt mutatja be, hogyan lehet egy alakzatot megbízhatóan azonosítani és a beépített alakzat‑igazítási pontokat módosítani, majd azt, hogy hogyan lehet klónozni, eltávolítani, elrejteni és újrarendezni az alakzatokat. Az utolsó szakaszok az elrendezés‑szintű formázást, az SVG‑exportálást, a justálást és a tükrözési beállításokat fedik le. Minden példa független, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy újrarendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció szerkesztésének és karbantartásának módja szerint:

- **[Name](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--)** hasznos fejlesztő‑vezérelt sablonok esetén, és könnyen megtekinthető a PowerPoint „Selection Pane”‑ben. A neveket szerkeszthető, de nem garantált a egyediségük, ezért ha a kód rá támaszkodik, alakíts ki egy elnevezési konvenciót.
- **[AlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getAlternativeText--)** akkor hasznos, ha egy akadálymentesítési leírás vagy a szerző által megadott címke már azonosítja az alakzatot. Látható a felhasználók számára, lokalizálható vagy átírható akadálymentesítés céljából, és nem garantált az egyediség. Ne használja csendben az értelmes akadálymentesítési szöveget adatbáziskulcsként.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)** egy csak‑olvasású azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat‑azonosítónak. Használja, ha a PowerPoint‑tel integrál, vagy ha a forma életciklusa alatt egyértelmű hivatkozásra van szükség. Egy klónozott vagy újból létrehozott alakzat másik alakzat, és saját ID‑t kap.

A kapcsolódó **[getUniqueId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getUniqueId--)** metódus prezentáció‑szintű azonosítót ad vissza, de ez a metódus kiegészítők számára készült, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosságra van szükség, tárolja a leképezést az alkalmazás adatbázisában, és ellenőrizze, hogy a várt alakzat még mindig létezik‑e.

A **[Manage Alternative Text Titles and Descriptions](/slides/hu/androidjava/presentation-accessibility/)** példában látható, hogyan lehet elolvasni és frissíteni az alternatív szöveg címet és leírást. Használja az alternatív szöveget a vizuális elemek jelentésének magyarázatára, és tartsa külön a kód által használt alakzatnevektől.

Az alábbi példa név szerint keres pontos egyezéssel, és a diára vonatkozó interop‑ID‑t jelzi. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti, ahelyett, hogy a rossz objektummal folytatná.

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

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze az interfészt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy **[IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)**.

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

## **Előre beállított alakzat‑igazítások azonosítása és módosítása**

Az előre beállított geometriai alakzatok ki tudnak adni igazítási pontokat, amelyek a sarkok méretét, a nyíl arányait vagy ívhöjét szabályozzák. Ezeket a csak‑olvasású **[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--)** gyűjteményen keresztül érheti el. A gyűjteményt maga az alakzat biztosítja, de minden **[IAdjustValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/)** tartalmaz egy módosítható értéket.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Iteráljon az igazításokon, és vizsgálja meg a csak‑olvasású **[getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getType--)** metódust, amelynek **[ShapeAdjustmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeadjustmenttype/)** értéke leírja, mit szabályoz az adott igazítás. A csak‑olvasású **[getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getName--)** további azonosítási információt ad, és különösen hasznos, ha egy előre beállítás több ugyanolyan szemantikai típusú igazítást tartalmaz.

Használja a jelentésnek megfelelő értékmódszert:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Kerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Nyíl farok vastagsága | `setRawValue` |
| `ArrowheadLength` | Nyílfej hossza | `setRawValue` |
| `ArrowheadWidth` | Nyílfej szélessége | `setRawValue` |
| `StartAngle` | Kör-/ív kezdőszöge | [setAngleValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Kör-/ív befejező szöge | `setAngleValue` |

A `getType` és a `getName` csak‑olvasású információt ad. A `getRawValue` és a `setRawValue` egy egész számot használ a beállított geometriai egységben, míg a `getAngleValue` és a `setAngleValue` fokban megadott szöget kezel. Az igazítások száma, sorrendje, jelentése és érvényes tartománya a konkrét **[ShapeType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)**‑tól függ. Egy presethez érvényes érték egy másik presetnél érvénytelen lehet vagy más hatást eredményezhet.

Ha a `getType` **ShapeAdjustmentType.Custom**‑ot ad vissza, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `getName`‑et, a preset típusát és a meglévő értéket, és csak akkor módosítsa, ha a várható jelentés és tartomány ismert. Még a felismert típusoknál is ellenőrizze, hogy ugyanaz a típus többször is előfordul‑e, mielőtt értéket választana. A **[Connector](/slides/hu/androidjava/connector/)** cikk bemutatja ezt a helyzetet a connector‑görbületi igazításoknál.

Az alábbi teljes példa három előre beállított alakzat alap‑ és módosított változatát hozza létre. Minden igazításon végigiterál, kiírja a nevét és típusát, a `setRawValue`‑val méret‑kapcsolt értékeket módosít, a `setAngleValue`‑val szögeket változtat, majd az eredményt menti. A bal oszlop az alap geometriai adatot, a jobb oszlop a módosított lekerekített téglalapot, a négyszögletes nyilat és a kört mutatja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáadja a fejléceket az alap és a módosított alakzatoszlopokhoz.
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

A szemantikai típus ellenőrzése a módosítás előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑index különböző preset alakzatoknál más jelentéssel bírjon.

## **Alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és újrarendezés módszerek azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább az előzőleg rögzített indexekre.

### **Alakzat klónozása**

A **[addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)** egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. A **[insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)** szintén másolatot készít, de egy megadott z‑sorrend‑indexen helyezi el. A koordinátákat elfogadó túlterhelések a klónt méret‑változtatás nélkül mozgatják; a szélesség‑ és magasságot megadó túlterhelések át is méretezhetik.

A példa egy cél‑diát hoz létre, egy címkézett téglalapot a frontba klónoz, és egy második klónt a hátulra illeszt be. Az egyik vagy másik klónon végzett módosítások nem érintik a forrás alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjtemény‑elemet jelent új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

A **[remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)** egy konkrét alakzat‑objektust töröl a gyűjteményéből. Több egyező alakzat eltávolítása során indexelt iteráció esetén járjon végig a gyűjteményen a végtől a kezdő felé, hogy minden maradt index érvényes maradjon.

Ez a példa minden megnevezett névvel rendelkező alakzatot eltávolít. Az aktuális indexnél olvassa be az alakzatot, nem egy rögzített gyűjtemény‑elemet, és nincs felesleges típuskényszerítés.

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

Eltávolítás után a alakzatok száma és a későbbi alakzatok indexei is változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye figyelembe a csatlakozókat, animációkat és a prezentáció egyéb elemeit, amelyek hivatkozhatnak a törölt objektumra; egy látható alakzat eltávolítása több mint csak a dia megjelenését befolyásolhatja.

### **Alakzat elrejtése**

A **[Hidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setHidden-boolean-)** `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, ezért az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és visszakapcsolható felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **Z‑rendezés módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek festésre. A **[reorder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)** egy meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. A `0`‑as index a hátul, a `size() - 1` a front.

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

Először a téglalap jön létre, ezért eleinte a ellipszis mögött helyezkedik el. A végső indexre mozgatásával előre kerül. A z‑rendezést a kapcsolódó alakzatok hozzáadása vagy klónozása után finomítsa, mivel ezek a műveletek új gyűjtemény‑elemeket szúrhatnak be és módosíthatják a kívánt rétegsorrendet.

## **Elrendezési diák alakzatainak vizsgálata**

A normál diák, elrendezési diák és fődiák külön alakzatgyűjteményekkel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezkedő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha formázást kell megértenie vagy módosítania, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat **[FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFillFormat--)** és **[LineFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getLineFormat--)** tulajdonságát olvassa ki, anélkül, hogy feltegyené, minden alakzat egy `AutoShape`.

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

Az elrendezés szerkesztése több, azt használó diára is hatással lehet. Mielőtt megváltoztatna egy elrendezési alakzatot, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes olyan diát, amely az adott elrendezést használja.

## **Alakzat exportálása SVG‑be**

A **[writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)** egy alakzat renderelt tartalmát írja egy adatfolyamba. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűtípusok és képekhez hasonló erőforrásoktól függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, nem csak az egyes alakzatot. A hívó birtokolja az adatfolyamot, és köteles azt bezárni.

## **Alakzatok igazítása**

A **[SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)** túlterhelésekkel vagy minden alakzatot, vagy kiválasztott gyűjtemény indexeket igazít. A **[ShapesAlignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapesalignmenttype/)** határozza meg a széleket, középvonalat vagy elosztási módot. Állítsa az `alignToSlide`‑t `true`‑ra a dia széleihez igazításhoz; `false`‑ra állítva a kiválasztott alakzatok egymáshoz viszonyított igazításához.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszakapott alakzat‑referenciákat a tényleges indexeikre konvertálja közvetlenül az igazítás előtt.

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

Az igazítás a pozíciókat változtatja, nem a z‑rendezést. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell, hogy meghatározza a távolságot. Ha a metódus meghívása előtt módosította a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A **[ShapeFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/)** osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait, valamint a forgást. A `getFlipH` és `getFlipV` értékek **[NullableBool](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/)** típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig a nem meghatározott/alapértelmezett állapotot őrzi meg.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új **[Frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)** hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükrözve marad, miközben a pozíciója, mérete és forgási szöge változatlan.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat azonosítóként?**

Csak rövid életű feldolgozáskor, amikor a gyűjtemény nem változik az index használata előtt. Hosszabb távon válasszon ellenőrzött `Name` vagy `AlternativeText` konvenciót a szerkesztett sablonokhoz, vagy `OfficeInteropShapeId`‑t a diára vonatkozó interop feladatokhoz.

**Az elrejtett alakzat eltűnik a z‑rendezésből?**

Nem. Egy elrejtett alakzat ugyanazon az indexen marad a gyűjteményben. Megtalálható, újrarendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rendezés frontja. Használja az `insertClone`‑t a kezdeti index megadásához, vagy a `reorder`‑t minden alakzat hozzáadása után.

**Használhatok rögzített indexet egy előre beállított alakzat‑igazítás azonosításához?**

Csak akkor, ha az adott presetet és a gyűjtemény elrendezését validálta. Inkább iteráljon a `IGeometryShape.getAdjustments`‑on, és ellenőrizze az `IAdjustValue.getType`‑t; ha ugyanaz a szemantikai típus többször is megjelenik, használja az `IAdjustValue.getName`‑t további információként.