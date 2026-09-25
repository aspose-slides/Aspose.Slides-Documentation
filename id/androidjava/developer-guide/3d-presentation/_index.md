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
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint di Android dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides untuk Android melalui Java dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, gradien atau isian gambar, dan teks 3D.

{{% alert color="info" title="Catatan" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang memasukkan atau mengedit file model 3D mandiri. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [IShape.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode ini mengembalikan [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan menggunakannya |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Pandangan, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau sesuaikan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) dan [setMaterial](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama terlihat lebih rata, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) dan [setExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Seberapa jauh bentuk menjorok ke belakang dari permukaan depannya. | Mengubah bentuk datar menjadi objek 3D yang tebal terlihat. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [getDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getDepth--) dan [setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) dan [getBevelBottom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Tepi yang terangkat atau melengkung pada permukaan depan dan belakang. | Menambahkan tepi yang lembut atau dibentuk alih-alih permukaan datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) dan [getContourWidth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) dan [setContourWidth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Garis luar di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisi dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks pada permukaan depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi 100 poin. Contoh ini merender slide menjadi gambar PNG dengan dimensi dua kali ukuran default dan menyimpan presentasi sebagai PPTX.

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

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada permukaan depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3-D PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [IThreeDFormat.getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z masing-masing menjadi 20, 30, dan 40 derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

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

Gunakan kamera ketika Anda perlu mengubah bagaimana penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang permukaan depan. Di PowerPoint, kontrol kedalaman menetapkan ketebalan yang terlihat ini, dan kontrol warna menetapkan warna pada sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) untuk menentukan ketebalan dan [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) untuk mengakses warna sisi. Contoh ini memberikan persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

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

Metode [IThreeDFormat.setDepth] menetapkan kedalaman sebuah bentuk 3D. Metode [setExtrusionHeight] mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan dalam contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D independen dari isian bentuk. Anda dapat menerapkan warna padat, gradien, pola, atau isian gambar pada permukaan depan dan tetap menggunakan kamera, cahaya, material, dan pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru-ke-oranye pada permukaan depan dan warna oranye tua pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandakan awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender menjadi gambar PNG dengan dimensi dua kali ukuran default:

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

Output yang dirender mempertahankan gradien pada permukaan depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini membutuhkan file yang ada bernama "image.jpg" di direktori kerja. Ia memperluas gambar untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan atau merender file:

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

Gambar dirender pada permukaan depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada permukaan depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf-huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye-dan-putih, menerapkan lengkungan ke atas, dan mengkonfigurasi pengaturan 3D melalui [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis luar disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan dimensi slide dua kali ukuran default dan menyimpan presentasi sebagai PPTX:

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

Teks dirender sebagai huruf 3D melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Pertahankan Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan penampilan 3D bentuk, panggil [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) melalui [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Ketika nilainya `true`, teks tetap di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D-nya.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusinya tetap dikonfigurasi melalui [IShape.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Ini juga berbeda dari rotasi biasa. [IShape.setRotation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setRotation-float-) memutar bentuk pada bidang slide, sedangkan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di samping yang asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh ini menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan dimensi dua kali ukuran default.

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

Di sebelah kiri, teks mengikuti orientasi 3D. Di sebelah kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang sama.

![Persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D diubah menjadi raster atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/androidjava/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), atau menghasilkan frame untuk [konversi video](/slides/id/androidjava/convert-powerpoint-to-video/).

Perhatikan poin-poin berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/androidjava/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih-alih disimpan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang interaktif sebagai adegan 3D yang dapat diputar penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila format mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang dimasukkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan salah satu ekstrusi atau kedalaman. Praktiknya, juga atur light rig dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [IShape.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk badan bentuk dan [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D ketika menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/androidjava/shape-effective-properties/) untuk membaca kamera akhir, light rig, bevel, dan nilai 3D terkait lainnya.