---
title: Node.js Kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/nodejs-java/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile Node.js'te PowerPoint şekilleri ve metni için 3B efektler uygulayın ve renderleyin. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, şekil ve metin için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale, döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma, malzeme, degrade veya resim dolgu ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getThreeDFormat) yöntemini kullanın. Bu yöntem, o şeklin 3B sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, önceden ayarlanmış kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B boşlukta döndürmek veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık rotasyonu. | 3B yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik ya da metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, yumuşak, parlak ya da metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3B nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilmiş yanların rengi. | Derinliği görünür kılmak veya yan rengini ön dolgu ile eşleştirmek. |
| [getDepth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3B biçimlendirmesi tarafından kullanılan ek 3B derinlik. | Özellikle kenar yumuşatma ve malzeme ayarlarıyla birlikte şekil veya metin için derinliği ince ayarlamak. |
| [getBevelTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş ya da yuvarlatılmış kenarlar. | Keskin düz yüz yerine yumuşak ya da kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3B nesnenin etrafındaki kontur. | Renderlanan çıktıda nesne sınırını vurgulamak. |

## **3B Bir Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayara ihtiyacı vardır:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Aydınlatma ayarları, çünkü ışık yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlanacağını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derece cinsindendir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutunun iki katı büyüklüğünde bir PNG görüntüsüne renderlar ve sunumu PPTX olarak kaydeder.

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

Renderlanan slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metinli mavi 3B dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'da, kameraya [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getCamera) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

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

Kamera, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanılır. Slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides'ın renderleme sırasında kullandığı 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ile kalınlığı, [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) ile yan renkleri ayarlayabilirsiniz. Bu örnek, bir dikdörtgene 100 puanlık ekstrüzyon ve mor yanlar verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setDepth) yöntemi bir 3B şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) yöntemi, bu örnekte gösterildiği gibi, ekstrüzyon etkisinin yüksekliğini kontrol eder.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3B biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen ya da resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu renk uygular. Degrade, 0 ve 100 değerlerinde başlangıç ve bitiş noktalarını belirler. Kamera döndürme değerleri derece cinsindedir. Slayt, varsayılan boyutunun iki katı büyüklüğünde bir PNG görüntüsüne renderlanır:

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

Renderlanan çıktı, ön yüze degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu 3B dikdörtgen](img_02_03.png)

Bunun yerine resim dolgusu kullanmak için, resmi sunuma ekleyip şekil dolgusuna atayın. Bu örnek, çalışma dizininde "image.jpg" adlı mevcut bir dosya gerektirir. Resmi dikdörtgene yayar, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece cinsinden ayarlar. Şekli dosya kaydetmeden veya renderlamadan bellekte yapılandırır:

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

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için yararlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir yay uygular ve 3B ayarları [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık rotasyonu derecedir. Şekil dolgu ve kontur gizlenir, böylece sadece metin görünür. Örnek, varsayılan slayt boyutunun iki katı büyüklüğünde bir PNG görüntüsü renderlar ve sunumu PPTX olarak kaydeder:

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

![Yaylı WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyonlu 3B metin](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

Bir şeklin 3B görünümünü korurken metnin okunabilirliğini sağlamak için, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) üzerinden [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) metodunu çağırın. Değer `true` olduğunda, metin 3B sahnenin dışındadır. `false` olduğunda, metin sahneye katılır ve 3B yönelimine uyar.

Bu ayar, şeklin 3B biçimlendirmesini kaldırmaz: kamera, aydınlatma, malzeme ve ekstrüzyon, [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getThreeDFormat) aracılığıyla yapılandırılmış olmaya devam eder. Ayrıca, sıradan döndürmeden farklıdır. [Shape.setRotation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setRotation) şekli slayt düzleminde döndürürken, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) metnin sınırlayıcı kutusu içinde özel döndürmesini kontrol eder. Metni 3B sahneden dışarıda tutmak, bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve orijinalin yanına bir kopyasını ekler. Her iki şeklin de aynı 3B biçimlendirmesi vardır; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derece cinsindedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutunun iki katı büyüklüğünde PNG olarak renderlar.

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

Solda metin 3B yönelime uyar. Sağda ise düz kalır ve okumak daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3B yönelime sahiptir.

![Yan yana 3B dikdörtgenler: solda metin 3B yönelime uyar, sağda düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarında kaydederken 3B biçimlendirmeyi korur. Sabit sayfa düzeni formatlarına renderlarken veya dışa aktarırken, 3B sahne rasterleştirilir veya çıktıya 2B sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/nodejs-java/convert-powerpoint-to-png/) formatına renderladığınızda, [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) olarak dışa aktardığınızda, [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) olarak dışa aktardığınızda veya [video conversion](/slides/tr/nodejs-java/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/nodejs-java/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak saklanmak yerine renderlanır.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**  
Aspose.Slides, şekil ve metin için PowerPoint 3B efektleri oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını izleyicinin döndürebileceği etkileşimli 3B sahnelere dönüştürmez. PPTX formatında, format destekliyorsa 3B biçimlendirme PowerPoint'te düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**  
3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma ve malzeme gibi normal bir PowerPoint şekline veya metnine uygulanan biçimlendirmedir. Bu makale 3B efektleri kapsar.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**  
En azından bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarlanmalıdır. Pratikte, renderlanan yüzlerin belirgin vurgular ve gölgeler alması için bir ışık rig'i ve malzeme de ayarlanır.

**3B efektleri hem şekillere hem de metne uygulayabilir miyim?**  
Evet. Şekil gövdesi için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getThreeDFormat) ve metin için [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın.

**3B efektler görüntülere, PDF'ye, HTML'ye veya video karelerine dışa aktarırken görünecek mi?**  
Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler oluşturulurken 3B efektleri renderlar. Dışa aktarılan çıktı, renderlanmış görünümü içerir; düzenlenebilir bir 3B nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**  
Evet. Son kamera, ışık rig'i, kenar yumuşatma ve ilgili 3B değerlerini okumak için [Shape Effective Properties](/slides/tr/nodejs-java/shape-effective-properties/) bölümünde anlatılan etkili biçimlendirme API'lerini kullanın.