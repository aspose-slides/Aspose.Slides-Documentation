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
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v Node.js s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Node.js prostřednictvím Javy může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou rotace, extruze, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getThreeDFormat) k aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte metodu [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Tím se aplikuje 3D formátování na rámec textu místo těla tvaru.

Nejdůležitějšími členy API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getCamera) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Otáčení objektu ve 3D prostoru nebo shoda s přednastaveným 3D rotací v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getLightRig) | Přednastavení osvětlení, směr a rotace světla. | Změna vzhledu zvýraznění a stínů na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobí, že stejná geometrie vypadá plochěji, měkče, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko se tvar rozprostírá dozadu od své přední plochy. | Promění plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Umožní viditelnost hloubky nebo sladí barvu stran s výplní přední strany. |
| [getDepth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná PowerPoint 3D formátováním. | Jemně doladí hloubku pro tvary nebo text, zejména ve spojení se zkosením a nastavením materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Vyvýšené nebo zaoblené hrany na přední i zadní straně. | Přidá změkčený nebo formovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zdůrazní hranice objektu ve výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři druhy nastavení, aby vypadal přesvědčivě jako 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení činí plochy a strany čitelné.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvakrát většího než výchozí rozměry a uloží prezentaci jako PPTX.

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

Vykreslený snímek ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené pomocí API kamery.

![Panel 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides získáte přístup ke kameře pomocí [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getCamera). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez uložení souboru:

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

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint a Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá silně díky prodloužení za přední plochu. V PowerPointu ovládací prvek hloubky nastavuje tuto viditelnou tloušťku a ovládací prvek barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy a výšky extruze](img_02_02.png)

Použijte [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) k nastavení tloušťky a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) k získání barvy stran. Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru, aby ukázala jeho tloušťku. Konfiguruje tvar v paměti bez uložení souboru:

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

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setDepth) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) řídí výšku extruzního efektu, jak je ukázáno v tomto příkladu.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále použít stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje modro‑oranžový gradient na přední stranu a tmavě oranžovou barvu na 150‑bodovou extruzi. Gradientové zastavení při 0 % a 100 % označuje začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku dvakrát většího než výchozí rozměry:

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

Vykreslený 3D obdélník s modro‑oranžovým gradientem výplně a oranžovou extruzí:

![Vykreslený 3D obdélník s modro-oranžovým gradientem výplně a oranžovou extruzí](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovním adresáři. Roztáhne obrázek tak, aby vyplnil obdélník, aplikuje 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Konfiguruje tvar v paměti bez ukládání nebo vykreslování souboru:

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

Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí:

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

Formátování 3D tvaru ovlivňuje tělo tvaru. Formátování 3D textu ovlivňuje rámec textu. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, použije horní oblouk a nastaví 3D parametry pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný jen text. Příklad vykreslí PNG obrázek dvakrát větší než výchozí rozměry snímku a uloží prezentaci jako PPTX:

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

Vykreslený 3D text s obloukovým WordArt transformací, oranžovou vzorovanou výplní a tmavou extruzí:

![Vykreslený 3D text s obloukem WordArt transformace, oranžovou vzorovanou výplní a tmavou extruzí](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Chcete‑li zachovat čitelnost textu při zachování 3D vzhledu tvaru, zavolejte [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) přes [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se podílí na scéně a sleduje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: kamera, osvětlení, materiál a extruze zůstávají nastaveny pomocí [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getThreeDFormat). Je to také odlišné od běžné rotace. [Shape.setRotation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#setRotation) otáčí tvar v rovině snímku, zatímco [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Uchování textu mimo 3D scénu nevrací žádnou z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; pouze nastavení textu se liší: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG dvakrát většího než výchozí rozměry.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky si zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranně umístěné 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/nodejs-java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/nodejs-java/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete prozkoumat zděděné nebo tématem určené hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/nodejs-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné PowerPoint 3D formátování. V těchto formátech je vizuální výsledek vykreslen místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **FAQ**

**Dokáže Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný PowerPoint tvar nebo text, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se věnuje právě 3D efektům.

**Jaká nastavení jsou požadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi nebo hloubku. V praxi je také vhodné nastavit osvětlení a materiál, aby vykreslené plochy měly jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty na tvary i na text?**

Ano. Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích použitého pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, ne editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/nodejs-java/shape-effective-properties/), abyste získali koneční hodnoty kamery, osvětlení, zkosení a související 3D parametry.