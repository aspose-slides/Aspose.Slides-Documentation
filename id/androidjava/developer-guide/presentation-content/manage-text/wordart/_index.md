---
title: Membuat dan Menerapkan Efek WordArt di Android
linktitle: WordArt
type: docs
weight: 110
url: /id/androidjava/wordart/
keywords:
- WordArt
- buat WordArt
- templat WordArt
- efek WordArt
- efek bayangan
- efek tampilan
- efek glow
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Android. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional di Java."
---
## **Ringkasan**

Efek WordArt memungkinkan Anda menambahkan teks bergaya dan menarik secara visual ke presentasi PowerPoint Anda. Dengan Aspose.Slides, pengembang dapat secara programatis membuat, menyesuaikan, dan mengelola WordArt persis seperti di Microsoft PowerPoint—tanpa perlu menginstal Office. Artikel ini memberikan gambaran tentang bekerja dengan WordArt, termasuk cara menerapkan transformasi teks, gaya isi, garis tepi, bayangan, dan opsi pemformatan lainnya untuk membuat konten presentasi Anda lebih ekspresif dan menarik. WordArt memungkinkan Anda memperlakukan teks sebagai objek grafis. Ini terdiri dari efek atau modifikasi khusus yang diterapkan pada teks agar lebih menarik atau mencolok.

## **Buat Template WordArt Sederhana dan Terapkan pada Teks**

**Using Aspose.Slides** 

Pertama, kami membuat teks sederhana menggunakan kode Java berikut: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Sekarang, kami mengatur tinggi font teks ke nilai yang lebih besar agar efeknya lebih terlihat melalui kode ini:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Buka menu efek WordArt di Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dari menu di sebelah kanan, Anda dapat memilih efek WordArt yang telah ditentukan. Dari menu di sebelah kiri, Anda dapat menentukan pengaturan untuk WordArt baru. 

Berikut beberapa parameter atau opsi yang tersedia:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Di sini, kami menerapkan warna pola [SmallGrid](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PatternStyle#SmallGrid) pada teks dan menambahkan batas teks hitam dengan lebar 1 menggunakan kode berikut:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Teks hasilnya:

![todo:image_alt_text](image-20200930114108-4.png)

## **Terapkan Efek WordArt Lainnya**

**Using Microsoft PowerPoint**

Dari antarmuka program, Anda dapat menerapkan efek ini pada teks, blok teks, bentuk, atau elemen serupa:

![todo:image_alt_text](image-20200930114129-5.png)

Misalnya, efek Shadow, Reflection, dan Glow dapat diterapkan pada teks; efek 3D Format dan 3D Rotation dapat diterapkan pada blok teks; properti Soft Edges dapat diterapkan pada objek Shape (efek ini tetap ada ketika properti 3D Format tidak diatur). 

### **Terapkan Efek Bayangan**

Di sini, kami bermaksud mengatur properti yang hanya terkait dengan teks. Kami menerapkan efek bayangan pada teks menggunakan kode Java berikut:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides mendukung tiga jenis bayangan: OuterShadow, InnerShadow, dan PresetShadow. 

Dengan PresetShadow, Anda dapat menerapkan bayangan pada teks (menggunakan nilai preset). 

**Using Microsoft PowerPoint**

Di PowerPoint, Anda dapat menggunakan satu jenis bayangan. Berikut contohnya:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides sebenarnya memungkinkan Anda menerapkan dua jenis bayangan sekaligus: InnerShadow dan PresetShadow.

Catatan:

- Ketika OuterShadow dan PresetShadow digunakan bersama, hanya efek OuterShadow yang diterapkan. 
- Jika OuterShadow dan InnerShadow digunakan secara bersamaan, efek yang dihasilkan atau diterapkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi dua kali lipat. Tetapi di PowerPoint 2007, efek OuterShadow yang diterapkan. 

### **Terapkan Efek Refleksi pada Teks**

Kami menambahkan refleksi pada teks melalui contoh kode Java berikut:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Terapkan Efek Glow pada Teks**

Kami menerapkan efek glow pada teks agar bersinar atau menonjol menggunakan kode berikut:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Hasil operasi:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Anda dapat mengubah parameter untuk bayangan, refleksi, dan glow. Properti efek diatur pada setiap bagian teks secara terpisah. 

{{% /alert %}} 

### **Gunakan Transformasi dalam WordArt**

Kami menggunakan properti Transform (mewakili seluruh blok teks) melalui kode berikut:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Hasil:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Baik Microsoft PowerPoint maupun Aspose.Slides untuk Android via Java menyediakan sejumlah tipe transformasi yang telah ditentukan. 

{{% /alert %}} 

**Using PowerPoint**

Untuk mengakses tipe transformasi yang telah ditentukan, buka: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Untuk memilih tipe transformasi, gunakan enum TextShapeType. 

### **Terapkan Efek 3D pada Teks dan Bentuk**

Kami mengatur efek 3D pada bentuk teks menggunakan contoh kode berikut:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Teks dan bentuk hasilnya:

![todo:image_alt_text](image-20200930114816-9.png)

Kami menerapkan efek 3D pada teks dengan kode Java berikut:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Hasil operasi:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Penerapan efek 3D pada teks atau bentuknya serta interaksi antar efek didasarkan pada aturan tertentu. 

Pertimbangkan sebuah scene untuk teks dan bentuk yang berisi teks tersebut. Efek 3D mencakup representasi objek 3D dan scene tempat objek ditempatkan. 

- Ketika scene diatur untuk both figure dan teks, scene figure memiliki prioritas lebih tinggi—scene teks diabaikan. 
- Ketika figure tidak memiliki scene sendiri tetapi memiliki representasi 3D, scene teks yang digunakan. 
- Jika tidak—ketika bentuk pada awalnya tidak memiliki efek 3D—bentuk tetap datar dan efek 3D hanya diterapkan pada teks. 

Deskripsi ini terkait dengan metode ThreeDFormat.getLightRig() dan ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Terapkan Efek Bayangan Luar pada Teks**
Aspose.Slides untuk Android via Java menyediakan kelas [**IOuterShadow**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioutershadow/) dan [**IInnerShadow**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iinnershadow/) yang memungkinkan Anda menerapkan efek bayangan pada teks yang berada dalam [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/). Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) .
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Tambahkan AutoShape tipe Rectangle ke slide.
4. Akses TextFrame yang terkait dengan AutoShape.
5. Setel FillType AutoShape ke NoFill.
6. Instansiasi kelas OuterShadow
7. Setel BlurRadius bayangan.
8. Setel Direction bayangan
9. Setel Distance bayangan.
10. Setel RectangleAlign ke TopLeft.
11. Setel PresetColor bayangan ke Black.
12. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Contoh kode Java ini—implementasi langkah-langkah di atas—menunjukkan cara menerapkan efek bayangan luar pada teks:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Dapatkan referensi slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Tambahkan TextFrame ke Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Nonaktifkan isian bentuk jika kita ingin mendapatkan bayangan teks
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Tambahkan bayangan luar dan atur semua parameter yang diperlukan
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Simpan presentasi ke disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Efek Bayangan Dalam pada Bentuk**
Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) .
2. Dapatkan referensi slide.
3. Tambahkan AutoShape tipe Rectangle.
4. Aktifkan InnerShadowEffect.
5. Setel semua parameter yang diperlukan.
6. Setel ColorType menjadi Scheme.
7. Setel Scheme Color.
8. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Contoh kode ini (berdasarkan langkah-langkah di atas) menunjukkan cara menerapkan efek bayangan dalam pada teks menggunakan Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Dapatkan referensi slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Tambahkan TextFrame ke Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Aktifkan InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Atur semua parameter yang diperlukan
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Atur ColorType menjadi Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Atur Warna Skema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Simpan Presentasi
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Dapatkah saya menggunakan efek WordArt dengan font atau skrip yang berbeda (misalnya Arab, Cina)?

Ya, Aspose.Slides mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti bayangan, isi, dan garis tepi dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

### Dapatkah saya menerapkan efek WordArt pada elemen master slide?

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide yang terkait.

### Apakah efek WordArt memengaruhi ukuran file presentasi?

Sedikit. Efek WordArt seperti bayangan, glow, dan isian gradien dapat sedikit meningkatkan ukuran file karena penambahan metadata pemformatan, tetapi perbedaannya biasanya dapat diabaikan.

### Dapatkah saya melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?

Ya, Anda dapat merender slide yang berisi WordArt ke gambar (misalnya PNG, JPEG) menggunakan metode `getImage` dari antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) atau [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/). Ini memungkinkan Anda melihat pratinjau hasil secara in‑memory atau di layar sebelum menyimpan atau mengekspor presentasi lengkap.