---
title: Menyederhanakan Penggantian Font dalam Presentasi Menggunakan Python via Java
linktitle: Penggantian Font
type: docs
weight: 60
url: /id/python-java/font-replacement/
keywords:
- font
- mengganti font
- penggantian font
- mengubah font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ganti font secara mulus di Aspose.Slides untuk Python via Java untuk memastikan tipografi yang konsisten dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengganti satu font dengan font lain di seluruh presentasi. Ketika sebuah font diganti, semua instance font asli akan diubah menjadi font baru.

Untuk melakukan penggantian font, muat presentasi, tentukan font sumber dan font pengganti, panggil metode penggantian font, dan simpan presentasi yang sudah dimodifikasi sebagai file PPTX. Pendekatan ini berguna ketika Anda secara sengaja ingin beralih dari satu keluarga font ke keluarga lain di seluruh presentasi.

## **Ganti Font**

Jika Anda berubah pikiran mengenai penggunaan sebuah font, Anda dapat mengganti font tersebut dengan font lain. Semua instance font lama akan diganti oleh font baru. 

Aspose.Slides memungkinkan Anda mengganti font dengan cara berikut:

1. Muat presentasi yang relevan. 
2. Muat font yang akan diganti. 
3. Muat font baru. 
4. Ganti font. 
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Muat presentasi.
presentation = Presentation("Fonts.pptx")
try:
    # Muat font sumber yang akan diganti.
    source_font = FontData("Arial")

    # Muat font baru.
    destination_font = FontData("Times New Roman")

    # Ganti font.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Simpan presentasi.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 

Untuk mengatur aturan yang menentukan apa yang terjadi dalam kondisi tertentu (misalnya jika sebuah font tidak dapat diakses), lihat [Substitusi Font](/slides/id/python-java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Apa perbedaan antara "penggantian font", "substitusi font", dan "fallback font"?**

Penggantian adalah pergantian yang disengaja dari satu keluarga ke keluarga lain di seluruh dokumen. [Substitusi](/slides/id/python-java/font-substitution/) adalah aturan seperti "jika font tidak tersedia, gunakan X." [Fallback](/slides/id/python-java/fallback-font/) diterapkan pada glyph yang hilang secara individual ketika font dasar terpasang tetapi tidak berisi karakter yang diperlukan.

**Apakah penggantian berlaku untuk master slide, layout, catatan, dan komentar?**

Ya. Penggantian memengaruhi semua objek presentasi yang menggunakan font asli, termasuk master slide dan catatan; komentar juga merupakan bagian dari dokumen dan dipertimbangkan oleh mesin font.

**Apakah font akan berubah di dalam objek OLE yang tertanam (misalnya, Excel)?**

Tidak. [Konten OLE](/slides/id/python-java/manage-ole/) dikendalikan oleh aplikasinya masing-masing. Penggantian dalam presentasi tidak mengubah format data OLE internal; data tersebut dapat ditampilkan sebagai gambar atau sebagai konten yang dapat diedit secara eksternal.

**Apakah saya dapat mengganti font hanya pada bagian tertentu dari presentasi (per slide atau wilayah)?**

Penggantian terarah dimungkinkan jika Anda mengubah font pada tingkat objek/jangkauan yang diperlukan daripada menerapkan penggantian global ke seluruh dokumen. Logika pemilihan font secara keseluruhan selama proses rendering tetap sama.

**Bagaimana saya dapat menentukan sebelumnya font apa saja yang digunakan dalam presentasi?**

Gunakan [font manager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) presentasi: ia menyediakan daftar [keluarga font yang digunakan](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFonts) dan informasi tentang [substitusi/"font tidak dikenal"](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions), yang membantu merencanakan penggantian.

**Apakah penggantian font berfungsi saat mengonversi ke PDF/gambar?**

Ya. Selama ekspor, Aspose.Slides menerapkan [urutan pemilihan/substitusi font](/slides/id/python-java/font-selection-sequence/) yang sama, sehingga penggantian yang dilakukan sebelumnya akan dihormati selama konversi.

**Apakah saya harus menginstal font target di sistem, atau saya dapat melampirkan folder font?**

Instalasi tidak diperlukan: perpustakaan memungkinkan [memuat font eksternal](/slides/id/python-java/custom-font/) dari folder pengguna untuk digunakan selama [rendering dan ekspor](/slides/id/python-java/convert-powerpoint/).

**Apakah penggantian akan memperbaiki "tofu" (kotak) alih-alih karakter?**

Hanya jika font target memang berisi glyph yang diperlukan. Jika tidak, [konfigurasikan fallback](/slides/id/python-java/fallback-font/) untuk menutupi karakter yang hilang.