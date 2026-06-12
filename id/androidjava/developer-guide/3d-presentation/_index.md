---
title: Buat Efek 3D dalam Presentasi di Android
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Menerapkan dan merender efek 3D untuk bentuk dan teks PowerPoint di Android dengan Aspose.Slides. Mengonfigurasi kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides for Android via Java dapat membuat, mengedit, mempertahankan, dan merender format 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="primary" %}}
Artikel ini tentang efek format 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau mengedit file model 3D mandiri. Ketika Anda mengekspor slide menjadi gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Format 3D**

Gunakan metode [IShape.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk menerapkan format 3D pada sebuah bentuk. Metode ini mengembalikan [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Ini menerapkan format 3D pada bingkai teks alih‑alih pada badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan digunakan |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Memutar objek dalam ruang 3D atau mencocokkan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preset cahaya, arah, dan rotasi cahaya. | Mengubah bagaimana sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) dan [setMaterial](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) dan [setExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Seberapa jauh bentuk menjorok ke belakang dari muka depannya. | Mengubah bentuk datar menjadi objek 3D yang jelas tebalnya. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau mengkoordinasikan warna sisi dengan isi depan. |
| [getDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getDepth--) dan [setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Kedalaman 3D tambahan yang digunakan oleh format 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) dan [getBevelBottom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Tepi yang naik atau melengkung pada muka depan dan belakang. | Menambahkan tepi yang lebih lembut atau dibentuk alih‑alih muka datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), dan [setContourWidth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Garis tepi di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Suatu bentuk biasanya memerlukan empat jenis pengaturan sebelum tampak meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.  
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisinya terlihat.  
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.  
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks pada muka depannya, menerapkan format 3D, menyimpan presentasi sebagai PPTX, dan merender slide menjadi gambar PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

Gambar slide yang dirender menunjukkan persegi panjang sebagai balok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada muka depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3-D PowerPoint dengan nilai rotasi X, Y, dan Z yang disorot](img_02_01.png)

Di Aspose.Slides, atur tipe kamera dan rotasi melalui [IThreeDFormat.getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah titik pandang 3D yang digunakan oleh PowerPoint dan Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperluasnya ke belakang muka depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) untuk ketebalan dan [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) untuk warna sisi:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Gunakan [IThreeDFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ketika Anda perlu bekerja langsung dengan nilai kedalaman PowerPoint atau menggabungkan kedalaman dengan bevel, material, dan efek teks. Dalam banyak skenario bentuk, `setExtrusionHeight` adalah pengaturan yang lebih jelas karena secara langsung menyatakan ekstrusi yang terlihat.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Format 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna padat, gradien, pola, atau isian gambar pada muka depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

Output yang dirender mempertahankan gradien pada muka depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru‑ke‑oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

Gambar dirender pada muka depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada muka depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Format 3D pada Teks**

Format 3D pada bentuk memengaruhi badan bentuk. Format 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑hurufnya sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan isian pola, menerapkan transformasi WordArt, dan mengonfigurasi pengaturan 3D pada [ITextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

Teks dirender sebagai huruf 3D melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan format 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D diubah menjadi raster atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/androidjava/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/androidjava/convert-powerpoint-to-video/).

Perhatikan poin-poin berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.  
- Penampilan akhir tergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.  
- Jika Anda perlu memeriksa nilai format yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/androidjava/shape-effective-properties/).  
- Beberapa format output tidak dapat menyimpan format 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih‑alih dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides menciptakan dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang interaktif sebagai adegan 3D yang dapat diputar oleh penonton. Pada PPTX, format 3D tetap dapat diedit di PowerPoint bila format tersebut mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah format yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Pada praktiknya, juga atur light rig dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [IShape.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk badan bentuk dan [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan tema diterapkan?**

Ya. Gunakan API format efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/androidjava/shape-effective-properties/) untuk membaca kamera, light rig, bevel, dan nilai 3D terkait yang final.