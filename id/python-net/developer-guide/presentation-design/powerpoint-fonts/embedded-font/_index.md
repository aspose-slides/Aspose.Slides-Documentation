---
title: Sematkan Font dalam Presentasi dengan Python
linktitle: Font yang Disematkan
type: docs
weight: 40
url: /id/python-net/embedded-font/
keywords:
- tambahkan font
- sematkan font
- penyematan font
- dapatkan font yang disematkan
- tambahkan font yang disematkan
- hapus font yang disematkan
- kompres font yang disematkan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola font yang disematkan dalam PowerPoint dengan Aspose.Slides untuk Python via .NET. Gunakan Python untuk menambahkan, mengambil, menghapus, dan mengompres font guna mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika pemirsa mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut meskipun font tidak terpasang pada sistem target. Ini membantu mempertahankan pemisahan baris, jarak teks, dan tata letak slide.

Aspose.Slides for Python via .NET memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui properti [fonts_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/fonts_manager/) dari objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan sebuah font, pastikan data font tersebut tersedia untuk Aspose.Slides dan lisensinya memperbolehkan penyematan.

## **Dapatkan dan Hapus Font yang Disematkan**

Gunakan [get_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) untuk menampilkan daftar font yang tersimpan dalam sebuah presentasi. Untuk menghapus satu font, berikan sebuah font dari daftar tersebut ke [remove_embedded_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/remove_embedded_font/), lalu simpan presentasinya.

Contoh berikut menampilkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Menghapus font yang disematkan menghapus data font yang tersimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font tersebut terpasang pada sistem target, teks masih dapat menggunakannya. Jika tidak, proses rendering mungkin memerlukan [font substitution](/slides/id/python-net/font-substitution/), yang dapat memengaruhi tata letak.

## **Periksa Data Font dan Izin Penyematan**

Gunakan kelas [FontsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [get_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [FontData](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontstyletype/) yang diperlukan ke [get_font_bytes](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_font_bytes/). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `None` bila font atau gaya yang diminta tidak tersedia. Jangan memberikan hasil `None` ke [get_font_embedding_level](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), karena metode itu memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/python-net/aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `INSTALLABLE` memperbolehkan penyematan dan instalasi permanen pada sistem lain, tergantung pada lisensi font.
- `RESTRICTED` melarang penyematan kecuali izin diperoleh dari pemilik hukum font ketika itu adalah satu‑satunya flag izin penggunaan.
- `PREVIEW_PRINT` memperbolehkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font tersebut harus bersifat hanya‑baca.
- `EDITABLE` memperbolehkan penggunaan sementara dan memungkinkan dokumen diedit serta disimpan.
- `NO_SUBSETTING` merupakan pembatas tambahan yang melarang penyematan hanya sebagian glyph. Sematkan semua karakter bila flag ini ada.
- `BITMAP_ONLY` merupakan pembatas tambahan yang hanya memperbolehkan penyematan bitmap strike, bukan data outline. Jika font tidak memiliki bitmap strike, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NO_SUBSETTING` dan `BITMAP_ONLY` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `INSTALLABLE` bernilai nol, maskilah bit izin penggunaan dan bandingkan hasilnya dengan `INSTALLABLE`. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin paling tidak restriktif: `EDITABLE`, kemudian `PREVIEW_PRINT`, kemudian `RESTRICTED`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal‑miring yang tersedia untuk setiap font yang dikembalikan oleh `get_fonts`. Ia melewatkan gaya yang tidak tersedia, font yang dibatasi, font bitmap‑only, font yang terbatas pada pratinjau dan cetak karena output tetap dapat diedit, serta font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NO_SUBSETTING`, ia menyematkan semua karakter untuk keluarga font tersebut.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Pemeriksaan ini tidak memberikan lisensi, tidak membuktikan bahwa Anda memperoleh font secara legal, dan tidak menggantikan pemeriksaan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Tambahkan Font yang Disematkan**

Gunakan [add_embedded_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/add_embedded_font/) untuk menyematkan sebuah font. Overload‑nya menerima baik objek [FontData](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- [ALL](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [ONLY_USED](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk ditampilkan.

Contoh berikut menggunakan [get_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan yang belum disematkan. Font yang akan ditambahkan harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan tetap mempertahankan set karakter saat ini.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Kompres Font yang Disematkan**

[compress_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) mengurangi data font yang disematkan dengan menghapus karakter yang tidak digunakan. Ia beroperasi pada font yang sudah disematkan, sehingga pengurangan ukuran bergantung pada seberapa banyak data font yang tidak terpakai yang ada dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Simpan file asli jika penerima mungkin perlu menambahkan teks di kemudian hari. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan bila Anda awalnya menyematkan semua karakter.

## **Tanya Jawab**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan diganti selama rendering?**

Panggil [get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) dalam lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [font substitution](/slides/id/python-net/font-substitution/) dan aturan [font fallback](/slides/id/python-net/fallback-font/). Fallback menangani karakter yang hilang, sehingga penyematan font tidak menyelesaikan karakter yang tidak terdapat dalam font itu sendiri.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang dibutuhkan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya dapat menambah ukuran file yang tidak perlu. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang diinginkan, dengan catatan lisensinya memperbolehkan hal itu.