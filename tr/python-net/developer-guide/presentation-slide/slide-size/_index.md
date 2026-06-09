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
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçekleme yok
- uygunluk sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
descriptions: "Python ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı, kalite kaybı olmadan herhangi bir ekran için sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlayın; tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın, böylece komplikasyonlardan kaçınırsınız.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumda Slayt Boyutunu Değiştirme**

Bu örnek kod, Python'da Aspose.Slides kullanarak bir sunumda slayt boyutunun nasıl değiştirileceğini gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdaki slaytları özel bir sayfa düzeninde tam boyutlu olarak yazdırmayı planlıyorsanız veya belirli ekran türlerinde görüntülemeyi düşünüyorsanız, sunumunuz için özel bir boyut ayarı kullanmanız yararlı olacaktır. 

Bu örnek kod, Python üzerinden .NET aracılığıyla Aspose.Slides for Python kullanarak bir sunumda özel slayt boyutu belirlemenin nasıl yapılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içeriği nasıl ele alacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı amaçladığınıza bağlı olarak aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DO_NOT_SCALE`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını istemiyorsanız, bu ayarı kullanın.

- `ENSURE_FIT`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamasını istiyorsanız (böylece içerik kaybını önlersiniz), bu ayarı kullanın. 

- `MAXIMIZE`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `MAXIMIZE` ayarının nasıl kullanılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **SSS**

**Özel bir slayt boyutunu inç dışında bir birim (örneğin puan veya milimetre) kullanarak ayarlayabilir miyim?**

Evet. Aspose.Slides, dahili olarak puan birimini kullanır; 1 puan bir inçin 1/72'sine eşittir. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, daha fazla bellek tüketimi ve daha uzun işleme sürelerine yol açar. Pratik bir slayt boyutu hedefleyin ve yalnızca istenen çıktı kalitesini elde etmek için render ölçeğini gerektiği gibi ayarlayın.

**Standart dışı bir slayt boyutu tanımlayıp ardından farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [merge presentations](/slides/tr/python-net/merge-presentation/) yapamazsınız — önce bir sunumu diğerine eşit olacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya slaytın belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [entire slides](/slides/tr/python-net/slide/get_image/) ve [selected shapes](/slides/tr/python-net/shape/get_image/) için önizleme görselleri oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.