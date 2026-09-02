---
title: Kelola Font Tema Spesifik Skrip di Python
linktitle: Font Tema Spesifik Skrip
type: docs
weight: 15
url: /id/python-net/script-specific-font-mappings/
keywords:
- font spesifik skrip
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
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font spesifik skrip dalam tema PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Hal ini memungkinkan teks multibahasa yang tetap menggunakan font tema mengikuti satu skema font terkoordinasi sambil menggunakan font yang cocok untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lainnya.

[FontScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/) tema berisi koleksi font utama, biasanya digunakan untuk judul, dan koleksi font minor, biasanya digunakan untuk teks badan. Selain properti font Latin dan Asia Timur mereka, kedua koleksi mengekspos pemetaan dari tag sistem penulisan ke nama keluarga font melalui kelas [Fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/).

Artikel ini menunjukkan cara memeriksa dan memodifikasi pemetaan tersebut di tema master presentasi serta memverifikasi bahwa perubahan tetap ada setelah siklus simpan‑dan‑muat kembali.

## **Memahami Tag Skrip**

Metode font skrip menggunakan subtag skrip BCP 47 empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arab |
| `Hans` | Mandarin Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgia |
| `Thaa` | Thaana |

Pemetaan ini milik skema font tema, bukan bagian teks individu. Sebuah presentasi dapat mendefinisikan pemetaan yang berbeda untuk koleksi utama dan minor, dan dapat mengabaikan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/) untuk mengakses tema tingkat presentasi. Properti [FontScheme.major](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.minor](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/minor/) mengembalikan dua koleksi [Fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/).

Panggil [Fonts.get_script_font_map](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/get_script_font_map/) untuk mengambil semua pemetaan dari sebuah koleksi. Untuk mencari satu sistem penulisan, panggil [Fonts.get_script_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/get_script_font/) dengan tag skripnya. `get_script_font` mengembalikan `None` ketika koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Memodifikasi Pemetaan dan Memverifikasi Persistensi**

Gunakan [Fonts.set_script_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/set_script_font/) untuk membuat pemetaan atau mengganti keluarga fontnya saat ini. Gunakan [Fonts.remove_script_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/remove_script_font/) untuk menghapus sebuah pemetaan.

Contoh end‑to‑end berikut membaca semua pemetaan utama dan minor yang ada, mencari font utama Jepang, mengubah font utama Cyrillic, menghapus pemetaan minor Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Untuk membuat langkah penghapusan independen dari tema awal, contoh pertama membuat pemetaan Thaana hanya bila belum ada yang didefinisikan.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Verifikasi menggunakan perilaku `None` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `get_script_font("Thaa")` mengembalikan `None` untuk koleksi minor.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan tema spesifik skrip berpartisipasi dalam pemilihan font, tetapi menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema spesifik skrip | Memilih font tema utama atau minor untuk suatu sistem penulisan. | Teks yang masih menggunakan font tema yang bersangkutan dapat beralih ke keluarga yang dipetakan baru. |
| Font yang ditetapkan secara eksplisit pada bagian teks | Menetapkan keluarga font yang diminta pada bagian tersebut alih‑alih bergantung pada tema. | Bagian tersebut mungkin tetap tidak berubah karena pemformatan langsungnya mengesampingkan pilihan tema. |
| Substitusi font | Mengganti font yang diminta bila font tersebut tidak tersedia atau bila aturan substitusi berlaku. | Beroperasi setelah font diminta; tidak mendefinisikan ulang pemetaan skrip tema. |
| Fallback font | Menyediakan glif yang tidak dimiliki font terpilih, biasanya untuk rentang Unicode tertentu. | Mengisi cakupan glif yang hilang; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/python-net/font-substitution/) dan [Fallback Fonts](/slides/id/python-net/fallback-font/).

Mengubah pemetaan di [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/) memengaruhi hanya konten yang pemformatannya masih bergantung pada tema tersebut. Teks dapat mewarisi override tema dari master, layout, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa tingkatan tersebut bila hasil yang terlihat tidak mengikuti pemetaan tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak memasang atau memuat berkas font yang bersangkutan. Untuk render yang konsisten dan ekspor, setiap font yang dipetakan harus dipasang di lingkungan atau disediakan ke Aspose.Slides melalui sumber khusus seperti [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/load_external_fonts/) atau [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/document_level_font_sources/). Lihat [Custom Fonts](/slides/id/python-net/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya mengonfirmasi bahwa definisi tema dipertahankan. Itu tidak membuktikan bahwa font tersedia, berisi semua glif yang diperlukan, atau menghasilkan tata letak yang diinginkan. Render teks perwakilan untuk setiap sistem penulisan yang diperlukan ke gambar atau PDF dan periksa outputnya. Ini menangkap font yang hilang, cakupan glif yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/python-net/convert-powerpoint/) untuk contoh render dan ekspor.

## **FAQ**

**Apa yang dikembalikan `get_script_font` ketika sebuah skrip tidak dipetakan?**

[Fonts.get_script_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/get_script_font/) mengembalikan `None` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font utama atau minor tersebut.

**Apakah `set_script_font` menambahkan pemetaan kedua ketika skrip sudah ada?**

Tidak. [Fonts.set_script_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fonts/set_script_font/) membuat pemetaan bila belum ada dan mengganti keluarga font yang dipetakan bila tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks tersebut mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema yang berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat render. Pemetaan skrip tingkat presentasi hanya mengontrol teks yang pemformatannya masih merujuk pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali hanya memverifikasi keberlangsungan data tema. Selain itu, render teks perwakilan dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glif yang diperlukan.