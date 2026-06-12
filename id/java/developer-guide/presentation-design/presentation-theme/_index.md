---
title: Kelola Tema Presentasi di Java
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema presentasi
- Tema slide
- Mengatur tema
- Mengubah tema
- Mengelola tema
- Warna tema
- Palet tambahan
- Font tema
- Gaya tema
- Efek tema
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan penjenamaan yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih satu set elemen visual tertentu beserta propertinya.

Dalam PowerPoint, sebuah tema terdiri dari warna, [font](/slides/id/java/powerpoint-fonts/), [gaya latar belakang](/slides/id/java/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan satu set warna tertentu untuk elemen berbeda pada sebuah slide. Jika Anda tidak suka warna-warna tersebut, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai-nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/SchemeColor).

Kode Java berikut menunjukkan cara mengubah warna aksen untuk sebuah tema:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Anda dapat menentukan nilai efektif warna yang dihasilkan dengan cara ini:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Untuk lebih menunjukkan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) padanya. Kemudian kami mengubah warna dalam tema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Warna baru secara otomatis diterapkan pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Ketika Anda menerapkan transformasi luminansi ke warna tema utama(1), warna-warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1** - Warna tema utama  
**2** - Warna dari palet tambahan.

Kode Java berikut mendemonstrasikan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan dalam bentuk:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aksen 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Aksen 4, Lebih Terang 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Aksen 4, Lebih Terang 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Aksen 4, Lebih Terang 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Aksen 4, Lebih Gelap 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Aksen 4, Lebih Gelap 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Pemetaan `SchemeColor` ke Warna `IColorScheme`**

Ketika Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai-nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, and `Text2`.

Namun, `Presentation.getMasterTheme().getColorScheme()` mengembalikan [IColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorscheme/), yang menampilkan warna yang bersesuaian sebagai:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai ini merujuk pada slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanyalah nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari istilah Microsoft Office. Versi Office lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI terbaru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lain, Aspose.Slides menggunakan pengidentifikasi khusus berikut (mirip dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Tubuh Latin (Minor Latin Font)
* **+mj-lt** - Font Judul Latin (Major Latin Font)
* **+mn-ea** - Font Tubuh Asia Timur (Minor East Asian Font)
* **+mj-ea** - Font Tubuh Asia Timur (Major East Asian Font)

Kode Java berikut menunjukkan cara menetapkan font Latin ke elemen tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Kode Java berikut menunjukkan cara mengubah font tema presentasi:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Font di semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [font PowerPoint](/slides/id/java/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 dari 12 latar belakang tersebut yang disimpan dalam presentasi tipikal.

![todo:image_alt_text](presentation-design_8.png)

Sebagai contoh, setelah Anda menyimpan presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode Java ini untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Dengan menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme), Anda dapat menambahkan atau mengakses gaya latar belakang dalam tema PowerPoint. 
{{% /alert %}} 

Kode Java berikut menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Panduan indeks**: 0 digunakan untuk tanpa isian. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [Latar Belakang PowerPoint](/slides/id/java/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap larik gaya. Larik-larik tersebut digabungkan menjadi 3 efek ini: halus, sedang, dan intens. Misalnya, inilah hasil ketika efek diterapkan pada bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme#getEffectStyles--)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/FormatScheme), Anda dapat mengubah elemen dalam tema (lebih fleksibel daripada opsi di PowerPoint).

Kode Java berikut menunjukkan cara mengubah efek tema dengan memodifikasi bagian-bagian elemen:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Perubahan yang dihasilkan pada warna isian, jenis isian, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema pada tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sambil menjaga tema master tetap utuh (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidethememanager/)).

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/java/clone-slides/) bersama dengan master-nya ke dalam presentasi target. Ini mempertahankan master asli, tata letak, dan tema yang terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "effective" setelah semua pewarisan dan penimpaan?**

Gunakan ["effective" views](/slides/id/java/shape-effective-properties/) API untuk tema/warna/font/efek. Ini mengembalikan properti akhir yang telah diselesaikan setelah menerapkan master ditambah penimpaan lokal apa pun.