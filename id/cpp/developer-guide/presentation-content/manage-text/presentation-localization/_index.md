---
title: Otomatisasi Lokalisasi Presentasi dalam C++
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/cpp/presentation-localization/
keywords:
- mengubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Otomatisasi lokalisasi slide PowerPoint dan OpenDocument dalam C++ dengan Aspose.Slides, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengatur `LanguageId` untuk teks dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan shape dengan teks, menetapkan pengenal bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Presentasi dan Teks Shape**
- Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Rectangle ke slide.
- Tambahkan beberapa teks ke TextFrame.
- Menetapkan Language Id ke teks.
- Simpan presentasi sebagai file PPTX.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Apakah Language ID memicu terjemahan otomatis teks?**

Tidak. [Language ID](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) di Aspose.Slides menyimpan bahasa untuk pengecekan ejaan dan tata bahasa, namun tidak menerjemahkan atau mengubah isi teks. Ini merupakan metadata yang dipahami PowerPoint untuk keperluan proofing.

**Apakah Language ID memengaruhi hyphenation dan pemecahan baris saat rendering?**

Di Aspose.Slides, [Language ID](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) digunakan untuk proofing. Kualitas hyphenation dan pembungkusan baris terutama bergantung pada ketersediaan [font yang tepat](/slides/id/cpp/powerpoint-fonts/) serta pengaturan layout/pemecahan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [aturan substitusi font](/slides/id/cpp/font-substitution/), dan/atau [sematkan font](/slides/id/cpp/embedded-font/) ke dalam presentasi.

**Bisakah saya menetapkan bahasa yang berbeda dalam satu paragraf?**

Ya. [Language ID](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan proofing yang berbeda.