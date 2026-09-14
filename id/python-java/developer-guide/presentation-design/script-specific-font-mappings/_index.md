---
title: Kelola Font Tema Khusus Skrip di Python melalui Java
linktitle: Font Tema Khusus Skrip
type: docs
weight: 15
url: /id/python-java/script-specific-font-mappings/
keywords:
- font khusus skrip
- pemetaan font tema
- presentasi multibahasa
- sistem penulisan
- font Cyrillic
- font Arab
- font Jepang
- font Georgia
- font Thaana
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font khusus skrip dalam tema PowerPoint dengan Aspose.Slides untuk Python melalui Java."
---
## **Ikhtisar**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Ini memungkinkan teks multibahasa yang tetap menggunakan font tema mengikuti satu skema font terkoordinasi sekaligus menggunakan font yang sesuai untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lainnya.

[FontScheme](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontscheme/) tema berisi koleksi font utama, biasanya digunakan untuk judul, dan koleksi font sekunder, biasanya digunakan untuk teks isi. Selain pengaturan font Latin dan Asia Timur mereka, kedua koleksi tersebut mengekspos pemetaan dari tag sistem penulisan ke nama keluarga font melalui kelas [Fonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/).

Artikel ini menunjukkan cara memeriksa dan mengubah pemetaan tersebut dalam tema master presentasi serta memverifikasi bahwa perubahan tetap ada setelah siklus simpan‑dan‑muat ulang.

## **Memahami Tag Skrip**

Metode font skrip menggunakan subtags skrip BCP 47 empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arab |
| `Hans` | Chinese Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgia |
| `Thaa` | Thaana |

Pemetaan ini milik skema font tema, bukan bagian teks individu. Sebuah presentasi dapat mendefinisikan pemetaan yang berbeda untuk koleksi utama dan sekunder, dan dapat mengabaikan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasterTheme) untuk mengakses tema tingkat presentasi. Metode [FontScheme.getMajor](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontscheme/#getMajor) dan [FontScheme.getMinor](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontscheme/#getMinor) mengembalikan dua koleksi [Fonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/).

Panggil [Fonts.getScriptFontMap](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#getScriptFontMap) untuk mengambil semua pemetaan dari sebuah koleksi. Untuk mencari satu sistem penulisan, panggil [Fonts.getScriptFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#getScriptFont) dengan tag skripnya. `getScriptFont` mengembalikan `None` ketika koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Mengubah Pemetaan dan Memverifikasi Persistensi**

Gunakan [Fonts.setScriptFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#setScriptFont) untuk membuat pemetaan atau mengganti keluarga fontnya saat ini. Gunakan [Fonts.removeScriptFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#removeScriptFont) untuk menghapus sebuah pemetaan.

Contoh end‑to‑end berikut membaca semua pemetaan utama dan sekunder yang ada, mencari font utama Jepang, mengubah font utama Cyrillic, menghapus pemetaan sekunder Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Agar langkah penghapusan tidak bergantung pada tema awal, contoh terlebih dulu membuat pemetaan Thaana hanya bila belum ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Verifikasi menggunakan perilaku `None` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `getScriptFont("Thaa")` mengembalikan `None` untuk koleksi sekunder.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lainnya**

Pemetaan tema khusus skrip berpartisipasi dalam pemilihan font, tetapi menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema khusus skrip | Memilih font tema utama atau sekunder untuk sebuah sistem penulisan. | Teks yang masih menggunakan font tema terkait dapat beralih ke keluarga font baru yang dipetakan. |
| Font yang ditetapkan secara eksplisit pada bagian teks | Menetapkan keluarga font yang diminta pada bagian tersebut alih‑alih mengandalkan tema. | Bagian itu mungkin tetap tidak berubah karena pemformatan langsung menimpa pilihan tema. |
| Substitusi font | Mengganti font yang diminta ketika font tersebut tidak tersedia atau ketika aturan substitusi berlaku. | Berlaku setelah font diminta; tidak mendefinisikan ulang pemetaan skrip tema. |
| Fallback font | Menyediakan glif yang tidak dimiliki font yang dipilih, biasanya untuk rentang Unicode tertentu. | Mengisi kekurangan glif; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/python-java/font-substitution/) dan [Fallback Fonts](/slides/id/python-java/fallback-font/).

Mengubah pemetaan di [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasterTheme) memengaruhi hanya konten yang pemformatannya yang efektif masih bergantung pada tema itu. Teks dapat mewarisi override tema dari master, layout, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa level tersebut bila hasil visual tidak mengikuti pemetaan tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; tidak menginstal atau memuat berkas font yang bersangkutan. Untuk rendering dan ekspor yang konsisten, setiap font yang dipetakan harus diinstal di lingkungan atau disediakan ke Aspose.Slides melalui sumber khusus seperti [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFonts) atau [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Lihat [Custom Fonts](/slides/id/python-java/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan definisi tema tetap terjaga. Itu tidak membuktikan bahwa font tersedia, berisi semua glif yang diperlukan, atau menghasilkan tata letak yang diinginkan. Render teks representatif untuk setiap sistem penulisan yang diperlukan ke gambar atau PDF dan periksa outputnya. Ini menangkap font yang hilang, cakupan glif yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/python-java/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **FAQ**

**Apa yang dikembalikan `getScriptFont` ketika sebuah skrip tidak dipetakan?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#getScriptFont) mengembalikan `None` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font utama atau sekunder tersebut.

**Apakah `setScriptFont` menambahkan pemetaan kedua ketika skrip sudah ada?**

Tidak. [Fonts.setScriptFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fonts/#setScriptFont) membuat pemetaan ketika belum ada dan mengganti keluarga font yang dipetakan ketika tag skrip yang sama sudah hadir.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema yang berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat rendering. Pemetaan skrip tingkat presentasi hanya mengendalikan teks yang pemformatannya yang efektif masih merujuk pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali memverifikasi persistensi data tema. Selain itu, render teks representatif dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glif yang diperlukan.