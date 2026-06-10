---
title: Prezentációs Témák Kezelése Java-ban
linktitle: Prezentációs Téma
type: docs
weight: 10
url: /hu/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Fő prezentációs témák az Aspose.Slides for Java-ban a PowerPoint fájlok egységes márkázással történő létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

Egy prezentációs téma meghatározza a tervezési elemek tulajdonságait. Amikor egy prezentációs témát választ, lényegében egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választja ki.

PowerPointban egy téma színeket, [betűtípusokat](/slides/hu/java/powerpoint-fonts/), [háttérstílusokat](/slides/hu/java/presentation-background/) és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma Színének Módosítása**

A PowerPoint téma egy meghatározott színkészletet használ a dia különböző elemeihez. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatja a témát. Ahhoz, hogy új téma színt válasszon, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SchemeColor) felsorolásban elérhető értékeket biztosítja.

Ez a Java kód megmutatja, hogyan módosíthatja egy téma hangsúlyszínét:
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

Az színváltoztatás műveletének további bemutatásához létrehozunk egy másik elemet, és ráadjuk a hangsúlyszínt (az első műveletből). Ezután megváltoztatjuk a színt a témában:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Téma Színének Beállítása Kiegészítő Palettából**

Amikor a fő téma színére (1) luminancia-transzformációkat alkalmaz, a kiegészítő palettáról (2) színek keletkeznek. Ezeket a téma színeket ezután beállíthatja és lekérheti.

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő téma színek  
**2** - A kiegészítő palettáról származó színek.

Ez a Java kód egy olyan műveletet mutat be, ahol a kiegészítő paletta színeit a fő téma színéből nyerik, majd alakzatokban használják:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 4-es akcentus
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 4-es akcentus, 80%-kal világosabb
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 4-es akcentus, 60%-kal világosabb
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 4-es akcentus, 40%-kal világosabb
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 4-es akcentus, 25%-kal sötétebb
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 4-es akcentus, 50%-kal sötétebb
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **A `SchemeColor` leképezése az `IColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) elemmel dolgozik, észreveheti, hogy a következő témaszínek értékeit tartalmazza:
`Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation.getMasterTheme().getColorScheme()` egy [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) objektumot ad vissza, amely a megfelelő színeket a következőképpen jeleníti meg:
`Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a különbség csak a névben van. Ezek az értékek ugyanazokra a témaszínhelyekre vonatkoznak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen csak alternatív nevei ugyanannak a témaszínnek.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket a `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **Téma Betűtípusának Módosítása**

Az, hogy betűtípusokat válasszon témákhoz és egyéb célokra, az Aspose.Slides ezeket a speciális azonosítókat használja (a PowerPointban használtakhoz hasonlóan):

* **+mn-lt** - Testi betűtípus Latin (Minor Latin Font)
* **+mj-lt** - Fejléc betűtípusa Latin (Major Latin Font)
* **+mn-ea** - Testi betűtípus Kelet-Ázsiai (Minor East Asian Font)
* **+mj-ea** - Testi betűtípusa Kelet-Ázsiai (Major East Asian Font)

Ez a Java kód megmutatja, hogyan rendeljen a latin betűtípust egy témaelemhez:
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Ez a Java kód megmutatja, hogyan változtassa meg a prezentáció téma betűtípusát:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

A betűtípus az összes szövegdobozban frissülni fog.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/java/powerpoint-fonts/).
{{% /alert %}}

## **Téma Háttérstílusának Módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de a tipikus prezentációban ezek közül csak 3 van mentve.

![todo:image_alt_text](presentation-design_8.png)

Például, miután elment egy prezentációt a PowerPoint alkalmazásban, futtathatja ezt a Java kódot, hogy megtudja a prezentációban lévő előre definiált hátterek számát:
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
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonság használatával a [FormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme) osztályból hozzáadhat vagy elérheti a háttérstílust egy PowerPoint témában. 
{{% /alert %}} 

Ez a Java kód megmutatja, hogyan állíthatja be a háttérképet egy prezentációhoz:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index útmutató**: 0 a kitöltés hiányát jelenti. Az index 1‑től indul.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/java/presentation-background/).
{{% /alert %}}

## **Téma Effektusának Módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílus tömbhöz. Ezek a tömbök kombinálódnak a 3 effektusba: finom, közepes és erőteljes. Például, ez a végeredmény, amikor a hatásokat egy adott alakzatra alkalmazzák:
![todo:image_alt_text](presentation-design_10.png)

Az [FillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme#getEffectStyles--) három tulajdonság használatával a [FormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FormatScheme) osztályból módosíthatja a téma elemeit (akár rugalmasabban, mint a PowerPoint beállításai).

Ez a Java kód megmutatja, hogyan változtassa meg egy téma effektust az elemek részeinek módosításával:
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

A kapott változások a kitöltési színben, a kitöltés típusában, az árnyék effektusban stb.:
![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a master-t módosítanám?**  
Igen. Az Aspose.Slides támogatja a dia-szintű téma felülbírálásokat, így egy helyi témát alkalmazhat csak arra a diára, miközben a master téma érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/) segítségével).

**Mi a legbiztonságosabb módja annak, hogy egy témát egyik prezentációból a másikba vigyünk?**  
[Clone slides](/slides/hu/java/clone-slides/) együtt a masterrel a célprezentációba. Ez megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

**Hogyan tekinthetem meg a „tényleges” értékeket minden öröklődés és felülbírálás után?**  
Használja az API [„effective” nézeteit](/slides/hu/java/shape-effective-properties/) a téma/szín/betűtípus/effektus esetén. Ezek a master és a helyi felülbírálások alkalmazása után visszaadják a feloldott, végső tulajdonságokat.