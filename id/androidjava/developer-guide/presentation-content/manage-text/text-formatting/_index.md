---
title: Format Teks Presentasi pada Android
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/androidjava/text-formatting/
keywords:
- perataan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- jangkar bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks pada presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Ini mencakup warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Kecuali dinyatakan lain, contoh menggunakan [sample.pptx](sample.pptx). Bentuk pertama pada slide pertamanya adalah kotak teks, dan paragraf pertamanya berisi teks yang ditampilkan di bawah ini. Indeks slide dan bentuk menggunakan basis nol. Contoh yang menyorot bagian tebal menggunakan pemformatan efektif, termasuk pemformatan tebal yang diwariskan:

![Teks contoh](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Pencarian dan Penggantian Teks](/slides/id/androidjava/search-and-replace-text/).

## **Setel Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) untuk mengatur warna sorotan default bagi sebuah paragraf, atau gunakan [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) untuk bagian teks individual.

Contoh berikut mengatur sorotan abu-abu terang sebagai default untuk paragraf pertama. Warna sorotan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Set warna sorotan untuk seluruh paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah ini menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur warna sorotan untuk bagian teks.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bagian teks abu-abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) untuk menyetel perataan paragraf dalam bingkai teks. Nilainya dapat berupa centered, left-aligned, right-aligned, justified, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur perataan paragraf ke tengah.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Ratakan Font dalam Baris**

Gunakan [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) untuk meratakan vertikal bagian teks dengan ukuran font berbeda dalam satu baris. Pengaturan ini berlaku untuk seluruh paragraf dan mengontrol perataan dalam setiap barisnya.

Contoh mandiri berikut membuat empat kotak teks berlabel pada satu slide. Setiap paragraf berisi teks yang sama dengan ukuran 18, 36, dan 54 poin, dengan perataan font yang berbeda. Menggunakan Arial, menonaktifkan autofit dan wrapping, serta menjaga bingkai teks cukup besar untuk satu baris.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Perbandingan perataan Baseline, Top, Center, dan Bottom dengan ukuran font campuran](font_alignment.png)

Perataan font menggunakan metrik font, sehingga tepi visual huruf individual tidak selalu berbaris secara tepat. Contoh mencakup huruf kapital dan descender untuk menunjukkan perbedaan antara baseline dan bottom alignment. Ketersediaan font dan substitusi, karakter yang digunakan, serta perbedaan ukuran font memengaruhi hasil. Dimensi bingkai, margin, jarak baris, wrapping, dan autofit juga memengaruhi tata letak; gunakan font dan pengaturan tata letak yang sama saat membandingkan mode.

Pengaturan ini berbeda dari [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), yang mengontrol perataan horizontal paragraf, dan [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), yang menempatkan blok teks secara vertikal dalam bentuknya. Format superskrip dan subskrip melalui [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) menggeser bagian individual relatif terhadap baseline, bukan mengatur perataan font untuk baris paragraf.

## **Setel Transparansi untuk Teks**

Transparansi teks dikendalikan melalui komponen alfa warna yang ditetapkan ke [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Pada contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur warna isi teks menjadi warna transparan.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur transparansi bagian teks.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Setel Jarak Karakter untuk Teks**

Gunakan [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) untuk memperlebar atau mempersempit jarak antar karakter dalam kotak teks. Contoh menambahkan 3 poin jarak; nilai negatif mempersempit teks.

Kode Java berikut menunjukkan cara memperlebar jarak karakter dalam **seluruh paragraf**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Perluas jarak karakter.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah ini menunjukkan cara memperlebar jarak karakter dalam **bagian teks dengan font tebal**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
            portion.getPortionFormat().setSpacing(3); // Perluas jarak karakter.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat dibandingkan teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan di pengaturan PowerPoint.

Untuk membuat output yang lebih mirip dengan PowerPoint, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terkena. Setel [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ke nilai yang lebih besar daripada ukuran font sebenarnya. Contoh ini memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Ia memeriksa nama font efektif, termasuk font yang diwariskan, dan menetapkan ambang 100 poin untuk bagian yang menggunakan Roboto. Ini menonaktifkan kerning untuk bagian yang cocok dengan ukuran font di bawah 100 poin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk teks yang cocok di bawah ambang, pengaturan ini mencegah kerning dan dapat membantu menyelaraskan hasil render Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat disetel pada tingkat paragraf melalui [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) atau pada bagian individual melalui [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Contoh berikut mengatur font default paragraf pertama menjadi Times New Roman 12 poin dengan format tebal, miring, dan underline bertitik. Pemformatan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur properti font untuk paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh berikut menerapkan Times New Roman 13 poin, format miring, dan underline bertitik pada bagian yang pemformatannya efektif tebal:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur properti font untuk bagian teks.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Kontrol Normalisasi Tinggi Teks**

Gunakan [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) saat mereproduksi tipografi template atau menyelidiki perbedaan tinggi karakter. Di PowerPoint, mengaktifkan normalisasi meregangkan atau mengompres karakter individual secara vertikal sehingga mereka memiliki tinggi visual yang seragam dalam bagian teks. Ini tidak menjamin tinggi teks yang sama di font yang berbeda.

Setel properti ke [NullableBool.True atau False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) untuk secara eksplisit mengaktifkan atau menonaktifkan normalisasi. `NullableBool.NotDefined` membiarkan pengaturan lokal tidak diset sehingga bagian mewarisi nilainya, misalnya, dari [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) paragraf. Ini bukan berarti `False`. Gunakan [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) dan baca [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) untuk memperoleh nilai Boolean yang terresolusi.

Contoh mandiri berikut memerlukan **Arial** terpasang. Ia membuat dua blok teks yang berisi huruf kapital, huruf kecil, descender, dan karakter beraksen pada 54 poin. Kedua paragraf mengaktifkan normalisasi secara default. Bagian atas secara eksplisit menonaktifkannya; bagian bawah mewarisinya. Ukuran bingkai, margin, dan jarak paragraf identik, dengan wrapping dan autofit dinonaktifkan agar perbandingan konsisten. Contoh mencetak `False: false` dan `NotDefined: true`, lalu menyimpan "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah ini diekspor dari presentasi yang disimpan. Baris atas memiliki normalisasi dinonaktifkan (`False`); baris bawah mewarisi pengaturan yang diaktifkan (`NotDefined` → `True`). Pastikan Arial terpasang untuk mereproduksi tampilan ini.

![Teks Arial 54 poin dengan normalisasi dinonaktifkan di atas dan normalisasi diwariskan di bawah](text_height_normalization.png)

Normalisasi mengubah tinggi karakter tanpa mengubah nilai [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) yang ditetapkan, yang menentukan ukuran font dalam poin. [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) paragraf mengontrol jarak baris, sementara [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bingkai teks mengontrol bagaimana teks atau kontainernya menyesuaikan diri. Pengaturan ini memiliki tujuan berbeda dan dapat memengaruhi tata letak secara independen. Untuk informasi lebih lanjut tentang pemformatan paragraf dan pewarisan, lihat [Kelola Paragraf](/slides/id/androidjava/manage-paragraph/).

## **Terapkan dan Hapus Coret**

Gunakan [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) pada bagian teks untuk menampilkan koreksi, istilah yang dibatalkan, atau harga sebelumnya tanpa menghapus teks asli. Setel ke [TextStrikethroughType.Single atau Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) untuk satu atau dua garis melalui teks.

Untuk menghapus coret, gunakan [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Ini secara eksplisit menonaktifkan efek, meskipun pemformatan di sekitarnya menyatakan coret. Sebaliknya, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) membiarkan pengaturan lokal tidak terdefinisi, memungkinkan bagian mewarisi pemformatan, misalnya, dari paragraf. Ini tidak menjamin coret dihapus. Gunakan [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) untuk membaca pemformatan hasil, termasuk nilai yang diwariskan.

Contoh mandiri berikut membuat tiga perbandingan harga. Setiap paragraf memiliki bagian terpisah untuk label, harga lama, dan harga baru, sehingga hanya harga lama yang terpengaruh. Baris pertama menerapkan lalu menghapus coret; baris lainnya mempertahankan coret tunggal dan ganda. Mengubah pengaturan ini mempertahankan teks dan format lainnya, termasuk harga lama yang tebal.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Terapkan coret, lalu secara eksplisit hapus dari harga sebelumnya pertama.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya, dari atas ke bawah: tanpa coret, coret tunggal, dan coret ganda.

![Harga sebelumnya tanpa coret, dengan coret tunggal, dan dengan coret ganda](strikethrough.png)

## **Setel Rotasi Teks**

Gunakan [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) untuk menetapkan orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), yang memutar teks **90 derajat berlawanan arah jarum jam**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Setel Rotasi Kustom untuk Bingkai Teks**

Gunakan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) untuk menentukan sudut rotasi kustom bagi sebuah [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

Contoh kode di bawah ini memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi kustom teks](custom_text_rotation.png)

## **Setel Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), dan [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) untuk mengontrol jarak paragraf. Properti‑nya digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh berikut mengatur jarak dalam paragraf pertama menjadi 200 % tinggi baris (jarak ganda):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak baris dalam paragraf](line_spacing.png)

## **Kontrol Pemutusan Garis**

Aturan pemutusan garis paragraf berguna pada blok teks sempit dan presentasi yang mencampur teks Latin dan Asia Timur. Metode berikut milik [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), sehingga berlaku untuk seluruh paragraf:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) mengontrol aturan pemutusan garis Latin. Pada teks campuran, mengubahnya juga dapat mengubah tempat teks Asia Timur dan tanda baca di sekitarnya terbungkus.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) mengontrol aturan pemutusan garis Asia Timur, termasuk pembatasan karakter pada awal dan akhir baris.

Aturan ini tidak menggantikan [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), yang mengaktifkan pembungkus otomatis dalam bingkai teks. Mereka memengaruhi tata letak ketika pembungkus terjadi; mereka tidak menyisipkan karakter pemutusan baris. Pemutusan baris eksplisit memaksa baris baru dalam paragraf terlepas dari lebar yang tersedia.

Contoh mandiri berikut membuat blok teks sempit yang berisi bahasa Cina dan Latin. Ia mengatur kedua opsi pemutusan garis secara eksplisit dan menyimpan "line_breaking.pptx". Untuk bereksperimen dengan salah satu aturan, ubah nilai yang bersangkutan sambil mempertahankan pengaturan lainnya. Contoh menggunakan Arial 24 poin dan SimSun dengan lebar bingkai 160 poin serta margin horizontal bingkai teks nol. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) dipanggil dengan [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) sehingga ukuran teks dan bingkai tetap tetap.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrol Tanda Baca Menggantung**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) memungkinkan tanda baca yang memenuhi syarat menjorok melewati tepi kanan baris teks alih‑alih menempati baris berikutnya. Pengaturan ini berlaku untuk seluruh paragraf dan berbeda dari hanging indent.

Contoh mandiri berikut mengaktifkan tanda baca menggantung dalam bingkai teks selebar 100 poin dan menyimpan "hanging_punctuation.pptx". Dengan Arial 24 poin dan margin horizontal bingkai teks nol, titik akhir akhir tetap berada setelah "sentence" dan menjorok melewati tepi kanan teks. Setel properti ke [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) untuk perbandingan: dengan pengaturan ini, titik berada pada baris terpisah. Wrapping diaktifkan dan autofit dinonaktifkan agar lebar tersedia tetap tetap.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tidak setiap tanda baca dapat menggantung. [Kondisi font dan tata letak yang dijelaskan di atas](#control-line-breaking) juga berlaku untuk perbandingan ini: mengubah font, lebar tersedia, margin, atau pengaturan autofit dapat menghilangkan perbedaan visual.

## **Setel Tipe Autofit untuk Bingkai Teks**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks diperkecil, meluap, atau bentuk secara otomatis menyesuaikan dirinya. Contoh berikut mengonfigurasi bentuk untuk menyesuaikan ukurannya agar cocok dengan teks dan menyimpan hasil ke "autofit_type.pptx".

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghitung baris setelah pembungkus otomatis dan melihat bagaimana lebar teks atau bentuk mengubah hasil, lihat [Hitung Baris yang Dirender](/slides/id/androidjava/manage-paragraph/). Jumlah baris saja tidak menunjukkan apakah teks meluap dari kontainernya.

## **Setel Anchor Bingkai Teks**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) menentukan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah. Contoh berikut menambatkan teks ke bagian bawah bentuk pertama dan menyimpan hasil ke "text_anchor.pptx".

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Setel Tabulasi Teks**

Gunakan [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) dan [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) untuk mengonfigurasi tab stop dalam sebuah paragraf. Contoh berikut mengatur interval tab default menjadi 100 poin dan menambahkan tab stop rata kiri pada 30 poin. Pengaturan ini memengaruhi teks yang berisi karakter tab.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Tab paragraf](paragraph_tabs.png)

## **Setel Bahasa Proofing**

Aspose.Slides menyediakan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), yang memungkinkan Anda menetapkan bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh berikut memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama dan setidaknya satu paragraf. Ia mengganti isi paragraf pertama dengan "1。", menetapkan SimSun sebagai fontnya, dan menetapkan bahasa proofing Chinese Simplified (`zh-CN`). Hasil disimpan ke "proofing_language.pptx":

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Atur Id bahasa proofing.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Salin Metadata Bahasa**

Saat menyalin teks multibahasa dari template, pertahankan baik [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) maupun [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Contoh mandiri berikut membuat bagian sumber dengan bahasa Inggris AS sebagai bahasa utama dan Prancis sebagai bahasa alternatif, lalu menyalin teks dan pengenal ke bagian dalam presentasi baru.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Jika sumber tidak memiliki bahasa alternatif, null menghapus nilai tujuan.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk mencoba sumber tanpa bahasa alternatif, hilangkan penetapan `"fr-FR"`. Pengidentifikasi alternatif kemudian menjadi `null`, dan pernyataan salin yang sama mempertahankan ketidakhadirannya tanpa memperkenalkan nilai default, bahkan bila tujuan sebelumnya memiliki bahasa alternatif yang ditetapkan.

Pengidentifikasi ini menyimpan metadata bahasa. Mempertahankannya tidak menentukan kamus mana yang dipilih PowerPoint untuk pemeriksaan ejaan atau tata bahasa.

## **Setel Bahasa Default**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) untuk mendefinisikan bahasa default bagi teks yang dibuat saat memuat atau membuat presentasi. Contoh berikut membuat presentasi dengan bahasa teks default English (US), menambahkan kotak teks, dan mencetak `en-US` untuk bagian teks pertamanya.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan bentuk persegi panjang baru dengan teks.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Periksa bahasa bagian pertama.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Setel Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada tingkat presentasi, gunakan [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Contoh berikut menetapkan font tebal 14 poin sebagai default untuk paragraf tingkat atas dalam presentasi baru dan menyimpannya ke "default_text_style.pptx". Teks dapat mewarisi default ini kecuali pemformatan yang lebih spesifik menimpanya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Dapatkan format paragraf tingkat atas.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dengan Efek Semua Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks tampil dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) dan konversi string yang dikembalikan ke huruf kapital bila nilai tersebut `All`.

Contoh ini memerlukan "sample2.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Bagian pertama paragraf pertamanya berisi "Hello, Aspose!" dengan efek All Caps diterapkan, seperti ditunjukkan di bawah.

![Efek All Caps](all_caps_effect.png)

Contoh kode berikut menunjukkan cara mengekstrak teks dengan efek **All Caps** diterapkan:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara mengubah teks dalam tabel pada slide?**

Untuk mengubah teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Iterasi sel‑sel dan perbarui masing‑masing sel melalui [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) dan format paragraf melalui [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Setel [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ke [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) dan konfigurasikan titik‑titik gradien, arah, serta transparansi.