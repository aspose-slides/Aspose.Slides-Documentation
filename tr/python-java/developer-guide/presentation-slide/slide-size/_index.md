---
title: Sunum Slayt Boyutunu Python üzerinden Java ile Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/python-java/slide-size/
keywords:
- slayt boyutu
- en boy oranı
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
- ekran türü
- yeniden ölçeklendirme
- uygunluğu sağla
- büyüklet
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarında slaytları hızlıca yeniden boyutlandırmayı öğrenin ve kaliteden ödün vermeden herhangi bir ekrana uygun sunumlar oluşturun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en boy oranını ayarlamak için kapsamlı araçlar sağlar; bu hem baskı hem de ekranda görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için tavsiye edilir.

Tüm slaytlara tek bir slayt boyutu ve en boy oranı uygulandığından, sunumunuz boyunca tutarlılığı sağlayın. En iyi sonuçlar için, karmaşık durumları önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="info" title="Not" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak Java üzerinden Python'da bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

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

Eğer yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzu özel bir sayfa düzeninde tam boyutlu slaytlar olarak yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde göstermeyi düşünüyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, Aspose.Slides for Python via Java kullanarak bir sunum için özel bir slayt boyutu nasıl belirleneceğini gösterir:

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

## **Yeniden Boyutlandırdıktan Sonra Slayt İçeriğini İşleme**

Bir sunum için slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slayt içeriğiyle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya başarmayı amaçladığınıza bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- [DoNotScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ, bu ayarı kullanın.

- [EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamak (bu şekilde içerik kaybını önlersiniz) istiyorsanız, bu ayarı kullanın.

- [Maximize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna göre orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

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

**İnç dışındaki birimler (örneğin puan veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan (point) kullanır; 1 puan 1/72 inç'e eşittir. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürerek slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, işleme sırasında performansı ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek işleme ölçeği, bellek tüketimini artırır ve işlem sürelerini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde işleme ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/python-java/merge-presentation/) — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slayttaki tek tek şekiller veya belirli bölgeler için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olacak mı?**

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) için olduğu kadar [seçili şekiller](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) için de küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutunu ve en boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.