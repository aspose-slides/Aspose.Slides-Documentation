---
title: Python'da PPT, PPTX ve ODP'yi JPG'ye Dönüştür
linktitle: Slaytları JPG Görüntülerine Dönüştür
type: docs
weight: 60
url: /tr/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i JPG'ye dönüştür
- sunumu JPG'ye dönüştür
- slaytı JPG'ye dönüştür
- PPT'yi JPG'ye dönüştür
- PPTX'i JPG'ye dönüştür
- ODP'yi JPG'ye dönüştür
- PowerPoint'tan JPG'ye
- sunumdan JPG'ye
- slayttan JPG'ye
- PPT'den JPG'ye
- PPTX'den JPG'ye
- ODP'den JPG'ye
- PowerPoint'i JPEG'e dönüştür
- sunumu JPEG'e dönüştür
- slaytı JPEG'e dönüştür
- PPT'yi JPEG'e dönüştür
- PPTX'i JPEG'e dönüştür
- ODP'yi JPEG'e dönüştür
- PowerPoint'tan JPEG'e
- sunumdan JPEG'e
- slayttan JPEG'e
- PPT'den JPEG'e
- PPTX'den JPEG'e
- ODP'den JPEG'e
- Python
- Aspose.Slides
description: "Python'da sadece birkaç satır kodla PowerPoint ve OpenDocument sunumlarındaki slaytlarınızı yüksek kaliteli JPEG görüntülerine nasıl dönüştüreceğinizi öğrenin. Sunumları web kullanımı, paylaşım ve arşivleme için optimize edin. Tam kılavuzu şimdi okuyun!"
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides for Python, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülerine dönüştürmenizi sağlar. Bu kılavuz, dönüşümün farklı yöntemlerini açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Sunum slaytlarını kopyalamadan korumak veya yalnızca okunabilir modda sunumu göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenize olanak tanır.

## **Sunum Slaytlarını JPG Görüntülerine Dönüştürme**

Bir PPT, PPTX veya ODP dosyasını JPG'ye dönüştürmek için adımlar:

1. Presentation sınıfının bir örneğini oluşturun.
1. Presentation.slides koleksiyonundan Slide tipinde bir slayt nesnesi alın.
1. Slide.get_image(scale_x, scale_y) metodunu kullanarak slaytın bir görüntüsünü oluşturun.
1. Görüntü nesnesi üzerinde IImage.save(filename, format) metodunu çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak geçin.

{{% alert color="primary" %}}

**Not:** PPT, PPTX veya ODP'den JPG'ye dönüşüm, Aspose.Slides Python API'sindeki diğer format dönüşümlerinden farklıdır. Diğer formatlar için genellikle Presentation.save(fname, format, options) metodunu kullanırsınız. Ancak JPG dönüşümü için IImage.save(filename, format) metodunu kullanmanız gerekir.

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Görüntüyü JPEG formatında diske kaydet.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Özel Boyutlarla Slaytları JPG'ye Dönüştürme**

Oluşturulan JPG görüntülerinin boyutlarını değiştirmek için, [Slide.get_image(image_size)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) metoduna resmi boyutunu geçirerek ayarlayabilirsiniz. Bu, belirli genişlik ve yükseklik değerlerine sahip görüntüler oluşturmanızı sağlar ve çıktı, çözünürlük ve en-boy oranı gereksinimlerinizi karşılar. Bu esneklik, web uygulamaları, raporlar veya belgeler için görüntü oluştururken kesin boyutların gerektiği durumlarda özellikle faydalıdır.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Belirtilen boyutta bir slayt resmi oluştur.
        with slide.get_image(image_size) as thumbnail:
            # Görüntüyü JPEG formatında diske kaydet.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Görseller Olarak Kaydederken Yorumları İşleme**

Aspose.Slides for Python, slaytları JPG görüntülerine dönüştürürken sunum slaytlarındaki yorumları işleme özelliği sunar. Bu işlevsellik, PowerPoint sunumlarına iş birliği yapan kişiler tarafından eklenen açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle yararlıdır. Bu seçeneği etkinleştirerek, yorumların oluşturulan görüntülerde görünür olmasını sağlarsınız; böylece orijinal sunum dosyasını açmadan geri bildirimleri incelemek ve paylaşmak daha kolay olur.

Diyelim ki "sample.pptx" adlı bir sunum dosyamız var ve içinde yorumlar bulunan bir slayt:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki Python kodu, slaytı yorumları koruyarak bir JPG görüntüsüne dönüştürür:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Slayt yorumları için seçenekleri ayarla.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # İlk slaytı bir görüntüye dönüştür.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Sonuç:

![Yorumlu JPG görüntüsü](image_with_comments.png)

## **Ayrıca bakınız**

Diğer PPT, PPTX veya ODP'yi görüntülere dönüştürme seçeneklerine bakın:

- [PowerPoint'i GIF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint'i PNG'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-png/)
- [PowerPoint'i TIFF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint'i SVG'ye Dönüştür](/slides/tr/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides'in PowerPoint'i JPG görüntülere nasıl dönüştürdüğünü görmek için bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT to JPG](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Ücretsiz Çevrimiçi PPTX'ten JPG'ye Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose, [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'yi JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'yi PNG'ye birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

Bu makalede açıklanan aynı prensipleri kullanarak, görüntüleri bir formattan diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [görüntüyü JPG'ye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/image-to-jpg/; [JPG'yi görüntüye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-image/; [JPG'yi PNG'ye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-png/; [PNG'yi JPG'ye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/png-to-jpg/; [PNG'yi SVG'ye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/png-to-svg/; [SVG'yi PNG'ye dönüştür]https://products.aspose.com/slides/tr/python-net/conversion/svg-to-png/.

{{% /alert %}}

## **SSS**

**Bu yöntem toplu dönüşümü destekliyor mu?**

Evet, Aspose.Slides tek bir işlemde birden çok slaytı JPG'ye toplu olarak dönüştürmeye olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil olmak üzere tüm içeriği işler. Ancak, özellikle özelleştirilmiş veya eksik yazı tipleri kullanıldığında, render doğruluğu PowerPoint'e kıyasla biraz farklı olabilir.

**İşlenebilecek slayt sayısında herhangi bir sınırlama var mı?**

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı üzerinde katı bir sınırlama getirmez. Ancak, büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatasıyla karşılaşabilirsiniz.