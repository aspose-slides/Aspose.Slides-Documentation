---
title: Düzen Slaytı
type: docs
weight: 20
url: /tr/python-net/examples/elements/layout-slide/
keywords:
- düzen slaytı
- düzen slaytı ekle
- düzen slaytına eriş
- düzen slaytını kaldır
- kullanılmayan düzen slaytı
- düzen slaytını kopyala
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile layout slaytlarını yönetmek için Python kullanın: PPT, PPTX ve ODP sunumlarında yer tutucuları ve temaları oluşturun, uygulayın, kopyalayın, yeniden adlandırın ve özelleştirin."
---
Bu makale, Aspose.Slides for Python via .NET içinde **Layout Slides** ile nasıl çalışılacağını gösterir. Bir layout slide, normal slaytlar tarafından miras alınan tasarımı ve biçimlendirmeyi tanımlar. Layout slide'larını ekleyebilir, erişebilir, klonlayabilir ve kaldırabilirsiniz; ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Bir Düzen Slaytı Ekle**

Yeniden kullanılabilir biçimlendirme tanımlamak için özel bir layout slide oluşturabilirsiniz.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Belirtilen tür ve ad ile bir düzen slaytı oluştur.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **İpucu 1:** Layout slide'lar, bireysel slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slaytta tekrar kullanabilirsiniz.

> 💡 **İpucu 2:** Bir layout slide'a şekil veya metin eklediğinizde, o düzene dayanan tüm slaytlar bu ortak içeriği otomatik olarak gösterir.
> Aşağıdaki ekran görüntüsü, aynı layout slide'dan bir metin kutusu miras alan iki slaytı gösterir.

![Düzen İçeriğini Miras Alan Slaytlar](layout-slide-result.png)


## **Bir Düzen Slaytına Erişme**

Layout slide'larına indeks veya layout türüne göre (ör. `Blank`, `Title`, `SectionHeader` vb.) erişilebilir.

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # İndeks ile eriş.
        first_layout_slide = presentation.layout_slides[0]

        # Düzen türüne göre eriş.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Bir Düzen Slaytını Kaldır**

Artık gerekmediğinde belirli bir layout slide'ını kaldırabilirsiniz.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Türüne göre bir düzen slaytı al ve kaldır.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kullanılmayan Düzen Slaytlarını Kaldır**

Sunum boyutunu azaltmak için, hiçbir normal slayt tarafından kullanılmayan layout slide'larını kaldırmak isteyebilirsiniz.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Otomatik olarak hiçbir slayt tarafından referans edilmeyen tüm düzen slaytlarını kaldırır.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Düzen Slaytını Kopyala**

`AddClone` metodunu kullanarak bir layout slide'ını çoğaltabilirsiniz.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Türüne göre mevcut bir düzen slaytı al.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Düzen slaytını düzen slaytı koleksiyonunun sonuna kopyala.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Özet:** Layout slide'ları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, layout slide'larını oluşturma, yönetme ve iyileştirme konusunda tam kontrol sağlar.