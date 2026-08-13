---
title: Bemutató témák kezelése Androidon
linktitle: Bemutató téma
type: docs
weight: 10
url: /hu/androidjava/presentation-theme/
keywords:
- PowerPoint téma
- bemutató téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Androidban a bemutató témák teljes körű kezelése Java segítségével PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához konzisztens márkajelzés mellett."
---
## **Bevezetés**

A bemutató téma meghatározza a tervezési elemek tulajdonságait. Amikor egy bemutató témát választ, lényegében egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választja ki.

PowerPointban egy téma színeket, [fonts](/slides/hu/androidjava/powerpoint-fonts/), [background styles](/slides/hu/androidjava/presentation-background/) és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma szín módosítása**

A PowerPoint téma egy meghatározott színkészletet használ a dián lévő különböző elemekhez. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatja a témát. Ahhoz, hogy új témaszínt válasszon, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SchemeColor) felsorolásban értékeket biztosít.

Ez a Java kód bemutatja, hogyan lehet módosítani a téma akcentusszínét:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Így meghatározhatja a kapott szín tényleges értékét:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Az színváltoztatás további bemutatásához létrehozunk egy másik elemet, és az első műveletben kapott akcentusszínt hozzárendeljük. Ezután megváltoztatjuk a színt a témában:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Az új szín automatikusan alkalmazásra kerül mindkét elemen.

### **Témaszín beállítása kiegészítő palettáról**

Ha a fő témaszínre (1) luminancia átalakításokat alkalmaz, a kiegészítő palettáról (2) színek képződnek. Ezután beállíthatja és lekérheti ezeket a témaszíneket.

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő témaszínek  
**2** - A kiegészítő palettáról származó színek.

Ez a Java kód bemutat egy műveletet, ahol a kiegészítő palettaszínek a fő témaszínből nyerhetők, és aztán alakzatokban használhatók:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcentus 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcentus 4, 80%-kal világosabb
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcentus 4, 60%-kal világosabb
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcentus 4, 40%-kal világosabb
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcentus 4, 25%-kal sötétebb
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcentus 4, 50%-kal sötétebb
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` leképezése az `IColorScheme` színekre**

Ha a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/)‑vel dolgozik, észreveheti, hogy a következő témaszín értékeket tartalmazza:
`Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation.getMasterTheme().getColorScheme()` a [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/)‑t adja vissza, amely a megfelelő színeket a következőképpen teszi elérhetővé:
`Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a különbség csak a névadásban van. Ezek az értékek ugyanazokra a témaszínhelyekre utalnak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus konverzió a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen ugyanazoknak a témaszíneknek alternatív nevei.

Ez a névadási különbség a Microsoft Office terminológiájából származik. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb UI verziók ugyanazokat a helyeket `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **Téma betűtípus módosítása**

Hogy betűtípusokat választhasson témákhoz és egyéb célokra, az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** – törzs betűtípus Latin (Minor Latin Font)
* **+mj-lt** – cím betűtípus Latin (Major Latin Font)
* **+mn-ea** – törzs betűtípus Kelet‑Ázsiai (Minor East Asian Font)
* **+mj-ea** – törzs betűtípus Kelet‑Ázsiai (Major East Asian Font)

Ez a Java kód bemutatja, hogyan lehet a latin betűtípust egy témaelemhez hozzárendelni:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a Java kód bemutatja, hogyan módosítható a bemutató téma betűtípusa:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Az összes szövegdoboz betűtípusa frissülni fog.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Téma háttérstílus módosítása**

Alapértelmezésben a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de ezek közül csak 3 kerül mentésre egy tipikus bemutatóban.

![todo:image_alt_text](presentation-design_8.png)

Például, miután ment egy bemutatót a PowerPoint alkalmazásban, futtathatja ezt a Java kódot, hogy meghatározza az előre definiált háttérképek számát a bemutatóban:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonság használatával a [FormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme)‑osztályból hozzáadhat vagy elérheti a háttérstílust egy PowerPoint témában.
{{% /alert %}} 

Ez a Java kód megmutatja, hogyan állítható be a háttér egy bemutatóhoz:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Index útmutató**: 0 a kitöltés nélküli. Az index 1‑től kezdődik.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/androidjava/presentation-background/).
{{% /alert %}}

## **Téma effektus módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílus tömbhöz. Ezek a tömbök ezekbe a 3 effektusba kombinálódnak: finom, közepes és intenzív. Például ez a végeredmény, amikor az effektusokat egy adott alakzatra alkalmazzák:

![todo:image_alt_text](presentation-design_10.png)

A [FillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--) három tulajdonság használatával a [FormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme)‑osztályból módosíthatja a téma elemeit (még rugalmasabban, mint a PowerPoint beállításai).

Ez a Java kód bemutatja, hogyan változtatható meg egy téma effektus az elemek részeinek módosításával:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

A kapott változások a kitöltő színben, a kitöltő típusban, az árnyék effektusban stb.:
![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

### Alkalmazhatok témát egyetlen diára a mester módosítása nélkül?

Igen. Az Aspose.Slides támogatja a diaszintű téma felülbírálásokat, így egy helyi témát alkalmazhat csak arra a diára, miközben a mester témát változatlanul hagyja (a [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/) segítségével).

### Mi a legbiztonságosabb módja egy téma átvitelének egy bemutatóból a másikba?

A [Clone slides](/slides/hu/androidjava/clone-slides/) a mesterrel együtt a célbemutatóba másolásával. Ez megőrzi az eredeti mestert, az elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

### Hogyan tekinthetem meg a „tényleges” értékeket az összes öröklődés és felülbírálás után?

Használja az API ["effective" nézeteit](/slides/hu/androidjava/shape-effective-properties/) a téma/szín/betűtípus/effektus esetén. Ezek a feloldott, végső tulajdonságokat adják vissza a mester és az esetleges helyi felülbírálások alkalmazása után.