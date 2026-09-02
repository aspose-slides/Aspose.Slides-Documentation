---
title: Ambil dan Perbarui Informasi Presentasi dengan Python
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/python-net/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- dapatkan properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Python untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/) serta menunjukkan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lain-lain) dari presentasi tersebut saat ini.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode Python berikut:

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

Kode Python berikut menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Anda mungkin ingin melihat [properti di bawah kelas DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/#properties).

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki sebuah presentasi PowerPoint dengan properti dokumen seperti yang ditunjukkan di bawah.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode berikut menunjukkan cara mengedit beberapa properti presentasi:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang telah diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Presentasi dengan Perlindungan Kata Sandi](/slides/id/python-net/password-protected-presentation/)
- [Presentasi dengan Perlindungan Penulisan](/slides/id/python-net/write-protected-presentation/)

## **FAQ**

**Bagaimana cara memeriksa apakah font disematkan dan font mana saja yang disematkan?**

Cari [informasi font yang disematkan](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pada level presentasi, kemudian bandingkan entri tersebut dengan kumpulan [font yang benar-benar digunakan dalam konten](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui [koleksi slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) dan periksa [bendera visibilitas](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/) setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [ukuran slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slide_size/) dan orientasi saat ini dengan preset standar; ini membantu memperkirakan perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah bagan merujuk ke sumber data eksternal?**

Ya. Telusuri semua [bagan](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang mungkin memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi titik kinerja yang lambat.