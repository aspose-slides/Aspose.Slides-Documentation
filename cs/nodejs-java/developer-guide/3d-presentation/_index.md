---
title: Vytvoření 3D efektů v prezentacích pomocí Node.js
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplikujte a renderujte 3D efekty pro tvary a text PowerPointu v Node.js pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Node.js prostřednictvím Java může vytvářet, upravovat, zachovávat a renderovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty, jako je otáčení, extruze, zkosení, osvětlení, materiál, výplně gradientem nebo obrázkem a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **3D formátovací koncepty**

Použijte metodu [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) k aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Bod pohledu, přednastavený typ kamery, rotace, zoom a perspektiva. | Otáčení objektu ve 3D prostoru nebo shoda s přednastaveným 3D otáčením v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Přednastavení světla, směr a rotace světla. | Změna vzhledu zvýraznění a stínů na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobí, že stejná geometrie vypadá plošeji, měkče, leskle nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko tvar vyčnívá dozadu od své přední plochy. | Promění plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s výplní přední plochy. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná PowerPointem při 3D formátování. | Dolaďte hloubku pro tvary nebo text, zejména spolu se nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Vyvýšené nebo zakulacené hrany na přední a zadní ploše. | Přidejte zmírněnou nebo formovanou hranu namísto ostré ploché. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zvýrazněte hranici objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři druhy nastavení, aby vypadal věrohodně 3D:

- Nastavení kamery, protože výchozí pohled zepředu může skryvat extruzi.
- Nastavení světla, protože osvětlení umožňuje rozeznat plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo renderováno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje objem.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku při dvojnásobné výchozí velikosti a uloží prezentaci jako PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v podokně 3‑D rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené přes API kamery.

![Podokno 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujte ke kameře přes [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Tento příklad vytvoří obdélník, vybere ortografický pohled zepředu a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez uložení souboru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Používejte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při renderování.

### **Kopírování orientace kamery z tvaru šablony**

Pro sladění orientace se šablonovým tvarem přečtěte jeho přednastavenou kameru pomocí [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) a úhly rotace pomocí [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Příklad otevře `template.pptx` a zkopíruje orientaci kamery z prvního tvaru na první snímku do druhého tvaru. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` je zeměpisná šířka, index `1` je zeměpisná délka a index `2` je revoluce. Předávejte je metodě [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) v tomto pořadí. Pokud zdroj vrátí `null`, nemá explicitní rotaci, takže ponechte úhly druhého tvaru nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Když znovu otevřete `camera-copy.pptx` v PowerPointu, šipka vpravo má stejnou přednastavenou kameru a rotaci jako obdélník vlevo. Oba tvary používají stejné osvětlení a hloubku extruze.

![Modrý 3D obdélník a šipka vpravo se shodnou orientací kamery, zobrazené shora a zprava](camera-orientation.png)

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu přiřazené k barvě extruze a výšce extruze](img_02_02.png)

Použijte [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) k nastavení tloušťky a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) pro přístup k barvě stran. Tento příklad dá obdélníku extruzi 100 bodů s fialovými stranami a otočí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez uložení souboru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) řídí výšku efektu extruze, jak ukazuje tento příklad.

## **Použití gradientu nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete aplikovat jednolitou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejnou kameru, osvětlení, materiál a nastavení extruze.

Tento příklad aplikuje gradient od modré po oranžovou na přední plochu a tmavě oranžovou barvu na 150‑bodovou extruzi. Gradientové zastavení na 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku při dvojnásobné výchozí velikosti:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje samostatně:

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor pojmenovaný „image.jpg“ v pracovním adresáři. Roztáhne obrázek tak, aby vyplnil obdélník, aplikuje extruzi 150 bodů a nastaví rotaci kamery ve stupních. Konfiguruje tvar v paměti bez uložení nebo vykreslení souboru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Obrázek je vykreslen na přední ploše, zatímco extruze se vykresluje jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikování 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To se hodí pro efekty podobné WordArt, kde jsou písmena samotná potřeba extruze, materiálu, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým vzorem mřížky, aplikuje obloukový nárůst a konfiguruje 3D nastavení přes [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný jen text. Příklad vykreslí PNG obrázek při dvojnásobné výchozí velikosti snímku a uloží prezentaci jako PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovým WordArt transformací, oranžovým vzorem výplně a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Pro zachování čitelnosti textu při zachování 3D vzhledu tvaru zavolejte [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) přes [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Když je hodnota `true`, text zůstane mimo 3D scénu. Když je `false`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nakonfigurovány přes [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Je také odlišné od běžné rotace. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) otáčí tvar v rovině snímku, zatímco [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Zachování textu mimo 3D scénu nepřepíná žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se jen nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG při dvojnásobné výchozí velikosti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Vedle sebe umístěné 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Export a chování při renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkovou strukturou je 3D scéna rasterizována nebo nakreslena do výstupu jako 2D výsledek. Toto platí při renderování snímků do [PNG](/slides/cs/nodejs-java/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), nebo generování snímků pro [video conversion](/slides/cs/nodejs-java/convert-powerpoint-to-video/).

Mějte na paměti:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu rotovat.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete zkontrolovat zděděné nebo motivové hodnoty formátování, přečtěte [effective shape properties](/slides/cs/nodejs-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený, nikoli zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a renderuje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou potřebná pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu použít 3D efekty jak na tvary, tak na text?**

Ano. Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides renderuje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímků použitých pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a motivových nastavení?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/nodejs-java/shape-effective-properties/) pro načtení konečných hodnot kamery, osvětlení, zkosení a souvisejících 3D parametrů.