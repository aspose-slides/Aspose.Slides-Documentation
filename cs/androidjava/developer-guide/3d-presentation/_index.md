---
title: Vytvořte 3D efekty v prezentacích na Androidu
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

Aspose.Slides pro Android prostřednictvím Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou rotace, extruze, zkosení, osvětlení, materiál, výplně gradientem nebo obrázkem a 3D text.

{{% alert color="info" %}}
Tento článek se týká 3D formátovacích efektů na tvary a text v PowerPointu. Nejde o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Pro použití 3D formátování na tvar použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Metoda vrací objekt [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Tím se 3D formátování použije na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Otočit objekt ve 3D prostoru nebo použít přednastavený 3D rotaci v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavené světlo, směr a rotace světla. | Změnit, jak se na 3D povrchu zobrazují zvýraznění a stíny. |
| [getMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechat stejnou geometrii vypadat plochěji, měkčeji, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko se tvar táhne zpět od přední plochy. | Proměnit plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatečná 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zejména v kombinaci se zkosením a nastavením materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vyvýšené nebo zaoblené hrany na přední a zadní straně. | Přidat měkčí nebo formovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), a [setContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zdůraznit hranici objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři druhy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí pohled zepředu může skrývat extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje objem.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený snímek ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v podokně 3‑D Rotation. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![Panel 3D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides nastavit typ kamery a rotaci pomocí [IThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D pohledový úhel, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá silně tím, že se prodlouží za přední plochu. V PowerPointu ovládací prvek hloubky nastavuje tuto viditelnou tloušťku a ovládací prvek barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) pro tloušťku a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) pro barvu stran:

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

Použijte [IThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) když potřebujete pracovat přímo s hodnotou hloubky PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvaru je `setExtrusionHeight` jasnějším nastavením, protože přímo vyjadřuje viditelnou extruzi.

## **Použití výplní gradientem nebo obrázkem s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete na přední stranu použít jednolitou barvu, gradient, vzor nebo obrázek a stále používat stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad použije gradientní výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachovává gradient na přední straně a vykresluje extruzi odděleně:

![Vykreslený 3D obdélník s výplní gradientu od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití výplně obrázkem přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

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

Obrázek je vykreslen na přední straně, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s foto výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, použije WordArt transformaci a nastaví 3D parametry na [ITextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/):

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovým WordArt transformem, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou strukturou je 3D scéna rasterizována nebo nakreslena do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/androidjava/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), nebo tvorbě snímků pro [video conversion](/slides/cs/androidjava/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete prozkoumat hodnoty zděděného nebo tematického formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

### Může Aspose.Slides vytvořit interaktivní 3D prezentace?

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

### Jaký je rozdíl mezi 3D modelem a 3D efektem?

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

### Jaká nastavení jsou vyžadována pro viditelný 3D tvar?

Minimálně je nutné nastavit rotaci kamery a buď extruzi, nebo hloubku. V praxi je také vhodné nastavit osvětlení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

### Mohu použít 3D efekty jak na tvary, tak na text?

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

### Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?

Ano. Aspose.Slides vykreslí 3D efekty při vytváření obrázků snímků, PDF výstupu, HTML výstupu a snímcích použité pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

### Mohu po aplikaci dědičnosti a nastavení motivu přečíst konečné 3D hodnoty?

Ano. Použijte API pro efektivní formátování popsané v [efektivních vlastnostech tvaru](/slides/cs/androidjava/shape-effective-properties/), abyste získali konečné hodnoty kamery, osvětlení, zkosení a související 3D parametry.