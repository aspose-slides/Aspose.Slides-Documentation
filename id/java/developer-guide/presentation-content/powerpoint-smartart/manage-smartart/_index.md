---
title: "Kelola SmartArt dalam Presentasi PowerPoint Menggunakan Java"
linktitle: "Kelola SmartArt"
type: docs
weight: 10
url: /id/java/manage-smartart/
keywords:
  - SmartArt
  - Teks SmartArt
  - tipe tata letak
  - properti tersembunyi
  - bagan organisasi
  - bagan organisasi gambar
  - PowerPoint
  - presentasi
  - Java
  - Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Java menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang terdiri dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Java, Anda dapat membuat SmartArt, membaca teks dari node‑nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi berbentuk gambar.

## **Mengambil Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks dari bentuk node, iterasi melalui [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), kemudian baca [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) yang dikembalikan oleh [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

Contoh ini memerlukan presentasi dengan setidaknya satu slide dan objek SmartArt sebagai bentuk pertama pada slide tersebut. Ia mencetak setiap frame teks yang tersedia ke konsol.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mengubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan terhubung. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi. Posisi dan ukuran yang diberikan ke [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) diukur dalam poin. Gunakan [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) untuk mengubah tata letak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memeriksa Apakah Node SmartArt Tersembunyi**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan sebuah node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node yang ditambahkan. Ia mencetak pesan jika node tersembunyi dan menyimpan diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan atau Menetapkan Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) dan [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat menempatkan node anak menggantung di kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan menetapkan tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks berbasis nol `0` memilih node tingkat atas pertama; node anaknya menggunakan pengaturan yang dipilih. Presentasi yang telah dimodifikasi kemudian disimpan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Membuat Bagan Organisasi Berbentuk Gambar**

Bagan organisasi berbentuk gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang mencakup placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide. Contoh ini menyimpan diagram dengan placeholder gambar; ia tidak mengisi placeholder dengan gambar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengonversi Diagram Warisan Menjadi Grup Bentuk**

Saat memodernisasi presentasi yang ada, Anda mungkin perlu memperbarui bagan organisasi yang awalnya dibuat di PowerPoint 97–2003. Aspose.Slides merepresentasikan diagram warisan ini sebagai objek [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/). Gunakan [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) untuk mengonversi diagram menjadi grup bentuk sehingga Anda dapat mengedit elemen visual secara individual. Lihat [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) untuk detail.

Konversi menambahkan grup baru ke koleksi bentuk tanpa menghapus diagram asli. Setelah konversi berhasil, hapus diagram asli dengan [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) untuk menghindari konten duplikat. Kumpulkan diagram warisan ke dalam daftar sebelum mengonversinya sehingga penambahan dan penghapusan bentuk tidak mengganggu iterasi.

Contoh berikut membuka presentasi, mencari setiap slide, mengonversi diagram menjadi grup bentuk, dan menyimpan presentasi yang diperbarui sebagai PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Presentasi yang disimpan berisi grup bentuk yang dapat diedit menggantikan diagram warisan yang telah dikonversi, tanpa diagram asli yang tersisa di sampingnya. Buka file PPTX di PowerPoint untuk mengedit elemen individual dalam setiap grup, seperti teks, isian, atau posisinya.

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) mengubah arah diagram dari kiri‑ke‑kanan menjadi kanan‑ke‑kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana cara menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [menyalin bentuk SmartArt](/slides/id/java/shape-manipulations/) dengan [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) atau [menyalin seluruh slide](/slides/id/java/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan format.

**Bagaimana cara merender SmartArt menjadi gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana cara menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Gunakan [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) atau [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) untuk memberikan teks alternatif atau nama yang khas pada bentuk SmartArt, cari nilai tersebut dalam [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), kemudian pastikan bentuk yang cocok adalah sebuah [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).