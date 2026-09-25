---
title: PHP'de WordArt Efektlerini Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/php-java/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin PHP'de profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, metni doldurmalar, konturlar, gölgeler, yansımalar, parıltı, dönüşümler ve 3B biçimlendirme ile stilize etmenizi sağlar. Bu makale, Microsoft Office yüklü olmadan Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında bu efektlerin nasıl oluşturulacağını ve özelleştirileceğini açıklar.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Aşağıdaki örnekler, metni, yazı tipini, desen dolgusunu ve konturu ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slaytına bir dikdörtgen ekler; giriş dosyası gerektirmez. İlk örnek metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları puan cinsinden ölçülür:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Biçimin daha belirgin olmasını sağlamak için yazı tipini Arial Black olarak 36 puanda ayarlayın:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Koyu turuncu ön plan ve beyaz arka plan ile bir [SmallGrid](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternstyle/#SmallGrid) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin konturu ekleyin:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Ortaya çıkan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulayın**

Aşağıdaki örnekler, metne gölgeler, yansımalar, parıltı, dönüşümler ve 3B efektler nasıl uygulanacağını gösterir.

### **Dış Gölge Efektlerini Uygula**

Bir dış gölge, metnin arkasına gölge yerleştirerek derinlik katar. Rengini, yönünü, mesafesini, bulanıklık yarıçapını, ölçeğini ve eğimini özelleştirebilirsiniz.

Bu örnek [enableOuterShadowEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) metodunu çağırır ve 4 puan bulanıklık yarıçapı, 230 derece yön ve 30 puan mesafe ile siyah bir gölge ayarlar. 100 ölçek değerleri gölgenin boyutunu korur, yatay eğim ise 20 derece döndürür. Alfa dönüşümü opaklığını %32 olarak ayarlar:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Ortaya çıkan metin:

![Dış Gölge etkisi](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Dış ve önceden tanımlı gölgeler birlikte kullanıldığında, yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, ortaya çıkan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki kat olur, PowerPoint 2007'de ise yalnızca dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygula**

Yansıma, metnin aynalı bir kopyasını oluşturur. Konumunu, ölçeğini, bulanıklığını ve opaklığını ayarlayarak görünümünü kontrol edebilirsiniz.

Bu örnek [enableReflectionEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effectformat/#enableReflectionEffect--) metodunu çağırır ve yansımayı -100% ölçekle dikey olarak çevirir. 0,5 puan bulanıklık yarıçapı ve 4,72 puan mesafe kullanır. Opaklık, yansıma boyunca %0 ile %60 konumları arasında %60'tan %0,9'a düşer:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Ortaya çıkan metin:

![Yansıma efekti](reflection_effect.png)

### **Parıltı Efektlerini Uygula**

Parıltı, metnin etrafına yumuşak renkli bir kontur ekler. Rengini, opaklığını ve yarıçapını ayarlayarak efekti kontrol edebilirsiniz.

Bu örnek [enableGlowEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effectformat/#enableGlowEffect--) metodunu çağırır ve %54 opaklıkta, 7 puan yarıçapında kırmızı bir parıltı uygular:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Ortaya çıkan metin:

![Parıltı efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygula**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya şekillendirebilir.

[setTransform](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setTransform-int-) metodunu [ArchUpPour](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textshapetype/#ArchUpPour) olarak ayarlayarak tüm metin çerçevesini yukarı doğru eğin:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Ortaya çıkan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java, önceden tanımlanmış bir dizi [dönüşüm türü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textshapetype/) sunar.
{{% /alert %}}

### **Şekillere ve Metne 3B Efektler Uygula**

Bir şekle veya onun metnine 3B efektler uygulayabilirsiniz. Kaldırımlar, ekstrüzyon, aydınlatma ve kamera ayarları ortaya çıkan görünümü kontrol eder.

Aşağıdaki örnek, dikdörtgene dairesel kaldırımlar, turuncu ekstrüzyon ve koyu kırmızı bir kontur eklemek için [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) kullanır. Kaldırım boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsindendir. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve bir perspektif kamera görünümünü tanımlar:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

![Şekil 3B etkisi](shape_3D_effect.png)

Bu örnek, [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) aracılığıyla metne benzer bir 3B biçimlendirme uygular. Daha küçük kaldırımlar harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik kazandırır:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

![Metin 3B etkisi](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Metne veya şekillerine 3B efektlerin uygulanması — ve bu efektler arasındaki etkileşim — belirli kurallarla yönetilir. Hem metni hem de onu içeren şekli içeren bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsilini ve yerleştirildiği sahneyi içerir.

- Eğer sahne hem şekil hem de metin için ayarlanmışsa, şeklin sahnesi öncelikli olur ve metnin sahnesi göz ardı edilir.
- Şeklin kendi sahnesi yoksa ancak 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, düz olarak kabul edilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getLightRig--) ve [ThreeDFormat::getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/#getCamera--) yöntemleriyle ilişkilidir.
{{% /alert %}}

Daha fazla 3B biçimlendirme örneği için, [Create 3D Effects in Presentations Using PHP](/slides/tr/php-java/3d-presentation/) adresine bakın.

## **SSS**

**Farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile WordArt efektleri kullanabilir miyim?**

Evet, Aspose.Slides for PHP via Java Unicode destekler ve tüm büyük yazı tipleri ve betikler ile çalışır. Gölge, dolgu ve kontur gibi WordArt efektleri, dili ne olursa olsun uygulanabilir; ancak yazı tipi bulunabilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana düzeni öğelerine uygulayabilir miyim?**

Evet, başlık yer tutucuları, alt bilgi alanları veya arka plan metni gibi ana slayt üzerindeki şekillere WordArt efektleri uygulayabilirsiniz. Ana düzente yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosyasının boyutunu etkiler mi?**

Bir miktar. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek formatlama meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle ihmal edilebilir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?**

Evet, [Slide::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage--) kullanarak WordArt içeren slaytları görüntülere (örn. PNG, JPEG) renderleyebilir veya [Shape::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage--) ile tek tek şekilleri renderleyebilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda önizleyebilirsiniz.