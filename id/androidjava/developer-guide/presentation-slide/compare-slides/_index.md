---
title: Bandingkan Slide Presentasi di Android
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/androidjava/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk Android. Identifikasi perbedaan slide dalam kode Java dengan cepat."
---
## **Overview**

Aspose.Slides memungkinkan Anda membandingkan slide, slide tata letak, dan slide master dengan menggunakan metode `equals` yang disediakan oleh antarmuka `IBaseSlide` dan kelas `BaseSlide`. Metode ini mengembalikan `true` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Compare Two Slides**
Metode Equals telah ditambahkan ke antarmuka [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBaseSlide) dan kelas [BaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/BaseSlide). Metode ini mengembalikan true untuk slide/tata letak dan slide/master yang identik dalam struktur dan konten statisnya.

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lain, dll., sama. Perbandingan tidak memperhitungkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**Apakah fakta bahwa sebuah slide disembunyikan memengaruhi perbandingan slide itu sendiri?**

[Hidden status](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#getHidden--) adalah properti tingkat presentasi/pemutaran, bukan konten visual. Kesetaraan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan tidak membuat slide tersebut berbeda.

**Apakah hyperlink dan parameternya diperhitungkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau tindakan hyperlink berbeda, biasanya dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah diagram merujuk ke file Excel eksternal, apakah konten file tersebut akan diperhitungkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal biasanya tidak dibaca pada saat perbandingan; hanya apa yang ada dalam struktur dan keadaan statis slide yang dipertimbangkan.