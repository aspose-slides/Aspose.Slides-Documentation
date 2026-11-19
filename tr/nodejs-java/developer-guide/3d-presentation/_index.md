---
title: Node.js Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D döndürme
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js ile Aspose.Slides kullanarak PowerPoint şekilleri ve metni için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgular ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, şekiller ve metin için PowerPoint tarzı 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale döndürme, ekstrüzyon, köşe yuvarlama, aydınlatma, materyal, degrade veya resim dolgu ve 3D metin gibi 3D etkileri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme etkileriyle ilgilidir. Ayrı 3D model dosyaları ekleme veya düzenleme hakkında değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D etkileri dışa aktarılan 2D çıktıya işler.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) yöntemini kullanın. Bu yöntem, o şeklin 3D sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Bakış noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık döndürmesi. | Parlaklıkların ve gölgelerin 3D yüzeyde nasıl göründüğünü değiştirir. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlar. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli görünür şekilde kalın bir 3D nesneye dönüştürür. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür kılar veya yan rengini ön dolgu ile uyumlu hale getirir. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için derinliği ince ayar yapar, özellikle köşe yuvarlama ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar ekler. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D nesnenin etrafındaki kontur. | İşlenen çıktıda nesne sınırını vurgular. |

## **3D Şekil Oluşturma**

Bir şeklin gerçekçi bir 3D görünüm alabilmesi genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların görülebilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutunun iki katı bir PNG görüntüsüne render eder ve sunumu PPTX olarak kaydeder.

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

Render edilmiş slayt görüntüsü dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metinle mavi 3D dikdörtgenin render edilmiş hali](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te 3D döndürme, 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

In Aspose.Slides, kamera [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) aracılığıyla erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

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

Kamerayı, izleyicinin nesneyi görme şeklini değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından render edildiğinde kullanılan 3D bakış noktasını değiştirir.

### **Şablon Şekilden Kamera Yönelimini Kopyalama**

Şablon şeklin yönelimini eşleştirmek için, kameranın ön ayarını [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) ve döndürme açılarını [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) ile okuyun. Örnek `template.pptx` dosyasını açar ve ilk slayttaki ilk şeklin kamera yönelimini ikinci şekle kopyalar. Her iki şeklin de zaten 3D aydınlatması vardır ve ikinci şeklin açık bir kamera döndürmesi yoktur.

Açıların birimi derecedir. `0` indeksi enlem, `1` indeksi boylam ve `2` indeksi devrimdir. Bunları [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) yöntemine bu sırayla aktarın. Kaynak `null` döndürürse, açık bir döndürmesi yok demektir; bu durumda ikinci şeklin açıları ayarlanmamış bırakılır. `(0, 0, 0)` gibi açık bir döndürme üç sıfır döndürür ve kopyalanmalıdır.

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

PowerPoint'te `camera-copy.pptx` dosyasını yeniden açtığınızda, sağdaki ok sol taraftaki dikdörtgenle aynı kamera ön ayarı ve döndürmeye sahiptir. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğini kullanır.

![Üstten ve sağdan bakıldığında aynı kamera yönelimine sahip mavi bir 3D dikdörtgen ve sağ ok](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın görmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ile kalınlığı, [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) ile yan renkleri ayarlayın. Bu örnek, bir dikdörtgene 100 puanlık ekstrüzyon ve mor yanlar verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) yöntemi bir 3D şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) yöntemi, bu örnekte gösterildiği gibi ekstrüzyon etkisinin yüksekliğini kontrol eder.

## **3D Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3D biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu renk uygular. Degrade durdurma noktaları 0 ve 100, degrade başlangıç ve bitişini gösterir. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutunun iki katı bir PNG görüntüsüne render edilir:

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

Render edilmiş çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak render eder:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_03.png)

Resim dolgu kullanmak için, görüntüyü sunuma ekleyin ve şekil dolgusuna atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olmasını gerektirir. Resmi dikdörtgeni dolduracak şekilde uzatır, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derecelerde ayarlar. Şekli dosya kaydetmeden veya render etmeden bellekte yapılandırır:

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

![Ön yüzde fotoğraf dolgu ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirme şekil gövdesini etkiler. Metin 3D biçimlendirme metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri etkiler için faydalıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir kemer uygular ve 3D ayarlarını [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinliği puan cinsindendir, ışık döndürmesi derecedir. Şekil dolgu ve kontur gizlenir, böylece sadece metin görünür. Örnek, varsayılan slayt boyutunun iki katı bir PNG görüntüsü render eder ve sunumu PPTX olarak kaydeder:

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

![Kemerli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyonlu render edilmiş 3D metin](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Bir şeklin 3D görünümünü korurken metni okunabilir tutmak için, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) üzerinden [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) metodunu çağırın. Değer `true` ise metin 3D sahnenin dışında kalır. `false` ise metin sahneye katılır ve 3D yönelimini takip eder.

Bu ayar, şeklin 3D biçimlendirmesini (kamera, aydınlatma, malzeme ve ekstrüzyon) [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) aracılığıyla yapılandırılmış olmasını kaldırmaz. Ayrıca sıradan döndürmeden farklıdır. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) şekli slayt düzleminde döndürürken, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) metnin sınırlama kutusu içindeki özel döndürmesini kontrol eder. Metni 3D sahneden dışarıda tutmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli bir mavi dikdörtgen oluşturur ve orijinalin yanına bir kopyasını oluşturur. Her iki şekil de aynı 3D biçimlendirmeye sahiptir; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaydını varsayılan boyutunun iki katı bir PNG olarak render eder:

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

Solda, metin 3D yönelimini takip eder. Sağda ise düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3D yönelimini korur.

![Yan yana 3D dikdörtgenler: solda metin 3D yönelimini takip eder, sağda ise düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit düzen formatlarına render ederken veya dışa aktarırken, 3D sahne rasterleştirilir veya 2D bir sonuç olarak çıktı içine çizilir. Bu, slaytları [PNG](/slides/tr/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) olarak dışa aktarırken veya [video dönüştürme](/slides/tr/nodejs-java/convert-powerpoint-to-video/) için çerçeveler üretirken geçerlidir.

Bu noktaları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık sistemi, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/nodejs-java/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini depolayamaz. Bu formatlarda, görsel sonuç render edilir ve düzenlenebilir 3D ayarları olarak korunmaz.

## **FAQ**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metin için PowerPoint 3D etkilerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde, 3D biçimlendirme PowerPoint'te formatın desteklediği sürece düzenlenebilir olarak kalır.

**Bir 3D model ile bir 3D efekt arasındaki fark nedir?**

Bir 3D model, sunuma eklenen ayrı bir 3D nesnedir. Bir 3D efekt, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, köşe yuvarlama, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri kapsar.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

Görünür bir 3D şekil için en az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, render edilen yüzlerin net vurgular ve gölgeler alması için bir ışık sistemi ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3D etkileri uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), metin için [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın.

**3D efektler, görüntüler, PDF, HTML veya video çerçevelerine dışa aktarıldığında görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüştürme için kullanılan çerçeveler üretildiğinde 3D efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3D nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. [Şekil Etkili Özellikleri](/slides/tr/nodejs-java/shape-effective-properties/) sayfasında açıklanan etkili biçimlendirme API'lerini kullanarak nihai kamera, ışık sistemi, köşe yuvarlama ve ilgili 3D değerleri okuyabilirsiniz.