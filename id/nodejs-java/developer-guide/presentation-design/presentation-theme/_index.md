---
title: Kelola Tema Presentasi dalam JavaScript
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/nodejs-java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema presentasi
- Tema slide
- Atur tema
- Ubah tema
- Kelola tema
- Warna tema
- Palet tambahan
- Font tema
- Gaya tema
- Efek tema
- PowerPoint
- OpenDocument
- Presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola tema presentasi utama dalam JavaScript dengan Aspose.Slides untuk Node.js untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan identitas merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih satu set elemen visual tertentu beserta propertinya.

Di PowerPoint, sebuah tema terdiri dari warna, [fonts](/slides/id/nodejs-java/powerpoint-fonts/), [background styles](/slides/id/nodejs-java/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan satu set warna tertentu untuk elemen yang berbeda pada sebuah slide. Jika Anda tidak menyukai warna-warna tersebut, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai-nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SchemeColor).

Kode JavaScript ini menunjukkan cara mengubah warna aksen untuk sebuah tema:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Anda dapat menentukan nilai efektif warna yang dihasilkan dengan cara ini:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Untuk memperlihatkan lebih lanjut operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) padanya. Kemudian kami mengubah warna dalam tema:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Warna baru diterapkan secara otomatis pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Saat Anda menerapkan transformasi luminansi pada warna tema utama(1), warna-warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna tema tersebut. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Warna tema utama

**2** - Warna dari palet tambahan.

Kode JavaScript ini mendemonstrasikan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan dalam bentuk:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Aksen 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Aksen 4, Lebih Terang 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Aksen 4, Lebih Terang 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Aksen 4, Lebih Terang 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Aksen 4, Lebih Gelap 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Aksen 4, Lebih Gelap 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Petakan `SchemeColor` ke Warna `ColorScheme`**

Ketika Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai-nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation.getMasterTheme().getColorScheme()` mengembalikan [ColorScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colorscheme/), yang menampilkan warna yang sesuai sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai ini merujuk ke slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanyalah nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI terbaru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan tujuan lainnya, Aspose.Slides menggunakan pengenal khusus berikut (mirip dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Tubuh Latin (Font Latin Minor)
* **+mj-lt** - Font Heading Latin (Font Latin Mayor)
* **+mn-ea** - Font Tubuh Asia Timur (Font Asia Timur Minor)
* **+mj-ea** - Font Tubuh Asia Timur (Font Asia Timur Mayor)

Kode JavaScript ini menunjukkan cara menetapkan font Latin ke elemen tema:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Kode JavaScript ini menunjukkan cara mengubah font tema presentasi:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Font di semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [PowerPoint fonts](/slides/id/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 dari 12 latar belakang tersebut yang disimpan dalam presentasi tipikal. 

![todo:image_alt_text](presentation-design_8.png)

Sebagai contoh, setelah Anda menyimpan sebuah presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode JavaScript ini untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme), Anda dapat menambahkan atau mengakses gaya latar belakang dalam tema PowerPoint.
{{% /alert %}} 

Kode JavaScript ini menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Panduan Indeks**: 0 digunakan untuk tanpa isi. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [PowerPoint Background](/slides/id/nodejs-java/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap array gaya. Array tersebut digabungkan menjadi 3 efek berikut: subtle, moderate, dan intense. Misalnya, ini adalah hasil ketika efek diterapkan pada bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FormatScheme) Anda dapat mengubah elemen dalam tema (lebih fleksibel dibandingkan opsi di PowerPoint).

Kode JavaScript ini menunjukkan cara mengubah efek tema dengan mengubah bagian-bagian elemen:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Perubahan yang dihasilkan pada warna isi, tipe isi, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Apakah saya dapat menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sementara tema master tetap (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidethememanager/)).

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

[*Clone slides*](/slides/id/nodejs-java/clone-slides/) bersama dengan master-nya ke presentasi target. Ini mempertahankan master asli, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "effective" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan "effective" API [/slides/id/nodejs-java/shape-effective-properties/] untuk tema/warna/font/efek. Ini mengembalikan properti akhir yang telah diselesaikan setelah menerapkan master serta penimpaan lokal apa pun.