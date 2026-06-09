---
title: OleNesnesi
type: docs
weight: 210
url: /tr/python-net/examples/elements/ole-object/
keywords:
- OLE nesnesi
- OLE nesnesi ekle
- OLE nesnesine eriş
- OLE nesnesini kaldır
- OLE nesnesini güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak OLE nesneleriyle çalışın: gömülü dosyaları ekleyin veya güncelleyin, simgeler veya bağlantılar ayarlayın, içeriği çıkarın, PPT, PPTX ve ODP için davranışı kontrol edin."
---
Bir dosyayı OLE nesnesi olarak gömmeyi ve verilerini **Aspose.Slides for Python via .NET** kullanarak güncellemeyi gösterir.

## **Add an OLE Object**
Bir PDF dosyasını sunuma göm.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Gömülecek PDF verilerini yükle.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Slayta bir OLE nesne çerçevesi ekle.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an OLE Object**
Bir slayttaki ilk OLE nesne çerçevesini alın.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk OLE nesne çerçevesini al.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Remove an OLE Object**
Gömülü bir OLE nesnesini slayttan sil.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir OleObjectFrame nesnesi olduğunu varsayarak.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update OLE Object Data**
Mevcut bir OLE nesnesine gömülü verileri değiştir.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir OleObjectFrame nesnesi olduğunu varsayarak.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # OLE nesnesini yeni gömülü veriyle güncelle.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```