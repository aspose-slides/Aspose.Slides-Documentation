---
title: Konversi Presentasi PowerPoint ke PDF dengan Catatan dalam Python
linktitle: PowerPoint ke PDF dengan Catatan
type: docs
weight: 50
url: /id/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- PPTX ke PDF
- simpan presentasi sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- catatan pembicara
- PDF dengan catatan
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke PDF dengan catatan pembicara menggunakan Aspose.Slides untuk Python via Java. Atur penempatan catatan dan pertahankan catatan panjang."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke PDF dengan catatan pembicara menggunakan Aspose.Slides untuk Python via Java. Anda dapat menyertakan catatan di bawah setiap slide dan memungkinkan catatan panjang melanjutkan ke halaman tambahan. Untuk pengaturan ekspor PDF lainnya, lihat [Convert PowerPoint to PDF](/slides/id/python-java/convert-powerpoint-to-pdf/).

## **Konversi PowerPoint ke PDF dengan Catatan**

Gunakan metode [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) untuk mengekspor presentasi PPT atau PPTX ke PDF. Untuk menyertakan catatan pembicara, buat objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/) dan konfigurasikan metode [setNotesPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Tetapkan tata letak ini ke [PdfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/) menggunakan [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Contoh berikut memuat `sample.pptx` dan mengekspornya ke `output.pdf` dengan catatan pembicara di bawah slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konfigurasikan opsi PDF untuk menampilkan catatan pembicara.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Simpan presentasi ke PDF dengan catatan pembicara.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Catatan" %}}
Anda juga dapat mencoba [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/id/conversion).
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat mencegah catatan pembicara yang panjang terpotong?**

Gunakan [NotesPositions.BottomFull](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/#BottomFull), seperti pada contoh di atas. Pengaturan ini menampilkan catatan secara lengkap, menggunakan halaman tambahan bila diperlukan.

**Bisakah saya menjaga setiap slide dan catatannya pada satu halaman?**

Gunakan [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/#BottomTruncated). Pengaturan ini membatasi catatan ke satu halaman, sehingga catatan yang tidak muat dapat terpotong.

**Bagaimana cara mengekspor slide tanpa catatan pembicara?**

Hapus konfigurasi tata letak catatan dan gunakan ekspor PDF standar yang dijelaskan dalam [Convert PowerPoint to PDF](/slides/id/python-java/convert-powerpoint-to-pdf/).