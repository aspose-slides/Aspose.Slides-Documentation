---
title: Mengelola Transisi Slide dalam Presentasi Menggunakan Java
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/java/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- menerapkan transisi slide
- transisi slide lanjutan
- transisi morph
- jenis transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Menerapkan transisi slide, mengonfigurasi kemajuan slide otomatis, dan menyesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk Java."
---
## **Ringkasan**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides for Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi spesifik untuk sebuah efek. Artikel ini menggunakan contoh Java untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh tersebut juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Gunakan [setType](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setType-int-) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitiontype/), lalu simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama sebuah slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) memungkinkan penonton untuk melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) mengaktifkan kemajuan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan baik klik maupun kemajuan berbasis timer agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, berikan `false` ke [setAdvanceOnClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Penundaan mengontrol kapan pertunjukan slide maju; itu tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat maju slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Untuk memeriksa apakah kemajuan berbasis timer diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Penundaan yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Itu mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [setDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setDuration-int-) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) pada slide mengungkapkan pengaturan ini melalui [ISlideShowTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Mengatur durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Mengatur penundaan sebelum slide maju secara otomatis, dalam milidetik. Berikan `true` ke [setAdvanceAfter](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Memilih kategori kecepatan yang telah ditentukan sebelumnya dari [TransitionSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi tepat tidak ditentukan. |

[setDuration] mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [getSpeed].

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk kecepatan yang konsisten, terapkan efek dan durasi tepat yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitiontype/), dan memberikan setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Atur Durasi Berbeda untuk Setiap Slide**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini mengatur 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/java/export-to-html5/), atau [video](/slides/id/java/convert-powerpoint-to-video/), atur durasi transisi yang tepat sebelum mengekspor untuk menyesuaikan kecepatan yang diinginkan. Misalnya, gunakan fade 600 milidetik antar adegan, dan sesuaikan penundaan kemajuan masing‑masing slide secara terpisah agar ada waktu untuk narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik bersamaan dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#getDuration--) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan nilai [getSpeed] untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dulu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transisi Morph**

Transisi Morph menganimasi perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, gandakan slide, pindahkan atau ubah ukuran objek pada salinan, dan terapkan transisi Morph ke slide kedua. Ini memberi transisi objek‑objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menggandakan slide, dan mengubah posisi serta ukuran persegi panjang pada salinan. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan dalam penampil presentasi yang mendukung Morph untuk melihat efek selama pertunjukan slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasi konten:

- [ByObject](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionmorphtype/#ByObject) menganggap setiap shape sebagai objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionmorphtype/#ByWord) menganimasi teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionmorphtype/#ByChar) menganimasi teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setType-int-) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#getValue--). Nilai tersebut kemudian menyediakan antarmuka [IMorphTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/imorphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/id/java/com.aspose.slides/imorphtransition/#setMorphType-int-) memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Atur Efek Transisi**

Beberapa transisi menampilkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setType-int-). Tetapkan tipe terlebih dulu, lalu gunakan antarmuka yang tepat dari [getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#getValue--).

Contoh berikut menerapkan transisi Cut ke slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) melalui [IOptionalBlackTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioptionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bisakah saya mengontrol kecepatan pemutaran transisi slide?**

Ya. Pilih [setDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ketika kategori kecepatan yang telah ditentukan sebelumnya dari [TransitionSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionspeed/)—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang ditetapkan. Pengaturan ini mengontrol efek transisi secara terpisah dari penundaan kemajuan otomatis.

**Bisakah saya menambahkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), berikan StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) dengan `true`. Audio akan berulang hingga peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Iterasi koleksi [getSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSlides--) pada presentasi dan panggil [setType](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#setType-int-) dengan nilai yang sama untuk setiap transisi slide. Tetapkan opsi waktu dan efek apa pun dalam loop yang sama untuk menjaga perilaku konsisten di semua slide.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini diterapkan pada slide?**

Panggil [getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideshowtransition/#getType--) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.