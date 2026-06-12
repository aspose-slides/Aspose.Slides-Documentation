---
title: Menyederhanakan Penggantian Font dalam Presentasi Menggunakan PHP
linktitle: Penggantian Font
type: docs
weight: 60
url: /id/php-java/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk PHP melalui Java untuk memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua instance font asli diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang sudah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda sengaja ingin beralih dari satu keluarga font ke keluarga lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan digantikan oleh font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan. 
2. Muat font yang akan diganti. 
3. Muat font baru. 
4. Ganti font. 
5. Tulis presentasi yang sudah dimodifikasi sebagai file PPTX.

Berikut contoh kode PHP untuk penggantian font:

```php
  # Memuat sebuah presentasi
  $pres = new Presentation("Fonts.pptx");
  try {
    # Memuat font sumber yang akan diganti
    $sourceFont = new FontData("Arial");
    # Memuat font baru
    $destFont = new FontData("Times New Roman");
    # Mengganti font
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Menyimpan presentasi
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Penggantian Font**](/slides/id/php-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "penggantian font", "substitusi font", dan "font cadangan"?**

Penggantian adalah pergantian sengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitusi](/slides/id/php-java/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Cadangan](/slides/id/php-java/fallback-font/) diterapkan secara spesifik untuk glyph yang hilang ketika font dasar terpasang tetapi tidak berisi karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya Excel)?**

Tidak. [Konten OLE](/slides/id/php-java/manage-ole/) dikendalikan oleh aplikasi masing‑masing. Penggantian di dalam presentasi tidak merubah data internal OLE; data tersebut mungkin ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Bisakah saya mengganti font hanya pada bagian tertentu dari presentasi (per slide atau wilayah)?**

Penggantian terarah memungkinkan jika Anda mengubah font pada level objek atau rentang yang dibutuhkan, bukan dengan menerapkan penggantian global pada seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana cara mengetahui sebelumnya font apa saja yang digunakan oleh presentasi?**

Gunakan [font manager] presentasi (https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/): ia menyediakan daftar [keluarga font yang digunakan] (https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getfonts/) dan informasi tentang [substitusi/"font tidak diketahui"] (https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama proses ekspor, Aspose.Slides menerapkan urutan [pemilihan/substitusi font](/slides/id/php-java/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati saat konversi.

**Apakah saya harus menginstal font target di sistem, atau dapat melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/php-java/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/php-java/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) alih-alih karakter?**

Hanya jika font target benar‑benarnya berisi glyph yang diperlukan. Jika tidak, [konfigurasikan cadangan](/slides/id/php-java/fallback-font/) untuk menutupi karakter yang hilang.