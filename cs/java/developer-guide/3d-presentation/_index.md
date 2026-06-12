---
title: Vytvoření 3D efektů v prezentacích pomocí Javy
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v Javě pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou otáčení, extruze, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="primary" %}}

Tento článek popisuje 3D formátovací efekty na tvary a text v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.

{{% /alert %}}

## **Koncepty 3D formátování**

Pro použití 3D formátování na tvar použijte [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).`getThreeDFormat()`. Vrácený objekt formátu řídí 3D scénu pro daný tvar.

Pro text použijte [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getCamera--) | Pohled, přednastavený typ kamery, otočení, přiblížení a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídejte přednastavenému 3D otáčení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavené osvětlení, směr a otočení světla. | Změňte, jak se zvýraznění a stíny zobrazují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Udělejte stejnou geometrii plošší, měkčí, lesklejší nebo kovovější. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko tvar vyčnívá dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných bočních ploch. | Zobrazte hloubku nebo sladěte barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatečná 3D hloubka používaná ve formátování PowerPointu. | Doladěte hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vytlačené nebo zaoblené hrany na přední a zadní ploše. | Přidejte zjemněný nebo formovaný okraj místo ostré ploché stěny. |
| [getContourColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourWidth--), a [setContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zvýrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle vyžaduje čtyři druhy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může extruzi skrýt.
- Nastavení osvětlení, protože osvětlení umožňuje rozpoznat plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený obrázek snímku ukazuje obdélník jako tlustý 3D blok:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v podokně 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení nastavenému přes API kamery.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení pomocí 3D formátu vráceného metodou `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Použijte kameru, když potřebujete změnit, jak pozorovatel vidí objekt. Nemění geometrické tvary 2D na snímku. Mění 3D pohledový úhel používaný PowerPointem i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě, protože se prodlouží za přední plochu. V PowerPointu řízení hloubky nastavuje tuto viditelnou tloušťku a řízení barvy nastavuje barvu bočních ploch.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Nastavte výšku extruze pro tloušťku a barvu extruze pro barvu stran:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Použijte nastavení hloubky, když potřebujete pracovat přímo s hodnotou hloubky PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvaru je výška extruze srozumitelnějším nastavením, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednotnou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejná nastavení kamery, osvětlení, materiálu a extruze.

Tento příklad použije gradientní výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje samostatně:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru:

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

Obrázek se vykreslí na přední ploše, zatímco extruze se vykreslí jako 3D boční povrch:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text se vzorovou výplní, použije transformaci WordArt a nakonfiguruje 3D nastavení na [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/):

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

Text se vykreslí jako zakřivené, extrudované 3D písmo:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou rozlohou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/java/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/java/convert-powerpoint-to-html/) nebo generování snímků pro [video conversion](/slides/cs/java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zjistit zděděné nebo tématem podmíněné hodnoty formátování, přečtěte si [effective shape properties](/slides/cs/java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen místo toho, aby byl uložen jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by si uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

** Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, například otáčení, extruzi, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně je potřeba nastavit otáčení kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly jasné zvýraznění a stíny.

**Mohu použít 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).`getThreeDFormat()` pro tělo tvaru a [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení tématu?**

Ano. Použijte API efektivního formátování popsané v [Shape Effective Properties](/slides/cs/java/shape-effective-properties/) k načtení konečných hodnot kamery, osvětlení, zkosení a souvisejících 3D parametrů.