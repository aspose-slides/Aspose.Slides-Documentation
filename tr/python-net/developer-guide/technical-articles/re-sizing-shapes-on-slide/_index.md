---
title: Python ile Sunumlarda Şekilleri Yeniden Boyutlandırma
linktitle: Şekilleri Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/python-net/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarında şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for Python müşterilerinin en sık sorduğu sorulardan biri, slayt boyutu değiştiğinde verilerin kesilmemesi için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale, bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Slayt boyutu değiştiğinde şekillerin hizalanmasını korumak için, her şeklin konumunu ve boyutlarını yeni slayt düzenine göre güncelleyin.

```py
import aspose.slides as slides

# Sunum dosyasını yükle.
with slides.Presentation("sample.pptx") as presentation:
    # Orijinal slayt boyutunu al.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Yeni slayt boyutunu al.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Her slaytta şekilleri yeniden boyutlandır ve konumlandır.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Şekil boyutunu ölçeklendir.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Şekil konumunu ölçeklendir.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru çalışmaz. Bu durumda, tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}} 

Tablo içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kullanın. Tablolar için genişlik veya yükseklik ayarlamak özel bir durumdur: tablonun genel boyutunu değiştirmek için bireysel satır yüksekliği ve sütun genişliğini ayarlamanız gerekir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Orijinal slayt boyutunu al.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Yeni slayt boyutunu al.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Şekil boyutunu ölçeklendir.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Şekil konumunu ölçeklendir.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Şekil boyutunu ölçeklendir.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Şekil konumunu ölçeklendir.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Şekil boyutunu ölçeklendir.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Şekil konumunu ölçeklendir.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Kaydırma yeniden boyutlandırıldıktan sonra şekiller neden bozuluyor veya kesiliyor?**  
Kaydırma yeniden boyutlandırıldığında, şekiller ölçek açıkça değiştirildiği sürece orijinal konum ve boyutlarını korur. Bu, içeriğin kırpılmasına veya şekillerin hizalanmamasına neden olabilir.

**Sağlanan kod tüm şekil tipleri için çalışıyor mu?**  
Temel örnek, metin kutuları, görüntüler, grafikler vb. çoğu şekil tipi için çalışır. Ancak tablolar için satır ve sütunları ayrı ayrı ele almanız gerekir; çünkü bir tablonun yüksekliği ve genişliği ayrı hücrelerin boyutlarıyla belirlenir.

**Kaydırma yeniden boyutlandırıldığında tabloları nasıl yeniden boyutlandırırım?**  
Tablonun tüm satır ve sütunları üzerinden döngü kurarak, ikinci kod örneğinde gösterildiği gibi yükseklik ve genişliklerini orantılı olarak yeniden boyutlandırmalısınız.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için işe yarar mı?**  
Evet, aynı ölçekleme mantığını uygulamak için [Ustalar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/masters/) ve [Düzen slaytları](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/layout_slides/) üzerinden de döngü kurmalı ve şekillerine aynı mantığı uygulamalısınız.

**Kaydırmayı yeniden boyutlandırırken slaytın yönünü (dikey/yatay) değiştirebilir miyim?**  
Evet. Yönü değiştirmek için [presentation.slide_size.orientation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/islidesize/orientation/) özelliğini kullanabilirsiniz. Yerleşimi korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**  
Aspose.Slides özelleştirilmiş boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluk sorunları yaratabilir.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**  
Şeklin `aspect_ratio_locked` özelliğini ölçeklemeden önce kontrol edebilirsiniz. Eğer kilitli ise, genişlik veya yüksekliği bireysel olarak ölçeklemek yerine orantılı olarak ayarlayın.