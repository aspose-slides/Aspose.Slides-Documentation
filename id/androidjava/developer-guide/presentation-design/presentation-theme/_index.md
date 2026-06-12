---
title: Kelola Tema Presentasi di Android
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/androidjava/presentation-theme/
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
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola tema presentasi utama di Aspose.Slides untuk Android via Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih sekumpulan elemen visual tertentu beserta propertinya.

Di PowerPoint, tema terdiri dari warna, [font](/slides/id/androidjava/powerpoint-fonts/), [gaya latar belakang](/slides/id/androidjava/presentation-background/), dan efek.

![unsur tema](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan sekumpulan warna tertentu untuk elemen yang berbeda pada sebuah slide. Jika Anda tidak menyukai warnanya, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SchemeColor).

Kode Java ini menunjukkan cara mengubah warna aksen untuk sebuah tema:

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

Untuk lebih mendemonstrasikan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) kepadanya. Kemudian kami mengubah warna dalam tema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Warna baru diterapkan secara otomatis pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Saat Anda menerapkan transformasi luminansi pada warna tema utama(1), warna-warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna tema tersebut.

![warna palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama  

**2** - Warna dari palet tambahan.

Kode Java ini mendemonstrasikan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan dalam bentuk:

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

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation.getMasterTheme().getColorScheme()` mengembalikan [IColorScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icolorscheme/), yang menampilkan warna yang bersesuaian sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai tersebut merujuk pada slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanya nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office yang lebih lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI yang lebih baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lain, Aspose.Slides menggunakan pengenal khusus ini (serupa dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Tubuh Latin (Minor Latin Font)
* **+mj-lt** - Font Judul Latin (Major Latin Font)
* **+mn-ea** - Font Tubuh Asia Timur (Minor East Asian Font)
* **+mj-ea** - Font Tubuh Asia Timur (Major East Asian Font)

Kode Java ini menunjukkan cara menetapkan font Latin ke elemen tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Kode Java ini menunjukkan cara mengubah font tema presentasi:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Font di semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [font PowerPoint](/slides/id/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 dari 12 latar belakang tersebut yang disimpan dalam presentasi tipikal.

![todo:image_alt_text](presentation-design_8.png)

Sebagai contoh, setelah Anda menyimpan sebuah presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode Java ini untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

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
Dengan menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme), Anda dapat menambahkan atau mengakses gaya latar belakang dalam tema PowerPoint.
{{% /alert %}} 

Kode Java ini menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Panduan indeks**: 0 digunakan untuk tanpa isi. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [Latar Belakang PowerPoint](/slides/id/androidjava/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap array gaya. Array‑array tersebut digabung menjadi 3 efek: halus, sedang, dan intens. Sebagai contoh, inilah hasil ketika efek‑efek tersebut diterapkan pada sebuah bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme) Anda dapat mengubah elemen dalam tema (bahkan lebih fleksibel daripada opsi di PowerPoint).

Kode Java ini menunjukkan cara mengubah efek tema dengan memodifikasi bagian‑bagian elemen:

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

Perubahan yang dihasilkan pada warna isi, tipe isi, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **Tanya Jawab**

**Apakah saya dapat menerapkan tema pada satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema pada tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sementara tema master tetap tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidethememanager/)).

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/androidjava/clone-slides/) bersama master‑nya ke dalam presentasi target. Ini mempertahankan master asli, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "efektif" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan ["effective"](/slides/id/androidjava/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti akhir yang telah diselesaikan setelah menerapkan master serta segala penimpaan lokal.