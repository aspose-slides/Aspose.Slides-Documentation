---
title: Format Teks Presentasi dalam Java
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/java/text-formatting/
keywords:
- perataan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- famili font
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
- Java
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java. Artikel ini mencakup warna latar belakang, transparansi, jarak antar karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab, dan pengaturan bahasa.

Kecuali dinyatakan lain, contoh menggunakan [sample.pptx](sample.pptx). Bentuk pertama pada slide pertama adalah kotak teks, dan paragraf pertamanya berisi teks yang ditunjukkan di bawah. Indeks slide dan bentuk menggunakan basis nol. Contoh yang memilih bagian tebal menggunakan pemformatan efektif, termasuk pemformatan tebal yang diwariskan:

![Teks contoh](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Cari dan Ganti Teks](/slides/id/java/search-and-replace-text/).

## **Atur Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) untuk mengatur warna sorotan default untuk sebuah paragraf, atau gunakan [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) untuk bagian teks individual.

Contoh berikut mengatur sorotan abu-abu terang sebagai default untuk paragraf pertama. Warna sorotan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur warna sorotan untuk seluruh paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur warna sorotan untuk bagian teks.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
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

Gunakan [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) untuk mengatur perataan paragraf dalam bingkai teks. Nilainya dapat berupa centered, left-aligned, right-aligned, justified, dan sebagainya.

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

Gunakan [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) untuk meratakan secara vertikal bagian teks dengan ukuran font berbeda dalam satu baris. Pengaturan ini berlaku untuk seluruh paragraf dan mengontrol perataan dalam setiap barisnya.

Contoh berikut yang berdiri sendiri membuat empat kotak teks berlabel pada satu slide. Setiap paragraf berisi teks yang sama dengan ukuran 18, 36, dan 54 poin, dengan perataan font yang berbeda. Contoh ini menggunakan Arial, menonaktifkan autofit dan pembungkus, serta menjaga bingkai teks cukup besar untuk satu baris.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Perbandingan perataan Font Baseline, Top, Center, dan Bottom dengan ukuran font campuran](font_alignment.png)

Perataan font menggunakan metrik font, sehingga tepi yang terlihat dari masing‑masing huruf tidak selalu berbaris secara tepat. Contoh ini mencakup huruf kapital dan descender untuk memperlihatkan perbedaan antara perataan baseline dan bottom. Ketersediaan font, substitusi, karakter yang dipakai, dan perbedaan ukuran font memengaruhi hasil. Dimensi bingkai, margin, jarak baris, pembungkus, dan autofit juga memengaruhi tata letak; gunakan font dan pengaturan tata letak yang sama saat membandingkan mode.

Pengaturan ini berbeda dari [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), yang mengontrol perataan horizontal paragraf, dan [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), yang menempatkan blok teks secara vertikal di dalam bentuknya. Pemformatan superskrip dan subskrip melalui [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) menggeser bagian individual relatif terhadap baseline alih-alih mengatur perataan font untuk baris‑baris paragraf.

## **Atur Transparansi untuk Teks**

Transparansi teks dikendalikan melalui komponen alfa dari warna yang ditetapkan pada [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Pada contoh di bawah, `alpha = 50` adalah nilai channel alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode di bawah menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur warna isi teks menjadi warna transparan.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Atur Jarak Karakter untuk Teks**

Gunakan [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) untuk memperlebar atau mempersempit jarak antar karakter dalam kotak teks. Contoh menambahkan 3 poin jarak; nilai negatif memperkecil jarak teks.

Kode Java berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

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

Contoh kode di bawah menunjukkan cara memperluas jarak karakter dalam **bagian teks dengan font tebal**:

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

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat dibandingkan teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat hasil render lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terpengaruh. Atur [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ke nilai yang lebih besar daripada ukuran font sebenarnya. Contoh ini memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Ia memeriksa nama font efektif, termasuk font yang diwarisi, dan menetapkan ambang 100 poin untuk bagian yang menggunakan Roboto. Ini menonaktifkan kerning untuk bagian yang cocok dengan ukuran font di bawah 100 poin:

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

Properti font dapat diatur pada tingkat paragraf melalui [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) atau pada bagian individual melalui [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Contoh berikut mengatur font default paragraf pertama menjadi Times New Roman 12 poin dengan format tebal, miring, dan garis bawah bertitik. Pemformatan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini:

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

Contoh berikut menerapkan Times New Roman 13 poin, format miring, dan garis bawah bertitik pada bagian yang pemformatannya efektif adalah tebal:

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

Gunakan [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) saat mereproduksi tipografi template atau menyelidiki perbedaan tinggi karakter. Di PowerPoint, mengaktifkan normalisasi meregangkan atau memampatkan karakter individual secara vertikal sehingga mereka memiliki tinggi tampilan yang seragam dalam bagian teks. Ini tidak menjamin tinggi teks yang sama antar font yang berbeda.

Atur properti ke [NullableBool.True or False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) untuk secara eksplisit mengaktifkan atau menonaktifkan normalisasi. `NullableBool.NotDefined` membiarkan pengaturan lokal tidak ditetapkan sehingga bagian mewarisi nilainya, misalnya dari [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) paragraf. Ini tidak berarti `False`. Gunakan [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) dan baca [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) untuk memperoleh nilai Boolean yang telah diselesaikan.

Contoh berdiri sendiri berikut memerlukan **Arial** terpasang. Ia membuat dua blok teks yang berisi huruf kapital, huruf kecil, descender, dan karakter beraksen yang sama pada 54 poin. Kedua paragraf mengaktifkan normalisasi secara default. Bagian atas secara eksplisit menonaktifkannya; bagian bawah mewarisinya. Ukuran bingkai, margin, dan jarak paragraf identik, dengan pembungkus dan autofit dinonaktifkan agar perbandingan konsisten. Contoh mencetak `False: false` dan `NotDefined: true`, lalu menyimpan "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Perbandingan di bawah diekspor dari presentasi yang disimpan. Baris atas memiliki normalisasi dinonaktifkan (`False`); baris bawah mewarisi pengaturan yang diaktifkan (`NotDefined` → `True`). Pastikan Arial terpasang untuk mereproduksi tampilan ini.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalisasi mengubah tinggi karakter tanpa mengubah nilai [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) yang ditetapkan, yang menentukan ukuran font dalam poin. [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) paragraf mengontrol jarak baris, sementara [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bingkai teks mengontrol bagaimana teks atau kontainernya menyesuaikan ukuran. Pengaturan ini melayani tujuan yang berbeda dan dapat memengaruhi tata letak secara independen. Untuk info lebih lanjut tentang pemformatan paragraf dan pewarisan, lihat [Manage Paragraph](/slides/id/java/manage-paragraph/).

## **Terapkan dan Hapus Coret**

Gunakan [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) pada bagian teks untuk menampilkan koreksi, istilah dibatalkan, atau harga sebelumnya tanpa menghapus teks asli. Atur ke [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) untuk satu atau dua garis melalui teks.

Untuk menghapus coret, gunakan [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Ini secara eksplisit menonaktifkan efek, bahkan jika pemformatan di sekitarnya menentukan coret. Sebaliknya, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) membiarkan pengaturan lokal tidak terdefinisi, memungkinkan bagian mewarisi pemformatan, misalnya dari paragraf. Ini tidak menjamin coret dihapus. Gunakan [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) untuk membaca pemformatan hasil, termasuk nilai yang diwarisi.

Contoh berdiri sendiri berikut membuat tiga perbandingan harga. Setiap paragraf memiliki bagian terpisah untuk label, harga sebelumnya, dan harga saat ini, sehingga hanya harga sebelumnya yang terpengaruh. Baris pertama menerapkan lalu menghapus coret; baris lainnya mempertahankan coret tunggal dan ganda. Mengubah pengaturan ini mempertahankan teks dan pemformatan lainnya, termasuk harga sebelumnya yang tebal.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Hasil, dari atas ke bawah: tidak ada coret, coret tunggal, dan coret ganda.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Atur Rotasi Teks**

Gunakan [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) untuk mengatur orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), yang memutar teks **90 derajat berlawanan arah jarum jam**:

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

## **Tampilkan Digit Berdampingan dalam Teks Vertikal**

Untuk menjaga dua digit angka tetap bersama dalam label vertikal Jepang, letakkan kedua digit dalam satu bagian teks dan panggil [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) pada bagian tersebut. Contoh menggunakan [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) dan MS Gothic 40 poin untuk kedua label. Hanya nilai [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) yang diberikan ke bagian numerik yang berbeda.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Di PowerPoint, label kiri (`True`) menampilkan digit tegak lurus dan berdampingan di antara 和 dan 年. Pada label kanan (`False`), pasangan digit diputar 90 derajat searah jarum jam. Karakter Jepang di sekitarnya tetap tegak lurus pada kedua label.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Atur Rotasi Kustom untuk Bingkai Teks**

Gunakan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) untuk mengatur sudut rotasi kustom bagi sebuah [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

Contoh kode di bawah memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

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

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), dan [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) untuk mengontrol jarak paragraf. Properti‑properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh berikut mengatur jarak dalam paragraf pertama menjadi 200 % dari tinggi baris (jarak ganda):

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

## **Kontrol Pemutusan Baris**

Aturan pemutusan baris paragraf berguna pada blok teks sempit dan presentasi yang mencampur teks Latin dan Asia Timur. Metode berikut termasuk dalam [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), sehingga berlaku untuk seluruh paragraf:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) mengontrol aturan pemutusan baris Latin. Dalam teks campuran, mengubahnya juga dapat mengubah tempat teks Asia Timur dan tanda baca berdekatan terbungkus.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) mengontrol aturan pemutusan baris Asia Timur, termasuk pembatasan pada karakter di awal dan akhir baris.

Aturan‑aturan ini tidak menggantikan [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), yang mengaktifkan pembungkus otomatis dalam bingkai teks. Mereka memengaruhi tata letak ketika pembungkus terjadi; mereka tidak menyisipkan karakter pemutusan baris. Pemutusan baris eksplisit memaksa baris baru dalam paragraf secara independen dari lebar yang tersedia.

Contoh berdiri sendiri berikut membuat blok teks sempit yang berisi teks Cina dan Latin. Ia mengatur kedua opsi pemutusan baris secara eksplisit dan menyimpan "line_breaking.pptx". Untuk bereksperimen dengan salah satu aturan, ubah nilai yang bersangkutan sambil mempertahankan pengaturan lainnya. Contoh menggunakan Arial 24 poin dan SimSun dengan lebar bingkai 160 poin serta margin horizontal bingkai teks nol. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) dipanggil dengan [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) agar ukuran teks dan dimensi bingkai tetap tetap.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) memungkinkan tanda baca yang memenuhi syarat melampaui tepi kanan baris teks alih-alih menempati baris berikutnya. Ini berlaku untuk seluruh paragraf dan berbeda dari indentasi menggantung.

Contoh berdiri sendiri berikut mengaktifkan tanda baca menggantung dalam bingkai teks lebar 100 poin dan menyimpan "hanging_punctuation.pptx". Dengan Arial 24 poin dan margin horizontal bingkai teks nol, titik akhir tetap berada setelah "kalimat" dan melampaui tepi kanan teks. Atur properti ke [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) untuk membandingkan: dengan pengaturan ini, titik berada pada baris terpisah. Pembungkus diaktifkan dan autofit dinonaktifkan agar lebar tersedia tetap tetap.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Tidak semua tanda baca dapat menggantung. [Kondisi font dan tata letak yang dijelaskan di atas](#control-line-breaking) juga berlaku untuk perbandingan ini: mengubah font, lebar tersedia, margin, atau pengaturan autofit dapat menghilangkan perbedaan yang terlihat.

## **Atur Tipe Autofit untuk Bingkai Teks**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks diperkecil, meluap, atau mengubah ukuran bentuk secara otomatis. Contoh berikut mengonfigurasi bentuk agar menyesuaikan ukurannya dengan teks dan menyimpan hasil ke "autofit_type.pptx".

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

Untuk menghitung baris setelah pembungkus otomatis dan melihat bagaimana lebar teks atau bentuk mengubah hasil, lihat [Count Rendered Lines](/slides/id/java/manage-paragraph/). Jumlah baris saja tidak menunjukkan apakah teks meluap kontainernya.

## **Atur Penjepitan Bingkai Teks**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) menentukan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah. Contoh berikut menjepit teks ke bagian bawah bentuk pertama dan menyimpan hasil ke "text_anchor.pptx".

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

## **Atur Tabulasi Teks**

Gunakan [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) dan [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) untuk mengonfigurasi tabulasi dalam sebuah paragraf. Contoh berikut mengatur interval tab default menjadi 100 poin dan menambahkan tab kiri pada 30 poin. Pengaturan ini memengaruhi teks yang berisi karakter tab.

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

![Tabulasi paragraf](paragraph_tabs.png)

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), yang memungkinkan Anda mengatur bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh berikut memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama dan setidaknya satu paragraf. Ia mengganti isi paragraf pertama dengan "1。", menetapkan SimSun sebagai fontnya, dan menetapkan bahasa proofing Cina Sederhana (`zh-CN`). Hasil disimpan ke "proofing_language.pptx":

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

Saat menyalin teks multibahasa dari sebuah template, pertahankan baik [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) maupun [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Contoh berdiri sendiri berikut membuat bagian sumber dengan bahasa Inggris AS sebagai bahasa dan bahasa Prancis sebagai bahasa alternatif, lalu menyalin teks dan pengidentifikasi ke bagian dalam presentasi baru.

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
    // Jika sumber tidak memiliki bahasa alternatif, null akan menghapus nilai tujuan.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk mencoba sumber tanpa bahasa alternatif, hapus penetapan `"fr-FR"`. Pengidentifikasi alternatif kemudian menjadi `null`, dan pernyataan salin yang sama mempertahankan ketidakhadirannya tanpa menambahkan nilai default, bahkan jika tujuan sebelumnya memiliki bahasa alternatif yang ditetapkan.

Pengidentifikasi ini menyimpan metadata bahasa. Mempertahankannya tidak menentukan kamus mana yang dipilih PowerPoint untuk pemeriksaan ejaan atau tata bahasa.

## **Atur Bahasa Default**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) untuk menentukan bahasa default bagi teks yang dibuat saat memuat atau membuat presentasi. Contoh berikut membuat presentasi dengan bahasa teks default Inggris AS, menambahkan kotak teks, dan mencetak `en-US` untuk bagian teks pertamanya.

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

## **Atur Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada tingkat presentasi, gunakan [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Contoh berikut mengatur font tebal 14 poin sebagai default untuk paragraf level atas dalam presentasi baru dan menyimpannya ke "default_text_style.pptx". Teks dapat mewarisi default ini kecuali pemformatan yang lebih spesifik menimpanya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Dapatkan format paragraf level atas.
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

## **Ekstrak Teks dengan Efek Semua Huruf Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) dan konversi string yang dikembalikan menjadi huruf kapital ketika nilai tersebut adalah `All`.

Contoh ini memerlukan "sample2.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Bagian pertama paragraf pertamanya berisi "Hello, Aspose!" dengan efek All Caps diterapkan, seperti yang ditunjukkan di bawah.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

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

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Iterasi sel‑sel dan perbarui masing‑masing sel melalui [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) serta pemformatan paragraf melalui [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Bagaimana cara menerapkan warna gradasi pada teks di slide PowerPoint?**

Untuk menerapkan warna gradasi pada teks, gunakan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Atur [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ke [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) dan konfigurasikan titik‑titik gradasi, arah, serta transparansi.

Fitur terkait: [Format text within slides](/slides/id/features/text-formatting/).