---
title: Buat dan Terapkan Efek WordArt di Node.js
linktitle: WordArt
type: docs
weight: 110
url: /id/nodejs-java/wordart/
keywords:
- WordArt
- buat WordArt
- template WordArt
- efek WordArt
- efek bayangan
- efek refleksi
- efek cahaya bersinar
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Node.js via Java. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional di Node.js."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda memberi gaya pada teks dengan isian, garis luar, bayangan, refleksi, cahaya bersinar, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek tersebut dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js via Java, tanpa perlu menginstal Microsoft Office.

## **Buat Template WordArt Sederhana dan Terapkan ke Teks**

Contoh berikut membangun gaya WordArt sederhana dengan mengatur teks, font, pola isian, dan garis luar.

Setiap contoh membuat presentasi baru dan menambahkan sebuah persegi panjang ke slide pertama; tidak diperlukan file masukan. Contoh pertama mengatur teks menjadi "Aspose.Slides". Posisi dan dimensi bentuk diukur dalam poin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Atur font ke Arial Black dengan ukuran 36 poin agar pemformatan lebih terlihat:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/patternstyle/#SmallGrid) dengan latar depan oranye tua dan latar belakang putih, lalu tambahkan garis luar teks berwarna hitam dengan lebar 1 poin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Template WordArt sederhana](WordArt_template.png)

## **Terapkan Efek WordArt Lainnya**

Contoh berikut menunjukkan cara menerapkan bayangan, refleksi, cahaya bersinar, transformasi, dan efek 3D pada teks.

### **Terapkan Efek Bayangan Luar**

Bayangan luar menambah kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius blur, skala, dan kemiringan.

Contoh ini memanggil [enableOuterShadowEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) dan mengatur bayangan hitam dengan radius blur 4 poin, arah 230 derajat, dan jarak 30 poin. Nilai skala 100 mempertahankan ukuran bayangan, sementara kemiringan horizontal memiringkannya 20 derajat. Transformasi alfa mengatur opasitas menjadi 32%:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Bayangan Luar](outer_shadow_effect.png)

{{% alert color="info" title="Catatan" %}}
- Ketika bayangan luar dan bayangan preset digunakan bersamaan, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan bayangan dalam digunakan secara simultan, efek yang dihasilkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi dua kali lipat, sedangkan di PowerPoint 2007, hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Terapkan Efek Refleksi**

Refleksi membuat salinan teks yang dicerminkan. Sesuaikan posisi, skala, blur, dan opasitas untuk mengontrol penampilannya.

Contoh ini memanggil [enableReflectionEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) dan membalik refleksi secara vertikal dengan skala -100%. Ia menggunakan radius blur 0,5 poin dan jarak 4,72 poin. Opasitas menurun dari 60% menjadi 0,9% antara posisi 0% dan 60% sepanjang refleksi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Refleksi](reflection_effect.png)

### **Terapkan Efek Cahaya Bersinar**

Cahaya bersinar menambahkan garis luar berwarna lembut di sekitar teks. Sesuaikan warna, opasitas, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [enableGlowEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) dan menerapkan cahaya bersinar merah dengan opasitas 54% serta radius 7 poin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek Cahaya Bersinar](glow_effect.png)

### **Terapkan Transformasi WordArt**

Transformasi WordArt melengkungkan, meregangkan, atau memelintir blok teks.

Atur [setTransform](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setTransform) ke [ArchUpPour](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) untuk melengkungkan seluruh rangka teks ke atas:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Transformasi WordArt](transform_effect.png)

{{% alert color="info" title="Catatan" %}}
Aspose.Slides untuk Node.js via Java menyediakan sekumpulan [tipe transformasi](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textshapetype/) yang telah ditentukan sebelumnya.
{{% /alert %}}

### **Terapkan Efek 3D pada Bentuk dan Teks**

Anda dapat menerapkan efek 3D pada sebuah bentuk atau pada teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol tampilan hasil.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah tua pada persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam poin. Material plastik, pencahayaan seimbang yang diputar 40 derajat di sekitar sumbu Z, serta kamera perspektif menentukan penampilannya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Bentuk yang dihasilkan:

![Efek 3D pada bentuk](shape_3D_effect.png)

Contoh ini menerapkan pemformatan 3D serupa pada teks melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberi kedalaman pada teks:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Teks yang dihasilkan:

![Efek 3D pada teks](text_3D_effect.png)

{{% alert color="info" title="Catatan" %}}
Penerapan efek 3D pada teks atau bentuknya—dan interaksi antara efek-efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah adegan yang melibatkan baik teks maupun bentuk yang menampungnya. Efek 3D mencakup representasi 3D objek serta adegan tempat objek tersebut ditempatkan.

- Jika sebuah adegan ditetapkan untuk baik bentuk maupun teks, adegan bentuk memiliki prioritas dan adegan teks diabaikan.
- Jika bentuk tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan.
- Jika bentuk tidak memiliki efek 3D sama sekali, ia diperlakukan sebagai datar, dan efek 3D diterapkan hanya pada teks.

Perilaku ini terkait dengan metode [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getLightRig) dan [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Untuk menjaga teks tetap datar dan dapat dibaca sambil mempertahankan pemformatan 3D bentuknya, lihat [Jaga Teks Tetap Datar pada Bentuk 3D](/slides/id/nodejs-java/3d-presentation/) untuk perbandingan kedua pengaturan dan contoh JavaScript lengkap.

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip yang berbeda (mis., Arab, Cina)?**

Ya, Aspose.Slides untuk Node.js via Java mendukung Unicode dan berfungsi dengan semua font dan skrip utama. Efek WordArt seperti bayangan, isian, dan garis luar dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide yang terkait.

**Apakah efek WordArt memengaruhi ukuran berkas presentasi?**

Sedikit. Efek WordArt seperti bayangan, cahaya bersinar, dan isian gradasi dapat sedikit menambah ukuran berkas karena metadata pemformatan tambahan, tetapi perbedaannya biasanya dapat diabaikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (mis., PNG, JPEG) menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage), atau merender bentuk individual menggunakan [Shape.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage). Ini memungkinkan Anda meninjau hasil dalam memori atau di layar sebelum menyimpan atau mengekspor presentasi secara lengkap.