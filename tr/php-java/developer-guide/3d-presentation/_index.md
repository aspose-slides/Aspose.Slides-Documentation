---
title: PHP Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de PowerPoint şekilleri ve metin için 3D efektleri uygulayın ve render edin. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, şekiller ve metin için PowerPoint tarzı 3D formatlamayı oluşturabilir, düzenleyebilir, koruyabilir ve render edebilir. Bu makale, döndürme, ekstrüzyon, köşe yuvarlamaları, aydınlatma, malzeme, degrade veya resim doldurma ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D formatlama efektleriyle ilgilidir. Ayrı 3D model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektleri dışa aktarılan 2D çıktıya yansıtır.
{{% /alert %}}

## **3D Formatlama Kavramları**

Bir şekle 3D formatlama uygulamak için [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) yöntemini kullanın. Bu yöntem, o şeklin 3D sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D formatlama uygular.

En önemli API üyeleri şunlardır:

| API Üyesi | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, ön tanımlı kamera tipi, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarıyla eşleşmek için. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeyde parlaklık ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometriyi daha düz, daha yumuşak, parlak veya metalik göstermek için. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür kılmak veya yan rengi ön doldurmayla eşleştirmek için. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D formatlamasında kullanılan ek 3D derinlik. | Şekil veya metin için derinliği ince ayarlamak, özellikle köşe ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz yüzler yerine yumuşak veya kalıplanmış kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) ve [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | 3D nesnenin etrafındaki dış hat. | Render edilmiş çıktıda nesne sınırını vurgulamak için. |

## **3D Şekil Oluşturma**

Bir şeklin inandırıcı bir şekilde 3D görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görüş ekstrüzyonu gizleyebilir.
- Aydınlatma ayarları, çünkü ışık yüzeylerin ve kenarların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıtıldığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D formatlamayı uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek slaytı iki katı varsayılan boyutta bir PNG görüntüsü olarak render eder ve sunumu PPTX olarak kaydeder.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Render edilen slayt görüntüsü dikdörtgeni kalın bir 3D blok olarak gösterir:

![Render edilmiş mavi 3D dikdörtgen, ön yüzünde beyaz 3D metin](img_01_01.png)

## **Kamerayı Kullanarak Şekli Döndürme**

PowerPoint’te 3D döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3‑D Rotation bölmesi, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides’te kamera, [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekil bellekte konfigure edilir, dosya kaydedilmez:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides’in render sırasında kullandığı 3D bakış noktasını değiştirir.

### **Şablon Şekilden Kamera Yönelimini Kopyalama**

Şablon şeklin yönelimini eşleştirmek için [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) ile kamera ön ayarını ve [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) ile döndürme açılarını okuyun. Örnek `template.pptx` dosyasını açar ve ilk slayttaki ilk şeklin kamera yönelimini ikinci şekle kopyalar. Her iki şeklin de 3D aydınlatması vardır; ikinci şeklin açık bir kamera döndürmesi yoktur.

Açıların birimi derecedir. Dizin `0` enlem, `1` boylam, `2` devrimdir. Bu değerleri aynı sırayla [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) metoduna aktarın. Kaynak `null` döndürürse, açık bir döndürme yoktur; ikinci şeklin açılarını ayarlamadan bırakın. `(0, 0, 0)` gibi açık bir döndürme üç sıfır döndürür ve kopyalanmalıdır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`camera-copy.pptx` dosyasını PowerPoint’te yeniden açtığınızda, sağdaki ok, soldaki dikdörtgenle aynı kamera ön ayarı ve döndürmeye sahiptir. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğini kullanır.

![Sol tarafta mavi 3D dikdörtgen, sağ tarafta eşleşen kamera yönelimiyle sağ ok; üstten ve sağdan görüntülenmiş](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünden geriye doğru uzatarak kalın görünmesini sağlar. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlığı ayarlamak için [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) yöntemini, yan renk için ise [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) yöntemini kullanın. Bu örnek bir dikdörtgene 100 puanlık ekstrüzyon, mor yan yüzler verir ve kalınlığı göstermek için kamerayı döndürür. Şekil bellekte konfigure edilir, dosya kaydedilmez:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) yöntemi, bir 3D şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) yöntemi ekstrüzyon yüksekliğini kontrol eder; bu örnek bunu gösterir.

## **3D Efektlerle Degrade veya Resim Doldurma Kullanma**

3D formatlama, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurma uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını koruyabilirsiniz.

Bu örnek ön yüze mavi‑turuncu bir degrade uygular, ekstrüzyonun yan yüzlerine koyu turuncu renk verir. Degrade durakları 0 ve 100, başlangıç ve bitiş noktalarını işaret eder. Kamera döndürme değerleri derecedir. Slayt iki katı varsayılan boyutta bir PNG görüntüsü olarak render edilir:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Render edilen çıktı, ön yüzdeki degradeyi korur ve ekstrüzyonu ayrı olarak render eder:

![Render edilmiş 3D dikdörtgen, mavi‑turuncu degrade doldurma ve turuncu ekstrüzyon](img_02_03.png)

Resim doldurma kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek çalışma dizininde “image.jpg” adlı bir dosyanın mevcut olduğunu varsayar. Resmi dikdörtgene yayar, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derecede ayarlar. Şekil bellekte konfigure edilir, dosya kaydedilmez veya render edilmez:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Resim ön yüze render edilirken, ekstrüzyon 3D yan yüz olarak render edilir:

![Render edilmiş 3D dikdörtgen, ön yüze fotoğraf doldurma ve turuncu ekstrüzyon](img_02_04.png)

## **Metne 3D Formatlama Uygulama**

Şekil 3D formatlaması şekil gövdesini etkiler. Metin 3D formatlaması metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt‑benzeri efektler için yararlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, bir yay kemeri ekler ve 3D ayarları [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) üzerinden yapılandırır. Ekstrüzyon yüksekliği ve derinliği puan cinsindendir, ışık döndürmesi derecedir. Şekil doldurma ve dış hat gizlenir, böylece yalnızca metin görünür. Örnek iki katı varsayılan slayt boyutunda bir PNG görüntüsü render eder ve sunumu PPTX olarak kaydeder:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metin, eğimli, ekstrüze 3D harfler olarak render edilir:

![Render edilmiş 3D metin, bir yay kemeri WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyon](img_02_05.png)

## **3D Şekil Üzerinde Metni Düz Tutma**

Metni 3D sahneden dışarıda tutmak ve şeklin 3D görünümünü korumak için [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) üzerinden [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) metodunu çağırın. Değer `true` ise metin 3D sahneden dışarıda kalır; `false` ise metin sahneye katılır ve 3D yönelimini izler.

Bu ayar, şeklin 3D formatlamasını kaldırmaz: kamera, aydınlatma, malzeme ve ekstrüzyon hâlâ [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) üzerinden yapılandırılmıştır. Ayrıca normal döndürmeden farklıdır. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) şekli slayt düzleminde döndürürken, [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) metnin kendi sınırlama kutusundaki özel döndürmesini kontrol eder. Metni sahneden dışarıda tutmak, bu açıları sıfırlamaz.

Aşağıdaki kendi içinde çalışan örnek, bir mavi dikdörtgen oluşturur, üzerine metin ekler ve orijinalin yanında bir kopyasını oluşturur. Her iki şekil de aynı 3D formatlamaya sahiptir; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki katı varsayılan boyutta PNG’ye render eder.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Sol tarafta metin 3D yönelimiyle birlikte hareket eder. Sağ tarafta metin düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3D yönelime sahiptir.

![Yan yana 3D dikdörtgenler: solda metin 3D yönelimini izler, sağda düz ve daha okunaklı](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D formatlamayı korur. Sabit düzenli formatlara render ederken veya dışa aktarırken 3D sahne rasterize edilir veya 2D sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/php-java/convert-powerpoint-to-png/), [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) formatlarına render ederken veya [video conversion](/slides/tr/php-java/convert-powerpoint-to-video/) için kareler üretirken geçerlidir.

Şunları aklınızda tutun:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık cihazı, malzeme, ekstrüzyon, doldurma ve slayt ölçeklendirme kombinasyonuna bağlıdır.
- Kalıtılmış veya tema‑tabanlı format değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/php-java/shape-effective-properties/) API’lerini okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3D formatlamasını saklayamaz. Bu formatlarda görsel sonuç render edilir, düzenlenebilir 3D ayarları korunmaz.

## **SSS**

**Aspose.Slides interaktif 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metin için PowerPoint 3D efektlerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfaları, izleyicinin döndürebileceği interaktif 3D sahneler haline getirmez. PPTX içinde, format destekliyorsa 3D formatlama PowerPoint’te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir PowerPoint şekline veya metne uygulanan döndürme, ekstrüzyon, köşe yuvarlaması, aydınlatma ve malzeme gibi formatlamadır. Bu makale 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gerekir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, render edilen yüzlerin belirgin vurgular ve gölgeler alması için bir ışık cihazı ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3D efekt uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat), metin için ise [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın.

**3D efektler, görüntülere, PDF, HTML veya video karelerine dışa aktarıldığında görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3D efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3D nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık cihazı, köşe ve ilgili 3D değerlerini okumak için [Shape Effective Properties](/slides/tr/php-java/shape-effective-properties/) içinde açıklanan etkin formatlama API’lerini kullanın.