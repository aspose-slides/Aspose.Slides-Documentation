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
description: Alkalmazza és jelenítse meg a 3D hatásokat PowerPoint alakzatokhoz és szöveghez Java-ban az Aspose.Slides segítségével. Konfigurálja a kamerát, a világítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget.
---
## **Áttekintés**

Az Aspose.Slides for Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni PowerPoint‑stílusú 3D formázást alakzatok és szövegek számára. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, levágások, világítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint alakzatok és szövegek 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportálsz, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D Formázási Fogalmak**

Használd az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/).`getThreeDFormat()` metódust 3D formázás alkalmazásához egy alakzatra. A visszaadott formátumobjektum vezérli az adott alakzat 3D jelenetét.

Szöveghez használd az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` metódust. Ez a szövegdobozra alkalmazza a 3D formázást, nem az alakzat testére.

A legfontosabb API tagok:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy a PowerPoint 3D forgatás előre beállított értékének megfeleltetése. |
| [getLightRig](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getLightRig--) | Világítás előbeállítása, irány és fényforgás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, lágyabbá, fényesebbé vagy fémesebbé teszi. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messze nyúlik vissza az alakzat a frontális felületétől. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldalszín összehangolása a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setDepth-double-) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szövegek esetén, különösen a levágás és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelt vagy lekerekített élek az elő‑ és hátlapokon. | Lágyabb vagy formázott él hozzáadása éles, lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getContourWidth--), és [setContourWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontúr a 3D objektum körül. | Kiemeli az objektum határait a renderelt kimenetben. |

## **3D Alakzat Létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑snek tűnik:

- Kamera beállítások, mivel az alapértelmezett frontális nézet elrejtheti az extrúziót.
- Világítási beállítások, mivel a fény megmutatja a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad a frontális felülethez, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG képpé rendereli.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

![Megjelenített kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat Forgatása a Kamerával**

PowerPoint‑ban a 3D forgatás a **3‑D Rotation** panelből állítható. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑val beállított forgatásnak.

![PowerPoint 3‑D Rotation panel X, Y és Z forgatási értékekkel kiemelve](img_02_01.png)

Aspose.Slides‑ben a kamera típusát és forgatását a `shape.getThreeDFormat()` által visszaadott 3D formátummal állíthatod be:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Használd a kamerát, ha meg kell változtatnod, hogyan látja a néző az objektumot. Nem változtatja meg a dia 2D alakzatának geometriáját, csak a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

## **Extrúzió és Mélység Hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azzal, hogy kiterjeszti a frontális felület mögé. PowerPoint‑ban a mélység szabályozó határozza meg ezt a látható vastagságot, a szín szabályozó pedig az oldalfalak színét.

![PowerPoint mélység szabályozók leképezve az extrúzió színre és extrúzió magasság tulajdonságokra](img_02_02.png)

Állítsd be az extrúzió magasságát a vastagsághoz, az extrúzió színét pedig az oldalszínhez:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Használd a mélység beállítást, ha közvetlenül a PowerPoint mélységértékével szeretnél dolgozni, vagy a mélységet kombinálnád a levágással, anyaggal és szöveghatásokkal. Sok alakzatszituációban az extrúzió magassága egyértelműbb, mert közvetlenül kifejezi a látható extrúziót.

## **Színátmenetes vagy Kép Kitöltés 3D Hatásokkal**

A 3D formázás önálló a forma kitöltésétől. Alkalmazhatsz egyszínű, színátmenetes, mintás vagy képes kitöltést a frontális felületre, miközben ugyanazokat a kamera-, világítási-, anyag‑ és extrúzió‑beállításokat használod.

Ez a példa színátmenetes kitöltést alkalmaz a formára, és sötétebb extrúziószínt az oldalakra:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

A renderelt kimenet megtartja a színátmenetet a frontális felületen, az extrúziót pedig külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képes kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá a forma kitöltéséhez:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

A kép a frontális felületen jelenik meg, míg az extrúzió a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrúzióval](img_02_04.png)

## **3D Formázás Alkalmazása Szövegre**

Az alakzat 3D formázása a forma testét érinti. A szöveg 3D formázása a szövegdobozt. Ez WordArt‑szerű hatásokhoz hasznos, ahol a betűknek maguknak is szükségük van extrúzióra, anyagra, világításra és kamera beállításokra.

A következő példa mintás kitöltéssel hoz létre szöveget, WordArt transzformációt alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/)‑nél:

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

A szöveg görbült, extrudált 3D betűként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálási és Renderelési Viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás fix elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D‑ként kerül be a kimenetbe. Ez akkor is érvényes, ha diákot renderelsz [PNG](/slides/hu/java/convert-powerpoint-to-png/), exportálsz [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), exportálsz [HTML](/slides/hu/java/convert-powerpoint-to-html/), vagy kereteket generálsz [video conversion](/slides/hu/java/convert-powerpoint-to-video/).

Fontos tudnivalók:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem tudja elforgatni.
- A végső megjelenés a kamera, a világítás, az anyag, az extrúzió, a kitöltés és a dia skálázás kombinációjától függ.
- Ha meg kell vizsgálnod az örökölt vagy témaalapú formázási értékeket, olvasd el a [effective shape properties](/slides/hu/java/shape-effective-properties/).
- Néhány kimeneti formátum nem képes szerkeszthető PowerPoint 3D formázást tárolni. Ilyen formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként marad meg.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides PowerPoint‑3D hatásokat hoz létre és renderel alakzatokra és szövegre. Nem tesz interaktív 3D jeleneteket exportált képekben, PDF‑ekben vagy HTML‑oldalakon, amelyeket a néző elforgathat. PPTX‑ben a 3D formázás szerkeszthető marad PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség a 3D modell és a 3D hatás között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrúzió, levágás, világítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább kamera forgatás és extrúzió vagy mélység beállítása szükséges. Gyakorlati szempontból ajánlott egy világítási rig és anyag beállítása is, hogy a renderelt felületeknek egyértelmű kiemelések és árnyékok legyenek.

**Alkalmazhatok‑e 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/).`getThreeDFormat()`‑t az alakzat testére, és az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`‑t a szövegre.

**Megjelennek‑e a 3D hatások képek, PDF, HTML vagy videókeretek exportálásakor?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor dia képeket, PDF‑kimenetet, HTML‑kimenetet és videókonvertáláshoz használt kereteket hoz létre. Az exportált kimenet a renderelt megjelenést tartalmazza, nem egy szerkeszthető 3D objektumot.

**Olvashatom‑e a végső 3D értékeket az öröklés és a téma beállítások alkalmazása után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/java/shape-effective-properties/) leír, hogy a végső kamera, világítási rig, levágás és kapcsolódó 3D értékeket olvasd.