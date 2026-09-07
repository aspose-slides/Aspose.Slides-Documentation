---
title: "Konversi Presentasi PowerPoint ke SWF Flash dalam Python via Java"
linktitle: "PowerPoint ke SWF"
type: docs
weight: 80
url: /id/python-java/convert-powerpoint-to-swf-flash/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke SWF
- presentasi ke SWF
- slide ke SWF
- PPT ke SWF
- PPTX ke SWF
- PowerPoint ke Flash
- presentasi ke Flash
- slide ke Flash
- PPT ke Flash
- PPTX ke Flash
- simpan PPT sebagai SWF
- simpan PPTX sebagai SWF
- ekspor PPT ke SWF
- ekspor PPTX ke SWF
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke SWF Flash dalam Python via Java dengan Aspose.Slides. Konfigurasikan penampil, catatan, slide tersembunyi, kompresi, dan font."
---
## **Ringkasan**

Aspose.Slides for Python via Java memungkinkan Anda mengonversi presentasi PowerPoint ke SWF tanpa Microsoft PowerPoint. Gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk mengekspor presentasi dan [SwfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/) untuk mengonfigurasi pengaturan penampil, kualitas gambar, serta tata letak catatan atau komentar.

## **Konversi Presentasi ke Flash**

Muat file sumber dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), konfigurasikan [SwfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/), dan simpan menggunakan [SaveFormat.Swf](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Swf).

Contoh berikut mengekspor `presentation.pptx` ke `presentation.swf`. Itu menonaktifkan penampil tersemat dengan [setViewerIncluded](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setViewerIncluded) dan menyertakan catatan pembicara di bawah slide menggunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Sebelum menjalankan contoh, [install Aspose.Slides for Python via Java](/slides/id/python-java/installation/) dan letakkan `presentation.pptx` di direktori kerja. JVM dimulai satu kali per proses Python.

Contoh ini menerapkan [NotesPositions.BottomFull](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/#BottomFull) melalui [setNotesPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition), dan meneruskan tata letak ke [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Untuk menyertakan komentar juga, konfigurasikan [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) sebelum mengekspor.

## **FAQ**

**Bisakah saya menyertakan slide tersembunyi dalam SWF?**

Ya. Panggil [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) dengan `True`. Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan [SwfOptions.setCompressed](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setCompressed) untuk mengaktifkan atau menonaktifkan kompresi dan [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setJpegQuality) untuk menyesuaikan kualitas gambar JPEG. Kualitas JPEG yang lebih rendah dapat mengurangi ukuran file dengan mengorbankan ketajaman gambar.

**Apa fungsi penampil tersemat, dan kapan saya harus menonaktifkannya?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/#setViewerIncluded) mengontrol apakah SWF yang dihasilkan menyertakan penampil. Berikan `False` ketika Anda membutuhkan slide yang diekspor tanpa penampil tersemat, seperti pada contoh di atas.

**Apa yang terjadi jika font sumber tidak ada pada mesin ekspor?**

Anda dapat menentukan font reguler default dengan [setDefaultRegularFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), yang diwarisi oleh [SwfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/swfoptions/). Pilih font yang tersedia untuk proses ekspor; substitusi font dapat mengubah tampilan teks dan tata letak.