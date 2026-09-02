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
description: "Aspose.Slides for PHP via Java ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin ve sunmanın verimli bir yoludur. Hücrelerden oluşan bir ızgaradaki (satır ve sütunlar halinde düzenlenmiş) bilgi, açık ve anlaşılması kolaydır.

Aspose.Slides, [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) sınıfını, [Hücre](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) sınıfını ve diğer türleri sağlar; böylece her türlü sunumda tabloları oluşturabilir, güncelleyebilir ve yönetebilirsiniz.

## **Sıfırdan Bir Tablo Oluşturma**

1. [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. İndeks aracılığıyla bir slaytın referansını alın.  
3. Bir `columnWidth` dizisi tanımlayın.  
4. Bir `rowHeight` dizisi tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addtable/) yöntemiyle slayta bir [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) nesnesi ekleyin.  
6. Her bir [Hücre](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [Hücre](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/)'nin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)'ına erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içine bir metin ekleyin.  
10. Değiştirilen sunumu kaydedin.

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Sütunları genişlikleriyle ve satırları yükseklikleriyle tanımlar
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücrenin kenar biçimini ayarlar
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # 1. satırın 1. ve 2. hücrelerini birleştirir
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Birleşik hücreye metin ekler
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Sunumu diske kaydeder
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standart Bir Tablodaki Numaralandırma**

Standart bir tabloda hücrelerin numaralandırması basittir ve sıfırdan başlar. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu PHP kodu, bir tablodaki hücrelerin numaralandırmasını nasıl belirteceğinizi gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Sütunları genişlikleriyle ve satırları yükseklikleriyle tanımlar
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücrenin kenar biçimini ayarlar
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Sunumu diske kaydeder
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mevcut Bir Tabloya Erişme**

1. [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. İndeks aracılığıyla tabloyu içeren bir slayta referans alın.  
3. Bir [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesi oluşturun ve null olarak ayarlayın.  
4. [Şekil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleri arasında tablo bulunana kadar dolaşın.  

   Eğer üzerinde çalıştığınız slayt tek bir tablo içeriyorsa, içinde bulunduğu tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesine tip dönüşümü yapabilirsiniz. Ancak slayt birden çok tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setalternativetext/) özelliğiyle aramak daha iyidir.  

5. [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesini kullanarak tablo ile çalışın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  
6. Değiştirilen sunumu kaydedin.

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx'i başlatır
    $tbl = null;
    # Şekiller arasında dolaşır ve bulunan tabloya bir referans ayarlar
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # İkinci satırın birinci sütununa metin ayarlar
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Değiştirilen sunumu diske kaydeder
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir TextFrame'e Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) aldığında, sahip [Hücre](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/)yi geri almak için [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) sahibi döndürür ve [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) `null` döner; tablo kendisi bir şekil olsa bile.

Hücre koordinatları, yalnızca okunabilir olan [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/#getFirstColumnIndex) ve [Cell::getFirstRowIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/#getFirstRowIndex) metodlarıyla elde edilebilir. [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) ayrıca yalnızca okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Her zaman `java_is_null` ile dönen hücreyi kontrol edip ardından kullanın.

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri içeren kapsamlı bir örnek için [Metin Arama ve Değiştirme](/slides/tr/php-java/search-and-replace-text/) bölümüne bakın.

## **Tablodaki Metni Hizalama**

1. [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. İndeks aracılığıyla bir slaytın referansını alın.  
3. Slayta bir [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) nesnesine erişin.  
5. [Paragraf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) nesnesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # Sütunları genişlikleriyle ve satırları yükseklikleriyle tanımlar
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Slayta tablo şekli ekler
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Metin çerçevesine erişir
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Metin çerçevesi için Paragraph nesnesi oluşturur
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraf için Portion nesnesi oluşturur
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Metni dikey olarak hizalar
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Sunumu diske kaydeder
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. İndeks aracılığıyla bir slaytın referansını alın.  
3. Slayttan bir [Tablo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight) ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginright/) ayarlarını yapın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/settextverticaltype/) ayarlayın.  
7. Değiştirilen sunumu kaydedin.

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("simpletable.pptx");
  try {
    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek çağrıda ayarlar
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Tablo hücrelerinin metin dikey tipini ayarlar
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; bu sayede bu detayları başka bir tabloya ya da başka bir yere uygulayabilirsiniz. Bu PHP kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// varsayılan stil ön ayar temasını değiştir

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Tablonun En-Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki boyutlarının oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı kilitleme ayarını sağlayan [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) yöntemini sunar.

Bu PHP kodu, bir tablonun en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// tersine çevir

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bir bütün tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [setRightToLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/setrighttoleft/) yöntemi sunar ve paragraflar da [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setrighttoleft/) metoduna sahiptir. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve oluşturulmasını sağlar.

**Kullanıcıların tablonun son dosyada taşınmasını veya yeniden boyutlandırılmasını nasıl engelleyebilirim?**

Şekil kilitlerini kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakın. Bu kilitler tablo için de geçerlidir.

**Bir hücre içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; seçim moduna (germe veya döşeme) göre resim hücre alanını kaplar.