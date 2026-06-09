---
title: PHP'de Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/php-java/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- tema yönet
- tema rengi
- ek palet
- tema fontu
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak tutarlı marka kimliğiyle PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temaları."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, temelde belirli bir görsel öğe kümesini ve bunların özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema renkler, [fontlar](/slides/tr/php-java/powerpoint-fonts/), [arkaplan stilleri](/slides/tr/php-java/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constitues.png)

## **Tema Rengini Değiştir**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk kümesi kullanır. Renkleri beğenmezseniz, tema için yeni renkler uygulayarak değiştirebilirsiniz. Yeni bir tema rengi seçebilmeniz için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SchemeColor) enum'unda değerler sağlar.

Bu PHP kodu, bir tema için vurgu rengini nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu şekilde ortaya çıkan rengin etkili değerini belirleyebilirsiniz:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Renk değişikliği işlemini daha da göstermek için başka bir öğe oluşturup ona (ilk işlemden gelen) vurgu rengini atarız. Ardından temadaki rengi değiştiririz:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Yeni renk her iki öğeye de otomatik olarak uygulanır.

### **Ek Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek paletten (2) renkler oluşur. Bu tema renklerini daha sonra ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri

**2** - Ek paletten renkler.

Bu PHP kodu, ek palet renklerinin ana tema renginden elde edilip şekillerde kullanılmasını gösterir:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Vurgu 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Vurgu 4, %80 daha açık
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Vurgu 4, %60 daha açık
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Vurgu 4, %40 daha açık
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Vurgu 4, %25 daha koyu
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Vurgu 4, %50 daha koyu
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor`'ı `ColorScheme` Renklerine Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema renk değerlerini içerdiğini fark edebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak, `Presentation::getMasterTheme()::getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) döndürür ve ilgili renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark yalnızca isimlendirmededir. Bu değerler aynı tema renk yuvalarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Bunlar aynı tema renklerinin sadece alternatif adlarıdır.

Bu adlandırma farkı Microsoft Office terminolojisinden gelir. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Tema ve diğer amaçlar için yazı tiplerini seçebilmeniz için Aspose.Slides bu özel tanımlayıcıları (PowerPoint'te kullanılanlara benzer) kullanır:

* **+mn-lt** - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Bu PHP kodu, Latin yazı tipini bir tema öğesine nasıl atayacağınızı gösterir:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Bu PHP kodu, sunum teması yazı tipini nasıl değiştireceğinizi gösterir:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Tüm metin kutularındaki yazı tipi güncellenecek.

{{% alert color="primary" title="TIP" %}} 
İsterseniz [PowerPoint fontlarını](/slides/tr/php-java/powerpoint-fonts/) görebilirsiniz.
{{% /alert %}}

## **Tema Arkaplan Stilini Değiştir**

Varsayılan olarak, PowerPoint uygulaması 12 önceden tanımlı arka plan sunar ancak tipik bir sunumda bu 12 arka plandan yalnızca 3 tanesi kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, bu PHP kodunu çalıştırarak sunumdaki önceden tanımlı arka plan sayısını öğrenebilirsiniz:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
[FormatScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme) sınıfının [BackgroundFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) özelliğini kullanarak, bir PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz.
{{% /alert %}} 

Bu PHP kodu, bir sunumun arka planını nasıl ayarlayacağınızı gösterir:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Dizin rehberi**: 0 dolgu yok anlamında kullanılır. Dizin 1’den başlar.

{{% alert color="primary" title="TIP" %}} 
İsterseniz [PowerPoint Arka Planı](/slides/tr/php-java/presentation-background/) görebilirsiniz.
{{% /alert %}}

## **Tema Efektini Değiştir**

PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, üç etkiyle birleştirilir: hafif, orta ve yoğun. Örneğin, efektler belirli bir şekle uygulandığında ortaya çıkan sonuç şu şekildedir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme) sınıfının 3 özelliğini ([FillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FormatScheme#getEffectStyles--)) kullanarak bir temadaki öğeleri değiştirebilirsiniz (PowerPoint seçeneklerinden daha esnek bir şekilde).

Bu PHP kodu, öğelerin bölümlerini değiştirerek bir tema efektini nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dolgu rengi, dolgu türü, gölge etkisi vb. üzerindeki sonuçtaki değişiklikler:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir temayı, ustayı (master) değiştirmeden tek bir slayta uygulayabilir miyim?**  
Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler, böylece master temayı bozmadan yalnızca o slayta yerel bir tema uygulayabilirsiniz ([SlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidethememanager/) aracılığıyla).

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**  
[Slide'ları klonla](/slides/tr/php-java/clone-slides/) hedef sunuma masterlarıyla birlikte kopyalayın. Bu, orijinal master, yerleşim düzenlerini ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrasında “etkili” değerleri nasıl görebilirim?**  
API’nin tema/renk/yazı tipi/efekt için ["effective" görünümlerini](/slides/tr/php-java/shape-effective-properties/) kullanın. Bunlar, master ve yerel geçersiz kılmaların uygulanmasından sonra çözümlenmiş, son özellikleri döndürür.