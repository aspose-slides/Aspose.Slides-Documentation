---
title: Android'de Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da sunum oluşturun- PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta bir sunum oluşturmayı, bir slayta basit içerik eklemeyi ve sonucu dosya olarak kaydetmeyi gösterir. Ayrıca yeni bir sunum oluşturup kaydetmeyi, desteklenen bir biçimde mevcut bir sunumu açmayı ve başka bir biçime kaydetmeyi de gösterir.

## **PowerPoint Sunumu Oluşturma**
Sunumun seçilen bir slaydına basit bir düz çizgi eklemek için lütfen aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını, indeksini kullanarak edinin.
1. Shapes nesnesi tarafından sunulan addAutoShape yöntemiyle Line türünde bir AutoShape ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaydına bir çizgi ekledik.

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide slide = pres.getSlides().get_Item(0);

    // Çizgi tipinde bir autoshape ekleyin
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Yeni bir sunumu hangi biçimlerde kaydedebilirim?**

Şu biçimlerde kaydedebilirsiniz: [PPTX, PPT ve ODP](/slides/tr/androidjava/save-presentation/), ve şu biçimlere dışa aktarabilirsiniz: [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/tr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/), [SVG](/slides/tr/androidjava/convert-powerpoint-to-png/), ve [görseller](/slides/tr/androidjava/convert-powerpoint-to-png/), vb.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyip istediğiniz biçime kaydedebilirsiniz; POTX/POTM/PPTM ve benzeri biçimler [desteklenir](/slides/tr/androidjava/supported-file-formats/).

**Bir sunum oluştururken slayt boyutunu/en oranını nasıl kontrol ederim?**

[slayt boyutunu](/slides/tr/androidjava/slide-size/) ayarlayın (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar dahil) ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerde ölçülür?**

Puan (point) cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok sayıda medya dosyası içeren büyük sunumları nasıl yönetirim?**

[BLOB yönetim stratejilerini](/slides/tr/androidjava/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturabilir/kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği üzerinde [birden çok iş parçacığından](/slides/tr/androidjava/multithreading/) işlem yapamazsınız. İş parçacığı veya süreç başına ayrı, izole örnekler çalıştırın.

**Deneme filigranı ve sınırlamaları nasıl kaldırırım?**

Süreç başına bir kez [lisans uygulayın](/slides/tr/androidjava/licensing/). Lisans XML'i değiştirilmemiş olmalı ve birden çok iş parçacığı söz konusuysa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/androidjava/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturup/düzenleyebilir](/slides/tr/androidjava/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.