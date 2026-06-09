---
title: Resim
type: docs
weight: 50
url: /tr/python-net/examples/elements/picture/
keywords:
- resim
- resim çerçevesi
- resim ekle
- resme eriş
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da resimlerle çalışın: ekleme, değiştirme, kırpma, sıkıştırma, şeffaflığı ve efektleri ayarlama, şekilleri doldurma ve PPT, PPTX ve ODP için dışa aktarma."
---
Bellek içi görüntülerden resim ekleme ve erişme işlemlerinin **Aspose.Slides for Python via .NET** kullanılarak nasıl yapılacağını gösterir. Aşağıdaki örnekler bir resmi bellek içinde oluşturur, bir slayta yerleştirir ve ardından alır.

## **Resim Ekle**

Bu kod, bir dosyadan resmi yükler ve ilk slayta bir resim çerçevesi olarak ekler.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dosyadan bir görüntü yükle.
        with open("image.png", "rb") as image_stream:
            # Görüntüyü sunum kaynaklarına ekle.
            image = presentation.images.add_image(image_stream)

        # İlk slaytta görüntüyü gösteren bir resim çerçevesi ekle.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Resme Erişme**

Bu örnek, bir slaytın bir resim çerçevesi içerdiğini doğrular ve ardından bulduğu ilk çerçeveye erişir.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk resim çerçevesine eriş.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```