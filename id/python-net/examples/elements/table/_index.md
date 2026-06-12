---
title: Tabel
type: docs
weight: 120
url: /id/python-net/examples/elements/table/
keywords:
- tabel
- tambahkan tabel
- akses tabel
- hapus tabel
- gabungkan sel
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat dan format tabel di Python dengan Aspose.Slides: sisipkan data, gabungkan sel, gaya batas, sejajarkan konten, serta impor/ekspor untuk PPT, PPTX, dan ODP."
---
Contoh menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan Tabel**

Buat tabel sederhana dengan dua baris dan dua kolom.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tentukan lebar kolom dan tinggi baris.
        widths = [80, 80]
        heights = [30, 30]

        # Tambahkan bentuk tabel ke slide.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Tabel**

Ambil bentuk tabel pertama pada slide.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses tabel pertama pada slide.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Menghapus Tabel**

Hapus tabel dari slide.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah tabel.
        table = slide.shapes[0]

        # Hapus tabel dari slide.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Menggabungkan Sel Tabel**

Gabungkan sel-sel bersebelahan dalam tabel menjadi satu sel.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah tabel.
        table = slide.shapes[0]

        # Gabungkan sel.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```