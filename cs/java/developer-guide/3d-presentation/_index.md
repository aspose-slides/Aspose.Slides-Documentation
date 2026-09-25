---
title: Vytvoření 3D efektů v prezentacích pomocí Javy
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text PowerPointu v Javě s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek zahrnuje 3D efekty, jako jsou rotace, extruze, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty pro tvary a text v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací objekt [IThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getCamera--) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Otáčet objekt ve 3D prostoru nebo použít přednastavený PowerPoint 3D otáčecí preset. |
| [getLightRig](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavení světla, směr a rotace světla. | Změnit, jak se odlesky a stíny zobrazují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Udělat stejnou geometrii plochější, měkčí, lesklejší nebo kovovější. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko se tvar prodlužuje dozadu od své přední plochy. | Přeměnit plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatečná 3D hloubka používaná PowerPoint 3D formátováním. | Jemně doladit hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Zvednuté nebo zaoblené okraje na přední a zadní straně. | Přidat zjemněný nebo formovaný okraj místo ostré ploché plochy. |
| [getContourColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourColor--) a [getContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getContourWidth--) a [setContourWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zvýraznit hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři druhy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrývat extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo renderováno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvakrát ve výchozích rozměrech a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D Rotation. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![Panel PowerPoint 3‑D Rotation se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujete ke kameře přes [IThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getCamera--). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez ukládání souboru:

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

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu používaný PowerPointem a Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá silně, protože se prodlužuje za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu namapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Použijte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) k nastavení tloušťky a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) k přístupu k barvě stran. Tento příklad dá obdélníku extruzi 100 bodů s fialovými stranami a otočí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez ukládání souboru:

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setDepth-double-) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ovládá výšku extruze, jak ukazuje tento příklad.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednolitou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední plochu a tmavě oranžovou barvu na 150‑bodovou extruzi. Zastávky gradientu na 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku dvakrát ve výchozích rozměrech:

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

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje samostatně:

![Vykreslený 3D obdélník s gradientní výplní od modré k oranžové a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad předpokládá existenci souboru „image.jpg“ v pracovním adresáři. Obrázek roztáhne tak, aby vyplnil obdélník, aplikuje extruzi 150 bodů a nastaví rotaci kamery ve stupních. Konfiguruje tvar v paměti bez ukládání nebo vykreslování souboru:

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

Obrázek je vykreslen na přední ploše, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje horní oblouk a nastaví 3D parametry přes [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Výška extruze a hloubka jsou v bodech, rotace světla ve stupních. Výplň tvaru a obrys jsou skryté, takže je viditelný jen text. Příklad vykreslí PNG obrázek dvakrát ve výchozích rozměrech snímku a uloží prezentaci jako PPTX:

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovým WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Aby byl text čitelný při zachování 3D vzhledu tvaru, zavolejte [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) přes [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Když je hodnota `true`, text zůstane mimo 3D scénu. Když je `false`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getThreeDFormat--). Je také odlišné od běžné rotace. [IShape.setRotation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setRotation-float-) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu neresetuje žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zduplikuje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí porovnávací snímek do PNG dvakrát ve výchozích rozměrech.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a lépe čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranně umístěné 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou stránkou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/java/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/java/convert-powerpoint-to-html/) nebo generování snímků pro [konverzi videa](/slides/cs/java/convert-powerpoint-to-video/).

Mějte na paměti:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nemůže být po exportu otáčen uživatelem.
- Konečný vzhled závisí na kombinaci kamery, světelného nastavení, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete zkontrolovat zděděné nebo téma‑závislé hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné PowerPoint 3D formátování. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl uložen jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

** Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný PowerPoint tvar nebo text, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se věnuje 3D efektům.

**Jaké nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelný rig a materiál, aby měly vykreslené plochy jasné odlesky a stíny.

**Mohu použít 3D efekty na tvary i na text?**

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích použité pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu po aplikaci dědictví a tématických nastavení přečíst finální 3D hodnoty?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/java/shape-effective-properties/), abyste získali konečnou kameru, světelný rig, zkosení a související 3D hodnoty.