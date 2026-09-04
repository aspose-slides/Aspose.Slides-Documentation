---
title: Format File yang Didukung
type: docs
weight: 30
url: /id/python-java/supported-file-formats/
keywords:
- format file yang didukung
- format presentasi
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- gambar slide
- Python
- Aspose.Slides for Python via Java
description: "Jelajahi format presentasi, dokumen, web, dan gambar yang dapat dimuat, diimpor, disimpan, dan diekspor oleh Aspose.Slides for Python via Java."
---
## **Ikhtisar**

Aspose.Slides for Python via Java membaca dan menulis presentasi PowerPoint serta OpenDocument. Ia juga mengimpor konten PDF dan HTML ke dalam slide serta mengekspor presentasi atau slide individu ke format dokumen, web, dan gambar.

Tabel di bawah ini membedakan pemuatan presentasi dari impor konten dan perenderan slide. Untuk gambaran umum tentang kemampuan penyuntingan dan perenderan, lihat [Features Overview](/slides/id/python-java/features-overview/).

## **Versi Microsoft PowerPoint yang Didukung**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint untuk Mac
- PowerPoint untuk Microsoft 365 (sebelumnya Office 365)


## **Format File yang Didukung**

Tabel berikut mencantumkan format input dan output yang didukung. **Muat / Impor** mencakup membuka berkas presentasi serta mengimpor konten PDF atau HTML. **Simpan / Ekspor** mencakup menyimpan presentasi dan merender slide ke gambar. Garis miring berarti operasi tersebut tidak didukung sebagai operasi konversi presentasi.

|**Format**|**Deskripsi**|**Muat / Impor**|**Simpan / Ekspor**|**Catatan**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentasi PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Templat PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Tayangan PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentasi PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Templat PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Tayangan PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentasi PowerPoint dengan Makro|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Tayangan PowerPoint dengan Makro|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Templat PowerPoint dengan Makro|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentasi OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Format OpenDocument terpaket.|
|FODP|Presentasi OpenDocument XML Datar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Menyimpan presentasi sebagai satu dokumen XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Templat Presentasi OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|{{< emoticons/tick >}}|Mendukung output multi‑halaman.|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|{{< emoticons/tick >}}|Mengekspor slide individu sebagai gambar vektor.|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|{{< emoticons/tick >}}|Mengimpor halaman PDF sebagai slide; mengekspor presentasi ke PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|{{< emoticons/tick >}}|Output dokumen berlayout tetap.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Gambar JPEG|—|{{< emoticons/tick >}}|Merender slide individu sebagai gambar raster.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Merender slide individu sebagai gambar raster.|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|{{< emoticons/tick >}}|Output gambar.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Gambar Bitmap|—|{{< emoticons/tick >}}|Merender slide individu sebagai gambar raster.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|{{< emoticons/tick >}}|Mengekspor slide individu sebagai gambar vektor.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Output Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|{{< emoticons/tick >}}|Mengimpor konten HTML sebagai slide; mendukung ekspor HTML dan HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|{{< emoticons/tick >}}|Mengekspor konten presentasi sebagai XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Mengekspor konten presentasi ke Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Presentasi XML PowerPoint|—|{{< emoticons/tick >}}|Output XML khusus PowerPoint, bukan XML semb arbitrer.|

## **Catatan Impor dan Ekspor**

- **Impor PDF dan HTML:** Gunakan [SlideCollection.addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addfrompdf) atau [SlideCollection.addFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addfromhtml) untuk membuat slide dari konten sumber dan menambahkannya ke presentasi.
- **Output presentasi:** [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) mencantumkan format penyimpanan presentasi yang tersedia, termasuk opsi ekspor HTML dan HTML5 terpisah.
- **Output gambar:** Mengekspor slide ke gambar menghasilkan representasi visual slide tersebut. Kolom input tidak menjelaskan apakah gambar dapat disisipkan ke dalam presentasi.

## **Tanya Jawab**

**Bisakah saya mengonversi presentasi PPT ke PPTX atau ODP?**

Ya. PPT didukung sebagai format input, dan baik PPTX maupun ODP didukung sebagai format output. Hasil konversi bergantung pada fitur yang tersedia di format tujuan.

**Apakah impor PDF atau HTML membuka sumber sebagai berkas PowerPoint?**

Tidak. Impor membuat slide dari halaman PDF atau konten HTML. Anda kemudian dapat menyimpan presentasi yang dihasilkan dalam format presentasi yang didukung.

**Bisakah saya memuat PNG atau SVG yang diekspor sebagai presentasi yang dapat diedit?**

Tidak. Ekspor ini menggambarkan tampilan slide. Simpan presentasi sumber bila Anda perlu menyunting teks, bentuk, diagram, dan objek lainnya di kemudian hari.