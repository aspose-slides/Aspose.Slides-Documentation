---
title: PHP'de Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/php-java/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en-boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgileri satırlar ve sütunlar halinde düzenler, böylece değerleri okumak ve karşılaştırmak daha kolay olur.

Aspose.Slides, sunumlarda tablo oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Tablo](https://reference.aspose.com/slides/php-java/aspose.slides/table/) sınıfını, [Hücre](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) sınıfını ve diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Pozisyonunu, sütun genişliklerini ve satır yüksekliklerini belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak slayta bir referans alın.
3. Sütun genişliklerini puan cinsinden bir dizi olarak tanımlayın.
4. Satır yüksekliğini puan cinsinden bir dizi olarak tanımlayın.
5. Slayta, [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) yöntemi aracılığıyla bir [Tablo](https://reference.aspose.com/slides/php-java/aspose.slides/table/) nesnesi ekleyin.
6. Her bir [Hücre](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) üzerinde döngü yaparak üst, alt, sağ ve sol kenarlıklara biçimlendirme uygulayın.
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.
8. Birleştirilmiş hücreye, [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) yöntemiyle erişin.
9. Birleştirilmiş hücreye metni ayarlayın.
10. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puan konumunda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlık uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda, hücre indeksleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler bu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 puan ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mevcut Bir Tabloya Erişim**

Tablolar bir slaydın şekil koleksiyonunda depolanır. Şekiller arasında dolaşarak bir tablo bulun, ardından [Tablo](https://reference.aspose.com/slides/php-java/aspose.slides/table/) sınıfını kullanarak hücrelerini okuyun veya güncelleyin.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.
2. Tablonun bulunduğu slayta dizinle bir referans alın.
3. [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) nesneleri arasında döngü yapın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı tanımlamak için [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) kullanın.
4. Hedef hücredeki metni güncelleyin.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. Hücreyi sütun 0, satır 1 olarak `New` değerine ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Mevcut bir tabloda satırı yeniden boyutlandırmak ve gerçek yüksekliğin istenen minimumu neden aşabileceğini anlamak için [Satır Yüksekliğini Kontrol Et](/slides/tr/php-java/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan bir [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) aldığında, sahibi olan [Hücre](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) nesnesini elde etmek için [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) sahibi döndürür ve [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) `null` döndürür, tablo kendisi bir şekil olmasına rağmen.

Hücre koordinatları, sadece okunabilir [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) ve [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) yöntemleriyle elde edilebilir. [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) ayrıca sadece okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce her zaman döndürülen hücreyi `java_is_null` ile kontrol edin.

SmartArt düğümleriyle ilişkili şekiller dahil, tablo hücresi ve şekil sahiplerini tanımlayan tam bir örnek için [Metin Arama ve Değiştirme](/slides/tr/php-java/search-and-replace-text/) bölümüne bakın.

## **Bir Tablo İçinde Metni Hizalama**

Bireysel tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak slayta bir referans alın.
3. Slayta bir [Tablo](https://reference.aspose.com/slides/php-java/aspose.slides/table/) nesnesi ekleyin.
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) nesnesine erişin.
5. İlk [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) nesnesine erişin ve metnini ve rengini ayarlayın.
6. Hücrenin dikey sabitlemesini ve metin yönünü [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) ve [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) kullanarak ayarlayın.
7. Değiştirilen sunumu kaydedin.

Bu örnek, 120 puan sütun genişliği ve 100 puan satır yüksekliği olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değer ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Düzeyinde Metin Biçimlendirmeyi Ayarlama**

[setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayın. Aşırı yüklemeleri bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, bu sayede bireysel hücreler arasında döngü yapmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.
2. Dizini kullanarak slayta bir referans alın.
3. Slayttan bir [Tablo](https://reference.aspose.com/slides/php-java/aspose.slides/table/) nesnesine erişin.
4. Metin için [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) kullanarak yazı tipi boyutunu ayarlayın.
5. [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) kullanarak paragraf hizalamasını ve sağ kenar boşluğunu ayarlayın.
6. [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) kullanarak metin yönünü ayarlayın.
7. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek `table.pptx` dosyasını açar; bu dosya en az bir slayt ve ilk şekli tablo olmalıdır. Yazı tipi boyutunu 25 puan olarak ayarlar, paragrafları 20 puan sağ kenar boşluğu ile sağa hizalar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Stil Özelliklerini Almak**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) kullanarak bir tablonun ön tanımlı stilini okuyabilir ve [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) ile atayabilirsiniz. Bu örnek, bir tabloya [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) uygular, ön tanımlı değeri yazdırır ve aynı ön tanımı ikinci tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Tablonun En-Boy Oranını Kilitleme**

Bir tablonun en-boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) kullanın.

Aşağıdaki örnek `pres.pptx` dosyasını açar; bu dosya en az bir slayt ve ilk şekli tablo olmalıdır. Mevcut kilit durumunu yazdırır, en‑boy oranı kilidini etkinleştirir, güncellenmiş durumu (`true`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Tam bir tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) yöntemini sunar ve paragraflar [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) yöntemine sahiptir. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlemeyi sağlar.

**Kullanıcıların final dosyasında bir tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) kullanarak hareket ettirmeyi, yeniden boyutlandırmayı, seçimi vb. devre dışı bırakabilirsiniz. Bu kilitler tablolara da uygulanır.

**Bir hücre içine arka plan olarak resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; bu resim, seçilen moda (esnetme veya döşeme) göre hücre alanını kaplar.