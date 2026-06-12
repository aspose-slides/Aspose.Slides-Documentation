---
title: GroupShape
type: docs
weight: 170
url: /id/python-net/examples/elements/group-shape/
keywords:
- grup
- menambahkan bentuk grup
- mengakses bentuk grup
- menghapus bentuk grup
- membongkar bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan grup bentuk di Python menggunakan Aspose.Slides: membuat dan membongkar, menyusun ulang bentuk anak, mengatur transformasi dan batas di seluruh PowerPoint dan OpenDocument."
---
Contoh membuat grup bentuk, mengaksesnya, membongkar grup, dan menghapus menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan Grup Bentuk**

Buat grup yang berisi dua bentuk dasar.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan grup bentuk.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Grup Bentuk**

Ambil grup bentuk pertama dari slide.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses grup bentuk pertama pada slide.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Menghapus Grup Bentuk**

Hapus grup bentuk dari slide.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah grup bentuk.
        group = slide.shapes[0]

        # Hapus grup bentuk.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Membongkar Bentuk**

Pindahkan bentuk keluar dari kontainer grup.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah grup bentuk.
        group = slide.shapes[0]

        # Pindahkan bentuk keluar dari grup.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```