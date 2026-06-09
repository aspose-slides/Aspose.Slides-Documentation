---
title: Android'da Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides ile Android'de PowerPoint şekilleri ve metni için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, şekil ve metin için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, köşe yuvarlamaları, aydınlatma, malzeme, degrade veya resim doldurmalar ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı ayrı 3B model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) yöntemini kullanın. Bu yöntem, o şeklin 3B sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Bakış noktası, ön ayarlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B alanda döndürmek veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki ışık vurguları ve gölgelerin nasıl göründüğünü değiştirir. |
| [getMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Yüzey malzemesi, örneğin düz, mat, plastik veya metal. | Aynı geometrinin daha düz, daha yumuşak, parlak ya da metalik görünmesini sağlar. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3B nesneye dönüştürür. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür yapar ya da yan renk ile ön doldurmayı koordine eder. |
| [getDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekiller veya metin için, özellikle köşe yuvarlama ve malzeme ayarlarıyla birlikte, derinliği ince ayar yapar. |
| [getBevelTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak ya da şekillendirilmiş bir kenar ekler. |
| [getContourColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), ve [setContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki anahat. | Render edilen çıktıda nesne sınırını vurgular. |

## **3B Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlandığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak renderlar.

```java
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

Render edilen slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metinli mavi render edilmiş 3B dikdörtgen](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te, 3B döndürme 3-D Döndürme panelinden ayarlanır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerleri vurgulanmış PowerPoint 3-D Döndürme paneli](img_02_01.png)

Aspose.Slides'da, kamera tipini ve döndürmeyi [IThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) aracılığıyla ayarlayın:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Kamera, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanılır. Slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından renderlarken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ve yan renk için [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) ayarlayın:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği köşe yuvarlama, malzeme ve metin efektleriyle birleştirirken [IThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) kullanın. Çoğu şekil senaryosunda, `setExtrusionHeight` görünür ekstrüzyonu doğrudan ifade ettiğinden daha net bir ayardır.

## **3B Efektlerle Degrade veya Resim Doldurmayı Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim doldurma uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, şekle degrade bir doldurma ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

![Mavi- turuncu degrade doldurma ve turuncu ekstrüzyonlu render edilmiş 3B dikdörtgen](img_02_03.png)

Bunun yerine resim doldurma kullanmak için, görüntüyü sunuma ekleyin ve şekil doldurmasına atayın:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![Ön yüzünde fotoğraf doldurulmuş ve turuncu ekstrüzyonlu render edilmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, bir desen doldurma ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/) üzerinde 3B ayarları yapılandırır:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![Kavisli WordArt dönüşümü, turuncu desen doldurması ve koyu ekstrüzyonlu render edilmiş 3B metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarında kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına renderlarken veya dışa aktarırken, 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/androidjava/convert-powerpoint-to-png/), [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) olarak renderlarken veya [video conversion](/slides/tr/androidjava/convert-powerpoint-to-video/) için çerçeve üretirken geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktardıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Eğer kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/androidjava/shape-effective-properties/) okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda, görsel sonuç düzenlenebilir 3B ayarlar yerine renderlenir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, 3B biçimlendirme destekleyen yerlerde PowerPoint'te düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, köşe yuvarlama, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gerekir?**

Minimum olarak bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı yapılmalıdır. Pratikte, renderlenen yüzlerin açık vurgular ve gölgeler alması için bir ışık rig'i ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) kullanın.

**3B efektler görüntülere, PDF'ye, HTML'ye veya video çerçevelerine dışa aktarılırken görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretilirken 3B efektleri renderlar. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3B nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık rig'i, köşe yuvarlama ve ilgili 3B değerleri okumak için [Shape Effective Properties](/slides/tr/androidjava/shape-effective-properties/) API'lerini kullanın.