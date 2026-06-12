---
title: Kelola Superskrip dan Subskrip dalam Presentasi Menggunakan C++
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/cpp/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambahkan superskrip
- tambahkan subskrip
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasai superskrip dan subskrip di Aspose.Slides untuk C++ dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti rumus kimia, persamaan matematika, atau memberi anotasi konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan presisi. Dalam artikel ini, Anda akan mempelajari cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil profesional di setiap slide.

## **Kelola Teks Superskrip dan Subskrip**

Anda dapat menambahkan teks superskrip dan subskrip di dalam bagian paragraf mana pun. Untuk menambahkan teks Superskrip atau Subskrip dalam bingkai teks Aspose.Slides, Anda harus menggunakan properti **Escapement** dari kelas PortionFormat.

Properti ini mengembalikan atau mengatur teks superskrip atau subskrip (nilai dari -100% (subskrip) hingga 100% (superskrip). Contoh :

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan IAutoShape tipe Rectangle ke slide.
- Akses ITextFrame yang terkait dengan IAutoShape.
- Hapus Paragraph yang ada
- Buat objek paragraf baru untuk menampung teks superskrip dan tambahkan ke koleksi IParagraphs pada ITextFrame.
- Buat objek portion baru
- Atur properti Escapement untuk portion antara 0 hingga 100 untuk menambahkan superskrip. (0 berarti tidak ada superskrip)
- Tetapkan teks untuk Portion dan kemudian tambahkan ke koleksi portion pada paragraf.
- Buat objek paragraf baru untuk menampung teks subskrip dan tambahkan ke koleksi IParagraphs pada ITextFrame.
- Buat objek portion baru
- Atur properti Escapement untuk portion antara 0 hingga -100 untuk menambahkan subskrip. (0 berarti tidak ada subskrip)
- Tetapkan teks untuk Portion dan kemudian tambahkan ke koleksi portion pada paragraf.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah ini.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**Apakah superskrip dan subskrip akan dipertahankan saat mengekspor ke PDF atau format lain?**

Ya, Aspose.Slides secara tepat mempertahankan pemformatan superskrip dan subskrip ketika mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh di semua file output.

**Dapatkah superskrip dan subskrip digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan secara bersamaan menerapkan superskrip atau subskrip dengan mengkonfigurasi properti yang sesuai di [PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip bekerja untuk teks di dalam tabel, diagram, atau SmartArt?**

Ya, Aspose.Slides mendukung pemformatan dalam sebagian besar objek, termasuk elemen tabel dan diagram. Saat bekerja dengan SmartArt, Anda perlu mengakses elemen yang tepat (seperti [SmartArtNode](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartnode/)) dan kontainer teksnya, lalu mengkonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/portionformat/) dengan cara yang serupa.