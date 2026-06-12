---
title: Kelola Slide Master Presentasi di JavaScript
linktitle: Master Slide
type: docs
weight: 70
url: /id/nodejs-java/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- kloning master slide
- menyalin master slide
- duplikat master slide
- master slide yang tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk Node.js via Java: mengakses, mengedit, mengkloning, membandingkan, dan menghapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekumpulan slide. Ini dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasanya untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides untuk Node.js via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan setiap master slide dapat berisi beberapa layout slide. Slide biasa biasanya tidak merujuk langsung ke master slide. Sebaliknya, slide biasa menggunakan layout slide, dan layout slide itu dimiliki oleh master slide.

Hierarki nya adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.
1. **Layout slide** – mendefinisikan susunan placeholder dan pemformatan tingkat layout tertentu.
1. **Slide normal** – berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/). Semua master slide dalam sebuah presentasi dapat diakses melalui koleksi `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}

Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika sebuah master slide dan sebuah layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `getMasters()` untuk mengakses master slide:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Anda juga dapat mendapatkan master slide yang digunakan oleh slide normal melalui layoutnya:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Apa yang Dimiliki Slide Master**

Sebuah master slide adalah objek yang mirip slide. Ia mewarisi perilaku slide umum dari [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/), sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master terdaftar pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/).

Anggota master slide yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Menetapkan latar belakang slide tingkat master. |
| `getShapes()` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan layout slide yang dimiliki master. |
| `getThemeManager()` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master serta layout anaknya. |
| `getDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/nodejs-java/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder pada tampilan Slide Master di PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang dimiliki master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder judul yang diformat diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi format placeholder dan teks lainnya, lihat [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) dan [Text Formatting](/nodejs-java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang padat untuk master slide pertama:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk topik terkait, lihat [Presentation Background](/nodejs-java/presentation-background/) dan [Presentation Theme](/nodejs-java/presentation-theme/).

## **Mengkloning Slide Master ke Presentasi Lain**

Gunakan `MasterSlideCollection.addClone` untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide dalam presentasi tujuan.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Jika Anda perlu mengkloning slide normal bersama masternya, lihat [Clone Slides](/nodejs-java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa master slide. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

Contoh berikut mengkloning master default, memberi klon latar belakang yang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/) untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/nodejs-java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal manapun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan template.

Gunakan `removeUnused` untuk menghapus master yang tidak dipakai dari koleksi `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat menggunakan metode low-code `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide berada di bawah slide master dan mendefinisikan susunan placeholder tertentu. Slide normal memakai layout slide, sehingga ia mewarisi baik dari layout maupun master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau ke layout slide?**

Sebagian besar kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, lalu tempatkan placeholder konten pada layout yang akan dipakai slide normal.

**Bisakah saya menghapus slide master yang masih dipakai?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pertama, pindahkan slide‑slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master tidak terpakai yang hanya menghapus master yang tidak dipakai.