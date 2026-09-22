---
title: Simpan Presentasi dalam Python
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/python-net/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang ditentukan
- Format Office Open XML yang Ketat
- mode Zip64
- memperbarui gambar mini
- proses penyimpanan
- Python
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau stream dalam Python dengan Aspose.Slides, dan konfigurasikan opsi output PPTX."
---
## **Gambaran Umum**

Setelah Anda membuat presentasi atau [buka presentasi yang ada](/slides/id/python-net/open-presentation/), gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/) untuk menulis hasilnya. Aspose.Slides untuk Python via .NET dapat menyimpan presentasi ke file atau stream dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Tambahkan atau ubah konten presentasi di sini.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi dalam Format Aslinya**

Untuk contoh deteksi file dan stream, perilaku presentasi yang baru dibuat, serta perbedaan antara format sumber dan output, lihat [Determine the Original Presentation Format](/slides/id/python-net/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format input mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dari properti [Presentation.source_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/source_format/). Berikan nilai [SourceFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil.to_save_format](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/to_save_format/) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) yang sesuai, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori input, memperbarui judulnya, dan menyimpannya ke direktori output dalam format yang sama dengan format saat dimuat:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/to_save_format/) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang sesuai. Ia hanya memetakan format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Memberikan nilai [SourceFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid akan menimbulkan pengecualian.

File PPT, PPS, dan POT lama menggunakan wadah biner yang sama. Ketika presentasi semacam itu dimuat dari stream tanpa ekstensi file, file PPS atau POT dapat diidentifikasi sebagai PPT. Jika diperlukan untuk mempertahankan subtipe lama ini, simpan nama file atau metadata format asli secara terpisah dan gunakan saat memilih nama file dan format output.

## **Simpan Presentasi ke Stream**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan stream [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) yang dapat ditulisi dan nilai [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan dalam basis data, atau diproses di memori.

Contoh berikut menyimpan presentasi baru ke stream file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi dengan Jenis Tampilan yang Telah Ditentukan**

Anda dapat menentukan tampilan di mana PowerPoint membuka presentasi yang disimpan secara default. Atur properti [ViewProperties.last_view](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/last_view/) ke nilai [ViewType](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengatur tampilan Slide Master sebagai tampilan awal:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi dalam Format Office Open XML yang Ketat**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/) dan atur properti [conformance](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/conformance/) menjadi `Conformance.ISO_29500_2008_STRICT`. Kemudian berikan opsi tersebut ke metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi setiap entri, total ukuran arsip, serta jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan properti [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- `IF_NECESSARY` menggunakan ZIP64 hanya ketika presentasi melampaui batas ZIP standar. Ini adalah mode default.
- `NEVER` menonaktifkan ekstensi ZIP64.
- `ALWAYS` selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi output:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Jika `Zip64Mode.NEVER` digunakan dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan menimbulkan [PptxException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan mengatur properti [PptxOptions.compression_level](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/compression_level/). Enum [CompressionLevel](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/) menyediakan nilai berikut:

- `NONE` menyimpan data tanpa kompresi.
- `LEVEL1` memberikan kompresi tercepat dan output terkompresi terbesar.
- `LEVEL2` hingga `LEVEL5` secara bertahap lebih mengutamakan ukuran output yang lebih kecil daripada kecepatan penyimpanan.
- `LEVEL6` menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah tingkat default.
- `LEVEL7` dan `LEVEL8` lebih mengutamakan ukuran output yang lebih kecil daripada kecepatan penyimpanan.
- `LEVEL9` memberikan kompresi terkuat dan memerlukan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Simpan Presentasi tanpa Memperbarui Gambar Mini**

Saat presentasi disimpan sebagai PPTX, properti [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) mengontrol gambar mini dokumen:

- `True` menghasilkan kembali gambar mini selama operasi penyimpanan. Ini adalah nilai default.
- `False` mempertahankan gambar mini yang ada. Jika presentasi tidak memiliki gambar mini, Aspose.Slides tidak akan membuatnya.

Contoh berikut menyimpan presentasi tanpa memperbarui gambar mini:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran gambar mini dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide yang dipilih dari presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan inkremental atau “fast save”?**

Tidak. Setiap operasi penyimpanan menulis file output lengkap alih-alih memperbarui hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) **tidak thread-safe** (/slides/id/python-net/multithreading/). Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang terhubung secara eksternal ketika saya menyimpan presentasi?**

[Hyperlink](/slides/id/python-net/manage-hyperlinks/) tetap ada dalam presentasi. Aspose.Slides tidak menyalin file yang terhubung secara eksternal, sehingga presentasi yang disimpan masih harus dapat mengakses lokasi tersebut.

**Bisakah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

Ya. Atur [properti dokumen](/slides/id/python-net/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menuliskannya ke file output.