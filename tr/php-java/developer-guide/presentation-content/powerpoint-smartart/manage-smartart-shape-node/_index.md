---
title: PHP Kullanarak Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/php-java/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüm erişimi
- düğüm kaldırma
- özel konum
- asistan düğümü
- dolgu formatı
- düğüm renderlama
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı optimize etmek için net kod örnekleri ve ipuçları alın."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikleri, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyebilir, alt düğümleri belirli bir konuma ekleyebilir, mevcut düğümlere erişebilir ve metinlerini, seviyelerini ve konumlarını okuyabilirsiniz.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümleri nasıl kaldıracağınızı, alt düğümlerle indeks veya konuma göre nasıl çalışılacağını, asistan düğümünü normal düğüme nasıl dönüştüreceğinizi, SmartArt düğüm şekillerinin konum, boyut ve dönüşünü nasıl ayarlayacağınızı, düğüm dolgu formatlarını nasıl ayarlayacağınızı ve bir SmartArt alt düğümü için küçük resim görüntüsü nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekleme**
Aspose.Slides for PHP via Java, SmartArt şekillerini en kolay şekilde yönetmek için en basit API'yi sağlamıştır. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olacaktır.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. SmartArt şeklinin [**NodeCollection**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/#getAllNodes) içinde yeni bir [Node](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnodecollection/#addNode) ekleyin ve metni TextFrame'e ayarlayın.
1. Şimdi, yeni eklenen [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) düğümüne bir [**Child Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getChildNodes) ekleyin ve metni TextFrame'e ayarlayın.
1. Sunumu kaydedin.

```php
  # İstenen sunumu yükle
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # İlk slayttaki her şekli dolaş
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        # Yeni bir SmartArt Düğümü ekleme
        $TemNode = $smart->getAllNodes()->addNode();
        # Metin ekleme
        $TemNode->getTextFrame()->setText("Test");
        # Üst düğümde yeni bir alt düğüm ekleme. Koleksiyonun sonuna eklenecek
        $newNode = $TemNode->getChildNodes()->addNode();
        # Metin ekleme
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Sunumu kaydetme
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belirli Bir Konumda SmartArt Düğümü Ekleme**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceği açıklanmıştır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. Erişilen slayta bir [**StackedList**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtLayoutType#StackedList) türünde [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) şekli ekleyin.
1. Eklenen SmartArt şeklinin ilk düğümüne erişin.
1. Seçilen [**Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtNode) için konum 2'de bir [**Child Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getChildNodes) ekleyin ve metnini ayarlayın.
1. Sunumu kaydedin.

```php
  # Sunum örneği oluşturma
  $pres = new Presentation();
  try {
    # Sunum slaytına erişme
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape ekleme
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # SmartArt düğümüne indeks 0'da erişme
    $node = $smart->getAllNodes()->get_Item(0);
    # Üst düğümde konum 2'de yeni alt düğüm ekleme
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Metin ekle
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Sunumu kaydet
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen SmartArt'ın LayoutType'ının yalnızca okunabilir olduğunu ve yalnızca SmartArt şekli eklenirken ayarlandığını unutmayın.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. SmartArt Shape içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt#getAllNodes--) dolaşın.
1. SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```php
  # Sunum Sınıfını Oluştur
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # İlk slaytı al
    $slide = $pres->getSlides()->get_Item(0);
    # İlk slayttaki her şekli dolaş
    foreach($slide->getShapes() as $shape) {
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        # SmartArt içindeki tüm düğümleri dolaş
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # i indeksindeki SmartArt düğümüne erişme
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt düğüm parametrelerini yazdırma
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olacaktır.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. SmartArt Shape içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt#getAllNodes--) dolaşın.
1. Seçilen her SmartArt şekli [**Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtNode) için belirli düğüm içindeki tüm [**Child Nodes**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtNode#getChildNodes--) dolaşın.
1. [**Child Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getChildNodes) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```php
  # Sunum Sınıfını Örnekle
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # İlk slaytı al
    $slide = $pres->getSlides()->get_Item(0);
    # İlk slayttaki her şekli dolaş
    foreach($slide->getShapes() as $shape) {
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        # SmartArt içindeki tüm düğümleri dolaş
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # i indeksindeki SmartArt düğümüne erişme
          $node0 = $smart->getAllNodes()->get_Item($i);
          # i indeksindeki SmartArt düğümündeki alt düğümleri dolaş
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArt düğümündeki alt düğüme erişme
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt alt düğüm parametrelerini yazdırma
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belirli Bir Konumda SmartArt Alt Düğümüne Erişme**
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceğini öğreneceğiz.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. Bir [**StackedList**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtLayoutType#StackedList) türünde SmartArt şekli ekleyin.
1. Eklenen SmartArt şekline erişin.
1. Erişilen SmartArt şekli için indeks 0'daki düğüme erişin.
1. Şimdi, erişilen SmartArt düğümündeki [**Child Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getChildNodes) konumu 1'deki alt düğüme **get_Item()** yöntemiyle erişin.
1. [**Child Node**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getChildNodes) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```php
  # Sunumu örnekle
  $pres = new Presentation();
  try {
    # İlk slayta erişme
    $slide = $pres->getSlides()->get_Item(0);
    # İlk slayta SmartArt şekli ekleme
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # İndeks 0'da SmartArt düğümüne erişme
    $node = $smart->getAllNodes()->get_Item(0);
    # Üst düğümde konum 1'de alt düğüme erişme
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt alt düğüm parametrelerini yazdırma
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağını öğreneceğiz.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) içinde 0'dan fazla düğüm olup olmadığını kontrol edin.
1. Silinecek SmartArt düğümünü seçin.
1. Şimdi, seçilen düğümü [**removeNode**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnodecollection/#removeNode) yöntemiyle kaldırın.
1. Sunumu kaydedin.

```php
  # İstenen sunumu yükle
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # İlk slayttaki her şekli dolaş
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # İndeks 0'da SmartArt düğümüne erişme
          $node = $smart->getAllNodes()->get_Item(0);
          # Seçilen düğümü kaldırma
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Sunumu kaydet
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belirli Bir Konumda SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içinde belirli bir konumda bulunan düğümlerin nasıl kaldırılacağını öğreneceğiz.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ilk slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. İndeks 0'da bulunan SmartArt şekli düğümünü seçin.
1. Şimdi, seçilen SmartArt düğümünün 2'den fazla alt düğümü olup olmadığını kontrol edin.
1. Şimdi, **Position 1** konumundaki düğümü [**removeNode**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnodecollection/#removeNode) yöntemiyle kaldırın.
1. Sunumu kaydedin.

```php
  # İstenen sunumu yükle
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # İlk slayttaki her şekli dolaş
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # İndeks 0'da SmartArt düğümüne erişme
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Konum 1'deki alt düğümü kaldırma
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Sunumu kaydet
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt Nesnesindeki Alt Düğüm İçin Özel Konum Ayarlama**
Aspose.Slides for PHP via Java, [SmartArtShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setX) ve [Y](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setY) özelliklerini ayarlamayı destekler. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve dönüşünün nasıl ayarlanacağını gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarını yeniden hesapladığını lütfen unutmayın. Özel konum ayarlarıyla kullanıcı, düğümleri gereksinimlerine göre ayarlayabilir.

```php
  # Sunum Sınıfını Örnekle
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt şekli yeni konuma taşı
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt şeklinin genişliklerini değiştir
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt şeklinin yüksekliğini değiştir
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt şeklinin dönüşünü değiştir
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Bir Asistan Düğümünü Kontrol Etme**
{{% alert color="primary" %}} 

Bu makalede, Aspose.Slides for PHP via Java kullanarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha ayrıntılı inceleyeceğiz.

{{% /alert %}} 

Aşağıdaki bölümlerde inceleme yapacağımız kaynak SmartArt şekli:

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slayttaki Kaynak SmartArt Şekli**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki **Assistant Nodes** (Asistan Düğümleri) nasıl tanımlanır ve nasıl değiştirilir incelenecektir.

1. SmartArt Shape içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak ikinci slaytın referansını alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) tipine dönüştürün.
1. SmartArt şekli içindeki tüm düğümleri dolaşın ve [**Assistant Nodes**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtNode#isAssistant--) olup olmadığını kontrol edin.
1. Asistan Düğümünün durumunu normal düğüm olarak değiştirin.
1. Sunumu kaydedin.

```php
  # Sunum örneği oluşturma
  $pres = new Presentation("AddNodes.pptx");
  try {
    # İlk slayttaki her şekli dolaş
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Şeklin SmartArt tipi olup olmadığını kontrol et
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArt tipine dönüştür
        $smart = $shape;
        # SmartArt şeklinin tüm düğümlerini dolaş
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Düğümün Asistan düğümü olup olmadığını kontrol et
          if ($node->isAssistant()) {
            # Asistan düğümünü false yap ve normal düğüm olarak ayarla
            $node->isAssistant();
          }
        }
      }
    }
    # Sunumu kaydet
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Şekil: Slayttaki SmartArt Şekli İçinde Asistan Düğümleri Değiştirildi**|

## **Bir Düğümün Dolgu Formatını Ayarlama**
Aspose.Slides for PHP via Java, özel SmartArt şekilleri eklemeyi ve dolgu formatlarını ayarlamayı mümkün kılar. Bu makale, SmartArt şekillerinin nasıl oluşturulup erişileceğini ve dolgu formatlarının nasıl ayarlanacağını açıklamaktadır.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaytın referansını alın.
1. [**LayoutType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayarak bir [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) şekli ekleyin.
1. SmartArt şekli düğümleri için [**Fill Format**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getFillFormat) ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```php
  # Sunumu örnekle
  $pres = new Presentation();
  try {
    # Slayta erişme
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt şekli ve düğümler ekleme
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Düğüm dolgu rengini ayarlama
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Sunumu kaydet
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir SmartArt Alt Düğümünün Küçük Resmini Oluşturma**
Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt alt düğümünün küçük resmini oluşturabilir:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [SmartArt Ekle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnodecollection/#addNode).
1. İndeksini kullanarak bir düğümün referansını alın.
1. Küçük resim görüntüsünü alın.
1. Küçük resmi istediğiniz herhangi bir görüntü formatında kaydedin.

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # SmartArt ekle
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Bir düğümün referansını indeks kullanarak al
    $node = $smart->getNodes()->get_Item(1);
    # Küçük resmi al
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Küçük resmi kaydet
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt, normal bir şekil gibi ele alındığından, [standart animasyonları](/slides/tr/php-java/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerekirse SmartArt düğümleri içindeki şekilleri de animasyonlayabilirsiniz.

**Bir slaytta belirli bir SmartArt nesnesini, iç kimliği bilinmiyorsa nasıl güvenilir şekilde bulabilirim?**

[Alternatif metin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getalternativetext/) atayarak ve bu metni arayarak bulun. SmartArt üzerine ayarladığınız belirgin AltText, iç kimliklere bakmadan programlı olarak bulmanızı sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunur mu?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/php-java/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla render eder; düzen, renk ve efektler korunur.

**Tüm SmartArt'ın bir görüntüsünü (ön izleme veya raporlar için) çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarda](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) veya [SVG](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) olarak render edilebilir; bu sayede küçük resimler, raporlar veya web kullanımı için uygundur.