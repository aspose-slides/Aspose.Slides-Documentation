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
description: "Aspose.Slides ile Java'da PowerPoint şekilleri ve metinleri için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Java, şekiller ve metinler için PowerPoint benzeri 3D formatlamayı oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, kiriş, aydınlatma, malzeme, degrade veya resim doldurma ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Not" %}}

Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D formatlama efektleriyle ilgilidir. Ayrı bir 3D model dosyasının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektleri dışa aktarılmış 2D çıktıya renderlar.

{{% /alert %}}

## **3D Formatlama Kavramları**

Bir şekle 3D formatlama uygulamak için [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) yöntemini kullanın. Bu yöntem, o şeklin 3D sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D formatlama uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Bakış açısı, ön tanımlı kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık dönüşü. | 3D yüzeyde vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılmak veya yan renkleri ön doldurmayla eşleştirmek. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D formatlaması tarafından kullanılan ek 3D derinlik. | Şekiller veya metin için derinliği ince ayarlama, özellikle kiriş ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) ve [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) ve [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D nesnenin etrafındaki kontur. | Renderlanan çıktıda nesne sınırını vurgulamak. |

## **3D Şekil Oluşturma**

Bir şekil, ikna edici bir şekilde 3D görünmeden önce genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve kenarları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlandığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D formatlama uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutlarının iki katı bir PNG görüntüsüne renderlar ve sunumu PPTX olarak kaydeder:

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

Renderlanmış slayt görüntüsü, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metin bulunan renderlanmış mavi 3D dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te, 3D döndürme 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te, kamera [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) ile erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünümü seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

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

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides render ederken kullanılan 3D bakış açısını değiştirir.

### **Şablon Şekilden Kamera Yönelimini Kopyalama**

Şablon şeklin yönelimini eşleştirmek için, [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) ile kamera ön ayarını ve [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) ile döndürme açılarını okuyun. Örnek `template.pptx` dosyasını açar ve ilk slayttaki ilk şeklin kamera yönelimini ikinci şekle kopyalar. Her iki şeklin de zaten 3D aydınlatması vardır; ikinci şeklin açık bir kamera döndürmesi yoktur.

Açıların birimi derecedir. `0` indeksi enlem, `1` indeksi boylam ve `2` indeksi devrimdir. Bu sırayla [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) metoduna geçirin. Kaynak `null` döndürürse, açık bir döndürme yok demektir; bu yüzden ikinci şeklin açılarını boş bırakın. `(0, 0, 0)` gibi açık bir döndürme üç sıfır döndürür ve kopyalanmalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`camera-copy.pptx` dosyasını PowerPoint'te yeniden açtığınızda, sağdaki ok, soldaki dikdörtgenle aynı kamera ön ayarı ve döndürmeye sahiptir. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğini kullanır.

![Üstten ve sağdan bakıldığında eşleşen kamera yönelimine sahip mavi bir 3D dikdörtgen ve sağ ok](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın görünmesini sağlar. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlığı ayarlamak için [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) yöntemini, yan renklere erişmek için ise [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) yöntemini kullanın. Bu örnek, dikdörtgene mor yan yüzlerle 100 puanlık bir ekstrüzyon uygulayıp kamerayı kalınlığını gösterecek şekilde döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) yöntemi bir 3D şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) yöntemi ise örnekte gösterildiği gibi ekstrüzyon etkisinin yüksekliğini kontrol eder.

## **3D Efektlerle Degrade veya Resim Doldurma Kullanma**

3D formatlama, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurma uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyon için koyu turuncu renk uygular. Degrade durakları 0 ve 100, degrade başlangıç ve bitişini işaret eder. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutlarının iki katı bir PNG görüntüsüne renderlanır:

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

Renderlanan çıktı, ön yüze degrade uygulanmış ve ekstrüzyon ayrı olarak renderlanmış bir 3D dikdörtgen gösterir:

![Mavi- turuncu degrade doldurma ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_03.png)

Resim doldurma kullanmak için, resmi sunuma ekleyip şekil doldurmasına atayın. Bu örnek, çalışma dizininde mevcut bir `image.jpg` dosyası gerektirir. Resmi dikdörtgeni dolduracak şekilde yayar, 150 puanlık ekstrüzyon uygular ve kamerayı derecelerde döndürür. Şekli dosya kaydetmeden veya renderlamadan bellek içinde yapılandırır:

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

Resim, ön yüze fotoğraf doldurma olarak renderlanırken, ekstrüzyon 3D yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_04.png)

## **Metne 3D Formatlama Uygulama**

Şekil 3D formatlaması şekil gövdesini etkiler. Metin 3D formatlaması ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarıya doğru bir yay eğrisi ekler ve 3D ayarları [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık döndürmesi derecedir. Şekil doldurma ve kenarlık gizlenir; sadece metin görünür olur. Örnek, varsayılan slayt boyutlarının iki katı bir PNG görüntüsü renderlar ve sunumu PPTX olarak kaydeder:

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

Renderlanan 3D metin, yaylı WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyon ile görüntülenir:

![Yukarı kıvrımlı WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3D metin](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Şeklin 3D görünümünü korurken metni okunabilir tutmak için, [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) üzerinden [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metodunu çağırın. Değer `true` ise metin 3D sahneden dışarıda kalır; `false` ise metin sahneye katılır ve 3D yönelimini takip eder.

Bu ayar, şeklin kamera, ışık, malzeme ve ekstrüzyon gibi 3D formatlamasını kaldırmaz; bunlar hâlâ [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) üzerinden yapılandırılmıştır. Ayrıca sıradan döndürmeden farklıdır. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) şekli slayt düzleminde döndürürken, [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metnin sınırlayıcı kutusundaki özel döndürmeyi kontrol eder. Metni 3D sahneden dışarıda tutmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, mavi bir dikdörtgen ve metin oluşturur, orijinali yanına klonlar. Her iki şeklin de aynı 3D formatlaması vardır; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir, ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutların iki katı bir PNG’ye renderlar:

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

Solda metin 3D yönelimini takip eder. Sağda ise düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3D yönelime sahiptir.

![Yan yana 3D dikdörtgenler: metin solda 3D yönelimini takip eder, sağda düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D formatlamayı korur. Sabit‑düzen formatlarına renderlarken veya dışa aktarırken 3D sahne rasterleştirilir veya 2D sonuç olarak çıktıya çizilir. Bu, slaytları [PNG](/slides/tr/java/convert-powerpoint-to-png/), [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/java/convert-powerpoint-to-html/) olarak renderlarken veya [video conversion](/slides/tr/java/convert-powerpoint-to-video/) için kareler üretirken geçerlidir.

Bu noktaları aklınızda tutun:

- Dışa aktarılan görseller ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin bir kombinasyonuna bağlıdır.
- Eğer kalıtılmış veya tema tabanlı format değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/java/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D formatlamasını saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak saklanmak yerine renderlanır.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görseller, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde, format destekliyorsa 3D formatlama PowerPoint'te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt ise bir PowerPoint şekli veya metnine uygulanan, döndürme, ekstrüzyon, kiriş, aydınlatma ve malzeme gibi formatlamadır. Bu makale 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gerekir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, renderlanan yüzeylerin belirgin vurgular ve gölgeler alması için bir ışık kiti ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3D efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) kullanın.

**3D efektler görsellere, PDF'e, HTML'e veya video karelerine dışa aktarırken görünecek mi?**

Evet. Aspose.Slides, slayt görselleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretirken 3D efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3D nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonraki son 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık kiti, kiriş ve ilgili 3D değerlerini okumak için [Shape Effective Properties](/slides/tr/java/shape-effective-properties/) sayfasında açıklanan etkili formatlama API'lerini kullanın.