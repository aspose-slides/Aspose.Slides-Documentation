---
title: Menyimpan Presentasi dalam Python via Java
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/python-java/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke aliran
- tipe tampilan yang ditentukan
- Format Office Open XML Strict
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- Python
- Java
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau aliran dalam Python via Java dengan Aspose.Slides, dan atur output PPTX serta pelaporan progres."
---
## **Gambaran Umum**

Setelah Anda membuat presentasi atau [buka presentasi yang ada](/slides/id/python-java/open-presentation/), gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menulis hasilnya. Aspose.Slides untuk Python via Java dapat menyimpan presentasi ke file atau aliran dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Tambahkan atau modifikasi konten presentasi di sini.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Simpan Presentasi dalam Format Aslinya**

Dalam aplikasi pemrosesan batch, format masukan mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya melalui metode [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSourceFormat). Berikan nilai [SourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/#toSaveFormat) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) yang sesuai, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori masukan, memperbarui judulnya, dan menyimpannya ke direktori keluaran dalam format dari mana file itu dimuat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

SlideUtil.toSaveFormat memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang sesuai. Ia hanya memetakan format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Memberikan nilai [SourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid menghasilkan [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

File PPT, PPS, dan POT warisan menggunakan kontainer biner yang sama. Ketika presentasi semacam itu dimuat dari aliran tanpa ekstensi file, file PPS atau POT mungkin diidentifikasi sebagai PPT. Jika perlu mempertahankan subtipe warisan ini, simpan nama file asli atau metadata format secara terpisah dan gunakan saat memilih nama file dan format keluaran.

## **Simpan Presentasi ke Aliran**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan aliran yang dapat ditulis dan nilai [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan dalam basis data, atau diproses dalam memori.

Contoh berikut menyimpan presentasi baru ke aliran file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Simpan Presentasi dengan Tipe Tampilan yang telah Ditentukan**

Anda dapat menentukan tampilan di mana PowerPoint membuka presentasi yang disimpan pertama kali. Gunakan metode [ViewProperties.setLastView](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#setLastView) dengan nilai [ViewType](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengonfigurasi tampilan Slide Master sebagai tampilan awal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Simpan Presentasi dalam Format Office Open XML yang Strict**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxoptions/) dan gunakan metode [setConformance](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxoptions/#setConformance) dengan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Kemudian berikan opsi tersebut ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi setiap entri, ukuran total arsip, serta jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxoptions/#setZip64Mode) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/id/python-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ZIP64 hanya ketika presentasi melebihi batas ZIP standar. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/python-java/aspose.slides/zip64mode/#Never) menonaktifkan ekstensi ZIP64.
- [Always](https://reference.aspose.com/slides/id/python-java/aspose.slides/zip64mode/#Always) selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi output:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Jika [Zip64Mode.Never](https://reference.aspose.com/slides/id/python-java/aspose.slides/zip64mode/#Never) digunakan dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan menggunakan metode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Kelas [CompressionLevel](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/) menyediakan nilai-nilai berikut:

- [None](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#None) menyimpan data tanpa kompresi.
- [Level1](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level1) memberikan kompresi tercepat dan output terkompresi terbesar.
- [Level2](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level2) hingga [Level5](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level5) secara bertahap lebih mengutamakan output yang lebih kecil daripada kecepatan penyimpanan.
- [Level6](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level6) menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah tingkat default.
- [Level7](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level7) dan [Level8](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level8) lebih mengutamakan output yang lebih kecil daripada kecepatan penyimpanan.
- [Level9](https://reference.aspose.com/slides/id/python-java/aspose.slides/compressionlevel/#Level9) memberikan kompresi terkuat dan memerlukan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Ketika sebuah presentasi disimpan sebagai PPTX, metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol thumbnail dokumen:

- `True` menghasilkan kembali thumbnail selama operasi penyimpanan. Ini adalah nilai default.
- `False` mempertahankan thumbnail yang ada. Jika presentasi tidak memiliki thumbnail, Aspose.Slides tidak akan membuatnya.

Contoh berikut menyimpan presentasi tanpa menyegarkan thumbnailnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran thumbnail dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Laporkan Progres Penyimpanan sebagai Persentase**

Untuk memantau operasi penyimpanan, daftarkan penangkap progres Python melalui `jpype.JProxy` dan berikan ke metode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides kemudian memanggil metode `reporting` penangkap dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Ini menyimpan slide terpilih dari sebuah presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan incremental atau “fast save”?**  
Tidak. Setiap operasi penyimpanan menulis file output lengkap alih-alih memperbarui hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**  
Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) [tidak thread-safe](/slides/id/python-java/multithreading/). Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal ketika saya menyimpan sebuah presentasi?**  
[Hyperlink](/slides/id/python-java/manage-hyperlinks/) tetap ada dalam presentasi. Aspose.Slides tidak menyalin file yang ditautkan secara eksternal, sehingga presentasi yang disimpan tetap harus dapat mengakses lokasi mereka.

**Bisakah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**  
Ya. Atur [properti dokumen](/slides/id/python-java/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides menuliskannya ke file output.