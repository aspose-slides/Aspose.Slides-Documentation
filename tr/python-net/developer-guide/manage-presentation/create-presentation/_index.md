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
description: "Aspose.Slides ile Python'da PowerPoint sunumları oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programatik olarak kaydedin."
---
## **Genel Bakış**

Aspose.Slides for Python, kod içinde tamamen yeni bir sunum dosyası oluşturmanıza olanak tanır. Bu makale, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi oluşturma, ilk slaytı alıp, basit bir şekil ekleme ve sonucu kalıcı hâle getirme gibi temel iş akışını gösterir; böylece Microsoft Office olmadan bir sunum üretmek için ne kadar az kurulum gerektiğini görebilirsiniz. Aynı API PPT, PPTX ve ODP dosyaları yazabildiği için tek bir kod tabanından hem geleneksel PowerPoint hem de OpenDocument formatlarını hedefleyebilirsiniz. Aspose.Slides, masaüstü, web veya sunucu ortamlarına uygundur ve Python uygulamanıza ilk slayt destesi oluşturulduktan sonra metin, resim veya grafik gibi daha zengin içerik eklemek için verimli bir başlangıç noktası sunar.

## **Sunum Oluşturma**

Aspose.Slides for Python’da sıfırdan bir PowerPoint dosyası oluşturmak, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturmak kadar basittir. Yapıcı, otomatik olarak tek bir slayttan oluşan boş bir desteyi sağlar ve bu sayede şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu herhangi bir içerik için hemen bir tuval elde edersiniz. Bu slaytı değiştirdikten sonra—veya yenilerini ekledikten sonra—sonucu PPTX, eski PPT veya hatta OpenDocument formatlarında kalıcı hâle getirebilirsiniz. Aşağıdaki kısa kod örneği, ilk slayta basit bir şekil ekleyerek bu iş akışını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slayta indeksine göre bir referans alın.  
3. `shapes` koleksiyonunda bulunan `add_auto_shape` yöntemiyle `CLOUD` tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnesi ekleyin.  
4. Auto‑shape’e metin ekleyin.  
5. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun ilk slaytına bir bulut şekli eklenir.

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

Sonuç:

![Yeni sunum](new_presentation.png)

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**  
Yeni bir sunumu [PPTX, PPT ve ODP](/slides/tr/python-net/save-presentation/) formatlarında kaydedebilir, ayrıca [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/), [SVG](/slides/tr/python-net/convert-powerpoint-to-png/) ve [görseller](/slides/tr/python-net/convert-powerpoint-to-png/) gibi diğer formatlara da dışa aktarabilirsiniz.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**  
Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/python-net/supported-file-formats/).

**Sunum oluştururken slayt boyutunu/en boy oranını nasıl kontrol edebilirim?**  
[slide size](/slides/tr/python-net/slide-size/) ayarını (4:3 ve 16:9 gibi ön ayarlar ya da özel boyutlar) yapın ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerle ölçülür?**  
Puan (point) cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok sayıda medya dosyası içeren büyük sunumları nasıl yönetebilirim?**  
[BLOB management strategies](/slides/tr/python-net/manage-blob/) kullanın, geçici dosyaları kullanarak bellekteki depolamayı sınırlayın ve tamamen bellekteki akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup/kaydedebilir miyim?**  
Aynı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği üzerinde [çoklu iş parçacıkları](/slides/tr/python-net/multithreading/) ile işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

**Deneme filigranı ve sınırlamaları nasıl kaldırabilirim?**  
İşlem başına bir kez [Lisans uygulayın](/slides/tr/python-net/licensing/) yapın. Lisans XML'i değiştirilmemeli ve birden fazla iş parçacığı kullanılıyorsa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?**  
Evet. Sunumlar için [Digital signatures](/slides/tr/python-net/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**  
Evet. [create/edit VBA projects](/slides/tr/python-net/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.