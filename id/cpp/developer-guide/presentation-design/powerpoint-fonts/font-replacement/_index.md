---
title: Menyederhanakan Penggantian Font dalam Presentasi Menggunakan C++
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
- C++
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk C++ guna memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua instance font asli diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang telah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda dengan sengaja ingin beralih dari satu keluarga font ke keluarga font lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan diganti dengan font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan. 
2. Muat font yang akan diganti.
3. Muat font baru. 
4. Ganti font. 
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan contoh penggantian font:

``` cpp
// Muat presentasi
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Muat font sumber yang akan diganti
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Muat font baru
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Ganti font
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Simpan presentasi
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Font Substitution**](/slides/id/cpp/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "font replacement", "font substitution", dan "fallback fonts"?**

Penggantian adalah pergantian yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitution](/slides/id/cpp/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/cpp/fallback-font/) diterapkan secara spesifik untuk glyph yang hilang secara individual ketika font dasar terpasang tetapi tidak mengandung karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya, Excel)?**

Tidak. [OLE content](/slides/id/cpp/manage-ole/) dikendalikan oleh aplikasinya masing-masing. Penggantian dalam presentasi tidak mengubah format data OLE internal; data tersebut dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Bisakah saya mengganti font hanya pada bagian tertentu dari presentasi (berdasarkan slide atau wilayah)?**

Penggantian terarah dimungkinkan jika Anda mengubah font pada tingkat objek/jangkauan yang diperlukan daripada menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama proses rendering tetap sama.

**Bagaimana saya dapat mengetahui sebelumnya font apa saja yang digunakan dalam presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) presentasi: ia menyediakan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) dan informasi tentang [substitusi/"unknown" fonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getsubstitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama proses ekspor, Aspose.Slides menerapkan urutan [font selection/substitution sequence](/slides/id/cpp/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya perlu menginstal font target di sistem, atau dapat saya melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [loading external fonts](/slides/id/cpp/custom-font/) dari folder pengguna untuk digunakan selama [rendering and export](/slides/id/cpp/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) alih-alih karakter?**

Hanya jika font target memang berisi glyph yang diperlukan. Jika tidak, [configure fallback](/slides/id/cpp/fallback-font/) untuk menutupi karakter yang hilang.