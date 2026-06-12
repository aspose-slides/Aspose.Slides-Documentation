---
title: Konversi Presentasi PowerPoint ke SWF Flash di Python
linktitle: PowerPoint ke SWF Flash
type: docs
weight: 80
url: /id/python-net/convert-powerpoint-to-swf-flash/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- PowerPoint ke SWF
- presentasi ke SWF
- slide ke SWF
- PPT ke SWF
- PPTX ke SWF
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Konversi PowerPoint (PPT/PPTX) ke SWF Flash di Python dengan Aspose.Slides. Contoh kode langkah demi langkah, output berkualitas cepat, tanpa otomasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyimpan presentasi sebagai file SWF dengan metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) dan cara mengonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Konversi Presentasi ke Flash**

Metode [save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen SWF. Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan dengan menggunakan kelas [SWFOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/) dan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/). Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen SWF dengan menggunakan opsi yang disediakan oleh kelas SWFOptions.

```py
import aspose.slides as slides

# Buat objek Presentation yang mewakili file presentasi
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Menyimpan presentasi dan halaman catatan
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Aktifkan opsi [show_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) di [SwfOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan flag [compressed](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/compressed/) (diaktifkan secara default) dan sesuaikan [jpeg_quality](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/jpeg_quality/) untuk menyeimbangkan ukuran file dan kualitas gambar.

**Untuk apa 'viewer_included', dan kapan saya harus menonaktifkannya?**

[viewer_included](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/viewer_included/) menambahkan antarmuka pemutar tersemat (kontrol navigasi, panel, pencarian). Nonaktifkan jika Anda berencana menggunakan pemutar Anda sendiri atau membutuhkan kerangka SWF tanpa UI.

**Apa yang terjadi jika font sumber tidak ada di mesin ekspor?**

Aspose.Slides akan menggantikan font yang Anda tentukan melalui [default_regular_font](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/default_regular_font/) di [SwfOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/swfoptions/) untuk menghindari fallback yang tidak diinginkan.