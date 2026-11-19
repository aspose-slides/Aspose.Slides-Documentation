---
title: Vytvořte 3D efekty v prezentacích pomocí Javy
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

Aspose.Slides for Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty jako rotaci, extruzi, zkosení, osvětlení, materiál, přechodové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D efekty formátování na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **3D formátovací koncepty**

Použijte metodu [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) k použití 3D formátování na tvar. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte metodu [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Tím se použije 3D formátování na textový rámec místo těla tvaru.

Nejdůležitějšími členy API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Bod pohledu, přednastavený typ kamery, rotace, zoom a perspektiva. | Otočte objekt ve 3D prostoru nebo použijte přednastavený 3D rotaci v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Přednastavené světlo, směr a rotace světla. | Změňte, jak se odlesky a stíny objevují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Udělejte stejnou geometrii plochější, měkčí, lesklejší nebo kovovější. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko se tvar rozšiřuje dozadu od své přední strany. | Proměňte plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zobrazte hloubku nebo sladťe barvu stran s výplní přední strany. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Další 3D hloubka používaná 3D formátováním v PowerPointu. | Doladťe hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Vyvýšené nebo zaoblené hrany na přední a zadní straně. | Přidejte změkčený nebo tvarovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) a [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) a [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zvýrazněte hranici objektu ve vykresleném výstupu. |

## **Vytvořit 3D tvar**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvakrát ve výchozích rozměrech a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku zobrazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otočit tvar pomocí kamery**

V PowerPointu se 3D rotace nastavuje v podokně 3‑D Rotation. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte přes API kamery.

![Panel 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujte ke kameře pomocí [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfigurace tvaru probíhá v paměti bez uložení souboru:

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

Používejte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při vykreslování.

### **Zkopírovat orientaci kamery ze šablonového tvaru**

Chcete‑li sladit orientaci se šablonovým tvarem, přečtěte jeho přednastavení kamery pomocí [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) a úhly rotace pomocí [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Příklad otevře `template.pptx` a zkopíruje orientaci kamery z prvního tvaru na první snímku na druhý tvar. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` je zeměpisná šířka, index `1` je zeměpisná délka a index `2` je otáčení. Předávejte je funkci [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) v tomto pořadí. Pokud zdroj vrátí `null`, nemá explicitní rotaci, takže nechte úhly druhého tvaru nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

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

Když znovu otevřete `camera-copy.pptx` v PowerPointu, šipka vpravo má stejný přednastavený úhel kamery a rotaci jako obdélník vlevo. Oba tvary používají stejné osvětlení a hloubku extruze.

![Modrý 3D obdélník a pravá šipka s odpovídající orientací kamery, zobrazené shora a zprava](camera-orientation.png)

## **Přidat extruzi a hloubku**

Extruze způsobí, že se tvar jeví jako silný tím, že se prodlouží za přední stranu. V PowerPointu ovládací prvek hloubky nastavuje tuto viditelnou tloušťku a ovládací prvek barvy nastavuje barvu bočních stran.

![Ovládací prvky hloubky v PowerPointu mapované na barvu extruze a výšku extruze](img_02_02.png)

Použijte [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) k nastavení tloušťky a [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) k získání barvy bočních stran. Tento příklad dá obdélníku 100‑bodovou extruzi s fialovými stranami a otočí kameru, aby se ukázala jeho tloušťka. Konfigurace probíhá v paměti bez uložení souboru:

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použít gradientové nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete aplikovat plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále používat stejnou kameru, osvětlení, materiál a nastavení extruze.

Tento příklad použije gradient od modré k oranžové na přední stranu a tmavě oranžovou barvu na 150‑bodovou extruzi. Zastavení gradientu při 0 a 100 značí začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku dvakrát ve výchozích rozměrech:

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

Vykreslený výstup zachovává gradient na přední straně a extruzi vykresluje samostatně:

![Vykreslený 3D obdélník s modro‑oranžovým gradientem výplní a oranžovou extruzí](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem `image.jpg` v pracovním adresáři. Roztažením obrázku vyplní celý obdélník, použije 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Konfigurace probíhá v paměti bez uložení nebo vykreslení souboru:

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

Obrázek je vykreslen na přední straně, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použít 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, použije obloukový výstup směrem nahoru a nastaví 3D parametry přes [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Výška a hloubka extruze jsou v bodech, rotace světla je ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný jen text. Příklad vykreslí PNG obrázek dvakrát ve výchozích rozměrech snímku a uloží prezentaci jako PPTX:

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

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Chcete‑li zachovat čitelnost textu a přitom udržet 3D vzhled tvaru, zavolejte [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) přes [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Je také odlišné od běžné rotace. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu neobnovuje žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a duplikuje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se jen nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG dvakrát ve výchozích rozměrech.

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

![Postranně zarovnané 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Export a chování vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů pevného rozvržení je 3D scéna rasterizována nebo vykreslena do výstupu jako 2D výsledek. To se použije, když vykreslujete snímky do [PNG](/slides/cs/java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/java/convert-powerpoint-to-html/), nebo generujete snímky pro [konverzi videa](/slides/cs/java/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet uživatelem.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat hodnoty děděné nebo tématem definované, přečtěte [efektivní vlastnosti tvaru](/slides/cs/java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek spíše vykreslený než zachovaný jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaké nastavení je vyžadováno pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) pro tělo tvaru a [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [efektivních vlastnostech tvaru](/slides/cs/java/shape-effective-properties/) k načtení konečních hodnot kamery, osvětlení, zkosení a souvisejících 3D parametrů.