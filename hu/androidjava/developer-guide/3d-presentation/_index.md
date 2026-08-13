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
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Androidon az Aspose.Slides segítségével. Konfigurálja a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint-szerű 3D formázást alakzatokra és szövegre. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, rézsútok, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" %}}
Ez a cikk a PowerPoint-alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képként, PDF‑ként vagy HTML‑ként exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust 3D formázás alkalmazásához egy alakzatra. A metódus visszaad egy [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) objektumot, amely az adott alakzat 3D jelenetét irányítja.

Szöveghez használja az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust. Ez a 3D formázást a szövegdobozra alkalmazza az alakzat testének helyett.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatási előrebeállítás egyezéséhez. |
| [getLightRig](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Fény előrebeállítás, irány és fényforgás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) és [setMaterial](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriai formát laposabbá, puhábbá, fényesebbé vagy fémesebbé teszi. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Milyen messzire nyúlik visszafelé az alakzat az első oldalától. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakítja. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldalszín összehangolása az első kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getDepth--) és [setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | A PowerPoint 3D formázás által használt további 3D mélység. | A mélység finomhangolása alakzatok vagy szövegek számára, különösen a rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Emelkedett vagy lekerekített élek az elülső és hátsó felületeken. | Lágyabb vagy formázott él hozzáadása egy éles, lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), és [setContourWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Az objektum határának hangsúlyozása a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt hitelesen 3D‑nek tűnik:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Fény beállítások, mivel a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény renderelését.
- Extrúzió vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az előoldalhoz, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG képre rendereli.

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

A renderelt dia kép a téglalapot egy vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D Forgatás panelen konfigurálható. Az X, Y és Z forgatási értékek a kamera API‑n keresztül beállított forgatásnak felelnek meg.

![PowerPoint 3‑D Forgatás panel, amelyen az X, Y és Z forgatási értékek ki vannak emelve](img_02_01.png)

Az Aspose.Slides‑ben állítsa be a kamera típusát és forgatását a [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getCamera--) segítségével:

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

Használja a kamerát, amikor módosítani kell, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot módosítja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azáltal, hogy kiterjeszti azt az előoldal mögé. PowerPointban a mélység szabályzó állítja be ezt a látható vastagságot, a szín szabályzó pedig az oldalfelületek színét.

![PowerPoint mélység szabályzók leképezve az extrúzió színre és extrúzió magasság tulajdonságokra](img_02_02.png)

Állítsa be a [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metódussal a vastagságot, és a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) metódussal az oldal színét:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Használja a [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) metódust, amikor közvetlenül kell a PowerPoint mélységértékével dolgozni vagy a mélységet rézsúttal, anyaggal és szövegeffektusokkal kombinálni. Sok alakzatszituációban a `setExtrusionHeight` egyértelműbb beállítás, mivel közvetlenül a látható extrúziót fejezi ki.

## **Színátmenetes vagy képes kitöltések használata 3D effektusokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, színátmenetes, mintás vagy képes kitöltést az előoldalra, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra, és egy sötétebb extrúzió színt az oldalakon:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

A renderelt kimenet megtartja a színátmenetet az előoldalon és külön rendereli az extrúziót:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Ha helyette képes kitöltést szeretne használni, adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![Renderelt 3D téglalap fotó kitöltéssel az előoldalon és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegdobozt érinti. Ez hasznos a WordArt‑hoz hasonló effektusokhoz, ahol a betűknek maguknak kell extrúzióval, anyaggal, megvilágítással és kamera beállításokkal rendelkezniük.

Az alábbi példa mintás kitöltéssel hoz létre szöveget, WordArt transzformációt alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/) objektumnál:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
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

![Renderelt 3D szöveg íves WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, ha PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor a diákot [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumba rendereli, [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) formátumba exportál, [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) formátumba exportál, vagy a [video conversion](/slides/hu/androidjava/convert-powerpoint-to-video/) kereteit állítja elő.

Tartsa szem előtt a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, fényrig, anyag, extrúzió, kitöltés és diaméret kombinációjától függ.
- Ha meg kell vizsgálnia a örökölt vagy témán alapuló formázási értékeket, olvassa el a [effective shape properties](/slides/hu/androidjava/shape-effective-properties/) oldalát.
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve van, nem pedig szerkeszthető 3D beállításként megőrizve.

## **FAQ**

### Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D effektusokat alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML‑oldalakat olyan interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ahol a formátum támogatja.

### Mi a különbség egy 3D modell és egy 3D effektus között?

A 3D modell egy különálló 3D objektum, amely a prezentációba kerül. A 3D effektus egy formázás, amelyet egy hagyományos PowerPoint alakzatra vagy szövegre alkalmaznak, például forgatás, extrúzió, rézsút, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

### Mely beállítások szükségesek egy látható 3D alakzathoz?

Legalább be kell állítani egy kamera forgatást, valamint vagy extrúziót vagy mélységet. Gyakorlati szempontból érdemes a fény riget és az anyagot is beállítani, hogy a renderelt felületeken egyértelmű kiemelések és árnyékok legyenek.

### Alkalmazhatok‑e 3D effektusokat alakzatokra és szövegre egyaránt?

Igen. Használja az [IShape.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metódust az alakzat testére, és az [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metódust a szövegre.

### Megjelennek‑e a 3D effektusok képek, PDF, HTML vagy videoképkockák exportálásakor?

Igen. Az Aspose.Slides rendereli a 3D effektusokat diaképek, PDF kimenet, HTML kimenet és a videókonvertáláshoz használt képkockák létrehozásakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem pedig szerkeszthető 3D objektumot.

### Ki tudom olvasni a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/androidjava/shape-effective-properties/) leírás tartalmaz, a végső kamera, fény rig, rézsút és kapcsolódó 3D értékek olvasásához.