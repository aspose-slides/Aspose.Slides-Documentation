---
title: Vytvoření 3D efektů v prezentacích na Androidu
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Použijte a renderujte 3D efekty pro tvary a text PowerPointu na Androidu pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Android via Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty jako otáčení, extruzi, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D efekty formátování na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Když exportujete snímek jako obrázek, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/), která řídí 3D scénu pro tento tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členy API jsou:

| Člen API | Co řídí | Kdy použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Bod pohledu, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otáčíte objekt ve 3D prostoru nebo chcete odpovídat přednastavenému 3D otáčení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavení světla, směr a otáčení světla. | Změna vzhledu zvýraznění a stínů na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobí, že stejná geometrie vypadá plošší, měkčí, lesklejší nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko tvar vyčnívá dozadu od své přední strany. | Přemění plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zviditelní hloubku nebo sladí barvu stran s výplní přední strany. |
| [getDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně dolaďuje hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vytahy nebo zaoblené hrany na přední a zadní straně. | Přidá změkčený nebo formovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) a [getContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) a [setContourWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zdůrazní hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení činí povrchy a strany čitelnými.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a použije 3D formátování. Hodnoty otáčení kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku ve dvou násobcích výchozích rozměrů a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3‑D otáčení nastavuje v panelu 3‑D otáčení. Hodnoty otáčení X, Y a Z odpovídají otáčení nastavenému pomocí API kamery.

![Panel 3‑D otáčení v PowerPointu se zvýrazněnými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides získáte přístup ke kameře pomocí [IThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví otáčení X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez uložení souboru:

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

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední stranu. V PowerPointu řídí ovládání hloubky tuto viditelnou tloušťku a ovládání barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Použijte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) k nastavení tloušťky a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) pro přístup k barvě stran. Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez uložení souboru:

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále použít stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradient od modré po oranžovou na přední stranu a tmavě oranžovou barvu na 150‑bodovou extruzi. Gradientové zastávky při 0 a 100 označují začátek a konec gradientu. Hodnoty otáčení kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku ve dvou násobcích výchozích rozměrů:

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

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej k výplni tvaru. Tento příklad vyžaduje existující soubor nazvaný „image.jpg“ v pracovním adresáři. Roztažením obrázku vyplní obdélník, použije 150‑bodovou extruzi a nastaví otáčení kamery ve stupních. Konfiguruje tvar v paměti bez uložení nebo vykreslení souboru:

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

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje vystupující oblouk a konfiguruje 3D nastavení přes [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Výška extruze a hloubka jsou v bodech a otáčení světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný pouze text. Příklad vykreslí PNG obrázek ve dvou násobcích výchozích rozměrů snímku a uloží prezentaci jako PPTX:

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

![Vykreslený 3D text s obloukem ve stylu WordArt, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Pro zachování čitelnosti textu při zachování 3D vzhledu tvaru zavolejte [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se podílí na scéně a sleduje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: kamera, osvětlení, materiál a extruze zůstávají nastaveny pomocí [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Je to také odlišné od běžného otáčení. [IShape.setRotation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setRotation-float-) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) řídí vlastní otáčení textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu neovlivní žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG ve dvou násobcích výchozích rozměrů.

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

Vlevo text sleduje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky si zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranně umístěné 3D obdélníky: text sleduje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou prezentací je 3D scéna rastrována nebo vykreslena do výstupu jako 2D výsledek. To platí, když vykreslujete snímky do [PNG](/slides/cs/androidjava/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/androidjava/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného rigu, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tematem podmíněné hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte otáčení kamery a buď extruzi nebo hloubku. V praxi také nastavte světelný rig a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty na tvary i text?**

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, ne editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API efektivního formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/), abyste přečetli konečnou kameru, světelný rig, zkosení a související 3D hodnoty.