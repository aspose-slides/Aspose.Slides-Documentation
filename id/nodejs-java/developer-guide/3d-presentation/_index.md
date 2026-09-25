---
title: Membuat Efek 3D dalam Presentasi Menggunakan Node.js
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradien 3D
- teks 3D
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint di Node.js dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, serta teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang memasukkan atau mengedit file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode ini mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Anggota API yang paling penting adalah:

| API member | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getCamera) | Viewpoint, preset camera type, rotation, zoom, and perspective. | Rotate the object in 3D space or match a PowerPoint 3D rotation preset. |
| [getLightRig](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getLightRig) | Light preset, direction, and light rotation. | Change how highlights and shadows appear on the 3D surface. |
| [getMaterial](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setMaterial) | Surface material, such as flat, matte, plastic, or metal. | Make the same geometry look flatter, softer, glossy, or metallic. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | How far the shape extends backward from its front face. | Turn a flat shape into a visibly thick 3D object. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Color of the extruded sides. | Make depth visible or coordinate the side color with the front fill. |
| [getDepth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setDepth) | Additional 3D depth used by PowerPoint 3D formatting. | Fine-tune depth for shapes or text, especially together with bevel and material settings. |
| [getBevelTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Raised or rounded edges on the front and back faces. | Add a softened or molded edge instead of a sharp flat face. |
| [getContourColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Outline around the 3D object. | Emphasize the object boundary in rendered output. |

## **Membuat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat benar-benar 3D:

- Pengaturan kamera, karena tampilan depan bawaan dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat sisi dan permukaan terlihat.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat persegi panjang, menambahkan teks pada muka depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali dimensi default dan menyimpan presentasi sebagai PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar slide yang dirender menampilkan persegi panjang sebagai blok 3D tebal:

![Persegi panjang 3D biru dengan teks 3D putih pada muka depan](img_01_01.png)

## **Memutar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3‑D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel 3‑D Rotation PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getCamera). Contoh ini membuat persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, Z menjadi 20, 30, dan 40 derajat masing‑masing. Contoh ini mengonfigurasi bentuk di memori tanpa menyimpan file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Gunakan kamera ketika Anda perlu mengubah cara pemirsa melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah pandangan 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

## **Menambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang muka depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) untuk mengatur ketebalan dan [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) untuk mengakses warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Konfigurasi dilakukan di memori tanpa menyimpan file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setDepth) mengatur kedalaman bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) mengendalikan tinggi efek ekstrusi, seperti yang ditunjukkan pada contoh ini.

## **Menggunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada muka depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru‑ke‑oranye pada muka depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi default:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Output yang dirender mempertahankan gradien pada muka depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D dengan isian gradien biru‑ke‑oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang ada bernama "image.jpg" di direktori kerja. Gambar tersebut diregangkan untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Konfigurasi dilakukan di memori tanpa menyimpan atau merender file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Gambar dirender pada muka depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D dengan isian foto pada muka depan dan ekstrusi oranye](img_02_04.png)

## **Menerapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑hurufnya sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola grid oranye‑dan‑putih, menerapkan lengkungan ke atas, dan mengonfigurasi pengaturan 3D melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis tepi disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Teks dirender sebagai huruf 3D melengkung dan terekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Menjaga Teks Tetap Datar pada Bentuk 3D**

Agar teks tetap dapat dibaca sambil mempertahankan tampilan 3D bentuk, panggil [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) melalui [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Ketika nilai `true`, teks tetap berada di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusi tetap dikonfigurasi melalui [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getThreeDFormat). Ini juga berbeda dari rotasi biasa. [Shape.setRotation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#setRotation) memutar bentuk pada bidang slide, sementara [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) mengendalikan rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di samping yang asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang terlihat sama.

![Dua persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/nodejs-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), atau menghasilkan frame untuk [konversi video](/slides/id/nodejs-java/convert-powerpoint-to-video/).

Perhatikan hal‑hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh pemirsa setelah diekspor.
- Penampilan akhir bergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/nodejs-java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender bukan disimpan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML menjadi adegan 3D interaktif yang dapat diputar oleh pemirsa. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang dimasukkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Pada praktiknya, juga atur light rig dan material agar permukaan yang dirender memiliki highlight dan bayangan yang jelas.

**Apakah saya dapat menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getThreeDFormat) untuk badan bentuk dan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D ketika menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Apakah saya dapat membaca nilai 3D akhir setelah pewarisan dan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/nodejs-java/shape-effective-properties/) untuk membaca kamera, light rig, bevel, dan nilai 3D terkait yang akhir.