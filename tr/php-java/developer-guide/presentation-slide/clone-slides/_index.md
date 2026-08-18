---
title: PHP'de Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/php-java/clone-slides/
keywords:
- slayt klonlama
- slayt kopyalama
- slayt kaydetme
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Saniyeler içinde PPT oluşturmayı otomatikleştirmek ve manuel çalışmayı ortadan kaldırmak için net kod örneklerimizi izleyin."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for PHP via Java, herhangi bir slaytı kopyalama veya klonlama ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma ekleme olanağı sağlar. Slayt klonlama süreci, orijinal slaytı değiştirmeden geliştiriciler tarafından değiştirilebilecek yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde Sona Klonla.
- Sunum içinde Farklı Bir Konuma Klonla.
- Başka Bir Sunumda Sona Klonla.
- Başka Bir Sunumda Farklı Bir Konuma Klonla.
- Başka Bir Sunumda Belirli Bir Konuma Klonla.

Aspose.Slides for PHP via Java’da, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından sağlanan (bir [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Slide) nesnesi koleksiyonu) [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) ve [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) yöntemlerini sunar ve bu yöntemlerle yukarıdaki slayt klonlama türleri gerçekleştirilir.

## **Bir Sunumun Sonuna Slayt Klonla**
Bir slaytı klonlamak ve ardından aynı sunum dosyasında mevcut slaytların sonuna eklemek istiyorsanız, aşağıdaki adımlara göre [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan slayt koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesini alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini çağırın ve klonlanacak slaytı parametre olarak geçin.
1. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun ilk konumunda (sıfır indeks) bulunan bir slaytı sunumun sonuna klonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Değiştirilmiş sunumu diske yaz
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Bir Sunum İçinde Başka Bir Konuma Slayt Klonla**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir konuma eklemek istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan **[Slides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides)** koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection) nesnesini alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesi tarafından sağlanan [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) yöntemini çağırın ve klonlanacak slaytı yeni konumun indeks’i ile birlikte parametre olarak geçin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun sıfır indeksindeki (konum 1) bir slaytı indeks 1 – Konum 2 – ye klonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    $slds = $pres->getSlides();
    # İstenen slaytı aynı sunumdaki belirtilen indekse klonla
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Değiştirilmiş sunumu diske yaz
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Başka Bir Sunumun Sonuna Slayt Klonla**
Bir slaytı bir sunumdan alıp başka bir sunum dosyasının mevcut slaytlarının sonuna eklemeniz gerektiğinde:

1. Slaytı klonlanacak kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan **[Slides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides)** koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection) nesnesini alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini çağırın ve kaynak sunumdan slaytı parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı hedef sunumun sonuna klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Slaytın klonlanacağı hedef PPTX için Presentation sınıfını örnekle
    $destPres = new Presentation();
    try {
      # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonla
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Hedef sunumu diske kaydet
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Başka Bir Sunumda Başka Bir Konuma Slayt Klonla**
Bir slaytı bir sunumdan alıp başka bir sunum dosyasında belirli bir konuma eklemeniz gerektiğinde:

1. Slaytı klonlanacak kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) sınıfını alın.
1. [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesi tarafından sağlanan [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) yöntemini çağırın ve kaynak sunumdan slaytı istediğiniz konumla birlikte parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun indeks 1 (konum 2) konumuna klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Slaytın klonlanacağı hedef PPTX için Presentation sınıfını örnekle
    $destPres = new Presentation();
    try {
      # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonla
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Hedef sunumu diske kaydet
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Başka Bir Sunumda Belirli Bir Konuma Slayt Klonla**
Bir sunumdan ana slaytı olan bir slaytı başka bir sunuma klonlamanız gerektiğinde, önce kaynak sunumdan hedef sunuma istediğiniz ana slaytı klonlamalısınız. Ardından bu ana slaytı, ana slaytı olan slaytı klonlamak için kullanmalısınız. [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) yöntemi, kaynak sunumdan değil, hedef sunumdan bir ana slayt bekler. Ana slaytı klonlamak için aşağıdaki adımları izleyin:

1. Slaytı klonlanacak kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Slaytı klonlayacağınız hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği oluşturun.
1. Klonlanacak slayta ve ona ait ana slayta erişin.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan Masters koleksiyonuna başvurarak [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterSlideCollection) sınıfını örnekleyin.
1. [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterSlideCollection) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini çağırın ve kaynak PPTX’ten klonlanacak ana slaytı parametre olarak geçin.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından açığa çıkarılan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) sınıfını örnekleyin.
1. [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSlides) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini çağırın ve kaynak sunumdan klonlanacak slaytı ve ana slaytı parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı ve ana slaytı hedef sunumun sonuna, kaynak slayttan alınan bir ana slaytı kullanarak klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Slaytın klonlanacağı hedef sunum için Presentation sınıfını örnekle
    $destPres = new Presentation();
    try {
      # Kaynak sunumdaki slayt koleksiyonundan ISlide'ı ve
      # Ana slaytı oluştur
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kaynak sunumdan istenen ana slaytı hedef sunumdaki ana slayt koleksiyonuna klonla
      # Hedef sunum
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kaynak sunumdan istenen ana slaytı hedef sunumdaki ana slayt koleksiyonuna klonla
      # Hedef sunum
      $iSlide = $masters->addClone($SourceMaster);
      # Kaynak sunumdan istenen slaytı istenen ana slayt ile hedef sunumdaki slayt koleksiyonunun sonuna klonla
      # Hedef sunumdaki slayt koleksiyonunun sonuna
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Hedef sunumu diske kaydet
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Belirli Bir Bölümün Sonuna Slayt Klonla**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir bölüme eklemek istiyorsanız, [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection) sınıfı tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) yöntemini kullanın. Aspose.Slides for PHP via Java, bir slaytı ilk bölümden klonlayıp aynı sunumun ikinci bölümüne eklemenizi sağlar.

Aşağıdaki kod örneği, bir slaytı klonlayıp klonlanmış slaytı belirtilen bir bölüme nasıl ekleyeceğinizi gösterir.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Hedef sunumu diske kaydet
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Eşleşen Slayt Boyutunu Sağlayın**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Slayt boyutları farklıysa, Aspose.Slides klonlanan şekilleri otomatik olarak yeniden ölçeklendirmez—orijinal koordinat ve boyutları korunur; bu da içeriğin kayması veya slayt sınırlarının dışına taşmasına neden olabilir.

Ana slaytı ve slaytı klonlamadan önce hedef sunumun slayt boyutunu kaynakla eşleştirebilirsiniz:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Bunu ana slaytı ve slaytı klonlamadan önce yapın.

## **SSS**

**Konuşmacı notları ve inceleme yorumları da klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. Eğer istemiyorsanız, ekledikten sonra [kaldırın](/slides/tr/php-java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik harici bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/php-java/manage-ole/) olarak korunur. Dosyalar arasında taşıdıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klona ekleme konumu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüm](/slides/tr/php-java/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm mevcut değilse, önce bölümü oluşturun ve ardından slaytı ona taşıyın.