---
title: Buat dan Terapkan Efek WordArt di Android
linktitle: WordArt
type: docs
weight: 110
url: /id/androidjava/wordart/
keywords:
- WordArt
- buat WordArt
- template WordArt
- efek WordArt
- efek bayangan
- efek refleksi
- efek cahaya
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Android via Java. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional di Android."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda memberi gaya pada teks dengan isian, outline, bayangan, refleksi, cahaya, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek-efek ini dalam presentasi PowerPoint menggunakan Aspose.Slides for Android via Java, tanpa perlu menginstal Microsoft Office.

## **Buat Template WordArt Sederhana dan Terapkan ke Teks**

Contoh-contoh berikut membuat gaya WordArt sederhana dengan mengatur teks, font, isian pola, dan outline.

Setiap contoh membuat presentasi baru dan menambahkan persegi panjang ke slide pertama; tidak diperlukan file masukan. Contoh pertama mengatur teks menjadi "Aspose.Slides". Posisi dan dimensi bentuk diukur dalam poin:

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

Atur font ke Arial Black dengan ukuran 36 poin agar formatnya lebih terlihat:

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

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/patternstyle/#SmallGrid) dengan latar depan oranye gelap dan latar belakang putih, lalu tambahkan outline teks hitam dengan lebar 1 poin:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int darkOrange = Color.rgb(255, 140, 0);
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

Contoh-contoh berikut menunjukkan cara menerapkan bayangan, refleksi, cahaya, transformasi, dan efek 3D pada teks.

### **Terapkan Efek Bayangan Luar**

Bayangan luar menambah kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius blur, skala, dan skew.

Contoh ini memanggil [enableOuterShadowEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) dan mengatur bayangan hitam dengan radius blur 4 poin, arah 230 derajat, dan jarak 30 poin. Nilai skala 100 mempertahankan ukuran bayangan, sementara skew horizontal memiringkannya 20 derajat. Transformasi alfa mengatur opasitas menjadi 32%:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

{{% alert color="info" title="Catatan" %}}
- Ketika bayangan luar dan bayangan preset digunakan bersama, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan dalam digunakan secara bersamaan, efek yang dihasilkan bergantung pada versi PowerPoint. Misalnya, pada PowerPoint 2013, efeknya menjadi dua kali lipat, sedangkan pada PowerPoint 2007, hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Terapkan Efek Refleksi**

Refleksi membuat salinan teks yang tercermin. Sesuaikan posisi, skala, blur, dan opasitas untuk mengontrol penampilannya.

Contoh ini memanggil [enableReflectionEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) dan membalik refleksi secara vertikal dengan skala -100%. Ia menggunakan radius blur 0,5 poin dan jarak 4,72 poin. Opasitas menurun dari 60% menjadi 0,9% antara posisi 0% dan 60% sepanjang refleksi:

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

### **Terapkan Efek Cahaya**

Cahaya menambahkan outline berwarna lembut di sekitar teks. Sesuaikan warna, opasitas, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [enableGlowEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) dan menerapkan cahaya merah dengan opasitas 54% serta radius 7 poin:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Efek Cahaya](glow_effect.png)

### **Terapkan Transformasi WordArt**

Transformasi WordArt membengkokkan, meregangkan, atau melengkungkan blok teks.

Atur [setTransform](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) ke [ArchUpPour](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) untuk melengkungkan seluruh frame teks ke atas:

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

{{% alert color="info" title="Catatan" %}}
Aspose.Slides for Android via Java menyediakan sekumpulan tipe transformasi yang telah ditentukan sebelumnya.
{{% /alert %}}

### **Terapkan Efek 3D pada Bentuk dan Teks**

Anda dapat menerapkan efek 3D pada sebuah bentuk atau pada teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol tampilan akhir.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah gelap pada persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam poin. Material plastik, pencahayaan seimbang yang diputar 40 derajat di sekitar sumbu Z, dan kamera perspektif mendefinisikan penampilannya:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

Bentuk yang dihasilkan:

![Efek 3D bentuk](shape_3D_effect.png)

Contoh ini menerapkan format 3D serupa pada teks melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberikan kedalaman pada teks:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

![Efek 3D teks](text_3D_effect.png)

{{% alert color="info" title="Catatan" %}}
Penerapan efek 3D pada teks atau bentuk‑bentuknya—serta interaksi antara efek‑efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah adegan yang melibatkan baik teks maupun bentuk yang menampungnya. Sebuah efek 3D mencakup representasi 3D objek dan adegan tempat objek tersebut diletakkan.

- Jika sebuah adegan diatur untuk baik bentuk maupun teks, adegan bentuk memiliki prioritas dan adegan teks diabaikan.
- Jika bentuk tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan.
- Jika bentuk tidak memiliki efek 3D sama sekali, ia diperlakukan sebagai datar, dan efek 3D diterapkan hanya pada teks.

Perilaku ini terkait dengan metode [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/threedformat/#getLightRig--) dan [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Untuk menjaga teks tetap datar dan dapat dibaca sambil mempertahankan format 3D bentuknya, lihat [Jaga Teks Tetap Datar pada Bentuk 3D](/slides/id/androidjava/3d-presentation/) untuk perbandingan kedua pengaturan serta contoh lengkap Java.

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip yang berbeda (mis., Arab, Cina)?**

Ya, Aspose.Slides for Android via Java mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti bayangan, isian, dan outline dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan render dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide yang terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, cahaya, dan isian gradien dapat sedikit menambah ukuran file karena metadata format tambahan, namun perbedaannya biasanya tidak signifikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt ke gambar (mis., PNG, JPEG) menggunakan [ISlide.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#getImage--), atau merender bentuk individual menggunakan [IShape.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getImage--). Ini memungkinkan Anda melihat pratinjau hasil di memori atau layar sebelum menyimpan atau mengekspor presentasi secara lengkap.