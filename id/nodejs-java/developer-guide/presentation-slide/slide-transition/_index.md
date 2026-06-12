---
title: Kelola Transisi Slide dalam Presentasi Menggunakan JavaScript
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan transisi slide dalam JavaScript dengan Aspose.Slides untuk Node.js via Java, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola transisi slide dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menerapkan jenis transisi pada slide, mengonfigurasi perilaku transisi seperti maju pada klik atau setelah waktu tertentu, memeriksa dan menonaktifkan maju otomatis, menggunakan transisi Morph dan jenis-jenisnya, serta mengatur opsi efek transisi. Contohnya memperlihatkan cara memuat atau membuat presentasi, mengubah pengaturan transisi untuk slide yang dipilih, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menjawab pertanyaan umum tentang kecepatan transisi, suara transisi, menerapkan transisi yang sama ke banyak slide, dan memeriksa transisi yang saat ini diterapkan pada sebuah slide.

## **Tambahkan Transisi Slide**
Untuk membuat efek transisi slide sederhana, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang ditawarkan oleh Aspose.Slides for Node.js via Java melalui enum TransitionType.
1. Tuliskan file presentasi yang telah dimodifikasi.

```javascript
// Membuat instance kelas Presentation untuk memuat file presentasi sumber
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Terapkan transisi tipe lingkaran pada slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Terapkan transisi tipe sisir pada slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Simpan presentasi ke disk
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Transisi Slide Lanjutan**
Pada bagian sebelumnya, kami hanya menerapkan efek transisi sederhana pada slide. Sekarang, untuk membuat efek transisi sederhana tersebut menjadi lebih baik dan terkontrol, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang ditawarkan oleh Aspose.Slides for Node.js via Java.
1. Anda juga dapat mengatur transisi menjadi Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Jika transisi slide diaktifkan untuk Advance On Click, transisi hanya akan maju ketika pengguna mengklik mouse. Selain itu, jika properti Advance After Time diatur, transisi akan maju secara otomatis setelah waktu yang ditentukan berlalu.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file presentasi.

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Terapkan transisi tipe lingkaran pada slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Atur waktu transisi selama 3 detik
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Terapkan transisi tipe sisir pada slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Atur waktu transisi sebesar 5 detik
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Terapkan transisi tipe zoom pada slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Atur waktu transisi sebesar 7 detik
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Simpan presentasi ke disk
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java kini mendukung [Morph Transition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MorphTransition). Ini adalah transisi morph baru yang diperkenalkan di PowerPoint 2019.

{{% /alert %}} 

Transisi Morph memungkinkan Anda menganimasikan pergerakan halus dari satu slide ke slide berikutnya. Artikel ini menjelaskan konsepnya dan cara menggunakan transisi Morph. Agar dapat menggunakan transisi Morph secara efektif, Anda memerlukan dua slide yang memiliki setidaknya satu objek yang sama. Cara termudah adalah menduplikasi slide lalu memindahkan objek pada slide kedua ke posisi yang berbeda.

Potongan kode berikut menunjukkan cara menambahkan klon slide dengan teks ke presentasi dan mengatur transisi ke [morph type](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TransitionType) pada slide kedua.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Jenis‑jenis Morph Transition**
Enum baru [TransitionMorphType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TransitionMorphType) telah ditambahkan. Enum ini mewakili berbagai jenis transisi slide Morph.

Enum TransitionMorphType memiliki tiga anggota:

- ByObject: Transisi Morph akan dilakukan dengan mempertimbangkan bentuk sebagai objek yang tidak dapat dibagi.
- ByWord: Transisi Morph akan dilakukan dengan mentransfer teks per kata bila memungkinkan.
- ByChar: Transisi Morph akan dilakukan dengan mentransfer teks per karakter bila memungkinkan.

Potongan kode berikut menunjukkan cara mengatur transisi morph pada slide dan mengubah jenis morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Efek Transisi**
Aspose.Slides for Node.js via Java mendukung pengaturan efek transisi seperti, from black, from left, from right, dll. Untuk mengatur Transition Effect, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide.
- Atur efek transisi.
- Tuliskan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Pada contoh di bawah ini, kami telah mengatur efek transisi.

```javascript
// Buat instance kelas Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Atur efek
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Simpan presentasi ke disk
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Atur [speed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setspeed/) transisi menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/transitionspeed/) (misalnya, slow/medium/fast).

**Apakah saya dapat melampirkan audio pada transisi dan membuatnya berulang?**

Ya. Anda dapat menyematkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan looping (misalnya, [setSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), serta metadata seperti [setSoundIsBuiltIn](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) dan [setSoundName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi masing‑masing slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide menghasilkan hasil yang konsisten.

**Bagaimana cara memeriksa transisi mana yang saat ini diterapkan pada sebuah slide?**

Periksa [pengaturan transisi](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) slide dan baca [jenis transisinya](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowtransition/gettype/); nilai tersebut memberi tahu Anda secara tepat efek apa yang diterapkan.