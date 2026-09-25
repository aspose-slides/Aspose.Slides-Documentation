---
title: Prezentáció alakzatok kezelése Java-ban
linktitle: Alakzatmanipuláció
type: docs
weight: 40
url: /hu/java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat beállítási pont
- előre definiált alakzat beállítása
- alakzat geometria
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan azonosíthat, módosíthat, klónozhat, eltávolíthat, elrejthet, átrendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Java a dián lévő alakzatokat rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/)ként ábrázolja. A gyűjtemény egyszerre a hely, ahol alakzatokat találunk és módosítunk, valamint a rétegezési sorrend forrása: a `0` index a leghátruló alakzat, míg az utolsó index a legelöl lévő alakzat.

Ez a cikk ezen modell szerint halad. Először bemutatja, hogyan lehet egy alakzatot megbízhatóan azonosítani és a beépített alakzatemetés-pontokat módosítani, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. Az utolsó szakaszok a felület szintű formázást, az SVG exportálást, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Azonosítás és alakzatok keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató elkészítési és karbantartási módja szerint:

- **[Name](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--)** hasznos fejlesztői irányítású sablonoknál, és könnyen ellenőrizhető a PowerPoint Kiválasztási ablaktáblájában. A neveket szerkeszthetik, és nem garantált, hogy egyediek, ezért nevezési konvenciót kell bevezetni, ha a kód rájuk támaszkodik.
- **[AlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getAlternativeText--)** akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy újraírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben a jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)** egy csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítóval egyezik. Használja, ha PowerPoint‑integrációt végez, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama alatt. Egy klónozott vagy újra létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó **[getUniqueId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getUniqueId--)** metódus prezentáció‑szintű azonosítót ad vissza, de ezt a kiegészítők használják, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazásadataiban, és ellenőrizze, hogy a várt alakzat még létezik‑e.

A *alternative text* címek és leírások olvasásának és frissítésének gyakorlati példáját lásd a **[Manage Alternative Text Titles and Descriptions](/slides/hu/java/presentation-accessibility/)** oldalon. Használja az alternatív szöveget a vizuális elem jelentésének leírására, és tartsa külön a kódban használt alakzatnevektől.

Az alábbi példa pontos összehasonlítással név szerint keres, és a diára vonatkozó interop‑azonosítót jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi a helytelen objektummal való folytatás helyett.

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

Amikor egy művelet alakzat‑típus‑specifikus, ellenőrizze a felületet, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy **[IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/)**.

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

## **Azonosítás és a beépített alakzatemetés módosítása**

A beépített geometriai alakzatok kitépési pontokat exponálhatnak, amelyek a sarokméret, nyíl arányok vagy ív szögek vezérlésére szolgálnak. Ezekhez a csak‑olvasó **[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igeometryshape/#getAdjustments--)** gyűjteményen keresztül férhet hozzá. A gyűjteményt az alakzat szolgáltatja, de minden **[IAdjustValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/)** egy módosítható értéket tartalmaz.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Járja végig a kitépéseket, és vizsgálja meg a csak‑olvasó **[getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getType--)** metódust, amelynek **[ShapeAdjustmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeadjustmenttype/)** értéke leírja, mit szabályoz a kitépés. A csak‑olvasó **[getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getName--)** metódus további azonosítási információt ad, és különösen hasznos, ha egy előre definiált alakzat több azonos szemantikai típusú kitépést tartalmaz.

Használja a kitépés jelentéséhez illő értékmódszert:

| Módosítás típusa | Cél | Megváltoztatandó érték |
|---|---|---|
| `CornerSize` | A lekerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | A nyílfarok vastagsága | `setRawValue` |
| `ArrowheadLength` | A nyílhegy hossza | `setRawValue` |
| `ArrowheadWidth` | A nyílhegy szélessége | `setRawValue` |
| `StartAngle` | A körszelet vagy ív kezdőszöge | [setAngleValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | A körszelet vagy ív zárószöge | `setAngleValue` |

A **getType** és **getName** csak‑olvasó információkat ad. A **getRawValue** és **setRawValue** egy egész számot használ a beállítás natív geometriai egységeiben, míg a **getAngleValue** és **setAngleValue** fokban megadott szöget kezel. A kitépés száma, sorrendje, jelentése és érvényes tartománya a beépített **[ShapeType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igeometryshape/#getShapeType--)**‑tól függ. Egy adott beállítás, amely egy előre definiált alakzatra érvényes, egy másikra érvénytelen vagy más hatást eredményezhet.

Ha a **getType** **ShapeAdjustmentType.Custom** értéket ad vissza, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a **getName**‑et, a beépített típust és a meglévő értéket, és csak akkor változtassa meg a kitépést, ha ismeri a várt jelentést és tartományt. Még felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször is előfordul‑e, mielőtt értéket választana. A **[Connector](/slides/hu/java/connector/)** cikk bemutatja ezt a helyzetet a csatlakozó görbületi kitépéseknél.

Az alábbi teljes példa három előre definiált alakzat alap‑ és módosított változatát hozza létre. Minden kitépésen végigiterál, jelentésének nevét és típusát kiírja, a méret‑kapcsolt értékeket **setRawValue**‑val módosítja, a szögeket **setAngleValue**‑val, majd elmenti az eredményt. A bal oszlop az alapgeometriát tartja; a jobb oszlop a módosított lekerekített téglalapot, a négyirányú nyilat és a körszelet mutatja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fejlécet ad az alapértelmezett és a módosított alakzat oszlopokhoz.
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

A szemantikai típus ellenőrzése a módosítás előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑index különböző előre definiált alakzatoknál más jelentéssel bírjon.

## **Az alakzatgyűjtemény módosítása**

A hozzáadási, klónozási, eltávolítási és átrendezési metódusok azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne továbbra is az előzőleg rögzített indexekre támaszkodjon.

### **Alakzat klónozása**

**[addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)** egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. **[insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)** szintén másolatot készít, de egy megadott z‑rendi indexbe helyezi. A koordinátákat elfogadó túlterhelések a méretet nem változtatják; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa egy cél diát hoz létre, klónoz egy feliratos téglalapot előre, és egy második klónt szúr be a hátulra. Az egyik klón módosítása nem érinti a forrásalakzatot.

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

A klónozás az alakzat tartalmát és formázását, köztük a nevét és az alternatív szöveget is másolja. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjtemény‑elem, új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

**[remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)** egy adott alakzat objektumot töröl a gyűjteményéből. Több egyező alakzat eltávolításakor index‑szerkesztett iteráció során haladjon a vég felől, hogy a maradék indexek érvényben maradjanak.

Ez a példa minden megadott nevű alakzatot eltávolít. A jelenlegi indexen lévő alakzatot olvassa, nem egy rögzített gyűjtemény‑elemet, és nem kényszeríti a típust feleslegesen.

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

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Fontolja meg a csatlakozók, animációk és egyéb prezentációs elemek esetét, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása a dián megjelenő elemeknél több mint a megjelenés változását eredményezheti.

### **Alakzat elrejtése**

A **[Hidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setHidden-boolean-)** `true`‑ra állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági lépés. Az objektum továbbra is felfedezhető és visszafejthető a felhasználó vagy a kód által, és része marad a prezentáció fájlnak.

### **Z‑rend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében festődnek. **[reorder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)** egy meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. Az index `0` a hátul, a `size() - 1` az elöl.

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

A téglalap először kerül létrehozásra, és eleinte az ellipsz mögött helyezkedik el. A végső indexre való áthelyezés előre helyezi. A z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsa be, mivel ezek a műveletek új gyűjtemény‑elemeket adnak hozzá vagy szúrnak be, és megváltoztathatják a kívánt rétegsorrendet.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, elrendezési diák és mesterdiák külön‑külön alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezkedő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha a formázást szeretné megérteni vagy megváltoztatni, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat **[FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFillFormat--)** és **[LineFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getLineFormat--)** tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

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

Egy elrendezés szerkesztése több diára is kihatással lehet, amelyik használja. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökölte‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑be**

**[writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)** egy alakzat renderelt tartalmát egy adatfolyamba írja. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés során. A kimenet az alakzat formázásától és olyan erőforrásoktól, mint betűkészletek és képek, függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, nem egyetlen alakzatot. A hívó birtokolja az adatfolyamot, és le kell zárnia azt.

## **Alakzatok igazítása**

A **[SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)** túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A **[ShapesAlignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapesalignmenttype/)** határozza meg az él, középvonal vagy elosztási módot. Állítsa az `alignToSlide` értékét `true`‑ra a dia széleihez igazításhoz; `false`‑ra a kiválasztott alakzatok egymáshoz viszonyított igazításához.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszakapott alakzathivatkozásokat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás pozíciókat változtat, nem a z‑rendet. Relatív igazítás általában legalább két alakzatot igényel, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell a távolság meghatározásához. Ha a metódus hívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A **[ShapeFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/)** osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait, valamint a forgást. A `getFlipH` és `getFlipV` értékek **[NullableBool](https://reference.aspose.com/slides/hu/java/com.aspose.slides/nullablebool/)**‑t használnak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig az alapértelmezett/ nem definiált állapotot őrzi meg.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden többi keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új **[Frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)** hozzárendelése a teljes keretet felülírja.

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

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használhatok gyűjtemény‑indexet alakzatazonosítóként?**

Csak rövid élettartamú feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítse a validált `Name` vagy `AlternativeText` konvenciót a szerkesztett sablonoknál, vagy `OfficeInteropShapeId`‑t a diára vonatkozó interop munkához.

**Eltávolítja-e egy rejtett alakzat a z‑rendet?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend elöljét jelenti. Használja az `insertClone`‑t a kezdeti index kiválasztásához, vagy a `reorder`‑t az összes alakzat hozzáadása után.

**Használhatok rögzített indexet egy előre definiált alakzatemetés azonosításához?**

Csak akkor, ha a pontos előre definiált alakzatot és a gyűjtemény‑elrendezést előzetesen ellenőrizte. Előnyben részesítse a **IGeometryShape.getAdjustments** végigiterálását és a **IAdjustValue.getType** ellenőrzését; ha ugyanaz a szemantikai típus többször fordul elő, használja a **IAdjustValue.getName**‑t további információként.