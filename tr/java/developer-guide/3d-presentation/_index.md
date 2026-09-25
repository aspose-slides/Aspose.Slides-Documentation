---
title: Java Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java’da PowerPoint şekilleri ve metinleri için 3D efektler uygulayın ve renderlayın. Kamera, ışıklandırma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Java, şekil ve metinler için PowerPoint‑stili 3D biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, döndürme, ekstrüzyon, köşe yuvarlama, aydınlatma, malzeme, degrade veya resim dolgu ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Not" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3D biçimlendirme efektleri hakkında; bağımsız 3D model dosyalarını ekleme veya düzenleme hakkında değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektleri dışa aktarılan 2D çıktıya işler.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getThreeDFormat--) metodunu kullanın. Bu metod, o şekil için 3D sahneyi kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) metodunu kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getCamera--) | Görüş noktası, önceden tanımlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya PowerPoint 3D döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeyde vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometriyi daha düz, yumuşak, parlak veya metalik göstermek. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli görünür kalın bir 3D nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılmak veya yan rengi ön dolgu ile uyumlu hale getirmek. |
| [getDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için, özellikle köşe yuvarlama ve malzeme ayarlarıyla birlikte, derinliği hassas ayarlamak. |
| [getBevelTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşatılmış veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourColor--) ve [getContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getContourWidth--) ve [setContourWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D nesnenin etrafındaki kontur. | Oluşturulan çıktıda nesne sınırını vurgulamak. |

## **3D Bir Şekil Oluşturma**

Bir şeklin inandırıcı bir 3D görünüm elde edebilmesi için genellikle dört tür ayar gereklidir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve yanları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işleneceğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek, bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D biçimlendirme uygular. Kamera döndürme değerleri derece cinsindendir, ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı iki katı varsayılan boyutta bir PNG görüntüsüne render eder ve sunumu PPTX olarak kaydeder.

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

Render edilmiş slayt görüntüsü, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzde beyaz 3D metinle render edilmiş mavi 3D dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint’te 3D döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑D Rotation bölmesi](img_02_01.png)

Aspose.Slides’te kameraya, [IThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getCamera--) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik bir ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli bir dosyaya kaydetmeden bellekte yapılandırır:

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

Kamera, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanılır. Bu, slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides tarafından render edilirken kullanılan 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şeklin ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlığı ayarlamak için [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ve yan renk erişimi için [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) kullanılabilir. Bu örnek, dikdörtgene 100 puanlık bir ekstrüzyon, mor yanlar verir ve kalınlığını göstermek için kamerayı döndürür. Şekli bir dosyaya kaydetmeden bellekte yapılandırır:

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setDepth-double-) metodu, bir 3D şeklin derinliğini belirler. [setExtrusionHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metodu ise ekstrüzyon etkisinin yüksekliğini kontrol eder; örnekde gösterildiği gibi.

## **3D Efektlerle Degrade veya Resim Dolgusu Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim dolgu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını tutabilirsiniz.

Bu örnek, ön yüzde mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyon için koyu turuncu renk uygular. Degrade durakları 0 ve 100, başlangıç ve bitiş noktalarını işaret eder. Kamera döndürme değerleri derece cinsindendir. Slayt, iki katı varsayılan boyutta bir PNG’ye render edilir:

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

Render edilen çıktı, ön yüzdeki degradeyi korur ve ekstrüzyonu ayrı olarak işler:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_03.png)

Resim dolgu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olduğunu varsayar. Resmi dikdörtgene yayar, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece olarak ayarlar. Şekli bir dosya kaydetmeden veya render etmeden bellekte yapılandırır:

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

Resim ön yüzde render edilirken, ekstrüzyon 3D yan yüz olarak işlenir:

![Ön yüzde fotoğraf dolgu ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi, şekil gövdesini etkiler. Metin 3D biçimlendirmesi, metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarları gerektirdiği WordArt‑benzeri efektler için yararlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir yay oluşturur ve 3D ayarları [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) üzerinden yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık döndürmesi derece cinsindendir. Şekil dolgu ve kontur gizlenir, sadece metin görünür. Örnek, iki katı varsayılan slayt boyutunda bir PNG görüntüsü render eder ve sunumu PPTX olarak kaydeder:

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

Metin, eğimli, ekstrüde edilmiş 3D harfler olarak render edilir:

![Eğimli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyonlu render edilmiş 3D metin](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Metnin, şeklin 3D görünümünü korurken okunabilir kalmasını sağlamak için, [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getTextFrameFormat--) üzerinden [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metodunu çağırın. Değer `true` olduğunda, metin 3D sahneden çıkar. Değer `false` olduğunda, metin sahneye katılır ve 3D yönelimini takip eder.

Bu ayar, şeklin 3D biçimlendirmesini ([IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getThreeDFormat--)) kaldırmaz; kamera, ışık, malzeme ve ekstrüzyon ayarları aynı kalır. Ayrıca sıradan döndürmeden farklıdır. [IShape.setRotation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setRotation-float-) şekli slayt düzleminde döndürürken, [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metnin kendi sınırlayıcı kutusu içinde özel döndürmesini kontrol eder. Metni sahneden çıkarmak, bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, mavi bir dikdörtgen ve metin oluşturur, ardından orijinalin yanına bir kopyasını yerleştirir. Her iki şeklin de aynı 3D biçimlendirmesi vardır; yalnızca metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derece cinsindedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki katı varsayılan boyutta PNG’ye render eder.

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

Solda metin 3D yönelime göre hareket eder. Sağda ise düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünen ekstrüzyon ve 3D yönelime sahiptir.

![Yan yana 3D dikdörtgenler: solda metin 3D yönelime göre, sağda düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit‑sayfa formatlarına render ederken veya dışa aktarırken, 3D sahne rasterleştirilir veya 2D sonuç olarak çıktı içine çizilir. Bu, slaytları [PNG](/slides/tr/java/convert-powerpoint-to-png/), [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/java/convert-powerpoint-to-html/) olarak render ederken veya [video dönüştürme](/slides/tr/java/convert-powerpoint-to-video/) için kareler üretirken geçerlidir.

Şunları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne, dışa aktarımdan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig’i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Kalıtılmış veya tema‑tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özelliklerini](/slides/tr/java/shape-effective-properties/) okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları yerine render edilmiş olarak sunulur.

## **SSS**

**Aspose.Slides interaktif 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metinler için PowerPoint 3D efektlerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfaları, izleyicinin döndürebileceği interaktif 3D sahneler haline gelmez. PPTX’te, format destekliyorsa 3D biçimlendirme PowerPoint’te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, köşe yuvarlama, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale yalnızca 3D etkileri kapsar.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı yapılmalıdır. Uygulamada, render edilen yüzlerin net vurgular ve gölgeler alması için bir ışık rig’i ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3D efekt uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) kullanın.

**3D efektler, görüntülere, PDF’ye, HTML’ye veya video karelerine dışa aktarıldığında görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3D efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3D nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Nihai kamera, ışık rig’i, köşe yuvarlama ve ilgili 3D değerlerini okumak için [Shape Effective Properties](/slides/tr/java/shape-effective-properties/) bölümünde açıklanan etkili biçimlendirme API’lerini kullanın.