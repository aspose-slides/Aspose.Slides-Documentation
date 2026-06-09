---
title: Hiperlink
type: docs
weight: 130
url: /tr/python-net/examples/elements/hyperlink/
keywords:
- hiperlink
- hiperlink ekle
- hiperlink erişimi
- hiperlink kaldır
- hiperlink güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da hiperlink ekleyin, düzenleyin ve kaldırın: metin bağlantısı, şekiller, slaytlar, URL'ler ve e-posta; PPT, PPTX ve ODP için hedef ve eylemler ayarlayın."
---
Şekillerdeki hiperlinkleri ekleme, erişme, kaldırma ve güncelleme işlemlerini **Aspose.Slides for Python via .NET** kullanarak gösterir.

## **Hiperlink Ekle**

Harici bir web sitesine yönelen bir hiperlink içeren bir dikdörtgen şekli oluşturun.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperlink Erişimi**

Bir şeklin metin bölümünden hiperlink bilgilerini okuyun.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Hiperlink'i Kaldır**

Bir şeklin metnindeki hiperlinki temizleyin.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperlink'i Güncelle**

Mevcut bir hiperlinkin hedefini değiştirin. PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme şeklini taklit eden `HyperlinkManager`'ı kullanarak, zaten bir hiperlink içeren metni değiştirin.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Mevcut metin içindeki bir hiperlinkin değiştirilmesi şu şekilde yapılmalıdır
        # HyperlinkManager kullanılarak, özelliği doğrudan ayarlamaktan kaçınılmalıdır.
        # Bu, PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme şeklini taklit eder.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```