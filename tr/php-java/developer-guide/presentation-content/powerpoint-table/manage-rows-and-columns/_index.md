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
- satırı çoğalt
- sütunu çoğalt
- satırı kopyala
- sütunu kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirmesi
- sütun metin biçimlendirmesi
- tablo stili
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint'te tablo satırlarını ve sütunlarını yönetin ve sunum düzenleme ile veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumunda bir tablonun satırlarını ve sütunlarını yönetebilmeniz için Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) sınıfını ve birçok diğer türü sağlar.

## **İlk Satırı Başlık Olarak Ayarlama**

1. Sunum sınıfının bir örneğini oluşturun ve sunumu yükleyin.  
2. Slaytın referansını indeksine göre alın.  
3. Bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Table) nesnesi oluşturun ve null olarak ayarlayın.  
4. İlgili tabloyu bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleri arasında döngü yapın.  
5. Tablonun ilk satırını başlık olarak ayarlayın.  

Bu PHP kodu, bir tablonun ilk satırını başlık olarak nasıl ayarlayacağınızı gösterir:

```php
  # Presentation sınıfını örnekler
  $pres = new Presentation("table.pptx");
  try {
    # İlk slaytı erişir
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx'i başlatır
    $tbl = null;
    # Şekilleri iterasyonla dolaşır ve tabloya referans ayarlar
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Tablonun ilk satırını başlık olarak ayarlar
        $tbl->setFirstRow(true);
      }
    }
    # Sunumu diske kaydeder
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Satırını veya Sütununu Kopyala**

1. Sunum sınıfının bir örneğini oluşturun ve sunumu yükleyin,  
2. Slaytın referansını indeksine göre alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. [addTable] yöntemiyle slayta bir [Table] nesnesi ekleyin.  
6. Tablo satırını kopyalayın.  
7. Tablo sütununu kopyalayın.  
8. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu, bir PowerPoint tablosunun satırını veya sütununu nasıl kopyalayacağınızı gösterir:

```php
  # Presentation sınıfını örnekler
  $pres = new Presentation("Test.pptx");
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Slayta bir tablo şekli ekler
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Satır 1 hücre 1'e metin ekler
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Satır 1 hücre 2'ye metin ekler
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Tablonun sonunda Satır 1'i klonlar
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Satır 2 hücre 1'e metin ekler
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Satır 2 hücre 2'ye metin ekler
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Satır 2'yi tablonun 4. satırı olarak klonlar
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Sonunda ilk sütunu klonlar
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 4. sütun indeksinde 2. sütunu klonlar
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Sunumu diske kaydeder
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Tablo İçinden Satır veya Sütun Kaldırma**

1. Sunum sınıfının bir örneğini oluşturun ve sunumu yükleyin,  
2. Slaytın referansını indeksine göre alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. [addTable] yöntemiyle slayta bir [Table] nesnesi ekleyin.  
6. Tablo satırını kaldırın.  
7. Tablo sütununu kaldırın.  
8. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu, bir tablodan satır veya sütun nasıl kaldırılacağını gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Sunum sınıfının bir örneğini oluşturun ve sunumu yükleyin,  
2. Slaytın referansını indeksine göre alın.  
3. Slayttan ilgili [Table] nesnesine erişin.  
4. İlk satır hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight) yöntemini ayarlayın.  
5. İlk satır hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginright/) ayarlarını yapın.  
6. İkinci satır hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/settextverticaltype/) ayarını yapın.  
7. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu işlemi gösterir.

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # İlk satır hücrelerinin yazı tipi yüksekliğini ayarlar
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlar
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # İkinci satır hücrelerinin metin dikey tipini ayarlar
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Sunumu diske kaydeder
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Sunum sınıfının bir örneğini oluşturun ve sunumu yükleyin,  
2. Slaytın referansını indeksine göre alın.  
3. Slayttan ilgili [Table] nesnesine erişin.  
4. İlk sütun hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight) yöntemini ayarlayın.  
5. İlk sütun hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setalignment/) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginright/) ayarlarını yapın.  
6. İkinci sütun hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/settextverticaltype/) ayarını yapın.  
7. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu işlemi gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlar
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # İkinci sütun hücrelerinin metin dikey tipini ayarlar
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır, böylece bu ayrıntıları başka bir tablo ya da başka bir yerde kullanabilirsiniz. Bu PHP kodu, tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

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

## **SSS**

**Zaten oluşturulmuş bir tabloya PowerPoint temalarını/stillerini uygulayabilir miyim?**  
Evet. Tablo, slayt/yerleşim/ana tema miras alır ve bu temanın üzerine hâlâ dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Tablo satırlarını Excel gibi sıralayabilir miyim?**  
Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelerde özel renkler tutarken şeritli (banded) sütunlar elde edebilir miyim?**  
Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme tablo stilinden önce gelir.