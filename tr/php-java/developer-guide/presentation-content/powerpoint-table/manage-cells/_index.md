---
title: PHP Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/php-java/manage-cells/
keywords:
- tablo hücresi
- birleştirilmiş hücreler
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP'de PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for PHP via Java ile arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücre birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunum oluşturmayı veya açmayı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilen sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine erişmek için sıfır tabanlı indeksler kullanır ve sırası `(column, row)` biçimindedir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Ardından tüm satır ve sütunlarda döngü yapar ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) yöntemini kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), ve bölgenin başlangıç koordinatlarını [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) ve [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) yazdırır.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) kullanarak bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığının tamamını [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) olarak ayarlar ve böylece kenarlıklar görünmez hâle gelir.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) kullanarak tablo hücrelerinin dikdörtgen bir aralığını tek bir hücreye birleştirin. Aralığın sol üst ve sağ alt köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını kontrol eder; `false` birleştirmenin yalnızca bu aralıkta kalmasını sağlar.

Örnek, 70 puanlık sütun ve satırlara sahip 4 × 4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için bu örnekte üst‑sol konumu kullanın: `$table->get_Item(1, 1)`. Birleştirilmiş aralıktaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralık dışındaki hücre indeksleri değişmez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücre birleştirme, tablonun ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puanlık sütun ve satırlara sahip 4 × 4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) metodunu çağırır. Hücrenin 70 puanlık genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için geçirilir.

Bu bölmeden sonra iki yarı `$table->get_Item(1, 1)` ve `$table->get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: başlangıçta 2. ve 3. sütunlarda bulunan hücreler sırasıyla 3. ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölme işleminden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Birleştirilmiş Hücreleri Satır veya Sütun Genişliğine Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlarken, mevcut bir satır sınırına göre bölmek için [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/), bir sütun sınırına göre bölmek için ise [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre görelidir:

- Satır bölme: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Sütun bölme: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Örnek, bir sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) ve [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) ile köken bulunur ve her iki genişlik de kontrol edilir. `splitByRowSpan(1)` ardından satır 2 ve 3’ü ürün adları için ayırır. Yatay iki‑sütun birleştirme için `splitByColSpan(1)` kullanılabilir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Bölme işleminden sonra tablodan elde edilen hücreleri alın.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Tablo ızgarası ve çevre hücre indeksleri değişmeden kalır. Sonuç hücreleri koordinatlarıyla alın; burada her ikisi de 1 genişliğe sahiptir ve [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` yazdırır. Daha büyük bölgeler tek bir bölme işleminden sonra kısmen birleşik kalabilir.

Orijinal metin ve biçimlendirme üst (veya sol) hücrede kalır; yeni hücre boştur ancak doldurma, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölme işleminden sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı “Product A” ve “Product B” hücreleri içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) bölümüne bakın.

## **Tablo Hücre Arka Plan Rengini Değiştirme**

Bu örnek, 150 puanlık sütunlar ve 50 puanlık satırlara sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) ile katı bir doldurma seçilir ve [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) tarafından döndürülen renk, `(2, 3)` hücresi için kırmızı olarak ayarlanır.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine yerleştirin. Resim, [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) ile yüklenir ve [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) ile sunumun resim koleksiyonuna eklenir. Ardından resim, tablo içindeki `(0, 0)` hücresinin resim doldurmasına atanır.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) resmi hücreye sığdıracak şekilde gerer; bu, en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), [right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) kenarlıkların ayrı özellikleri vardır; bu sayede her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) seçimine bağlıdır. Stretch seçilirse resim yeni hücreye göre ayarlanır; tile seçilirse döşeme parçaları yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) hücrenin metin çerçevesindeki (portion) düzeyinde ya da tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir bölüme ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri kullanabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) düzeyinde bağımsız biçimlendirme—yazı tipi ailesi, stili, boyutu ve rengi—destekler.