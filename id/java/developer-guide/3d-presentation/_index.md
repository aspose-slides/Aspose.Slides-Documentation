---
title: Membuat Efek 3D dalam Presentasi Menggunakan Java
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/java/3d-presentation/
keywords:
- PowerPoint 3D
- Presentasi 3D
- Rotasi 3D
- Kedalaman 3D
- Ekstrusi 3D
- Gradien 3D
- Teks 3D
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Gunakan dan render efek 3D untuk bentuk dan teks PowerPoint di Java dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Gambaran Umum**

Aspose.Slides for Java dapat membuat, mengedit, melestarikan, dan merender format 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="primary" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Artikel ini bukan tentang memasukkan atau mengedit file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/).`getThreeDFormat()` untuk menerapkan pemformatan 3D pada sebuah bentuk. Objek format yang dikembalikan mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan menggunakannya |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getCamera--) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getLightRig--) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getMaterial--) dan [setMaterial](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material permukaan, seperti datar, matte, plastik, atau logam. | Buat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) dan [setExtrusionHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Seberapa jauh bentuk menjorok ke belakang dari wajah depannya. | Ubah bentuk datar menjadi objek 3D yang tampak tebal. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Warna sisi yang diekstrusi. | Buat kedalaman terlihat atau koordinasikan warna sisi dengan isi depan. |
| [getDepth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getDepth--) dan [setDepth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getBevelTop--) dan [getBevelBottom](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Tepi terangkat atau bulat pada wajah depan dan belakang. | Tambahkan tepi yang lebih lembut atau berlekuk alih-alih wajah datar tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#getContourWidth--), dan [setContourWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Garis tepi di sekitar objek 3D. | Tekankan batas objek pada output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat persegi panjang, menambahkan teks ke wajah depannya, menerapkan pemformatan 3D, menyimpan presentasi sebagai PPTX, dan merender slide ke gambar PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar slide yang dirender memperlihatkan persegi panjang sebagai balok 3D tebal:

![Persegi tiga dimensi biru yang dirender dengan teks 3D putih pada wajah depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasikan melalui panel 3‑D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel 3‑D Rotation PowerPoint dengan nilai rotasi X, Y, dan Z yang disorot](img_02_01.png)

Di Aspose.Slides, atur tipe kamera dan rotasi melalui format 3D yang dikembalikan oleh `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Gunakan kamera ketika Anda perlu mengubah cara pemirsa melihat objek. Kamera tidak mengubah geometri bentuk 2D pada slide. Ia mengubah sudut pandang 3D yang digunakan PowerPoint dan Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya ke belakang wajah depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur tinggi ekstrusi untuk ketebalan dan warna ekstrusi untuk warna sisi:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Gunakan pengaturan kedalaman ketika Anda perlu bekerja langsung dengan nilai kedalaman PowerPoint atau menggabungkan kedalaman dengan bevel, material, dan efek teks. Dalam banyak skenario bentuk, tinggi ekstrusi lebih jelas karena secara langsung mengekspresikan ekstrusi yang terlihat.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada wajah depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan isian gradien pada bentuk dan warna ekstrusi yang lebih gelap pada sisi:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Output yang dirender mempertahankan gradien pada wajah depan dan merender ekstrusi secara terpisah:

![Persegi tiga dimensi dengan isian gradien biru‑ke‑oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Gambar dirender pada wajah depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi tiga dimensi dengan isian foto pada wajah depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑huruf sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan isian pola, menerapkan transformasi WordArt, dan mengonfigurasi pengaturan 3D pada [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/):

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Teks dirender sebagai huruf 3D melengkung dan ter-ekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D di rasterisasi atau digambar ke output sebagai hasil 2D. Hal ini berlaku ketika Anda merender slide ke [PNG](/slides/id/java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/java/convert-powerpoint-to-html/), atau menghasilkan bingkai untuk [konversi video](/slides/id/java/convert-powerpoint-to-video/).

Perhatikan hal‑hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh pemirsa setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwarisi atau berbasis tema, baca [effective shape properties](/slides/id/java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender daripada dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**  
Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML menjadi adegan 3D interaktif yang dapat diputar oleh pemirsa. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**  
Model 3D adalah objek 3D terpisah yang dimasukkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**  
Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Dalam praktiknya, juga atur light rig dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Dapatkah saya menerapkan efek 3D pada bentuk dan teks?**  
Ya. Gunakan [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/).`getThreeDFormat()` untuk badan bentuk dan [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau bingkai video?**  
Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan bingkai yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Dapatkah saya membaca nilai akhir 3D setelah pewarisan dan pengaturan tema diterapkan?**  
Ya. Gunakan API pemformatan efektif yang dijelaskan di [Shape Effective Properties](/slides/id/java/shape-effective-properties/) untuk membaca kamera akhir, light rig, bevel, dan nilai 3D terkait lainnya.