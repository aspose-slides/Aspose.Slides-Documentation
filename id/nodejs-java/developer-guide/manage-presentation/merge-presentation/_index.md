---
title: Gabungkan Presentasi Secara Efisien dengan JavaScript
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/nodejs-java/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- menggabungkan PowerPoint
- menggabungkan presentasi
- menggabungkan slide
- menggabungkan PPT
- menggabungkan PPTX
- menggabungkan ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Dengan mudah menggabungkan presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) dalam JavaScript menggunakan Aspose.Slides untuk Node.js, menyederhanakan alur kerja Anda."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggabungkan presentasi dengan menyalin slide dari satu presentasi ke presentasi lain. Artikel ini menjelaskan cara menggabungkan seluruh presentasi atau slide yang dipilih, menggunakan slide master atau tata letak tertentu selama penggabungan, menangani presentasi dengan ukuran slide berbeda, dan menambahkan slide yang digabung ke bagian presentasi. Artikel ini juga mencakup catatan praktis terkait konten yang digabung, termasuk catatan pembicara, komentar, file sumber yang dilindungi kata sandi, dan penggunaan thread.

## **Penggabungan Presentasi**

Saat Anda menggabungkan satu presentasi ke yang lain, Anda pada dasarnya menggabungkan slide‑slide mereka dalam satu presentasi untuk menghasilkan satu file. 

{{% alert title="Info" color="info" %}}

Sebagian besar program presentasi (PowerPoint atau OpenOffice) tidak memiliki fungsi yang memungkinkan pengguna menggabungkan presentasi dengan cara tersebut. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/id/nodejs-java/), bagaimanapun, memungkinkan Anda menggabungkan presentasi dengan berbagai cara. Anda dapat menggabungkan presentasi beserta semua bentuk, gaya, teks, pemformatan, komentar, animasi, dll. tanpa harus khawatir kehilangan kualitas atau data.

**Lihat juga**

[Clone Slides](https://docs.aspose.com/slides/id/nodejs-java/clone-slides/).

{{% /alert %}}

### **Apa yang Dapat Digabung**

Dengan Aspose.Slides, Anda dapat menggabungkan 

* seluruh presentasi. Semua slide dari presentasi tersebut akan berada dalam satu presentasi
* slide tertentu. Slide yang dipilih akan berada dalam satu presentasi
* presentasi dalam satu format (PPT ke PPT, PPTX ke PPTX, dll) dan dalam format yang berbeda (PPT ke PPTX, PPTX ke ODP, dll) satu sama lain. 

### **Opsi Penggabungan**

Anda dapat menerapkan opsi yang menentukan apakah

* setiap slide dalam presentasi keluaran mempertahankan gaya unik
* gaya tertentu digunakan untuk semua slide dalam presentasi keluaran. 

Untuk menggabungkan presentasi, Aspose.Slides menyediakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (dari kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection)). Ada beberapa implementasi metode `addClone` yang menentukan parameter proses penggabungan presentasi. Setiap objek Presentation memiliki koleksi [Slides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) , sehingga Anda dapat memanggil metode `addClone` dari presentasi yang ingin Anda tambahkan slide.

Metode `addClone` mengembalikan objek `Slide`, yang merupakan klon dari slide sumber. Slide‑slide dalam presentasi keluaran hanyalah salinan dari slide sumber. Oleh karena itu, Anda dapat mengubah slide yang dihasilkan (misalnya, menerapkan gaya atau opsi pemformatan atau tata letak) tanpa khawatir presentasi sumber terpengaruh. 

## **Menggabungkan Presentasi** 

Aspose.Slides menyediakan metode [**AddClone(ISlide)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang memungkinkan Anda menggabungkan slide sambil mempertahankan tata letak dan gaya slide (parameter default).

Kode JavaScript berikut menunjukkan cara menggabungkan presentasi:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Menggabungkan Presentasi dengan Slide Master**

Aspose.Slides menyediakan metode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) yang memungkinkan Anda menggabungkan slide sambil menerapkan templat slide master. Dengan cara ini, bila diperlukan, Anda dapat mengubah gaya slide dalam presentasi keluaran.

Kode JavaScript berikut mendemonstrasikan operasi yang dijelaskan:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Tata letak slide untuk slide master ditentukan secara otomatis. Ketika tata letak yang sesuai tidak dapat ditentukan, jika parameter boolean `allowCloneMissingLayout` dari metode `addClone` diset ke true, tata letak slide sumber akan digunakan. Jika tidak, [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PptxEditException) akan dilempar.

{{% /alert %}}

Jika Anda menginginkan slide dalam presentasi keluaran memiliki tata letak slide yang berbeda, gunakan metode [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) sebagai gantinya saat menggabungkan.

## **Menggabungkan Slide Tertentu dari Presentasi**

Menggabungkan slide tertentu dari beberapa presentasi berguna untuk membuat deck slide khusus. Aspose.Slides for Node.js via Java memungkinkan Anda memilih dan mengimpor hanya slide yang Anda butuhkan. API mempertahankan pemformatan, tata letak, dan desain slide asli.

Kode JavaScript berikut membuat presentasi baru, menambahkan slide judul dari dua presentasi lain, dan menyimpan hasilnya ke file:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Menggabungkan Presentasi dengan Tata Letak Slide**

Kode JavaScript berikut menunjukkan cara menggabungkan slide dari presentasi sambil menerapkan tata letak slide pilihan Anda untuk menghasilkan satu presentasi keluaran:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

{{% alert title="Note" color="warning" %}} 

Anda tidak dapat menggabungkan presentasi dengan ukuran slide yang berbeda. 

{{% /alert %}}

Untuk menggabungkan 2 presentasi dengan ukuran slide berbeda, Anda harus mengubah ukuran salah satu presentasi agar ukurannya cocok dengan presentasi yang lain. 

Kode contoh berikut mendemonstrasikan operasi yang dijelaskan:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Menggabungkan Slide ke Bagian Presentasi**

Kode JavaScript berikut menunjukkan cara menggabungkan slide tertentu ke sebuah bagian dalam presentasi:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Slide ditambahkan di akhir bagian. 

## **FAQ**

**Apakah catatan pembicara dipertahankan selama penggabungan?**

Ya. Saat menyalin slide, Aspose.Slides membawa semua elemen slide, termasuk catatan, pemformatan, dan animasi.

**Apakah komentar dan penulisnya dipindahkan?**

Komentar, sebagai bagian dari konten slide, disalin bersama slide. Label penulis komentar dipertahankan sebagai objek komentar dalam presentasi yang dihasilkan.

**Bagaimana jika presentasi sumber dilindungi kata sandi?**

Presentasi harus [dibuka dengan kata sandi](/slides/id/nodejs-java/password-protected-presentation/) melalui [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/setpassword/); setelah dimuat, slide tersebut dapat dengan aman diklon ke file target yang tidak dilindungi (atau yang dilindungi juga).

**Seberapa aman operasi penggabungan terhadap thread?**

Jangan gunakan instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang sama dari [multiple threads](/slides/id/nodejs-java/multithreading/). Aturan yang disarankan adalah "satu dokumen — satu thread"; file berbeda dapat diproses secara paralel pada thread terpisah.

## **Lihat Juga**

Aspose menyediakan [FREE Online Collage Maker](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan lainnya.

Coba [Aspose FREE Online Merger](https://products.aspose.app/slides/id/merger). Layanan ini memungkinkan Anda menggabungkan presentasi PowerPoint dalam format yang sama (misalnya PPT ke PPT, PPTX ke PPTX) atau lintas format yang berbeda (misalnya PPT ke PPTX, PPTX ke ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/id/merger)