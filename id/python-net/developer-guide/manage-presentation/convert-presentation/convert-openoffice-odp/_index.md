---
title: Konversi Presentasi OpenDocument di Python
linktitle: Konversi OpenDocument
type: docs
weight: 10
url: /id/python-net/convert-openoffice-odp/
keywords:
- konversi OpenDocument
- konversi ODP
- ODP ke PDF
- ODP ke PPT
- ODP ke PPTX
- ODP ke XPS
- ODP ke HTML
- ODP ke TIFF
- ODP ke SWF
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Konversi OpenDocument ODP ke PDF, PPT, PPTX, XPS, HTML, TIFF, atau SWF di Python dengan Aspose.Slides: contoh kode, kesetiaan tinggi, konversi batch, dan penyesuaian."
---
## **Pendahuluan**

[**Aspose.Slides API**](https://products.aspose.com/slides/id/python-net/) memungkinkan Anda mengonversi presentasi OpenDocument (ODP) ke banyak format (HTML, PDF, TIFF, SWF, XPS, dll.). API yang digunakan untuk mengonversi file ODP ke format dokumen lain sama dengan yang digunakan untuk operasi konversi PowerPoint (PPT dan PPTX).

Sebagai contoh, jika Anda perlu mengonversi presentasi ODP ke PDF, Anda dapat melakukannya sebagai berikut:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Apakah saya dapat mengonversi ODP ke PPTX tanpa menginstal LibreOffice atau OpenOffice?**

Ya. Aspose.Slides adalah pustaka mandiri penuh yang menangani format PowerPoint dan OpenOffice tanpa memerlukan aplikasi eksternal apa pun.

**Apakah Aspose.Slides dapat membuka dan menyimpan file ODP/OTP yang dilindungi kata sandi?**

Ya. Itu dapat [memuat presentasi terenkripsi](/slides/id/python-net/password-protected-presentation/) ketika Anda memberikan kata sandi dan juga dapat menyimpan presentasi dengan pengaturan enkripsi dan perlindungan.

**Apakah saya dapat mengekstrak file media tersemat (audio/video) dari ODP sebelum mengonversinya?**

Ya. Aspose.Slides memungkinkan Anda mengakses dan mengekstrak [audio](/slides/id/python-net/audio-frame/) dan [video](/slides/id/python-net/video-frame/) dari presentasi, yang berguna untuk pemrosesan pra‑konversi atau penggunaan terpisah.

**Apakah saya dapat menyimpan ODP yang dikonversi sebagai Strict Office Open XML?**

Ya. Saat menyimpan ke PPTX Anda dapat mengaktifkan Strict OOXML melalui [opsi penyimpanan](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/) untuk memenuhi persyaratan kepatuhan yang lebih ketat.