---
title: Mempercepat Penggantian Font dalam Presentasi Menggunakan Python
linktitle: Penggantian Font
type: docs
weight: 60
url: /id/python-net/font-replacement/
keywords:
- font
- ganti font
- penggantian font
- ubah font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides Python via .NET untuk memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua instance font asli akan diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang telah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda dengan sengaja ingin beralih dari satu keluarga font ke keluarga lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran tentang penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan diganti dengan font baru.

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan.  
2. Muat font yang akan diganti.  
3. Muat font baru.  
4. Ganti font.  
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan penggantian font:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Memuat sebuah presentasi
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Memuat font sumber yang akan diganti
    sourceFont = slides.FontData("Arial")

    # Memuat font baru
    destFont = slides.FontData("Times New Roman")

    # Mengganti font
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Menyimpan presentasi
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Untuk menetapkan aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [**Font Substitution**](/slides/id/python-net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "font replacement", "font substitution", dan "fallback fonts"?**

Penggantian adalah perpindahan yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitution](/slides/id/python-net/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/python-net/fallback-font/) diterapkan secara khusus untuk glyph yang hilang secara individu ketika font dasar terpasang tetapi tidak berisi karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang disematkan (misalnya, Excel)?**

Tidak. [OLE content](/slides/id/python-net/manage-ole/) dikontrol oleh aplikasinya sendiri. Penggantian dalam presentasi tidak memformat ulang data OLE internal; data tersebut dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Apakah saya dapat mengganti font hanya pada bagian tertentu dari presentasi (per slide atau wilayah)?**

Penggantian terarah dimungkinkan jika Anda mengubah font pada tingkat objek/jangkauan yang diperlukan alih-alih menerapkan penggantian global pada seluruh dokumen. Logika pemilihan font secara keseluruhan selama rendering tetap sama.

**Bagaimana saya dapat menentukan sebelumnya font apa saja yang digunakan dalam presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/) presentasi: ia menyediakan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) dan informasi tentang [substitusi/"unknown" fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan [urutan pemilihan/substitusi font](/slides/id/python-net/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya perlu menginstal font target di sistem, atau dapat saya melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/python-net/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/python-net/convert-powerpoint/).

**Apakah penggantian akan memperbaiki “tofu” (kotak) alih-alih karakter?**

Hanya jika font target memang berisi glyph yang dibutuhkan. Jika tidak, [konfigurasi fallback](/slides/id/python-net/fallback-font/) untuk menutupi karakter yang hilang.