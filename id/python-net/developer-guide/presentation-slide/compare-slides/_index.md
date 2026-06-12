---
title: Bandingkan Slide Presentasi dalam Python
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/python-net/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk Python via .NET. Identifikasi perbedaan slide dalam kode dengan cepat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membandingkan slide, slide tata letak, dan slide master menggunakan metode `equals` yang disediakan oleh kelas `BaseSlide`. Metode ini mengembalikan `True` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Bandingkan Dua Slide**
Metode `equals` telah ditambahkan ke kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/) . Metode ini mengembalikan true untuk slide/tata letak dan slide/master yang identik dalam struktur dan konten statisnya.

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lainnya sama, dll. Perbandingan tidak memperhitungkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Apakah fakta bahwa sebuah slide disembunyikan memengaruhi perbandingan slide itu sendiri?**

[Hidden status](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/) adalah properti tingkat presentasi/pemutaran, bukan konten visual. Kesetaraan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan tidak membuat slide menjadi berbeda.

**Apakah hyperlink dan parameternya diperhitungkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau aksi hyperlink berbeda, hal ini biasanya dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah bagan merujuk ke file Excel eksternal, apakah isi file tersebut akan diperhitungkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal biasanya tidak dibaca pada saat perbandingan; hanya apa yang ada dalam struktur dan keadaan statis slide yang dipertimbangkan.