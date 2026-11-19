---
title: Buat Efek 3D pada Presentasi dengan Node.js
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

Aspose.Slides untuk Node.js via Java dapat membuat, mengedit, mempertahankan, dan merender format 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek format 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau mengedit file model 3D yang berdiri sendiri. Ketika Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode tersebut mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada tubuh bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan menggunakannya |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah bagaimana sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) dan [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Material permukaan, seperti datar, matte, plastik, atau logam. | Buat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) dan [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Seberapa jauh bentuk menjorok ke belakang dari permukaan depannya. | Ubah bentuk datar menjadi objek 3D yang terlihat tebal. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Warna sisi yang diekstrusi. | Buat kedalaman terlihat atau koordinasikan warna sisi dengan isi depan. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) dan [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) dan [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Tepi terangkat atau membulat pada permukaan depan dan belakang. | Tambahkan tepi yang lembut atau dibentuk alih-alih permukaan datar tajam. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth), dan [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Garis tepi di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisi dapat terlihat.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke permukaan depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali dimensi default dan menyimpan presentasi sebagai PPTX.

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

Gambar slide yang dirender menunjukkan persegi panjang sebagai balok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada permukaan depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3-D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel 3-D Rotation PowerPoint dengan nilai rotasi X, Y, dan Z yang disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografik, dan menetapkan rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing‑masing. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

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

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah titik pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

### **Salin Orientasi Kamera dari Bentuk Template**

Untuk cocokkan orientasi bentuk template, baca preset kamera dengan [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) dan sudut rotasinya dengan [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Contoh membuka `template.pptx` dan menyalin orientasi kamera dari bentuk pertama pada slide pertama ke bentuk kedua. Kedua bentuk sudah memiliki pencahayaan 3D, dan bentuk kedua tidak memiliki rotasi kamera eksplisit.

Sudutnya dalam derajat. Indeks `0` adalah lintang, indeks `1` adalah bujur, dan indeks `2` adalah revolusi. Kirimkan ke [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) dalam urutan tersebut. Jika sumber mengembalikan `null`, berarti tidak ada rotasi eksplisit, jadi biarkan sudut bentuk kedua tidak diatur. Rotasi eksplisit `(0, 0, 0)` mengembalikan tiga nol dan harus disalin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saat Anda membuka kembali `camera-copy.pptx` di PowerPoint, panah di kanan memiliki preset kamera dan rotasi yang sama dengan persegi panjang di kiri. Kedua bentuk menggunakan pencahayaan dan kedalaman ekstrusi yang sama.

![Sebuah persegi panjang 3D biru dan panah kanan dengan orientasi kamera yang cocok, dilihat dari atas dan ke kanan](camera-orientation.png)

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang permukaan depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) untuk mengatur ketebalan dan [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) untuk mengakses warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk menampilkan ketebalannya. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

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

Metode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) mengatur kedalaman bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan pada contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar ke permukaan depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru‑ke‑oren pada permukaan depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi default:

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

Output yang dirender mempertahankan gradien pada permukaan depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar sebagai gantinya, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang ada bernama "image.jpg" di direktori kerja. Gambar diperluas untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan atau merender file:

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

Gambar dirender pada permukaan depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada permukaan depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D ke Teks**

Pemformatan 3D pada bentuk memengaruhi tubuh bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt dimana huruf‑hurufnya sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye‑dan‑putih, menerapkan lengkungan ke atas, dan mengkonfigurasi pengaturan 3D melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian dan garis bentuk disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

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

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap terbaca sambil mempertahankan tampilan 3D bentuk, panggil [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) melalui [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Ketika nilai `true`, teks tetap berada di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusinya tetap dikonfigurasi melalui [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Ini juga berbeda dari rotasi biasa. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) memutar bentuk di bidang slide, sementara [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan mengklonnya di samping yang asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

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

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D diubah menjadi raster atau digambar ke dalam output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/nodejs-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/nodejs-java/convert-powerpoint-to-video/).

Perhatikan hal‑hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, bacalah [effective shape properties](/slides/id/nodejs-java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender daripada dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila format mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Minimal, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur rig cahaya dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks sekaligus?**

Ya. Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) untuk tubuh bentuk dan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D ketika menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan di [Shape Effective Properties](/slides/id/nodejs-java/shape-effective-properties/) untuk membaca nilai kamera, rig cahaya, bevel, dan nilai 3D terkait yang final.