---
title: Gambar
type: docs
weight: 50
url: /id/python-net/examples/elements/picture/
keywords:
- gambar
- bingkai gambar
- tambah gambar
- akses gambar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan gambar di Python menggunakan Aspose.Slides: menyisipkan, mengganti, memotong, mengompresi, menyesuaikan transparansi dan efek, mengisi bentuk, serta mengekspor untuk PPT, PPTX, dan ODP."
---
Menampilkan cara menyisipkan dan mengakses gambar dari gambar dalam memori menggunakan **Aspose.Slides for Python via .NET**. Contoh‑contoh di bawah membuat gambar dalam memori, menempatkannya pada slide, dan kemudian mengambilnya.

## **Tambah Gambar**

Kode ini memuat gambar dari file dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Muat gambar dari file.
        with open("image.png", "rb") as image_stream:
            # Tambahkan gambar ke sumber daya presentasi.
            image = presentation.images.add_image(image_stream)

        # Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Gambar**

Contoh ini memastikan sebuah slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses bingkai gambar pertama pada slide.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```