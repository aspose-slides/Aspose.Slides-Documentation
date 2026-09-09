---
title: Python üzerinden Java ile Sunum Oluşturma
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
description: "Aspose.Slides ile Python üzerinden Java’da sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinin avantajlarından yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java ile bir sunum nasıl oluşturulacağını, ilk slayta metin içeren bir şekil eklemeyi ve sonucu PPTX dosyası olarak kaydetmeyi gösterir. SSS, çıktı formatları, şablonlar, slayt boyutu, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğini kapsar.

## **Sunum Oluşturma**

Aspose.Slides for Python via Java’da sıfırdan bir PowerPoint dosyası oluşturmak, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini yaratmak kadar basittir. Yapıcı, tek bir slayt içeren boş bir sunum otomatik olarak sağlar; bu, şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu diğer içerikler için anında bir tuval sunar. Bu slaytı düzenledikten—veya yeni slaytlar ekledikten—sonucu PPTX, eski PPT veya hatta OpenDocument formatlarına kaydedebilirsiniz. Aşağıdaki kısa kod örneği, ilk slayta basit bir şekil ekleyerek bu iş akışını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İlk slaytı indeksine göre alın.  
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) kullanarak [ShapeType.Cloud](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Cloud) tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.  
1. Şeklin metnini [TextFrame.setText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#setText) ile ayarlayın.  
1. [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile kullanarak sunumu kaydedin.

Aşağıdaki örnek, Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanını gerektirir. JVM henüz çalışmıyorsa başlatır, ilk slayta bir bulut şekli ekler ve sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Bir boş slayt ile sunum oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir bulut şekli ekle ve metnini ayarla.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![The new presentation](new_presentation.png)

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

[PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/), [SVG](/slides/tr/python-java/render-slide-as-svg/) ve [görseller](/slides/tr/python-java/convert-powerpoint-to-png/) gibi diğer seçeneklerin yanı sıra [PPTX, PPT ve ODP](/slides/tr/python-java/save-presentation/) formatlarında kaydedebilirsiniz.

**Bir şablondan (POTX/POTM) başlatıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyin ve istediğiniz formatta kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/python-java/supported-file-formats/).

**Sunum oluştururken slayt boyutu/ en‑boy oranını nasıl kontrol ederim?**

[slayt boyutunu](/slides/tr/python-java/slide-size/) (4:3, 16:9 gibi ön ayarlar veya özel boyutlar) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimde ölçülür?**

Puan cinsinden: 1 inç 72 birime eşittir.

**Çok sayıda medya dosyası içeren büyük sunumlarda bellek kullanımını nasıl azaltırım?**

[Blob yönetim stratejileri](/slides/tr/python-java/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya temelli iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğine [çoklu iş parçacıkları](/slides/tr/python-java/multithreading/) üzerinden erişemezsiniz. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

**Deneme sürümü filigranı ve sınırlamaları nasıl kaldırırım?**

İşlem başına bir kez [lisans uygulayın](/slides/tr/python-java/licensing/). Lisans XML’i değiştirilmemeli ve birden fazla iş parçacığı kullanıyorsanız lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX dosyasını dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/python-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturabilir/düzenleyebilir](/slides/tr/python-java/presentation-via-vba/) ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.