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
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text PowerPointu na Androidu pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Android přes Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty jako rotaci, extruzi, zkosení, osvětlení, materiál, přechodové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se týká 3D formátovacích efektů na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides převádí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Pohled, přednastavený typ kamery, rotace, přiblížení a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídá přednastavenému 3D otáčení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavení světla, směr a rotace světla. | Změňte, jak se na 3D povrchu objevují odlesky a stíny. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Udělejte stejnou geometrii plochější, měkčí, lesklejší nebo kovovější. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko se tvar rozšiřuje dozadu od své přední plochy. | Proměňte plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zviditelněte hloubku nebo sladěte barvu stran s výplní přední strany. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Další 3D hloubka používaná v 3D formátování PowerPointu. | Jemně doladěte hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vyvýšené nebo zakulacené hrany na přední a zadní ploše. | Přidejte zjemněný nebo tvarovaný okraj místo ostré ploché stěny. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) a [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) a [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zvýrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a aplikuje 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku ve dvojnásobné výchozí velikosti a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3‑D rotace nastavuje v panelu 3‑D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

V Aspose.Slides přistupujte ke kameře pomocí [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví rotace X, Y a Z na 20, 30 a 40 stupňů. Nastaví tvar v paměti bez uložení souboru:

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

Použijte kameru, když potřebujete změnit, jak objekt vidí divák. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint a Aspose.Slides při vykreslování.

### **Zkopírování orientace kamery z šablonového tvaru**

Pro sladění orientace šablonového tvaru načtěte jeho přednastavení kamery pomocí [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) a úhly rotace pomocí [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Příklad otevře `template.pptx` a zkopíruje orientaci kamery z prvního tvaru na prvním snímku do druhého tvaru. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` je šířka, index `1` je délka a index `2` je otáčení. Předávejte je v tomto pořadí metodě [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-). Pokud zdroj vrátí `null`, nemá explicitní rotaci, takže nechte úhly druhého tvaru nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Když znovu otevřete `camera-copy.pptx` v PowerPointu, šipka vpravo má stejné přednastavení kamery a rotaci jako obdélník vlevo. Oba tvary používají stejné osvětlení a hloubku extruze.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Přidání extruze a hloubky**

Extruze dává tvaru vzhled tlustého tím, že ho prodlouží za přední plochu. V PowerPointu nastavení hloubky určuje tuto viditelnou tloušťku a nastavení barvy určuje barvu bočních ploch.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Použijte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) k nastavení tloušťky a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) k získání barvy stran. Tento příklad přidá obdélníku extruzi 100 bodů s fialovými stranami a otočí kameru, aby ukázala jeho tloušťku. Nastavuje tvar v paměti bez uložení souboru:

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použití přechodové nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete na přední stranu použít plnou barvu, přechod, vzor nebo obrázkovou výplň a přitom použít stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje přechod z modré na oranžovou na přední stranu a tmavě oranžovou barvu na extruzi 150 bodů. Zastavení přechodu na 0 a 100 označují začátek a konec přechodu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku ve dvojnásobné výchozí velikosti:

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

Vykreslený výstup zachová přechod na přední straně a vykreslí extruzi odděleně:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru. Tento příklad vyžaduje existující soubor nazvaný "image.jpg" v pracovním adresáři. Roztáhne obrázek tak, aby vyplnil obdélník, aplikuje extruzi 150 bodů a nastaví rotaci kamery ve stupních. Nastavuje tvar v paměti bez uložení nebo vykreslení souboru:

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

Obrázek je vykreslen na přední straně, zatímco extruze je vykreslena jako 3D boční povrch:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo-bílým mřížkovým vzorem, aplikuje obloukový ohyb směrem vzhůru a nastaví 3D parametry pomocí [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný pouze text. Příklad vykreslí PNG obrázek ve dvojnásobné výchozí velikosti snímku a uloží prezentaci jako PPTX:

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Chcete‑li zachovat čitelnost textu při zachování 3D vzhledu tvaru, zavolejte [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) přes [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se účastní scény a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny pomocí [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Je to také odlišné od běžné rotace. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) řídí vlastní rotaci textu v rámci jeho ohraničujícího rámečku. Udržení textu mimo 3D scénu neresetuje žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zduplikuje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG ve dvojnásobné výchozí velikosti.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkou se 3D scéna rastrová nebo vykreslí do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/androidjava/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/androidjava/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného rig, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem podmíněné hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek renderován místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a renderuje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by si uživatel mohl otáčet. V PPTX zůstává 3D formátování v PowerPointu editovatelné, pokud formát podporuje tuto funkci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný PowerPoint tvar nebo text, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelný rig a materiál, aby vykreslené plochy měly jasné odlesky a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides renderuje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení tématu?**

Ano. Použijte API efektivního formátování popsané v [Efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/) pro načtení konečných hodnot kamery, světelného rig, zkosení a souvisejících 3D hodnot.