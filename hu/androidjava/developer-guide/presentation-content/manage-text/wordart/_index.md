---
title: WordArt hatások létrehozása és alkalmazása Androidon
linktitle: WordArt
type: docs
weight: 110
url: /hu/androidjava/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt effektus
- árnyék effektus
- megjelenítési effektus
- ragyogás effektus
- WordArt átalakítás
- 3D effektus
- külső árnyék effektus
- belső Shadow effektus
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "WordArt effektusok létrehozása és testreszabása az Aspose.Slides for Android-ban. Ez a lépésről‑lépésre útmutató segít a fejlesztőknek, hogy Java-ban professzionális szöveggel gazdagítsák a bemutatóikat."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk a PowerPoint bemutatókhoz. Az Aspose.Slides segítségével a fejlesztők programozottan létrehozhatják, testreszabhatják és kezelhetik a WordArt-ot, akárcsak a Microsoft PowerPointban – anélkül, hogy az Office telepítve lenne. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegalakítások, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a bemutató tartalma kifejezőbb és lebilincselőbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Olyan hatásokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy vonzóbbá vagy feltűnőbbé tegyék.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Using Aspose.Slides** 

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
Ezután a szöveg betűméretét nagyobb értékre állítjuk, hogy a hatás jobban látható legyen, a következő kóddal:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

Navigáljon a WordArt hatások menüjéhez a Microsoft PowerPointban:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat egy előre definiált WordArt hatást. A bal oldali menüből adhatja meg az új WordArt beállításait. 

Ezek a rendelkezésre álló paraméterek vagy opciók egy része:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Itt a [SmallGrid](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PatternStyle#SmallGrid) minta színét alkalmazzuk a szövegre, és egy 1-es vastagságú fekete szövegkeretet adunk hozzá a következő kóddal:

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

**Using Microsoft PowerPoint**

A program felületéről ezeket a hatásokat szövegre, szövegtömbre, alakzatra vagy hasonló elemre alkalmazhatja:

![todo:image_alt_text](image-20200930114129-5.png)

Például a Shadow, Reflection és Glow hatásokat szövegre, a 3D Format és 3D Rotation hatásokat szövegtömbre, a Soft Edges tulajdonságot Shape Object-re lehet alkalmazni (akkor is hatása van, ha nincs 3D Format beállítva). 

### **Árnyékhatások alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat kívánjuk beállítani. A szövegre a következő Java kóddal alkalmazzuk az árnyékhatást:

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

Az Aspose.Slides API háromféle árnyékot támogat: OuterShadow, InnerShadow és PresetShadow. 

A PresetShadow segítségével előre definiált értékekkel alkalmazhat árnyékot a szövegre. 

**Using Microsoft PowerPoint**

A PowerPointban egyetlen árnyéktípust használhat. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Az Aspose.Slides valójában kétféle árnyékot enged egyszerre alkalmazni: InnerShadow és PresetShadow.

**Notes:**

- Ha az OuterShadow és a PresetShadow együtt van használva, csak az OuterShadow hatás kerül alkalmazásra. 
- Ha az OuterShadow és az InnerShadow egyszerre van használva, a keletkezett vagy alkalmazott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013 esetén a hatás duplázódik, míg a PowerPoint 2007-ben az OuterShadow hatás kerül alkalmazásra. 

### **Visszatükrözés hatások alkalmazása szövegre**

A szöveghez visszatükrözést adunk a következő Java kódrészlettel:

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

### **Ragyogás hatás alkalmazása szövegre**

A szövegre ragyogás hatást alkalmazunk, hogy kiemelkedjen, a következő kóddal:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Az árnyék, a visszatükrözés és a ragyogás paramétereit módosíthatja. A hatások tulajdonságai minden szövegrészen külön-külön kerülnek beállításra. 

{{% /alert %}} 

### **Átalakítások használata WordArt-ban**

A Transform tulajdonságot (amely az egész szövegtömbre vonatkozik) a következő kóddal használjuk:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Mind a Microsoft PowerPoint, mind az Androidra szánt Aspose.Slides Java segítségével egy meghatározott számú előre definiált átalakítási típust biztosít.

{{% /alert %}} 

**Using PowerPoint**

Az előre definiált átalakítási típusok eléréséhez lépjen a: **Formátum** -> **Szöveheffektus** -> **Átalakítás** menüpontokra.

**Using Aspose.Slides**

Az átalakítási típus kiválasztásához használja a TextShapeType felsorolt típust (enum). 

### **3D hatások alkalmazása szövegre és alakzatokra**

Egy 3D hatást állítunk be egy szöveg alakzatra a következő mintakóddal:

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

3D hatást alkalmazunk a szövegre a következő Java kóddal:

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

A 3D hatások szövegekre vagy azok alakzataira való alkalmazása, valamint a hatások közötti kölcsönhatások bizonyos szabályokon alapulnak. 

Tekintsen egy jelenetet a szöveghez és a szöveget tartalmazó alakzathoz. A 3D hatás tartalmazza a 3D objektum ábrázolását és a jelenetet, amelyre az objektum el van helyezve. 

- Ha a jelenet mind a forma, mind a szöveg számára be van állítva, a forma jelenete magasabb prioritást kap – a szöveg jelenete figyelmen kívül marad. 
- Ha a formának nincs saját jelenete, de 3D ábrázolása van, a szöveg jelenete kerül használatra. 
- Ellenkező esetben – ha az alakzat eredetileg nincs 3D hatással – az alakzat lapos, és a 3D hatás csak a szövegre kerül alkalmazásra. 

Ezek a leírások a ThreeDFormat.getLightRig() és ThreeDFormat.getCamera() metódusokhoz kapcsolódnak.

{{% /alert %}} 

## **Külső árnyék hatások alkalmazása szövegre**
Aspose.Slides for Android via Java a [**IOuterShadow**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioutershadow/) és [**IInnerShadow**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinnershadow/) osztályokat biztosítja, amelyek lehetővé teszik árnyékhatások alkalmazását a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)-ben lévő szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg egy diát az indexével.  
3. Adjon egy Rectangle típusú AutoShape-et a diához.  
4. Hozzáférés a AutoShape-hez tartozó TextFrame-hez.  
5. Állítsa az AutoShape FillType-ját NoFill-re.  
6. Hozzon létre egy OuterShadow példányt  
7. Állítsa be az árnyék BlurRadius értékét.  
8. Állítsa be az árnyék Direction értékét  
9. Állítsa be az árnyék Distance értékét.  
10. Állítsa a RectanglelAlign értékét TopLeft-re.  
11. Állítsa a shadow PresetColor értékét Black-re.  
12. Írja a prezentációt PPTX fájlként.

Ez a Java példakód – a fenti lépések megvalósítása – megmutatja, hogyan lehet külső árnyék hatást alkalmazni egy szövegre:

```java
Presentation pres = new Presentation();
try {
    // A dia hivatkozásának lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Egy Rectangle típusú AutoShape hozzáadása
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame hozzáadása a Rectangle-hez
    ashp.addTextFrame("Aspose TextBox");

    // Alakzat kitöltésének letiltása, ha a szöveg árnyékát szeretnénk
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Külső árnyék hozzáadása és az összes szükséges paraméter beállítása
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // A prezentáció mentése lemezre
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belső árnyék hatások alkalmazása alakzatokra**
Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
2. Szerezzen referenciát a diára.  
3. Adjon egy Rectangle típusú AutoShape-et.  
4. Engedélyezze az InnerShadowEffect-et.  
5. Állítsa be az összes szükséges paramétert.  
6. Állítsa a ColorType-ot Scheme-re.  
7. Állítsa be a Scheme színt.  
8. Írja a prezentációt PPTX fájlként.

Ez a példa (a fenti lépések alapján) bemutatja, hogyan adhat hozzá egy csatlakozót két alakzat között Java-ban:

```java
Presentation pres = new Presentation();
try {
    // A dia hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Egy Rectangle típusú AutoShape hozzáadása
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // TextFrame hozzáadása a Rectangle-hez
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Belső árnyék hatás engedélyezése
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Az összes szükséges paraméter beállítása
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // A ColorType beállítása Scheme-re
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // A Scheme szín beállítása
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Prezentáció mentése
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Alkalmazhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides támogatja az Unicode-ot és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatásokat, mint árnyék, kitöltés és körvonal, a nyelvtől függetlenül alkalmazhatja, bár a betűtípus elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt hatásokat a diamester elemeire?**

Igen, a diamester diákon lévő alakzatokra, például címhelyőrzőkre, láblécre vagy háttérszövegre is alkalmazhat WordArt hatásokat. A mesterelrendezésben végzett módosítások minden kapcsolódó diára kihatnak.

**Növelik a WordArt hatások a bemutató fájlméretét?**

Kissé. Az árnyék, ragyogás és színátmenetes kitöltés hatások kissé növelhetik a fájlméretet a formázási metaadatok hozzáadása miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét anélkül, hogy elmenteném a bemutatót?**

Igen, a WordArt-ot tartalmazó diákat renderelheti képekké (például PNG, JPEG) a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) vagy [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) interfész `getImage` metódusával. Ez lehetővé teszi a végeredmény előzetes megtekintését memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.