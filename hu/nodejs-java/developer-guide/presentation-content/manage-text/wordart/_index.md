---
title: WordArt hatások létrehozása és alkalmazása JavaScriptben
linktitle: WordArt
type: docs
weight: 110
url: /hu/nodejs-java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyék hatás
- megjelenítési hatás
- ragyogás hatás
- WordArt transzformáció
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for Node.js-ben. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat."
---
## **Áttekintés**

A WordArt‑effektek lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjon PowerPoint‑prezentációihoz. Az Aspose.Slides‑szel a fejlesztők programozottan hozhatnak létre, testre szabhatnak és kezelhetnek WordArt‑ot, akárcsak a Microsoft PowerPoint‑ben – akkor is, ha az Office nincs telepítve. Ez a cikk áttekintést nyújt a WordArt használatáról, többek között arról, hogyan alkalmazhat szövegtranszformációkat, kitöltési stílusokat, körvonalakat, árnyékokat és egyéb formázási lehetőségeket, hogy a prezentáció tartalma kifejezőbb és vonzóbb legyen. A WordArt a szöveget grafikus objektumként kezeli. Olyan hatásokat vagy speciális módosításokat tartalmaz, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Az Aspose.Slides használatával**

Először egy egyszerű szöveget hozunk létre a következő JavaScript‑kóddal:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Ezután a szöveg betűméretét nagyobb értékre állítjuk, hogy a hatás jobban látható legyen a következő kóddal:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**A Microsoft PowerPoint használatával**

Lépjen a WordArt‑effektek menüjébe a Microsoft PowerPoint‑ban:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat előre definiált WordArt‑effektet. A bal oldali menüből adhatja meg egy új WordArt beállításait.

Az elérhető paraméterek vagy opciók egy része:

![todo:image_alt_text](image-20200930114015-3.png)

**Az Aspose.Slides használatával**

Itt a [SmallGrid](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PatternStyle#SmallGrid) minta színt alkalmazzuk a szövegre, és egy 1‑pixel széles fekete szövegkeretet adunk hozzá a következő kóddal:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Az eredményül kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt‑hatások alkalmazása**

**A Microsoft PowerPoint használatával**

A program felületéről ezen hatásokat alkalmazhatja szövegre, szövegtömbre, alakzatra vagy hasonló elemre:

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, Reflexió és Ragyogás hatásokat szövegre, a 3D‑Formátum és 3D‑Forgatás hatásokat szövegtömbre, a Lágy szélek tulajdonságot alakzatra (akár 3D‑Formátum nélkül is) lehet alkalmazni.

### **Árnyékhatások alkalmazása**

Itt csak a szövegre vonatkozó tulajdonságokat állítjuk be. A következő JavaScript‑kóddal alkalmazzuk az árnyékot a szövegre:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Az Aspose.Slides API három árnyéktípust támogat: OuterShadow, InnerShadow és PresetShadow.

A PresetShadow‑nal előre definiált értékekkel alkalmazhat árnyékot a szövegre.

**A Microsoft PowerPoint használatával**

A PowerPoint csak egy árnyéktípust kínál. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Az Aspose.Slides használatával**

Az Aspose.Slides valójában egyszerre két árnyéktípust is alkalmazhat: InnerShadow és PresetShadow.

**Megjegyzések:**

- Ha OuterShadow és PresetShadow együtt van használva, csak az OuterShadow hatás lép életbe.  
- Ha OuterShadow és InnerShadow egyszerre kerül alkalmazásra, a tényleges hatás a PowerPoint‑verziótól függ. Például PowerPoint 2013‑ban a hatás duplázódik, míg PowerPoint 2007‑ben csak az OuterShadow hatás lép életbe.

### **Megjelenítés alkalmazása szövegekre**

A szövegre a következő JavaScript‑mintakóddal adunk megjelenítést:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Ragyogás hatás alkalmazása szövegekre**

A következő kóddal alkalmazzuk a ragyogás hatást, hogy a szöveg kiemelkedjen:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Az művelet eredménye:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

A árnyék, a megjelenítés és a ragyogás paramétereit külön‑külön módosíthatja. A hatások tulajdonságait a szöveg egyes részeire különállóan állítják be. 

{{% /alert %}} 

### **Transzformációk használata WordArt‑ban**

A következő kóddal használjuk a Transform tulajdonságot (amely az egész szövegtömbre vonatkozik):

```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

A Microsoft PowerPoint és az Aspose.Slides for Node.js via Java is rendelkezik számos előre definiált transzformációs típussal.

{{% /alert %}} 

**A PowerPoint használatával**

Az előre definiált transzformációs típusok eléréséhez a következő útvonalat kövesse: **Formátum** → **Szöveghatás** → **Transzformáció**

**Az Aspose.Slides használatával**

A transzformáció típusának kiválasztásához a TextShapeType enumerációt használja. 

### **3D‑hatások alkalmazása szövegekre és alakzatokra**

A következő mintakóddal 3D‑hatást állítunk be egy szöveg‑alakzatra:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Az eredményül kapott szöveg és alakzat:

![todo:image_alt_text](image-20200930114816-9.png)

A szövegre 3D‑hatást alkalmazunk ezzel a JavaScript‑kóddal:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Az művelet eredménye:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A 3D‑hatások szövegekre vagy azok alakzataira való alkalmazása, valamint a hatások kölcsönhatása bizonyos szabályokon alapul.

Tekintsen egy szöveget és az azt tartalmazó alakzatot jelenítő jelenetre. A 3D‑hatás tartalmazza a 3D‑objektum ábrázolását és a jelenetet, amelyre az objektum helyezve van.

- Ha a jelenet mind a alakzatra, mind a szövegre be van állítva, az alakzat jelenete magasabb prioritást kap – a szöveg jelenete figyelmen kívül marad.  
- Ha az alakzatnak nincs saját jelenete, de van 3D‑ábrázolása, a szöveg jelenete lesz használva.  
- Egyébként – ha az alakzat eredetileg nincs 3D‑hatással – akkor az alakzat lapos marad, és a 3D‑hatás csak a szövegre kerül alkalmazásra.  

Ezek a leírások a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusokra vonatkoznak.

{{% /alert %}} 

## **Külső árnyék hatásainak alkalmazása szövegekre**

Az Aspose.Slides for Node.js via Java a [**OuterShadow**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/outershadow/) és a [**InnerShadow**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/innershadow/) osztályokat biztosítja, amelyekkel árnyékhatásokat alkalmazhat a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ben lévő szövegre. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze be a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy Rectangle típusú AutoShape‑t a diára.  
4. Hozza elérhetővé a AutoShape‑hez tartozó TextFrame‑et.  
5. Állítsa be az AutoShape FillType‑ját NoFill‑re.  
6. Hozzon létre egy OuterShadow példányt.  
7. Állítsa be az árnyék BlurRadius‑át.  
8. Állítsa be az árnyék Direction‑ját.  
9. Állítsa be az árnyék Distance‑ét.  
10. Állítsa be a RectanglelAlign‑t TopLeft‑ra.  
11. Állítsa be az árnyék PresetColor‑ját Black‑re.  
12. Írja a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi Java‑minta kód bemutatja, hogyan alkalmazza a külső árnyék hatást szövegre:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Kapja meg a dia referenciáját
    var sld = pres.getSlides().get_Item(0);
    // Adj hozzá egy téglalap típusú AutoShape‑t
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adj TextFrame‑et a téglalaphoz
    ashp.addTextFrame("Aspose TextBox");
    // Tiltsa le az alakzat kitöltését, ha a szöveg árnyékát akarja
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Adj külső árnyékot és állíts be minden szükséges paramétert
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Írja a prezentációt lemezre
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Belső árnyék hatásának alkalmazása alakzatokra**

Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze be a dia referenciáját.  
3. Adjon hozzá egy Rectangle típusú AutoShape‑t.  
4. Engedélyezze az InnerShadowEffect‑et.  
5. Állítsa be az összes szükséges paramétert.  
6. Állítsa be a ColorType‑ot Scheme‑re.  
7. Állítsa be a Scheme Color‑t.  
8. Írja a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlba.

Az alábbi JavaScript‑mintakód (a fenti lépések alapján) megmutatja, hogyan adjon csatlakozót két alakzat közé:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Kapja meg a dia referenciáját
    var slide = pres.getSlides().get_Item(0);
    // Adjunk hozzá egy téglalap típusú AutoShape‑t
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Adjunk TextFrame-et a téglalaphoz
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Engedélyezzük az InnerShadowEffect-et
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Állítsuk be az összes szükséges paramétert
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Állítsuk be a ColorType-ot Scheme-ként
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Állítsuk be a Scheme Color-t
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Mentse el a prezentációt
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Használhatók-e a WordArt‑hatások különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides támogatja az Unicode‑ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt‑hatások, például árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípus elérhetősége és megjelenítése a rendszer betűtípusaitól függ.

**Alkalmazhatók a WordArt‑hatások a dia‑mester elemeire?**

Igen, a WordArt‑hatásokat alkalmazhatja a mesterdiák alakzataira, beleértve a címhelyettesítőket, lábléc‑helyettesítőket vagy háttér‑szöveget is. A mesterelrendezésben végzett módosítások az összes hozzá kapcsolt diára kihatnak.

**A WordArt‑hatások befolyásolják a prezentáció fájlméretét?**

Kissé. Az árnyék, ragyogás és gradient kitöltések kis mértékben növelhetik a fájlméretet az extra formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt‑hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diák megjeleníthetők képként (pl. PNG, JPEG) a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) vagy a [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) osztály `getImage` metódusával. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.