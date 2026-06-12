---
title: Buat dan Terapkan Efek WordArt dalam JavaScript
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
- efek tampilan
- efek cahaya
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Node.js. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional."
---
## **Ikhtisar**

Efek WordArt memungkinkan Anda menambahkan teks yang menarik secara visual dan bergaya ke presentasi PowerPoint Anda. Dengan Aspose.Slides, pengembang dapat secara programatik membuat, menyesuaikan, dan mengelola WordArt seperti di Microsoft PowerPoint—tanpa perlu menginstal Office. Artikel ini memberikan ikhtisar tentang cara bekerja dengan WordArt, termasuk cara menerapkan transformasi teks, gaya isi, outline, bayangan, dan opsi pemformatan lainnya untuk membuat konten presentasi Anda lebih ekspresif dan menarik. WordArt memungkinkan Anda memperlakukan teks sebagai objek grafis. Ia terdiri dari efek atau modifikasi khusus yang diterapkan pada teks untuk membuatnya lebih menarik atau terlihat.

## **Membuat Template WordArt Sederhana dan Menerapkannya ke Teks**

**Menggunakan Aspose.Slides** 

Pertama, kami membuat teks sederhana menggunakan kode JavaScript ini:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Sekarang, kami mengatur tinggi font teks ke nilai yang lebih besar agar efeknya lebih terlihat melalui kode ini:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Menggunakan Microsoft PowerPoint**

Buka menu efek WordArt di Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dari menu di kanan, Anda dapat memilih efek WordArt yang telah ditentukan sebelumnya. Dari menu di kiri, Anda dapat menentukan pengaturan untuk WordArt baru. 

Berikut adalah beberapa parameter atau opsi yang tersedia:

![todo:image_alt_text](image-20200930114015-3.png)

**Menggunakan Aspose.Slides**

Di sini, kami menerapkan warna pola [SmallGrid](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PatternStyle#SmallGrid) ke teks dan menambahkan batas teks hitam dengan lebar 1 menggunakan kode berikut:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Teks hasil:

![todo:image_alt_text](image-20200930114108-4.png)

## **Menerapkan Efek WordArt Lainnya**

**Menggunakan Microsoft PowerPoint**

Dari kelas program, Anda dapat menerapkan efek-efek ini ke teks, blok teks, bentuk, atau elemen serupa:

![todo:image_alt_text](image-20200930114129-5.png)

Misalnya, efek Shadow, Reflection, dan Glow dapat diterapkan pada teks; efek 3D Format dan 3D Rotation dapat diterapkan pada blok teks; properti Soft Edges dapat diterapkan pada Objek Shape (masih berpengaruh meskipun tidak ada properti 3D Format yang diatur). 

### **Menerapkan Efek Bayangan**

Di sini, kami bermaksud mengatur properti yang hanya terkait dengan teks. Kami menerapkan efek bayangan pada teks menggunakan kode berikut dalam JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

API Aspose.Slides mendukung tiga jenis bayangan: OuterShadow, InnerShadow, dan PresetShadow. 

Dengan PresetShadow, Anda dapat menerapkan bayangan pada teks (menggunakan nilai preset). 

**Menggunakan Microsoft PowerPoint**

Di PowerPoint, Anda dapat menggunakan satu jenis bayangan. Berikut contohnya:

![todo:image_alt_text](image-20200930114225-6.png)

**Menggunakan Aspose.Slides**

Aspose.Slides sebenarnya memungkinkan Anda menerapkan dua jenis bayangan sekaligus: InnerShadow dan PresetShadow.

Catatan:

- Ketika OuterShadow dan PresetShadow digunakan bersamaan, hanya efek OuterShadow yang diterapkan. 
- Jika OuterShadow dan InnerShadow digunakan secara bersamaan, efek yang dihasilkan atau diterapkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi dua kali lipat. Tetapi di PowerPoint 2007, efek OuterShadow yang diterapkan. 

### **Menerapkan Display ke Teks**

Kami menambahkan display ke teks melalui contoh kode ini dalam JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Menerapkan Efek Glow ke Teks**

Kami menerapkan efek glow ke teks agar bersinar atau menonjol menggunakan kode berikut:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Hasil operasi:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Kamu dapat mengubah parameter untuk bayangan, display, dan glow. Properti efek diatur pada setiap bagian teks secara terpisah. 

{{% /alert %}} 

### **Menggunakan Transformasi dalam WordArt**

Kami menggunakan properti Transform (mewarisi seluruh blok teks) melalui kode berikut:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Hasilnya:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Baik Microsoft PowerPoint maupun Aspose.Slides untuk Node.js via Java menyediakan sejumlah jenis transformasi yang telah ditentukan sebelumnya.

{{% /alert %}} 

**Menggunakan PowerPoint**

Untuk mengakses jenis transformasi yang telah ditentukan, buka: **Format** -> **TextEffect** -> **Transform**

**Menggunakan Aspose.Slides**

Untuk memilih jenis transformasi, gunakan enum TextShapeType. 

### **Menerapkan efek 3D pada Teks dan Bentuk**

Kami menetapkan efek 3D pada bentuk teks menggunakan contoh kode berikut:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Teks dan bentuk yang dihasilkan:

![todo:image_alt_text](image-20200930114816-9.png)

Kami menerapkan efek 3D ke teks dengan kode JavaScript berikut:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Hasil operasi:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Penerapan efek 3D pada teks atau bentuknya dan interaksi antar efek didasarkan pada aturan tertentu. 

Pertimbangkan sebuah scene untuk teks dan bentuk yang berisi teks tersebut. Efek 3D mencakup representasi objek 3D dan scene tempat objek ditempatkan. 

- Ketika scene diatur untuk baik gambar maupun teks, scene gambar memiliki prioritas lebih tinggi—scene teks diabaikan. 
- Ketika gambar tidak memiliki scene sendiri tetapi memiliki representasi 3D, scene teks yang digunakan. 
- Jika tidak—ketika bentuk pada awalnya tidak memiliki efek 3D—bentuk tetap datar dan efek 3D hanya diterapkan pada teks. 

Deskripsi ini terkait dengan metode ThreeDFormat.getLightRig() dan ThreeDFormat.getCamera().

{{% /alert %}} 

## **Menerapkan Efek Outer Shadow pada Teks**

Aspose.Slides untuk Node.js via Java menyediakan kelas [**OuterShadow**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/outershadow/) dan [**InnerShadow**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/innershadow/) yang memungkinkan Anda menerapkan efek bayangan pada teks yang dibawa oleh [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/). Ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation). 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Tambahkan AutoShape bertipe Rectangle ke slide. 
4. Akses TextFrame yang terkait dengan AutoShape. 
5. Atur FillType AutoShape ke NoFill. 
6. Instansiasi kelas OuterShadow 
7. Atur BlurRadius bayangan. 
8. Atur Direction bayangan 
9. Atur Distance bayangan. 
10. Atur RectanglelAlign ke TopLeft. 
11. Atur PresetColor bayangan ke Black. 
12. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

Contoh kode berikut dalam Java—implementasi langkah-langkah di atas—menunjukkan cara menerapkan efek outer shadow pada teks:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan referensi slide
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Tambahkan TextFrame ke Rectangle
    ashp.addTextFrame("Aspose TextBox");
    // Nonaktifkan isian shape jika ingin mendapatkan bayangan teks
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Tambahkan outer shadow dan atur semua parameter yang diperlukan
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Simpan presentasi ke disk
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menerapkan Efek Inner Shadow pada Bentuk**

Ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation). 
2. Dapatkan referensi slide. 
3. Tambahkan AutoShape bertipe Rectangle. 
4. Aktifkan InnerShadowEffect. 
5. Atur semua parameter yang diperlukan. 
6. Atur ColorType menjadi Scheme. 
7. Atur Scheme Color. 
8. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) file. 

Contoh kode berikut (berdasarkan langkah-langkah di atas) menunjukkan cara menambahkan konektor antara dua bentuk dalam JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan referensi slide
    var slide = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Tambahkan TextFrame ke Rectangle
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Aktifkan InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Atur semua parameter yang diperlukan
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Setel ColorType menjadi Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Setel Warna Skema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Simpan Presentasi
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tanya Jawab**

**Apakah saya dapat menggunakan efek WordArt dengan berbagai font atau skrip (mis., Arab, Cina)?**

Ya, Aspose.Slides mendukung Unicode dan bekerja dengan semua font dan skrip utama. Efek WordArt seperti bayangan, isi, dan outline dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada shape di master slide, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan yang dibuat pada tata letak master akan tercermin pada semua slide terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, glow, dan isian gradasi dapat sedikit menambah ukuran file karena metadata pemformatan tambahan, namun perbedaannya biasanya tidak signifikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (mis., PNG, JPEG) menggunakan metode `getImage` dari kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) atau [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/). Ini memungkinkan Anda melihat pratinjau hasil dalam memori atau di layar sebelum menyimpan atau mengekspor presentasi lengkap.