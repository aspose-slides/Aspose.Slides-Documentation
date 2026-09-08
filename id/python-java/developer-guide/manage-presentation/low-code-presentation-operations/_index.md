---
title: Operasi Presentasi Low-Code di Python via Java
linktitle: API Low-Code
type: docs
weight: 50
url: /id/python-java/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- menggabungkan presentasi
- mengiterasi slide
- mengiterasi shape
- mengiterasi teks
- mengumpulkan shape
- mengompres presentasi
- menghapus master slide yang tidak terpakai
- menghapus layout slide yang tidak terpakai
- mengompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di Python via Java untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/id/python-java/aspose.slides/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan ke dalam metode terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan kode yang lebih sedikit.

Pembantu low-code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default sesuai dengan kebutuhan Anda. Gunakan [Aspose.Slides object model](https://reference.aspose.com/slides/id/python-java/aspose.slides/) lengkap ketika Anda memerlukan kontrol detail atas slide individu, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Untuk apa |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/python-java/aspose.slides/convert/) | Mengonversi presentasi ke format lain dengan panggilan file-ke-file langsung. |
| [Merger](https://reference.aspose.com/slides/id/python-java/aspose.slides/merger/) | Menggabungkan seluruh file presentasi dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/python-java/aspose.slides/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang disematkan. |

## **Mengonversi Presentasi**

Gunakan [Convert.autoByExtension](https://reference.aspose.com/slides/id/python-java/aspose.slides/convert/#autoByExtension) ketika ekstensi file output sudah cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Kelas [Convert](https://reference.aspose.com/slides/id/python-java/aspose.slides/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/slides/id/python-java/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger.process](https://reference.aspose.com/slides/id/python-java/aspose.slides/merger/#process) untuk menggabungkan seluruh file presentasi dengan satu panggilan. Presentasi input harus memiliki format file yang sama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang slide secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide yang dipilih, menerapkan master atau layout tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/slides/id/python-java/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan memudahkan inspeksi atau perubahan format pada seluruh presentasi.

Contoh berikut menggunakan [ForEach.slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#paragraph), dan [ForEach.portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#portion) untuk memeriksa elemen yang bersesuaian:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Secara default, penelusuran shape dan teks pada seluruh presentasi mencakup slide normal, master, dan layout. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan penelusuran, keluar lebih awal, penyaringan sebelum pemanggilan callback, atau kontrol detail induk‑anak penting.

## **Kumpulkan Shape**

Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/collect/#shapes) ketika Anda memerlukan koleksi semua shape dalam sebuah presentasi daripada callback untuk setiap shape. Ini berguna ketika set yang sama akan difilter, dihitung, atau diproses lebih dari satu kali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#shape) sebagai gantinya ketika setiap shape dapat diproses langsung dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Kompresi Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang disematkan:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) menghapus slide layout yang tidak direferensikan oleh slide normal apa pun.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedMasterSlides) menghapus slide master yang tidak lagi digunakan.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#compressEmbeddedFonts) menghapus karakter yang tidak terpakai dari font yang disematkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin membutuhkan master, layout, atau data font yang disematkan lengkap secara original nanti. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/python-java/slide-master/) dan [Embedded Font](/slides/id/python-java/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code daripada model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar diterapkan pada seluruh file atau presentasi dan tidak memerlukan kontrol detail atas elemen individu. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger.process](https://reference.aspose.com/slides/id/python-java/aspose.slides/merger/#process) memerlukan presentasi input dengan format yang sama. Konversi file input ke format umum terlebih dahulu, misalnya dengan [Convert.autoByExtension](https://reference.aspose.com/slides/id/python-java/aspose.slides/convert/#autoByExtension), kemudian gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach.slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#slide) mengiterasi slide presentasi normal. Operasi [ForEach.shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#paragraph), dan [ForEach.portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#portion) pada seluruh presentasi secara default mencakup slide normal, master, dan layout. Gunakan overload mereka dengan `includeNotes` diset ke `True` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.shape dan Collect.shapes?**

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/#shape) untuk memproses setiap shape secara langsung melalui callback. Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/collect/#shapes) ketika Anda memerlukan hasil yang dapat diiterasi yang dapat disimpan, difilter, dihitung, atau dilalui berkali‑kali.

**Apakah Compress selalu membuat file presentasi menjadi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font yang disematkan dengan karakter yang tidak terpakai. Jika tidak ada yang demikian, operasi [Compress](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/python-java/aspose.slides/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/), panggil [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menulis hasilnya.

## **Artikel Terkait**

- [Convert Presentation](/slides/id/python-java/convert-presentation/)
- [Merge Presentations](/slides/id/python-java/merge-presentation/)
- [Slide Master](/slides/id/python-java/slide-master/)
- [Manage Text Box](/slides/id/python-java/manage-textbox/)
- [Embedded Font](/slides/id/python-java/embedded-font/)