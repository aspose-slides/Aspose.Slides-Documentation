---
title: "PHP'de Sunum Metnini Biçimlendirme"
linktitle: "Metin Biçimlendirme"
type: docs
weight: 50
url: /tr/php-java/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi bağlama
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for PHP via Java kullanarak metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin yerleştirme, sekme durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran “sample.pptx” adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

Metin ara ve değiştir [Metin Ara ve Değiştir](/slides/tr/php-java/search-and-replace-text/).

## **Metin Arka Plan Rengini Ayarla**

Paragraf için varsayılan vurgulama rengini ayarlamak üzere [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın veya tek tek metin bölümleri için [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getHighlightColor) kullanın.

Aşağıdaki kod örneği **tüm paragraf** için arka plan renginin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Paragrafın tamamı için vurgulama rengini ayarla.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Metin bölümü için vurgulama rengini ayarla.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setAlignment) kullanın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın nasıl yapılacağını gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Paragrafın hizalamasını merkeze ayarla.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getFillFormat) aracılığıyla atanmış rengin alfa bileşeni ile kontrol edilir. Aşağıdaki örneklerde, `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Metnin dolgu rengini şeffaf bir renge ayarla.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Metin bölümünün şeffaflığını ayarla.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarla**

Bir metin kutusunda karakterler arasındaki aralığı genişletmek veya daraltmak için [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setSpacing) kullanın.

Aşağıdaki PHP kodu **tüm paragraf** için karakter aralığını nasıl genişleteceğinizi gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Karakter aralığını genişlet.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            $portion->getPortionFormat()->setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri için Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, aynı metin PowerPoint'te görüntülendiğinde biraz daha sık görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; yazı tipinde geçerli kerning bilgisi olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) değerini gerçek yazı tipi boyutundan çok daha büyük bir değere ayarlayın:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını engeller ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides render'ını PowerPoint'in görsel çıktısına daha yakınlaştırmaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla paragraf seviyesinde veya [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) aracılığıyla tek tek bölümler için ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipi ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini paragraftaki tüm bölümlere uygular.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Paragraf için yazı tipi özelliklerini ayarla.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Metin bölümü için yazı tipi özelliklerini ayarla.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

Bir şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.

Aşağıdaki kod örneği, şekildeki metin yönelimini `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri için Özel Döndürmeyi Ayarla**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setRotationAngle) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceWithin) metodlarını sunar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzdesi olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki kod örneği, paragraftaki satır aralığını nasıl belirleyeceğinizi gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri için Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setAutofitType), metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını veya şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Satırların otomatik kaydırma sonrası sayısını ve metin ya da şekil genişliğinin sonucu nasıl değiştirdiğini görmek için [Render Edilen Satırları Say](/slides/tr/php-java/manage-paragraph/). Tek başına satır sayısı, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Bağlantı Noktasını Ayarla**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setAnchoringType), metnin bir şekil içinde dikey olarak nerede konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Metin Sekmelerini Ayarla**

Paragrafta sekme duraklarını yapılandırmak için [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat::getTabs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getTabs) kullanın.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) sunar. Denetleme dili, PowerPoint’te yazım ve dil bilgisi denetimleri için kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin bölümü için denetleme dilinin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Denetleme dilinin kimliğini ayarla.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metodunu kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metinler için varsayılan dili tanımlayabilirsiniz.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Metin içeren yeni bir dikdörtgen şekli ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // İlk bölüm dilini kontrol et.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Varsayılan Metin Stilini Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki kod örneği, yeni bir sunumdaki tüm slaytlarda 14 pt boyutunda varsayılan kalın bir yazı tipini ayarlar.

```php
$presentation = new Presentation();
try {
    // Üst seviye paragraf biçimini al.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tüm Büyük Harf Efekti ile Metin Çıkarma**

PowerPoint’te **All Caps** yazı tipi etkisini uygulamak, metni slaytta büyük harf olarak gösterir; metin aslında küçük harfle girilmiş olsa bile. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği gibi döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Örnek olarak, sample2.pptx dosyasının ilk slaytındaki aşağıdaki metin kutusuna bakalım.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tabloda metni nasıl değiştirebilirim?**

Bir slayttaki tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) kullanın. Hücreler arasında döngü yapın ve her hücreyi [Cell::getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/#getTextFrame) ve paragraf biçimlendirmesini [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getParagraphFormat) aracılığıyla güncelleyin.

**PowerPoint slaytında metne geçiş rengi (gradient) nasıl uygulanır?**

Metne geçiş rengi uygulamak için [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getFillFormat) kullanın. [FillFormat::setFillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#setFillType) değerini [FillType::Gradient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) olarak ayarlayın ve geçiş duraklarını, yönünü ve şeffaflığını yapılandırın.