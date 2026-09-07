---
title: Konversi PPTX ke PPT dalam Python
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/python-java/convert-pptx-to-ppt/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPTX
- PPTX ke PPT
- simpan PPTX sebagai PPT
- ekspor PPTX ke PPT
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Konversi PPTX ke format PPT lama dalam Python dengan Aspose.Slides untuk Python via Java. Menyertakan contoh kode dan catatan tentang kompatibilitas serta file yang dilindungi."
---
## **Ikhtisar**

Aspose.Slides untuk Python via Java memungkinkan Anda mengonversi presentasi PPTX ke format PPT lama yang digunakan oleh PowerPoint 97–2003 tanpa harus menginstal Microsoft PowerPoint. Muat file PPTX dan simpan dengan format output PPT, seperti ditunjukkan di bawah.

## **Konversi PPTX ke PPT**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) , lalu panggil [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan jalur output dan [SaveFormat.Ppt](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Ppt) .

Contoh berikut memulai mesin virtual Java bila diperlukan dan mengonversi `template.pptx` ke `output.ppt` menggunakan opsi default. Ganti jalur dengan nama file Anda sendiri. Blok `finally` melepaskan sumber daya presentasi meskipun penyimpanan gagal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Muat presentasi PPTX.
presentation = Presentation("template.pptx")
try:
    # Simpan presentasi dalam format PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Argumen [SaveFormat.Ppt](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Ppt) menentukan format output; mengubah ekstensi file saja tidak mengonversi presentasi. Simpan file PPTX asli sehingga Anda dapat kembali ke sana jika fitur baru tidak memiliki padanan di PPT.

## **Konversi PPTX ke Format Lain**

Aspose.Slides juga mendukung format output lainnya. Lihat artikel terkait untuk opsi dan contoh spesifik format:

- [Konversi PowerPoint ke PDF dalam Python](/slides/id/python-java/convert-powerpoint-to-pdf/)
- [Konversi PowerPoint ke XPS dalam Python](/slides/id/python-java/convert-powerpoint-to-xps/)
- [Konversi PowerPoint ke HTML dalam Python](/slides/id/python-java/convert-powerpoint-to-html/)
- [Simpan Presentasi sebagai ODP dalam Python](/slides/id/python-java/save-presentation/)
- [Konversi PowerPoint ke PNG dalam Python](/slides/id/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada setelah konversi ke PPT?**

Tidak selalu. Format PPT lama tidak mendukung setiap fitur yang tersedia di PPTX. Beberapa efek, objek, atau perilaku mungkin disederhanakan atau ditampilkan secara berbeda. Tinjau presentasi yang telah dikonversi di penampil yang dimaksud, terutama bila mengandung fitur PowerPoint terbaru.

**Bisakah saya mengonversi hanya slide tertentu ke PPT?**

Menyimpan ke PPT menulis seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru, hapus slide kosong awalnya, kloning slide yang diperlukan ke dalamnya, dan simpan sebagai PPT. Lihat [Clone Slides in Python](/slides/id/python-java/clone-slides/) .

**Bisakah saya mengonversi file PPTX yang dilindungi kata sandi?**

Ya, jika Anda memberikan kata sandi yang benar saat memuat presentasi sumber. Anda juga dapat mengonfigurasi perlindungan untuk file output. Lihat [Password-Protected Presentations](/slides/id/python-java/password-protected-presentation/) .