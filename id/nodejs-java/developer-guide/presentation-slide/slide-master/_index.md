---
title: Kelola Slide Master Presentasi dalam JavaScript
linktitle: Slide Master
type: docs
weight: 70
url: /id/nodejs-java/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- banyak slide master
- bandingkan slide master
- latar belakang
- placeholder
- duplikasi slide master
- salin slide master
- duplikat slide master
- slide master tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk Node.js via Java: akses, edit, duplikat, bandingkan, dan hapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides untuk Node.js via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide biasa biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide biasa menggunakan layout slide, dan layout slide tersebut dimiliki oleh slide master.

Hierarki tersebut adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.  
1. **Layout slide** – mendefinisikan susunan placeholder dan pemformatan tingkat layout tertentu.  
1. **Slide biasa** – berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan slide biasa](slide-master_2.jpg)

Di Aspose.Slides, slide master diwakili oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/). Semua slide master dalam sebuah presentasi dapat diakses melalui koleksi `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `getMasters()` untuk mengakses slide master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Anda juga dapat memperoleh slide master yang digunakan oleh slide biasa melalui layout-nya:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Isi Slide Master**

Slide master adalah objek yang mirip slide. Ia mewarisi perilaku slide umum dari [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/), sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide biasa dan layout slide. Anggota khusus master tercantum pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/).

Anggota master slide yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Menetapkan latar belakang slide pada tingkat master. |
| `getShapes()` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan layout slide yang dimiliki master. |
| `getThemeManager()` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master serta layout turunannya. |
| `getDependingSlides()` | Mengembalikan slide biasa yang bergantung pada master melalui layout-nya. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut akan muncul pada slide yang menggunakan layout dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Mengontrol Visibilitas Grafik Master**

Gunakan [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Berikan `false` ke [Slide.setShowMasterShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#setShowMasterShapes) pada slide yang harus menghilangkan grafik tersebut dan pertahankan `true` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif biru pada master dan dua slide yang menggunakan layout kosong yang sama. Pita tersebut terlihat pada slide pertama dan disembunyikan pada slide kedua. Tidak diperlukan presentasi atau gambar masukan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Contoh ini menggunakan layout **Blank** yang disediakan dengan presentasi baru dan menghapus placeholder slide awal.

### **Pilih Lingkup Pengaturan**

Slide biasa menggunakan master-nya melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getLayoutSlide) dan [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Menetapkan properti pada slide individual hanya mempengaruhi slide tersebut. Memberikan `false` ke [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) menyembunyikan grafik master untuk semua slide yang menggunakan layout bersama itu, meskipun pengaturan mereka sendiri `true`. Untuk menyembunyikan grafik hanya pada satu slide, ubah properti slide tersebut dan biarkan layout bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada master slide itu sendiri. Pada master, [getShowMasterShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) selalu mengembalikan `false`, dan memberikan `true` ke [setShowMasterShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) akan menimbulkan pengecualian. Terapkan pada slide biasa atau layout saja.

### **Bedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengontrol visibilitas bentuk master yang diwariskan tanpa menghapusnya atau mengubah bentuk slide itu sendiri. |
| Ubah isi latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafik master adalah bentuk terpisah dan dapat tetap terlihat di atas latar tersebut. Lihat [Presentation Background](/slides/id/nodejs-java/presentation-background/). |
| Hapus bentuk dari master | Menghapus sumber bentuk bersama, sehingga tidak lagi tersedia untuk slide mana pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh layout, sementara masing‑masing layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder di tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerja pada layout slide yang dimiliki master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder judul yang diformat dan diwariskan oleh slide biasa](slide-master_8.png)

Untuk opsi format placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) dan [Text Formatting](/nodejs-java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menggantinya. Contoh berikut menetapkan warna latar belakang padat untuk master slide pertama:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Menduplikasi Slide Master ke Presentasi Lain**

Gunakan `MasterSlideCollection.addClone` untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Jika Anda perlu menduplikasi slide biasa bersama master-nya, lihat [Clone Slides](/nodejs-java/clone-slides/).

## **Menambahkan Multiple Slide Masters**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut menduplikasi master default, memberikan duplikat latar belakang berbeda, membuat layout di bawah master yang diduplikasi, dan menambahkan slide baru berdasarkan layout tersebut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Membandingkan Slide Masters**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/nodejs-java/compare-slides/).

## **Menetapkan Slide Master View sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka PowerPoint pertama kali. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/nodejs-java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang‑kadang berisi slide master yang tidak lagi dipakai oleh slide biasa mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `removeUnused` untuk menghapus master yang tidak terpakai dari koleksi `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat menggunakan metode low‑code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide termasuk dalam slide master dan mendefinisikan susunan placeholder tertentu. Slide biasa menggunakan layout slide, sehingga ia mewarisi dari layout serta master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau ke layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan dipakai slide biasa.

**Bisakah saya menghapus slide master yang masih dipakai?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung. Pindahkan slide‑slide tersebut ke layout di bawah master lain terlebih dahulu, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.