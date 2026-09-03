---
title: PHP Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/php-java/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturun, tanımlayın, biçimlendirin ve güncelleyin."
---
## **Giriş**

Aspose.Slides for PHP via Java'da slayt metni, şekillere ait metin çerçevelerinde depolanır. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) sınıfı en yaygın metin içeren şekli temsil eder ve metnini [AutoShape::getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#getTextFrame) yöntemi aracılığıyla ortaya koyar.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfından türetilir, ancak her şekil otomatik şekil değildir veya bir metin çerçevesini desteklemez. Mevcut bir sunumu işlerken, bir şeklin metnine erişmeden önce şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olduğunu kontrol etmek için `java_instanceof` kullanın.
{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için, slayta bir otomatik şekil ekleyin, metni metin çerçevesine ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[ShapeCollection::addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape)'a geçirilen koordinatlar ve boyutlar puan cinsindendir. [AutoShape::addTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#addTextFrame) metin çerçevesini sağlanan metinle başlatır.

## **Metin Kutusu Şekli İçin Kontrol**

Bir otomatik şeklin metin kutusu olarak kabul edilip edilmediğini belirlemek için [AutoShape::isTextBox](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#isTextBox) yöntemini kullanın. Bu, bir sunumun hem metin içeren hem de yalnızca grafiksel otomatik şekilleri barındırdığı durumlarda faydalıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki tüm otomatik şekilleri inceler:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Yeni eklenen bir otomatik şekil, boş olmayan metin içerene kadar metin kutusu olarak kabul edilmez. Bu metni [AutoShape::addTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#addTextFrame) veya [TextFrame::setText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#setText) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [AutoShape::isTextBox](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#isTextBox) metodunun `false` döndürmesine neden olur:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

İlk iki çağrı `true`, son iki çağrı `false` yazdırır.

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içerdiğini bilmeden bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) alabilir. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) ’e geri gitmek için yalnızca okunabilir [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) yöntemini kullanın.

Bir otomatik şekil veya başka bir metin içeren şekil tarafından sahip olunan bir metin çerçevesi için, [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) sahibi döndürür ve [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) `null` döndürür. Erişmeden önce döndürülen değeri `java_is_null` ile kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümlerine bağlı şekilleri de içerecek şekilde tanımlamak için [Search and Replace Text](/slides/tr/php-java/search-and-replace-text/) bölümüne bakın.

## **Bir Metin Kutusuna Sütun Ekleme**

[TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setColumnCount) yöntemi metin çerçevesini sütunlara böler, [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setColumnSpacing) ise sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki ayar da [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfına aittir ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında yeniden akar; başka bir şekle devam etmez.

Aşağıdaki örnek, sütunlar arasında 10 puan boşluk olan üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve çıktıyı dosyasından saklanan ayarları geri okur:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Tek Tek Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesindeki her görsel sütuna atanan metni elde etmek için [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#splitTextByColumns) kullanın. Metod, sütun bazlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi bir elemanlı bir dizi üretir ve boş bir sütun boş bir dizeyle temsil edilir. Dize yalnızca düz metin içerir; bölüm düzeyindeki biçimlendirme korunmaz.

Bu, şunlara ihtiyaç duyduğunuzda faydalıdır:

- Metni, sütun bazlı okuma sırasını koruyarak çıkarın.
- Çok sütunlu slaytların içeriğini indeksleyin veya karşılaştırın.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe aktarın.
- Sütun sayısını [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setColumnCount), boşluğu [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setColumnSpacing), yazı tipini veya metin çerçevesi boyutunu değiştirerek metnin nasıl yeniden dağıtıldığını inceleyin.

Metod, mevcut [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içinde dağıtılan metni raporlar; ayrı şekiller veya metin kutuları arasında otomatik olarak akış sağlamaz. Sütun dağılımı kullanılabilir yazı tiplerine ve diğer metin düzeni ayarlarına bağlı olabilir; tutarlı sonuçların önemli olduğu durumlarda gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesi olan ilk çok sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütundan metni ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Metni Güncelleme**

Sunum boyunca metni güncellemek için slaytlar ve şekiller üzerinde dolaşın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenizi sağlar.

Aşağıdaki örnek, otomatik şekil metninde `years` ifadesinin her geçişini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu dolaşım yalnızca otomatik şekillerdeki metni günceller. Tablo, grafik, SmartArt veya gruplandırılmış şekillerde depolanan metin, bu nesnelerin kendi koleksiyonları arasında dolaşma gerektirir.

## **Bir Metin Kutusuna Köprü Ekleme**

Bir köprü, belirli bir metin bölümüne atanabilir, böylece sadece o metin tıklanabilir bağlantı olur. Bölümü dış bir URL ile ilişkilendirmek için [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) kullanın.

Aşağıdaki örnek bağlantılı metin oluşturur ve bir sunuma kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir ana slayt veya düzen slaytındaki bir metin kutusu ile metin tutucusu arasındaki fark nedir?**

[placeholder](/slides/tr/php-java/manage-placeholder/) bir [master slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) konum ve biçimlendirmesini devralabilir. Normal bir metin kutusu, yaratıldığı slaytta bağımsız bir şekildir ve düzen değiştiğinde tutucu davranışı kazanmaz.

**Grafiklerde, tablolarda veya SmartArt'ta metni değiştirmeden metni nasıl değiştirebilirim?**

Dolaşımı, Metni Güncelleme örneğinde gösterildiği gibi sadece [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesneleriyle sınırlayın. Grafikler, tablolar ve SmartArt, metni kendi nesne modellerinde depolar; bu nedenle döngü tarafından değiştirilmezler.