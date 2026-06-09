---
title: PHP'de Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/php-java/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile PowerPoint slaytlarını hızlıca çoğaltın. Saniyeler içinde PPT oluşturmayı otomatikleştirmek ve manuel işi ortadan kaldırmak için net kod örneklerimizi izleyin."
---
## **Giriş**

Cloning bir şeyin tam kopyasını veya replikasını oluşturma işlemidir. Aspose.Slides for PHP via Java ayrıca herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma eklemeyi mümkün kılar. Slayt klonlama süreci, geliştiricilerin orijinal slaytı değiştirmeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sona kopyala.
- Sunum içinde başka bir konuma kopyala.
- Başka bir sunumda sona kopyala.
- Başka bir sunumda başka bir konuma kopyala.
- Başka bir sunumda belirli bir konuma kopyala.

Aspose.Slides for PHP via Java'da, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) nesnesi tarafından sunulan (bir [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Slide) nesnesi koleksiyonu) [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) ve [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) metodlarını sağlayarak yukarıdaki slayt klonlama türlerini gerçekleştirir.

## **Bir Sunumun Sonunda Slaytı Klonla**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) method according to the steps listed below:

1. [Presentation] sınıfının bir örneğini oluşturun.
1. [Presentation] nesnesi tarafından sunulan slayt koleksiyonuna başvurarak [SlideCollection] nesnesini alın.
1. [SlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve klonlanacak slaytı [addClone] metoduna parametre olarak geçirin.
1. Değiştirilmiş sunum dosyasını kaydedin.

Aşağıda verilen örnekte, bir slaytı (sunumun ilk konumunda – sıfır indeks – bulunan) sunumun sonuna klonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Değiştirilmiş sunumu diske kaydedin
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Bir Sunum içinde Başka Bir Konuma Slaytı Klonla**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#insertClone) method:

1. [Presentation] sınıfının bir örneğini oluşturun.
1. [Presentation] nesnesi tarafından sunulan [**Slides**] koleksiyonuna başvurarak [SlideCollection] nesnesini alın.
1. [insertClone] metodunu çağırın ve klonlanacak slaytı yeni konum için indeksle birlikte [insertClone] metoduna parametre olarak geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, bir slaytı (sunumun sıfır indeksinde – konum 1 – bulunan) indeks 1 – Konum 2 – üzerine klonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    $slds = $pres->getSlides();
    # İstenen slaytı aynı sunumdaki belirtilen indekse klonlayın
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Değiştirilmiş sunumu diske kaydedin
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Başka Bir Sunumun Sonunda Slaytı Klonla**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. [Presentation] sınıfının bir örneğini oluşturun; bu sınıf slaytın klonlanacağı sunumu içerir.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan [**Slides**] koleksiyonuna başvurarak [SlideCollection] nesnesini alın.
1. [addClone] metodunu çağırın ve kaynak sunumdan slaytı [addClone] metoduna parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıda verilen örnekte, bir slaytı (kaynak sunumun ilk indeksinden) hedef sunumun sonuna klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    $destPres = new Presentation();
    try {
      # Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Hedef sunumu diske kaydedin
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Başka Bir Sunumda Başka Bir Konuma Slaytı Klonla**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Kaynak sunumu içeren ve slaytın klonlanacağı [Presentation] sınıfının bir örneğini oluşturun.
1. Slaytın ekleneceği sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection] sınıfını alın.
1. [insertClone] metodunu çağırın ve kaynak sunumdan slaytı istediğiniz konumla birlikte [insertClone] metoduna parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıda verilen örnekte, bir slaytı (kaynak sunumun sıfır indeksinden) hedef sunumun 1. indeksine (konum 2) klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    $destPres = new Presentation();
    try {
      # Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Hedef sunumu diske kaydedin
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Başka Bir Sunumda Belirli Bir Konuma Slaytı Klonla**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Kaynak sunumu içeren ve slaytın klonlanacağı [Presentation] sınıfının bir örneğini oluşturun.
1. Hedef sunumu içeren ve slaytın klonlanacağı [Presentation] sınıfının bir örneğini oluşturun.
1. Klonlanacak slayta ve onun master slaytına erişin.
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan Masters koleksiyonuna başvurarak [MasterSlideCollection] sınıfını örnekleyin.
1. [MasterSlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve kaynak PPTX'ten klonlanacak master'ı [addClone] metoduna parametre olarak geçirin.
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection] sınıfını örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve kaynak sunumdan slaytı ve master slaytı [addClone] metoduna parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıda verilen örnekte, bir slaytı (kaynak sunumun sıfır indeksinde bulunan) bir master ile birlikte hedef sunumun sonuna, kaynak slayttan alınan bir master kullanarak klonladık.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    $destPres = new Presentation();
    try {
      # Kaynak sunumdaki slayt koleksiyonundan ISlide'ı ve
      # Master slaytı
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # İstenen master slaytı kaynak sunumdan hedef sunumdaki master koleksiyonuna klonlayın
      # Hedef sunuma
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # İstenen master slaytı kaynak sunumdan hedef sunumdaki master koleksiyonuna klonlayın
      # Hedef sunuma
      $iSlide = $masters->addClone($SourceMaster);
      # İstenen master ile kaynak sunumdaki istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Hedef sunumu diske kaydedin
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Belirli Bir Bölümün Sonunda Slaytı Klonla**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection/#addClone) method exposed by the [SlideCollection] class. Aspose.Slides for PHP via Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Hedef sunumu diske kaydedin
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **SSS**

**Konuşmacı notları ve inceleme yorumları klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. Eğer istemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/php-java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve gömülü veriler kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE object](/slides/tr/php-java/manage-ole/) olarak korunur. Dosyalar arasında taşıma sonrası veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [section](/slides/tr/php-java/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm mevcut değilse, önce onu oluşturun ve ardından slaytı ona taşıyın.