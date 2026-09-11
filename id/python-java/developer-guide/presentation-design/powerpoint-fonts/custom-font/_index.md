---
title: Sesuaikan Font PowerPoint di Python via Java
linktitle: Font Kustom
type: docs
weight: 20
url: /id/python-java/custom-font/
keywords:
- font
- font kustom
- font eksternal
- memuat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk Python via Java agar presentasi Anda tajam dan konsisten di semua perangkat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggunakan font kustom dalam presentasi tanpa menginstalnya pada sistem operasi. Anda dapat memuat font dari folder kustom, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font kustom untuk rendering terpisah dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

Tema presentasi dapat merujuk pada keluarga font yang berbeda untuk sistem penulisan individu. Pemetaannya menyimpan nama font tetapi tidak menginstal atau memuat berkas font. Lihat [Font Tema Spesifik Skrip](/slides/id/python-java/script-specific-font-mappings/) untuk mengelola pemetaan, dan gunakan opsi pemuatan di bawah ini agar font yang dirujuk tersedia untuk rendering yang konsisten.

{{% alert color="info" title="Note" %}}

Aspose.Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di berbagai lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi berkas font.
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFonts) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#clearCache) untuk membersihkan cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Tentukan folder yang berisi berkas font kustom.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Muat font kustom dari folder yang ditentukan.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Render/ekspor presentasi menggunakan font yang dimuat.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Bersihkan cache font setelah pekerjaan selesai.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFonts) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.

Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**

Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#getFontFolders) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode [loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFonts) serta folder font sistem.

Kode Python berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Dapatkan folder yang ditambahkan melalui loadExternalFonts dan folder font sistem.
font_folders = FontsLoader.getFontFolders()
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**

Aspose.Slides menyediakan metode [getDocumentLevelFontSources](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode Python berikut menunjukkan cara menggunakan metode [getDocumentLevelFontSources](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Bekerja dengan presentasi.
    # CustomFont1, CustomFont2, dan font dari assets/fonts serta global/fonts
    # dan subfolder-nya tersedia untuk presentasi.
    pass
finally:
    presentation.dispose()
```

## **Kelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadExternalFont) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode Python berikut mendemonstrasikan proses pemuatan font dari array byte:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Font eksternal dimuat selama masa hidup presentasi.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font yang dibawa di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/python-java/embedded-font/) secara eksplisit.

**Bisakah saya mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [substitusi font](/slides/id/python-java/font-substitution/), [aturan penggantian](/slides/id/python-java/font-replacement/), dan [set fallback](/slides/id/python-java/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak ada.

**Bisakah saya menggunakan font di dalam kontainer Linux/Docker tanpa menginstalnya secara sistem?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam gambar kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratannya bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.