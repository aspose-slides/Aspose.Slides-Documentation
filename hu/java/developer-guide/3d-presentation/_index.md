---
title: 3D hatások létrehozása prezentációkban Java használatával
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Java-ban az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint-szerű 3D formázást alakzatok és szöveg számára. Ez a cikk a 3D hatásokat tárgyalja, mint például a forgatás, extrúzió, rézsútok, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Ha egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási fogalmak**

Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét szabályozza.

Szövegnél használja az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a 3D formázást a szövegkeretre alkalmazza az alakzat teste helyett.

A legfontosabb API tagok a következők:

| API tag | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Forgassa el az objektumot 3D térben, vagy illessze a PowerPoint 3D forgatási előbeállításhoz. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Fény előbeállítás, irány és fényforgatás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felületi anyag, például egyenes, matt, műanyag vagy fém. | A geometria laposabb, puhább, fényesebb vagy fémesebb megjelenése. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messzire nyúlik az alakzat hátrafelé az első oldalától. | Átalakít egy lapos alakzatot láthatóan vastag 3D objektummá. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrúziós oldalak színe. | Láthatóvá teszi a mélységet, vagy összhangba hozza az oldalszínt az első kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelkedett vagy lekerekített élek az első és hátsó felületeken. | Lábnyék vagy formázott él hozzáadása a szúrós, egyenes felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) és [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) és [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzatnak általában négyféle beállításra van szüksége, mielőtt meggyőzően 3D‑nek tűnik:

- Kamera beállítások, mert az alapértelmezett előnézet elrejtheti az extrúziót.
- Világítás beállítások, mert a fény megteszi, hogy a felületek és oldalak láthatóak legyenek.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad hozzá az első oldalához, és alkalmazza a 3D formázást. A kamera forgatási értékei fokban vannak, az extrúzió magassága 100 pont. A példa a diát PNG képre rendereli a alapértelmezett méretének kétszeresére, és a prezentációt PPTX‑ként menti.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

A renderelt diakép a téglalapot vastag 3D blokkként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3‑D forgatást a 3‑D Forgatás panelen állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel X, Y és Z forgatási értékek kiemelésével](img_02_01.png)

Aspose.Slides‑ban a kamerához a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai előnézetet választ, és X, Y, Z forgatásait rendre 20, 30 és 40 fokra állítja. A alakzatot memóriában konfigurálja fájl mentése nélkül:

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

Használja a kamerát, ha meg kell változtatnia, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

### **Kamera orientáció másolása sablon alakzatról**

A sablon alakzat orientációjának egyeztetéséhez olvassa el a kamera előbeállítását a [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) segítségével, és forgatási szögeit a [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) metódussal. A példa megnyitja a `template.pptx` fájlt, és a első dián található első alakzat kamera orientációját a második alakzatra másolja. Mindkét alakzat már rendelkezik 3D világítással, a második alakzatnak pedig nincs kifejezett kamera forgatása.

A szögek fokban vannak. A `0` index a szélesség, az `1` index a hosszúság, a `2` index a fordulat. Ebben a sorrendben adja át őket a [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) metódusnak. Ha a forrás `null`‑t ad vissza, nincs kifejezett forgatás, ezért hagyja a második alakzat szögeit beállítatlanul. A `(0, 0, 0)` kifejezett forgatás három nullát ad vissza, és azt másolni kell.

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

Amikor újra megnyitja a `camera-copy.pptx` fájlt a PowerPointban, a jobb oldali nyíl ugyanazt a kamera előbeállítást és forgatást mutatja, mint a bal oldali téglalap. Mindkét alakzat ugyanazt a világítást és extrúzió mélységet használja.

![Egy kék 3D téglalap és egy jobb nyíl, egyező kamera orientációval, felülről és jobbról nézve](camera-orientation.png)

## **Extrúzió és mélység hozzáadása**

Az extrúzió vastagnak mutatja az alakzatot azzal, hogy a frontális felület mögé nyújtja. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység beállítások az extrúzió szín- és magasság tulajdonságokhoz leképezve](img_02_02.png)

Használja a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódust a vastagság beállításához, és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) metódust az oldal színének lekéréséhez. Ez a példa egy 100 pontos extrúziót ad a téglalaphoz lila oldalakkal, és a kamerát elforgatja, hogy feltárja a vastagságát. Az alakzatot memóriában konfigurálja fájl mentése nélkül:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

Az [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódus szabályozza az extrúzió magasságát, ahogyan ezt a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy homogén színt, színátmenetet, mintát vagy képes kitöltést az első felületre, és továbbra is használhatja ugyanazt a kamera, fény, anyag és extrúzió beállítást.

Ez a példa kék‑narancssárga színátmenetet alkalmaz az első felületre, és egy sötét narancssárga színt a 150 pontos extrúzióra. A színátmenet állomásai 0‑nél és 100‑nál jelzik a színátmenet kezdő‑ és végpontját. A kamera forgatási értékei fokban vannak. A diát PNG képre rendereli a alapértelmezett méretének kétszeresére:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
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

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képes kitöltés használatához adja a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy meglévő, a munkakönyvtárban található „image.jpg” nevű fájlt igényel. A képet nyújtja, hogy kitöltse a téglalapot, 150 pontos extrúziót alkalmaz, és a kamera forgatását fokban állítja be. Az alakzatot memóriában konfigurálja mentés vagy renderelés nélkül:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

![Renderelt 3D téglalap fotó kitöltéssel az első felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre. Ez WordArt‑hoz hasonló hatások esetén hasznos, ahol a betűknek maguknak is szükségük van extrúzióra, anyagra, megvilágításra és kamera beállításokra.

A következő példa narancssárga‑fehér rácsmintával hoz létre szöveget, felfelé ívelt ívet alkalmaz, és a 3D beállításokat a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) segítségével konfigurálja. Az extrúzió magassága és mélysége pontban van megadva, a fény forgatása fokban. Az alakzat kitöltése és körvonala el van rejtve, hogy csak a szöveg látható legyen. A példa PNG képet renderel a diák alapértelmezett méretének kétszeresére, és a prezentációt PPTX‑ként menti:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color patternColor = new Color(255, 140, 0);
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

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvasható maradása és az alakzat 3D megjelenésének megőrzése érdekében hívja meg a [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metódust a [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) segítségével. Ha az érték `true`, a szöveg a 3D jelenetből kizárásra kerül. Ha `false`, a szöveg részt vesz a jelenetben és követi a 3D orientációt.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a világítás, az anyag és az extrúzió továbbra is a [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) segítségével van konfigurálva. Emellett eltér a szokásos forgatástól. Az [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) a alakzatot a dia síkjában forgatja, míg az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) a szöveg egyéni forgatását szabályozza a körülhatároló keretén belül. A szöveg 3D jelenetből való kivétele sem a forgatási szögeket állítja vissza.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és az eredeti mellett másolatot készít. Mindkét alakzat ugyanazzal a 3D formázással rendelkezik; csak a szöveg beállítása különbözik: `false` a bal oldalon és `true` a jobb oldalon. A kamera szögek fokban vannak, az extrúzió magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli a alapértelmezett méretének kétszeresére.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

Bal oldalon a szöveg követi a 3D orientációt. Jobb oldalon sík marad, és könnyebben olvasható. Mindkét téglalap ugyanazt a látható extrúziót és 3D orientációt tartja meg.

![Egymás mellett elhelyezkedő 3D téglalapok: a szöveg bal oldalon a 3D orientációt követi, jobbra sík marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy export rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/java/convert-powerpoint-to-png/)-re rendereli, a [PDF](/slides/hu/java/convert-powerpoint-to-pdf/)-re exportál, a [HTML](/slides/hu/java/convert-powerpoint-to-html/)-re exportál, vagy [video conversion](/slides/hu/java/convert-powerpoint-to-video/) kereteket generál.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, a világítás, az anyag, az extrúzió, a kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy téma‑alapú formázási értékeket, olvassa el az [effective shape properties](/slides/hu/java/shape-effective-properties/) oldalt.
- Egyes kimeneti formátumok nem tárolhatják a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként.

## **FAQ**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatás, valamint extrúzió vagy mélység beállítása szükséges. Gyakorlati szempontból érdemes a világítást és az anyagot is beállítani, hogy a renderelt felületeken egyértelmű kiemelések és árnyékok legyenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre is?**

Igen. Használja a [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) metódust az alakzat testére, és a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek a 3D hatások képek, PDF, HTML vagy videókeretek exportálásakor?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor diákképeket, PDF‑kimenetet, HTML‑kimenetet és a videókonvertáláshoz használt kereteket állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom olvasni a végső 3D értékeket öröklődés és téma beállítások után?**

Igen. Használja a [Shape Effective Properties](/slides/hu/java/shape-effective-properties/) leírt hatékony formázási API‑kat a végső kamera, világítás, rézsút és kapcsolódó 3D értékek olvasásához.