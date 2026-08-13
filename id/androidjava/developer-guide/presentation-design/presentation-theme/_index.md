---
title: Kelola Tema Presentasi di Android
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/androidjava/presentation-theme/
keywords:
- tema PowerPoint
- tema presentasi
- tema slide
- atur tema
- ubah tema
- kelola tema
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola tema presentasi utama di Aspose.Slides untuk Android via Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Introduction**

Tema presentasi menentukan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih satu set elemen visual tertentu beserta propertinya.

Di PowerPoint, sebuah tema terdiri dari warna, [fonts](/slides/id/androidjava/powerpoint-fonts/), [background styles](/slides/id/androidjava/presentation-background/), dan efek.

![theme-constit­uents](theme-constit­uents.png)

## **Change Theme Color**

Tema PowerPoint menggunakan satu set warna tertentu untuk elemen yang berbeda pada sebuah slide. Jika Anda tidak menyukai warnanya, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai‑nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SchemeColor).

Kode Java ini menunjukkan cara mengubah warna aksen untuk sebuah tema:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Untuk lebih menunjukkan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) padanya. Kemudian kami mengubah warna dalam tema:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Warna baru diterapkan secara otomatis pada kedua elemen.

### **Set Theme Color from an Additional Palette**

Saat Anda menerapkan transformasi luminansi pada warna tema utama(1), warna‑warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1** - Warna tema utama

**2** - Warna dari palet tambahan.

Kode Java ini menunjukkan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan pada bentuk:

```java
import com.aspose.slides.*;

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

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Map `SchemeColor` to `IColorScheme` Colors**

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation.getMasterTheme().getColorScheme()` mengembalikan [IColorScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icolorscheme/), yang mengekspos warna yang bersesuaian sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai‑nilai ini merujuk pada slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanya merupakan nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office yang lebih lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sedangkan versi UI yang lebih baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Change Theme Font**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lain, Aspose.Slides menggunakan pengenal khusus ini (serupa dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Badan Latin (Minor Latin Font)
* **+mj-lt** - Font Heading Latin (Major Latin Font)
* **+mn-ea** - Font Badan Asia Timur (Minor East Asian Font)
* **+mj-ea** - Font Badan Asia Timur (Major East Asian Font)

Kode Java ini menunjukkan cara menetapkan font Latin ke elemen tema:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Kode Java ini menunjukkan cara mengubah font tema presentasi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Font di semua kotak teks akan diperbarui.

{{% alert color="info" title="TIP" %}} 
Anda mungkin ingin melihat [font PowerPoint](/slides/id/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Change Theme Background Style**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 dari 12 latar belakang tersebut yang disimpan dalam sebuah presentasi tipikal.

![todo:image_alt_text](presentation-design_8.png)

Sebagai contoh, setelah Anda menyimpan sebuah presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode Java ini untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Dengan menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme), Anda dapat menambah atau mengakses gaya latar belakang dalam tema PowerPoint.
{{% /alert %}} 

Kode Java ini menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Panduan Indeks**: 0 digunakan untuk tanpa isi. Indeks dimulai dari 1.

{{% alert color="info" title="TIP" %}} 
Anda mungkin ingin melihat [Latar Belakang PowerPoint](/slides/id/androidjava/presentation-background/).
{{% /alert %}}

## **Change Theme Effect**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap larik gaya. Larik‑larik tersebut digabungkan menjadi 3 efek ini: subtle, moderate, dan intense. Sebagai contoh, inilah hasil ketika efek diterapkan pada sebuah bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FormatScheme), Anda dapat mengubah elemen dalam tema (lebih fleksibel dibandingkan opsi di PowerPoint).

Kode Java ini menunjukkan cara mengubah efek tema dengan mengubah bagian‑bagian elemen:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Perubahan yang dihasilkan pada warna isi, jenis isi, efek bayangan, dll:

![todo:image_alt_text](presentation‑design_11.png)

## **FAQ**

### Can I apply a theme to a single slide without changing the master?

Ya. Aspose.Slides mendukung penimpaan tema pada tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide itu sementara tema master tetap tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidethememanager/)).

### What’s the safest way to carry a theme from one presentation to another?

[Clone slides](/slides/id/androidjava/clone-slides/) bersama dengan master‑nya ke presentasi target. Ini mempertahankan master, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

### How can I see the "effective" values after all inheritance and overrides?

Gunakan tampilan ["effective"](/slides/id/androidjava/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti akhir yang telah diselesaikan setelah menerapkan master plus semua penimpaan lokal.