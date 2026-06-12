---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan JavaScript
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- jenis tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi gambar
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Node.js menggunakan contoh kode JavaScript yang jelas dan mempercepat desain slide serta otomatisasi."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang terdiri dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Node.js via Java, Anda dapat membuat SmartArt, membaca teks dari node-node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi berbasis gambar.

## **Mendapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau beberapa bentuk. Untuk membaca teks yang terlihat, iterasi melalui [SmartArt.getAllNodes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/#getAllNodes--), kemudian baca [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mengubah Jenis Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memeriksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartnode/ishidden/) menunjukkan apakah node disembunyikan dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan atau Menetapkan Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) dan [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung di kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan menetapkan tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Membuat Bagan Organisasi Gambar**

Bagan organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tanya Jawab**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt.setReversed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/setreversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan pemformatan?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/nodejs-java/shape-manipulations/) dengan [ShapeCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/addclone/) atau [mengkloning seluruh slide](/slides/id/nodejs-java/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**Bagaimana cara saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape.setAlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/setalternativetext/) atau [Shape.setName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/setname/) yang khas pada bentuk SmartArt, cari nilai tersebut di [BaseSlide.getShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getShapes), dan kemudian pastikan bahwa bentuk yang cocok adalah sebuah [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/).