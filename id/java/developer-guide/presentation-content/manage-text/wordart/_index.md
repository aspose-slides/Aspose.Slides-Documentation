---
title: Membuat dan Menerapkan Efek WordArt di Java
linktitle: WordArt
type: docs
weight: 110
url: /id/java/wordart/
keywords:
- WordArt
- membuat WordArt
- template WordArt
- efek WordArt
- efek bayangan
- efek refleksi
- efek cahaya bersinar
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- Java
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Java. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional di Java."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda menata teks dengan isian, garis luar, bayangan, refleksi, cahaya bersinar, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek-efek tersebut dalam presentasi PowerPoint menggunakan Aspose.Slides for Java, tanpa perlu menginstal Microsoft Office.

## **Buat Template WordArt Sederhana dan Terapkan pada Teks**

Contoh-contoh berikut membangun gaya WordArt sederhana dengan menetapkan teks, font, pola isi, dan garis luar.

Setiap contoh membuat presentasi baru dan menambahkan sebuah persegi panjang ke slide pertama; tidak diperlukan file masukan. Contoh pertama menetapkan teks menjadi "Aspose.Slides". Posisi dan dimensi bentuk diukur dalam poin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Atur font menjadi Arial Black pada 36 poin agar pemformatan lebih terlihat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/java/com.aspose.slides/patternstyle/#SmallGrid) dengan latar depan oranye gelap dan latar belakang putih, lalu tambahkan garis luar teks hitam dengan lebar 1 poin:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Template WordArt sederhana](WordArt_template.png)

## **Terapkan Efek WordArt Lainnya**

Contoh-contoh berikut menunjukkan cara menerapkan bayangan, refleksi, cahaya bersinar, transformasi, dan efek 3D pada teks.

### **Terapkan Efek Bayangan Luar**

Bayangan luar menambahkan kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius keburaman, skala, dan kemiringan.

Contoh ini memanggil [enableOuterShadowEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) dan menetapkan bayangan hitam dengan radius keburaman 4 poin, arah 230 derajat, dan jarak 30 poin. Nilai skala 100 mempertahankan ukuran bayangan, sementara kemiringan horizontal memiringkannya sebesar 20 derajat. Transformasi alfa mengatur opasitas menjadi 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Bayangan Luar](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ketika bayangan luar dan bayangan preset digunakan bersama, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan dalam digunakan sekaligus, efek yang dihasilkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi dua kali lipat, sedangkan di PowerPoint 2007, hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Terapkan Efek Refleksi**

Refleksi membuat salinan cermin dari teks. Sesuaikan posisi, skala, keburaman, dan opasitas untuk mengontrol penampilannya.

Contoh ini memanggil [enableReflectionEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/effectformat/#enableReflectionEffect--) dan membalikkan refleksi secara vertikal dengan skala -100%. Ia menggunakan radius keburaman 0,5 poin dan jarak 4,72 poin. Opasitas menurun dari 60% menjadi 0,9% antara posisi 0% dan 60% sepanjang refleksi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Refleksi](reflection_effect.png)

### **Terapkan Efek Glow**

Glow menambahkan garis luar berwarna lembut di sekitar teks. Sesuaikan warna, opasitas, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [enableGlowEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/effectformat/#enableGlowEffect--) dan menerapkan glow merah dengan opasitas 54% serta radius 7 poin:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Glow](glow_effect.png)

### **Terapkan Transformasi WordArt**

Transformasi WordArt membengkokkan, meregangkan, atau memelintir blok teks.

Atur [setTransform](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframeformat/#setTransform-int-) ke [ArchUpPour](https://reference.aspose.com/slides/id/java/com.aspose.slides/textshapetype/#ArchUpPour) untuk melengkungkan seluruh bingkai teks ke atas:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Transformasi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java menyediakan sekumpulan [tipe transformasi yang telah ditentukan sebelumnya](https://reference.aspose.com/slides/id/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Terapkan Efek 3D pada Bentuk dan Teks**

Anda dapat menerapkan efek 3D pada sebuah bentuk atau pada teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol penampilan akhir.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah tua pada persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam poin. Material plastik, pencahayaan seimbang yang diputar 40 derajat di sekitar sumbu Z, dan kamera perspektif menentukan penampilannya:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Efek 3D pada bentuk:

![Efek 3D Bentuk](shape_3D_effect.png)

Contoh ini menerapkan pemformatan 3D serupa pada teks melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberi teks kedalaman:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek 3D Teks](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Penerapan efek 3D pada teks atau pada bentuknya—dan interaksi antara efek-efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah adegan yang melibatkan baik teks maupun bentuk yang menampungnya. Sebuah efek 3D mencakup representasi 3D objek serta adegan tempat objek tersebut ditempatkan.

- Jika sebuah adegan ditetapkan untuk baik bentuk maupun teks, adegan bentuk memiliki prioritas dan adegan teks diabaikan.
- Jika bentuk tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang akan digunakan.
- Jika bentuk tidak memiliki efek 3D sama sekali, ia diperlakukan sebagai datar, dan efek 3D hanya diterapkan pada teks.

Perilaku ini terkait dengan metode [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/#getLightRig--) dan [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Untuk menjaga teks tetap datar dan dapat dibaca sambil mempertahankan pemformatan 3D bentuknya, lihat [Jaga Teks Tetap Datar pada Bentuk 3D](/slides/id/java/3d-presentation/) untuk perbandingan kedua pengaturan dan contoh Java lengkap.

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip yang berbeda (mis., Arab, Cina)?**

Ya, Aspose.Slides for Java mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti bayangan, isi, dan garis luar dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide yang terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, glow, dan isi gradien dapat sedikit meningkatkan ukuran file akibat metadata pemformatan tambahan, namun perbedaannya biasanya tidak signifikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (mis., PNG, JPEG) menggunakan [ISlide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getImage--), atau merender bentuk individual menggunakan [IShape.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getImage--). Ini memungkinkan Anda melihat pratinjau hasil di memori atau layar sebelum menyimpan atau mengekspor presentasi lengkap.