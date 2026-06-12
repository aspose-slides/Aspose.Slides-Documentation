---
title: Sesuaikan Font PowerPoint di Python
linktitle: Font Kustom
type: docs
weight: 20
url: /id/python-net/custom-font/
keywords:
- font
- font khusus
- font eksternal
- muat font
- kelola font
- folder font
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Sematkan font khusus dalam slide PowerPoint dengan Aspose.Slides untuk Python melalui .NET agar presentasi Anda tajam dan konsisten di semua perangkat."
---
## **Gambaran Umum**

Aspose.Slides untuk Python memungkinkan Anda menyediakan font khusus pada waktu berjalan sehingga presentasi ditampilkan dengan benar bahkan ketika font yang diperlukan tidak terpasang di sistem host. Selama mengekspor ke PDF atau gambar, Anda dapat menyediakan folder font atau data font dalam memori untuk mempertahankan tata letak teks, metrik glif, dan tipografi. Ini membuat rendering sisi server dapat diprediksi di berbagai lingkungan, menghilangkan ketergantungan font tingkat OS, dan mencegah fallback atau reflow yang tidak diinginkan. Artikel ini menunjukkan cara mendaftarkan sumber font.

Aspose.Slides memungkinkan Anda memuat font berikut menggunakan metode `load_external_font` dan `load_external_fonts` dari kelas [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/):

- Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen hasil tampak konsisten di semua lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/load_external_fonts/) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clear_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/clear_cache/) untuk menghapus cache font.

```py
import aspose.slides as slides

# Tetapkan folder yang berisi file font khusus.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Muat font khusus dari folder yang ditentukan.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Bersihkan cache font setelah pekerjaan selesai.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/load_external_fonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.

Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Dapatkan Folder Font Kustom**

Aspose.Slides menyediakan metode `get_font_folders` untuk mengambil folder font. Metode ini mengembalikan baik folder yang ditambahkan melalui `load_external_fonts` maupun folder font sistem.

```python
import aspose.slides as slides

# Panggilan ini mengembalikan folder yang diperiksa untuk file font.
# Ini termasuk folder yang ditambahkan melalui metode load_external_fonts dan folder font sistem.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Tentukan Font Kustom untuk Presentasi**

Aspose.Slides menyediakan properti `document_level_font_sources`, yang memungkinkan Anda menentukan font eksternal yang akan digunakan dengan sebuah presentasi.

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
    # CustomFont1, CustomFont2, dan font dari folder assets\fonts dan global\fonts (beserta subfoldernya) tersedia untuk presentasi.
    # ...
    print(len(presentation.slides))
```

## **Muat Font Eksternal dari Data Biner**

Aspose.Slides menyediakan metode `load_external_font` untuk memuat font eksternal dari data biner.

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

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyematkannya ke dalam PPTX. Jika Anda membutuhkan font yang dibawa di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/python-net/embedded-font/).

**Apakah saya dapat mengontrol perilaku fallback ketika font kustom tidak memiliki glif tertentu?**

Ya. Konfigurasikan [substitusi font](/slides/id/python-net/font-substitution/), [aturan penggantian](/slides/id/python-net/font-replacement/), dan [set fallback](/slides/id/python-net/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glif yang diminta tidak ada.

**Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam gambar kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Syaratnya bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan hasil.