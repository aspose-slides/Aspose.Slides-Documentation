---
title: Kelola Tema Presentasi pada Android
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/androidjava/presentation-theme/
keywords:
- Tema PowerPoint
- Tema presentasi
- Tema slide
- Tetapkan tema
- Ubah tema
- Kelola tema
- Tema eksternal
- THMX
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
description: "Kelola tema presentasi utama di Aspose.Slides untuk Android melalui Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan penjenamaan yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan satu set terkoordinasi warna, font, gaya latar belakang, isian, garis, dan efek. Objek yang menyadari tema merujuk pada definisi bersama ini alih‑alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Presentasi juga dapat berisi penimpaan tema pada level yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/masterthememanager/), sementara tata letak atau slide individual dapat menimpa tema yang diwarisi melalui [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseoverridethememanager/). Secara praktis, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Periksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mastertheme/) mengekspos skema warna tema, skema font, dan skema format melalui [MasterTheme.getColorScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mastertheme/), dan [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mastertheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika sebuah presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang disimpan dalam tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Jika sebuah file menggunakan beberapa master, jangan berasumsi bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema‑efektif yang ditunjukkan later dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Ubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersesuaian dalam [IColorScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icolorscheme/), semua objek yang masih merujuk pada warna tema itu diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak berubah oleh pembaruan warna tema.

Contoh end‑to‑end berikut membuat sebuah bentuk yang menggunakan `Accent4`, mengubah warna `Accent4` tema menjadi merah, menyimpan presentasi, membuka kembali, dan mencetak warna isian efektif:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Karena persegi panjang tetap terhubung ke `Accent4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak lagi memengaruhi isian tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/colortransformoperation/).

![Warna tema utama dan warna lebih terang serta lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.

**2** - Varian lebih terang dan lebih gelap yang diproduksi dari warna tema utama.

Contoh berikut membuat enam persegi panjang berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

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

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah nanti, warna yang ditransformasikan dihitung ulang dari nilai `Accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [IColorScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icolorscheme/) mengekspos slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Ubah Font Tema**

Skema font tema berisi satu set font utama untuk heading dan satu set font minor untuk teks tubuh. Metode [IFontScheme.getMajor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontscheme/) dan [IFontScheme.getMinor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontscheme/) mengekspos set tersebut.

Identifier font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn‑lt` - Font Tubuh Latin (Minor Latin Font)
* `+mj‑lt` - Font Heading Latin (Major Latin Font)
* `+mn‑ea` - Font Tubuh Asia Timur (Minor East Asian Font)
* `+mj‑ea` - Font Heading Asia Timur (Major East Asian Font)

Contoh berikut membuat satu heading yang menggunakan font tema Latin mayor dan satu baris tubuh yang menggunakan font tema Latin minor. Kemudian mengubah font tema dan menyimpan hasilnya:

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

Heading mengikuti font mayor dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih‑alih identifier tema tidak akan otomatis berganti ketika skema font tema berubah.

Koleksi font mayor dan minor juga dapat berisi pemetaan font untuk sistem penulisan individual, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Salin atau Terapkan Tema**

Alur kerja di bawah ini menyelesaikan berbagai masalah terkait tema.

### **Terapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin menata ulang setiap slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat slide master baru berdasarkan master yang dipilih.
1. Menerapkan tema eksternal ke master baru.
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.
1. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) yang baru dibuat.

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

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxReadException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxreadexception/). Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master yang dipilih yang akan dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar belakang, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan tingkat tata letak dan tingkat slide juga dapat mengambil prioritas atas nilai yang diwarisi dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/androidjava/custom-font/), atau konfigurasikan [font substitution](/slides/id/androidjava/font-substitution/).

Ini merupakan alur kerja tingkat master langsung: metode menerima jalur file `.thmx` dan tidak memerlukan pembuatan manual penimpaan tema tingkat slide atau tata letak.

### **Terapkan Tema Eksternal Berbeda dalam Presentasi Multi‑Master**

Ketika master yang relevan tidak diketahui sebelumnya, dapatkan dari slide representatif melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/) dan [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap panggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke setiap grup:

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

Panggilan pertama memengaruhi hanya slide yang bergantung pada `firstGroupMaster`, dan panggilan kedua memengaruhi hanya slide yang bergantung pada `secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gayanya.

### **Pertahankan Tema Sumber saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke presentasi target dengan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/), lalu kloning slide dengan [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/) dan master yang dikloning. Ini membawa master, tata letaknya, dan tema terkait bersama‑sama.

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

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Sekadar mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang digerakkan tema.

### **Terapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap berada pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/overridetheme/), dan [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/overridetheme/) menyalin tiga komponen tema utama ke penimpaan.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/overridetheme/).

### **Terapkan Penimpaan Tema ke Tata Letak**

Penimpaan tingkat tata letak berlaku untuk slide yang menggunakan tata letak tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Gunakan tema tingkat master atau presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak memerlukan gaya berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari lebih sulit diprediksi.

## **Perbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iformatscheme/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI-nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.getStyleIndex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/background/) saat ini. Indeks gaya `0` berarti tidak ada isian ber‑tema; nilai positif merupakan referensi gaya latar belakang tema. Ini berbeda dari pengindeksan koleksi Java secara langsung, dimana `get_Item(0)` berarti item pertama yang disimpan. Jangan berasumsi bahwa setiap presentasi berisi jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang ber‑tema ke master pertama, dan menyimpan presentasi:

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

Hasil yang terlihat tergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat tata letak atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/background/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Hindari juga meng‑hard‑code nomor gaya dari satu file dan mengasumsikan tampilannya sama di file lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk format latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/androidjava/presentation-background/).
{{% /alert %}}

## **Perbarui Efek Tema**

Skema format tema berisi koleksi isian, garis, dan efek terpisah yang diekspos melalui [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iformatscheme/), dan [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iformatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa masing‑masing koleksi alih‑alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens diterapkan pada bentuk yang sama](presentation-design_10.png)

Ketika Anda mengakses koleksi ini di Java, indeks koleksi berbasis nol: `get_Item(0)` adalah gaya pertama yang disimpan dan `get_Item(2)` adalah gaya ketiga. Indeks referensi gaya sebuah bentuk adalah konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk pada gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa bahwa entri gaya yang diperlukan ada, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk bentuk yang merujuk slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan padat, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual pasti tetap tergantung pada slot gaya mana yang dirujuk setiap bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isian, dan bayangan](presentation-design_11.png)

## **Baca Nilai Tema Efektif**

Objek tema mentah memberi tahu Anda apa yang didefinisikan pada level tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseoverridethememanager/). Untuk latar belakang, gunakan [Background.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/background/), dan untuk isian, gunakan [FillFormat.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fillformat/).

Contoh berikut membaca tema efektif, latar belakang, dan isian bentuk pertama dari sebuah slide:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), Anda dapat melewatkan penimpaan master, tata letak, slide, atau bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) hanya menugaskan ulang slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidethememanager/) slide dan inisialisasi tema penimpaannya. Perubahan tetap lokal untuk slide itu; slide lain terus mewarisi tema mereka yang ada.

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

Ketika memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master tersebut menggunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/) serta [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/). Ini menjaga master, tata letak, dan tema bersama‑sama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseoverridethememanager/) untuk slide atau tema tata letak dan metode data‑efektif yang bersangkutan untuk objek format seperti [Background.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/background/) dan [FillFormat.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fillformat/). API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.