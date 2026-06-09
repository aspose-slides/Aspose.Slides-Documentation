---
title: Slayt
type: docs
weight: 10
url: /tr/python-net/examples/elements/slide/
keywords:
- slayt
- slayt ekle
- slayta eriş
- slayt indeksi
- slaytı klonla
- slaytları yeniden sırala
- slayt kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da slaytları yönetin: oluşturun, klonlayın, yeniden sıralayın, gizleyin, arka planları ve boyutu ayarlayın, geçişler uygulayın ve PowerPoint ile OpenDocument için dışa aktarın."
---
Bu makale, **Aspose.Slides for Python via .NET** kullanarak slaytlarla nasıl çalışılacağını gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, klonlama, yeniden sıralama ve kaldırma işlemlerini öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından Python'da bir kod snippet'i içerir.

## **Slayt Ekle**

Yeni bir slayt eklemek için önce bir düzen seçmelisiniz. Bu örnekte, `Blank` düzenini kullanıyor ve sunuma boş bir slayt ekliyoruz.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Her slayt, bir düzen üzerine inşa edilir ve bu düzen kendisi bir ana slayta dayanır.
        # Yeni bir slayt oluşturmak için Blank düzenini kullanın.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **İpucu:** Her slayt düzeni, genel tasarımı ve yer tutucu yapısını tanımlayan bir ana slayttan türetilir. Aşağıdaki görüntü, ana slaytların ve bunlara bağlı düzenlerin PowerPoint'te nasıl organize edildiğini gösterir.

![Ana Slayt ve Düzen İlişkisi](master-layout-slide.png)

## **İndeks ile Slaytlara Erişim**

Slaytlara indekslerini kullanarak erişebilirsiniz. Bu, slaytlar arasında döngü yaparken veya belirli slaytları değiştirirken faydalıdır.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # İndeksle bir slayta eriş.
        first_slide = presentation.slides[0]
```

## **Bir Slaytı Klonla**

Bu örnek, mevcut bir slaytı nasıl klonlayacağınızı gösterir. Klonlanan slayt, slayt koleksiyonunun sonuna otomatik olarak eklenir.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Slaytı klonla; sunumun sonuna eklenecek.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Slaytları Yeniden Sırala**

Bir slaytı yeni bir indekse taşıyarak slaytların sırasını değiştirebilirsiniz. Bu örnekte, bir slaytı ilk konuma taşıyoruz.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Slaytı ilk konuma taşı (diğerleri aşağı kayar).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Slaytı Kaldır**

Bir slaytı kaldırmak için, basitçe ona referans verip `remove` metodunu çağırın. Bu örnek, ilk slaytı kaldırır.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Slaytı kaldır.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```