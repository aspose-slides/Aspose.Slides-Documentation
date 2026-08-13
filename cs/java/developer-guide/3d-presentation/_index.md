---
title: Vytvořit 3D efekty v prezentacích pomocí Java
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
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Použijte a renderujte 3D efekty pro tvary a text v PowerPointu v Java s Aspose.Slides. Nastavte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Java může vytvářet, upravovat, zachovávat a renderovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty, jako je otáčení, extruze, sklonování, osvětlení, materiál, přechodové nebo obrázkové výplně a 3D text.

{{% alert color="info" %}}
Tento článek se zabývá 3D efekty formátování na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides renderuje tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).`getThreeDFormat()` k aplikaci 3D formátování na tvar. Vrácený objekt formátu řídí 3D scénu pro tento tvar.

Pro text použijte [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Tím se použije 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getCamera--) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídajte přednastavenému 3D otáčení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavené světlo, směr a rotace světla. | Změňte, jak se zvýraznění a stíny objevují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plochěji, měkčeji, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko tvar vystupuje dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Udělejte hloubku viditelnou nebo sladěte barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zejména spolu s nastavením sklonování a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vyvýšené nebo zaoblené hrany na přední a zadní ploše. | Přidejte zmírněnou nebo formovanou hranu místo ostré ploché stěny. |
| [getContourColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourWidth--), a [setContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zdůrazněte hranici objektu v renderovaném výstupu. |

## **Vytvořit 3D tvar**

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.  
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.  
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.  
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otočit tvar pomocí kamery**

V PowerPointu se 3‑D otáčení nastavuje v panelu 3‑D otáčení. Hodnoty otáčení X, Y a Z odpovídají otáčení, které nastavujete pomocí API kamery.

![Panel 3‑D otáčení v PowerPointu se zvýrazněnými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení přes 3D formát vrácený metodou `shape.getThreeDFormat()`:

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

Použijte kameru, když potřebujete změnit, jak si objekt prohlíží divák. Nemění to 2D geometrii tvaru na snímku. Mění to 3D úhel pohledu, který používá PowerPoint a Aspose.Slides při renderování.

## **Přidat extruzi a hloubku**

Extruze způsobí, že tvar vypadá silně tím, že se prodlužuje za přední plochu. V PowerPointu ovládání hloubky nastavuje tuto viditelnou tloušťku a ovládání barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte výšku extruze pro tloušťku a barvu extruze pro barvu stran:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Použijte nastavení hloubky, když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se sklonováním, materiálem a textovými efekty. V mnoha scénářích tvaru je výška extruze přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použít přechodové nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, přechod, vzor nebo obrázkovou výplň na přední plochu a stále použít stejná nastavení kamery, osvětlení, materiálu a extruze.

Tento příklad použije přechodovou výplň na tvar a tmavší barvu extruze na strany:

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

![Vykreslený 3D obdélník s přechodovou výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Vykreslený výstup zachová přechod na přední ploše a extruzi vykreslí zvlášť:

Chcete-li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Použít 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArtu, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text se vzorovou výplní, použije WordArt transformaci a nastaví 3D parametry na [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/):

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

![Vykreslený 3D text s zakřiveným WordArt transformací, oranžovou vzorovou výplní a tmavou extruzí](img_02_05.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou velikostí je 3D scéna rasterizována nebo vložena do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/java/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/java/convert-powerpoint-to-video/).

Mějte na paměti tyto body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet divákem.  
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.  
- Pokud potřebujete zkontrolovat zděděné nebo na motivu založené hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/java/shape-effective-properties/).  
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek renderován místo toho, aby byl uložen jako editovatelné 3D nastavení.

## **FAQ**

### Může Aspose.Slides vytvořit interaktivní 3D prezentace?

Aspose.Slides vytváří a renderuje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF ani HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

### Jaký je rozdíl mezi 3D modelem a 3D efektem?

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, sklonování, osvětlení a materiál. Tento článek se zabývá 3D efekty.

### Jaká nastavení jsou potřebná pro viditelný 3D tvar?

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby měly renderované plochy jasná zvýraznění a stíny.

### Mohu použít 3D efekty na tvary i na text?

Ano. Použijte [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).`getThreeDFormat()` pro tělo tvaru a [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` pro text.

### Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?

Ano. Aspose.Slides renderuje 3D efekty při vytváření obrázků snímků, PDF výstupu, HTML výstupu a snímcích použivaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, ne editovatelný 3D objekt.

### Mohu po dědičnosti a nastavení motivu přečíst konečné 3D hodnoty?

Ano. Použijte API efektivního formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/java/shape-effective-properties/) k načtení konečných hodnot kamery, osvětlení, sklonování a souvisejících 3D parametrů.