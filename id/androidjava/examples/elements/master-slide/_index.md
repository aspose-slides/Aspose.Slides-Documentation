---
title: Slide Master
type: docs
weight: 30
url: /id/androidjava/examples/elements/master-slide/
keywords:
- contoh kode
- slide master
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Jelajahi contoh slide master Aspose.Slides untuk Android: buat, edit, dan gaya master, placeholder, dan tema dalam PPT, PPTX, dan ODP dengan kode Java yang jelas."
---
Slide master membentuk level teratas dalam hierarki pewarisan slide di PowerPoint. **Slide master** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Slide tata letak** mewarisi dari slide master, dan **slide normal** mewarisi dari slide tata letak.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola slide master menggunakan Aspose.Slides for Android via Java.

## **Menambahkan Slide Master**

Contoh ini menampilkan cara membuat slide master baru dengan menyalin slide master bawaan. Selanjutnya menambahkan spanduk nama perusahaan ke semua slide melalui pewarisan tata letak.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Kloning slide master default.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Tambahkan spanduk dengan nama perusahaan ke bagian atas slide master.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Tetapkan slide master baru ke slide tata letak.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tetapkan slide tata letak ke slide pertama dalam presentasi.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan 1:** Slide master menyediakan cara untuk menerapkan merek konsisten atau elemen desain bersama di semua slide. Setiap perubahan yang dilakukan pada master akan otomatis tercermin pada slide tata letak dan slide normal yang bergantung.

> 💡 **Catatan 2:** Setiap bentuk atau pemformatan yang ditambahkan ke slide master akan diwarisi oleh slide tata letak dan, pada gilirannya, semua slide normal yang menggunakan tata letak tersebut.  
> Gambar di bawah mengilustrasikan bagaimana kotak teks yang ditambahkan pada slide master secara otomatis muncul pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Mengakses Slide Master**

Anda dapat mengakses slide master menggunakan koleksi master presentasi. Berikut cara mengambil dan bekerja dengan slide master:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ubah tipe latar belakang.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Master**

Slide master dapat dihapus baik berdasarkan indeks maupun referensi.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Hapus slide master berdasarkan indeks.
        presentation.getMasters().removeAt(0);

        // Hapus slide master berdasarkan referensi.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Master yang Tidak Digunakan**

Beberapa presentasi berisi slide master yang tidak digunakan. Menghapus slide tersebut dapat membantu mengurangi ukuran file.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hapus semua slide master yang tidak terpakai (bahkan yang ditandai sebagai Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```