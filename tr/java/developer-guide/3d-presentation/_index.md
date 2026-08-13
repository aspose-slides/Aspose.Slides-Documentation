---
title: Java Kullanarak Sunumlarda 3B Efektler Oluşturma
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
description: "Aspose.Slides ile Java'da PowerPoint şekilleri ve metni için 3B efektleri uygulayın ve işleyin. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgular ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Java, şekiller ve metinler için PowerPoint tarzı 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, döndürme, ekstrüzyon, köşe yumuşatmaları, aydınlatma, malzeme, degrade veya resim dolguları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya işler.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/).`getThreeDFormat()` yöntemini kullanın. Döndürülen biçim nesnesi o şeklin 3B sahnesini kontrol eder.

Metin için, [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getCamera--) | Görüş noktası, önceden ayarlanmış kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya PowerPoint 3B döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Yüzey malzemesi, örneğin düz, mat, plastik veya metal. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye doğru ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3B nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılmak veya yan rengini ön dolgu ile uyumlu hale getirmek. |
| [getDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmede kullanılan ek 3B derinlik. | Şekil veya metin için derinliği hassas ayarlamak, özellikle köşe yumuşatma ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourWidth--), ve [setContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki kontur. | İşlenmiş çıktıda nesne sınırını vurgulamak. |

## **3B Şekil Oluşturma**

Bir şekil, ikna edici bir 3B görünüm elde etmeden önce genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak işler.

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

İşlenmiş slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metinli, mavi 3B dikdörtgenin işlenmiş görüntüsü](img_01_01.png)

## **Kamerayı Kullanarak Şekli Döndürme**

PowerPoint'te 3B döndürme, 3‑D Rotation panelinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'de, `shape.getThreeDFormat()` tarafından döndürülen 3B biçim aracılığıyla kamera tipini ve döndürmeyi ayarlayın:

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

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez; yalnızca PowerPoint ve Aspose.Slides'in işleme sırasında kullandığı 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şeklin kalın görünmesini sağlayarak ön yüzünün arkasına uzatır. PowerPoint'te derinlik kontrolü bu görünen kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrollerinin ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlendiği görüntü](img_02_02.png)

Kalınlık için ekstrüzyon yüksekliğini ve yan renk için ekstrüzyon rengini ayarlayın:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Derinlik ayarını, PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği köşe yumuşatma, malzeme ve metin efektleriyle birleştirmek istediğinizde kullanın. Çoğu şekil senaryosunda, ekstrüzyon yüksekliği daha net bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3B Efektlerle Degrade veya Resim Dolgularını Kullanma**

3B biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, şekle bir degrade dolgu ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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

İşlenmiş çıktı, ön yüze uygulanmış degrade'i korur ve ekstrüzyonu ayrı olarak işler:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_03.png)

Resim dolgusu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

Resim ön yüzde işlenirken, ekstrüzyon 3B yan yüz olarak işlenir:

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirmesi şekil gövdesini etkiler. Metin 3B biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarları gerektirdiği WordArt benzeri efektler için yararlıdır.

Aşağıdaki örnek, desen dolgu ile metin oluşturur, bir WordArt dönüşümü uygular ve [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` üzerinde 3B ayarları yapılandırır:

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

Metin, kemerli bir WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonla işlenmiş 3B harfler olarak gösterilir:

![Kemer şeklinde WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu işlenmiş 3B metin](img_02_05.png)

## **Dışa Aktarım ve İşleme Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit sayfa düzeni formatlarına render ederken veya dışa aktarırken, 3B sahne rasterleştirilir ve çıktı 2B bir sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/java/convert-powerpoint-to-png/), [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/java/convert-powerpoint-to-html/) olarak işlediğinizde veya [video conversion](/slides/tr/java/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Bu noktaları aklınızda tutun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık sistemi, malzeme, ekstrüzyon, dolgu ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/java/shape-effective-properties/) API'lerini okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine işlenir.

## **FAQ**

### Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve işler. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, 3B biçimlendirme, format destekliyorsa PowerPoint'te düzenlenebilir kalır.

### 3B model ile 3B efekt arasındaki fark nedir?

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt, bir normal PowerPoint şekline veya metne uygulanan döndürme, ekstrüzyon, köşe yumuşatma, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri kapsar.

### Görünür bir 3B şekil için hangi ayarlar gereklidir?

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı yapmanız gerekir. Pratikte, render edilen yüzlerin belirgin vurgular ve gölgeler alması için bir ışık sistemi ve malzeme de ayarlanmalıdır.

### Hem şekillere hem de metne 3B efektler uygulayabilir miyim?

Evet. Şekil gövdesi için [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/).`getThreeDFormat()` ve metin için [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` kullanın.

### 3B efektler, görüntülere, PDF'e, HTML'e veya video karelerine dışa aktarıldığında görünecek mi?

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3B efektleri işler. Dışa aktarılan çıktı, işlenmiş görünüme sahiptir; düzenlenebilir bir 3B nesne içermez.

### Kalıtım ve tema ayarları uygulandıktan sonraki son 3B değerleri okuyabilir miyim?

Evet. Son kamera, ışık sistemi, köşe yumuşatma ve ilgili 3B değerleri okumak için [etkili şekil özellikleri](/slides/tr/java/shape-effective-properties/) API'lerini kullanın.