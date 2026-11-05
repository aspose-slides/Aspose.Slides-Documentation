---
title: "PowerPoint alakzatok formázása Java-ban"
linktitle: "Alakzat formázás"
type: docs
weight: 20
url: /hu/java/shape-formatting/
keywords:
- "alakzat formázása"
- "vonal formázása"
- "vázlat effektus"
- "vázlat alakzat vonal"
- "csatlakozási stílus formázása"
- "gradiens kitöltés"
- "minta kitöltés"
- "kép kitöltés"
- "textúra kitöltés"
- "egyszínű kitöltés"
- "alakzat átlátszóság"
- "fekete-fehér alakzat renderelés"
- "szürkeárnyalatos alakzat renderelés"
- "alakzat forgatása"
- "3D sarok effektus"
- "3D forgatási effektus"
- "formázás visszaállítása"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan lehet Java-ban az Aspose.Slides használatával PowerPoint alakzatokat formázni – pontos és teljes irányítással állítsa be a kitöltés, vonal és effektus stílusait PPT és PPTX fájlokhoz."
---
## **Bevezetés**

Formázza a alakzatokat a PowerPointban a körvonalak, kitöltések és effektusok beállításával. Az Aspose.Slides for Java lehetővé teszi ezen beállítások programozott vezérlését, beleértve az átlátszóságot, forgást és a 3D formázást.

![Alakzat formázási lehetőségek a PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for Java olyan interfészeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a lehetőségekkel.

## **Formázza a vonalakat**

Használja az [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) a alakzat körvonalának vezérléséhez. Ez a példa egy kitöltés nélküli téglalapot hoz létre kék, szaggatott körvonallal. Az [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) egy vastag-vékony összetett vonalat választ, míg az [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) a szélességet 7 pontra állítja és az [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) a szaggatás mintát választja.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A formázott vonalak a bemutatóban](formatted-lines.png)

### **Egyéni vonal‑szaggatási minták beállítása**

Használja az [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) akár előre meghatározott vonalstílusok nem biztosítják a szükséges szaggatási hosszakat és hézagokat, például márkás körvonalak vagy műszaki diagramok esetén. Egy minta hozzárendelése automatikusan a vonal szaggatási stílusát a [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) értékre állítja.

A tömb elemei váltakoznak a szaggatási és hézag hosszok között, szaggatással kezdve. Minden érték a vonal szélesség többszöröse: `{ 4, 2 }` 3 pont szélességnél 12 pont hosszú szaggatást és 6 pont hézagot eredményez. Párokat használjon véges, nem negatív értékekből a teljes szaggatási‑hézag szegmensek meghatározásához. A példa pozitív értékeket használ, hogy minden szaggatást és hézagot láthatóvá tegye.

Ez a példa öt kék vonalat hoz létre azonos hosszúsággal és lapos végekkel. Az első három a mintákat 3 pont szélességnél hasonlítja össze. A negyedik kétszeres szélességgel ismétli az első mintát, megduplázva mind a szaggatást, mind a hézagot. Az ötödik egy egyéni mintáról egy szilárd vonalra vált.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Állítsa az utolsó vonalat szilárd stílusra.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha vissza szeretne térni egy előre meghatározott szaggatott stílusra, adja át a [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) értéket az [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) metódusnak. A kiválasztott stílus szabályozza a vonal megjelenését.

Az eredmény a PowerPointban, felülről lefelé: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; és **Solid, 3 pt**.

![Három egyéni szaggatási minta, egy szélesebb vonal az első mintával, és egy szilárd vonal a PowerPointban](custom-dash-patterns.png)

### **Vonalvégek beállítása**

Használja az [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) egy nyílt vonal végeinek beállításához. A [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) osztály három explicit végtípust biztosít:

- `Flat`: A vonal a végpontnál leáll.
- `Round`: Egy félkör alakú vége a végponttól a vonal szélességének felével túlnyúlik.
- `Square`: Egy négyzet alakú vége a végponttól a vonal szélességének felével túlnyúlik.

Az osztály tartalmazza a `NotDefined` értéket is, ami azt jelenti, hogy nincs explicit módon megadott végtípus.

A végek különböznek a nyílfejekkel, amelyek szimbólumokat adnak a vonalvégekhez, valamint a csatlakozásokkal, amelyek a vonalszakaszok közötti sarkokat szabályozzák. Ez a példa letiltja a nyílfejeket az [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) és az [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) metódusokkal, hogy csak a végtípusok legyenek összehasonlítva.

Az alábbi példa három egyébként azonos vízszintes vonalat hoz létre, 20 pont széles. Felülről lefelé lapos, kerek és négyzet alakú végeket használnak. Végpontjaik ugyanazokkal a vízszintes koordinátákkal rendelkeznek; a kerek és a négyzet végek 10 ponttal túlnyúlnak minden végponton.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény a PowerPointban, felülről lefelé: **Flat**, **Round** és **Square**.

![Lapos, kerek és négyzet végek azonos vastag vonalakon a PowerPointban](line-caps.png)

## **Vázlat effektusok alkalmazása a forma vonalaira**

A vázlat effektus a forma vonalát kézzel rajzoltként jeleníti meg. Használja az [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) a vonal beállításainak eléréséhez, az [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) a vázlat beállításainak eléréséhez, és az [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) a [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) osztályból egy érték kiválasztásához.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) effektust, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el az effektust a [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) használatával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Az [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) által visszaadott érték a formához közvetlenül hozzárendelt beállítást képviseli. Ha a vonalformázást egy téma, mesterdia vagy elrendezési dia örökölheti, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), érje el a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) és olvassa a [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). A hatékony érték tükrözi a formázást, amely a öröklődés feloldása után ténylegesen alkalmazásra kerül. Ez a példa egy meglévő prezentációt igényel, amely legalább egy alakzatot tartalmaz az első dián, és kiírja mindkét értéket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Csatlakozási stílusok formázása**

Íme a három csatlakozási típus lehetőség:

* Round
* Miter
* Bevel

A csatlakozási stílus szabályozza, hogy a két körvonal szegmens hogyan találkozik a sarkon. Használja a **Round** értéket a lekerekített sarkokhoz, a **Miter** értéket a hegyes sarkokhoz, vagy a **Bevel** értéket a lelevágott sarkokhoz.

![A csatlakozási stílus a bemutatóban](join-style-powerpoint.png)

Ez a példa három fekete téglalapot hoz létre kék, 15 pont széles körvonallal. Az [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) használatával állítja be a miter, bevel és round értékeket a [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) megfelelően, hogy összehasonlítsa, hogyan rajzolódnak a sarkok.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Mitszer csatlakozások korlátozása hegyes sarkoknál**

Használja az [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) a [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) beállításával, hogy korlátozza, milyen messzire nyúlhat egy hegyes sarok.

A korlát a csatlakozás belső és külső sarkai közötti távolság és a vonal szélességének aránya. Például a `8` érték legfeljebb nyolcszoros vonal szélességű mitszer hosszát engedélyezi; ez nem pontmérték. Ha a sarok meghaladná a korlátot, a PowerPoint egy lelevágott csatlakozást használ az adott sarkon. A nagyobb korlát hegyesebb pontokat tesz lehetővé. A beállítás csak a mitszer csatlakozásokra hat, és a módosítása nem eredményez látható változást, ha a sarok mindkét korláton belül marad.

Ez a példa két azonos, kitöltés nélküli háromszöget hoz létre, 20 pont széles körvonallal. A bal háromszög a `2` korlátot használja, a jobb a `8`-at. Minden háromszög 80 pont széles és 160 pont magas, ami a felső sarkának körülbelül `4.12` arányú mitszer‑hossz‑vonalszélesség arányt eredményez. Ennek következtében a PowerPoint a bal csúcsot lelevágja, míg a jobb csúcsot megőrzi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény a PowerPointban: **Miter limit 2** a bal oldalon és **miter limit 8** a jobb oldalon.

![Lelevágott csúcs mitszer korláttal 2, és hegyes csúcs mitszer korláttal 8 a PowerPointban](miter-limits.png)

## **Gradiens kitöltés**

A gradiens kitöltés színeket kever át egy alakzaton. Ez a példa egy ellipszist tölt ki lineáris gradienssel 45 fokos szöggel pirosról lilára az [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) használatával. Az [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) metódus a színállomásokat 0 és 1 pozícióba helyezi, a gradiens elejére és végére. A meglévő állomások törlése biztosítja, hogy csak ez a két szín legyen használva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az ellipszis gradiens kitöltéssel](gradient-fill.png)

Ha egy gradiens másképp jelenik meg egy exportált képen, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy megjelenítési stílust anélkül, hogy megváltoztatná a prezentációban tárolt gradiens kitöltést.

### **Lineáris gradiens szög beállítása**

Használja az [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) t, hogy szabályozza egy [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) kitöltés tájolását. A szöget fokban mérik, és az óramutató járásával növekszik: `0` balról jobbra, `90` felülről lefele, `180` jobbról balra, és `270` alulról felülre. Tört szögeket is támogat. A `[0, 360)` tartományon kívül eső véges szögeket egy fordulóra normalizálja; például a `-45` `315` lesz, és a `360` `0`.

Ez a példa hat téglalapot hoz létre azonos piros, zöld és kék állomásokkal a `0`, `0.5` és `1` pozíciókban. A skálázás ki van kapcsolva, hogy a szöget a téglalapok arányaitól függetlenül lehessen összehasonlítani. A szögek, balról jobbra, az első sorban `0`, `45` és `90`, a második sorban pedig `135`, `180` és `270`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény a PowerPointban:

![Lineáris gradiens 0, 45 és 90 fokon az első sorban, valamint 135, 180 és 270 fokon a második sorban](linear-gradient-angles.png)

### **Lineáris gradiens skálázása az alakzattal**

Az [IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) értéket fogad. Állítsa explicit `False` értékre, hogy a geometriai gradiens szög a forma arányainak változásakor is megmaradjon, vagy `True` értékre, hogy a gradiens a forma szélességével és magasságával együtt skálázódjon. Skálázás engedélyezése esetén a látható szög eltérhet a hozzárendelt szögtől egy nem négyzetes alakzaton.

A következő példa `45` fokos szöget és ugyanazokat a színállomásokat használja, mint a szögek összehasonlításánál. A bal oszlop `False` értéket használ; a jobb oszlop `True` értéket. Minden oszlop egy széles téglalapot tartalmaz egy magasabb téglalap felett. Mindkettő azonos széles mérettel indul; a második téglalap szélességének és magasságának módosítása bemutatja, hogyan reagál a kitöltés a méretezésre a gradiens beállítások módosítása nélkül.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény a PowerPointban, balra skálázás letiltva, jobbra engedélyezve:

![Széles és magas téglalapok 45 fokos gradienssel, összehasonlítva a bal oldalon a LinearGradientScaled False értéket a jobb oldalon a True értékkel](linear-gradient-scaling.png)

Skálázás letiltásakor a diagonális színcsíkok ugyanazt az orientációt tartják mindkét téglalapon. Skálázás engedélyezése esetén a csíkok a forma arányával nyúltak. Ez segít egy sablon gradiensének reprodukálásában, amikor egy alakzatot más méretre adaptál. Négyzet esetén a skálázás engedélyezése nem változtatja meg a `45` fokos gradiens megjelenését.

Mind a szög, mind a skálázási beállítások lineáris gradiensre vonatkoznak. Nem szabályozzák a [GradientShape.Radial vagy GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) kitöltéseket.

### **A szög kombinálása a gradiens irányával**

Az [IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) a [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) osztályból választ ki egy gradiens stílust; nem helyettesíti a numerikus szöget. Lineáris gradiens esetén a sarokstílusok megváltoztathatják a színek eloszlási területét anélkül, hogy módosítanák a [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) által hozzárendelt szöget. Tartsa a irányt változatlanul, amikor szögeket vagy skálázást hasonlít.

Az alábbi példa ugyanazokat a beállításokat alkalmazza fordított sorrendben. A két téglalap ugyanúgy néz ki: az irány hozzárendelése a szög előtt vagy után nem változtatja meg az eredményt.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Minta kitöltés**

Egy minta kitöltés két színű dizájnt alkalmaz, például pontokat, csíkokat vagy kockákat. Ez a példa az [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) segítségével választ egy rácsos mintát. Az [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) a világosszürke háttérszínt biztosítja, a [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) pedig a sárga minta színét.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A téglalap mintával kitöltve](pattern-fill.png)

## **Kép kitöltés**

Egy kép kitöltés egy képet használ egy alakzat belsejében. Ez a példa helyi képet igényel, és a [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) használatával tölti be a prezentáció képgyűjteményébe. Az [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) csempézett módra állítása megismétli a képet a téglalapon belül. Az itt használt forráskép lent látható:

![A lótusz kép](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A forma képpel kitöltve](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne textúraként beállítani és testre szabni a csempézési viselkedést, használhatja a következő módszereket az [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) osztály esetén:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kezdőpontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat kezdőpontjától.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Megadja a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Megadja a csempe függőleges méretezését százalékban.

Ez a példa helyi képet igényel, és a [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) beállítja, hogy a képet az eredeti méret 50%-án ismételje. A -32 pont eltolások vízszintesen és függőlegesen mozgatják a csempéket; a jobb-alsó igazítás és a mindkét irányú tükrözés határozza meg, hogyan rendeződik a megismételt textúra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A csempézési beállítások](tile-options.png)

## **Egyszínű kitöltés**

Az egyszínű kitöltés egyetlen, egységes színt ad az alakzatra. Ez a példa az [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) használatával állítja be az egyszínű kitöltés módját, és a [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) segítségével sárgát ad hozzá, majd elmenti a téglalapot egy prezentációba.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A forma egyszínű kitöltéssel](solid-color-fill.png)

### **Színek másolása téma hivatkozások megőrzésével**

Használja az [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) t, hogy szín-definíciót másoljon, beleértve a szín típusát, a téma hivatkozását és a transzformációkat. Ez akkor hasznos, ha egy kitöltő színt alakzatok között kíván áthelyezni, amelyeknek továbbra is a prezentáció témát kell követniük. A metódus csak a színt másolja; nem másolja a kitöltés típusát, körvonalát vagy egyéb formaformázást. Állítsa be a célkitöltés típusát kifejezetten az [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) metódussal.

Ez a példa három téglalapot hoz létre, balról jobbra: a forrást, egy témaérzékeny másolatot, és egy rögzített RGB másolatot. A forrás az [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) használatával hivatkozik az első kiemelt színre, és egy árnyalatot ad hozzá az [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-) segítségével. Az RGB másolat a forrás hatékony kitöltő színét használja, így három elejük eleinte azonosnak tűnik. Az [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) hívása egy rögzített RGB értéket állít be és törli a meglévő színtranszformációkat.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // A témahivatkozások követik az új kiemelt színt; a fix RGB érték nem.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A témaváltozás előtt mindhárom kitöltés egyezik:

![Forrás, copyFrom cél, és rögzített RGB cél azonos kék kitöltésekkel](color-copy-before.png)

A témaváltozás után a forrás és a témaérzékeny másolat az új kiemelt színt követi és megtartja az árnyalatukat. A rögzített RGB másolat kék marad:

![Forrás és copyFrom cél narancssárga kitöltéssel, míg a rögzített RGB cél kék marad](color-copy-after.png)

A másolt definíció független a forrástól. A forrás témahivatkozásának, egy másik szín hozzárendelésének vagy a transzformációk hozzáadásának vagy eltávolításának későbbi módosítása nem változtatja meg a célt. A téma változása továbbra is mindkét alakzatot érinti, mivel mindegyik önállóan hivatkozik ugyanarra a téma színre.

A PPTX mentése és újranyitása megőrzi a másolt szín típusát, amelyet az [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--) ad vissza, a téma hivatkozást és a [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--) által visszaadott transzformációs gyűjteményt; nem lapítja le a definíciót RGB-re.

Különböző téma kontextusok között másolás esetén, például különböző kiemelt palettákkal rendelkező prezentációk esetén, a másolt hivatkozás a cél téma alapján kerül feloldásra. Ugyanaz a hivatkozás és transzformációk ezért más látható színt eredményezhetnek. Lásd a [Presentation Theme](/slides/hu/java/presentation-theme/) oldalt a téma színek konfigurálásáról.

## **A diák háttér használata forma kitöltésként**

Használja az [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) t, amikor egy alakzatnak meg kell egyeznie a diák háttérrel, például egy prezentációs sablonban. Állítsa be a kitöltés típusát az [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) segítségével a [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékre, hogy eltávolítsa az esetleges explicit kitöltést. Ezzel a kombinációval az alakzat a diák hátterét használja a stílus kitöltése helyett. A jelző engedélyezése önmagában nem távolítja el a meglévő explicit kitöltést.

Ez különbözik a [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): a háttér kitöltés a forma mögötti objektumokat a diák megfelelő területével takarja, míg a No Fill az objektumokat láthatóvá hagyja. A gradiens a diára marad igazítva, nem indul újra minden egyes forma belsejében.

Az alábbi példa egy mester háttérrel hoz létre, amelyet a dia örököl, és egy magenta sávot helyez el három téglalap mögött. A bal téglalap a hátteret használja, a középső téglalap nem rendelkezik kitöltéssel, a jobb téglalap a háttér kitöltésről egy explicit narancssárga kitöltésre vált.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // A gradienst a masterből örökölje.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Adja hozzá ezt az objektumot először, hogy a téglalapok mögött jelenjen meg.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Kapcsolja ki a háttér kitöltést, mielőtt explicit kitöltést alkalmazna.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény balról jobbra: **background fill**, **no fill**, és **explicit fill**. A magenta sáv a bal és jobb téglalapok által el van takarva, de a középső téglalapon keresztül látható marad.

![Háttér kitöltés, nincs kitöltés és explicit narancssárga kitöltés egy magenta sáv felett](background-fill.png)

Ugyanez a viselkedés vonatkozik a közvetlenül a diára vagy egy elrendezésből örökölt háttérre is. Az alakzat a diára feloldott háttért használja; a példa a dia és az elrendezés hátterét is nincs definiálva, így a mester biztosítja azt.

## **Átlátszóság beállítása**

Egy egyszínű kitöltésnél a szín alfa komponense szabályozza az átlátszatlanságot: a 0 teljesen átlátszó, a 255 teljesen átlátszatlan. Ez a példa 128 alfa értékkel egy sárga téglalapot alkalmaz, kb. 50%-ban átlátszóvá téve, így az alatta lévő téglalap látható marad. A szín a [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) segítségével van hozzárendelve.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó forma](shape-transparency.png)

## **Alakzatok forgatása**

Használja az [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) t, hogy forgassa az alakzatot a dia síkjában. A szöget fokban mérik; ez a példa egy téglalapot 5 fokkal óramutató járásával megegyező irányba forgat, és elmenti a prezentációt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D sarok effektusok hozzáadása**

Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) t, hogy a forma mélységet és levágott éleket kapjon. Ez a példa egy zöld ellipszist hoz létre narancssárga körvonallal, az [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) segítségével 4 pont mélységet állít be, és egy kör alakú felső sarok élt alkalmaz 6 pont szélesség és magasság segítségével az [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) metóduson keresztül. Egy elölnéző ortografikus kamera és hárompontos megvilágítás teszi láthatóvá a sarokat.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D sarok effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Egy forma 3D nézetét a kamera beállításai szabályozzák. Ez a példa az [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) használja 40, 35 és 20 fokos szélességi, hosszúsági és fordulat szögekkel. Egy izometrikus kamerát választ a [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) segítségével, és kiegyensúlyozott megvilágítást a [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) segítségével, majd elmenti a formázott téglalapot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Fekete-fehér renderelés vezérlése alakzatoknál**

Az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódus meghatározza, hogyan kerül renderelésre egy adott alakzat, amikor egy prezentációt fekete-fehér módban néznek vagy dolgozzák fel. Nem kapcsolja be magát a fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) osztályból a kívánt viselkedés kiválasztásához. Például az `Automatic` hagyja, hogy a renderelő alkalmazás válassza a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér színeket használ, a `Black` és a `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` kihagyja az alakzatot fekete‑fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatszintű mód beállítva.

Ez a példa egy narancssárga téglalapot hoz létre, és az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) segítségével a módot szürkére állítja. A mentett forma megőrzi narancssárga kitöltését normál szín megjelenítéskor, és szürke színezést kér a fekete‑fehér megjelenítési beállításokat tiszteletben tartó alkalmazásoktól:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál színmódban a téglalap megőrzi narancssárga kitöltését. Egy fekete‑fehér megjelenítési munkafolyamatban szürke színezést használ, mivel a módja `Gray` értékre van állítva. Ez lehetővé teszi, hogy egy teljes színű diát megőrizzen, miközben egy különálló megjelenést definiál a nyomtatáshoz, előnézethez vagy egyéb munkafolyamatokhoz, amelyek tiszteletben tartják a prezentáció fekete‑fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Használja az [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) t, hogy visszaállítsa a dia helyfoglalók pozícióját, méretét és formázását a megfelelő elrendezéshelyfoglalókból. Ez a példa egy már létező prezentációt igényel elrendezéshez kapcsolt helyfoglalókkal, és a mentés előtt minden diát visszaállít. Azok a formák, amelyeknek nincs megfelelő elrendezéshelyfoglalója, nem lesznek visszaállítva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Az alakzat formázása befolyásolja a végső prezentáció fájlméretét?**

A színek, vonalstílusok és effektus beállítások általában kevés adatot adnak hozzá az beágyazott képekhez és médiákhoz képest. A képes kitöltések növelhetik a fájlméretet, mivel képeik a prezentációban tárolódnak.

**Hogyan tudom felismerni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállítások. Ha minden megfelelő érték egyezik, tekintse a stílusaikat azonosnak, és logikusan csoportosítsa az alakzatokat, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílusok halmazát egy külön fájlba, hogy más prezentációkban is felhasználjam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon diakönyvben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat bárhol, ahol szükséges.