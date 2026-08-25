---
title: Sesuaikan Font PowerPoint di Python
linktitle: Font Kustom
type: docs
weight: 20
url: /id/python-net/custom-font/
keywords:
- font
- font kustom
- font eksternal
- memuat font
- mengelola font
- folder font
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Sertakan font kustom dalam slide PowerPoint dengan Aspose.Slides untuk Python melalui .NET agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Ikhtisar**

Aspose.Slides untuk Python memungkinkan Anda menyediakan font khusus pada waktu berjalan sehingga presentasi ditampilkan dengan benar meskipun font yang dibutuhkan tidak terpasang di sistem host. Saat mengekspor ke PDF atau gambar, Anda dapat memberikan folder font atau data font dalam memori untuk menjaga tata letak teks, metrik glif, dan tipografi. Hal ini membuat rendering sisi server dapat diprediksi di berbagai lingkungan, menghilangkan ketergantungan font pada tingkat OS, dan mencegah fallback atau reflow yang tidak diinginkan. Artikel ini menunjukkan cara mendaftarkan sumber font.

Tema presentasi dapat merujuk ke keluarga font yang berbeda untuk sistem penulisan individual. Pemetaan ini menyimpan nama font tetapi tidak menginstal atau memuat file font. Lihat [Script-Specific Theme Fonts](/slides/id/python-net/script-specific-font-mappings/) untuk mengelola pemetaan, dan gunakan opsi pemuatan di bawah ini agar font yang dirujuk tersedia untuk rendering yang konsisten.

Aspose.Slides memungkinkan Anda memuat font berikut menggunakan metode `load_external_font` dan `load_external_fonts` dari kelas [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/):

- Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di berbagai lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/load_external_fonts/) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clear_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/clear_cache/) untuk membersihkan cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```py
import aspose.slides as slides

# Tentukan folder yang berisi file font kustom.
font_folders = ["fonts", "external_fonts"]

# Muat font kustom dari folder yang ditentukan.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Bersihkan cache font setelah pekerjaan selesai.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Catatan" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/load_external_fonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.
Font diinisialisasi dalam urutan berikut:

1. Jalur font sistem operasi default.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Dapatkan Folder Font Kustom**

Aspose.Slides menyediakan metode `get_font_folders` untuk mendapatkan folder font. Metode ini mengembalikan baik folder yang ditambahkan melalui `load_external_fonts` maupun folder font sistem.

Kode Python berikut menunjukkan cara menggunakan `get_font_folders`:

```python
import aspose.slides as slides

# Panggilan ini mengembalikan folder yang diperiksa untuk file font.
# Ini termasuk folder yang ditambahkan melalui metode load_external_fonts dan folder font sistem.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Tentukan Font Kustom untuk Presentasi**

Aspose.Slides menyediakan properti `document_level_font_sources`, yang memungkinkan Anda menentukan font eksternal yang akan digunakan dalam sebuah presentasi.

Contoh Python berikut menunjukkan cara menggunakan `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Bekerja dengan presentasi.
    # CustomFont1, CustomFont2, dan font dari folder assets\fonts serta global\fonts (beserta subfoldernya) tersedia untuk presentasi.
    # ...
    print(len(presentation.slides))
```

## **Muat Font Eksternal dari Data Biner**

Aspose.Slides menyediakan metode `load_external_font` untuk memuat font eksternal dari data biner.

Contoh Python berikut menunjukkan pemuatan font dari array byte:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Muat font eksternal dari array byte.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Font eksternal tersedia selama masa hidup instance presentasi ini.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

### Apakah font kustom secara otomatis disertakan dalam PPTX yang dihasilkan?

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyertakan (embed) ke dalam PPTX. Jika Anda memerlukan font yang dibawa di dalam file presentasi, Anda harus menggunakan [fitur penyertaan](/slides/id/python-net/embedded-font/).

### Bisakah saya mengontrol perilaku fallback ketika font kustom tidak memiliki beberapa glif?

Ya. Konfigurasikan [font substitution](/slides/id/python-net/font-substitution/), [replacement rules](/slides/id/python-net/font-replacement/), dan [fallback sets](/slides/id/python-net/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glif yang diminta tidak ada.

### Bisakah saya menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem?

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam image kontainer.

### Bagaimana dengan lisensi—apakah saya dapat menyertakan (embed) font kustom apa pun tanpa batasan?

Anda bertanggung jawab atas kepatuhan lisensi font. Syaratnya bervariasi; beberapa lisensi melarang penyertaan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan hasil.