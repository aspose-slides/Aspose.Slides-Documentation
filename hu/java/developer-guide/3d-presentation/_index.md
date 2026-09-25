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

Az Aspose.Slides for Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑stílusú 3D formázást alakzatok és szöveg számára. Ez a cikk olyan 3D‑hatásokat tárgyal, mint a forgatás, extrúzió, peremek, megvilágítás, anyag, színátmenetes vagy képes kitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásaival foglalkozik. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportálsz, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getThreeDFormat--) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét irányítja.

Szövegnél használja az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a szövegkeretre alkalmaz 3D formázást a forma testének helyett.

A legfontosabb API tagok a következők:

| API tag | Mit irányít | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Forgasd el az objektumot 3D térben vagy illeszd egy PowerPoint 3D forgatási előre beállításhoz. |
| [getLightRig](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getLightRig--) | Világítás előre beállított típusa, irány és a fény forgatása. | Módosítja, hogy a kiemelések és árnyékok hogyan jelennek meg a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felület anyaga, például sík, matt, műanyag vagy fém. | Láttassa ugyanazt a geometriai formát laposabbnak, puhábbnak, fényesnek vagy fémesnek. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messzire nyúlik ki az alakzat a frontális felületétől hátrafelé. | Alakíts ki egy lapos alakzatból láthatóan vastag 3D objektumot. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | A mélységet láthatóvá teszi, vagy összehangolja az oldal színét a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setDepth-double-) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen perem‑ és anyagbeállításokkal kombinálva. |
| [getBevelTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelt vagy lekerekített élek az elülső és hátsó felületeken. | Lágyabb vagy formált élt ad hozzá ahelyett, hogy éles, sík felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getContourColor--) és [getContourWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getContourWidth--) és [setContourWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Az alakzat általában négy beállítási típusra van szüksége, mielőtt meggyőzően 3D‑nek tűnne:

- Kamera beállítások, mert az alapértelmezett előre nézet elrejtheti az extrudálást.
- Világítás beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az előlaphoz, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrúzió magassága 100 pont. A példa a diát PNG képre rendereli, ami kétszerese az alapértelmezett méretének, és a prezentációt PPTX‑ként menti.

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

A renderelt diakép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az előfelületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint‑ban a 3D forgatást a 3‑D forgatás panelről állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásoknak.

![PowerPoint 3‑D forgatás panel X, Y, és Z forgatási értékek kiemelve](img_02_01.png)

Aspose.Slides‑ben a kamerához a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getCamera--) segítségével férhetsz hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai előnézetet választ, és beállítja az X, Y és Z forgatásokat 20, 30 és 40 fokra. A példában az alakzatot memóriában konfigurálja fájl mentése nélkül:

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

Használd a kamerát, amikor meg kell változtatni, hogy a néző hogyan lássa az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által rendereléskor használt 3D nézetpontot módosítja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azzal, hogy kiterjeszti a frontális felület mögé. PowerPoint‑ban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység beállítások az extrúzió színre és magasságra vonatkozó tulajdonságokhoz leképezve](img_02_02.png)

Használd a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódust a vastagság beállításához, és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) metódust az oldal színének lekéréséhez. Ez a példa egy 100 pont extrúziót ad a téglalaphoz lila oldalakkal, és forgatja a kamerát, hogy látható legyen a vastagsága. A példában az alakzatot memóriában konfigurálja fájl mentése nélkül:

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

A [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setDepth-double-) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódus szabályozza az extrúzió hatás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egyszínű, színátmenetes, mintás vagy képes kitöltést az előfelületre, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használod.

Ez a példa kék‑narancs színátmenetet alkalmaz az előfelületre, és sötét narancssárga színt a 150 pont magasságú extrúzióra. A színátmenet állomásai 0‑nél és 100‑nál jelzik a színátmenet kezdetét és végét. A kamera forgatási értékek fokban vannak. A dia PNG képre kerül renderelésre, amely kétszerese az alapértelmezett méretnek:

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

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

A képes kitöltés használatához adj hozzá egy képet a prezentációhoz, és rendeld hozzá az alakzat kitöltéséhez. Ez a példa egy "image.jpg" nevű meglévő fájlt igényel a munkakönyvtárban. A képet nyújtja, hogy kitöltse a téglalapot, 150 pont extrúziót alkalmaz, és fokban adja meg a kamera forgatását. A példában az alakzatot memóriában konfigurálja fájl mentése vagy renderelése nélkül:

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

![Renderelt 3D téglalap fotó kitöltéssel az előfelületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat törzsére hat. A szöveg 3D formázása a szövegkeretre. Ez WordArt‑szerű hatásokhoz hasznos, ahol a betűknek maguknak kell extrúzióval, anyaggal, megvilágítással és kamera beállításokkal rendelkezniük.

A következő példa egy narancssárga‑fehér rács mintás szöveget hoz létre, felfelé ívelt átalakítást alkalmaz, és a 3D beállításokat a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) segítségével konfigurálja. Az extrúzió magassága és a mélység pontban van megadva, a fény forgatása fokban. Az alakzat kitöltése és körvonala el van rejtve, így csak a szöveg látható. A példa PNG képet renderel a diák kétszeres alapméretén, és a prezentációt PPTX‑ként menti:

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

## **Szöveg sík maradása 3D alakzaton**

A szöveg olvashatóságának megőrzése és az alakzat 3D megjelenésének megtartása érdekében hívd meg az [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metódust a [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getTextFrameFormat--) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a fény, az anyag és az extrúzió továbbra is a [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getThreeDFormat--) segítségével van konfigurálva. Emellett különbözik a szokásos forgatástól. Az [IShape.setRotation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setRotation-float-) a alakzatot a diaplaneen forgatja, míg az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) a szöveg saját forgatását szabályozza a határoló keretén belül. A szöveg 3D jelenetből való kihagyása nem állítja vissza ezeket a szögeket.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és a jobb oldalra klónozza az eredetit. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: `false` a bal oldalon és `true` a jobb oldalon. A kamera szögek fokban vannak, az extrúzió magassága 40 pont. A példa a prezentációt PPTX‑ként menti, és a összehasonlító diát PNG‑re rendereli, ami kétszerese az alapméretnek.

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

A bal oldalon a szöveg a 3D orientációt követi. A jobb oldalon sík marad, így könnyebben olvasható. Mindkét téglalap ugyanazt a látható extrúziót és 3D orientációt tartja meg.

![Egymás mellett lévő 3D téglalapok: a szöveg a bal oldalon a 3D orientációt követi, a jobb oldalon sík marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba (például PPTX) ment. Renderelés vagy export rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül be a kimenetbe. Ez akkor érvényes, amikor a diákat [PNG](/slides/hu/java/convert-powerpoint-to-png/)-re rendereled, [PDF](/slides/hu/java/convert-powerpoint-to-pdf/)-re exportálod, [HTML](/slides/hu/java/convert-powerpoint-to-html/)-re exportálod, vagy [videókonverzió](/slides/hu/java/convert-powerpoint-to-video/)-kereteket generálsz.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja elforgatni az export után.
- A végső megjelenés a kamera, a fényrig, az anyag, az extrúzió, a kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnod az örökölt vagy téma‑alapú formázási értékeket, olvasd el a [hatékony alakzat tulajdonságok](/slides/hu/java/shape-effective-properties/) oldalát.
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Az ilyen formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatok és szöveg számára. Nem teszi interaktívvá az exportált képeket, PDF‑eket vagy HTML‑oldalakat, amelyekben a néző el tudná forgatni a jelenetet. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

Egy 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. Egy 3D hatás egy normál PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrúzió, perem, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatás és vagy extrúzió vagy mélység beállítása szükséges. Gyakorlati esetben érdemes beállítani a fényriget és az anyagot is, hogy a renderelt felületeknek tiszta kiemelései és árnyékai legyenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getThreeDFormat--) metódust az alakzat törzsére és az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek‑e a 3D hatások exportáláskor képekre, PDF‑re, HTML‑re vagy videó keretekre?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli a diaképek, PDF‑kimenet, HTML‑kimenet és a videókonverzióhoz használt keretek előállítása során. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/java/shape-effective-properties/) leírásban részleteznek, hogy elolvasd a végső kamera, fényrig, perem és kapcsolódó 3D értékeket.