---
title: 3D hatások létrehozása prezentációkban Androidon
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Androidon az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrúziót, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg számára. Ez a cikk a 3D hatásokat tárgyalja, mint például a forgatás, extrúzió, rézsút, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási fogalmak**

Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust 3D formázás alkalmazásához egy alakzatra. A metódus visszaad egy [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) objektumot, amely az adott alakzat 3D jelenetét vezérli.

Szöveg esetén használja az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a szövegkeretre alkalmaz 3D formázást az alakzat testének helyett.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Nézetpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Forgassa el az objektumot 3D térben vagy egyeztesse a PowerPoint 3D forgatás előre beállított értékével. |
| [getLightRig](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Fény előbeállítás, irány és fény forgás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felület anyaga, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, puhábbá, fényesebbé vagy fémivé teszi. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messzire nyúlik vissza az alakzat az első felületétől. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | Megjeleníti a mélységet, vagy az oldalszín összehangolja az első kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Megemelt vagy lekerekített élek az első és hátsó felületeken. | A lágyabb vagy formázott él hozzáadása ahelyett, hogy a szögletes lapos felülettel rendelkezne. |
| [getContourColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), és [setContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges, mielőtt hitelesen 3D-nak tűnik:

- Kamera beállítások, mivel az alapértelmezett előre nézet elrejtheti az extrúziót.
- Fény beállítások, mivel a megvilágítás teszi olvashatóvá az felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az első felületéhez, 3D formázást alkalmaz, PPTX formátumban menti a prezentációt, és a diát PNG képként rendereli.

```java
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

A renderelt dia kép a téglalapot egy vastag 3D blokként mutatja:

![Megjelenített kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D forgatás panelen konfigurálható. Az X, Y és Z forgatási értékek megfelelnek annak a forgatásnak, amelyet a kamera API-val állít be.

![PowerPoint 3‑D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ben a kameratípust és a forgatást a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) segítségével állíthatja be:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Használja a kamerát, amikor meg kell változtatni, hogy a néző hogyan látja az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. Megváltoztatja a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

## **Extrúzió és mélység hozzáadása**

Az extrúzió úgy teszi vastagabbá az alakzatot, hogy az első felület mögé nyúlik. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység beállítások leképezve az extrúzió színre és extrúzió magasság tulajdonságokra](img_02_02.png)

Állítsa be a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) segítségével a vastagságot, és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) segítségével az oldal színét:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Használja a [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) metódust, amikor közvetlenül a PowerPoint mélység értékével kell dolgozni, vagy a mélységet rézsúttal, anyaggal és szöveghatásokkal kombinálni szeretné. Sok alakzatszituációban a `setExtrusionHeight` egyértelműbb beállítás, mivel közvetlenül a látható extrúziót fejezi ki.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy egyszínű, színátmenetes, mintás vagy képes kitöltést az első felületre, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra és sötétebb extrúzió színt az oldalakon:

```java
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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

A renderelt kimenet megtartja a színátmenetet az első felületen, és az extrúziót külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képes kitöltés használatához adja a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

A kép az első felületen jelenik meg, míg az extrúzió a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fényképes kitöltéssel az első felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre hat. Ez hasznos a WordArt‑szerű hatásokhoz, ahol a betűk maguknak szükségük van extrúzióra, anyagra, megvilágításra és kamera beállításokra.

A következő példa mintás kitöltésű szöveget hoz létre, WordArt transzformációt alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/) objektumon:

```java
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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

A szöveg ívelt, extrudált 3D betűként renderelődik:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/), [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) formátumba rendereli, vagy kereteket generál a [video conversion](/slides/hu/androidjava/convert-powerpoint-to-video/) számára.

Tartsa szem előtt a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző az export után nem tudja elforgatni.
- A végső megjelenés a kamera, fényrig, anyag, extrúzió, kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy sablon‑alapú formázási értékeket, olvassa el a [effective shape properties](/slides/hu/androidjava/shape-effective-properties/).
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként megőrzött.

## **FAQ**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásokat alakzatokra és szövegre. Nem teszi interaktívvá az exportált képeket, PDF‑eket vagy HTML oldalakat 3D jelenetekké, amelyeket a néző elforgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló, a prezentációba beszúrt 3D objektum. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrúzió, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállításokra van szükség egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és az extrúziót vagy mélységet kell beállítani. Gyakorlatban a fényriget és az anyagot is be kell állítani, hogy a renderelt felületeknek legyenek könnyen látható kiemelések és árnyékok.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre is?**

Igen. Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust az alakzat testére, és az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek a 3D hatások képek, PDF, HTML vagy videó keretek exportálásakor?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor diaképeket, PDF‑et, HTML‑t és videókonvertálásra használt kereteket állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom a végső 3D értékeket az öröklődés és a sablonbeállítások alkalmazása után?**

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/androidjava/shape-effective-properties/) leírásában talál, a végső kamera, fényrig, rézsút és kapcsolódó 3D értékek kiolvasásához.