---
title: PHP ile Sunum Metnini Biçimlendir
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
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekmesi
- öntanımlı dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaydındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Hem slayt hem de şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılan kalın biçimlendirme dahil olmak üzere etkili biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Metin Arama ve Değiştirme için, [Metin Arama ve Değiştirme](/slides/tr/php-java/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın, ya da tek tek metin bölümleri için [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Tek tek bölümlerde açıkça belirlenen vurgulama renkleri bu varsayılanın üzerindeki önceliğe sahiptir:

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

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

## **Metin Paragraflarını Hizala**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) kullanın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın yolunu gösterir:

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

## **Satır İçinde Yazı Tiplerini Hizala**

Satır içinde farklı puntoya sahip metin bölümlerini dikey olarak hizalamak için [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) kullanın. Bu ayar tüm paragraf için geçerlidir ve satırların her birindeki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puanda içerir ve farklı bir yazı tipi hizalamasına sahiptir. Arial kullanır, otomatik sığdırma ve satır bölmeyi devre dışı bırakır ve metin çerçevelerini tek satır için yeterince büyük tutar.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Alt Çizgi, Üst, Orta ve Alt yazı tipi hizalamalarının karışık boyutlarla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, yazı tipi metriklerini kullanır, bu nedenle bireysel harflerin görünür kenarları mutlaka tam olarak hizalanmaz. Örnek, alt çizgi ve alt hizalama arasındaki farkı göstermek için bir büyük harf ve bir alt karakter içerir. Yazı tipi bulunabilirliği ve ikamesi, kullanılan karakterler ve yazı tipi boyutları arasındaki fark sonuçları etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, sarmalama ve otomatik sığdırma da yerleşimi etkiler; modları karşılaştırırken aynı yazı tiplerini ve yerleşim ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), ve metin bloğunu şekil içinde dikey olarak konumlandıran [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) yöntemlerinden farklıdır. Üst ve alt simge biçimlendirmesi, [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) aracılığıyla, bireysel bölümleri temel çizgiye göre kaydırır; paragraf satırlarının yazı tipi hizalamasını ayarlamaz.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) ile atanmış rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, %0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

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

## **Metin Karakter Aralığını Ayarla**

Bir metin kutusundaki karakterler arasındaki boşluğu genişletmek ya da daraltmak için [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) kullanın. Örneklerde 3 puan boşluk eklenir; negatif değerler metni sıkıştırır.

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Belirli durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint'te görüntülenen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda render edilen çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılan yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri belirler. Bu, 100 puandan daha küçük puntoya sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Eşiğin altındaki eşleşen metinler için bu ayar kerning'i önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tiplerinin Aspose.Slides render'ını PowerPoint'in görsel çıktısına yaklaştırabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ile veya tek tek bölümler üzerinde [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) ile ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak, kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Tek tek bölümlerde açıkça yapılan biçimlendirme bu varsayılanların üzerindeki önceliğe sahiptir:

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

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

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

## **Metin Yüksekliği Normalizasyonunu Kontrol Et**

Şablon tipografisini yeniden üretirken ya da karakter yüksekliği farklarını incelerken [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) kullanın. PowerPoint'te normalizasyonu etkinleştirmek, metin bölümündeki karakterleri dikey olarak uzatır ya da sıkıştırır ve görünür yüksekliği tekdüze hâle getirir. Farklı yazı tipleri arasında eşit metin yüksekliği garantilemez.

Özelliği, normalizasyonu açıkça etkinleştirmek ya da devre dışı bırakmak için [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) olarak ayarlayın. `NullableBool::NotDefined`, yerel ayarı ayarlamamış bırakır; böylece bölüm, örneğin paragrafın [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) değerini devralır. Bu `False` anlamına gelmez. Çözümlenen Boolean değeri elde etmek için [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) kullanın ve dönen etkili biçimlendirme verisinde `getNormaliseHeight`'i okuyun.

Aşağıdaki bağımsız örnek, **Arial**'ın kurulu olmasını gerektirir. 54 puanda aynı büyük harfler, küçük harfler, alt karakterler ve aksanlı karakterleri içeren iki metin bloğu oluşturur. Her iki paragraf da varsayılan olarak normalizasyonu etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakır; alt bölüm ise devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynı olup, karşılaştırmanın tutarlı kalması için sarmalama ve otomatik sığdırma devre dışı bırakılmıştır. Örnek `False: false` ve `NotDefined: true` yazdırır, ardından "text_height_normalization.pptx" dosyasını kaydeder.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki karşılaştırma, kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalizasyon devre dışı (`False`); alt satırda etkin ayar devralınır (`NotDefined` → `True`). Bu görünümü yeniden oluşturmak için Arial kurulu tutun.

![Arial 54 puan metin, üstte normalizasyon devre dışı, altta devralınan normalizasyon etkin](text_height_normalization.png)

Normalizasyon, karakter yüksekliğini atanan [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) değerini değiştirmeden değiştirir; bu değer puan cinsinden yazı tipi boyutunu belirtir. Paragraf [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) satır aralığını kontrol eder, metin çerçevesi [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) ise metnin veya kapsayıcısının nasıl sığdırılacağını belirler. Bu ayarlar farklı amaçlara hizmet eder ve genel yerleşimi bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve kalıtım hakkında daha fazla bilgi için [Manage Paragraph](/slides/tr/php-java/manage-paragraph/) bölümüne bakın.

## **Üstü Çizili Biçimini Uygula ve Kaldır**

Bir metin bölümünde düzeltmeleri, iptal edilen terimleri veya önceki fiyatları orijinal metni silmeden göstermek için [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) kullanın. Metnin üzerinden bir ya da iki çizgi çekmek için bunu [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) olarak ayarlayın.

Üstü çiziliyi kaldırmak için [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) gönderin. Bu, etrafındaki biçimlendirme üstü çizili belirtiyor olsa bile, etkisi açıkça devre dışı bırakır. Buna karşılık, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) yerel ayarı tanımsız bırakır; bölümün, örneğin paragraftan, biçimlendirmeyi devralmasına izin verir. Bu, üstü çiziliğin kaldırılmasını garanti etmez. Sonuç biçimlendirmeyi, kalıtılan değerler dahil, okumak için [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) kullanın.

Aşağıdaki bağımsız örnek üç fiyat karşılaştırması oluşturur. Her paragrafta etiket, önceki fiyat ve mevcut fiyat için ayrı bölümler bulunur; bu yüzden yalnızca önceki fiyat etkilenir. İlk satır üstü çiziliyi uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çiziliyi korur. Bu ayarın değiştirilmesi, metni ve diğer biçimlendirmeleri, kalın önceki fiyat dahil, korur.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Üstü çizgiyi uygula, ardından ilk önceki fiyatın üstündeki çizgiyi açıkça kaldır.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç, üstten alta: üstü çizili yok, tek çizgi üstü çizili ve çift çizgi üstü çizili.

![Üstü çizili olmayan önceki fiyatlar, tek çizgi üstü çizili ve çift çizgi üstü çizili](strikethrough.png)

## **Metin Döndürmesini Ayarla**

Bir şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.

Aşağıdaki kod örneği, şekildeki metin yönelimini [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlamak üzere [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) kullanın.

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

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Satır aralığını satır yüksekliğinin yüzdesi olarak belirlemek için pozitif değer kullanın.
* Satır aralığını puan cinsinden belirlemek için negatif değer kullanın.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'üne (çift satır aralığı) ayarlar:

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

## **Satır Kesintisini Kontrol Et**

Paragraf satır kesintisi kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda faydalıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) aittir, bu yüzden tüm bir paragraf için uygulanır:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) Latin satır kesintisi kurallarını kontrol eder. Karışık metinde, bunu değiştirmek, yan yana gelen Doğu Asya metni ve noktalama işaretlerinin nerede bölüneceğini de etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) Doğu Asya satır kesintisi kurallarını kontrol eder; bir satırın başındaki ve sonundaki karakterlere ilişkin kısıtlamaları içerir.

Bu kurallar, metin çerçevesi içinde otomatik sarmalamayı etkinleştiren [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) işlevini yerine geçmez. Sarmalama gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır zorlar.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesintisi seçeneğini de açıkça ayarlar ve "line_breaking.pptx" dosyasını kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak ilgili değeri değiştirin. Örnek, 24 puan Arial ve SimSun kullanır, çerçeve genişliği 160 puan ve yatay metin çerçevesi kenar boşlukları sıfırdır. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve ölçüleri sabit kalır.

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

## **Askıda Noktalama İşaretlerini Kontrol Et**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation), uygun noktalama işaretlerinin bir sonraki satırı işgal etmeden metin satırının sağ kenarından öteye uzanmasına izin verir. Bu, tüm paragraf için geçerlidir ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde askıda noktalama işaretini etkinleştirir ve "hanging_punctuation.pptx" dosyasını kaydeder. 24 puan Arial ve yatay metin çerçevesi kenar boşlukları sıfır olduğunda, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırmak için özelliği [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) olarak ayarlayın; bu ayarlarda nokta ayrı bir satır alır. Sarmalama etkinleştirilir ve otomatik sığdırma devre dışı bırakılır, böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) bu karşılaştırmaya da uygulanır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipini Ayarla**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType), metin konteyner sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma mı yoksa şekli otomatik olarak yeniden boyutlandırıp boyutlandırmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine uyması için yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

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

Otomatik sarmalamadan sonra satırları saymak ve metnin ya da şeklin genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/php-java/manage-paragraph/) bölümüne bakın. Sadece satır sayısı, metnin konteyneri aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üst, orta ya da alt. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

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

## **Metin Sekme Ayarını Yap**

[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) kullanarak bir paragrafta sekme duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sekme aralığını 100 puana ayarlar ve 30 puanda sola hizalı bir sekme durak ekler. Bu ayarlar, sekme karakteri içeren metni etkiler.

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

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) sunar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetimi için kullanılan dili belirler.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu ve en az bir paragraf içeren "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

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

### **Dil Metaverisini Kopyala**

Bir şablondan çok dilli metin kopyalarken, hem [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) hem de [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) değerlerini koruyun. Aşağıdaki bağımsız örnek, dili US English ve alternatif dili Fransızca olan bir kaynak bölüm oluşturur ve metni ve tanımlayıcıları yeni bir sunumdaki bir bölüme kopyalar.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Eğer kaynağın alternatif dili yoksa, null hedef değerini temizler.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alternatif dili olmayan bir kaynak denemek için "fr-FR" atamasını atlayın. Alternatif tanımlayıcı o zaman `null` olur ve aynı kopyalama ifadesi, hedefte daha önce atanmış bir alternatif dil olsa bile, varsayılan bir değer eklemeden yokluğunu korur.

Bu tanımlayıcılar dil metaverisi olarak saklanır. Bunların korunması, PowerPoint'in hangi sözlüğü yazım veya dilbilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarla**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanarak bir sunum yüklenirken ya da oluşturulurken oluşturulan metin için varsayılan dili tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak US English ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazdırır.

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

## **Varsayılan Metin Stili Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları devralabilir.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Üst düzey paragraf biçimini al.
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

## **Tüm Büyük Harf Etkisiyle Metni Çıkar**

PowerPoint'te **All Caps** (Tüm Büyük Harf) yazı tipi etkisini uygulamak, metin küçük harfle girilmiş olsa bile slaytta büyük harfle görünmesini sağlar. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği şekilde döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda dönen dizeyi büyük harfe dönüştürün.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafının ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

![All Caps etkisi](all_caps_effect.png)

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

**Bir slayttaki tablodaki metni nasıl değiştiririm?**

Bir slayd üzerindeki bir tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) kullanın. Hücreler üzerinde döngü yapın ve her hücreyi [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) ile güncelleyin; paragraf biçimlendirmesi için [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) kullanın.

**PowerPoint slaytındaki metne bir degrade (gradient) renk nasıl uygularım?**

Metne bir degrade renk uygulamak için [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) kullanın. [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) değerini [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.