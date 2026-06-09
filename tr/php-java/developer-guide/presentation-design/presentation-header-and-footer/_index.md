---
title: PHP'de Sunum Başlık ve Altbilgilerini Yönetme
linktitle: Başlık ve Altbilgi
type: docs
weight: 140
url: /tr/php-java/presentation-header-and-footer/
keywords:
- başlık
- başlık metni
- altbilgi
- altbilgi metni
- başlık ayarla
- altbilgi ayarla
- el ilanı
- notlar
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı kullanarak PowerPoint ve OpenDocument sunumlarına profesyonel bir görünüm kazandırmak için başlık ve altbilgileri ekleyin ve özelleştirin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında başlık ve altbilgi ayarlarını yönetmenizi sağlar. Başlıklar ve altbilgiler sunum ana şablonu düzeyinde işlenir ve API, altbilgi metnini ayarlama, altbilgi görünürlüğünü değiştirme ve ana not slaytlarındaki başlık metnini güncelleme yöntemleri sunar.

Ayrıca el ilanı ve not slaytları için başlık ve altbilgileri yönetebilirsiniz. Bu, not ana şablonu, tüm alt not slaytları veya tek bir not slaytı için başlık, altbilgi, slayt numarası ve tarih‑saat yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Bir Sunumda Başlık ve Altbilgileri Yönetme**

Belirli bir slaytın notları aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```php
  # Sunumu Yükle
  $pres = new Presentation("headerTest.pptx");
  try {
    # Altbilgi Ayarlama
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Başlığa Eriş ve Güncelle
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Sunumu Kaydet
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **El İlanı ve Not Slaytlarında Başlık ve Altbilgileri Yönetme**
Aspose.Slides for PHP via Java, El İlanı ve not slaytlarında Başlık ve Altbilgi desteği sağlar. Lütfen aşağıdaki adımları izleyin:

- Videoyu içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) yükleyin.
- Not ana şablonu ve tüm not slaytları için Başlık ve Altbilgi ayarlarını değiştirin.
- Ana not slaytındaki ve tüm alt Footer yer tutucularını görünür olarak ayarlayın.
- Ana not slaytındaki ve tüm alt Tarih ve saat yer tutucularını görünür olarak ayarlayın.
- Yalnızca ilk not slaytı için Başlık ve Altbilgi ayarlarını değiştirin.
- Not slaytı Başlık yer tutucusunu görünür yapın.
- Not slaytı Başlık yer tutucusuna metin ayarlayın.
- Not slaytı Tarih‑saat yer tutucusuna metin ayarlayın.
- Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte kod parçacığı sağlanmıştır.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Not ana slaytı ve tüm not slaytları için Başlık ve Altbilgi ayarlarını değiştir
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// master not slaytını ve tüm alt Footer yer tutucularını görünür yap
      $headerFooterManager->setFooterAndChildFootersVisibility(true);// master not slaytını ve tüm alt Header yer tutucularını görünür yap
      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// master not slaytını ve tüm alt SlideNumber yer tutucularını görünür yap
      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// master not slaytını ve tüm alt Tarih ve saat yer tutucularını görünür yap
      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// master not slaytına ve tüm alt Header yer tutucularına metin ayarla
      $headerFooterManager->setFooterAndChildFootersText("Footer text");// master not slaytına ve tüm alt Footer yer tutucularına metin ayarla
      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// master not slaytına ve tüm alt Tarih ve saat yer tutucularına metin ayarla
    }
    # İlk not slaytı için yalnızca Başlık ve Altbilgi ayarlarını değiştir
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// bu not slaytının Header yer tutucusunu görünür yap
      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// bu not slaytının Footer yer tutucusunu görünür yap
      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// bu not slaytının SlideNumber yer tutucusunu görünür yap
      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// bu not slaytının Date-time yer tutucusunu görünür yap
      $headerFooterManager->setHeaderText("New header text");// not slaytı Header yer tutucusuna metin ayarla
      $headerFooterManager->setFooterText("New footer text");// not slaytı Footer yer tutucusuna metin ayarla
      $headerFooterManager->setDateTimeText("New date and time text");// not slaytı Date-time yer tutucusuna metin ayarla
    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Düzenli slaytlara bir "header" ekleyebilir miyim?**

PowerPoint'te "Header" yalnızca notlar ve el ilanları için mevcuttur; düzenli slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides'te bu aynı sınırlamaları yansıtır: header yalnızca Notes/Handout için, slaytlarda ise Footer/DateTime/SlideNumber.

**Düzen bir altbilgi alanı içermiyorsa—görünürlüğünü "aç"abilir miyim?**

Evet. Görünürlüğü başlık/altbilgi yöneticisi aracılığıyla kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik ya da gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasını 1 dışında bir değerden nasıl başlatırım?**

Sunumun [first slide number](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/setfirstslidenumber/) özelliğini ayarlayın; ardından tüm numaralandırma yeniden hesaplanır. Örneğin, 0 veya 10'dan başlayabilir ve başlık slaytındaki numarayı gizleyebilirsiniz.

**PDF/görseller/HTML'ye dışa aktarırken başlıklar/altbilgiler ne olur?**

Başlık ve altbilgiler, sunumun normal metin öğeleri olarak işlenir. Yani, bu öğeler slaytlar/not sayfalarında görünürse, çıktı formatında da içerikle birlikte görünürler.