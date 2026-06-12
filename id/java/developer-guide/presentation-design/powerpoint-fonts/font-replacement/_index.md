---
title: "Permudah Penggantian Font dalam Presentasi Menggunakan Java"
linktitle: "Penggantian Font"
type: docs
weight: 60
url: /id/java/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk Java guna memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua kemunculan font asli akan diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda dengan sengaja ingin beralih dari satu keluarga font ke keluarga lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua kemunculan font lama akan digantikan oleh font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan. 
2. Muat font yang akan diganti. 
3. Muat font baru. 
4. Ganti font. 
5. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara mengganti font:

```java
// Memuat presentasi
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Memuat font sumber yang akan diganti
    IFontData sourceFont = new FontData("Arial");
    
    // Memuat font baru
    IFontData destFont = new FontData("Times New Roman");
    
    // Mengganti font
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Menyimpan presentasi
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Font Substitution**](/slides/id/java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "penggantian font", "substitusi font", dan "font cadangan"?**

Penggantian adalah pergantian yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitution](/slides/id/java/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/java/fallback-font/) diterapkan secara spesifik untuk glyph yang hilang secara individu ketika font dasar terpasang tetapi tidak mengandung karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya Excel)?**

Tidak. [OLE content](/slides/id/java/manage-ole/) dikendalikan oleh aplikasinya sendiri. Penggantian dalam presentasi tidak memformat ulang data OLE internal; data tersebut dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Apakah saya bisa mengganti font hanya di sebagian presentasi (misalnya per slide atau wilayah)?**

Penggantian yang ditargetkan dimungkinkan jika Anda mengganti font pada tingkat objek atau rentang yang diperlukan, bukan menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana saya dapat menentukan sebelumnya font apa saja yang digunakan dalam presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/) presentasi: ia memberikan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#getFonts--) dan informasi tentang [substitusi/"font tidak dikenal"](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#getSubstitutions--), yang membantu merencanakan penggantian.

**Apakah penggantian font bekerja saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan urutan [pemilihan/substitusi font](/slides/id/java/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya harus menginstal font target di sistem, atau dapat melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/java/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/java/convert-powerpoint/).

**Apakah penggantian akan memperbaiki “tofu” (kotak) yang muncul alih-alih karakter?**

Hanya jika font target memang berisi glyph yang diperlukan. Jika tidak, [konfigurasikan fallback](/slides/id/java/fallback-font/) untuk menutupi karakter yang hilang.