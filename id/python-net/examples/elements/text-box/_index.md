---
title: Kotak Teks
type: docs
weight: 40
url: /id/python-net/examples/elements/text-box/
keywords:
- kotak teks
- tambahkan kotak teks
- akses kotak teks
- hapus kotak teks
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat dan format kotak teks dalam Python dengan Aspose.Slides: atur font, perataan, pembungkusan, penyesuaian otomatis, dan tautan untuk memperbaiki slide pada PowerPoint dan OpenDocument."
---
Di Aspose.Slides, **text box** direpresentasikan oleh sebuah `AutoShape`. Hampir semua bentuk dapat berisi teks, tetapi text box tipikal tidak memiliki isi atau bingkai dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambahkan, mengakses, dan menghapus text box secara programatis.

## **Menambahkan Text Box**

Text box hanyalah sebuah `AutoShape` tanpa isi atau bingkai dan dengan beberapa teks yang diformat. Berikut cara membuatnya:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Buat bentuk persegi panjang (default terisi dengan garis tepi dan tanpa teks).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Hapus isi dan garis tepi agar tampak seperti kotak teks tipikal.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Atur format teks.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Tetapkan konten teks sebenarnya.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` tidak kosong dapat berfungsi sebagai text box.

## **Mengakses Text Box Berdasarkan Konten**

Untuk menemukan semua text box yang berisi kata kunci tertentu (misalnya "Slide"), iterasi melalui shape dan periksa teksnya:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Hanya AutoShape yang dapat berisi teks yang dapat diedit.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Lakukan sesuatu dengan kotak teks yang cocok.
                    pass
```

## **Menghapus Text Box Berdasarkan Konten**

Contoh ini menemukan dan menghapus semua text box pada slide pertama yang berisi kata kunci tertentu:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Temukan shape untuk dihapus yang merupakan AutoShape yang berisi kata "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Hapus setiap shape yang cocok dari slide.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Selalu buat salinan koleksi shape sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.