---
title: Bemutató sablonok kezelése Java-ban
linktitle: Bemutató sablon
type: docs
weight: 10
url: /hu/java/presentation-theme/
keywords:
- PowerPoint sablon
- bemutató sablon
- dia sablon
- sablon beállítása
- sablon módosítása
- sablon kezelése
- sablon szín
- kiegészítő paletta
- sablon betűtípus
- sablon stílus
- sablon effektus
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java fő bemutató sablonjaival PowerPoint fájlokat hozhat létre, testreszabhat és konvertálhat egységes márkázás mellett."
---
## **Bevezetés**

A bemutató sablon meghatározza a tervezési elemek tulajdonságait. Amikor egy bemutató sablont választasz, lényegében egy adott vizuális elemek és azok tulajdonságainak halmazát választod ki.

PowerPointban a sablon színeket, [betűtípusokat](/slides/hu/java/powerpoint-fonts/), [háttérstílusokat](/slides/hu/java/presentation-background/), és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **A sablon színének módosítása**

A PowerPoint sablon meghatározott színkészletet használ egy dia különböző elemeihez. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatod őket a sablonban. Ahhoz, hogy új sablonszínt válassz, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SchemeColor) felsorolásban értékeket biztosít.

Ez a Java kód megmutatja, hogyan változtatható meg a sablon hangsúlyszíne:

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

Így meghatározhatod a kapott szín tényleges értékét:

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

A színmódosítás további bemutatásához létrehozunk egy másik elemet, és ráadjuk a hangsúlyszínt (az első műveletből). Ezután megváltoztatjuk a színt a sablonban:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Az új szín automatikusan alkalmazásra kerül mindkét elemen.

### **Sablonszín beállítása kiegészítő palettáról**

Amikor luminancia-transzformációkat alkalmazol a fő sablonszínre(1), a kiegészítő palettáról(2) színek keletkeznek. Ezeket a sablonszíneket ezután beállíthatod és lekérheted.

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő sablonszínek  
**2** - A kiegészítő palettáról származó színek.

Ez a Java kód bemutat egy műveletet, ahol a kiegészítő paletta színeit a fő sablonszínből nyerik, majd alakzatokban használják:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcentus 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcentus 4, Világosabb 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcentus 4, Világosabb 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcentus 4, Világosabb 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcentus 4, Sötétebb 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcentus 4, Sötétebb 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **A `SchemeColor` leképezése az `IColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/)‑vel dolgozol, észreveheted, hogy a következő sablonszínértékeket tartalmazza: `Background1`, `Background2`, `Text1` és `Text2`.

Azonban a `Presentation.getMasterTheme().getColorScheme()` a [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/)‑t adja vissza, amely a megfelelő színeket a következőképpen teszi elérhetővé: `Dark1`, `Dark2`, `Light1` és `Light2`.

Ez a különbség csak a névben rejlik. Ezek az értékek ugyanazokra a sablonszínhelyekre vonatkoznak, és a leképezés állandó:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Csak alternatív nevei ugyanannak a sablonszínnek.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` neveket használták, míg az újabb UI verziók ugyanazokat a helyeket a `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **A sablon betűtípusának módosítása**

Ahhoz, hogy betűtípusokat válassz a sablonokhoz és egyéb célokra, az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** - Törzs betűtípus Latin (Minor Latin Font)
* **+mj-lt** - Címsor betűtípus Latin (Major Latin Font)
* **+mn-ea** - Törzs betűtípus Kelet-Ázsiai (Minor East Asian Font)
* **+mj-ea** - Törzs betűtípus Kelet-Ázsiai (Major East Asian Font)

Ez a Java kód megmutatja, hogyan rendelj Latin betűtípust egy sablon elemhez:

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

Ez a Java kód bemutatja, hogyan változtatható meg a bemutató sablon betűtípusa:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

A betűtípus minden szövegdobozban frissülni fog.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/java/powerpoint-fonts/). 
{{% /alert %}}

## **A sablon háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret kínál, de egy tipikus bemutatóban csak 3 közülük mentődik el. 

![todo:image_alt_text](presentation-design_8.png)

Például, miután elmented a bemutatót a PowerPoint alkalmazásban, futtathatod ezt a Java kódot, hogy megállapítsd a bemutatóban lévő előre definiált hátterek számát:

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
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme) osztályból használva hozzáadhatsz vagy elérheted a háttérstílust egy PowerPoint sablonban. 
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

**Index útmutató**: 0 jelenti a kitöltés hiányát. Az index 1‑től indul.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/java/presentation-background/). 
{{% /alert %}}

## **A sablon effektusának módosítása**

A PowerPoint sablon általában három értéket tartalmaz minden stílus tömbben. Ezek a tömbök három effektusba egyesülnek: finom, közepes és intenzív. Például ez a végeredmény, amikor az effektusokat egy adott alakzatra alkalmazzuk:

![todo:image_alt_text](presentation-design_10.png)

A [FillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getEffectStyles--) tulajdonságok használatával a [FormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme) osztályból módosíthatod egy sablon elemeit (még rugalmasabban, mint a PowerPoint beállításai).

Ez a Java kód megmutatja, hogyan változtatható meg egy sablon effektus az elemek részeinek módosításával:

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

Az eredményül kapott változások a kitöltő színben, kitöltés típusában, árnyék effektusban stb.:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

### Alkalmazhatok-e sablont egyetlen diára a mester módosítása nélkül?

Igen. Az Aspose.Slides támogatja a diaszintű sablon felülírásokat, így egy helyi sablont alkalmazhatsz csak az adott diára, miközben a mester sablon érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/) segítségével).

### Mi a legbiztonságosabb módja egy sablon átvitelének egy bemutatóból a másikba?

A [Dia másolása](/slides/hu/java/clone-slides/) a masterrel együtt a célbemutatóba. Ez megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó sablont, így a megjelenés konzisztens marad.

### Hogyan tekinthetem meg a “hatékony” értékeket a teljes öröklődés és felülírás után?

Használd az API [„effective” nézeteit](/slides/hu/java/shape-effective-properties/) a sablon/szín/betűtípus/effektus esetén. Ezek a mester és a helyi felülírások alkalmazása után feloldott, végleges tulajdonságokat adják vissza.