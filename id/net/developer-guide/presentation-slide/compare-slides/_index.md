---
title: Bandingkan Slide Presentasi di .NET
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/net/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk .NET. Identifikasi perbedaan slide dalam kode dengan cepat."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda membandingkan slide, slide tata letak, dan slide master menggunakan metode `Equals` yang disediakan oleh antarmuka `IBaseSlide` dan kelas `BaseSlide`. Metode ini mengembalikan `true` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Bandingkan Dua Slide**

Metode Equals telah ditambahkan ke antarmuka [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide) dan kelas [BaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/baseslide). Metode ini mengembalikan true untuk slide/tata letak dan slide/master yang identik dalam struktur dan konten statisnya.

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lainnya sama. Perbandingan tidak memperhitungkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Apakah fakta bahwa slide disembunyikan memengaruhi perbandingan slide itu sendiri?**

[Hidden status](https://reference.aspose.com/slides/id/net/aspose.slides/slide/hidden/) adalah properti tingkat presentasi/pemutaran, bukan konten visual. Kesamaan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan tidak membuat slide menjadi berbeda.

**Apakah hyperlink dan parameternya dipertimbangkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau aksi hyperlink berbeda, biasanya itu dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah bagan merujuk ke file Excel eksternal, apakah isi file tersebut akan dipertimbangkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal biasanya tidak dibaca pada saat perbandingan; hanya apa yang ada dalam struktur dan keadaan statis slide yang dipertimbangkan.