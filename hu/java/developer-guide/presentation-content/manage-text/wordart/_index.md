---
title: WordArt hatások létrehozása és alkalmazása Java-ban
linktitle: WordArt
type: docs
weight: 110
url: /hu/java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt effektus
- árnyék effektus
- megjelenítés effektus
- glow effektus
- WordArt transzformáció
- 3D effektus
- külső árnyék effektus
- belső árnyék effektus
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "WordArt hatásokat hozhat létre és testreszabhat az Aspose.Slides for Java-ban. Ez a lépésről-lépésre útmutató segít a fejlesztőknek a prezentációk professzionális szöveggel történő gazdagításában Java-ban."
---
## **Áttekintés**

A WordArt effektusok lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk a PowerPoint‑prezentációkhoz. Az Aspose.Slides‑szel a fejlesztők programozottan hozhatnak létre, testre szabhatnak és kezelhetnek WordArt‑ot, akárcsak a Microsoft PowerPoint‑ban – anélkül, hogy az Office‑t telepíteni kellene. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegre vonatkozó átalakítások, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a prezentáció tartalma kifejezőbb és lebilincselőbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Effektek vagy speciális módosítások alkalmazásával a szöveget vonzóbbá vagy feltűnőbbé tehetjük.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Aspose.Slides használata** 

Először egy egyszerű szöveget hozunk létre ezzel a Java kóddal: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Most a szöveg betűmagasságát nagyobb értékre állítjuk, hogy a hatás jobban látható legyen, ezzel a kóddal:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPoint használata**

Nyissa meg a WordArt effektus menüt a Microsoft PowerPointban:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat egy előre definiált WordArt effektust. A bal oldali menüből megadhatja egy új WordArt beállításait. 

Ezek a rendelkezésre álló paraméterek vagy lehetőségek:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides használata**

Itt a [SmallGrid](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PatternStyle#SmallGrid) minta színt alkalmazzuk a szövegre, és 1 képpontos fekete szövegkeretet adunk hozzá ezzel a kóddal:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Az eredményül kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt hatások alkalmazása**

**Microsoft PowerPoint használata**

A program felületéről ezek a hatások alkalmazhatók szövegre, szövegtömbre, alakzatra vagy hasonló elemre:

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, a Tükör és a Glow hatásokat szövegre, a 3D Formátum és 3D Forgatás hatásokat szövegtömbre, a Lágy Szélek tulajdonságot alakzatra (akár 3D Formátum tulajdonság nélkül) lehet alkalmazni. 

### **Árnyék hatások alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat állítjuk be. A szövegre árnyékhatást alkalmazzuk ezzel a Java kóddal:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Az Aspose.Slides API három típusú árnyékot támogat: OuterShadow, InnerShadow és PresetShadow. 

A PresetShadow segítségével előre definiált értékekkel alkalmazhat árnyékot a szövegre. 

**Microsoft PowerPoint használata**

A PowerPointban csak egy árnyéktípust használhat. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides használata**

Az Aspose.Slides valójában egyszerre két árnyéktípust engedélyez: InnerShadow és PresetShadow.

**Megjegyzések:**

- Ha az OuterShadow és a PresetShadow együtt van használva, csak az OuterShadow hatás kerül alkalmazásra. 
- Ha az OuterShadow és az InnerShadow egyszerre van használva, a kapott vagy alkalmazott hatás a PowerPoint verziójától függ. Például PowerPoint 2013‑ban a hatás duplázódik, míg PowerPoint 2007‑ben az OuterShadow hatás kerül alkalmazásra. 

### **Megjelenítés alkalmazása szövegekre**

A szöveghez megjelenítést (display) adunk hozzá ezzel a Java kódrészlettel:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Glow hatás alkalmazása szövegekre**

A glow hatást a szövegre alkalmazzuk, hogy ragyogjon vagy kitűnjön, ezzel a kóddal:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

A shadow, display és glow paramétereit módosíthatja. A hatások tulajdonságait a szöveg minden részére külön‑külön állítják be. 

{{% /alert %}} 

### **Transzformációk használata WordArt-ban**

A Transform tulajdonságot (ami a teljes szövegtömbre vonatkozik) ezzel a kóddal használjuk:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

A Microsoft PowerPoint és az Aspose.Slides for Java egy bizonyos számú előre definiált transzformációs típust biztosít. 

{{% /alert %}} 

**PowerPoint használata**

Az előre definiált transzformációs típusok eléréséhez lépjen a következőre: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides használata**

A transzformációs típus kiválasztásához használja a TextShapeType enum‑ot. 

### **3D hatások alkalmazása szövegekre és alakzatokra**

Ezzel a mintakóddal 3D hatást állítunk be egy szöveg alakzatra:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Az eredményül kapott szöveg és alakzata:

![todo:image_alt_text](image-20200930114816-9.png)

Ezzel a Java kóddal 3D hatást alkalmazunk a szövegre:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A 3D hatások szövegekre vagy alakzataikra való alkalmazása, valamint a hatások közötti kölcsönhatások bizonyos szabályokon alapulnak. 

Tekintsen egy jelenetet a szöveghez és a szöveget tartalmazó alakzatra. A 3D hatás magában foglalja a 3D objektum ábrázolását és a jelenetet, amelyre az objektum kerül. 

- Ha a jelenet mind a alakzatra, mind a szövegre be van állítva, akkor az alakzat jelenete kapja a magasabb prioritást – a szöveg jelenete figyelmen kívül marad. 
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete lesz használva. 
- Egyébként – ha az alakzat eredetileg nincs 3D hatással – az alakzat lapos, és a 3D hatás csak a szövegre kerül alkalmazásra. 

Ezek a leírások a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusokhoz kapcsolódnak. 

{{% /alert %}} 

## **Külső árnyék hatások alkalmazása szövegekre**
Az Aspose.Slides for Java a [**IOuterShadow**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioutershadow/) és a [**IInnerShadow**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinnershadow/) osztályokat kínálja, amelyek lehetővé teszik, hogy árnyékhatásokat alkalmazzunk a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) által tartott szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon egy Rectangle típusú AutoShape‑et a diára.  
4. Szerezze meg az AutoShape‑hez kapcsolódó TextFrame‑et.  
5. Állítsa az AutoShape FillType‑ját NoFill‑re.  
6. Hozzon létre egy OuterShadow példányt.  
7. Állítsa be az árnyék BlurRadius‑át.  
8. Állítsa be az árnyék Direction‑ját.  
9. Állítsa be az árnyék Distance‑ét.  
10. Állítsa be a RectanglelAlign‑t TopLeft‑ra.  
11. Állítsa be az árnyék PresetColor‑át Black‑re.  
12. Mentse a prezentációt PPTX fájlként.

Ez a Java mintakód – a fenti lépések megvalósítása – bemutatja, hogyan alkalmazhatja a külső árnyék hatást szövegre:

```java
Presentation pres = new Presentation();
try {
    // Szerezze meg a dia hivatkozását
    ISlide sld = pres.getSlides().get_Item(0);

    // Hozzon létre Rectangle típusú AutoShape-et
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Szövegkeretet (TextFrame) ad a Rectangle-hez
    ashp.addTextFrame("Aspose TextBox");

    // Tiltsa le az alakzat kitöltését, ha a szöveg árnyékát szeretné megkapni
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Külső árnyék hozzáadása és az összes szükséges paraméter beállítása
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Mentse a prezentációt lemezre
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belső árnyék hatás alkalmazása alakzatokra**
Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciáját.  
3. Adjon egy Rectangle típusú AutoShape‑et.  
4. Engedélyezze az InnerShadowEffect‑et.  
5. Állítsa be az összes szükséges paramétert.  
6. Állítsa be a ColorType‑ot Scheme‑re.  
7. Állítsa be a Scheme Color‑t.  
8. Mentse a prezentációt PPTX fájlként.

Ez a mintakód (a fenti lépések alapján) megmutatja, hogyan adhat hozzá egy kapcsolatot két alakzat között Java‑ban:

```java
Presentation pres = new Presentation();
try {
    // A dia hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle típusú AutoShape hozzáadása
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // TextFrame hozzáadása a Rectangle-hez
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Belső árnyék effektus engedélyezése
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Az összes szükséges paraméter beállítása
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType beállítása Scheme-re
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme szín beállítása
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Prezentáció mentése
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides támogatja a Unicode‑ot, és minden főbb betűtípussal és írásrendszerrel működik. A WordArt hatásokat, például árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatja, bár a betűtípusok rendelkezésre állása és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt hatásokat a diamester elemeire?**

Igen, a WordArt hatásokat mesterdia alakzatokra is alkalmazhatja, beleértve a címhelyettesítőket, lábléceket vagy háttérszövegeket. A mester elrendezésében végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Enyhén. A shadow, glow és gradient kitöltések kisebb mértékben növelhetik a fájlméretet a formázási metaadatok hozzáadása miatt, de a különbség általában elhanyagolható.

**Megtekinthetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diákat képekké (például PNG, JPEG) renderelheti a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) vagy a [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) interfész `getImage` metódusával. Ez lehetővé teszi a végeredmény előnézetét memória‑ vagy képernyőalapon a teljes prezentáció mentése vagy exportálása előtt.