---
title: PHP Kullanarak Sunumlarda 3B Efektler Oluşturun
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/php-java/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B dönüş
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de PowerPoint şekilleri ve metinleri için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, şekiller ve metin için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, döndürme, ekstrüzyon, köşe yuvarlamaları, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B etkileri kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme etkileriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme hakkında değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B etkileri dışa aktarılan 2B çıktıya işler.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfını ve onun [Shape::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getThreeDFormat--) yöntemini kullanın. Yöntem, o şeklin 3B sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfını ve onun [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) yöntemini kullanın. Bu, 3B biçimlendirmeyi şekil gövdesi yerine metin çerçevesine uygular.

En önemli ayarlar şunlardır:

| Yöntem veya ayar | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getCamera--) | Görüş noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya PowerPoint 3B döndürme ön ayarına uymak için. |
| [getLightRig](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getLightRig--) | Işık ön ayarı, yönü ve ışık döndürmesi. | 3B yüzeydeki ışık vurgularının ve gölgelerin nasıl görüneceğini değiştirmek için. |
| [setMaterial](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Yüzey malzemesi, örneğin düz, mat, plastik veya metal. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [setExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye doğru ne kadar uzandığını. | Düz bir şekli görünür şekilde kalın bir 3B nesne haline getirmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Ekstrüde edilmiş yan yüzeylerin rengi. | Derinliği görünür kılmak veya yan renkleri ön doldurmayla eşleştirmek için. |
| [setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesi tarafından kullanılan ek 3B derinlik. | Şekiller veya metin için derinliği ince ayarlamak, özellikle köşe yuvarlaması ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getBevelBottom--) | Ön ve arka yüzeylerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya şekillendirilmiş bir kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getContourColor--) ve [setContourWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki kontur. | İşlenmiş çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şekil, gerçekçi bir 3B görünüm elde etmeden önce genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.  
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.  
- Malzeme ayarları, çünkü yüzey ışığın nasıl işleneceğini etkiler.  
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsüne işler.

```php
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

İşlenmiş slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Ön yüzünde beyaz 3B metinli mavi 3B dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te, 3B döndürme 3-D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3-D Döndürme bölmesi, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides'de, kamera tipi ve döndürmeyi [ThreeDFormat::getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getCamera--) aracılığıyla ayarlayın:

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmeniz gerektiğinde kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından işleme sırasında kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlık için [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double...), yan renk için ise [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getExtrusionColor--) ayarlayın:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#setDepth-double--)'ı, PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği köşe yuvarlaması, malzeme ve metin etkileriyle birleştirdiğinizde kullanın. Çoğu şekil senaryosunda, `setExtrusionHeight` daha açık bir ayardır çünkü görünür ekstrüzyonu doğrudan ifade eder.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanmaya devam edebilirsiniz.

Bu örnek, şekle bir degrade doldurma ve yanlara daha koyu bir ekstrüzyon rengi uygular:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

İşlenmiş çıktı, ön yüzekte degradeyi korur ve ekstrüzyonu ayrı olarak işler:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_03.png)

Bunun yerine resim doldurma kullanmak için, görüntüyü sunuma ekleyin ve şekil doldurmasına atayın:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

Resim ön yüzeyde işlenirken, ekstrüzyon 3B yan yüzey olarak işlenir:

![Ön yüzeyde fotoğraf doldurma ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirme şekil gövdesini etkiler. Metin 3B biçimlendirme ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri etkiler için yararlıdır.

Aşağıdaki örnek, desen doldurmalarıyla metin oluşturur, bir WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) üzerindeki 3B ayarları yapılandırır:

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

Metin, kavisli, ekstrüzyonlu 3B harfler olarak işlenir:

![Kavisli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu işlenmiş 3B metin](img_02_05.png)

## **Dışa Aktarma ve İşleme Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit düzen formatlarına işleme veya dışa aktarma sırasında, 3B sahne rasterize edilir veya çıktı içine 2B sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/php-java/convert-powerpoint-to-png/), [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/)’e işlediğinizde veya [video conversion](/slides/tr/php-java/convert-powerpoint-to-video/) için çerçeveler oluşturduğunuzda da geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.  
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklendirmesinin kombinasyonuna bağlıdır.  
- Eğer devralınan veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkili şekil özellikleri](/slides/tr/php-java/shape-effective-properties/) sayfasını okuyun.  
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine işlenir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve işler. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfalarını izleyicinin döndürebileceği etkileşimli 3B sahnelere dönüştürmez. PPTX'te, 3B biçimlendirme, formatın desteklediği PowerPoint içinde düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise, döndürme, ekstrüzyon, köşe yuvarlaması, aydınlatma ve malzeme gibi normal bir PowerPoint şekline veya metnine uygulanan biçimlendirmedir. Bu makale 3B efektleri ele almaktadır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En azından bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarlamalısınız. Uygulamada, işlenmiş yüzeylerin belirgin ışık vurguları ve gölgeleri olmasını sağlamak için bir ışık rig'i ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getThreeDFormat--) , metin için ise [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) kullanın.

**3B efektler görüntülere, PDF'ye, HTML'ye veya video çerçevelerine dışa aktarıldığında görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretildiğinde 3B efektleri işler. Dışa aktarılan çıktı, düzenlenebilir bir 3B nesne yerine işlenmiş görünümü içerir.

**Devralma ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık rig'i, köşe yuvarlaması ve ilgili 3B değerlerini okumak için [Shape Effective Properties](/slides/tr/php-java/shape-effective-properties/) sayfasında açıklanan etkili biçimlendirme API'lerini kullanın.