---
title: "Kelola Transisi Slide dalam Presentasi Menggunakan Java"
linktitle: "Transisi Slide"
type: docs
weight: 80
url: /id/java/slide-transition/
keywords:
- "transisi slide"
- "tambahkan transisi slide"
- "terapkan transisi slide"
- "transisi slide tingkat lanjut"
- "transisi morph"
- "jenis transisi"
- "efek transisi"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Temukan cara menyesuaikan transisi slide dalam Aspose.Slides untuk Java, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Overview**

Artikel ini menjelaskan cara mengelola transisi slide dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menerapkan jenis transisi ke slide, mengonfigurasi perilaku transisi seperti maju saat diklik atau setelah waktu tertentu, memeriksa dan menonaktifkan kemajuan otomatis, menggunakan transisi Morph dan jenis-jenisnya, serta mengatur opsi efek transisi. Contoh-contoh memperlihatkan cara memuat atau membuat presentasi, memodifikasi pengaturan transisi untuk slide yang dipilih, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menjawab pertanyaan umum tentang kecepatan transisi, suara transisi, menerapkan transisi yang sama ke beberapa slide, dan memeriksa transisi yang saat ini diterapkan pada slide.

## **Tambahkan Transisi Slide**
Untuk membuat efek transisi slide sederhana, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) .
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides untuk Java melalui enum TransitionType
1. Tuliskan file presentasi yang telah dimodifikasi.

```java
// Instansiasi kelas Presentation untuk memuat file presentasi sumber
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Terapkan transisi tipe lingkaran pada slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Terapkan transisi tipe sisir pada slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Tuliskan presentasi ke disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Transisi Slide Tingkat Lanjut**
Pada bagian di atas, kami hanya menerapkan efek transisi sederhana pada slide. Sekarang, untuk membuat efek transisi sederhana itu menjadi lebih baik dan terkendali, silakan ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) .
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides untuk Java
1. Anda juga dapat mengatur transisi menjadi Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Jika transisi slide diaktifkan untuk Advance On Click, transisi hanya akan maju ketika seseorang mengklik mouse. Selain itu, jika properti Advance After Time diatur, transisi akan otomatis maju setelah waktu maju yang ditentukan berlalu.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file presentasi.

```java
// Instansiasi kelas Presentation yang merepresentasikan file presentasi
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

    // Tuliskan presentasi ke disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides untuk Java kini mendukung [Morph Transition](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMorphTransition). Mereka merupakan transisi morph baru yang diperkenalkan di PowerPoint 2019.

{{% /alert %}} 

Transisi Morph memungkinkan Anda menganimasikan pergerakan halus dari satu slide ke slide berikutnya. Artikel ini menjelaskan konsep dan cara menggunakan transisi Morph. Agar dapat menggunakan transisi Morph secara efektif, Anda memerlukan dua slide dengan setidaknya satu objek yang sama. Cara termudah adalah menduplikasi slide dan kemudian memindahkan objek pada slide kedua ke tempat lain.

Potongan kode berikut menunjukkan cara menambahkan salinan slide dengan beberapa teks ke dalam presentasi dan mengatur transisi berupa [morph type](https://reference.aspose.com/slides/id/java/com.aspose.slides/TransitionType) ke slide kedua.

```java
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

## **Jenis-jenis Transisi Morph**
Enum [TransitionMorphType](https://reference.aspose.com/slides/id/java/com.aspose.slides/TransitionMorphType) baru telah ditambahkan. Enum ini mewakili berbagai jenis transisi slide Morph.

Enum TransitionMorphType memiliki tiga anggota:

- ByObject: Transisi Morph akan dilakukan dengan mempertimbangkan bentuk sebagai objek yang tidak dapat dibagi.
- ByWord: Transisi Morph akan dilakukan dengan mentransfer teks per kata bila memungkinkan.
- ByChar: Transisi Morph akan dilakukan dengan mentransfer teks per karakter bila memungkinkan.

Potongan kode berikut menunjukkan cara mengatur transisi morph pada slide dan mengubah jenis morph:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Efek Transisi**
Aspose.Slides untuk Java mendukung pengaturan efek transisi seperti dari hitam, dari kiri, dari kanan, dll. Untuk mengatur Efek Transisi, silakan ikuti langkah-langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
- Dapatkan referensi slide.
- Atur efek transisi.
- Tuliskan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Pada contoh di bawah ini, kami telah mengatur efek transisi.

```java
// Buat instance dari kelas Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Atur efek
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Tuliskan presentasi ke disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Atur [speed](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) transisi menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/java/com.aspose.slides/transitionspeed/) (misalnya, lambat/menengah/cepat).

**Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Anda dapat menyisipkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan pengulangan (misalnya, [setSound](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), serta metadata seperti [setSoundIsBuiltIn](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) dan [setSoundName](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi setiap slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide memberikan hasil yang konsisten.

**Bagaimana cara memeriksa transisi mana yang saat ini diterapkan pada slide?**

Periksa [transition settings](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslide/#getSlideShowTransition--) slide dan baca [transition type](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowtransition/#setType-int-); nilai tersebut memberi tahu Anda efek apa yang diterapkan.