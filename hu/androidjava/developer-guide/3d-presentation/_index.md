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
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Androidon az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg számára. Ez a cikk a 3D hatásokat, például a forgatást, extrudálást, rézsút, megvilágítást, anyagot, színátmenetes vagy képes kitöltéseket, valamint a 3D szöveget mutatja be.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről. Ha egy diát képre, PDF-re vagy HTML-re exportál, az Aspose.Slides a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

A [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust használja 3D formázás alkalmazásához egy alakzatra. A metódus visszaadja az [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/), amely az adott alakzat 3D jelenetét vezérli.

Szöveg esetén használja az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a szövegkeretre alkalmaz 3D formázást, nem pedig az alakzat testére.

A legfontosabb API tagnév a következők:

| API tagnév | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Nézőpont, előre beállított kamera típusa, forgatás, nagyítás és perspektíva. | Forgassa a tárgyat 3D térben vagy egyeztesse a PowerPoint 3D forgatás előre beállított értékével. |
| [getLightRig](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Fény előre beállítás, irány és fényforgatás. | Módosítsa, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felület anyaga, például sík, matt, műanyag vagy fém. | Ugyanazt a geometriai alakzatot laposabbá, puhábbá, fényesebbé vagy fémesebbé teheti. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Mennyire nyúlik visszafelé az alakzat az első felületétől. | Átalakít egy sík alakzatot láthatóan vastag 3D objektummá. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | Megjeleníti a mélységet vagy összhangba hozza az oldal színét az első kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatokra vagy szövegre, különösen rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelt vagy lekerekített szél a front és hátoldalon. | Puhább vagy formázott szél hozzáadása ahelyett, hogy éles, sík felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) és [getContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) és [setContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D-nak tűnik:

- Kamera beállítások, mivel az alapértelmezett front nézet elrejtheti az extrudálást.
- Fény beállítások, mivel a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény megjelenítését.
- Extrudálás vagy mélység beállítások, mivel egy sík alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az első felületéhez, és 3D formázást alkalmaz. A kamera forgatási értékek fokban vannak, az extrudálás magassága 100 pont. A példa a diát PNG képre rendereli a kétszeres alapméretben, és a prezentációt PPTX-ként menti.

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

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

A PowerPointban a 3‑D Forgatás panelen állítható be a 3D forgatás. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slidesban a kamerához a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai front nézetet választ, és X, Y, Z forgatásait rendre 20, 30 és 40 fokra állítja. A alakzatot memóriában konfigurálja fájl mentése nélkül:

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

Használja a kamerát, ha meg kell változtatnia, hogyan látja a néző az objektumot. Ez nem módosítja a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot változtatja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat az első felület mögé nyújtva. A PowerPointban a mélység vezérlő határozza meg ezt a látható vastagságot, a szín vezérlő az oldal felületek színét állítja be.

![PowerPoint mélység beállítások leképezve az extrudálás szín és magasság tulajdonságokra](img_02_02.png)

Használja a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódust a vastagság beállításához, és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) metódust az oldal szín eléréséhez. Ez a példa egy 100 pont extrudálással rendelkező téglalapot ad narancssárga oldalakkal, és a kamera forgatásával mutatja be a vastagságot. A alakzatot memóriában konfigurálja fájl mentése nélkül:

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

Az [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) metódus a 3D alakzat mélységét állítja be. A [setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódus az extrudálás magasságát szabályozza, ahogy ez a példában is látható.

## **Színátmenetes vagy kép kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy egyszínű, színátmenetes, mintás vagy képes kitöltést az első felületre, miközben ugyanazokat a kamera, fény, anyag és extrudálás beállításokat használja.

Ez a példa egy kék‑narancs színátmenetet alkalmaz az első felületre, és egy sötét narancssárga színt a 150 pont extrudáláshoz. A színátmenet megállításai 0‑nál és 100‑nál jelölik a kezdő és befejező pontot. A kamera forgatási értékek fokban vannak. A dia PNG képre renderelődik a kétszeres alapméretben:

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

A renderelt kimenet megtartja a színátmenetet az első felületen, és az extrudálást külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Kép kitöltés használatához adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy „image.jpg” nevű már meglévő fájlt vár a munkakönyvtárban. A képet a téglalap kitöltésére nyújtja, 150 pont extrudálást alkalmaz, és a kamera forgatását fokban állítja be. A alakzatot memóriában konfigurálja mentés vagy renderelés nélkül:

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

A kép az első felületen renderelődik, míg az extrudálás a 3D oldal felületként jelenik meg:

![Renderelt 3D téglalap fotó kitöltéssel az első felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

A forma 3D formázása a forma testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűknek is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

A következő példa egy szöveget hoz létre narancssárga‑fehér rácsmintával, egy felfelé ívelt ívet ad, és a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) segítségével konfigurálja a 3D beállításokat. Az extrudálás magassága és a mélység pontban van megadva, a fény forgatása fokban. A forma kitöltése és körvonala rejtve van, hogy csak a szöveg legyen látható. A példa PNG képet renderel a diák kétszeres alapméretében, és a prezentációt PPTX‑ként menti:

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

A szöveg ívelt, extrudált 3D betűként jelenik meg:

![Renderelt 3D szöveg íves WordArt átalakítással, narancssárga minta kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg sík tartásához hívja a [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metódust a [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) segítségével. Ha az érték `true`, a szöveg a 3D jelenetből kikerül. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D tájolását.

Ez a beállítás nem távolítja el az alakzat 3D formázását: kamera, fény, anyag és extrudálás a [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) segítségével marad beállítva. Emellett eltér a szokásos forgatástól. A [IShape.setRotation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setRotation-float-) a forma síkjában forgat, míg a [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) a szöveg egyéni forgatását szabályozza a saját keretében. A szöveg kizárása a 3D jelenetből nem állítja vissza ezeket a szögeket.

A következő önmagában álló példa egy kék téglalapot hoz létre szöveggel, és egy példányt klónoz mellette. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítás különbözik: a bal oldalon `false`, a jobb oldalon `true`. A kamera szögek fokban vannak, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli a kétszeres alapméretben.

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

A bal oldalon a szöveg követi a 3D tájolást. A jobb oldalon sík marad és könnyebben olvasható. Mindkét téglalap megtartja ugyanazt a látható extrudálást és 3D tájolást.

![Egymás melletti 3D téglalapok: a szöveg a bal oldalon követi a 3D tájolást, a jobb oldalon sík marad](keep_text_flat.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumok, például PPTX mentésekor. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy a kimenetbe 2D eredményként kerül. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/)-re rendereli, [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/)-re exportál, vagy [videó konverzió](/slides/hu/androidjava/convert-powerpoint-to-video/) kereteket generál.

Vedd figyelembe a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem forgathatja az export után.
- A végső megjelenés a kamera, fényrendszer, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy sablon alapú formázási értékeket, olvassa el a [effective shape properties](/slides/hu/androidjava/shape-effective-properties/) dokumentációt.
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatok és szöveg számára. Nem teszi interaktívvá az exportált képeket, PDF‑eket vagy HTML‑oldalakat, amelyeket a felhasználó forgathatna. PPTX‑ben a 3D formázás szerkeszthető marad PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**  
A 3D modell egy különálló 3D objektum, amely a bemutatóba van beszúrva. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrudálás, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Mely beállítások szükségesek egy látható 3D alakzathoz?**  
Minimum egy kamera forgatás és vagy extrudálás vagy mélység kell. Gyakorlati szempontból érdemes egy fényrendszert és anyagot is beállítani, hogy a renderelt felületek világos kiemelésekkel és árnyékokkal rendelkezzenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**  
Igen. Használja a [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust a forma testére és az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek a 3D hatások képek, PDF, HTML vagy videoképkockák exportálásakor?**  
Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor diákat képképpé, PDF‑kimenetté, HTML‑kimenetté vagy videó konverzióhoz szükséges keretekké alakít. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Olvashatom a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**  
Igen. Használja a hatékony formázási API‑kat a [Shape Effective Properties](/slides/hu/androidjava/shape-effective-properties/) leírásában a végső kamera, fényrendszer, rézsút és kapcsolódó 3D értékek olvasásához.