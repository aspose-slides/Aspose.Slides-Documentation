---
title: Python ile Sunumlarda Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/python-net/slide-size/
keywords:
- slayt boyutu
- en‑boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçeklendirme
- sığdırmayı sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Introduction**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en-boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekranda gösterim için kritiktir.

Popüler Slayt Boyutları ve Oranları:
- **Standard (4:3 Aspect Ratio)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 Aspect Ratio)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en-boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, komplikasyonları önlemek amacıyla slayt boyutlarını sunumu oluşturma sürecinin başında ayarlayın.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en-boy oranını kullanır.
{{% /alert %}}

Not ve el kitapçığı sayfalarının boyutları normal slaytlardan ayrı olup, boyut ve yönlerini değiştirmek için [Notes Page Size](/slides/tr/python-net/notes-size/) sayfasına bakın.

## **Sunumda Slayt Boyutunu Değiştirme**

Bu örnek kod, Python'da Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Slayt Boyutlarını Belirleme**

Eğer yaygın slayt boyutları (4:3 ve 16:9) çalışmanız için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran türlerinde göstermek istiyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, Python'da Aspose.Slides for Python via .NET kullanarak bir sunum için özel slayt boyutu nasıl belirleyeceğinizi gösterir:
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Kaydırma Sonrası Slayt İçeriğini Ele Alma**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutu değiştirildiğinde, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıktığını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı ya da neyi başarmayı amaçladığınıza bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:
- `DO_NOT_SCALE`

  Nesnelerin slaytlarda yeniden boyutlandırılmasını **istemiyorsanız**, bu ayarı kullanın.

- `ENSURE_FIT`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini tüm slaytlara sığacak şekilde küçültmesini (böylece içeriğin kaybolmasını önlersiniz) istiyorsanız, bu ayarı kullanın.

- `MAXIMIZE`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `MAXIMIZE` ayarının nasıl kullanılacağını gösterir:
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **SSS**

**İnç dışında birimlerle (örneğin, puan veya milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan (point) kullanır; 1 puan 1/72 inçtir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliği tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve daha yüksek oluşturma ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca istenen çıktı kalitesini elde etmek için oluşturma ölçeğini gerektiği gibi ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/python-net/merge-presentation/) — önce bir sunumu diğerine eşitlemek için yeniden boyutlandırın. Slayt boyutu değiştirildiğinde, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutlar eşitlendiğinde, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaytın belirli bölgeleri için küçük resimler oluşturabilir miyim ve yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) için ve [seçili şekiller](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) için küçük resimler oluşturabilir. Oluşturulan görseller mevcut slayt boyutunu ve en-boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.