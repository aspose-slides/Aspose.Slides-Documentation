---
title: Kelola Tema Presentasi di Java
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/java/presentation-theme/
keywords:
- tema PowerPoint
- tema presentasi
- tema slide
- atur tema
- ubah tema
- kelola tema
- tema eksternal
- THMX
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola tema presentasi master di Aspose.Slides untuk Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan branding yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan satu set warna, font, gaya latar, isian, garis, dan efek yang terkoordinasi. Objek yang menyadari tema mengacu pada definisi bersama ini alih‑alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Sebuah presentasi juga dapat berisi penimpaan tema pada tingkat yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterthememanager/), sementara tata letak atau slide individu dapat menimpa tema yang diwariskan melalui [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/). Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar, dan efek](theme-constituents.png)

Bagian‑bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/) mengekspos skema warna, skema font, dan skema format tema melalui [MasterTheme.getColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/), dan [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti utama tema dan melaporkan berapa banyak gaya latar, isian, garis, dan efek yang disimpan dalam tema:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Jika sebuah file menggunakan beberapa master, jangan menganggap setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema‑efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk ke warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersesuaian dalam [IColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorscheme/), semua objek yang masih merujuk ke warna tema tersebut diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak diubah oleh pembaruan warna tema.

Contoh end‑to‑end berikut membuat bentuk yang menggunakan `Accent4`, mengubah warna `Accent4` tema menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isian efektif:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Karena persegi tetap terhubung ke `Accent4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak lagi memengaruhi isian tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/java/com.aspose.slides/colortransformoperation/).

![Warna tema utama serta warna lebih terang dan lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.  
**2** - Varian lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah kemudian, warna yang ditransformasikan dihitung ulang dari nilai `Accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sedangkan [IColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorscheme/) menampilkan slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis antara satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk heading dan satu set font minor untuk teks badan. Metode [IFontScheme.getMajor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontscheme/) dan [IFontScheme.getMinor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontscheme/) mengekspos set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Badan Latin (Minor Latin Font)
* `+mj-lt` - Font Heading Latin (Major Latin Font)
* `+mn-ea` - Font Badan Asia Timur (Minor East Asian Font)
* `+mj-ea` - Font Heading Asia Timur (Major East Asian Font)

Contoh berikut membuat satu heading yang menggunakan font Latin utama tema dan satu baris badan yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Heading mengikuti font utama dan teks badan mengikuti font minor. Teks yang memiliki nama font eksplisit alih‑alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font utama dan minor juga dapat berisi pemetaan font untuk sistem penulisan individu, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan tersebut, lihat [Script-Specific Theme Fonts](/slides/id/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/java/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan masalah tema yang berbeda.

### **Menerapkan Tema Eksternal ke Slide‑Slide yang Bergantung pada Master**

Gunakan [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya setiap slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/), lalu berikan jalur file tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master yang dipilih.  
1. Menerapkan tema eksternal ke master baru.  
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master terpilih.  
1. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide yang bergantung pada master pertama dan menyimpan presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxReadException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxreadexception/). Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem berkas, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master terpilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan pada tingkat tata letak dan slide juga dapat memiliki prioritas atas nilai yang diwariskan dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/java/custom-font/), atau konfigurasikan [font substitution](/slides/id/java/font-substitution/).

Ini adalah alur kerja tingkat master langsung: metode menerima jalur file `.thmx` dan tidak memerlukan pembuatan penimpaan tema pada tingkat slide atau tata letak secara manual.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi‑Master**

Ketika master yang relevan tidak diketahui sebelumnya, peroleh dari slide perwakilan melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/) dan [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap pemanggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke masing‑masing grup:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Pemanggilan pertama memengaruhi hanya slide yang bergantung pada `firstGroupMaster`, dan pemanggilan kedua memengaruhi hanya slide yang bergantung pada `secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gayanya.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke presentasi target dengan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/), lalu kloning slide dengan [ISlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidecollection/) dan master yang dikloning. Ini membawa master, tata letaknya, dan tema terkait bersama‑sama.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Hanya mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar, dan efek yang dipicu tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/), dan [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/) menyalin tiga komponen tema utama ke dalam penimpaan.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ini mengubah tema yang digunakan slide tersebut tanpa mengubah tema yang diwariskan oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwariskan, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/).

### **Menerapkan Penimpaan Tema ke Tata Letak**

Penimpaan tingkat tata letak berlaku untuk slide yang menggunakan tata letak tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Gunakan tema tingkat master atau presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak memerlukan gaya berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi sulit diprediksi.

## **Memperbarui Gaya Latar Tema**

Isian latar tema disimpan dalam [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/). PowerPoint dapat menampilkan pilihan latar lebih banyak di UI‑nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lain.

![Galeri gaya latar PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar, periksa koleksi yang disimpan dan [Background.getStyleIndex](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) saat ini. Indeks gaya `0` berarti tidak ada isian bertema; nilai positif adalah referensi gaya latar tema. Ini berbeda dari mengindeks koleksi Java secara langsung, di mana `get_Item(0)` berarti item pertama yang disimpan. Jangan menganggap setiap presentasi memiliki jumlah gaya isian latar yang sama.

Contoh berikut melaporkan jumlah isian latar yang tersedia, menetapkan referensi latar bertema ke master pertama, dan menyimpan presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil yang terlihat tergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar di tingkat tata letak atau slide. Jika sebuah slide menggunakan latar sendiri, mengubah hanya latar master mungkin tidak mengubah slide tersebut. Gunakan [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) ketika Anda perlu mengetahui latar akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Peringatan" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Hindari juga meng‑hard‑code nomor gaya dari satu berkas dan mengasumsikan tampilannya sama pada berkas lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar langsung dan pewarisan latar, lihat [Presentation Background](/slides/id/java/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah untuk isian, garis, dan efek yang diekspos melalui [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/), dan [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih‑alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Ketika Anda mengakses koleksi ini di Java, indeks koleksi berbasis nol: `get_Item(0)` adalah gaya pertama yang disimpan dan `get_Item(2)` adalah yang ketiga. Indeks referensi gaya pada sebuah bentuk adalah konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk gaya tema tersebut; bentuk dengan format langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa keberadaan entri gaya yang diperlukan, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk bentuk yang merujuk slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan padat, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual akhir tetap tergantung pada slot gaya yang dirujuk masing‑masing bentuk serta apakah format langsung menimpa tema.

![Gaya efek tema setelah mengubah garis, isian, dan pengaturan bayangan](presentation-design_11.png)

## **Menentukan Apakah Isian Padat Efektif Menggunakan Warna Tema**

Sebuah isian dapat disimpan langsung pada objek atau diwariskan dari paragraf, tata letak, master, gaya tema, atau tingkat pemformatan lain. Panggil [IFillFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifillformat/) untuk menyelesaikan hierarki tersebut menjadi [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifillformateffectivedata/) yang tidak dapat diubah. Pertama periksa [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifillformateffectivedata/). Hanya ketika nilai tersebut `FillType.Solid` Anda harus membaca properti isian padat.

Untuk isian padat, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifillformateffectivedata/) mengembalikan nilai RGB akhir setelah pewarisan, pencarian tema, dan transformasi warna diterapkan. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifillformateffectivedata/) mengembalikan slot logis [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/) yang bersesuaian, seperti `Text1` atau `Accent6`. Nilai `SchemeColor.NotDefined` berarti isian padat efektif tidak didasarkan pada warna skema. Dalam alur kerja di mana isian hanya berupa warna tema atau warna RGB langsung, nilai ini mengidentifikasi isian RGB langsung.

Jangan hanya menggunakan nilai lokal [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorformat/) untuk mengklasifikasikan isian. Misalnya, sebagian teks dapat tidak memiliki warna skema yang didefinisikan secara lokal, sehingga nilainya `NotDefined`, padahal isian efektifnya mewarisi warna tema dan ter‑resolve ke `Text1` atau `Accent6`. Sebaliknya, `getSolidFillSchemeColor` memberi tahu slot tema logis yang menghasilkan warna efektif, tetapi tidak memberi tahu apakah slot tersebut berasal dari objek, paragraf, tata letak, master, atau tingkat hierarki lain.

Contoh berikut memuat presentasi, memeriksa isian bentuk serta isian bagian teks, mencetak setiap nilai RGB akhir dan warna skema yang terkait, serta menandai isian padat yang tidak akan melacak perubahan warna tema:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cabang `NotDefined` menyediakan daftar audit isian padat yang tidak akan merespon perubahan slot warna tema. Tinjau objek‑objek ini ketika sebuah presentasi harus mengikuti palet merek baru. Nilai RGB yang dilaporkan masih menunjukkan tampilan saat ini, sementara nilai skema menjelaskan apakah tampilan tersebut terhubung ke tema.

Objek format‑efektif adalah snapshot. Setelah mengubah tema presentasi, penimpaan tema, atau format yang diwariskan, panggil `getEffective` lagi dan baca objek `IFillFormatEffectiveData` yang baru sebelum membandingkan atau melaporkan warna.

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu apa yang didefinisikan pada tingkat tertentu. Nilai efektif memberi tahu apa yang sebenarnya dipakai slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/). Untuk latar, gunakan [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/), dan untuk isian, gunakan [FillFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/).

Contoh berikut membaca tema efektif, latar, dan isian bentuk pertama dari sebuah slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), Anda dapat melewatkan penimpaan master, tata letak, slide, atau bentuk yang mengubah penampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) hanya menugaskan ulang slide yang bergantung pada master terpilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidethememanager/) slide tersebut dan inisialisasi tema penimpaanannya. Perubahan tetap lokal pada slide itu; slide lain tetap mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master tersebut menggunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/) serta [ISlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidecollection/). Ini menjaga master, tata letak, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/) untuk tema slide atau tata letak serta metode data‑efektif yang bersesuaian untuk objek format seperti [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) dan [FillFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/). API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.