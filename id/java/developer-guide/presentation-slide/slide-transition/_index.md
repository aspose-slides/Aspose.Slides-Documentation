---
title: Kelola Transisi Slide pada Presentasi dengan Java
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/java/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- terapkan transisi slide
- transisi slide lanjutan
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan transisi Morph serta efek transisi lainnya dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides for Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan melalui klik mouse atau timer, dan menyesuaikan opsi yang spesifik untuk suatu efek. Artikel ini menggunakan contoh Java untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola timing slide, dan membuat transisi Morph antara dua slide. Contoh-contoh tersebut juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Gunakan [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), kemudian simpan presentasi.

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

## **Transisi Roda**

Metode [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) pada [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) mengontrol jumlah sektor radial yang mengungkap slide tujuan. Atur tipe transisi slide menjadi Wheel dari [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) menggunakan [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) sebelum mengakses [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) sebagai [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Contoh ini membuat dua pasang slide identik: slide hitam diikuti oleh slide dengan persegi panjang emas. Slide tujuan menggunakan jumlah spoke 1 dan 8, dengan kecepatan yang sama diatur melalui [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) dan durasi eksplisit 8.000 milidetik yang diatur melalui [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) untuk memudahkan pengamatan perbedaannya.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Buka presentasi output di PowerPoint dan jalankan pertunjukan slide. Lanjutkan dari slide 1 ke slide 2, lalu dari slide 3 ke slide 4. Pada pemutaran PowerPoint, jumlah spoke yang diverifikasi 1 mengungkap slide dengan satu sapuan searah jarum jam; jumlah 8 mengungkapnya melalui delapan sektor radial secara bersamaan. Konten tujuan dan timing transisi identik, sehingga perbedaannya hanya pada jumlah sektor pengungkapan.

## **Fade Through Black dengan Transisi Reveal**

Atur tipe transisi slide tujuan menjadi Reveal, lalu panggil [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) pada pengaturan [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/). Contoh ini membuat slide sumber berwarna teal dan slide tujuan berwarna coral, kemudian menggandakan keduanya. Setiap pasang menggunakan transisi Reveal dua detik yang sama. Hanya pasang kedua yang melakukan fade melalui hitam.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Buka presentasi yang disimpan di PowerPoint dan mulai pertunjukan slide. Lanjutkan dari slide 1 ke slide 2 untuk melihat teal memudar langsung ke coral. Kemudian lanjutkan dari slide 3 ke slide 4. Layar singkat menjadi hampir hitam sebelum slide coral muncul. Kedua slide tetap mempertahankan warna latar belakang aslinya.

Baris di bawah ini menampilkan frame PowerPoint pada interval setengah detik. Bandingkan frame tengah di setiap baris untuk melihat efeknya.

![Bar terpisah mengidentifikasi durasi transisi 750 ms dan pengaturan kemajuan otomatis 5.000 ms.](reveal-through-black.png)

## **Menambahkan Transisi Slide Tingkat Lanjut**

Anda dapat mengonfigurasi berapa lama sebuah slide tetap di layar dan apakah klik mouse memajukan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) mengaktifkan kemajuan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan terjadwal agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, berikan `false` ke [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Penundaan mengontrol kapan pertunjukan slide melanjutkan; ini tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat memajukan slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

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

Untuk memeriksa apakah kemajuan terjadwal diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Penundaan yang tersimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

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

## **Mengontrol Timing Transisi Secara Presisi**

Gunakan [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) pada slide mengekspor pengaturan ini melalui [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Mengatur durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Mengatur penundaan sebelum slide maju secara otomatis, dalam milidetik. Berikan `true` ke [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Memilih kategori kecepatan terdefinisi dari [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi eksak tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) hanya mengontrol efek transisi; tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Bar terpisah mengidentifikasi durasi transisi 750 ms dan pengaturan kemajuan otomatis 5.000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Contoh bersama memberikan setiap slide transisi Fade 750 ms dan secara terpisah mengaktifkan kemajuan otomatis pada 5.000 ms. Durasi transisi mengontrol efek; kemajuan mengontrol ketika meninggalkan slide. Bar ini adalah pengaturan skematis, bukan timeline gabungan yang terukur.*
<!-- visual-explanation:slide-transition:end -->

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk ritme yang konsisten, terapkan efek dan durasi tepat yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), dan memberikan setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan melalui klik mouse, kemudian menyimpan hasilnya sebagai PPTX.

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

### **Atur Durasi Berbeda untuk Slide Individual**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

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

Saat menyiapkan [animated GIF](/slides/id/java/convert-powerpoint-to-animated-gif/), [presentasi HTML5](/slides/id/java/export-to-html5/), atau [video](/slides/id/java/convert-powerpoint-to-video/), atur durasi transisi yang tepat sebelum ekspor untuk mencocokkan kecepatan yang diinginkan. Misalnya, gunakan fade 600 ms antara adegan, dan sesuaikan penundaan kemajuan setiap slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 ms bersesuaian dengan 18 frame pada 30 fps. Di HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi timing yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit tersimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang diatur; nilai non‑negatif menentukan durasi yang tersimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) untuk menentukan durasi tersebut. Menetapkan tipe transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

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

Transisi Morph menganimasikan perubahan antar objek pada slide berurutan. Untuk membuat efek Morph sederhana, gandakan sebuah slide, pindahkan atau ubah ukuran objek pada salinan, dan terapkan transisi Morph pada slide kedua. Ini memberi transisi objek‑objek yang bersangkutan untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menggandakan slide tersebut, dan mengubah posisi serta ukuran persegi panjang pada salinan. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efek selama pertunjukan slide.

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

## **Jenis‑jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) memperlakukan setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) menganimasikan teks dengan mencocokkan kata‑kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). Nilai tersebut kemudian menyediakan antarmuka [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-)‑nya memilih mode pencocokan.

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

Beberapa transisi menyajikan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). Atur tipe terlebih dahulu, lalu gunakan antarmuka yang tepat dari [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) melalui [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) sehingga transisi dimulai dari layar hitam.

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

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Lebih baik gunakan [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ketika kategori kecepatan yang telah ditentukan dalam [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/)—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang diatur. Pengaturan ini mengontrol efek transisi secara terpisah dari penundaan kemajuan otomatis.

**Apakah saya dapat melampirkan audio pada transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), berikan `StartSound` dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) dengan `true`. Audio akan berulang hingga terjadi peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Iterasi koleksi [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) pada presentasi dan panggil [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) dengan nilai yang sama untuk transisi tiap slide. Atur semua opsi timing dan efek dalam loop yang sama agar perilaku tetap konsisten di seluruh slide.

**Bagaimana saya dapat memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?**

Panggil [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.