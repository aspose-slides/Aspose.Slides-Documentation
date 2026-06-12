---
title: SmartArt
type: docs
weight: 140
url: /id/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- menambahkan SmartArt
- mengakses SmartArt
- menghapus SmartArt
- tata letak SmartArt
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bangun dan edit SmartArt di Python dengan Aspose.Slides: tambahkan node, ubah tata letak dan gaya, konversi ke bentuk dengan presisi, dan ekspor untuk PPT, PPTX, dan ODP."
---
Menunjukkan cara menambahkan grafik SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan SmartArt**

Masukkan grafik SmartArt menggunakan salah satu tata letak bawaan.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses SmartArt**

Ambil objek SmartArt pertama pada slide.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses bentuk SmartArt pertama.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Menghapus SmartArt**

Hapus bentuk SmartArt dari slide.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah objek SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengubah Tata Letak SmartArt**

Perbarui jenis tata letak grafik SmartArt yang ada.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah objek SmartArt.
        smart_art = slide.shapes[0]

        # Mengubah tata letak SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```