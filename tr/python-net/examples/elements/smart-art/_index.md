---
title: SmartArt
type: docs
weight: 140
url: /tr/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt ekle
- SmartArt eriş
- SmartArt kaldır
- SmartArt düzeni
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da SmartArt oluşturun ve düzenleyin: düğüm ekleyin, düzen ve stilleri değiştirin, şekillere hassas bir şekilde dönüştürün ve PPT, PPTX ve ODP için dışa aktarın."
---
Aspose.Slides for Python via .NET kullanarak SmartArt grafikleri ekleme, erişme, kaldırma ve düzenleri değiştirme yöntemini gösterir.

## **SmartArt Ekle**

Yerleşik düzenlerden birini kullanarak bir SmartArt grafiği ekleyin.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt'a Erişim**

Bir slayttaki ilk SmartArt nesnesini alın.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk SmartArt şekline eriş.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **SmartArt'ı Kaldır**

SmartArt şeklini slayttan silin.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir SmartArt nesnesi olduğunu varsayalım.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt Düzenini Değiştir**

Mevcut bir SmartArt grafiğinin düzen türünü güncelleyin.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir SmartArt nesnesi olduğunu varsayalım.
        smart_art = slide.shapes[0]

        # SmartArt düzenini değiştir.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```