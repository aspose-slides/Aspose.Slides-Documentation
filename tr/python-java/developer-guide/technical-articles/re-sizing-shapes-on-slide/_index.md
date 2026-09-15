---
title: Python üzerinden Java ile Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma
type: docs
weight: 110
url: /tr/python-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java müşterilerinin en yaygın sorularından biri, slayt boyutu değiştiğinde verinin kesilmemesi için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Slayt boyutu değiştiğinde şekillerin hizalanmasının bozulmasını önlemek için, her bir şeklin konum ve boyutlarını yeni slayt düzenine uyması üzere güncelleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Sunum dosyasını yükleyin.
presentation = Presentation("sample.ppt")
try:
    # Orijinal slayt boyutunu alın.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştirin.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Yeni slayt boyutunu alın.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Her slayttaki şekilleri yeniden boyutlandırın ve konumlandırın.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Şekil boyutunu ölçeklendirin.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Şekil konumunu ölçeklendirin.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}} 
Tablolar özel bir işleme gerek duymaz: bir tablonun genişliğini ve yüksekliğini ayarlamak, sütun ve satırları orantılı olarak yeniden ölçeklendirir, bu nedenle satır yüksekliklerini ve sütun genişliklerini tekrar ölçeklendirmek oranı iki kez uygulamak anlamına gelir.
{{% /alert %}} 

Yukarıdaki kod yalnızca slaytlardaki şekilleri değiştirir. Master slaytlar ve düzen slaytları kendi şekillerine sahiptir, bu yüzden tüm sunumun yeni slayt boyutuna uymasını istediğinizde onları da ölçeklendirin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Orijinal slayt boyutunu alın.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Yeni slayt boyutunu alın.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Şekil boyutunu ölçeklendirin.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Şekil konumunu ölçeklendirin.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Şekil boyutunu ölçeklendirin.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Şekil konumunu ölçeklendirin.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Şekil boyutunu ölçeklendirin.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Şekil konumunu ölçeklendirin.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?**

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmediği sürece şekiller orijinal konum ve boyutlarını korur. Bu, içeriğin kırpılmasına veya şekillerin hizalanmasının bozulmasına neden olabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

Evet. Yükseklik ve genişlik ayarlaması metin kutuları, resimler, grafikler ve tablolar için aynı şekilde çalışır.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Tablo şeklinin kendisini, diğer şekiller gibi ölçeklendirin. Satır ve sütunları orantılı olarak izler, bu yüzden sonradan onları tekrar ölçeklendirmeyin.

**Bu yeniden boyutlandırma master slaytlar ve düzen slaytları için de geçerli olacak mı?**

Evet, ancak [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) ve [Presentation.getLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getLayoutSlides) döngüsüyle de geçerek, şekillerine aynı ölçekleme mantığını uygulamalısınız; böylece sunum genelinde tutarlılık sağlanır.

**Yeniden boyutlandırma sırasında bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Yönü değiştirmek için [SlideSize.setOrientation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setOrientation) metodunu kullanabilirsiniz. Düzeni korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

Aspose.Slides özel boyutları destekler, ancak çok büyük boyutlar performansı veya bazı PowerPoint sürümleriyle uyumluluğu etkileyebilir.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Ölçeklendirmeden önce şekil kilidinin [getAspectRatioLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) metodunu kontrol edebilirsiniz. Eğer kilitli ise, genişlik veya yüksekliği bireysel olarak ölçeklendirmek yerine orantılı olarak ayarlayın.