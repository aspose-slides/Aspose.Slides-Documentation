---
title: "Mengonversi Presentasi PowerPoint ke Dokumen Word dalam Python via Java"
linktitle: "PowerPoint ke Word"
type: docs
weight: 110
url: /id/python-java/convert-powerpoint-to-word/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke Word
- presentasi ke Word
- PPT ke Word
- PPTX ke Word
- ODP ke Word
- PowerPoint ke DOCX
- PPT ke DOCX
- PPTX ke DOCX
- PowerPoint ke DOC
- simpan PPT sebagai DOCX
- simpan PPTX sebagai DOCX
- ekspor PPT ke DOCX
- ekspor PPTX ke DOCX
- Python
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke Word dalam Python via Java dengan Aspose.Slides dan Aspose.Words, menggabungkan gambar slide dengan teks yang dapat diedit."
---
## **Ringkasan**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint dan OpenDocument menjadi dokumen Word menggunakan Aspose.Slides for Python via Java bersama dengan Aspose.Words for Java. Aspose.Slides merender setiap slide dan membaca teksnya, sedangkan Aspose.Words membuat dokumen Word melalui JPype. Microsoft Office tidak diperlukan.

Dokumen yang dihasilkan berisi gambar slide diikuti oleh teks yang dapat diedit yang diambil dari auto shape tingkat atas pada slide tersebut. Gambar mempertahankan tampilan visual slide; bentuk individu, diagram, dan tabel tidak dikonversi menjadi objek Word yang dapat diedit. Teks yang diambil tidak mempertahankan pemformatan atau posisi teks asli.

## **Konversi PowerPoint ke Word**

1. Instal [Aspose.Slides for Python via Java](/slides/id/python-java/installation/) dan runtime Java yang kompatibel.
2. Unduh [Aspose.Words for Java](https://releases.aspose.com/words/java/). Tempatkan file JAR utama di direktori `lib` di samping skrip Anda dan ganti namanya menjadi `aspose-words.jar`, atau sesuaikan jalur dalam contoh agar cocok dengan file yang Anda unduh.
3. Tempatkan presentasi input, `sample.pptx`, di direktori kerja. Jalur `lib/aspose-words.jar` juga bersifat relatif terhadap direktori tersebut.
4. Jalankan kode Python berikut untuk membuat `output.docx`.

Contoh memuat sumber dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan merender slide dengan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage). Ia menggunakan [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) dari Aspose.Words untuk memasukkan gambar dan teks ke dalam dokumen Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Sesuaikan gambar slide dengan lebar area teks, mempertahankan rasio aspeknya.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Tambahkan teks biasa dari auto shape tingkat atas, termasuk kotak teks.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Setiap slide dimulai pada halaman baru. Teks yang diekstrak sangat panjang atau gambar slide yang tidak biasa tinggi dapat memerlukan halaman tambahan. Kode menambahkan pemecah halaman hanya di antara slide dan melepaskan presentasi serta gambar yang dirender dalam blok `finally`. JVM tetap tersedia untuk konversi berikutnya dalam proses Python yang sama.

## **FAQ**

**Perpustakaan apa yang diperlukan?**

Gunakan Aspose.Slides for Python via Java, JPype, runtime Java yang kompatibel, dan Aspose.Words for Java. Kedua perpustakaan Aspose berjalan dalam JVM yang sama. Aspose.Slides menangani presentasi; Aspose.Words menulis dokumen Word.

**Apakah saya dapat mengonversi file PPT dan ODP serta PPTX?**

Ya. Ganti `sample.pptx` dengan file PPT atau ODP. Lihat [Supported File Formats](/slides/id/python-java/supported-file-formats/) untuk format file presentasi yang didukung.

**Apakah semua konten slide dapat diedit di Word?**

Tidak. Setiap slide dimasukkan sebagai gambar statis, dengan teks biasa dari auto shape tingkat atas yang ditambahkan di bawahnya. Teks di dalam grup, tabel, SmartArt, dan diagram, serta catatan pembicara, tidak diekstrak oleh contoh ini. Animasi dan transisi tidak direproduksi dalam dokumen Word.

**Apakah saya dapat menyimpan sebagai DOC alih-alih DOCX?**

Ya. Ubah nama file output menjadi `output.doc`. Aspose.Words memilih format output dari ekstensi nama file saat menggunakan overload penyimpanan ini.