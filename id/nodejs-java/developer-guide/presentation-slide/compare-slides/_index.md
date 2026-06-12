---
title: Bandingkan Slide Presentasi dalam JavaScript
linktitle: Bandingkan Slide
type: docs
weight: 50
url: /id/nodejs-java/compare-slides/
keywords:
- bandingkan slide
- perbandingan slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bandingkan presentasi PowerPoint dan OpenDocument secara programatis dengan Aspose.Slides untuk Node.js melalui Java. Identifikasi perbedaan slide dalam kode dengan cepat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membandingkan slide, slide tata letak, dan slide master menggunakan metode `equals` yang disediakan oleh kelas `BaseSlide`. Metode ini mengembalikan `true` ketika slide yang dibandingkan identik dalam struktur dan konten statisnya.

## **Bandingkan Dua Slide**

Metode Equals telah ditambahkan ke kelas [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide) dan kelas [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide). Metode ini mengembalikan true untuk slide/tata letak dan slide/master yang identik dalam struktur dan konten statisnya.  

Dua slide dianggap sama jika semua bentuk, gaya, teks, animasi, dan pengaturan lainnya, dll., sama. Perbandingan tidak memperhitungkan nilai pengidentifikasi unik, misalnya SlideId, serta konten dinamis, misalnya nilai tanggal saat ini dalam Placeholder Tanggal.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

Status tersembunyi ([Hidden status](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/gethidden/)) merupakan properti tingkat presentasi/pemutaran, bukan konten visual. Kesamaan dua slide tertentu ditentukan oleh struktur dan konten statisnya; fakta bahwa sebuah slide disembunyikan tidak membuat slide tersebut berbeda.

**Apakah tautan hiperteks dan parameternya dipertimbangkan?**

Ya. Tautan merupakan bagian dari konten statis slide. Jika URL atau aksi tautan berbeda, hal ini biasanya dianggap sebagai perbedaan dalam konten statis.

**Jika sebuah diagram merujuk ke file Excel eksternal, apakah isi file tersebut dipertimbangkan?**

Tidak. Perbandingan dilakukan berdasarkan slide itu sendiri. Sumber data eksternal biasanya tidak dibaca pada saat perbandingan; hanya apa yang ada dalam struktur dan status statis slide yang dipertimbangkan.