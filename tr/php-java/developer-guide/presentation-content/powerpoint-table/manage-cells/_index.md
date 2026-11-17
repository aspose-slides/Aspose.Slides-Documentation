---
title: PHP Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/php-java/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarları kaldır
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri belirleyin, kenarları kaldırın, hücreleri bölün ve Aspose.Slides for PHP via Java ile arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonraki hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan tablonun nasıl alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

Aspose.Slides, tablo hücrelerine `(column, row)` sırasıyla sıfır‑tabanlı dizinler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğunu ve şeklin bir tablo olduğunu varsayar. Ardından tüm satır ve sütunlar üzerinde döner ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) yöntemini kullanır. Eşleşen her hücre için `row;column` sırasıyla hücre koordinatlarını, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) ve bölgenin başlangıç koordinatlarını, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) ve [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) yöntemlerini yazdırır.

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

## **Tablo Hücre Kenarlarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) yöntemiyle bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu nokta biriminde belirtilir. Örnek, tüm dört hücre kenarını [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) olarak ayarlayarak görünmez hâle getirir.

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

## **Köşegen Hücre Kenarları Ekleme**

Alt‑sağ köşeden üst‑sol köşeye çizgi çizmek için [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/), alt‑sol köşeden üst‑sağ köşeye çizgi çizmek için ise [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) yöntemini kullanın. Bir köşegen, köşe başlığı olarak işaretlenebilir; iki köşegen bir X oluşturup hücreyi “uygulanamaz” olarak gösterebilir.

Her köşegenin kendi [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) nesnesi vardır. Bu nesnenin [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) içinde, [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) ile [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) seçilir ve renk [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) ile belirlenir. Çizginin kalınlığı [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) ile nokta biriminde ayarlanır.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru köşegen, mavi yukarı doğru köşegen ve her iki köşegen. Üst, alt, sol ve sağ kenar kenarları aynı kalır.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bir köşegen yalnızca hücre biçimlendirmesini değiştirir. Her hücre, [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) aracılığıyla erişilebilen tek bir metin çerçevesi tutar. Bir köşegenin iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

Microsoft PowerPoint’te kaydedilen tablo:

![Üç tablo hücresi, üst‑sol köşeden alt‑sağ köşeye kırmızı bir köşegen, alt‑sol köşeden üst‑sağ köşeye mavi bir köşegen ve her iki köşegenin bir X oluşturduğu gösterir.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru köşegen (kırmızı, 3 pt), yukarı doğru köşegen (mavi, 5 pt) ve her iki köşegen.*

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) yöntemiyle dikdörtgen bir hücre aralığını tek bir hücreye birleştirin. Aralığın sol‑üst ve sağ‑alt köşe hücrelerini belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını kontrol eder; `false` değeri birleştirmenin yalnızca bu aralık içinde kalmasını sağlar.

Örnek, 70 nokta genişliğinde sütun ve satırlara sahip 4 × 4 bir tablo oluşturur ve `(1, 1)`‑`(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumu kullanın: bu örnekte `$table->get_Item(1, 1)`. Birleştirilmiş aralıktaki diğer konumlar tablo ızgarasının bir parçası olarak kalır, bu nedenle aralığın dışındaki hücre indeksleri değişmez.

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

Önceki örnekte hücreleri birleştirmek, tablonun ızgara yapısını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint’in tablo ızgara modelini izler.

Bu örnek, 70 nokta genişliğinde sütun ve satırlara sahip 4 × 4 bir tablo oluşturur ve `(1, 1)` hücresi üzerinde [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) yöntemini çağırır. Hücrenin 70 nokta genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `$table->get_Item(1, 1)` ve `$table->get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: asal olarak 2 ve 3. sütunlarda bulunan hücreler sırasıyla 3 ve 4. sütunlara kayar. Satır indeksleri değişmeden kalır. Bölmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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


<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70‑noktalık hücre iki 35‑noktalık hücreye bölünerek beşinci bir ızgara sütunu ekler ve sağındaki indeksleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölünmesi (1, 1) hücresini etkiler, sıfır‑tabanlı (column, row) indeksleri kullanır. Diğer satırlar iki yeni sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Satır veya Sütun Kapsamına Göre Birleştirilmiş Hücreleri Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlarken, mevcut bir satır sınırında bölmek için [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/), bir sütun sınırında bölmek için ise [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) yöntemini kullanın.

`index` parametresi, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre görecelidir:

- Satır bölme: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Sütun bölme: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ve `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, kökeni bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) ve [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) yöntemlerini kullanır ve her iki kapsama da bakar. `splitByRowSpan(1)` ardından satır 2 ve 3 ürün adları için ayrılır. Yatay iki‑sütun birleştirme için bunun yerine `splitByColSpan(1)` kullanılır.

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

        // Bölündükten sonra tablodan oluşan hücreleri alın.
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

Tablo ızgarası ve çevredeki hücre indeksleri aynı kalır. Sonuç hücreleri koordinatlarıyla alın; burada ikisi de 1 kapsama sahiptir ve [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` döndürür. Tek bir bölme sonrasında daha büyük bölgeler kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak doldurma, kenarlar ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölmeden sonra hücreleri doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı “Product A” ve “Product B” hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) sayfasına bakın.

### **Belirli Bir Yüksekliğe Göre Hücre Bölme**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) üst kısmın yüksekliğini nokta biriminde alır. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) ise üst kısmın kaç mevcut ızgara satırı içerdiğini alır. Sağ sütunda 40 noktalık bir hücreyi ortalamak için hücrenin gerçek yüksekliğinden 40 çıkarın ve kalan boşluğu eşit olarak üst ve altına bölün.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

İlk bölme bir ızgara satırı ekler ve `(1, 1)` hücresinde kalan 90 noktayı bırakır. İkinci bölme bu hücreyi 40 noktalık orta hücre ve 50 noktalık alt hücreye ayırır. Sağ sütunda üst‑alt sırasıyla 50, 40 ve 50 nokta yüksekliğinde üç hücre bulunur. Sol hücre tüm üç satırı kapsar ve özgün 140 nokta yüksekliğini korur.

![Sol hücre tam tablo yüksekliğini kapsarken, üç hücre ortada “Middle” etiketiyle gösterilir.](split-by-height.png)

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 nokta genişliğinde sütunlar ve 50 nokta yüksekliğinde satırlara sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) ile katı bir doldurma seçilir ve [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) tarafından döndürülen renk, `(2, 3)` hücresi için kırmızı olarak ayarlanır (üçüncü sütun, dördüncü satır).

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

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resim, [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) yöntemiyle yüklenir ve [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) ile sunumun resim koleksiyonuna eklenir. Ardından resim, `(0, 0)` hücresinin (tablodaki ilk hücre) resim doldurmasına atanır.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde genişletir; bu, en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri nokta birimindedir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

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

**Tek bir hücrede farklı kenar kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), [right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) kenarlarının ayrı özellikleri vardır; böylece her bir kenarın kalınlığı ve stili farklı olabilir.

**Hücrenin arka planında bir resim ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, seçilen [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) a bağlıdır. Stretch seçilirse resim yeni hücreye göre ayarlanır; tile seçilirse döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) hücrenin metin çerçevesindeki (portion) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir bölüme veya hücredeki tüm metne atarsınız.

**Tek bir hücrede farklı yazı tipleri kullanabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) düzeyinde bağımsız biçimlendirme—yazı tipi ailesi, stili, boyutu ve rengi—destekler.