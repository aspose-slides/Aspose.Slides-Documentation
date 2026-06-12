---
title: "Menyederhanakan Penggantian Font dalam Presentasi di .NET"
linktitle: "Penggantian Font"
type: docs
weight: 60
url: /id/net/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk .NET guna memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lainnya di seluruh presentasi. Ketika sebuah font diganti, semua instance font asli diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang telah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda secara sengaja ingin beralih dari satu keluarga font ke keluarga font lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan digantikan oleh font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan.  
2. Muat font yang akan diganti.  
3. Muat font baru.  
4. Ganti font.  
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini mendemonstrasikan penggantian font:

```c#
// Memuat presentasi
Presentation presentation = new Presentation("Fonts.pptx");

// Memuat font sumber yang akan diganti
IFontData sourceFont = new FontData("Arial");

// Memuat font baru
IFontData destFont = new FontData("Times New Roman");

// Mengganti font
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Menyimpan presentasi
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Catatan" color="warning" %}} 
Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Penggantian Font**](/slides/id/net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "font replacement", "font substitution", dan "fallback fonts"?**

Penggantian (replacement) adalah pergantian yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitusi](/slides/id/net/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/net/fallback-font/) diterapkan secara khusus untuk glyph yang hilang secara individual ketika font dasar terpasang tetapi tidak mengandung karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya, Excel)?**

Tidak. [Konten OLE](/slides/id/net/manage-ole/) dikendalikan oleh aplikasinya sendiri. Penggantian dalam presentasi tidak mengubah format data OLE internal; data tersebut dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Bisakah saya mengganti font hanya pada bagian tertentu dari presentasi (berdasarkan slide atau wilayah)?**

Penggantian terarah dimungkinkan jika Anda mengubah font pada tingkat objek/jangkauan yang diperlukan alih-alih menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana saya dapat mengetahui sebelumnya font apa saja yang digunakan oleh presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/): ia menyediakan daftar [keluarga yang digunakan](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getfonts/) dan informasi tentang [substitusi/\"font tidak dikenal\"](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getsubstitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan [urutan pemilihan/substitusi font](/slides/id/net/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya perlu menginstal font target di sistem, atau dapat saya melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/net/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/net/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) yang muncul alih-alih karakter?**

Hanya jika font target memang berisi glyph yang diperlukan. Jika tidak, [konfigurasikan fallback](/slides/id/net/fallback-font/) untuk menutupi karakter yang hilang.