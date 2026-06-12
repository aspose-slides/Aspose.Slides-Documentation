---
title: Slide Master
type: docs
weight: 30
url: /id/java/examples/elements/master-slide/
keywords:
- contoh kode
- slide master
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jelajahi contoh slide master Aspose.Slides untuk Java: buat, edit, dan gaya master, placeholder, serta tema dalam PPT, PPTX, dan ODP dengan kode Java yang jelas."
---
Master slide membentuk tingkat atas dari hierarki pewarisan slide di PowerPoint. Sebuah **master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slide** mewarisi dari master slide, dan **normal slide** mewarisi dari layout slide.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slide menggunakan Aspose.Slides for Java.

## **Menambahkan Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan mengkloning yang default. Kemudian menambahkan banner nama perusahaan ke semua slide melalui pewarisan layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klon master slide default.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Tambahkan banner dengan nama perusahaan ke bagian atas master slide.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Tetapkan master slide baru ke layout slide.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tetapkan layout slide ke slide pertama dalam presentasi.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan 1:** Master slide menyediakan cara untuk menerapkan branding yang konsisten atau elemen desain yang dibagikan ke semua slide. Setiap perubahan yang dibuat pada master akan secara otomatis tercermin pada layout dan normal slide yang bergantung.

> 💡 **Catatan 2:** Setiap bentuk atau pemformatan yang ditambahkan ke master slide akan diwariskan ke layout slide dan, pada gilirannya, ke semua normal slide yang menggunakan layout tersebut.  
> Gambar di bawah ini mengilustrasikan bagaimana kotak teks yang ditambahkan pada master slide secara otomatis ditampilkan pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Mengakses Master Slide**

Anda dapat mengakses master slide menggunakan koleksi master presentasi. Berikut cara mengambil dan bekerja dengan mereka:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ubah jenis latar belakang.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Master Slide**

Master slide dapat dihapus baik dengan indeks maupun dengan referensi.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Hapus master slide berdasarkan indeks.
        presentation.getMasters().removeAt(0);

        // Hapus master slide berdasarkan referensi.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Master Slide yang Tidak Digunakan**

Beberapa presentasi berisi master slide yang tidak digunakan. Menghapus slide ini dapat membantu mengurangi ukuran file.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hapus semua master slide yang tidak terpakai (bahkan yang ditandai sebagai Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```