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
- en/boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı hızlandırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin ve aktarmanın etkili bir yoludur. Hücrelerden (satır ve sütunlarda düzenlenmiş) oluşan bir ızgaradaki bilgiler basit ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) sınıfını, [Cell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) sınıfını ve diğer türleri sağlayarak, çeşitli sunumlarda tablolar oluşturmanıza, güncellemenize ve yönetmenize olanak tanır.

## **Sıfırdan Bir Tablo Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksinden alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addtable/) yöntemiyle bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) nesnesi ekleyin.  
6. Her bir [Cell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) üzerinden döngü yaparak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [Cell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) nesnesinin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine bir metin ekleyin.  
10. Değiştirilen sunumu kaydedin.

Bu PHP kodu, bir sunum içinde tablo oluşturmanın nasıl yapıldığını gösterir:

```php
  # PPTX dosyasını temsil eden bir Presentation sınıfını oluşturur
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenarlık biçimini ayarlar
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
    # 1. satırın 1 ve 2. hücrelerini birleştirir
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Birleştirilen hücreye biraz metin ekler
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Sunumu diske kaydeder
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standart Bir Tablo'da Numarlama**

Standart bir tabloda, hücrelerin numaralandırması basit ve sıfır temelli (zero‑based) olur. Tablo içindeki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu PHP kodu, bir tablodaki hücrelerin numaralandırmasının nasıl belirtileceğini gösterir:

```php
  # PPTX dosyasını temsil eden bir Presentation sınıfını başlatır
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenarlık biçimini ayarlar
    foreach($tbl->getRows() as $row) {
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

## **Mevcut Bir Tabloya Erişim**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla tabloyu içeren slaytın referansını alın.  
3. Bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleri üzerinde döngü yapın.  
   Eğer üzerinde çalıştığınız slaydın tek bir tablo içerdiğini düşünüyorsanız, içinde bulunan tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesine tip dönüşümüyle (typecast) atayabilirsiniz. Ancak, çalıştığınız slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setalternativetext/) yöntemiyle aramanız daha iyidir.  
5. Tabloyla çalışmak için [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesini kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  
6. Değiştirilen sunumu kaydedin.

Bu PHP kodu, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx'i başlatır
    $tbl = null;
    # Şekiller üzerinde döngü yapar ve bulunan tabloya bir referans ayarlar
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # İkinci satırın birinci sütunu için metni ayarlar
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

## **Bir Tablo İçinde Metni Hizalama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksinden alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) nesnesine erişin.  
5. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) öğesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.

Bu PHP kodu, bir tabloda metni nasıl hizalayacağınızı gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
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

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksinden alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight) metodunu ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginright/) metodlarını ayarlayın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/settextverticaltype/) metodunu ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Bu PHP kodu, bir tablodaki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("simpletable.pptx");
  try {
    # İlk slaydın ilk şeklinin bir tablo olduğunu varsayalım
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıyla ayarlar
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

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; bu ayrıntıları başka bir tabloya ya da başka bir yere uygulayabilirsiniz. Bu PHP kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

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

## **Bir Tablonun En/Boy Oranını Kilitleme**

Geometrik bir şeklin en/boy oranı, farklı boyutlarda ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en/boy oranı kilitleme ayarını etkinleştirmenizi sağlayan [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) metodunu sunar.

Bu PHP kodu, bir tablonun en/boy oranını nasıl kilitleyeceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Tam bir tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [setRightToLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/setrighttoleft/) metodunu ortaya çıkarır ve paragraflar [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setrighttoleft/) metoduna sahiptir. İkisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların final dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

Taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakmak için şekil kilitlerini kullanın. Bu kilitler tablolara da uygulanır.

**Bir hücrenin içinde arka plan olarak resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; görüntü, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.