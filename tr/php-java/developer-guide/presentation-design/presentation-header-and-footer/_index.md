---
title: PHP'de Sunum Üst Bilgi ve Alt Bilgileri Yönetme
linktitle: Üst Bilgi ve Alt Bilgi
type: docs
weight: 140
url: /tr/php-java/presentation-header-and-footer/
keywords:
- üst bilgi
- üst bilgi metni
- alt bilgi
- alt bilgi metni
- üst bilgi ayarla
- alt bilgi ayarla
- dağıtım
- notlar
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slaytlarda, not sayfalarında ve dağıtımlarda alt bilgi, tarih-saat, slayt numarası ve üst bilgi tutamacılarını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne bağlı olarak farklı üst bilgi ve alt bilgi tutamacı (placeholder) kullanır. Aspose.Slides for PHP via Java, bu tutamacıların metnini ve görünürlüğünü üst bilgi/alt bilgi yöneticisi sınıfları aracılığıyla kontrol etmenizi sağlar.

| Kapsam | Üst Bilgi | Alt Bilgi | Tarih/Zaman | Slayt/Sayfa Numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana taslağı | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| Dağıtım ana taslağı | Evet | Evet | Evet | Evet |

Normal bir sunum slaytının üst bilgi tutamacı yoktur. Üst bilgiler not sayfalarında ve dağıtımlarda bulunur. Normal slaytlar için alt bilgi, tarih/zaman ve slayt numarası tutamacı kullanılmalıdır.

Bir değişikliğin kapsamı kullandığınız yöneticisine bağlıdır. [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideheaderfootermanager/) sınıfı tek bir normal slaytı kontrol eder. [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslideheaderfootermanager/) sınıfı tek bir not slaytını kontrol eder. Ana taslak ve düzen yöneticileri ayarları bağımlı slaytlara da yayabilir, [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) sınıfı ise dağıtım ana taslağını kontrol eder.

## **Normal Slaytlarda Alt Bilgi, Tarih/Zaman ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın üst bilgi/alt bilgi yöneticisine erişmek, alt bilgi ve tarih/zaman metnini ayarlamak, gerekli tutamacı etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından oluşturulur, bu yüzden yalnızca görünürlüklerini kontrol etmeniz yeterlidir.

[`setFooterText`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) ve [`setDateTimeText`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) ile metin ayarlayın, [`setFooterVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) ve [`setSlideNumberVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) ile ilgili tutamacı gösterin.

Aşağıdaki uçtan uca örnek, aynı alt bilgi, tarih/zaman metni ve slayt numarası görünürlüğünü tüm normal slaytlara uygular:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Yalnızca bir slaytı güncellemeniz gerekiyorsa, tüm koleksiyonu döngüyle gezmek yerine [`getSlides`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getslides/) yöntemini kullanarak o slayta doğrudan erişin.

## **Notlar Ana Taslağında Üst Bilgi ve Alt Bilgi Ayarlama**

Notlar ana taslağı, not sayfaları için ortak biçimlendirme ve tutamacı davranışlarını tanımlar. Sadece notlar ana taslağını değiştirmek istediğinizde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/) sınıfını kullanın.

Aşağıdaki örnek, notlar ana taslağında üst bilgi, alt bilgi ve tarih/zaman metnini ayarlar ve o ana taslaktaki tüm desteklenen tutamacı görünür hâle getirir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) yöntemi, sunumda bir notlar ana taslağı bulunmadığında `null` döndürür.

## **Notlar Ana Taslağı Ayarlarını Çocuk Not Slaytlarına Uygulama**

Bir notlar ana taslağı, üst bilgi ve alt bilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Aynı ayarların notlar hiyerarşisi boyunca uygulanması gerektiğinde [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) ve [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) notlar ana taslağı üst bilgisini ve tüm çocuk üst bilgilerini günceller. Alt bilgiler, tarih/zaman ve slayt numaraları için eşdeğer yöntemler mevcuttur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Yukarıda kullanılan yayma yöntemleri şunlardır: [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), ve [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Bireysel Not Slaytında Üst Bilgi ve Alt Bilgi Ayarlama**

Bir not slaytı, belirli bir normal slayta aittir. Sadece o not sayfasını özelleştirmek istediğinizde [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslideheaderfootermanager/) sınıfını kullanın.

[`addNotesSlide`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslidemanager/addnotesslide/) yöntemi, geçerli slayt için not slaytını döndürür ve henüz mevcut değilse bir tane oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Önce notlar ana taslağından ayarları yayar, ardından bireysel bir not slaytını değiştirirseniz, sonraki slayt‑başına‑başına ayarlar o not sayfasını bağımsız olarak özelleştirmenizi sağlar.

## **Dağıtım Ana Taslağında Üst Bilgi ve Alt Bilgi Ayarlama**

Dağıtım sayfaları, üst bilgi, alt bilgi, tarih/zaman ve sayfa numarası tutamacı için dağıtım ana taslağını kullanır. Not sayfalarından farklı olarak, dağıtım ayarları bireysel dağıtım slaytları yerine dağıtım ana taslağı üzerinden yönetilir.

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) yöntemi ile dağıtım ana taslağına erişin. Mevcut değilse, varsayılan dağıtım ana taslağını oluşturmak için [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) metodunu çağırın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kapsam ve Kalıtımı Anlamak**

Değiştirmek istediğiniz kapsamla eşleşen üst bilgi/alt bilgi yöneticisini seçin:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideheaderfootermanager/) bir normal slayt için alt bilgi, tarih/zaman ve slayt numarası ayarlarını değiştirir.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslideheaderfootermanager/) bir normal slayt ana taslağını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslideheaderfootermanager/) notlar ana taslağını kontrol eder ve tüm bağımlı not slaytlarına ayarları yayabilir.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslideheaderfootermanager/) bir not slaytını değiştirir ve üst bilgi tutamacını, alt bilgi, tarih/zaman ve slayt numarasını destekler.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) dağıtım ana taslağını değiştirir ve dört tutamacı da destekler.

Aynı ayarın hiyerarşinin tamamında uygulanması gerektiğinde bir ana taslak veya düzen üzerinden yayma kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta üst bilgi ekleyebilir miyim?**

Hayır. PowerPoint, normal slaytlar için bir üst bilgi tutamacı tanımlamaz. Normal slaytlarda alt bilgi, tarih/zaman ve slayt‑numarası tutamacı kullanılmalıdır. Üst bilgi tutamacı not sayfalarında ve dağıtımlarda mevcuttur.

**Bir alt bilgi, tarih/zaman veya slayt‑numarası tutamacı görünür değilse ne yapmalıyım?**

İlgili üst bilgi/alt bilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`isFooterVisible`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) bir alt bilgi tutamacının mevcut olup olmadığını bildirir, [`setFooterVisibility`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ise görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 yerine farklı bir değerden başlatabilir miyim?**

Sunumun [`setFirstSlideNumber`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/setfirstslidenumber/) metodunu çağırın. Slayt‑numarası tutamacı daha sonra güncellenen numaralandırma sırasını kullanır.

**PDF, görüntüler veya HTML olarak dışa aktarırken üst bilgi ve alt bilgi ne olur?**

Görünür üst bilgi ve alt bilgi öğeleri, çıktının formatında sunum içeriğiyle birlikte işlenir. Görünüm, dışa aktarılan sayfa tipine ve ilgili tutamacı görünürlük ayarlarına bağlıdır.