---
title: PowerPoint Tablolarında Satır ve Sütunları PHP Kullanarak Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/php-java/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı kopyala
- sütunu kopyala
- satırı kopyala
- sütunu kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint'te tablo satır ve sütunlarını yönetin ve sunum düzenleme ile veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for PHP via Java, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) sınıfı aracılığıyla yönetmenizi sağlar. Bir başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir bütün satır ya da sütuna metin biçimlendirmesi uygulayabilirsiniz.

Bu makale bu işlemleri PHP örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alıp yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun indeksleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

Satırın minimum yüksekliğini puan cinsinden ayarlamak için [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) kullanın. Bu, sabit bir yükseklik değil, alt bir sınırdır. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) gerçek yüksekliği döndürür. Satıra [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) aracılığıyla erişin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puandan başlar. Hücreler 18 puanlık Arial metin, satır bölme ve üst‑alt 6 puan kenar boşluğu kullanır; ikinci sütundaki daha uzun metin birden çok satıra kayar. Örnek minimumu 100 puana yükseltir, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve her iki sonucu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sağlanan sunumla, minimumu artırmak satıra boşluk ekler. Azaltmak bu fazladan boşluğu kaldırır, ancak gerçek yükseklik 20 puandan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alana ihtiyaç duyar. Minimumu yalnızca azaltmak, satırı içeriğinin gerektirdiği alanın altına zorlayamaz.

Gerçek yüksekliği etkileyen birkaç faktör:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla düşey alan gerektirebilir.
- **Satır bölme ve sütun genişliği:** satır bölme etkinleştirildiğinde, [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) ile sütun genişliğini azaltmak daha fazla satır oluşturabilir. Daha geniş bir sütun düşey alana ihtiyaç duyulan miktarı azaltabilir.
- **Hücre kenar boşlukları:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) ve [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) düşey boşluk ekler. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) ve [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) metin için kullanılabilir genişliği azaltır ve ek satır bölmelere neden olabilir.

Birleştirilmiş hücre olmayan bu tabloda, en çok düşey alana ihtiyaç duyan hücre tüm satır için içerik‑tabanlı alt sınırı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. İllüstre edilen sonuçlarda gerçek yükseklikler sırasıyla 70, 100 ve 55,2 puan idi: son satır 20 puanlık minimumdan daha yüksek kaldı. Metin ölçümleri ortamınızdaki yazı tiplerine bağlı olarak değişebilir. Kaydedilen sonuçları indirin: [increased minimum](row-height-increased.pptx) ve [decreased minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![Orijinal tablo, 70 puanlık ilk satır.](row-height-before.png) | ![İlk satır minimumu 100 puana artırıldıktan sonra tablo.](row-height-increased.png) | ![İlk satır minimumu 20 puana düşürüldükten sonra tablo; sarılmış metin satırı minimumdan daha yüksek tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarlama**

İlk satırı başlık biçimlendirmesi için işaretlemek üzere [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) yöntemini kullanın. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak kaydedilen tabloya erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` dosyasını kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Satırını veya Sütununu Kopyalama**

Satırları veya sütunları kopyalayarak içerik ve biçimlendirmelerini yeniden kullanabilirsiniz. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma yerleştirebilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) yöntemiyle ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilen sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satırdan oluşan bir tablo oluşturur, boyutları puan cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını 3. indekste (dördüncü konum) ekler. Sonuçta tablo yedi satır ve beş sütun içerir. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamayı devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablodan Satır veya Sütun Kaldırma**

Tabloda artık ihtiyaç duyulmayan satır veya sütunları kaldırın. Bir öğeyi kaldırmak, ardından gelen satırların veya sütunların indekslerini kaydırır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı ile oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) yöntemiyle ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilen sunumu kaydedin.

Bu örnek, üç‑üç tablo oluşturur ve indeks 1'deki satırı ve sütunu kaldırarak `TestTable_out.pptx` dosyasında iki‑iki tablo bırakır. Boyutlar puan cinsindendir. `false` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Satır Düzeyinde Metin Biçimlendirme Ayarlama**

Bir bütün satıra metin biçimlendirmesi uygulayarak hücrelerinin tutarlı kalmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) kullanın.
4. İlk satır için [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) kullanın.
5. İkinci satır için [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) kullanın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki satır bulunan `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirme Ayarlama**

Bir bütün sütuna metin biçimlendirmesi uygulayarak hücrelerinin tutarlı kalmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) kullanın.
4. İlk sütun için [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) kullanın.
5. İkinci sütun için [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) kullanın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki sütun bulunan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tablo Stil Özelliklerini Almak**

Bir tabloya uygulanmış ön ayarı alıp başka bir tabloya yeniden uygulamak için [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) yöntemini kullanın. Bu, bireysel hücre biçimlendirme geçersiz kılmaları yerine ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) uygular ve ön ayarı geri okur. `DarkStyle1` değerine karşılık gelen tam sayı değerini yazar ve tabloyu `table.pptx` dosyasına kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Mevcut bir tabloya PowerPoint temaları/stilleri uygulayabilir miyim?**

Evet. Tablo, slayt/layout/ana tema miras alır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Tablo satırlarını Excel'deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme içermez. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Belirli hücrelerde özel renkler tutarak satır‑sütun şeritleri (banded) kullanabilir miyim?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre‑düzeyi biçimlendirme tablo stiline göre önceliklidir.