---
title: Penghubung
type: docs
weight: 190
url: /id/python-net/examples/elements/connector/
keywords:
- penghubung
- menambah penghubung
- akses penghubung
- hapus penghubung
- sambungkan ulang bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Gambar dan kendalikan penghubung dalam Python dengan Aspose.Slides: tambahkan, atur jalur, ubah jalur, tetapkan titik koneksi, panah, dan gaya untuk menghubungkan bentuk dalam PPT, PPTX, dan ODP."
---
Menampilkan cara menghubungkan bentuk dengan penghubung dan mengubah targetnya menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah Penghubung**

Sisipkan bentuk penghubung di antara dua titik pada slide.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan bentuk penghubung bengkok.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Penghubung**

Ambil bentuk penghubung pertama yang ditambahkan ke slide.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses penghubung pertama pada slide.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Hapus Penghubung**

Hapus penghubung dari slide.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah penghubung.
        connector = slide.shapes[0]

        # Hapus penghubung.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sambungkan Ulang Bentuk**

Lampirkan penghubung ke dua bentuk dengan menetapkan target awal dan akhir.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Tambahkan bentuk persegi panjang pertama.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Tambahkan bentuk persegi panjang kedua.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Tambahkan bentuk penghubung bengkok.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Hubungkan awal penghubung ke bentuk pertama.
        connector.start_shape_connected_to = shape1
        # Hubungkan akhir penghubung ke bentuk kedua.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```