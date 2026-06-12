---
title: Bandingkan Slide Presentasi dalam C++
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/cpp/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk C++. Identifikasi perbedaan slide dalam kode secara cepat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membandingkan slide, layout slide, dan master slide menggunakan metode `Equals` yang disediakan oleh antarmuka `IBaseSlide` dan kelas `BaseSlide`. Metode ini mengembalikan `true` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Bandingkan Dua Slide**
Metode Equals telah ditambahkan ke antarmuka IBaseSlide dan kelas BaseSlide. Metode ini mengembalikan true untuk slide / layout slide / master slide yang identik berdasarkan struktur dan konten statiknya.

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lainnya, dll. Perbandingan tidak mempertimbangkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Apakah fakta bahwa sebuah slide disembunyikan memengaruhi perbandingan slide itu sendiri?**

[Hidden status](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/get_hidden/) adalah properti tingkat presentasi/pemutaran, bukan konten visual. Kesamaan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan tidak membuat slide tersebut berbeda.

**Apakah tautan hiperteks dan parameternya dipertimbangkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau tindakan hyperlink berbeda, biasanya ini dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah diagram merujuk ke file Excel eksternal, apakah isi file tersebut akan dipertimbangkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal umumnya tidak dibaca saat perbandingan; hanya apa yang ada dalam struktur dan keadaan statis slide yang dipertimbangkan.