---
title: Kelola Transisi Slide dalam Presentasi Menggunakan JavaScript
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/nodejs-java/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- menerapkan transisi slide
- transisi slide lanjutan
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan transisi Morph serta efek transisi lainnya dengan Aspose.Slides untuk Node.js melalui Java."
---
## **Ikhtisar**

Transisi slide mengontrol cara slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk Node.js melalui Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh JavaScript untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Gunakan [setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setType) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitiontype/), lalu simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama sebuah slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) mengaktifkan kemajuan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan berwaktu agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk hanya menggunakan timer, kirim `false` ke [setAdvanceOnClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Penundaan mengatur kapan pertunjukan slide maju; itu tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat maju slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Untuk memeriksa apakah kemajuan berwaktu diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Penundaan yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [setDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setDuration) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) pada slide mengekspos pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Mengatur durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Mengatur penundaan sebelum slide maju secara otomatis, dalam milidetik. Kirim `true` ke [setAdvanceAfter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Ini digunakan ketika durasi tepat tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setDuration) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk ritme yang konsisten, terapkan efek yang sama dan durasi tepat pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan melalui klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Atur Durasi Berbeda untuk Setiap Slide**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan sebuah [animated GIF](/slides/id/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/nodejs-java/export-to-html5/), atau [video](/slides/id/nodejs-java/convert-powerpoint-to-video/), setel durasi transisi yang tepat sebelum diekspor agar sesuai dengan kecepatan yang diinginkan. Misalnya, gunakan fade 600 milidetik antara adegan, dan sesuaikan penundaan kemajuan tiap slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik setara dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi di pengaturan ekspor. Periksa efek dan opsi timing yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getDuration) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit tersimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diset bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transisi Morph**

Transisi Morph menganimasi perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, kloning sebuah slide, pindahkan atau ubah ukuran sebuah objek pada klon, dan terapkan transisi Morph pada slide kedua. Ini memberikan objek yang sesuai untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, mengkloning slide, dan mengubah posisi serta ukuran persegi panjang pada klon. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan dalam penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionmorphtype/) mengontrol bagaimana Morph mencocokkan dan menganimasi konten:

- [ByObject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) menganggap setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) menganimasi teks dengan mencocokkan kata‑kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) menganimasi teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setType) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getValue). Nilai tersebut kemudian menyediakan objek [MorphTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/morphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/morphtransition/#setMorphType)‑nya memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Atur Efek Transisi**

Beberapa transisi mengungkapkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setType). Tetapkan jenis terlebih dahulu, kemudian gunakan objek transisi yang sesuai dari [getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Utamakan [setDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setDuration) saat Anda membutuhkan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang disetel. Pengaturan ini mengontrol efek transisi secara terpisah dari penundaan kemajuan otomatis.

**Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setSound), kirim `StartSound` dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) dengan `true`. Audio akan berulang hingga event suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Iterasi melalui koleksi [getSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSlides) pada presentasi dan panggil [setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#setType) dengan nilai yang sama untuk setiap transisi slide. Atur opsi timing dan efek apapun dalam loop yang sama untuk menjaga perilaku konsisten di seluruh slide.

**Bagaimana cara memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?**

Panggil [getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/#getType) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitiontype/); `None` berarti tidak ada efek transisi yang diterapkan.