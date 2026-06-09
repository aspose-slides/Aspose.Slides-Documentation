---
title: Java'da Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programatik olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir sunum nasıl oluşturulur, bir slayta basit içerik nasıl eklenir ve sonuç nasıl dosya olarak kaydedilir gösterir. Ayrıca yeni bir sunumun nasıl oluşturulup kaydedileceğini, desteklenen bir formatta mevcut bir sunumun nasıl açılacağını ve başka bir formata nasıl kaydedileceğini gösterir. Ek olarak, makale formatlar, şablonlar, slayt boyutlandırma, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsayan kısa bir SSS içerir.

## **Sunum Oluşturma**

Aspose.Slides for Java'da sıfırdan bir PowerPoint dosyası oluşturmak, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfını örneklemek kadar basittir. Yapıcı otomatik olarak tek bir slayt içeren boş bir sunum oluşturur ve şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu herhangi bir içerik için anında bir tuval sağlar. Bu slaytı—veya yeni slaytlar ekleyerek—değiştirdikten sonra sonucu PPTX, eski PPT veya hatta OpenDocument formatlarına kaydedebilirsiniz. Aşağıdaki kısa kod örneği, ilk slayta basit bir şekil ekleyerek bu iş akışını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slayta indeksine göre bir referans alın.
3. `Shapes` koleksiyonu tarafından sunulan `addAutoShape` metodunu kullanarak `Cloud` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnesi ekleyin.
4. Otomatik şekle metin ekleyin.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun ilk slaytına bir bulut şekli eklenir.

```java
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cloud tipinde bir otomatik şekil ekleyin.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Yeni sunum](new_presentation.png)

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

Yeni sunumu [PPTX, PPT ve ODP](/slides/tr/java/save-presentation/) formatlarında kaydedebilir, ayrıca [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/java/convert-powerpoint-to-xps/), [HTML](/slides/tr/java/convert-powerpoint-to-html/), [SVG](/slides/tr/java/convert-powerpoint-to-png/) ve [görseller](/slides/tr/java/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyip istenen formatta kaydedebilirsiniz; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/java/supported-file-formats/).

**Bir sunum oluştururken slayt boyutunu/en oranını nasıl kontrol edebilirim?**

Slayt boyutunu ([slide size](/slides/tr/java/slide-size/)) ayarlayın (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar dahil) ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerle ölçülür?**

Puan cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok sayıda medya dosyası içeren büyük sunumlarla nasıl başa çıkabilirim?**

[BLOB yönetim stratejilerini](/slides/tr/java/manage-blob/) kullanın, geçici dosyalarla bellekteki depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup/kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği üzerinde [birden çok iş parçacığından](/slides/tr/java/multithreading/) çalışamazsınız. Her iş parçacığı veya süreç için ayrı, izole edilmiş örnekler çalıştırın.

**Deneme filigranını ve sınırlamaları nasıl kaldırırım?**

Her süreçte bir kez [lisans uygulayın](/slides/tr/java/licensing/). Lisans XML'i değişmeden kalmalı ve birden çok iş parçacığı söz konusuysa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturup/editleyebilir](/slides/tr/java/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.