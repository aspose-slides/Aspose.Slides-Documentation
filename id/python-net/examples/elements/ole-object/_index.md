---
title: OleObject
type: docs
weight: 210
url: /id/python-net/examples/elements/ole-object/
keywords:
- objek OLE
- menambahkan objek OLE
- mengakses objek OLE
- menghapus objek OLE
- memperbarui objek OLE
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan objek OLE di Python menggunakan Aspose.Slides: menyisipkan atau memperbarui file yang disematkan, mengatur ikon atau tautan, mengekstrak konten, mengendalikan perilaku untuk PPT, PPTX, dan ODP."
---
Menunjukkan cara menyematkan file sebagai objek OLE dan memperbarui datanya menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah OLE Object**

Sematkan file PDF ke dalam presentasi.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Muat data PDF untuk disematkan.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Tambahkan bingkai objek OLE ke slide.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses OLE Object**

Ambil frame OLE object pertama pada slide.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Dapatkan bingkai objek OLE pertama pada slide.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Hapus OLE Object**

Hapus OLE object yang disematkan dari slide.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah objek OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Perbarui Data OLE Object**

Ganti data yang disematkan dalam OLE object yang sudah ada.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah objek OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Perbarui objek OLE dengan data tersemat baru.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```