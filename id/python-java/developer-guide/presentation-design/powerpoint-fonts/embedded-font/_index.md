---
title: Menyematkan Font dalam Presentasi dengan Python via Java
linktitle: Font yang Disematkan
type: docs
weight: 40
url: /id/python-java/embedded-font/
keywords:
- menambah font
- menyematkan font
- penyematan font
- mendapatkan font yang disematkan
- menambah font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola font yang disematkan dalam PowerPoint dengan Aspose.Slides untuk Python via Java. Tambahkan, ambil, hapus, dan kompres font untuk mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut meskipun tidak terpasang di sistem target. Hal ini membantu mempertahankan jeda baris, jarak teks, dan tata letak slide.

Aspose.Slides for Python via Java memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui kelas [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) yang dikembalikan oleh [Presentation.getFontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getFontsManager). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data font tersedia untuk Aspose.Slides dan lisensinya mengizinkan penyematan.

## **Mendapatkan dan Menghapus Font yang Disematkan**

Gunakan [getEmbeddedFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) untuk melihat daftar font yang disimpan dalam presentasi. Untuk menghapus satu font, beri font tersebut dari daftar ke [removeEmbeddedFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), lalu simpan presentasinya.

Contoh berikut menampilkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Menghapus font yang disematkan menghilangkan data font yang disimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font tersebut terpasang di sistem target, teks masih dapat menggunakan font itu. Jika tidak, proses rendering mungkin memerlukan substitusi font, yang dapat memengaruhi tata letak.

## **Memeriksa Data Font dan Izin Penyematan**

Gunakan kelas [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [FontsManager.getFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFonts) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [FontData](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontstyletype/) yang diperlukan ke [FontsManager.getFontBytes](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFontBytes). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `None` ketika font atau gaya yang diminta tidak tersedia. Jangan berikan hasil `None` ke [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), karena metode itu memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/python-java/aspose.slides/embeddinglevel/) adalah enumerasi flags yang melaporkan pembatasan penyematan yang tersimpan dalam font:

- `Installable` memperbolehkan penyematan dan instalasi permanen pada sistem lain, sesuai lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik hukum font ketika flag ini merupakan satu‑satunya flag izin penggunaan.
- `PreviewPrint` memperbolehkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat hanya‑baca.
- `Editable` memperbolehkan penggunaan sementara dan memungkinkan dokumen diedit serta disimpan.
- `NoSubsetting` adalah pembatas tambahan yang melarang penyematan hanya sebagian glyph. Sematkan semua karakter bila flag ini ada.
- `BitmapOnly` adalah pembatas tambahan yang hanya memperbolehkan bitmap strikes disematkan, bukan data outline. Jika font tidak memiliki bitmap strikes, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `Installable` bernilai nol, maskelah bit izin penggunaan dan bandingkan hasilnya dengan `Installable` alih‑alih memeriksanya sebagai flag. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin paling tidak restriktif: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal‑miring yang tersedia untuk setiap font yang dikembalikan oleh `getFonts`. Ia melewati gaya yang tidak tersedia, font yang dibatasi, font bitmap‑only, font yang terbatas pada preview dan print karena output tetap dapat diedit, serta font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, semua karakter disematkan untuk keluarga font tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ia tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara legal, atau menggantikan pemeriksaan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Menambahkan Font yang Disematkan**

Gunakan [addEmbeddedFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) untuk menyematkan font. Overload‑nya menerima baik objek [FontData](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/python-java/aspose.slides/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- [All](https://reference.aspose.com/slides/id/python-java/aspose.slides/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/id/python-java/aspose.slides/embedfontcharacters/) menyematkan hanya karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk penayangan.

Contoh berikut menggunakan [getFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFonts) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan yang belum disematkan. Font yang akan ditambah harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan tetap mempertahankan set karakter saat ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengompresi Font yang Disematkan**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#compressEmbeddedFonts) mengurangi data font yang disematkan dengan menghapus karakter yang tidak terpakai. Ia beroperasi pada font yang sudah disematkan, jadi pengurangan ukuran bergantung pada berapa banyak data font yang tidak terpakai yang ada dalam presentasi.

Contoh berikut mengompresi font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Simpan file asli jika penerima mungkin perlu menambahkan teks nanti. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika sebelumnya Anda menyematkan semua karakter.

## **FAQ**

**Bagaimana cara memeriksa apakah font yang disematkan masih akan disubstitusi selama rendering?**

Panggil [getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) di lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan substitusi font dan aturan fallback font. Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak ada dalam font itu sendiri.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang diperlukan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya dapat menambah ukuran file yang tidak perlu. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang dimaksud, dengan catatan lisensinya mengizinkannya.