---
title: PowerPoint Sunumlarında PHP Kullanarak Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/php-java/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenar kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile PowerPoint'te tablo hücrelerini zahmetsizce yönetin. Hücrelere hızlıca erişme, değiştirme ve stillendirme konularında uzmanlaşarak sorunsuz bir slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işlemlerinden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresinin içine nasıl resim ekleyeceğinizi açıklar. Örneklerde bir sunum oluşturma veya açma, slayttan tablo alma, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncelleme ve değiştirilmiş sunumu PPTX dosyası olarak kaydetme adımları gösterilmiştir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunlarında döngü yapın.  
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdırın.

Bu PHP kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı gösterir:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// Slide#0.Shape#0'ın bir tablo olduğunu varsayarak

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Hücresi Kenarlıklarını Kaldırma**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.  
2. İndeks yoluyla bir slaydın referansını alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. Slayta [addTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addTable) yöntemiyle bir tablo ekleyin.  
6. Her hücreyi dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin.  
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, tablo hücrelerinin kenarlıklarını nasıl kaldıracağınızı gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Slayta tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenar biçimini ayarlar
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # PPTX dosyasını diske yazar
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Birleştirilmiş Hücrelerde Sayılandırma**
2 çift hücreyi (1, 1) x (2, 1) ve (1, 2) x (2, 2) birleştirirsek, ortaya çıkan tablo numaralandırılacaktır. Bu PHP kodu işlemi gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenar biçimini ayarlar
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
    # Hücreleri (1, 1) x (2, 1) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Hücreleri (1, 2) x (2, 2) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ardından (1, 1) ve (1, 2) hücrelerini birleştirerek hücreleri daha da birleştiririz. Sonuç, ortasında büyük bir birleştirilmiş hücre bulunan bir tablo olur:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenar biçimini ayarlar
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
    # Hücreleri (1, 1) x (2, 1) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Hücreleri (1, 2) x (2, 2) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Hücreleri (1, 1) x (1, 2) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # PPTX dosyasını diske yazar
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bölünmüş Hücrede Sayılandırma**
Önceki örneklerde, tablo hücreleri birleştirildiğinde diğer hücrelerdeki numaralandırma değişmemişti.

Bu sefer, birleştirilmiş hücre içermeyen normal bir tablo alıp (1,1) hücresini bölerek özel bir tablo oluşturuyoruz. Bu tablonun numaralandırmasına dikkat edin; Microsoft PowerPoint’in tablo hücrelerini numaralandırma şekli ve Aspose.Slides aynı davranışı sergiler.

Bu PHP kodu, açıklanan süreci gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Slayta bir tablo şekli ekler
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Her hücre için kenar biçimini ayarlar
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
    # Hücreleri (1, 1) x (2, 1) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Hücreleri (1, 2) x (2, 2) birleştirir
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # (1, 1) hücresini bölüyor
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # PPTX dosyasını diske yazar
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu PHP kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # yeni bir tablo oluştur
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # bir hücrenin arka plan rengini ayarla
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Tablo Hücresinin İçine Resim Ekleme**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.  
2. İndeks yoluyla bir slaydın referansını alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. Slayta [AddTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addTable) yöntemiyle bir tablo ekleyin.  
6. Görüntü dosyasını tutmak için bir `Images` nesnesi oluşturun.  
7. `IImage` görüntüsünü `IPPImage` nesnesine ekleyin.  
8. Tablo hücresi için `FillFormat` değerini `Picture` olarak ayarlayın.  
9. Görseli tablonun ilk hücresine ekleyin.  
10. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir tablo oluştururken bir tablo hücresinin içine nasıl resim yerleştirileceğini gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı erişir
    $islide = $pres->getSlides()->get_Item(0);
    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Slayta bir tablo şekli ekler
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Görüntü dosyasını kullanarak bir IPPImage nesnesi oluşturur
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Görüntüyü ilk tablo hücresine ekler
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX dosyasını diske kaydeder
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stiller ayarlayabilir miyim?**

Evet. Üst/[top](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellformat/getbordertop/), alt/[bottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellformat/getborderbottom/), sol/[left](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellformat/getborderleft/) ve sağ/[right](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellformat/getborderright/) kenarlıkların ayrı özellikleri vardır; bu sayede her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen hücre kenar kontrolünün mantıksal bir sonucudur.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem, görüntü ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillmode/) (stretch/tile) seçimine bağlıdır. Genişletme (stretch) durumunda, görüntü yeni hücreye uyacak şekilde ayarlanır; döşeme (tile) durumunda ise döşemeler yeniden hesaplanır. Makalede bir hücredeki görüntü görüntüleme modlarından bahsedilmiştir.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (portion) seviyesinde veya tüm tablo/shape seviyesinde ayarlanabilir. Pratikte, bağlantıyı bir bölüme ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye (yazı tipi ailesi, stil, boyut ve renk) sahip [portions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) (run)ları destekler.