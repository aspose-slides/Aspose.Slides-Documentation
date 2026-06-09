---
title: JavaScript ile Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides ile bir sunum oluşturmayı, bir slayta basit içerik eklemeyi ve sonucu bir dosya olarak kaydetmeyi göstermektedir.

## **PowerPoint Sunumu Oluşturma**

Sunumdaki seçilen bir slayta basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını, indeksini kullanarak alın.
3. Shapes nesnesinin sunduğu addAutoShape yöntemiyle Line tipinde bir AutoShape ekleyin.
4. Değiştirilen sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alın
    var slide = pres.getSlides().get_Item(0);
    // Çizgi tipinde bir autoshape ekleyin
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

Sunumu [PPTX, PPT ve ODP](/slides/tr/nodejs-java/save-presentation/) formatlarında kaydedebilir ve [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [görseller](/slides/tr/nodejs-java/convert-powerpoint-to-png/) gibi formatlara dışa aktarabilirsiniz.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyin ve istenen formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/nodejs-java/supported-file-formats/).

**Sunum oluştururken slayt boyutunu/en boy oranını nasıl kontrol ederim?**

[Slayt boyutunu](/slides/tr/nodejs-java/slide-size/) ayarlayın (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar dahil) ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerde ölçülür?**

Puan (point) cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok büyük (birçok medya dosyası içeren) sunumları nasıl yönetebilirim?**

[BLOB yönetim stratejilerini](/slides/tr/nodejs-java/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturabilir/kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği üzerinde [birden fazla iş parçacığından](/slides/tr/nodejs-java/multithreading/) işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı ve izole örnekler çalıştırın.

**Deneme filigranı ve sınırlamaları nasıl kaldırırım?**

İşlem başına bir kez [lisans uygulayın](/slides/tr/nodejs-java/licensing/). Lisans XML'i değiştirilmemeli ve birden fazla iş parçacığı varsa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/nodejs-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturup/düzenleyebilir](/slides/tr/nodejs-java/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.