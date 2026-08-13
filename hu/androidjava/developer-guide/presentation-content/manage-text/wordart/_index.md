---
title: "WordArt hatások létrehozása és alkalmazása Androidon"
linktitle: "WordArt"
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
- WordArt transzformáció
- 3D efektus
- külső árnyék effektus
- belső árnyék effektus
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Hozzon létre és testreszabjon WordArt effektusokat az Aspose.Slides for Android segítségével. Ez a lépésről‑lépésre útmutató segít a fejlesztőknek a bemutatók professzionális szövegekkel való gazdagításában Java‑ban."
---
## **Áttekintés**

A WordArt effektusok lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adj hozzá a PowerPoint előadásaidhoz. Az Aspose.Slides-szel a fejlesztők programozott módon létrehozhatják, testreszabhatják és kezelhetik a WordArt-ot, akárcsak a Microsoft PowerPointben – anélkül, hogy az Office telepítve lenne. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve, hogyan alkalmazz szövegtranszformációkat, kitöltési stílusokat, kontúrokat, árnyékokat és egyéb formázási lehetőségeket, hogy az előadásod tartalma kifejezőbb és lebilincselőbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeld. Olyan effektusokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Aspose.Slides használata** 

Először egy egyszerű szöveget hozunk létre ebben a Java-kódban: 

``` java
import com.aspose.slides.*;

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
Ezután a szöveg betűmagasságát nagyobb értékre állítjuk, hogy a hatás jobban látható legyen, a következő kóddal:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Microsoft PowerPoint használata**

Nyisd meg a WordArt effektusok menüt a Microsoft PowerPointben:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből egy előre definiált WordArt-effektust választhatsz. A bal oldali menüből egy új WordArt beállításait adhatod meg. 

Az alábbiak a rendelkezésre álló paraméterek vagy beállítások egy része:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides használata**

Itt a [SmallGrid](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PatternStyle#SmallGrid) mintaszínt alkalmazzuk a szövegre, és egy 1 széles fekete szövegszegélyt adunk hozzá a következő kóddal:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Az eredményként kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt effektusok alkalmazása**

**Microsoft PowerPoint használata**

A program felületéről ezek a hatások alkalmazhatók szövegre, szövegtömbre, alakzatra vagy hasonló elemre:

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, Tükröződés és Ragyogás effektusok szövegre alkalmazhatók; a 3D Formátum és 3D Forgatás effektusok szövegtömbre; a Lágy szegélyek tulajdonság egy Alakzat objektumra alkalmazható (akkor is hatása van, ha nincs 3D Formátum beállítva).

### **Árnyék hatások alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat kívánjuk beállítani. A szövegre a következő Java kóddal alkalmazzuk az árnyék hatást:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Az Aspose.Slides API három árnyéktípust támogat: OuterShadow, InnerShadow és PresetShadow. 

A PresetShadow segítségével előre beállított értékekkel alkalmazhatsz árnyékot szövegre. 

**Microsoft PowerPoint használata**

A PowerPointban egyetlen árnyéktípust lehet használni. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides használata**

Az Aspose.Slides valójában egyszerre két árnyéktípust alkalmazhat: InnerShadow és PresetShadow. 

- Ha az OuterShadow és a PresetShadow együtt kerülnek használatra, csak az OuterShadow hatás kerül alkalmazásra. 
- Ha az OuterShadow és az InnerShadow egyszerre használatos, az eredmény vagy alkalmazott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013-ban a hatás duplázódik, míg a PowerPoint 2007-ben az OuterShadow hatás kerül alkalmazásra. 

### **Tükröződés hatások szövegre alkalmazása**

A szöveghez megjelenítést adunk a következő Java kódmintával:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ragyogás hatások szövegre alkalmazása**

A következő kóddal a szövegre ragyogás hatást alkalmazunk, hogy az ragyogjon vagy kiemelkedjen:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Megváltoztathatod az árnyék, a megjelenítés és a ragyogás paramétereit. A hatások tulajdonságai a szöveg egyes részeire külön-külön állíthatók be. 
{{% /alert %}} 

### **Transzformációk használata a WordArt-ban**

A Transform tulajdonságot (amely az egész szövegtömbre jellemző) a következő kóddal használjuk:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
A Microsoft PowerPoint és az Aspose.Slides Androidra Java-val egy bizonyos számú előre definiált transzformációtípusát biztosítja. 
{{% /alert %}} 

**PowerPoint használata**

Az előre definiált transzformációtípusok eléréséhez navigálj: **Formátum** -> **Szövegeffektus** -> **Transzformáció**  

**Aspose.Slides használata**

Egy transzformációtípus kiválasztásához használd a TextShapeType enumerációt. 

### **3D hatások alkalmazása szövegre és alakzatokra**

A következő mintakóddal 3D hatást állítunk be egy szövegalakzatra:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Az eredményül kapott szöveg és alakzata:

![todo:image_alt_text](image-20200930114816-9.png)

A szövegre a következő Java kóddal alkalmazunk 3D hatást:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
A 3D hatások szövegekre vagy azok alakzataira való alkalmazása, valamint a hatások közötti kölcsönhatások bizonyos szabályokon alapulnak.  
Tekintsünk egy jelenetet a szöveghez és a szöveget tartalmazó alakzathoz. A 3D hatás tartalmazza a 3D objektum ábrázolását és a jelenetet, amelyre az objektum elhelyezésre kerül.  

- Ha a jelenet mind a figurára, mind a szövegre be van állítva, a figura jelenete kap magasabb prioritást – a szöveg jelenete figyelmen kívül marad.  
- Ha a figurának nincs saját jelenete, de van 3D ábrázolása, akkor a szöveg jelenete használatos.  
- Egyébként – ha az alakzat eredetileg nincs 3D hatással – az alakzat lapos, és a 3D hatás csak a szövegre kerül alkalmazásra.  

Ezeket a leírásokat a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusok kapcsolják.  
{{% /alert %}} 

## **Külső árnyék hatások alkalmazása szövegre**

Az Aspose.Slides for Android Java-n keresztül biztosítja a [**IOuterShadow**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioutershadow/) és a [**IInnerShadow**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinnershadow/) osztályokat, amelyek lehetővé teszik, hogy egy [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) által tartott szövegre árnyék hatásokat alkalmazz. Kövesd ezeket a lépéseket:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt.  
2. Szerezd meg egy dia hivatkozását az indexének használatával.  
3. Adj hozzá egy Téglalap típusú AutoShape-et a diára.  
4. Érd el az AutoShape-hez tartozó TextFrame-et.  
5. Állítsd be az AutoShape FillType-ját NoFill-re.  
6. Példányosítsd az OuterShadow osztályt.  
7. Állítsd be az árnyék BlurRadius értékét.  
8. Állítsd be az árnyék Direction értékét.  
9. Állítsd be az árnyék Distance értékét.  
10. Állítsd be a RectangleAlign értékét TopLeft-re.  
11. Állítsd be az árnyék PresetColor értékét Black-re.  
12. Írd ki a bemutatót [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  

Ez a Java példa kód – a fenti lépések megvalósítása – megmutatja, hogyan alkalmazz külső árnyék hatást egy szövegre:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Szerezze meg a dia referenciaját
    ISlide sld = pres.getSlides().get_Item(0);

    // Adjunk hozzá egy Téglalap típusú AutoShape-et
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adjunk TextFrame-et a Téglalaphoz
    ashp.addTextFrame("Aspose TextBox");

    // Tiltsuk le az alakzat kitöltését, ha a szöveg árnyékát szeretnénk
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Adjunk külső árnyékot és állítsuk be az összes szükséges paramétert
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Írjuk a bemutatót lemezre
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belső árnyék hatások alkalmazása alakzatokra**

Kövesd ezeket a lépéseket:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt.  
2. Szerezz hivatkozást a diára.  
3. Adj hozzá egy Téglalap típusú AutoShape-et.  
4. Engedélyezd az InnerShadowEffect-et.  
5. Állítsd be az összes szükséges paramétert.  
6. Állítsd be a ColorType-ot Scheme-re.  
7. Állítsd be a Scheme Color-t.  
8. Írd ki a bemutatót [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  

Ez a minta kód (a fenti lépések alapján) megmutatja, hogyan alkalmazz belső árnyék hatást egy szövegre Java-ban:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Szerezze meg a dia referenciaját
    ISlide slide = pres.getSlides().get_Item(0);

    // Adjunk hozzá egy Téglalap típusú AutoShape-et
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Adjunk TextFrame-et a Téglalaphoz
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Engedélyezze a Belső Árnyék effektust
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Állítsa be az összes szükséges paramétert
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Állítsa a ColorType-ot Scheme-re
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Állítsa be a Scheme színt
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Mentse a bemutatót
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Alkalmazhatok WordArt effektusokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?

Igen, az Aspose.Slides támogatja a Unicode-ot, és minden főbb betűtípussal és írásrendszerrel működik. A WordArt effektusok, például az árnyék, a kitöltés és a körvonal alkalmazhatók a nyelvtől függetlenül, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

### Alkalmazhatok WordArt effektusokat a diamester elemeire?

Igen, a WordArt effektusokat alkalmazhatod a mesterdia alakzatain, beleértve a címhelyőrzőket, lábléceket vagy háttérszöveget. A mester elrendezésén végzett módosítások az összes kapcsolódó dián megjelennek.

### Befolyásolják a WordArt effektusok a bemutató fájlméretét?

Enyhén. Az olyan WordArt effektusok, mint az árnyékok, ragyogás vagy a színátmenetes kitöltések, a hozzáadott formázási metaadatok miatt kissé növelhetik a fájlméretet, de a különbség általában elhanyagolható.

### Előnézhetem a WordArt effektusok eredményét a bemutató mentése nélkül?

Igen, a WordArt-ot tartalmazó diákat megjelenítheted képekként (pl. PNG, JPEG) a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) vagy [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) interfészek `getImage` metódusával. Így a teljes bemutató mentése vagy exportálása előtt memóriában vagy a képernyőn is előnézheted az eredményt.