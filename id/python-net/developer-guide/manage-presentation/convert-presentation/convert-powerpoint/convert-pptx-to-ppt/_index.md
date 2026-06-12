---
title: Konversi PPTX ke PPT di Python
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/python-net/convert-pptx-to-ppt/
keywords:
- PPTX ke PPT
- konversi PPTX ke PPT
- konversi PowerPoint
- konversi presentasi
- Python
- Aspose.Slides
description: "Dengan mudah konversi PPTX ke PPT menggunakan Aspose.Slides untuk Python via .NET—pastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Overview**

Aspose.Slides for Python memungkinkan Anda mengonversi presentasi PPTX modern ke format PPT lama sepenuhnya melalui kode. Buka file PPTX dan ekspor sebagai PPT sambil mempertahankan konten dan tata letak presentasi, sehingga hasilnya kompatibel dengan versi PowerPoint yang lebih lama. Alur kerja yang sama dapat menghasilkan output lain—seperti PDF, XPS, ODP, HTML, atau gambar—sehingga mudah diintegrasikan ke dalam skrip, pipeline CI, dan pemrosesan batch.

## **Convert PPTX to PPT**

Untuk mengonversi PPTX ke PPT, cukup berikan nama file dan format penyimpanan ke metode [save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) pada kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Contoh Python di bawah mengonversi presentasi dari PPTX ke PPT menggunakan opsi default.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PPTX.
presentation = slides.Presentation("presentation.pptx")

# Simpan presentasi sebagai file PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**Do all PPTX effects and features survive when saving to the legacy PPT (97–2003) format?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan baru (misalnya, efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau dirasterisasi selama konversi.

**Can I convert only selected slides to PPT instead of the entire presentation?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru yang hanya berisi slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Are password-protected presentations supported?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan password, dan juga [konfigurasi pengaturan perlindungan/enkripsi](/slides/id/python-net/password-protected-presentation/) untuk PPT yang disimpan.

**See also:**
- [Konversi PPT & PPTX ke PDF di Python | Opsi Lanjutan](/slides/id/python-net/convert-powerpoint-to-pdf/)
- [Konversi Presentasi PowerPoint ke XPS di Python](/slides/id/python-net/convert-powerpoint-to-xps/)
- [Konversi Presentasi PowerPoint ke HTML di Python](/slides/id/python-net/convert-powerpoint-to-html/)
- [Konversi Slide PowerPoint ke PNG di Python](/slides/id/python-net/convert-powerpoint-to-png/)