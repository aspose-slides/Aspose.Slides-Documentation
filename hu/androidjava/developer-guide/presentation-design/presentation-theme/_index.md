---
title: Manage Presentation Themes on Android
linktitle: Presentation Theme
type: docs
weight: 10
url: /hu/androidjava/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
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
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Androidban Java segítségével a PowerPoint fájlok egységes arculattal való létrehozásához, testreszabásához és átalakításához."
---
## **Bevezetés**

A prezentációs téma meghatározza a tervezési elemek tulajdonságait. Ha egy prezentációs témát választ, lényegében egy adott vizuális elemek és azok tulajdonságainak halmazát választja ki.

PowerPointban egy téma színeket, [betűtípusokat](/slides/hu/androidjava/powerpoint-fonts/), [háttérstílusokat](/slides/hu/androidjava/presentation-background/), és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

A PowerPoint téma egy adott színkészletet használ a dián lévő különböző elemekhez. Ha nem tetszenek a színek, új színeket alkalmazva megváltoztathatja őket a témában. Ahhoz, hogy új téma színt válasszon, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SchemeColor) felsorolásban értékeket biztosít.

Ez a Java kód megmutatja, hogyan lehet megváltoztatni a téma akcentusszínét:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Így határozhatja meg a kapott szín tényleges értékét:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

A színmódosítás műveletének további bemutatásához létrehozunk egy másik elemet, és az akcentusszínt (az első műveletből) hozzárendeljük hozzá. Ezután megváltoztatjuk a színt a témában:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Téma színének beállítása kiegészítő palettáról**

Amikor luminancia-transzformációkat alkalmaz a fő téma színére(1), a kiegészítő palettáról(2) színek alakulnak ki. Ezután beállíthatja és lekérheti ezeket a téma színeket.

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő téma színek  
**2** - A kiegészítő palettáról származó színek.

Ez a Java kód bemutat egy műveletet, ahol a kiegészítő paletta színét a fő téma színéből nyerik, majd alakzatokban használják:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcentus 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcentus 4, 80%-ban világosabb
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcentus 4, 60%-ban világosabb
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcentus 4, 40%-ban világosabb
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcentus 4, 25%-ban sötétebb
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcentus 4, 50%-ban sötétebb
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` leképezése az `IColorScheme` színekre**

Ha a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) használatával dolgozik, észreveheti, hogy a következő téma színértékeket tartalmazza:

`Background1`, `Background2`, `Text1`, and `Text2`.

Azonban a `Presentation.getMasterTheme().getColorScheme()` visszaad egy [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) objektumot, amely a megfelelő színeket a következőképpen teszi elérhetővé:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Ez a különbség csak a névben van. Ezek az értékek ugyanazokra a téma színhelyekre vonatkoznak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Ezek egyszerűen azonos téma színek alternatív nevei.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` neveket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **Téma betűtípusának módosítása**

A témákhoz és egyéb célokra történő betűtípus‑választáshoz az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** – Test betűtípusa Latin (Minor Latin Font)
* **+mj-lt** – Címsor betűtípusa Latin (Major Latin Font)
* **+mn-ea** – Test betűtípusa Kelet‑Ázsiai (Minor East Asian Font)
* **+mj-ea** – Címsor betűtípusa Kelet‑Ázsiai (Major East Asian Font)

Ez a Java kód megmutatja, hogyan lehet a latin betűtípust hozzárendelni egy téma elemhez:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Ez a Java kód megmutatja, hogyan lehet megváltoztatni a prezentáció téma betűtípusát:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Az összes szövegmező betűtípusa frissülni fog.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret kínál, de egy tipikus prezentációban csak 3 közülük kerül mentésre. 

![todo:image_alt_text](presentation-design_8.png)

Például, miután elment egy prezentációt a PowerPoint alkalmazásban, futtathatja ezt a Java kódot, hogy megtudja a prezentációban lévő előre definiált háttérképek számát:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme) osztályból használva hozzáadhat vagy elérhet háttérstílust egy PowerPoint témában.
{{% /alert %}} 

Ez a Java kód megmutatja, hogyan lehet beállítani a háttérképet egy prezentációhoz:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index útmutató**: 0 jelzi a kitöltés hiányát. Az indexelés 1‑től kezdődik.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/androidjava/presentation-background/).
{{% /alert %}}

## **Téma effektusának módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílusorhoz. Ezek az sorok összeolvadnak ez a 3 effektusba: finom, mérsékelt és intenzív. Például ez a végeredmény, amikor az effektusokat egy adott alakzatra alkalmazzák:

![todo:image_alt_text](presentation-design_10.png)

A [FillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--) három tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FormatScheme) osztályból használva módosíthatja a téma elemeit (még rugalmasabban, mint a PowerPoint beállításai).

```java
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

Az eredményül kapott változások a kitöltő színben, a kitöltés típusában, az árnyék effektusban stb.:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok‑e témát egyetlen diára anélkül, hogy a master témát módosítanám?**  
Igen. Az Aspose.Slides támogatja a diaszintű téma felülbírálást, így egy helyi témát alkalmazhat csak arra a diára, miközben a master téma változatlan marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/) használatával).

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációról a másikra?**  
[Clone slides](/slides/hu/androidjava/clone-slides/) a mesterrel együtt a célprezentációba. Ez megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó témát, így a megjelenés következetes marad.

**Hogyan tekinthetem meg a „hatékony” értékeket minden öröklődés és felülbírálás után?**  
Használja az API ["effective" nézeteit](/slides/hu/androidjava/shape-effective-properties/) a téma/szín/betűtípus/effektus esetében. Ezek a mester és a helyi felülbírálások alkalmazása után a végleges, feloldott tulajdonságokat adják vissza.