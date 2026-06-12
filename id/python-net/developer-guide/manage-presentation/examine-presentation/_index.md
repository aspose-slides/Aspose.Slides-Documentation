---
title: Mengambil dan Memperbarui Informasi Presentasi dalam Python
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/python-net/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mengambil properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Python untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/) serta menunjukkan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lainnya) presentasi tersebut saat ini.

Anda dapat memeriksa format presentasi tanpa memuat presentasi tersebut. Lihat kode Python berikut:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Dapatkan Properti Presentasi**

Kode Python ini menunjukkan cara memperoleh properti presentasi (informasi tentang presentasi):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Anda mungkin ingin melihat [properti di bawah DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/#properties) class.

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki presentasi PowerPoint dengan properti dokumen yang ditampilkan di bawah.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Memeriksa apakah Presentasi terenkripsi](https://docs.aspose.com/slides/id/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah Presentasi dilindungi Tulisan (baca-saja)](https://docs.aspose.com/slides/id/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah Presentasi dilindungi Sandi Sebelum Memuatnya](https://docs.aspose.com/slides/id/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font terembed dan yang mana?**

Cari [informasi font terembed](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pada tingkat presentasi, lalu bandingkan entri tersebut dengan kumpulan [font yang sebenarnya digunakan dalam konten](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasikan melalui [koleksi slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) dan inspeksikan [bendera visibilitas](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/) setiap slide.

**Bisakah saya mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [ukuran slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slide_size/) dan orientasi saat ini dengan preset standar; ini membantu memperkirakan perilaku untuk pencetakan dan ekspor.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Telusuri semua [chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, dan multimedia; berikan skor kompleksitas perkiraan untuk menandai potensi titik panas kinerja.