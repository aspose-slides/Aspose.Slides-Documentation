---
title: Mengonversi Presentasi OpenDocument di Python
linktitle: Konversi OpenDocument
type: docs
weight: 10
url: /id/python-java/convert-openoffice-odp/
keywords:
- konversi ODP
- ODP ke PDF
- ODP ke HTML
- ODP ke TIFF
- ODP ke PPT
- ODP ke PPTX
- ODP ke XPS
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi OpenDocument (ODP) ke PDF, HTML, dan format lainnya dengan Aspose.Slides untuk Python via Java, tanpa harus menginstal OpenOffice atau LibreOffice."
---
## **Pendahuluan**

Aspose.Slides for Python via Java memungkinkan Anda mengonversi presentasi OpenDocument (ODP) ke format seperti PDF, HTML, TIFF, XPS, PPT, dan PPTX. Konversi ODP menggunakan API yang sama seperti konversi PowerPoint: muat file sumber dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan pilih format output dengan [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/).

## **Konversi ODP ke PDF**

Ikuti [installation instructions](/slides/id/python-java/installation/) sebelum menjalankan contoh. Letakkan presentasi ODP bernama `pres.odp` di direktori kerja. Kode berikut memulai JVM jika diperlukan, memuat presentasi, dan menyimpannya sebagai `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Presentasi OpenDocument di Berbagai Aplikasi**

Presentasi ODP dapat terlihat berbeda di PowerPoint dan LibreOffice/OpenOffice Impress karena aplikasi-aplikasi ini mendukung fitur presentasi dan perilaku rendering yang berbeda. Tinjau presentasi yang dikonversi ketika tata letaknya bergantung pada pemformatan yang kompleks.

Perbedaan kompatibilitas dapat memengaruhi:

- Tabel, termasuk urutan tumpukannya relatif terhadap bentuk lain dan dukungan untuk isian gambar.
- Rotasi dan perataan teks.
- Isian gambar, gradasi, dan pola yang diterapkan pada teks.
- Daftar bernomor dan berbutir.

Gambar di bawah menunjukkan daftar yang dibuat di LibreOffice Impress:

![Contoh daftar ODP di LibreOffice Impress](odp-list-example.png)

Aspose.Slides menyimpan daftar ODP untuk kompatibilitas dengan LibreOffice/OpenOffice Impress.

Untuk detail tentang kompatibilitas fitur, lihat [Panduan Microsoft tentang format Presentasi OpenDocument](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Bagaimana jika pemformatan file ODP saya berubah setelah konversi?**

ODP dan PowerPoint menggunakan model presentasi yang berbeda. Tabel, font, dan gaya isian dapat ditampilkan secara berbeda. Pastikan font yang diperlukan tersedia, tinjau output, dan sesuaikan tata letak atau pemformatan jika diperlukan.

**Apakah saya perlu menginstal OpenOffice atau LibreOffice untuk mengonversi file ODP?**

Tidak. Aspose.Slides for Python via Java memproses presentasi tanpa aplikasi tersebut. Diperlukan runtime Java yang kompatibel dan paket Python.

**Bisakah saya menyesuaikan output PDF saat mengonversi presentasi ODP?**

Ya. Gunakan [PdfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/) untuk mengonfigurasi pengaturan ekspor PDF, seperti kualitas gambar dan kompresi.

**Bisakah saya mengonversi presentasi ODP di server atau dalam kontainer?**

Ya. Instal paket Python, runtime Java yang kompatibel, serta font yang diperlukan oleh presentasi Anda di lingkungan target. Tidak diperlukan aplikasi office.