---
title: Konversi Presentasi PowerPoint ke Markdown di Python via Java
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/python-java/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown di Python via Java serta mengontrol lokasi penyimpanan dan referensi gambar bitmap, metafile, dan SVG yang diekspor."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol bagaimana konten slide dirender, dan menentukan di mana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan merujuknya.

Secara default, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, setel jenis ekspor dengan metode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setExportType) ke nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownexporttype/) . `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` menjaga item yang dikelompokkan bersama untuk mempertahankan hubungan visual mereka. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga callback penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Mengonversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) , kemudian panggil metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Setiap contoh membaca `presentation.pptx` dari direktori kerja saat ini. Instal Aspose.Slides for Python via Java dan runtime Java yang kompatibel sebelum menjalankan contoh. Mulai JVM sekali per proses Python.

## **Pilih Varian Markdown**

Metode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setFlavor) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/python-java/aspose.slides/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Mengekspor Gambar dengan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/) menyediakan dua metode untuk mengonfigurasi gambar yang disimpan secara lokal:

- [setBasePath](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setBasePath) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Perilaku ini juga berfungsi sebagai fallback ketika handler penyimpanan gambar kustom mengembalikan `False`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan metode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/) untuk mendaftarkan callback bagi sumber daya bitmap dan metafile non‑SVG yang dihasilkan selama ekspor Markdown. Callback `MarkdownImageSavingHandler`‑nya menerima objek gambar, nilai [ImageFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/) , dan tautan Markdown yang dihasilkan sebagai parameter `String[]` satu‑elemen. Simpan atau unggah gambar dengan format yang diberikan, dan gantikan `link[0]` dengan referensi yang harus muncul di output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Daftarkan callback dengan metode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/) . Callback `MarkdownSvgImageSavingHandler`‑nya menerima objek [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/) dan parameter `String[] link` satu‑elemen. SVG tidak memiliki argumen `ImageFormat` ; tulis atau unggah data XML‑nya melalui metode [SvgImage.getSvgData](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/#getSvgData) . Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat dirasterkan atau digabungkan dengan konten lain; sumber non‑SVG yang dihasilkan kemudian diteruskan ke callback penyimpanan gambar. Daftarkan kedua callback ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Nilai kembali handler menentukan siapa yang memproses gambar:

- Kembalikan `True` setelah handler menyimpan, mengunggah, mengubah, atau memproses gambar dengan cara lain dan menetapkan nilai valid ke `link[0]`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal default.
- Kembalikan `False` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya sesuai nilai yang ditetapkan dengan [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setBasePath) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) .

{{% alert color="danger" title="Important" %}}
Handler yang mengembalikan `True` bertanggung jawab atas gambar. Jika mengembalikan `True` tanpa menetapkan tautan yang valid dan tidak kosong, ekspor akan gagal dengan `InvalidOperationException` .
{{% /alert %}}

Dalam Python, daftarkan callback ini dengan `jpype.JProxy` , mengimplementasikan antarmuka callback Java melalui metode `invoke`‑nya. Argumen `link` adalah array string Java yang dapat diubah: konversi `link[0]` ke string Python sebelum memprosesnya, lalu tetapkan URL pengganti kembali ke `link[0]`.

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut memperlakukan `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap handler mengekstrak nama file yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan menggantikan referensi lokal yang dihasilkan dengan URL CDN publik. Sampel sendiri tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau file‑filenya dipublikasikan ke CDN. Untuk penyimpanan objek, ganti penulisan file‑system dengan operasi unggah SDK penyimpanan dan tetapkan `link[0]` hanya setelah unggahan berhasil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Handler bitmap sengaja mengembalikan `False` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` menggunakan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Misalnya, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png` . Handler menggunakan path sistem operasi hanya saat menulis file; tautan yang ditulis ke Markdown memakai garis miring maju dan nama file yang di‑URL‑escape. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori spesifik platform.

## **FAQ**

**Apakah satu handler dapat memproses baik gambar raster maupun gambar SVG?**

Tidak. Gunakan [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/) untuk sumber daya bitmap dan metafile yang dihasilkan serta [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/) untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama memberikan objek gambar dan nilai [ImageFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/) ; yang kedua memberikan objek [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/) yang data SVG‑nya dapat dibaca dengan [SvgImage.getSvgData](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/#getSvgData) . SVG sumber yang dirasterkan selama ekspor diproses oleh callback penyimpanan gambar.

**Apa yang terjadi ketika handler penyimpanan gambar mengembalikan `False`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal defaultnya. Lokasi gambar dan referensi yang dihasilkan dikontrol oleh nilai yang ditetapkan dengan [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setBasePath) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) .

**Dapatkah handler menyediakan URL tanpa menyimpan gambar secara lokal?**

Ya. Handler dapat mengunggah gambar ke penyimpanan objek atau meneruskannya ke layanan lain, menetapkan URL yang dihasilkan ke `link[0]`, dan mengembalikan `True`. Handler harus menyelesaikan pemrosesan sendiri; mengembalikan `True` mencegah penyimpanan lokal default.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari handler?**

Pengecualian ini terjadi ketika handler mengembalikan `True` tetapi tidak menyediakan tautan yang valid. Tetapkan path relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `True`.

**Pemisah path mana yang harus digunakan pada tautan gambar?**

Gunakan garis miring maju (`/`) dalam tautan Markdown dan URL. Gunakan `pathlib.Path` hanya untuk path sistem file, kemudian bangun atau normalisasi referensi Markdown secara terpisah.

**Apakah tautan hiperteks dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/python-java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [transitions](/slides/id/python-java/slide-transition/) slide dan [animations](/slides/id/python-java/powerpoint-animation/) tidak dikonversi.

**Dapatkah presentasi dikonversi ke Markdown secara paralel?**

Anda dapat memproses file presentasi yang berbeda secara paralel, tetapi jangan berbagi instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang sama antar thread. Ikuti [multithreading guidelines](/slides/id/python-java/multithreading/) dan gunakan instance terpisah untuk setiap file.