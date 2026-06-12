---
title: Buat dan Terapkan Efek WordArt pada Android
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
- efek cahaya
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Android. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional dalam Java."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda menambahkan teks bergaya yang menarik secara visual ke presentasi PowerPoint Anda. Dengan Aspose.Slides, pengembang dapat secara programatis membuat, menyesuaikan, dan mengelola WordArt persis seperti di Microsoft PowerPoint—tanpa perlu menginstal Office. Artikel ini memberikan gambaran tentang cara bekerja dengan WordArt, termasuk cara menerapkan transformasi teks, gaya isi, garis tepi, bayangan, dan opsi pemformatan lainnya untuk membuat konten presentasi Anda lebih ekspresif dan menarik. WordArt memungkinkan Anda memperlakukan teks sebagai objek grafis. Ini terdiri dari efek atau modifikasi khusus yang diterapkan pada teks agar lebih menarik atau terlihat.

## **Buat Template WordArt Sederhana dan Terapkan ke Teks**

**Menggunakan Aspose.Slides** 

Pertama, kami membuat teks sederhana menggunakan kode Java berikut: 

``` java
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
Sekarang, kami mengatur tinggi font teks ke nilai yang lebih besar agar efeknya lebih terlihat melalui kode berikut:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Menggunakan Microsoft PowerPoint**

Buka menu efek WordArt di Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dari menu di sebelah kanan, Anda dapat memilih efek WordArt yang telah ditentukan sebelumnya. Dari menu di sebelah kiri, Anda dapat menentukan pengaturan untuk WordArt baru. 

Berikut beberapa parameter atau opsi yang tersedia:

![todo:image_alt_text](image-20200930114015-3.png)

**Menggunakan Aspose.Slides**

Di sini, kami menerapkan warna pola [SmallGrid](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PatternStyle#SmallGrid) ke teks dan menambahkan batas teks berwarna hitam dengan lebar 1 menggunakan kode berikut:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Teks yang dihasilkan:

![todo:image_alt_text](image-20200930114108-4.png)

## **Terapkan Efek WordArt Lainnya**

**Menggunakan Microsoft PowerPoint**

Dari antarmuka program, Anda dapat menerapkan efek ini pada teks, blok teks, bentuk, atau elemen serupa:

![todo:image_alt_text](image-20200930114129-5.png)

Sebagai contoh, efek Shadow, Reflection, dan Glow dapat diterapkan pada teks; efek 3D Format dan 3D Rotation dapat diterapkan pada blok teks; properti Soft Edges dapat diterapkan pada objek Shape (masih berpengaruh ketika tidak ada properti 3D Format yang disetel). 

### **Terapkan Efek Bayangan**

Di sini, kami bermaksud mengatur properti yang hanya terkait dengan teks. Kami menerapkan efek bayangan pada teks menggunakan kode Java berikut:

``` java
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
```

API Aspose.Slides mendukung tiga jenis bayangan: OuterShadow, InnerShadow, dan PresetShadow. 

Dengan PresetShadow, Anda dapat menerapkan bayangan pada teks (menggunakan nilai yang telah ditentukan). 

**Menggunakan Microsoft PowerPoint**

Di PowerPoint, Anda dapat menggunakan satu jenis bayangan. Berikut contohnya:

![todo:image_alt_text](image-20200930114225-6.png)

**Menggunakan Aspose.Slides**

Aspose.Slides sebenarnya memungkinkan Anda menerapkan dua jenis bayangan sekaligus: InnerShadow dan PresetShadow.

**Catatan:**

- Ketika OuterShadow dan PresetShadow digunakan bersama, hanya efek OuterShadow yang diterapkan. 
- Jika OuterShadow dan InnerShadow digunakan secara bersamaan, efek yang dihasilkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi ganda. Tetapi di PowerPoint 2007, efek OuterShadow yang diterapkan. 

### **Terapkan Efek Refleksi pada Teks**

Kami menambahkan tampilan pada teks melalui contoh kode Java berikut:

``` java
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
```

### **Terapkan Efek Glow pada Teks**

Kami menerapkan efek glow pada teks agar bersinar atau menonjol menggunakan kode berikut:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Hasil operasi:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Anda dapat mengubah parameter untuk bayangan, tampilan, dan glow. Properti efek diatur pada setiap bagian teks secara terpisah. 

{{% /alert %}} 

### **Gunakan Transformasi dalam WordArt**

Kami menggunakan properti Transform (yang melekat pada seluruh blok teks) melalui kode berikut:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Hasilnya:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Baik Microsoft PowerPoint maupun Aspose.Slides untuk Android via Java menyediakan sejumlah jenis transformasi yang telah ditentukan sebelumnya. 

{{% /alert %}} 

**Menggunakan PowerPoint**

Untuk mengakses jenis transformasi yang telah ditentukan, buka: **Format** -> **TextEffect** -> **Transform**

**Menggunakan Aspose.Slides**

Untuk memilih jenis transformasi, gunakan enum TextShapeType. 

### **Terapkan Efek 3D pada Teks dan Bentuk**

Kami menetapkan efek 3D pada bentuk teks menggunakan contoh kode berikut:

``` java
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
```

Teks dan bentuk yang dihasilkan:

![todo:image_alt_text](image-20200930114816-9.png)

Kami menerapkan efek 3D pada teks dengan kode Java berikut:

``` java
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
```

Hasil operasi:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Penerapan efek 3D pada teks atau bentuknya serta interaksi antar efek didasarkan pada aturan tertentu. 

Pertimbangkan sebuah adegan untuk teks dan bentuk yang berisi teks tersebut. Efek 3D mencakup representasi objek 3D dan adegan tempat objek ditempatkan. 

- Ketika adegan ditetapkan untuk baik gambar maupun teks, adegan gambar mendapatkan prioritas lebih tinggi—adegan teks diabaikan. 
- Ketika gambar tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan. 
- Jika tidak—ketika bentuk pada awalnya tidak memiliki efek 3D—bentuk tetap datar dan efek 3D hanya diterapkan pada teks. 

Deskripsi ini terkait dengan metode ThreeDFormat.getLightRig() dan ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Terapkan Efek Outer Shadow pada Teks**
Aspose.Slides untuk Android via Java menyediakan kelas [**IOuterShadow**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioutershadow/) dan [**IInnerShadow**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iinnershadow/) yang memungkinkan Anda menerapkan efek bayangan pada teks yang terdapat dalam [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/). Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).  
2. Dapatkan referensi slide dengan menggunakan indeksnya.  
3. Tambahkan AutoShape tipe Rectangle ke slide.  
4. Akses TextFrame yang terkait dengan AutoShape.  
5. Atur FillType AutoShape menjadi NoFill.  
6. Instansiasi kelas OuterShadow.  
7. Atur BlurRadius bayangan.  
8. Atur Direction bayangan.  
9. Atur Distance bayangan.  
10. Atur RectanglelAlign ke TopLeft.  
11. Atur PresetColor bayangan ke Black.  
12. Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Contoh kode Java—implementasi langkah‑langkah di atas—menunjukkan cara menerapkan efek outer shadow pada teks:

```java
Presentation pres = new Presentation();
try {
    // Dapatkan referensi slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Tambahkan TextFrame ke Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Nonaktifkan isi shape jika kita ingin mendapatkan bayangan teks
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Tambahkan outer shadow dan atur semua parameter yang diperlukan
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Simpan presentasi ke disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Efek Inner Shadow pada Bentuk**
Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).  
2. Dapatkan referensi slide.  
3. Tambahkan AutoShape tipe Rectangle.  
4. Aktifkan InnerShadowEffect.  
5. Atur semua parameter yang diperlukan.  
6. Atur ColorType menjadi Scheme.  
7. Atur Scheme Color.  
8. Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Contoh kode (berdasarkan langkah‑langkah di atas) menunjukkan cara menambahkan konektor antara dua bentuk dalam Java:

```java
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

    // Atur ColorType sebagai Scheme
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

**Apakah saya dapat menggunakan efek WordArt dengan berbagai jenis font atau aksara (mis. Arab, China)?**  

Ya, Aspose.Slides mendukung Unicode dan bekerja dengan semua font serta aksara utama. Efek WordArt seperti bayangan, isi, dan garis tepi dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**  

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**  

Sedikit. Efek WordArt seperti bayangan, glow, dan isi gradien dapat sedikit meningkatkan ukuran file karena penambahan metadata pemformatan, tetapi perbedaannya biasanya tidak signifikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**  

Ya, Anda dapat merender slide yang berisi WordArt ke gambar (mis. PNG, JPEG) menggunakan metode `getImage` dari antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) atau [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/). Ini memungkinkan Anda melihat pratinjau secara langsung di memori atau layar sebelum menyimpan atau mengekspor seluruh presentasi.