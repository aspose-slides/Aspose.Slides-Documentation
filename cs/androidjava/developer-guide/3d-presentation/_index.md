---
title: Vytvoření 3D efektů v prezentacích na Androidu
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu na Androidu s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Android přes Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty jako rotace, extruzi, zkosení, světlo, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="primary" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejde o vkládání nebo úpravu samostatných 3D modelových souborů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/), která řídí 3D scénu pro tento tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Bod pohledu, přednastavený typ kamery, rotace, zoom a perspektiva. | Otočit objekt ve 3D prostoru nebo odpovídat přednastavení rotace 3D v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavení světla, směr a rotace světla. | Změnit, jak se zvýraznění a stíny zobrazují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Učinit stejnou geometrii plošší, měkčí, lesklejší nebo kovovější. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko se tvar rozšiřuje zpět od své přední plochy. | Přeměnit plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Udělat hloubku viditelnou nebo sladit barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Další 3D hloubka používaná v 3D formátování PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vyvýšené nebo zaoblené hrany na přední a zadní ploše. | Přidat změkčený nebo formovaný okraj místo ostré ploché stěny. |
| [getContourColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), a [setContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zdůraznit hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, aplikuje 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený obrázek snímku zobrazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje z panelu 3-D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![Panel 3-D Rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a rotaci pomocí [IThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu používaný PowerPointem i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze dává tvaru vzhled tloušťky tím, že jej prodlouží za přední plochu. V PowerPointu řídí ovládání hloubky tuto viditelnou tloušťku a ovládání barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu přiřazené k vlastnostem barvy extruze a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) pro tloušťku a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) pro barvu stran:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Použijte [IThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvarů je `setExtrusionHeight` přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientních nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradientní výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje samostatně:

![Vykreslený 3D obdélník s modro-oranžovým gradientem výplně a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

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

Obrázek se vykreslí na přední ploše, zatímco extruze se vykreslí jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, aplikuje WordArt transformaci a nastaví 3D parametry na [ITextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/):

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

Text se vykreslí jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou rozložením se 3D scéna rasterizuje nebo vykreslí do výstupu jako 2D výsledek. To platí, když vykreslujete snímky do [PNG](/slides/cs/androidjava/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), nebo generujete snímky pro [konverzi videa](/slides/cs/androidjava/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tematické hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit upravitelná 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl zachován jako upravitelná 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování v PowerPointu editovatelné, pokud formát podporuje úpravy.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou potřebná pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných při konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci zděděných a tematických nastavení?**

Ano. Použijte API efektivního formátování popsaná v [Efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/), abyste přečetli konečná nastavení kamery, osvětlení, zkosení a související 3D hodnoty.