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
- WordArt hatás
- árnyék hatás
- megjelenítési hatás
- fényhatás
- WordArt transzformáció
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Hozzon létre és testreszabjon WordArt hatásokat az Aspose.Slides for Java-ban. Ez a lépésről-lépésre útmutató segít a fejlesztőknek a prezentációk professzionális szöveggel való gazdagításában Java-ban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk hozzá PowerPoint‑prezentációihoz. Az Aspose.Slides segítségével a fejlesztők programozottan hozhatnak létre, testreszabhatnak és kezelhetnek WordArt‑ot, akár a Microsoft PowerPointben – anélkül, hogy az Office telepítve lenne. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegtranszformációk, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a prezentáció tartalma kifejezőbb és vonzóbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Olyan effektusokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Az Aspose.Slides használata** 

Először egy egyszerű szöveget hozunk létre ezzel a Java kóddal: 

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
Most a szöveg betűméretét nagyobb értékre állítjuk, hogy a hatás jobban észrevehető legyen, a következő kóddal:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Microsoft PowerPoint használata**

Navigáljon a WordArt hatások menüjéhez a Microsoft PowerPointben:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat előre definiált WordArt hatást. A bal oldali menüből adhatja meg az új WordArt beállításait. 

A következők a rendelkezésre álló paraméterek vagy beállítások közül néhány:

![todo:image_alt_text](image-20200930114015-3.png)

**Az Aspose.Slides használata**

Itt a szövegre a [SmallGrid](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PatternStyle#SmallGrid) mintaszínt alkalmazzuk, és egy 1‑pixel széles fekete szövegkeretet adunk ehhez a kóddal:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Az eredményül kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt hatások alkalmazása**

**Microsoft PowerPoint használata**

A program felületéről ezeket a hatásokat alkalmazhatja szövegre, szövegblokkra, alakzatra vagy hasonló elemre:

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, a Tükrözés és a Fénylés hatásokat szövegre, a 3D formátum és 3D forgatás hatásokat szövegblokkra, a Lágy szegély tulajdonságot pedig alakzatra lehet alkalmazni (akkor is hat, ha nincs 3D formátum beállítva). 

### **Árnyék hatások alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat állítjuk be. A szöveghez árnyékhatást alkalmazzuk a következő Java kóddal:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

A PresetShadow segítségével előre definiált értékekkel lehet árnyékot alkalmazni szövegre. 

**Microsoft PowerPoint használata**

A PowerPointben csak egy árnyéktípust lehet használni. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Az Aspose.Slides használata**

Az Aspose.Slides valójában egyszerre két árnyéktípust is alkalmazhat: InnerShadow és PresetShadow.

**Megjegyzések:**

- Ha az OuterShadow és a PresetShadow együtt van használva, csak az OuterShadow hatás kerül alkalmazásra. 
- Ha az OuterShadow és az InnerShadow egyszerre van használva, a keletkezett vagy alkalmazott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban a hatás duplázódik, míg a PowerPoint 2007‑ben az OuterShadow hatás kerül alkalmazásra. 

### **Megjelenítés alkalmazása a szövegekre**

Az alábbi Java kódrészlettel adunk megjelenítést a szöveghez:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Fénylés hatás alkalmazása a szövegekre**

A következő kóddal alkalmazzuk a fénylés hatást a szövegre, hogy az ragyogjon vagy kiemelkedjen:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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
Árnyék, megjelenítés és fénylés paramétereit módosíthatja. A hatások tulajdonságai a szöveg egyes részeire külön-külön kerülnek beállításra. 
{{% /alert %}} 

### **Transzformációk használata a WordArt-ban**

A teljes szövegblokkra jellemző Transform tulajdonságot az alábbi kóddal használjuk:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
A Microsoft PowerPoint és az Aspose.Slides for Java egyaránt bizonyos számú előre definiált transzformáció típust biztosít. 
{{% /alert %}} 

**PowerPoint használata**

Az előre definiált transzformáció típusok eléréséhez navigáljon: **Formátum** -> **Szövegeffektus** -> **Transzformáció**

**Az Aspose.Slides használata**

A transzformáció típus kiválasztásához használja a TextShapeType felsorolást. 

### **3D hatások alkalmazása szövegekre és alakzatokra**

Ezzel a példakóddal 3D hatást állítunk be egy szövegalakzatra:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Ezzel a Java kóddal 3D hatást alkalmazunk a szövegre:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Tekintsen egy jelenetre a szöveg és a szöveget tartalmazó alakzat számára. A 3D hatás tartalmazza a 3D objektum ábrázolását és a jelenetet, amelyre az objektum elhelyezésre kerül.

- Ha a jelenet mind a figurára, mind a szövegre be van állítva, a figura jelenet a magasabb prioritást kapja – a szöveg jelenet figyelmen kívül marad.
- Ha a figurának nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenet kerül használatra.
- Egyébként – ha az alakzat eredetileg nincs 3D hatással – az alakzat sík, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a leírások a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusokra vonatkoznak.
{{% /alert %}} 

## **Külső árnyék hatások alkalmazása szövegekre**
Aspose.Slides for Java a [**IOuterShadow**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioutershadow/) és a [**IInnerShadow**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinnershadow/) osztályokat biztosítja, amelyek lehetővé teszik árnyékhatások alkalmazását a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) által hordozott szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be egy dia hivatkozását az indexe használatával.  
3. Adjon egy Rectangle típusú AutoShape‑t a diára.  
4. Érje el az AutoShape‑hez kapcsolódó TextFrame‑et.  
5. Állítsa be az AutoShape FillType‑ját NoFill értékre.  
6. Példányosítsa az OuterShadow osztályt  
7. Állítsa be az árnyék BlurRadius‑át.  
8. Állítsa be az árnyék Direction‑át.  
9. Állítsa be az árnyék Distance‑át.  
10. Állítsa be a RectanglelAlign‑t TopLeft értékre.  
11. Állítsa be az árnyék PresetColor‑ját Black értékre.  
12. Írja a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  

Ez a Java példakód – a fenti lépések megvalósítása – megmutatja, hogyan alkalmazza a külső árnyék hatást szövegre:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // A dia hivatkozásának lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Hozzon létre egy Rectangle típusú AutoShape-et
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Szövegkeretet ad a Rectangle-hez
    ashp.addTextFrame("Aspose TextBox");

    // Tiltsa le az alakzat kitöltését, ha a szöveg árnyékát szeretné elérni
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

## **Belső árnyék hatás alkalmazása alakzatokra**
Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be a dia hivatkozását.  
3. Adjon egy Rectangle típusú AutoShape‑t.  
4. Engedélyezze az InnerShadowEffect‑et.  
5. Állítsa be a szükséges paramétereket.  
6. Állítsa be a ColorType‑ot Scheme értékre.  
7. Állítsa be a Scheme színt.  
8. Írja a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  

Ez a példakód (a fenti lépések alapján) megmutatja, hogyan alkalmazza a belső árnyék hatást egy alakzat szövegére Java‑ban:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // A dia hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle típusú AutoShape hozzáadása
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Szövegkeret hozzáadása a Rectangle-hez
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

    // ColorType beállítása Scheme-nek
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Schema szín beállítása
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Prezentáció mentése
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Alkalmazhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?
Igen, az Aspose.Slides támogatja az Unicode‑ot és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatásokat, például árnyékot, kitöltést és körvonalat, nyelvtől függetlenül alkalmazni lehet, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

### Alkalmazhatok WordArt hatásokat a dia mester elemeire?
Igen, a mesterdia alakzatain is alkalmazhatja a WordArt hatásokat, beleértve a címsor helyőrzőket, lábléceket vagy háttérszöveget. A mesterelrendezésen végzett módosítások minden kapcsolódó dián megjelennek.

### Befolyásolják a WordArt hatások a prezentáció fájlméretét?
Kismértékben. Az olyan WordArt hatások, mint az árnyékok, fények és gradient kitöltések, kicsit növelhetik a fájlméretet a további formázási metaadatok miatt, de a különbség általában elhanyagolható.

### Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?
Igen, a WordArt‑ot tartalmazó diákat képekké (pl. PNG, JPEG) renderelheti a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) vagy [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) interfész `getImage` metódusával. Ez lehetővé teszi az eredmény memóriában vagy a képernyőn történő előnézetét a teljes prezentáció mentése vagy exportálása előtt.