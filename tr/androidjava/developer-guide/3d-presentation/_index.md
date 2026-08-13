---
title: Android'de Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides ile Android'de PowerPoint şekilleri ve metni için 3D efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, şekil ve metinler için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale döndürme, ekstrüzyon, eğimler, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı bir 3B model dosyasının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) yöntemini kullanın. Bu yöntem, şekil için 3B sahneyi kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API Üyesi | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Bakış noktası, ön ayarlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki vurgu ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3B nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılmak veya yan rengini ön doldurma ile uyumlu hale getirmek. |
| [getDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekil veya metin için derinliği ince ayar yapmak, özellikle eğim ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), ve [setContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki kontur. | Renderlanan çıktıdaki nesne sınırını vurgulamak. |

## **3B Bir Şekil Oluşturma**

Bir şekil, ikna edici bir 3B görünüme kavuşmadan önce genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlandığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak renderlar.

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

Renderlanan slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metin bulunan mavi 3B dikdörtgen renderı](img_01_01.png)

## **Kamerayı Kullanarak Bir Şekli Döndürme**

PowerPoint'te 3B döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'ta kamera tipi ve döndürmeyi [IThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) aracılığıyla ayarlayın:

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

Kamerayı, nesnenin izleyici tarafından nasıl görüldüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides render ederken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ve yan renk için [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) ayarlayın:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği eğim, malzeme ve metin efektleriyle birleştirmeniz gerektiğinde [IThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) kullanın. Çoğu şekil senaryosunda `setExtrusionHeight` daha net bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek şekle bir degrade doldurma ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

Renderlanan çıktı, ön yüzde degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_03.png)

Resim doldurma kullanmak isterseniz, resmi sunuma ekleyin ve şekil doldurmasına atayın:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

Resim ön yüzde renderlanırken, ekstrüzyon 3B yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek desen doldurmalı bir metin oluşturur, WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/) üzerinde 3B ayarları yapılandırır:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
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

Renderlanan metin, eğimli bir WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonla 3B harfler olarak gösterilir:

![Eğimli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3B metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit‑düzen formatlarına renderlarken veya dışa aktarırken 3B sahne rasterleştirilir veya 2B sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/androidjava/convert-powerpoint-to-png/), [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) olarak renderladığınızda veya [video conversion](/slides/tr/androidjava/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Bu noktaları aklınızda tutun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık seti, malzeme, ekstrüzyon, doldurma ve slayt ölçeklendirmesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/androidjava/shape-effective-properties/) bağlantısını okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine renderlanır.

## **SSS**

### Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?

Aspose.Slides, şekiller ve metinler için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, format destekliyse 3B biçimlendirme PowerPoint'te düzenlenebilir kalır.

### 3B model ile 3B efekt arasındaki fark nedir?

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise döndürme, ekstrüzyon, eğim, aydınlatma ve malzeme gibi düzenli bir PowerPoint şekli veya metnine uygulanan biçimlendirmedir. Bu makale 3B efektleri ele alır.

### Görünür bir 3B şekil oluşturmak için hangi ayarlar gereklidir?

Minimum olarak bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı yapın. Pratikte, renderlanan yüzlerin net vurgular ve gölgeler alması için bir ışık seti ve malzeme de ayarlayın.

### Hem şekillere hem de metne 3B efektler uygulayabilir miyim?

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) kullanın.

### 3B efektler görüntülere, PDF, HTML veya video karelerine dışa aktarıldığında görünür mü?

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne içermez.

### Kalıtım ve tema ayarları uygulandıktan sonra nihai 3B değerlerini okuyabilir miyim?

Evet. Nihai kamera, ışık seti, eğim ve ilgili 3B değerleri okumak için [Shape Effective Properties](/slides/tr/androidjava/shape-effective-properties/) bölümünde açıklanan etkili biçimlendirme API'lerini kullanın.