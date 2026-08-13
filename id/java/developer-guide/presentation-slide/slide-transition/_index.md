---
title: Kelola Transisi Slide dalam Presentasi Menggunakan Java
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
- jenis transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Temukan cara menyesuaikan transisi slide di Aspose.Slides untuk Java, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola transisi slide dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menerapkan jenis transisi pada slide, mengonfigurasi perilaku transisi seperti maju pada klik atau setelah waktu tertentu, memeriksa dan menonaktifkan kemajuan otomatis, menggunakan transisi Morph dan jenis‑jenisnya, serta mengatur opsi efek transisi. Contoh‑contohnya memperlihatkan cara memuat atau membuat presentasi, mengubah pengaturan transisi untuk slide yang dipilih, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menjawab pertanyaan umum tentang kecepatan transisi, suara transisi, menerapkan transisi yang sama pada beberapa slide, dan memeriksa transisi yang sedang diterapkan pada sebuah slide.

## **Menambahkan Transisi Slide**
Untuk membuat efek transisi slide sederhana, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides for Java melalui enum TransitionType.
1. Tulis file presentasi yang sudah dimodifikasi.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Terapkan transisi tipe lingkaran pada slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Terapkan transisi tipe sisir pada slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Simpan presentasi ke disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Transisi Slide Lanjutan**
Pada bagian sebelumnya, kami hanya menerapkan efek transisi sederhana pada slide. Sekarang, untuk membuat efek transisi sederhana tersebut menjadi lebih baik dan terkontrol, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides for Java.
1. Anda juga dapat mengatur transisi menjadi Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Jika transisi slide diaktifkan menjadi Advance On Click, transisi hanya akan maju ketika pengguna mengklik mouse. Selain itu, jika properti Advance After Time diatur, transisi akan maju secara otomatis setelah waktu yang ditentukan berlalu.
1. Tulis presentasi yang sudah dimodifikasi sebagai file presentasi.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Terapkan transisi tipe lingkaran pada slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Atur waktu transisi menjadi 3 detik
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Terapkan transisi tipe sisir pada slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Atur waktu transisi menjadi 5 detik
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Terapkan transisi tipe zoom pada slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Atur waktu transisi menjadi 7 detik
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Simpan presentasi ke disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="info" %}} 

Aspose.Slides for Java kini mendukung [Morph Transition](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMorphTransition). Fitur ini mewakili transisi morph baru yang diperkenalkan di PowerPoint 2019.

{{% /alert %}} 

Transisi Morph memungkinkan Anda menganimasikan perpindahan halus dari satu slide ke slide berikutnya. Artikel ini menjelaskan konsepnya dan cara menggunakan Morph transition. Untuk menggunakan Morph transition secara efektif, Anda memerlukan dua slide dengan setidaknya satu objek yang sama. Cara termudah adalah menggandakan slide lalu memindahkan objek pada slide kedua ke posisi yang berbeda.

Potongan kode berikut memperlihatkan cara menambahkan salinan slide dengan beberapa teks ke dalam presentasi dan menetapkan transisi [morph type](https://reference.aspose.com/slides/id/java/com.aspose.slides/TransitionType) pada slide kedua.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Jenis‑jenis Morph Transition**
Enum baru [TransitionMorphType](https://reference.aspose.com/slides/id/java/com.aspose.slides/TransitionMorphType) telah ditambahkan. Enum ini mewakili berbagai jenis transisi slide Morph.

Enum TransitionMorphType memiliki tiga anggota:

- **ByObject**: Transisi Morph akan dilakukan dengan mempertimbangkan bentuk sebagai objek yang tidak dapat dibagi.
- **ByWord**: Transisi Morph akan dilakukan dengan mentransfer teks per kata bila memungkinkan.
- **ByChar**: Transisi Morph akan dilakukan dengan mentransfer teks per karakter bila memungkinkan.

Potongan kode berikut memperlihatkan cara mengatur morph transition pada slide dan mengubah jenis morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Efek Transisi**
Aspose.Slides for Java mendukung pengaturan efek transisi seperti from black, from left, from right, dll. Untuk mengatur Transition Effect, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide.
- Atur efek transisi.
- Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Pada contoh di bawah ini, kami telah mengatur efek transisi.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Atur efek
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Simpan presentasi ke disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?

Ya. Atur [speed](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) transisi menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionspeed/) (misalnya slow/medium/fast).

### Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?

Ya. Anda dapat menyematkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan looping (misalnya [setSound](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), serta metadata seperti [setSoundIsBuiltIn](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) dan [setSoundName](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi masing‑masing slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide menghasilkan hasil yang konsisten.

### Bagaimana cara memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?

Periksa [transition settings](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslide/#getSlideShowTransition--) slide dan baca [transition type](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setType-int-); nilai tersebut memberi tahu Anda efek apa yang sedang diterapkan.