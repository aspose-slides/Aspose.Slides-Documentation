---
title: Menyederhanakan Penggantian Font dalam Presentasi Menggunakan JavaScript
linktitle: Penggantian Font
type: docs
weight: 60
url: /id/nodejs-java/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Ganti font secara mulus di JavaScript dengan Aspose.Slides untuk Node.js via Java untuk memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua kemunculan font asli akan diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang telah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda sengaja ingin beralih dari satu keluarga font ke keluarga font lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua kemunculan font lama akan digantikan oleh font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan.  
2. Muat font yang akan diganti.  
3. Muat font baru.  
4. Ganti font.  
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript berikut menunjukkan contoh penggantian font:

```javascript
// Memuat presentasi
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Memuat font sumber yang akan diganti
    var sourceFont = new aspose.slides.FontData("Arial");
    // Memuat font baru
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Mengganti font
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Menyimpan presentasi
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Penggantian Font**](/slides/id/nodejs-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "penggantian font", "penggantian font", dan "fallback font"?**

Penggantian adalah pergantian sengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Penggantian](/slides/id/nodejs-java/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/nodejs-java/fallback-font/) diterapkan secara khusus untuk glyph yang hilang ketika font dasar terpasang tetapi tidak berisi karakter yang diperlukan.

**Apakah penggantian berlaku pada master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya Excel)?**

Tidak. [Konten OLE](/slides/id/nodejs-java/manage-ole/) dikendalikan oleh aplikasi sendiri. Penggantian dalam presentasi tidak memformat ulang data OLE internal; dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Apakah saya dapat mengganti font hanya pada bagian tertentu dari presentasi (per slide atau wilayah)?**

Penggantian terarah memungkinkan jika Anda mengubah font pada level objek/jangkauan yang diperlukan daripada menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana cara menentukan sebelumnya font apa saja yang digunakan presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/) presentasi: ia menyediakan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getfonts/) dan informasi tentang [penggantian/"font tidak dikenal"](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font bekerja saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan urutan [pemilihan/penggantian font](/slides/id/nodejs-java/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya perlu menginstal font target di sistem, atau dapat melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/nodejs-java/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/nodejs-java/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) alih-alih karakter?**

Hanya jika font target memang berisi glyph yang dibutuhkan. Jika tidak, [konfigurasikan fallback](/slides/id/nodejs-java/fallback-font/) untuk menutupi karakter yang hilang.