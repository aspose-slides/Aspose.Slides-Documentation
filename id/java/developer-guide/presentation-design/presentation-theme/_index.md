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
- Presentasi
- Java
- Aspose.Slides
description: "Kelola tema presentasi utama dalam Aspose.Slides untuk Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan sekumpulan warna, font, gaya latar belakang, isian, garis, dan efek yang terkoordinasi. Objek yang sadar tema merujuk ke definisi bersama ini alih‑alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Sebuah presentasi juga dapat berisi override tema pada level yang lebih rendah. Sebuah master dapat meng‑override tema presentasi melalui [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterthememanager/), sementara sebuah layout atau slide individu dapat meng‑override tema yang diwarisi melalui [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/). Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, override master, override layout, dan override slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian‑bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan override diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/) menampilkan skema warna tema, skema font, dan skema format melalui [MasterTheme.getColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/), dan [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/mastertheme/). Memeriksa koleksi‑koleksi ini sebelum mengubahnya sangat berguna ketika sebuah presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang disimpan dalam tema:

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

Jika sebuah file menggunakan banyak master, jangan mengasumsikan setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema‑efektif yang ditunjukkan nanti dalam artikel ini ketika override layout atau slide mungkin hadir.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang sadar tema dapat merujuk ke warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/). Saat Anda mengubah entri yang bersangkutan dalam [IColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorscheme/), semua objek yang masih merujuk ke warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak diubah oleh pembaruan warna tema.

Contoh end‑to‑end berikut membuat sebuah bentuk yang menggunakan `Accent4`, mengubah warna tema `Accent4` menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isian efektif:

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

Karena persegi tetap terhubung ke `Accent4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak akan memengaruhi isian tersebut lagi.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian yang lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides menampilkan transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/java/com.aspose.slides/colortransformoperation/).

![Warna tema utama dan warna lebih terang serta lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.

**2** - Varian yang lebih terang dan lebih gelap yang diproduksi dari warna tema utama.

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

Varian‑varian ini tetap berlandaskan pada warna tema. Jika `Accent4` berubah nanti, warna yang ditransformasi akan dihitung ulang dari nilai `Accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [IColorScheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorscheme/) menampilkan slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk heading dan satu set font minor untuk teks tubuh. Metode [IFontScheme.getMajor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontscheme/) dan [IFontScheme.getMinor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontscheme/) menampilkan set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn‑lt` - Font Tubuh Latin (Font Latin Minor)
* `+mj‑lt` - Font Judul Latin (Font Latin Mayor)
* `+mn‑ea` - Font Tubuh Asia Timur (Font Asia Timur Minor)
* `+mj‑ea` - Font Judul Asia Timur (Font Asia Timur Mayor)

Contoh berikut membuat satu heading yang menggunakan font Latin mayor tema dan satu baris tubuh yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

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

Heading mengikuti font mayor dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih‑alih pengidentifikasi tema tidak akan otomatis beralih ketika skema font tema berubah.

Koleksi font mayor dan minor juga dapat berisi pemetaan font untuk sistem penulisan individu, seperti Cyrillic, Arab, Jepang, Georgian, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan tersebut, lihat [Script‑Specific Theme Fonts](/slides/id/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/java/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan masalah terkait tema yang berbeda.

### **Menerapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya semua slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode tersebut melakukan operasi berikut:

1. Membuat slide master baru berdasarkan master yang dipilih.
2. Menerapkan tema eksternal ke master baru.
3. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.
4. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) yang baru dibuat.

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

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxReadException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxreadexception/). Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide‑slide yang bergantung pada master yang dipilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema yang ada. Warna, font, isian, garis, latar belakang, dan efek yang sadar tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Override pada level layout dan slide juga dapat mengambil prioritas atas nilai yang diwarisi dari master baru.

Tema dapat merujuk ke font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/java/custom-font/), atau konfigurasikan [font substitution](/slides/id/java/font-substitution/).

Ini adalah alur kerja level master langsung: metode menerima jalur file ke file `.thmx` dan tidak memerlukan pembuatan manual override tema pada level slide atau layout.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi‑Master**

Ketika master yang relevan tidak diketahui sebelumnya, peroleh dari slide perwakilan melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/) dan [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap pemanggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua seksi untuk menemukan master mereka dan menerapkan tema eksternal berbeda ke tiap grup:

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

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, klon master sumber ke presentasi target dengan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/), kemudian klon slide dengan [ISlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidecollection/) dan master yang diklon. Ini membawa master, layout‑nya, dan tema terkait bersama‑sama.

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

Ini adalah alur kerja yang disarankan ketika slide sumber harus terlihat sama di tujuan. Hanya mengklon konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipengaruhi tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan layout saat ini, inisialisasi override level slide dari tema sumber. Metode [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/), dan [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/) menyalin tiga komponen utama tema ke dalam override.

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

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus override lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/overridetheme/).

### **Menerapkan Override Tema ke Layout**

Override level layout berlaku untuk slide yang menggunakan layout tersebut, kecuali slide tertentu memiliki override sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslidethememanager/):

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

Gunakan tema master atau tingkat presentasi ketika banyak layout dan slide harus berbagi desain dasar yang sama, override layout ketika satu keluarga layout memerlukan style yang berbeda, dan override slide hanya untuk pengecualian nyata. Override level slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI‑nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.getStyleIndex](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) saat ini. Indeks gaya `0` berarti tidak ada isian bertema; nilai positif adalah referensi gaya latar belakang tema. Ini berbeda dari pengindeksan koleksi Java secara langsung, di mana `get_Item(0)` berarti item pertama yang disimpan. Jangan mengasumsikan setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

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

Hasil yang terlihat tergantung pada entri tema yang direferensikan oleh master dan pada override latar belakang di level layout atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Hindari juga meng‑hard‑code nomor gaya dari satu file dan mengasumsikan memiliki tampilan yang sama di file lain; definisi gaya tema bersifat khusus untuk masing‑masing presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/java/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah untuk isian, garis, dan gaya efek yang ditampilkan melalui [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/), dan [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/id/java/com.aspose.slides/iformatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual sesuai dengan pemformatan halus, sedang, dan intens, namun kode harus memeriksa setiap koleksi alih‑alih mengasumsikan hitungan tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Saat Anda mengakses koleksi‑koleksi ini di Java, indeks koleksi berbasis nol: `get_Item(0)` adalah gaya pertama yang disimpan dan `get_Item(2)` adalah yang ketiga. Indeks referensi gaya sebuah bentuk adalah konsep terpisah, ditampilkan melalui [IShapeStyle](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk ke gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

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

Untuk bentuk yang merujuk ke slot‑slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual tepat masih tergantung pada slot gaya mana yang dirujuk tiap bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isian, dan bayangan](presentation-design_11.png)

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu apa yang didefinisikan pada level tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan override lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/). Untuk latar belakang, gunakan [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/), dan untuk isian, gunakan [FillFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/).

Contoh berikut membaca tema efektif, latar belakang, dan isian bentuk pertama dari sebuah slide:

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

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), Anda dapat melewatkan master, layout, slide, atau override bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) hanya menugaskan ulang slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema pada satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidethememanager/) slide dan inisialisasi override temanya. Perubahan tetap lokal pada slide itu; slide lain terus mewarisi tema yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumber, klon master sumber ke destinasi dan klon slide dengan master tersebut menggunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/) serta [ISlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidecollection/). Ini menjaga master, layout, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan override?**

Gunakan [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseoverridethememanager/) untuk slide atau tema layout dan metode data‑efektif yang bersesuaian untuk objek format seperti [Background.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/background/) dan [FillFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/). API‑API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan override diterapkan.