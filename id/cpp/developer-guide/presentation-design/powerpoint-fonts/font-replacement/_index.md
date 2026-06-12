---
title: Permudah Penggantian Font dalam Presentasi Menggunakan С++
linktitle: Penggantian Font
type: docs
weight: 60
url: /id/cpp/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- С++
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk С++ guna memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Saat sebuah font diganti, semua instance font asli diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tetapkan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang telah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda sengaja ingin beralih dari satu keluarga font ke keluarga lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan digantikan oleh font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan. 
2. Muat font yang akan diganti. 
3. Muat font baru. 
4. Ganti font. 
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ berikut mendemonstrasikan penggantian font:

``` cpp
// Memuat presentasi
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Memuat font sumber yang akan diganti
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Memuat font baru
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Mengganti font
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Menyimpan presentasi
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Font Substitution**](/slides/id/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "font replacement", "font substitution", dan "fallback fonts"?**

Penggantian adalah perpindahan yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitution](/slides/id/cpp/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/cpp/fallback-font/) diterapkan secara khusus untuk glyph yang hilang secara individu ketika font dasar terpasang tetapi tidak berisi karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya, Excel)?**

Tidak. [OLE content](/slides/id/cpp/manage-ole/) dikendalikan oleh aplikasinya sendiri. Penggantian dalam presentasi tidak mengubah format data OLE internal; itu dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Bisakah saya mengganti font hanya pada sebagian presentasi (per slide atau wilayah)?**

Penggantian terarah dimungkinkan jika Anda mengubah font pada tingkat objek/jangkauan yang diperlukan alih-alih menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana saya dapat menentukan sebelumnya font apa saja yang digunakan presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) milik presentasi: ia menyediakan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) dan informasi tentang [substitusi/"unknown" fonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getsubstitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan [urutan pemilihan/substitusi font](/slides/id/cpp/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya perlu menginstal font target di sistem, atau dapat saya melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/cpp/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/cpp/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) alih-alih karakter?**

Hanya jika font target sebenarnya berisi glyph yang diperlukan. Jika tidak, [konfigurasikan fallback](/slides/id/cpp/fallback-font/) untuk menutupi karakter yang hilang.