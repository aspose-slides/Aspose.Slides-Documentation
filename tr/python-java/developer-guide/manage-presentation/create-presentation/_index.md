---
title: Python üzerinden Java ile Sunumlar Oluşturma
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
description: "Aspose.Slides ile Python üzerinden Java aracılığıyla sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak bir sunum nasıl oluşturulur, ilk slayta metin içeren bir şekil nasıl eklenir ve sonuç bir PPTX dosyası olarak nasıl kaydedilir, konularını gösterir. SSS bölümü çıktı formatları, şablonlar, slayt boyutlandırması, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteği gibi konuları kapsar.

Başlamadan önce Python, bir JDK, JPype ve Aspose.Slides for Python via Java'ı kurun. Windows, Linux ve macOS için adımları görmek üzere [Kurulum](/slides/tr/python-java/installation/) sayfasına bakın.

## **Sunum Oluşturma**

Aspose.Slides for Python via Java ile sıfırdan bir PowerPoint dosyası oluşturmak, [Presentation] sınıfının bir örneğini oluşturmak kadar basittir. Yapıcı, tek bir slayttan oluşan boş bir sunum otomatik olarak sağlar ve bu sayede şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu diğer içerikler için hemen bir tuval elde edersiniz. Bu slaytı değiştirdikten—veya yenilerini ekledikten—sonucu PPTX, eski PPT ya da hatta OpenDocument formatlarında kalıcı hale getirebilirsiniz. Aşağıdaki kısa kod örneği, ilk slayta basit bir şekil ekleyerek bu iş akışını gösterir.

1. Bir [Presentation] örneği oluşturun.
1. İlk slaytı indeks değeri 0 ile alın.
1. [ShapeCollection.addAutoShape] yöntemiyle [ShapeType.Cloud] türünde bir [AutoShape] ekleyin.
1. Şeklin metnini [TextFrame.setText] ile ayarlayın.
1. [Presentation.save] metodunu [SaveFormat.Pptx] ile kullanarak sunumu kaydedin.

İşte örnek, Java Sanal Makinesi (JVM) hâlâ çalışmıyorsa başlatır, ilk slayta metinli bir bulut şekli ekler ve sunumu kaydeder. Dosyayı *create_presentation.py* olarak kaydedin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Bir sunumu tek boş slaytla oluştur.
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

Paketleri kurduğunuz ortamda betiği çalıştırın:

```sh
python create_presentation.py
```

Bulutun sol üst köşesi slaytın sol ve üst kenarlarından 20 puan uzaklıkta ve bulut 200 puan genişliğinde ve 80 puan yüksekliğindedir. Betik, *new_presentation.pptx* dosyasını geçerli çalışma dizinine kaydeder; bu dosya, bulutu ve metnini içeren bir slayt içerir. JVM, Python işlemi sona erene kadar çalışmaya devam eder; bkz. [Sınırlamalar ve API Farklılıkları](/slides/tr/python-java/limitations-and-api-differences/#import-the-library). Lisans olmadan Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı metin kutusu ekler; bkz. [Lisanslama](/slides/tr/python-java/licensing/).

Sonuç:

![Yeni sunum](new_presentation.png)

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

Yeni bir sunumu [PPTX, PPT ve ODP](/slides/tr/python-java/save-presentation/) formatlarında kaydedebilir ve ayrıca [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/), [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) ve [görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

**Şablondan (POTX/POTM) başlatıp normal bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyip istediğiniz formatta kaydedebilirsiniz; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/python-java/supported-file-formats/).

**Sunum oluştururken slayt boyutu/en‑boy oranını nasıl kontrol ederim?**

Şu yolu kullanarak [slayt boyutunu](/slides/tr/python-java/slide-size/) (4:3 ve 16:9 gibi ön ayarlar ya da özel boyutlar dahil) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimde ölçülür?**

Puan (point) cinsindendir: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok sayıda medya dosyası içeren büyük sunumları nasıl yönetebilirim?**

Bellek kullanımını azaltmak için [BLOB yönetim stratejilerini](/slides/tr/python-java/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlardan ziyade dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup/kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği üzerinde [birden fazla iş parçacığı](/slides/tr/python-java/multithreading/) işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı, izole edilmiş örnekler çalıştırın.

**Deneme filigranını ve sınırlamaları nasıl kaldırabilirim?**

[Bir lisans uygulayın](/slides/tr/python-java/licensing/) süreç başına bir kez. Lisans XML'i değiştirilmemiş kalmalı ve birden fazla iş parçacığı kullanılıyorsa lisans kurulumu senkronize edilmelidir.

**Oluşturduğum PPTX'yi dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [Dijital imzalar](/slides/tr/python-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturabilir/düzenleyebilirsiniz](/slides/tr/python-java/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.