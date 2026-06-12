---
title: Mengelola SmartArt dalam Presentasi PowerPoint di Android
linktitle: Mengelola SmartArt
type: docs
weight: 10
url: /id/androidjava/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- tipe tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi gambar
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Android menggunakan contoh kode Java yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Ikhtisar**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Android via Java, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi bergambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks yang terlihat, iterasi melalui [ISmartArt.getAllNodes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartart/#getAllNodes--), kemudian baca [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) yang dikembalikan oleh [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartartnode/#isHidden--) menunjukkan apakah node disembunyikan dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur bahkan ketika tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) dan [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung di kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OrganizationChartLayoutType) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Buat Bagan Organisasi Gambar**

Bagan organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang mencakup placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [ISmartArt.setReversed](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) mengubah arah diagram dari kiri-ke-kanan ke kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana cara menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan pemformatan?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/androidjava/shape-manipulations/) dengan [ShapeCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) atau [mengkloning seluruh slide](/slides/id/androidjava/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**Bagaimana saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/androidjava/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape.getAlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getAlternativeText--) atau [Shape.getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getName--) yang khas pada bentuk SmartArt, cari nilai tersebut di [BaseSlide.getShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslide/#getShapes--), lalu pastikan bahwa bentuk yang cocok adalah [ISmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartart/).