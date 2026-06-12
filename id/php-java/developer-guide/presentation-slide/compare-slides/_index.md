---
title: Bandingkan Slide Presentasi di PHP
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/php-java/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk PHP via Java. Identifikasi perbedaan slide dalam kode dengan cepat."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda membandingkan slide, slide tata letak, dan slide master menggunakan metode `equals` yang disediakan oleh kelas `BaseSlide`. Metode ini mengembalikan `true` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Bandingkan Dua Slide**

Metode Equals telah ditambahkan ke kelas [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/BaseSlide). Metode ini mengembalikan true untuk slide/tata letak dan slide/master yang identik dalam struktur dan konten statisnya.  

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lainnya, dll., sama. Perbandingan tidak memperhitungkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**Apakah fakta bahwa sebuah slide disembunyikan memengaruhi perbandingan slide itu sendiri?**

[Hidden status](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/gethidden/) merupakan properti tingkat presentasi/pemutaran, bukan konten visual. Kesetaraan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan saja tidak menjadikan slide tersebut berbeda.

**Apakah hyperlink dan parameternya diperhitungkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau aksi hyperlink berbeda, biasanya itu dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah diagram merujuk ke file Excel eksternal, apakah isi file tersebut akan diperhitungkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal umumnya tidak dibaca saat perbandingan; hanya apa yang ada dalam struktur dan keadaan statis slide yang dipertimbangkan.