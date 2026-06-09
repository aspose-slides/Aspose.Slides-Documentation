---
title: Grup Şekli
type: docs
weight: 170
url: /tr/python-net/examples/elements/group-shape/
keywords:
- grup
- grup şekli ekle
- grup şekline eriş
- grup şekli kaldır
- şekilleri gruptan çıkar
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da grup şekilleriyle çalışın: oluşturun ve gruptan çıkarın, alt şekilleri yeniden sıralayın, PowerPoint ve OpenDocument içinde dönüşümleri ve sınırları ayarlayın."
---
Şekil grupları oluşturma, onlara erişme, gruplamayı kaldırma ve silme örnekleri **Aspose.Slides for Python via .NET** kullanılarak.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Grup şekli ekle.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Grup Şekline Eriş**

Bir slayttan ilk grup şeklini alın.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk grup şekline eriş.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Grup Şekli Kaldır**

Grup şeklini slayttan silin.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir grup şekli olduğunu varsayarak.
        group = slide.shapes[0]

        # Grup şekli kaldır.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekilleri Gruplamadan Çıkar**

Şekilleri bir grup kapsayıcısından dışarı taşıyın.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir grup şekli olduğunu varsayarak.
        group = slide.shapes[0]

        # Şekilleri grup dışına taşı.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```