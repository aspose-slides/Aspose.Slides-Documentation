---
title: Node.js Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D dönüş
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js ile Aspose.Slides kullanarak PowerPoint şekilleri ve metni için 3D efektleri uygulayın ve renderleyin. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, şekiller ve metinler için PowerPoint tarzı 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale, dönüş, ekstrüzyon, köşebent, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya yansıtır.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Şekil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` kullanın. Döndürülen [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) nesnesi o şeklin 3B sahnesini kontrol eder.

Metin için, [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, ön ayarlı kamera türü, döndürme, yaklaştırma ve perspektif. | Nesneyi 3B uzayda döndürün veya bir PowerPoint 3B dönüş ön ayarıyla eşleştirin. |
| [getLightRig](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeyde vurguların ve gölgelerin nasıl göründüğünü değiştirin. |
| [getMaterial](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, yumuşak, parlak ya da metalik görünmesini sağlayın. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli görünür şekilde kalın bir 3B nesneye dönüştürün. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılın veya yan renkleri ön doldurmayla koordine edin. |
| [getDepth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3B biçimlendirmede kullanılan ek 3B derinlik. | Şekiller veya metinler için derinliği hassas ayarlayın, özellikle köşebent ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz yüz yerine yumuşak veya biçimlendirilmiş bir kenar ekleyin. |
| [getContourColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3B nesnenin çevresindeki kontur. | Render çıkan çıktıda nesne sınırını vurgulayın. |

## **3B Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Aydınlatma ayarları, çünkü ışık, yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şekil kalınlığa ihtiyaç duyar.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak renderlar.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

![Ön yüzünde beyaz 3B metinli mavi 3B dikdörtgenin renderlanmış görüntüsü](img_01_01.png)

## **Kamerayla Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-B Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te, `shape.getThreeDFormat()` tarafından döndürülen 3B formatı üzerinden kamera türünü ve döndürmeyi ayarlayın:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

İzleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kamerayı kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides render ederken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için ekstrüzyon yüksekliğini ve yan renk için ekstrüzyon rengini ayarlayın:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

PowerPoint'in derinlik değerini doğrudan kullanmanız veya derinliği köşebent, malzeme ve metin efektleriyle birleştirmeniz gerektiğinde derinlik ayarını kullanın. Birçok şekil senaryosunda, ekstrüzyon yüksekliği doğrudan görünür ekstrüzyonu ifade ettiği için daha açık bir ayardır.

## **3B Efektlerle Degrade veya Resim Doldurulması Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek, şekle degrade doldurma ve yanlara daha koyu bir ekstrüzyon rengi uygular:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

Render çıkan sonuç, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi- turuncu degrade doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_03.png)

Bunun yerine resim doldurması kullanmak için, görüntüyü sunuma ekleyin ve şekil doldurmasına atayın:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

Resim ön yüzde renderlanırken, ekstrüzyon 3B yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarları gerektirdiği WordArt benzeri efektlerde yararlıdır.

Aşağıdaki örnek, desen doldurmalı bir metin oluşturur, bir WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` üzerinden 3B ayarları yapılandırır:

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

Kemerli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3B metin:

![Kemerli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3B metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit sayfa düzeni formatlarına render ederken veya dışa aktarırken, 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) olarak renderladığınızda veya [video conversion](/slides/tr/nodejs-java/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Bu noktaları göz önünde bulundurun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık seti, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Eğer kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/nodejs-java/shape-effective-properties/) okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar yerine renderlanır.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3B efektlerini oluşturur ve renderler. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, 3B biçimlendirme, format destekliyse PowerPoint'te düzenlenebilir kalır.

**Bir 3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise bir PowerPoint şekline veya metne uygulanan dönüş, ekstrüzyon, köşebent, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En azından bir kamera dönüşü ve ya ekstrüzyon ya da derinlik ayarı yapmalısınız. Uygulamada ayrıca ışık seti ve malzeme ayarları da eklenir; böylece renderlanan yüzeylerde net vurgular ve gölgeler oluşur.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` ve metin için [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` kullanın.

**Görüntülere, PDF'ye, HTML'ye veya video karelerine dışa aktarırken 3B efektler görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3B değerleri okuyabilir miyim?**

Evet. Nihai kamera, ışık seti, köşebent ve ilgili 3B değerleri okumak için [Shape Effective Properties](/slides/tr/nodejs-java/shape-effective-properties/) içinde açıklanan etkili biçimlendirme API'larını kullanın.