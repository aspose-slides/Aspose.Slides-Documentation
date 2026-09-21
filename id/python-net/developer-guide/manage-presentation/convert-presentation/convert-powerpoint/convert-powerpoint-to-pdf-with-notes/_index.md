---
title: Konversi Presentasi ke PDF dengan Catatan dalam Python
linktitle: Presentasi ke PDF dengan Catatan
type: docs
weight: 50
url: /id/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- konversi PPT
- konversi PPTX
- konversi ODP
- PowerPoint ke PDF
- OpenDocument ke PDF
- presentasi ke PDF
- PPT ke PDF
- PPTX ke PDF
- ODP ke PDF
- catatan pembicara
- PDF dengan catatan
- Python
- Aspose.Slides
description: "Konversi format PPT, PPTX, dan ODP ke PDF dengan catatan menggunakan Aspose.Slides untuk Python. Pertahankan tata letak dan catatan pembicara untuk presentasi profesional."
---
## **Ikhtisar**

Dalam artikel ini, Anda akan belajar cara mengonversi presentasi PowerPoint ke format PDF dengan catatan pembicara menggunakan Aspose.Slides. Panduan ini akan mencakup langkah‑langkah yang diperlukan dan menyediakan contoh kode untuk membantu Anda menyelesaikan tugas ini secara efisien. Pada akhir artikel ini, Anda akan dapat:

- Menerapkan proses konversi untuk mengubah slide PowerPoint menjadi dokumen PDF sambil mempertahankan catatan pembicara.
- Menyesuaikan PDF output agar catatan pembicara disertakan dan diformat sesuai kebutuhan Anda.

Untuk mengatur dimensi dan orientasi halaman catatan sebelum ekspor, lihat [Ukuran Halaman Catatan](/slides/id/python-net/notes-size/).

## **Konversi PowerPoint ke PDF dengan Catatan**

Metode `save` dalam kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dapat digunakan untuk mengonversi presentasi PPT atau PPTX ke PDF dengan catatan pembicara. Dengan Aspose.Slides, Anda cukup memuat presentasi, mengonfigurasi opsi tata letak menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/) untuk menyertakan catatan pembicara, dan kemudian menyimpan file sebagai PDF. Potongan kode berikut menunjukkan cara mengonversi contoh presentasi ke PDF dalam tampilan Slide Catatan.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Konfigurasi opsi PDF untuk merender catatan pembicara.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Simpan presentasi ke PDF dengan catatan pembicara.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Catatan" %}}
Anda mungkin ingin melihat Aspose [Konverter PowerPoint ke PDF Online](https://products.aspose.app/slides/id/conversion).
{{% /alert %}}