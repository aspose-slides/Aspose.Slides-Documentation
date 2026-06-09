---
title: PHP'de Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/php-java/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides ile sunumlar oluşturun — PPT, PPTX ve ODP dosyaları üretin ve güvenilir sonuçlar için programatik olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir sunum oluşturmayı, slayta basit içerik eklemeyi ve sonucu bir dosya olarak kaydetmeyi gösterir. Ayrıca yeni bir sunumu oluşturup kaydetmeyi, desteklenen bir formatta mevcut bir sunumu açmayı ve başka bir formata kaydetmeyi de gösterir. Ek olarak, makale formatlar, şablonlar, slayt boyutlandırma, birimler, bellek kullanımı, çok iş parçacığı, lisanslama, dijital imzalar ve VBA desteği ile ilgili sık sorulan soruları içeren kısa bir SSS bölümü sunar.

## **Sunum Oluşturma**

Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını, indeksini kullanarak alın.  
1. Shapes nesnesi tarafından sunulan addAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, sunumun ilk slaydına bir çizgi ekledik.

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $slide = $pres->getSlides()->get_Item(0);
    # Çizgi tipinde bir autoshape ekle
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

Şu formatlarda kaydedebilirsiniz: [PPTX, PPT, and ODP](/slides/tr/php-java/save-presentation/), ve [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/), [SVG](/slides/tr/php-java/convert-powerpoint-to-png/), ve [images](/slides/tr/php-java/convert-powerpoint-to-png/) gibi diğer seçenekler de bulunmaktadır.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [are supported](/slides/tr/php-java/supported-file-formats/).

**Sunum oluştururken slayt boyutunu/enzan oranını nasıl kontrol ederim?**

[slide size](/slides/tr/php-java/slide-size/) (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar dahil) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerde ölçülür?**

Puan (point) cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok sayıda medya dosyası içeren büyük sunumları nasıl yönetirim?**

[BLOB management strategies](/slides/tr/php-java/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup/kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği üzerinde [multiple threads](/slides/tr/php-java/multithreading/) ile çalışamazsınız. Her iş parçacığı veya süreç için ayrı, izole edilmiş örnekler çalıştırın.

**Deneme filigranını ve sınırlamaları nasıl kaldırırım?**

[Apply a license](/slides/tr/php-java/licensing/) bir süreçte bir kez uygulanmalıdır. Lisans XML'i değiştirilmemeli ve birden fazla iş parçacığı kullanılıyorsa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [Digital signatures](/slides/tr/php-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [create/edit VBA projects](/slides/tr/php-java/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.