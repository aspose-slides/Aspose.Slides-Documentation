---
title: Python üzerinden Java ile Sunum Slaytı Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/python-java/slide-size/
keywords:
  - slayt boyutu
  - en-boy oranı
  - standart
  - geniş ekran
  - 4:3
  - 16:9
  - slayt boyutunu ayarla
  - slayt boyutunu değiştir
  - özel slayt boyutu
  - özel slayt boyutu
  - benzersiz slayt boyutu
  - tam boyutlu slayt
  - ekran tipi
  - ölçeklendirme yapma
  - uyumu sağla
  - büyüt
  - PowerPoint
  - OpenDocument
  - sunum
  - Python
  - Java
  - Aspose.Slides
description: "Python üzerinden Java ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı öğrenin ve kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarındaki slayt boyutu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekranda görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için slayt boyutlarını sunumu oluşturma sürecinin başında ayarlayın; bu, komplikasyonları önler.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Not ve el ilanı sayfalarının boyutları normal slaytlardan farklıdır. Boyutlarını ve yönlerini değiştirmek için [Notes Page Size](/slides/tr/python-java/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak Java aracılığıyla Python'da bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunumlarda Özel Slayt Boyutları Belirleme**

Eğer yaygın slayt boyutları (4:3 ve 16:9) çalışmanız için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, sunumunuz için özel bir boyut ayarı kullanmak size fayda sağlayabilir.

Bu örnek kod, Aspose.Slides for Python via Java kullanarak bir sunum için özel bir slayt boyutu nasıl belirtileceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Boyutlandırma Sonrası Slayt İçeriğini Yönetme**

Sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı düşündüğünüze bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- [DoNotScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Nesnelerin slaytlarda yeniden boyutlandırılmasını istemiyorsanız, bu ayarı kullanın.

- [EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Daha küçük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriği kaybetmezsiniz) sağlamasını istiyorsanız, bu ayarı kullanın.

- [Maximize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Daha büyük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken [Maximize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#Maximize) ayarının nasıl kullanılacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **SSS**

**İnç dışında birimlerle (örneğin puant veya milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puant (point) birimini kullanır; 1 puant 1/72 inçtir. Herhangi bir birimi (örneğin milimetre veya santimetre) puanta dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puant cinsinden) ve yüksek render ölçeği, bellek tüketiminin artmasına ve işlem sürelerinin uzamasına yol açar. Pratik bir slayt boyutuna hedefleyin ve istenen çıktı kalitesini elde etmek için yalnızca gerektiğinde render ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/python-java/merge-presentation/) — önce bir sunumun boyutunu diğerine eşitlemek için yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slayttaki tek tek şekiller veya belirli bölgeler için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) için olduğu gibi [seçili şekiller](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) için de küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.