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
- WordArt hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- WordArt átalakítás
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- Android
- Java
- Aspose.Slides
description: "WordArt hatásokat hozhat létre és testreszabhat az Aspose.Slides for Android via Java segítségével. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat Androidon."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik a szöveg stílusozását kitöltésekkel, körvonalakkal, árnyékokkal, tükröződésekkel, ragyogással, átalakításokkal és 3D formázással. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek a hatások PowerPoint‑prezentációkban az Aspose.Slides for Android via Java segítségével, anélkül, hogy a Microsoft Office telepítve lenne.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Az alábbi példák egy egyszerű WordArt stílust építenek fel a szöveg, a betűtípus, a minta kitöltés és a körvonal beállításával.

Minden példa új prezentációt hoz létre, és egy téglalapot ad az első diájához; bemeneti fájlra nincs szükség. Az első példa a szöveget „Aspose.Slides”‑re állítja. A forma pozíciója és méretei pontban vannak megadva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Állítsa a betűtípust Arial Black-ra 36 pont méretben, hogy a formázás jobban látható legyen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Alkalmazzon egy [SmallGrid](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternstyle/#SmallGrid) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy fekete szöveg körvonalat 1 pont szélességgel:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The simple WordArt template](WordArt_template.png)

## **Egyéb WordArt hatások alkalmazása**

Az alábbi példák bemutatják, hogyan alkalmazhatók árnyékok, tükröződések, ragyogás, átalakítások és 3D hatások a szövegre.

### **Külső árnyék hatások alkalmazása**

A külső árnyék mélységet ad azáltal, hogy a szöveg mögé helyez árnyékot. Testreszabhatja a színét, irányát, távolságát, elmosódási sugarát, méretarányát és döntését.

Ez a példa a [enableOuterShadowEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) metódust hívja, és egy fekete árnyékot állít be 4 pont elmosódási sugárral, 240 fokos irányban és 30 pont távolsággal. A 100‑as méretarány megőrzi az árnyék méretét, míg a vízszintes döntés 20 fokkal döntja el. Az alfa transzformáció 32 %-os átlátszatlanságot állít be:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha a külső és a beépített árnyékok együtt vannak használva, csak a külső árnyék lesz alkalmazva.
- Ha a külső és a belső árnyékok egyszerre vannak használva, a kapott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban a hatás duplázódik, míg a PowerPoint 2007‑ben csak a külső árnyék érvényesül.
{{% /alert %}}

### **Tükröződés hatások alkalmazása**

A tükröződés a szöveg tükörképes másolatát hozza létre. Pozíciójának, méretarányának, elmosódásának és átlátszatlanságának beállításával szabályozhatja a megjelenést.

Ez a példa a [enableReflectionEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) metódust hívja, és függőlegesen fordítja meg a tükröződést -100 % méretarányban. 0,5 pont elmosódási sugarat és 4,72 pont távolságot használ. Az átlátszatlanság 60 %-ról 0,9 %-ra csökken a tükröződés 0 % és 60 % közötti pozíciói között:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The Reflection effect](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

A ragyogás egy puha színes körvonalat ad a szöveg köré. Szín, átlátszatlanság és sugár beállításával szabályozhatja a hatást.

Ez a példa a [enableGlowEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) metódust hívja, és egy vörös ragyogást alkalmaz 54 %-os átlátszatlansággal és 7 pont sugarú körvonallal:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The Glow effect](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegrészt.

Állítsa a [setTransform](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) értékét [ArchUpPour](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textshapetype/#ArchUpPour)‑ra, hogy a teljes szövegkeret felfelé íveljen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Android via Java egy előre definiált [átalakítási típusok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textshapetype/) készletet biztosít.
{{% /alert %}}

### **3D hatások alkalmazása alakzatokra és szövegre**

3D hatásokat alkalmazhat egy alakzatra vagy annak szövegére. A letapadás, az extrúzió, a megvilágítás és a kamera beállításai szabják a végeredményt.

Az alábbi példa a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) használatával körkörös letapadásokat, narancssárga extrúziót és sötétvörös kontúrt ad a téglalapnak. A letapadás méretei, az extrúzió magassága, a kontúr szélessége és a mélység pontban van megadva. Egy műanyag anyag, 40 fokkal a Z‑tengely körül elforgatott kiegyensúlyozott megvilágítás és egy perspektív kamera határozza meg a megjelenést:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott alakzat:

![The shape 3D effect](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--) segítségével. A kisebb letapadások formálják a betűk széleit, míg az extrúzió és a megvilágítás mélységet ad a szövegnek:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A 3D hatások alkalmazása szövegre vagy azok alakzataira – valamint ezek kölcsönhatása – meghatározott szabályok szerint működik. Tekintsen meg egy jelenetet, amely mind a szöveget, mind a szöveget tartalmazó alakzatot magában foglalja. Egy 3D hatás magában foglalja az objektum 3D ábrázolását és a benne elhelyezett jelenetet.

- Ha egy jelenet mind a alakzatra, mind a szövegre be van állítva, az alakzat jelenete élvez elsőbbséget, a szöveg jelenete mellőzve lesz.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete kerül felhasználásra.
- Ha az alakzatnak egyáltalán nincs 3D hatása, laposnak tekintik, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a viselkedések a [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/#getLightRig--) és a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/#getCamera--) metódusokra vonatkoznak.
{{% /alert %}}

A szöveg lapos és olvasható tartása, miközben megtartja az alakzat 3D formázását, tekintse meg a [Keep Text Flat on a 3D Shape](/slides/hu/androidjava/3d-presentation/) oldalon, ahol összehasonlítjuk a két beállítást és egy teljes Java példát mutatunk be.

## **GYIK**

**Használhatók a WordArt hatások különböző betűtípusokkal vagy írásrendszerekkel (például arab, kínai)?**

Igen, az Aspose.Slides for Android via Java támogatja az Unicode‑ot és működik minden nagyobb betűtípussal és írásrendszerrel. A WordArt hatások, mint árnyék, kitöltés és körvonal, alkalmazhatók a nyelvtől függetlenül, bár a betűtípus elérhetősége és renderelése a rendszerszintű betűtípusoktól függhet.

**Alkalmazhatók a WordArt hatások a dia‑mester elemeire?**

Igen, a WordArt hatásokat a mesterdiák alakzataira is alkalmazhatja, beleértve a címtartalékot, láblécet vagy háttérszöveget. A mesterelrendezésen végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Kissé. A WordArt hatások, mint árnyékok, ragyogások és színátmenetes kitöltések, enyhén növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét anélkül, hogy elmenteném a prezentációt?**

Igen, a WordArt‑t tartalmazó diák renderelhetők képként (például PNG, JPEG) a [ISlide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage--) vagy az egyes alakzatok a [IShape.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getImage--) segítségével. Így a memóriában vagy a képernyőn is megtekintheti az eredményt a mentés vagy exportálás előtt.