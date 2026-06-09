---
title: Java Kullanarak Sunumlarda 3B Efektler Oluşturun
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PowerPoint şekilleri ve metinleri için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurulmaları ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Java, şekiller ve metinler için PowerPoint benzeri 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, eğim, aydınlatma, malzeme, degrade veya resim dolguları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme hakkında değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/).`getThreeDFormat()` metodunu kullanın. Döndürülen format nesnesi, o şeklin 3B sahnesini kontrol eder.

Metin için, [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` metodunu kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API öğeleri şunlardır:

| API öğesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getCamera--) | Görünüm noktası, önceden tanımlı kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya bir PowerPoint 3B döndürme ön ayarına eşlemek için. |
| [getLightRig](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki parlaklık ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [getMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye doğru ne kadar uzandığını. | Düz bir şekli görünür bir kalın 3B nesneye dönüştürmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılmak veya yan rengi ön doldurmayla eşleştirmek için. |
| [getDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesi tarafından kullanılan ek 3B derinlik. | Şekil ya da metin için derinliği ince ayarlamak, özellikle eğim ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzeylerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourWidth--), ve [setContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki anahat. | Renderlanan çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şeklin inandırıcı bir şekilde 3B görünmesi için genellikle dört tür ayara ihtiyacı vardır:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Aydınlatma ayarları, çünkü ışık, yüzeylerin ve kenarların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey, ışığın nasıl renderlandığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı bir PNG görüntüsü olarak renderlar.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

Renderlanan slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metin bulunan renderlanmış mavi 3B dikdörtgen](img_01_01.png)

## **Kamerayı Kullanarak Şekli Döndürme**

PowerPoint'te 3B döndürme, 3-D Döndürme panelinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme paneli](img_02_01.png)

Aspose.Slides'te, kamera türünü ve döndürmeyi `shape.getThreeDFormat()` tarafından döndürülen 3B format aracılığıyla ayarlayın:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından renderlama sırasında kullanılan 3B görüş noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için ekstrüzyon yüksekliğini ve yan renk için ekstrüzyon rengini ayarlayın:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Derinlik ayarını, PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği eğim, malzeme ve metin efektleriyle birleştirirken kullanın. Birçok şekil senaryosunda, ekstrüzyon yüksekliği daha açık bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek şekle degrade dolgu ve yanlara daha koyu bir ekstrüzyon rengi uygular:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

Renderlanan çıktı, ön yüze uygulanan degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_03.png)

Bunun yerine resim dolgusu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Resim ön yüze renderlanırken, ekstrüzyon 3B yan yüzey olarak renderlanır:

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyacı olduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek desen dolgu ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/)'de 3B ayarları yapılandırır:

```java
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

Kavisli WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu renderlanmış 3B metin:

![Kavisli WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu renderlanmış 3B metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına renderlarken veya dışa aktarırken, 3B sahne rasterleştirilir veya çıktıya 2B sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/java/convert-powerpoint-to-png/) olarak renderladığınızda, [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) olarak dışa aktardığınızda, [HTML](/slides/tr/java/convert-powerpoint-to-html/) olarak dışa aktardığınızda veya [video dönüşümü](/slides/tr/java/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Bu noktaları akılda tutun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Miras alınan veya tema temelli biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özelliklerini](/slides/tr/java/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine renderlanır.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, 3B biçimlendirme PowerPoint'te desteklendiği sürece düzenlenebilir kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt, bir PowerPoint şekline veya metnine uygulanan döndürme, ekstrüzyon, eğim, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

Minimum olarak bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı yapın. Pratikte, renderlanan yüzlerin açık vurgular ve gölgeler elde etmesi için bir ışık rig'i ve malzeme de ayarlamak iyi bir yaklaşımdır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/).`getThreeDFormat()` ve metin için [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` kullanın.

**3B efektler görüntülere, PDF'ye, HTML'ye veya video karelerine dışa aktarırken görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için oluşturulan kareler üretirken 3B efektleri renderlar. Dışa aktarılan çıktı, renderlanmış görünümü içerir; düzenlenebilir bir 3B nesne değil.

**Miras ve tema ayarları uygulandıktan sonra nihai 3B değerleri okuyabilir miyim?**

Evet. Nihai kamera, ışık rig'i, eğim ve ilgili 3B değerleri okumak için [Şekil Etkili Özellikleri](/slides/tr/java/shape-effective-properties/) API'lerini kullanın.