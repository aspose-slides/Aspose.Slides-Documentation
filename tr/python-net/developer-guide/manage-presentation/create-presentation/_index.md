---
title: Python'da Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da PowerPoint sunumları oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET ile bir sunum nasıl oluşturulur, ilk slaytına metin içeren bir şekil nasıl eklenir ve sonuç nasıl PPTX dosyası olarak kaydedilir gösterir. Aynı API ayrıca sunumları PPT ve ODP olarak da kaydeder, böylece tek bir kod tabanından hem PowerPoint hem de OpenDocument formatlarını hedefleyebilirsiniz, Microsoft Office gerekmez. Sonunda bulunan kısa SSS, formatlar, şablonlar, slayt boyutlandırma, birimler, bellek kullanımı, çok iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsar.

Başlamadan önce, paketi PyPI'dan `pip install aspose.slides` ile kurun. Linux ve macOS'un da ihtiyaç duyduğu kütüphaneler ve Debian ve Ubuntu'nun sistem Python'unun gerektirdiği sanal ortam için [Kurulum](/slides/tr/python-net/installation/) sayfasına bakın.

## **Sunum Oluşturma**

Bir sunum oluşturmak ve ilk slaytına metin içeren bir şekil eklemek için aşağıdaki adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.
2. [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) koleksiyonundan indeksini (0) kullanarak o slaytı alın.
3. Slaytın [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) koleksiyonundaki [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) yöntemiyle bulut şeklinde bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin ve onun [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/) özelliğini ayarlayın.
4. [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemiyle sunumu bir PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı al.
    slide = presentation.slides[0]

    # CLOUD tipinde bir otomatik şekil ekle.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Bulutun sol üst köşesi slaytın sol kenarından 20 point, üst kenarından 20 point uzakta ve bulut 200 point genişliğinde ve 80 point yüksekliğindedir. `with` ifadesi, blok sona erdiğinde sunumun kaynaklarını serbest bırakır. Betik, *new_presentation.pptx* dosyasını geçerli klasöre kaydeder; bulut ve metnini içeren bir slayt bulunur. Lisans olmadan Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; [Lisanslama](/slides/tr/python-net/licensing/) bölümüne bakın.

Sonuç:

![Yeni sunum](new_presentation.png)

## **SSS**

### Yeni bir sunumu hangi formatlara kaydedebilirim?

Sunumu [PPTX, PPT ve ODP](/slides/tr/python-net/save-presentation/) formatlarında kaydedebilir ve ayrıca [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/), [SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) ve [görseller](/slides/tr/python-net/convert-powerpoint-to-png/) gibi diğer formatlara dönüştürebilirsiniz.

### Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyip istediğiniz formata kaydedebilirsiniz; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/python-net/supported-file-formats/).

### Sunum oluştururken slayt boyutunu/eksen oranını nasıl kontrol ederim?

[slayt boyutu](/slides/tr/python-net/slide-size/) ayarını (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar) yapın ve içeriğin nasıl ölçekleneceğini seçin.

### Boyutlar ve koordinatlar hangi birimlerde ölçülür?

Birimi point olarak: 1 inç 72 birime eşittir.

### Bellek kullanımını azaltmak için çok büyük sunumları (çok sayıda medya dosyasıyla) nasıl yönetirim?

[BLOB yönetim stratejilerini](/slides/tr/python-net/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Sunumları paralel olarak oluşturup kaydedebilir miyim?

Aynı [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) örneği üzerinde [çoklu iş parçacıkları](/slides/tr/python-net/multithreading/) kullanarak işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

### Deneme filigranı ve sınırlamaları nasıl kaldırırım?

Bir süreçte bir kez lisans uygulayın. Lisans XML'i değiştirilmemiş olmalı ve birden fazla iş parçacığı varsa lisans ayarı senkronize edilmelidir.

### Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?

Evet. Sunumlar için [Dijital imzalar](/slides/tr/python-net/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. [VBA projeleri oluşturma/düzenleme](/slides/tr/python-net/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro etkinleştirilmiş dosyaları kaydedebilirsiniz.