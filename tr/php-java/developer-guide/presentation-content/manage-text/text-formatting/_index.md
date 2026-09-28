---
title: PHP'de Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
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
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for PHP via Java kullanarak metni biçimlendirin ve stilize edin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slayttaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır temellidir. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil etkin biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Metin bulma ve vurgulama konusunda (düz metin veya düzenli ifade eşleşmeleri) daha fazla bilgi için [Metin Arama ve Değiştirme](/slides/tr/php-java/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarlama**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın veya bireysel metin bölümleri için [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getHighlightColor) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde açık vurgulama renkleri bu varsayılanın üzerine geçer:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

## **Metin Paragraflarını Hizalama**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setAlignment) kullanarak bir metin çerçevesindeki paragraf hizalamasını ayarlayın. Değer orta, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getFillFormat)'a atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50` bir ARGB alfa kanal değeri (0–255 ölçeğinde) olup, şeffaflık yüzde değeri değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulamayı gösterir:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Metnin doldurma rengini şeffaf bir renk olarak ayarla.
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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

## **Metin Karakter Aralığını Ayarlama**

[BasePortionFormat::setSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setSpacing) kullanarak bir metin kutusundaki karakterler arasındaki aralığı genişletebilir veya sıkıştırabilirsiniz. Örnekler 3 puanlık aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki PHP kodu, **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

### **Belirli Yazı Tipleri için Kerning'i Devre Dışı Bırakma**

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini göz ardı etmesi durumunda meydana gelebilir; yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda oluşturulan çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkin biçimlendirilmiş yazı tipi adlarını, kalıtılmış yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik belirler. Bu, 100 puandan küçük yazı tipi boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Eşiğin altındaki eşleşen metinler için bu ayar kerning'i önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides render'ını PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, paragraf düzeyinde [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla veya bireysel bölümlerde [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak, kalın, italik ve noktalı altı çizili biçimlendirme ile ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine geçer:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

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

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkin biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarlama**

[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setTextVerticalType) kullanarak bir şekil içinde önceden tanımlı bir metin yönelimi ayarlayın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini [TextVerticalType::Vertical270](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarlama**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setRotationAngle) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setSpaceWithin) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzdesi olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Satır Kesmeyi Kontrol Etme**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metni karışık sunumlarda kullanışlıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/)’a aittir, bu yüzden tüm paragrafı kapsar:

- [setLatinLineBreak](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) Latin satır kesme kurallarını kontrol eder. Karışık metinde, bunu değiştirmek komşu Doğu Asya metni ve noktalama işaretlerinin nerede sarılacağını da etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) Doğu Asya satır kesme kurallarını, bir satırın başındaki ve sonundaki karakterlere ilişkin kısıtlamalar dahil, kontrol eder.

Bu kurallar, bir metin çerçevesi içinde otomatik sarmayı etkinleştiren [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setWrapText) işlevinin yerini almaz. Sarma gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragraf içinde yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini açıkça ayarlar ve "line_breaking.pptx" dosyasına kaydeder. Herhangi bir kuralla deneme yapmak için, diğer ayarlar sabitken ilgili değeri değiştirin. Örnek, 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu kullanır. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType::None](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textautofittype/) ile çağrılır, böylece metin boyutu ve çerçeve boyutları sabit kalır.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Askıda Noktalama İşaretlerini Kontrol Etme**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setHangingPunctuation), uygun noktalama işaretlerinin bir sonraki satırı almaktansa metin satırının sağ kenarının ötesine uzanmasına izin verir. Tüm paragrafı kapsar ve askıda girinti ile farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde askıda noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" dosyasına kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşlukları ile son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Özelliği [NullableBool::False](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırın: bu ayarlarla nokta ayrı bir satır alır. Sarma etkinleştirilmiş ve otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Her noktalama işareti askıda kalamaz. Görünür sonuç, yazı tipi kullanılabilirliği ve yerleşime bağlıdır: yazı tipini, mevcut genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipini Ayarlama**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setAutofitType), metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını veya şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine sığacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" dosyasına kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

Otomatik sarma sonrasında satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/php-java/manage-paragraph/) sayfasına bakın. Satır sayısı tek başına metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarlama**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setAnchoringType), bir şekil içinde metnin dikey konumunu, örneğin üst, orta veya alt olarak tanımlar. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

## **Metin Sekmelerini Ayarlama**

[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat::getTabs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getTabs) kullanarak bir paragrafta sekme duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sekme durak ekler. Bu ayarlar sekme karakteri içeren metni etkiler.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

## **Denetleme Dili Ayarlama**

Aspose.Slides, bir metin bölümü için denetleme dili ayarlamanızı sağlayan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) sunar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "presentation.pptx" dosyasını ve en az bir paragrafı gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Varsayılan Dili Ayarlama**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metnin varsayılan dilini tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesiyle bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Metin içeren yeni bir dikdörtgen şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // İlk bölümün dilini kontrol et.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Varsayılan Metin Stili Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları miras alabilir.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Üst düzey paragraf formatını al.
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

## **All-Caps Etkisiyle Metin Çıkarma**

PowerPoint'te **All Caps** yazı tipi etkisini uygulamak, metni küçük harfle yazılmış olsa bile slaytta büyük harfle gösterir. Aspose.Slides ile böyle bir metin bölümü aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görünen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" metnini içerir.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

**Bir slayd üzerindeki tabloda metni nasıl değiştiririm?**

Bir slayd üzerindeki tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) kullanın. Hücreler üzerinde döngü yaparak her birini [Cell::getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/#getTextFrame) ile güncelleyin ve paragraf biçimlendirmesini [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getParagraphFormat) ile ayarlayın.

**PowerPoint slaydındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne bir degrade renk uygulamak için [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#getFillFormat) kullanın. [FillFormat::setFillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#setFillType) değerini [FillType::Gradient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönü ve şeffaflığı yapılandırın.