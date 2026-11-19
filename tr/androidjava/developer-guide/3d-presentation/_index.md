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
description: "Aspose.Slides ile Android'de PowerPoint şekilleri ve metni için 3D efektleri uygula ve renderla. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandır."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, şekiller ve metin için PowerPoint tarzı 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale, döndürme, ekstrüzyon, oluklar, aydınlatma, malzeme, degrade veya resim doldurmalar ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Note" %}}

Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Ayrı bir 3D model dosyası ekleme veya düzenleme ile ilgili değildir. Bir slaytı görüntüye, PDF’ye veya HTML’ye dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılan 2D çıktıya renderlar.

{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) metodunu kullanın. Bu metod, o şeklin 3D sahnesini kontrol eden [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) nesnesini döndürür.

Metin için, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metodunu kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Görünüm noktası, önceden ayarlanmış kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarını eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeyde vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür kılar veya yan renkleri ön doldurma ile eşleştirir. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D biçimlendirmede kullanılan ek 3D derinlik. | Şekiller veya metin için derinliği ince ayar yapar, özellikle oluk ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak veya kalıplanmış bir kenar ekler. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) ve [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) ve [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D nesnenin etrafındaki anahat. | Renderlanan çıktıda nesne sınırını vurgular. |

## **3D Şekil Oluşturma**

Bir şeklin ikna edici bir 3D görünüm kazanması için genellikle dört tür ayara ihtiyacı vardır:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderleneceğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı iki kat varsayılan boyutta bir PNG görüntüsü olarak renderlar ve sunumu PPTX olarak kaydeder:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Renderlanan slayt görüntüsü, dikdörtgene kalın bir 3D blok görünümü verir:

![Render edilmiş mavi 3D dikdörtgen, ön yüzünde beyaz 3D metin](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint’te 3D döndürme, 3‑D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3-D Döndürme bölmesi, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides’te kameraya, [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

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

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından renderlarken kullanılan 3D bakış noktasını değiştirir.

### **Şablon Şekilden Kamera Yönlendirmesini Kopyalama**

Şablon şeklin yönlendirmesini eşlemek için, [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) ile kamera ön ayarını ve [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) ile döndürme açılarını okuyun. Örnek `template.pptx` dosyasını açar ve ilk slaydın ilk şekilinden kamera yönlendirmesini ikinci şekle kopyalar. Her iki şeklin de 3D aydınlatması vardır ve ikinci şeklin açık bir kamera döndürmesi yoktur.

Açılar derecedir. `0` indeks enlemdir, `1` indeks boylamdır ve `2` indeks devrimdir. Bu sırayla [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) metoduna aktarın. Kaynak `null` döndürürse, açık bir döndürmesi yoktur, bu yüzden ikinci şeklin açılarını ayarlamayın. `(0, 0, 0)` gibi açık bir döndürme üç sıfır döndürür ve kopyalanmalıdır.

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

`camera-copy.pptx` dosyasını PowerPoint’te yeniden açtığınızda, sağdaki ok, soldaki dikdörtgene aynı kamera ön ayarı ve döndürmesiyle görünür. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğini kullanır.

![Sol tarafta dikdörtgen, sağ tarafta aynı kamera yönlendirmesine sahip bir ok; üstten ve sağdan bakılıyor](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünden geriye uzatarak kalın gösterir. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlığı ayarlamak için [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metodunu ve yan renk için [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) metodunu kullanın. Bu örnek, dikdörtgene 100 puanlık bir ekstrüzyon, mor yan yüzler verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) metodu, bir 3D şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) metodu ise ekstrüzyon yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3D Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye düz renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüzde mavi‑tan‑turuncu bir degrade ve 150 puanlık ekstrüzyon için koyu turuncu renk uygular. Degrade durakları 0 ve 100, degrade başlangıç ve bitişini işaret eder. Kamera döndürme değerleri derecedir. Slayt iki kat varsayılan boyutta bir PNG’ye renderlanır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

Renderlanan çıktı, ön yüzdeki degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑tan‑turuncu degrade doldurmalı 3D dikdörtgen ve turuncu ekstrüzyon ile renderlanmış](img_02_03.png)

Resim doldurması kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde mevcut bir `image.jpg` dosyası gerektirir. Resmi dikdörtgeni dolduracak şekilde gerer, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece cinsinden ayarlar. Şekli dosya kaydetmeden veya renderlamadan bellekte yapılandırır:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

Resim ön yüzde renderlanırken, ekstrüzyon 3D yan yüz olarak renderlanır:

![Ön yüzde fotoğraf doldurmalı 3D dikdörtgen ve turuncu ekstrüzyon ile renderlanmış](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin de ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, bir yükseltilmiş kemer uygular ve 3D ayarları [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) üzerinden yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindedir, ışık döndürmesi derecedir. Şekil doldurma ve anahat gizlenir, böylece sadece metin görünür. Örnek, iki kat varsayılan slayt boyutunda bir PNG görüntüsü renderlar ve sunumu PPTX olarak kaydeder:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

Metin, kavisli, ekstrüde edilmiş 3D harfler olarak renderlanır:

![Kemerli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyon ile renderlanmış 3D metin](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Metnin okunabilirliğini korurken şeklin 3D görünümünü sürdürmek için, [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) üzerinden [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) metodunu çağırın. Değer `true` olduğunda, metin 3D sahneden dışarıda kalır. `false` olduğunda, metin sahneye katılır ve 3D yönlendirmeyi izler.

Bu ayar, şeklin 3D biçimlendirmesini kaldırmaz: kamera, aydınlatma, malzeme ve ekstrüzyon, [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) üzerinden yapılandırılmış olarak kalır. Ayrıca sıradan döndürmeden farklıdır. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) şekli slayt düzleminde döndürürken, [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metnin kendi sınırlama kutusu içindeki özel döndürmesini kontrol eder. Metni 3D sahneden dışarıda tutmak, bu açılardan hiç birini sıfırlamaz.

Aşağıdaki bağımsız örnek, mavi bir dikdörtgeni metinle oluşturur ve orijinalin yanına kopyalar. Her iki şekil aynı 3D biçimlendirmeye sahiptir; yalnızca metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki kat varsayılan boyutta PNG’ye renderlar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

Sol tarafta metin 3D yönlendirmeyi izler. Sağ tarafta ise metin düz kalır ve daha kolay okunur. Her iki dikdörtgen de aynı görünen ekstrüzyon ve 3D yönlendirmeyi korur.

![Yan yana 3D dikdörtgenler: sol tarafta metin 3D yönlendirmeyi izler, sağ tarafta düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit‑sayfa formatlarına renderlarken veya dışa aktarırken 3D sahne, 2D sonuç olarak rasterleştirilir veya çıkışa çizilir. Bu, slaytları [PNG](/slides/tr/androidjava/convert-powerpoint-to-png/), [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) formatlarına renderladığınızda veya [video dönüşümü](/slides/tr/androidjava/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Şunları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig’i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Kalıtılmış veya tema‑bazlı biçimlendirme değerlerini incelemek istiyorsanız, [effective shape properties](/slides/tr/androidjava/shape-effective-properties/) bölümünü okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları yerine renderlanmış olarak saklanır.

## **FAQ**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfalarını, izleyicinin döndürebileceği etkileşimli 3D sahnelere dönüştürmez. PPTX formatında, 3D biçimlendirme, formatın desteklediği PowerPoint’te düzenlenebilir olarak kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt ise normal bir PowerPoint şekline veya metnine uygulanan, döndürme, ekstrüzyon, oluk, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale, 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gerekir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, renderlanan yüzlerin belirgin vurgular ve gölgeler alması için bir ışık rig’i ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3D efekt uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) metodlarını kullanın.

**Görseller, PDF, HTML veya video karelerine dışa aktarırken 3D efektler görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretirken 3D efektleri renderlar. Dışa aktarılan çıktı, renderlanmış görünümü içerir; düzenlenebilir bir 3D nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık rig’i, oluk ve ilgili 3D değerlerini okumak için [Shape Effective Properties](/slides/tr/androidjava/shape-effective-properties/) bölümünde açıklanan etkili biçimlendirme API’larını kullanın.