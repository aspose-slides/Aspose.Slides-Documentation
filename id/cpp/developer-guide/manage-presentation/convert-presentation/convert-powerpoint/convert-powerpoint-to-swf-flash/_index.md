---
title: Mengonversi Presentasi PowerPoint ke SWF Flash dalam C++
linktitle: PowerPoint ke SWF
type: docs
weight: 80
url: /id/cpp/convert-powerpoint-to-swf-flash/
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
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Mengonversi PowerPoint (PPT/PPTX) ke SWF Flash dalam C++ dengan Aspose.Slides. Contoh kode langkah‑demi‑langkah, output berkualitas cepat, tanpa otomasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Ini menunjukkan cara menyimpan presentasi sebagai file SWF dengan metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) dan cara mengonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Mengonversi Presentasi ke Flash**

Metode [Save](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen SWF. Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan dengan menggunakan kelas [SWFOptions](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.swf_options) dan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/). Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen SWF dengan menggunakan opsi yang disediakan oleh kelas SWFOptions.

```cpp
// Jalur ke direktori dokumen.
    System::String dataDir = GetDataPath();

    // Buat objek Presentation yang mewakili file presentasi
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Menyimpan halaman presentasi dan catatan
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Gunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) dalam [SwfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan metode [set_Compressed](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/set_compressed/) dan sesuaikan [JPEG quality](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/set_jpegquality/) untuk menyeimbangkan ukuran file dan kualitas gambar.

**Untuk apa 'set_ViewerIncluded' dan kapan harus menggunakannya?**

[set_ViewerIncluded](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) menambahkan UI pemutar tersemat (kontrol navigasi, panel, pencarian). Nonaktifkan jika Anda berencana menggunakan pemutar sendiri atau membutuhkan kerangka SWF tanpa UI.

**Apa yang terjadi jika font sumber tidak ada pada mesin ekspor?**

Aspose.Slides akan mengganti font yang Anda tentukan melalui [set_DefaultRegularFont](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dalam [SwfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/swfoptions/) untuk menghindari fallback yang tidak diinginkan.