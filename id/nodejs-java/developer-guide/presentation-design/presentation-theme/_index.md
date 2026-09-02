---
title: Kelola Tema Presentasi dalam JavaScript
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/nodejs-java/presentation-theme/
keywords:
- Tema PowerPoint
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai tema presentasi dalam JavaScript dengan Aspose.Slides untuk Node.js untuk membuat, menyesuaikan, dan mengubah format file PowerPoint dengan merek yang konsisten."
---
## **Pengantar**

Tema presentasi mendefinisikan sekumpulan warna, font, gaya latar belakang, isian, garis, dan efek yang terkoordinasi. Objek yang menyadari tema merujuk ke definisi bersama ini alih‑alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getmastertheme/). Sebuah presentasi juga dapat berisi penimpaan tema pada tingkat yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterthememanager/), sementara layout atau slide individu dapat menimpa tema yang diwariskan melalui [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseoverridethememanager/). Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan layout, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian‑bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mastertheme/) mengekspos skema warna tema, skema font, dan skema format melalui [MasterTheme.getColorScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mastertheme/), dan [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mastertheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti utama tema dan melaporkan berapa banyak gaya latar belakang, isian, garis, serta efek yang disimpan dalam tema:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Jika sebuah file menggunakan banyak master, jangan mengasumsikan setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema‑efektif yang ditunjukkan kemudian dalam artikel ini ketika penimpaan layout atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk ke warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersangkutan dalam [ColorScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colorscheme/), semua objek yang masih merujuk ke warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak akan berubah oleh pembaruan warna tema.

Contoh end‑to‑end berikut membuat sebuah bentuk yang menggunakan `Accent4`, mengubah warna tema `Accent4` menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isian efektif:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Karena persegi panjang tetap terhubung ke `Accent4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak akan memengaruhi isian tersebut lagi.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colortransformoperation/).

![Warna utama tema serta warna lebih terang dan lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** – Warna utama tema.  
**2** – Varian lebih terang dan lebih gelap yang dihasilkan dari warna utama tema.

Contoh berikut membuat enam persegi panjang berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Varian‑varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah nanti, warna yang telah ditransformasi akan dihitung ulang dari nilai `Accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `ColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [ColorScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colorscheme/) mengekspos slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk judul dan satu set font minor untuk teks tubuh. Metode [FontScheme.getMajor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontscheme/) dan [FontScheme.getMinor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontscheme/) mengekspos set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn‑lt` – Font Tubuh Latin (Minor Latin Font)
* `+mj‑lt` – Font Judul Latin (Major Latin Font)
* `+mn‑ea` – Font Tubuh Asia Timur (Minor East Asian Font)
* `+mj‑ea` – Font Judul Asia Timur (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font tema Latin major dan satu baris tubuh yang menggunakan font tema Latin minor. Kemudian mengubah font tema dan menyimpan hasilnya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Judul mengikuti font major dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih‑alih pengidentifikasi tema tidak akan beralih otomatis ketika skema font tema berubah.

Koleksi font major dan minor juga dapat berisi pemetaan font untuk sistem penulisan individual, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script‑Specific Theme Fonts](/slides/id/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan masalah tema yang berbeda.

### **Menerapkan Tema Eksternal ke Slide‑Slide yang Bergantung pada Master**

Gunakan [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin menata ulang setiap slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang direpresentasikan oleh [MasterSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master yang dipilih.  
1. Menerapkan tema eksternal ke master baru.  
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.  
1. Mengembalikan [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide‑slide yang bergantung pada master pertama dan menyimpan presentasi:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tema yang tidak valid, rusak, atau tidak didukung dapat memicu [PptxReadException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxreadexception/). Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem berkas, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide‑slide yang bergantung pada master terpilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar belakang, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan pada tingkat layout dan slide juga dapat mengambil prioritas atas nilai yang diwariskan dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk memastikan rendering dan ekspor konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/nodejs-java/custom-font/), atau konfigurasikan [font substitution](/slides/id/nodejs-java/font-substitution/).

Ini adalah alur kerja tingkat master langsung: metode menerima jalur file `.thmx` dan tidak memerlukan pembuatan penimpaan tema secara manual pada tingkat slide atau layout.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi‑Master**

Ketika master yang relevan tidak diketahui sebelumnya, peroleh master tersebut dari slide perwakilan melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/) dan [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap pemanggilan menciptakan master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke setiap grup:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Pemanggilan pertama memengaruhi hanya slide yang bergantung pada `firstGroupMaster`, dan pemanggilan kedua memengaruhi hanya slide yang bergantung pada `secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gaya.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke dalam presentasi target dengan [MasterSlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslidecollection/), kemudian kloning slide dengan [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/) dan master yang dikloning. Ini membawa master, layout‑nya, dan tema yang terkait bersamaan.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Menyalin konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang digerakkan oleh tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan layout saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/overridetheme/), dan [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/overridetheme/) menyalin tiga komponen tema utama ke dalam penimpaan.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwariskan oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwariskan, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/overridetheme/).

### **Menerapkan Penimpaan Tema ke Layout**

Penimpaan tingkat layout berlaku untuk slide yang menggunakan layout tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Gunakan tema tingkat master atau presentasi ketika banyak layout dan slide harus berbagi desain dasar yang sama, penimpaan layout ketika satu keluarga layout memerlukan styling berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/formatscheme/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI‑nya daripada jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan nilai [Background.getStyleIndex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/background/). Indeks gaya `0` berarti tidak ada isian bertema; nilai positif merupakan referensi gaya latar belakang tema. Ini berbeda dari pengindeksan koleksi JavaScript secara langsung, di mana indeks `0` berarti item pertama yang disimpan. Jangan mengasumsikan setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil yang terlihat bergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat layout atau slide. Jika slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/background/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Hindari juga mengodekan nomor gaya dari satu file dan mengasumsikan tampilannya sama di file lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/nodejs-java/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi isian, garis, dan efek yang terpisah yang diekspos melalui [FormatScheme.getFillStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/formatscheme/), dan [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/formatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih‑alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens diterapkan pada bentuk yang sama](presentation-design_10.png)

Saat Anda mengakses koleksi ini dalam JavaScript, indeks koleksi berbasis nol: indeks `0` adalah gaya pertama yang disimpan dan indeks `2` adalah gaya ketiga. Indeks referensi gaya sebuah bentuk adalah konsep terpisah, diekspos melalui [ShapeStyle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk ke gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa keberadaan entri gaya yang diperlukan, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk bentuk yang merujuk ke slot‑slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual tepatnya tetap bergantung pada slot gaya mana yang dirujuk tiap bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isian, dan bayangan](presentation-design_11.png)

## **Menentukan Apakah Isian Padat Efektif Menggunakan Warna Tema**

Isian dapat disimpan langsung pada objek atau diwariskan dari paragraf, layout, master, gaya tema, atau tingkat pemformatan lain. Panggil [FillFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) untuk menyelesaikan hirarki tersebut menjadi snapshot isian‑padat yang tidak dapat diubah. Pertama periksa nilai `getFillType`‑nya. Hanya ketika nilainya `FillType.Solid` Anda harus membaca properti isian‑padat.

Untuk isian padat, `getSolidFillColor` mengembalikan nilai RGB akhir yang dirender setelah pewarisan, pencarian tema, dan transformasi warna diterapkan. Metode `getSolidFillSchemeColor` mengembalikan slot logis [SchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/schemecolor/) yang bersangkutan, seperti `Text1` atau `Accent6`. Nilai `SchemeColor.NotDefined` berarti isian padat efektif tidak didasarkan pada warna skema. Dalam alur kerja di mana isian berupa warna tema atau warna RGB langsung, nilai ini menandai isian RGB langsung.

Jangan gunakan nilai lokal [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colorformat/) saja untuk mengklasifikasikan isian. Misalnya, sebuah bagian teks dapat tidak memiliki warna skema yang didefinisikan secara lokal, sehingga nilainya `NotDefined`, sementara isian efektifnya mewarisi warna tema dan menyelesaikan ke `Text1` atau `Accent6`. Sebaliknya, `getSolidFillSchemeColor` memberi tahu Anda slot tema logis mana yang menghasilkan warna efektif, tetapi tidak memberi tahu Anda apakah slot tersebut berasal dari objek, paragraf, layout, master, atau tingkat lain dalam hierarki pemformatan.

Contoh berikut memuat presentasi, mengaudit isian bentuk serta isian bagian teks, mencetak setiap nilai RGB akhir dan skema warna yang terkait, serta menandai isian padat yang tidak akan melacak perubahan warna tema:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cabang `NotDefined` menyediakan daftar audit isian padat yang tidak akan merespons perubahan slot warna tema. Tinjau objek‑objek ini ketika sebuah presentasi harus mengikuti palet merek baru. Nilai RGB yang dilaporkan tetap menampilkan tampilan saat ini, sementara nilai skema menjelaskan apakah tampilan tersebut terhubung ke tema.

Objek format‑efektif adalah snapshot. Setelah mengubah tema presentasi, penimpaan tema, atau pemformatan yang diwariskan, panggil `getEffective` lagi dan baca objek isian‑padat baru sebelum membandingkan atau melaporkan warna.

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu Anda apa yang didefinisikan pada tingkat tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseoverridethememanager/). Untuk latar belakang, gunakan [Background.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/background/), dan untuk isian, gunakan [FillFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/).

Contoh berikut membaca tema efektif, latar belakang, dan isian bentuk pertama dari sebuah slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getmastertheme/), Anda dapat melewatkan master, layout, slide, atau penimpaan bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) hanya menugaskan ulang slide‑slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema mereka yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidethememanager/) slide tersebut dan inisialisasi tema penimpaan. Perubahan tetap lokal pada slide itu; slide lain terus mewarisi tema mereka yang ada.

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master itu menggunakan [MasterSlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslidecollection/) serta [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/). Ini menjaga master, layout, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseoverridethememanager/) untuk slide atau tema layout dan metode data‑efektif yang bersesuaian untuk objek format seperti [Background.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/background/) dan [FillFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/). API‑API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.