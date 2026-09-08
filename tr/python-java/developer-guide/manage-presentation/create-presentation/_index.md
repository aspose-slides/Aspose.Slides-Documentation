---
title: Python ile Java üzerinden Sunumlar Oluştur
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/python-java/create-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Python ile Java üzerinden Aspose.Slides kullanarak sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak bir sunum oluşturmayı, ilk slayda metin içeren bir şekil eklemeyi ve sonucu PPTX dosyası olarak kaydetmeyi gösterir. SSS, çıktı biçimleri, şablonlar, slayt boyutu, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteği konularını kapsar.

## **Sunum Oluşturma**

Aspose.Slides for Python via Java’da baştan bir PowerPoint dosyası oluşturmak, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturmaktan daha basit değildir. Yapıcı, tek bir slayt içeren boş bir sunum otomatik olarak sağlar; bu da şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu diğer içerikler için anında bir tuval sunar. Bu slaytı değiştirdikten veya yeni slaytlar ekledikten sonra sonucu PPTX, eski PPT veya hatta OpenDocument biçimlerinde kalıcı hale getirebilirsiniz. Aşağıdaki kısa kod örneği, ilk slayta basit bir şekil ekleyerek bu iş akışını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksiyle ilk slaytı alın.  
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) kullanarak type [ShapeType.Cloud](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Cloud) olan bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.  
1. Şeklin metnini [TextFrame.setText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#setText) ile ayarlayın.  
1. Sunumu [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) ve [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) kullanarak kaydedin.

Aşağıdaki örnek, Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanını gerektirir. JVM hâlâ çalışmıyorsa başlatır, ilk slayta bir bulut şekli ekler ve sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Bir boş slayt içeren bir sunum oluştur.
presentation = Presentation()
try:
    #    İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    #    Bir bulut şekli ekle ve metnini ayarla.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    #    Sunumu PPTX dosyası olarak kaydet.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Yeni sunum](new_presentation.png)

## **SSS**

**Yeni bir sunumu hangi biçimlerde kaydedebilirim?**

[PPTX, PPT ve ODP](/slides/tr/python-java/save-presentation/) biçimlerinde kaydedebilir ve [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/), [SVG](/slides/tr/python-java/render-slide-as-svg/) ve [images](/slides/tr/python-java/convert-powerpoint-to-png/) gibi diğer formatlarda dışa aktarabilirsiniz.

**Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyin ve istenilen biçimde kaydedin; POTX/POTM/PPTM ve benzeri biçimler [desteklenir](/slides/tr/python-java/supported-file-formats/).

**Sunum oluştururken slayt boyutunu/ en‑boy oranını nasıl kontrol edebilirim?**

[slide size](/slides/tr/python-java/slide-size/) ayarlayın (4:3 ve 16:9 gibi ön ayarlar ya da özel boyutlar dahil) ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerde ölçülür?**

Piksel değil, puan cinsindendir: 1 inç 72 birime eşittir.

**Çok büyük sunumları (birçok medya dosyasıyla) bellek kullanımını azaltmak için nasıl yönetebilirim?**

[BLOB yönetim stratejileri](/slides/tr/python-java/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini [multiple threads](/slides/tr/python-java/multithreading/) üzerinden çalıştıramazsınız. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

**Deneme su işareti ve kısıtlamaları nasıl kaldırabilirim?**

[Apply a license](/slides/tr/python-java/licensing/) işlemini işlem başına bir kez yapın. Lisans XML’i değiştirilmemeli ve birden çok iş parçacığı kullanılıyorsa lisans ayarı senkronize edilmelidir.

**Oluşturduğum PPTX dosyasını dijital olarak imzalayabilir miyim?**

Evet. [Digital signatures](/slides/tr/python-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) sunumlar için desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [create/edit VBA projects](/slides/tr/python-java/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.