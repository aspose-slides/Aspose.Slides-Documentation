---
title: Membuat Efek 3D dalam Presentasi di Android
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
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint di Android dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau mengedit file model 3D mandiri. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode ini mengembalikan [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Metode ini menerapkan pemformatan 3D pada bingkai teks alih-alih badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrolnya | Kapan digunakan |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Titik pandang, tipe kamera bawaan, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Pencahayaan preset, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) dan [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material permukaan, seperti datar, matte, plastik, atau logam. | Buat geometri yang sama terlihat lebih datar, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) dan [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Seberapa jauh bentuk menonjol ke belakang dari muka depannya. | Ubah bentuk datar menjadi objek 3D yang tebal terlihat. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Warna sisi yang diekstrusi. | Buat kedalaman terlihat atau koordinasikan warna sisi dengan isi depan. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) dan [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) dan [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Tepi yang terangkat atau melengkung pada muka depan dan belakang. | Tambahkan tepi yang melunak atau dibentuk alih-alih permukaan datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) dan [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) dan [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Garis luar di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

- Pengaturan kamera, karena tampilan depan bawaan dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat sisi dan wajah dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke muka depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali ukuran default dan menyimpan presentasi sebagai PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Gambar slide yang dirender menunjukkan persegi panjang sebagai blok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada muka depannya](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3-D PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing-masing. Contoh ini mengkonfigurasi bentuk di memori tanpa menyimpan file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Itu tidak mengubah geometri bentuk 2D pada slide. Itu mengubah titik pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

### **Salin Orientasi Kamera dari Bentuk Template**

Untuk mencocokkan orientasi bentuk template, baca preset kamera dengan [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) dan sudut rotasinya dengan [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Contoh membuka `template.pptx` dan menyalin orientasi kamera dari bentuk pertama pada slide pertama ke bentuk kedua. Kedua bentuk sudah memiliki pencahayaan 3D, dan bentuk kedua tidak memiliki rotasi kamera eksplisit.

Sudutnya dalam derajat. Indeks `0` adalah lintang, indeks `1` adalah bujur, dan indeks `2` adalah revolusi. Kirimkan ke [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) dalam urutan itu. Jika sumber mengembalikan `null`, maka tidak ada rotasi eksplisit, sehingga biarkan sudut bentuk kedua tidak diatur. Rotasi eksplisit `(0, 0, 0)` mengembalikan tiga nol dan harus disalin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saat Anda membuka kembali `camera-copy.pptx` di PowerPoint, panah di kanan memiliki preset kamera dan rotasi yang sama dengan persegi panjang di kiri. Kedua bentuk menggunakan pencahayaan dan kedalaman ekstrusi yang sama.

![Sebuah persegi panjang 3D biru dan panah kanan dengan orientasi kamera yang cocok, dilihat dari atas dan kanan](camera-orientation.png)

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk terlihat tebal dengan memperpanjangnya di belakang muka depan. Di PowerPoint, kontrol kedalaman menetapkan ketebalan tampak ini, dan kontrol warna menetapkan warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) untuk mengatur ketebalan dan [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) untuk mengakses warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Contoh ini mengkonfigurasi bentuk di memori tanpa menyimpan file:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) menetapkan kedalaman bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan dalam contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada muka depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru-ke-oren pada muka depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali ukuran default:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oren dan ekstrusi oranye:

![Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar sebagai gantinya, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang sudah ada bernama "image.jpg" di direktori kerja. Itu meregangkan gambar untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Contoh ini mengkonfigurasi bentuk di memori tanpa menyimpan atau merender file:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Gambar dirender pada muka depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada muka depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D bentuk memengaruhi badan bentuk. Pemformatan 3D teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye-dan-putih, menerapkan lengkungan ke atas, dan mengkonfigurasi pengaturan 3D melalui [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian dan kontur bentuk disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan penampilan 3D bentuk, panggil [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) melalui [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Ketika nilai `true`, teks tetap berada di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusi tetap dikonfigurasi melalui [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Ini juga berbeda dari rotasi biasa. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) memutar bentuk dalam bidang slide, sementara [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan mengkloningnya di samping aslinya. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali ukuran default.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

![Persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/androidjava/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/androidjava/convert-powerpoint-to-video/).

Perhatikan hal-hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [properti bentuk efektif](/slides/id/androidjava/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender daripada dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML menjadi adegan 3D interaktif yang dapat diputar penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Minimal, atur rotasi kamera dan ekstrusi atau kedalaman. Dalam praktiknya, juga atur rig cahaya dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk badan bentuk dan [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi penampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan di [Shape Effective Properties](/slides/id/androidjava/shape-effective-properties/) untuk membaca kamera akhir, rig cahaya, bevel, dan nilai 3D terkait lainnya.