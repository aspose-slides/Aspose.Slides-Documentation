---
title: 3D hatások létrehozása prezentációkban Androidon
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazzon és rendereljen 3D hatásokat PowerPoint alakzatokra és szövegre Androidon az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg esetén. Ez a cikk a 3D hatásokat, például a forgatást, extrudálást, rézsíkokat, megvilágítást, anyagot, színátmenetes vagy képes kitöltéseket, valamint a 3D szöveget tárgyalja.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásaival foglalkozik. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF-re vagy HTML-re exportálsz, az Aspose.Slides ezeket a 3D hatásokat az exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd az [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) objektumot ad vissza, amely a 3D jelenetet szabályozza az adott alakzat számára.

Szöveg esetén használd az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a 3D formázást a szövegkeretre alkalmazza az alakzat testének helyett.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Nézetpont, előre definiált kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy PowerPoint 3D forgatás előre beállított értékének egyezése. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Fény előbeállítás, irány és fényforgatás. | Módosítja, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Az azonos geometria laposabbá, lágyabbá, fényesebbé vagy fémesebbé tétele. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messzire nyúlik ki az alakzat a frontális felületétől hátrafelé. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldal színének összehangolása a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Az alakzatok vagy szöveg mélységének finomhangolása, különösen a rézsík- és anyagbeállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelt vagy lekerekített szélek az első és hátsó felületeken. | Lágyabb vagy formázott él hozzáadása ahelyett, hogy éles, lapos felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) és [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) és [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Az objektum határának kiemelése a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D-nek tűnik:

- Kamera beállítások, mivel az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Világítás beállítások, mivel a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad a frontális felülethez, és alkalmazza a 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrudálási magasság 100 pont. A példa a diát egy PNG képre rendereli, amely kétszerese az alapértelmezett méretének, és a prezentációt PPTX formátumban menti.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A renderelt diakép a téglalapot egy vastag 3D blokként mutatja:
![Renderelt kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3-D forgatás panelről állítható be. Az X, Y és Z forgatási értékek megfelelnek annak a forgatásnak, amelyet a kamera API-n keresztül állítasz be.

![PowerPoint 3-D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides-ban a kamerához a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) segítségével férhetsz hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai frontális nézetet választ, és az X, Y, Z forgatásait 20, 30 és 40 fokra állítja. A formát memóriában konfigurálja fájl mentése nélkül:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Használd a kamerát, amikor meg kell változtatni, hogyan látja a néző az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. Megváltoztatja a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

### **Kamera tájolás másolása sablon alakzatról**

A sablon alakzat tájolásának egyezéséhez olvasd ki a kamera előbeállítását a [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) segítségével és a forgatási szögeket a [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) metódussal. A példa megnyitja a `template.pptx`-t, és átmásolja a kamera tájolását az első dián lévő első alakzatról a második alakzatra. Mindkét alakzat már rendelkezik 3D megvilágítással, a második alakzatnak pedig nincs explicit kamera forgatása.

A szögek fokban vannak megadva. Az `0` index a szélességet, az `1` index a hosszúságot, a `2` index a fordulatot jelöli. Ezeket ebben a sorrendben add át a [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) metódusnak. Ha a forrás `null`-t ad, nincs explicit forgatás, ezért hagyd a második alakzat szögeit beállítatlanul. Egy explicit `(0, 0, 0)` forgatás három nullát ad vissza, és másolandó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Amikor újra megnyitod a `camera-copy.pptx`-t PowerPointban, a jobb oldali nyíl ugyanazzal a kamera előbeállítással és forgatással rendelkezik, mint a bal oldali téglalap. Mindkét alakzat ugyanazt a megvilágítást és extrudálási mélységet használja.

![Kék 3D téglalap és jobb nyíl a megfelelő kamera tájolással, felülről és jobbról nézve](camera-orientation.png)

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azzal, hogy hátra nyújtja a frontális felület mögött. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldal felületek színét.

![PowerPoint mélység vezérlők leképezve az extrudálás szín és magasság tulajdonságaira](img_02_02.png)

Használd a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódust a vastagság beállításához és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) metódust az oldal színének eléréséhez. Ez a példa egy 100 pontos extrudálást ad egy téglalapnak lila oldalakkal, és forgatja a kamerát, hogy látható legyen a vastagsága. A formát memóriában konfigurálja fájl mentése nélkül:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Az [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódus szabályozza az extrudálási effektus magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egyszínű, színátmenetes, mintás vagy képes kitöltést a frontális felületre, miközben ugyanazokat a kamera, fény, anyag és extrudálási beállításokat használod.

Ez a példa egy kék‑narancs színátmenetet alkalmaz a frontális felületre és sötét narancssárga színt a 150 pontos extrudálásra. A színátmenet 0‑nál és 100‑nál áll meg, jelezve a kezdetet és a végét. A kamera forgatási értékek fokban vannak. A diát egy PNG képre rendereli, amely kétszerese az alapértelmezett méretnek:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá az alakzat kitöltéséhez. Ez a példa egy meglévő, `image.jpg` nevű fájlt feltételez a munkakönyvtárban. A képet nyújtja a téglalap kitöltéséhez, 150 pontos extrudálást alkalmaz, és a kamera forgatást fokban állítja. A formát memóriában konfigurálja mentés vagy renderelés nélkül:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Renderelt 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét befolyásolja. A szöveg 3D formázása a szövegkeretet érinti. Ez hasznos a WordArt‑szerű hatásoknál, ahol maguknak a betűknek is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

A következő példa egy narancssárga‑fehér rácsmintával ellátott szöveget hoz létre, felülre ívelt ívet alkalmaz, és 3D beállításokat konfigurál a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) segítségével. Az extrudálási magasság és mélység pontban van megadva, a fény forgatás fokban. Az alakzat kitöltése és körvonala rejtve van, hogy csak a szöveg látható legyen. A példa egy PNG képet renderel kétszeres alapdiamérettben, és a prezentációt PPTX‑ként menti:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int patternColor = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megőrzése és az alakzat 3D megjelenésének megtartása érdekében hívd meg a [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metódust a [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben, és követi annak 3D tájolását.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, megvilágítás, anyag és extrudálás továbbra is a [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) segítségével van beállítva. Ez különbözik a szokásos forgatástól. Az [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) a formát a diaplánban forgatja, míg a [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) a szöveg egyéni forgatását szabályozza a határoló dobozán belül. A szöveg 3D jelenetből való kizárása nem állítja vissza ezeket a szögeket.

A következő önálló példa egy kék téglalapot hoz szöveggel, és duplikálja az eredeti mellett. Mindkét alakzat ugyanazzal a 3D formázással rendelkezik; csak a szöveg beállítás különbözik: baloldalon `false`, jobboldalon `true`. A kamera szögek fokban vannak, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a comparatív diát PNG‑re rendereli kétszeres alapdiamérettel.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

![Egymás mellett lévő 3D téglalapok: a szöveg követi a 3D tájolást baloldalon, míg jobboldalon sík marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PPTX‑hez hasonló PowerPoint formátumok mentésekor. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor érvényes, amikor a diákat [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumba rendereljük, [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) formátumba exportáljuk, [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) formátumba exportáljuk, vagy kereteket generálunk a [videó konvertáláshoz](/slides/hu/androidjava/convert-powerpoint-to-video/).

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, a fényrendszer, az anyag, az extrudálás, a kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnod az örökölt vagy sablon alapú formázási értékeket, olvasd el a [hatékony alakzattulajdonságok](/slides/hu/androidjava/shape-effective-properties/).
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként megőrizve.

## **FAQ**

**Készíthet-e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatokhoz és szöveghez. Nem tesz interaktív 3D jelenetekké az exportált képeket, PDF‑eket vagy HTML‑oldalakat, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló, a prezentációba beszúrt 3D objektum. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrudálás, rézsík, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább be kell állítani egy kamera forgást, valamint vagy az extrudálást, vagy a mélységet. Gyakorlati használat során érdemes beállítani a fényrendszert és az anyagot is, hogy a renderelt felületek tiszta fénycsíkokkal és árnyékokkal rendelkezzenek.

**Alkalmazhatok-e 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd az [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust az alakzat testére, és az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek‑e a 3D hatások képek, PDF, HTML vagy videokeret exportálásakor?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat a dia képek, PDF, HTML kimenet és a videó konvertáláshoz használt keretek előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom‑e olvasni a végső 3D értékeket az öröklődés és a sablon beállítások alkalmazása után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket a [Alakzat hatékony tulajdonságai](/slides/hu/androidjava/shape-effective-properties/) leírásában találsz, a végső kamera, fényrendszer, rézsík és kapcsolódó 3D értékek olvasásához.