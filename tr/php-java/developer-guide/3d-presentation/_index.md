---
title: PHP Kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de PowerPoint şekilleri ve metni için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, şekiller ve metin için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale döndürme, ekstrüzyon, burçlar, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getThreeDFormat--) metodunu kullanın. Metot, o şeklin 3B sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metodunu kullanın. Bu, 3B biçimlendirmeyi şekil gövdesi yerine metin çerçevesine uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Neyi kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getCamera--) | Bakış noktası, ön ayarlı kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürün veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirin. |
| [getLightRig](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık döndürmesi. | Vurguların ve gölgelerin 3B yüzeyde nasıl göründüğünü değiştirin. |
| [getMaterial](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getMaterial--) ve [setMaterial](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlayın. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getExtrusionHeight--) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli gözle görülür kalın bir 3B nesneye dönüştürün. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılın veya yan rengini ön dolgu ile uyumlu hale getirin. |
| [getDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getDepth--) ve [setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekiller veya metin için derinliği ince ayarlayın, özellikle burç ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak veya kalıplanmış bir kenar ekleyin. |
| [getContourColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getContourColor--) ve [getContourWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getContourWidth--) ve [setContourWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki kontur. | Renderlenen çıktıda nesne sınırını vurgulayın. |

## **3B Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayara ihtiyaç duyulur:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve kenarları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın renderlanmasını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutlarının iki katı bir PNG görüntüsüne renderlar ve sunumu PPTX olarak kaydeder.

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

Renderlenen slayt görüntüsü dikdörtgeni kalın bir 3B blok olarak gösterir:

![Renderlenmiş mavi 3B dikdörtgen, ön yüzünde beyaz 3B metin](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te, 3B döndürme 3-D Rotation panelinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3-D Rotation paneli, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides'ta, kameraya [ThreeDFormat::getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getCamera--) aracılığıyla erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y ve Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden hafızada yapılandırır:

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

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides render alırken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlığı ayarlamak için [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) yöntemini, yan rengini elde etmek için [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getExtrusionColor--) kullanın. Bu örnek, bir dikdörtgene mor yanlarla 100 puanlık ekstrüzyon verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden hafızada yapılandırır:

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

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setDepth-double-) yöntemi bir 3B şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) yöntemi, bu örnekte gösterildiği gibi, ekstrüzyon etkisinin yüksekliğini kontrol eder.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu degrade uygular ve 150 puanlık ekstrüzyona koyu turuncu renk verir. Degrade durakları 0 ve 100, degrade başlangıç ve bitişini gösterir. Kamera döndürme değerleri derecedir. Slayt, varsayılan boyutlarının iki katı bir PNG görüntüsüne renderlanır:

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

![Renderlenmiş 3B dikdörtgen, mavi‑turuncu degrade dolgu ve turuncu ekstrüzyon](img_02_03.png)

Bunun yerine resim doldurması kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın mevcut olmasını gerektirir. Resmi dikdörtgeni dolduracak şekilde uzatır, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini dereceler cinsinden ayarlar. Şekli dosya kaydetmeden veya renderlamadan hafızada yapılandırır:

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

![Renderlenmiş 3B dikdörtgen, ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyon](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir yay uygular ve 3B ayarları [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) aracılığıyla yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindedir, ışık döndürmesi derecedir. Şekil dolgu ve kenarlık gizlenir, böylece yalnızca metin görünür. Örnek, varsayılan slayt boyutlarının iki katı bir PNG görüntüsü renderlar ve sunumu PPTX olarak kaydeder:

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

![Renderlenmiş 3B metin, eğimli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyon](img_02_05.png)

## **Metni 3B Şekilde Düz Tutma**

Bir şeklin 3B görünümünü korurken metni okunabilir tutmak için, [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getTextFrameFormat--) üzerinden [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) çağırın. Değer `true` olduğunda, metin 3B sahnenin dışında kalır. `false` olduğunda, metin sahneye katılır ve 3B yönelimini takip eder.

Bu ayar, şeklin 3B biçimlendirmesini kaldırmaz: kamera, aydınlatma, malzeme ve ekstrüzyon [Shape::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getThreeDFormat--) aracılığıyla yapılandırılmış olarak kalır. Ayrıca sıradan döndürmeden farklıdır. [Shape::setRotation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setRotation-float-) slayt düzleminde şekli döndürürken, [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) metnin sınırlama kutusundaki özel döndürmesini kontrol eder. Metni 3B sahneden dışarı tutmak bu açılardan hiç birini sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve orijinalin yanına bir kopyasını ekler. Her iki şekil de aynı 3B biçimlendirmeye sahiptir; sadece metin ayarı farklıdır: solda `false`, sağda `true`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutların iki katı bir PNG olarak renderlar:

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

Solda, metin 3B yönelimi izler. Sağda, metin düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3B yönelimini korur.

![Yan yana 3B dikdörtgenler: sol tarafta metin 3B yönelimi izler, sağ tarafta düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına renderlarken veya dışa aktarırken, 3B sahne rasterleştirilir veya çıktı içine 2B sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/php-java/convert-powerpoint-to-png/), [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) formatlarına renderladığınızda veya [video dönüştürme](/slides/tr/php-java/convert-powerpoint-to-video/) için çerçeveler oluşturduğunuzda geçerlidir.

Bu noktaları akılda tutun:

- Dışa aktarılan görüntüler ve PDFler etkileşimli değildir. Nesne, dışa aktarmadan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık düzeni, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/php-java/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda, görsel sonuç renderlenir ve düzenlenebilir 3B ayar olarak korunmaz.

## **FAQ**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDFler veya HTML sayfalarını izleyicinin döndürebileceği etkileşimli 3B sahnelere dönüştürmez. PPTX formatında, 3B biçimlendirme, formatın desteklediği durumlarda PowerPoint içinde düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt, döndürme, ekstrüzyon, burç, aydınlatma ve malzeme gibi düzenli bir PowerPoint şekline veya metne uygulanan biçimlendirmedir. Bu makale 3B efektleri kapsar.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En azından bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarlamanız gerekir. Pratikte, renderlanan yüzlerin belirgin vurgular ve gölgeler alması için bir ışık düzeni ve malzeme de ayarlanmalıdır.

**3B efektleri hem şekillere hem de metne uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getThreeDFormat--) kullanın, metin için ise [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) kullanın.

**3B efektler görüntülere, PDF, HTML veya video çerçevelerine dışa aktarıldığında görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüştürme için kullanılan çerçeveler üretirken 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne değil.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık düzeni, burç ve ilgili 3B değerleri okumak için [Shape Effective Properties](/slides/tr/php-java/shape-effective-properties/) sayfasında açıklanan etkili biçimlendirme API'lerini kullanın.