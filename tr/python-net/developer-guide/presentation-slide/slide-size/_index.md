---
title: Python ile Sunumlardaki Slayt Boyutunu Değiştirin
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/python-net/slide-size/
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
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçekleme yok
- uygunluk sağla
- azami
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızla yeniden boyutlandırmayı öğrenin, herhangi bir ekranda kalite kaybı olmadan sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarındaki slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem yazdırma hem de ekranda gösterim için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En‑boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak önemlidir; tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, slayt boyutlarını sunum oluşturma sürecinin başında belirleyin, böylece komplikasyonlardan kaçınılır.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Bir Sunumda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak Python'da bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdaki tam boy slaytları özelleştirilmiş bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarı kullanmanız yararlı olacaktır. 

Bu örnek kod, Python'da bir sunum için özel bir slayt boyutu belirlemek amacıyla .NET üzerinden Python için Aspose.Slides kullanımını gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Kaydırma Sonrası Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıktığını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı ya da neyi başarmayı hedeflediğinize bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- `DO_NOT_SCALE`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ, bu ayarı kullanın.

- `ENSURE_FIT`

  Daha küçük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içerik kaybını önleyerek) sağlamasını istiyorsanız, bu ayarı kullanın. 

- `MAXIMIZE`

  Daha büyük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `MAXIMIZE` ayarının nasıl kullanılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **SSS**

**İnç dışındaki birimler kullanarak (örneğin, puant ya da milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puant (point) kullanır; 1 puant 1/72 inçe eşittir. Milimetre veya santimetre gibi herhangi bir birimi puanta dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performansı ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puant cinsinden) ve yüksek oluşturma ölçeği birleştiğinde, bellek tüketimi artar ve işlem süresi uzar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde oluşturma ölçeğini ayarlayın.

**Standart dışı bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştir](/slides/tr/python-net/merge-presentation/) yapılamaz — önce bir sunumu diğerine eşit olacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Tek tek şekiller veya slaytın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olur mu?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) ile birlikte [seçili şekiller](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) için küçük resimler oluşturabilir. Oluşan görseller, geçerli slayt boyutunu ve en‑boy oranını yansıtır; böylece çerçeveleme ve geometri tutarlılığı sağlanır.