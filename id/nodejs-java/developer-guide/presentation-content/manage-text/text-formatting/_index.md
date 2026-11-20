---
title: Format Teks Presentasi dalam JavaScript
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/nodejs-java/text-formatting/
keywords:
- menyelaraskan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- frame teks
- jarak baris
- properti autofit
- jangkar frame teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Format dan bergaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Ini mencakup warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tabulasi, dan pengaturan bahasa.

Kecuali dinyatakan lain, contoh menggunakan [sample.pptx](sample.pptx). Bentuk pertama pada slide pertamanya adalah kotak teks, dan paragraf pertamanya berisi teks yang ditunjukkan di bawah. Indeks slide dan bentuk berbasis nol. Contoh yang menyorot bagian tebal menggunakan format efektif, termasuk format tebal yang diwariskan:

![Teks contoh](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Search and Replace Text](/slides/id/nodejs-java/search-and-replace-text/).

## **Set Text Background Color**

Gunakan [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) untuk mengatur warna sorotan default bagi sebuah paragraf, atau gunakan [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) untuk bagian teks individual.

Contoh berikut menetapkan sorotan abu‑abu terang sebagai default untuk paragraf pertama. Warna sorotan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur warna sorotan untuk seluruh paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf abu‑abu](gray_paragraph.png)

Contoh kode di bawah ini memperlihatkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur warna sorotan untuk bagian teks.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bagian teks abu‑abu](gray_text_portions.png)

## **Align Text Paragraphs**

Gunakan [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) untuk mengatur perataan paragraf dalam sebuah frame teks. Nilainya dapat berupa centered, left‑aligned, right‑aligned, justified, dan sebagainya.

Contoh kode berikut menunjukkan cara menyejajarkan paragraf ke **tengah**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur perataan paragraf ke tengah.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf yang disejajarkan](aligned_paragraph.png)

## **Align Fonts Within a Line**

Gunakan [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) untuk menyejajarkan secara vertikal bagian teks dengan ukuran font berbeda dalam satu baris. Pengaturan ini berlaku untuk seluruh paragraf dan mengontrol perataan dalam setiap barisnya.

Contoh mandiri berikut membuat empat kotak teks berlabel pada satu slide. Setiap paragraf berisi teks yang sama dengan ukuran 18, 36, dan 54 poin, dengan perataan font yang berbeda. Menggunakan Arial, menonaktifkan autofit dan pembungkus, serta menjaga frame teks cukup besar untuk satu baris.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Perbandingan perataan Baseline, Top, Center, dan Bottom dengan ukuran font campuran](font_alignment.png)

Perataan font menggunakan metrik font, sehingga tepi visual huruf individual tidak selalu sejajar secara tepat. Contoh ini menyertakan huruf kapital dan huruf dengan descender untuk memperlihatkan perbedaan antara baseline dan bottom. Ketersediaan font serta substitusi, karakter yang dipakai, dan perbedaan ukuran font memengaruhi hasil. Dimensi frame, margin, jarak baris, pembungkus, dan autofit juga memengaruhi tata letak; gunakan font dan pengaturan tata letak yang sama saat membandingkan mode.

Pengaturan ini berbeda dari [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), yang mengontrol perataan horizontal paragraf, dan [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), yang menempatkan blok teks secara vertikal dalam bentuknya. Pemformatan superskrip dan subskrip melalui [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) menggeser bagian individual relatif terhadap baseline, bukan mengatur perataan font untuk baris paragraf.

## **Set Transparency for Text**

Transparansi teks dikendalikan melalui komponen alfa dari warna yang ditetapkan pada [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Pada contoh di bawah, `alpha = 50` adalah nilai kanal alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode berikut memperlihatkan cara menerapkan transparansi ke **seluruh paragraf**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Atur warna isi teks menjadi warna transparan.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut memperlihatkan cara menerapkan transparansi ke **bagian teks dengan font tebal**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Atur transparansi bagian teks.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Set Character Spacing for Text**

Gunakan [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) untuk memperlebar atau mempersempit jarak antar karakter dalam kotak teks. Contoh menambahkan 3 poin jarak; nilai negatif mempersempit teks.

Kode JavaScript berikut memperlihatkan cara memperlebar jarak karakter dalam **seluruh paragraf**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Perluas jarak karakter.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode berikut memperlihatkan cara memperlebar jarak karakter dalam **bagian teks dengan font tebal**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
            portion.getPortionFormat().setSpacing(3); // Perluas jarak karakter.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat dibandingkan teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat hasil render lebih mirip dengan PowerPoint, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terkena. Atur [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) ke nilai yang lebih besar daripada ukuran font sebenarnya. Contoh ini memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Ia memeriksa nama font efektif, termasuk font yang diwariskan, dan menetapkan ambang 100 poin untuk bagian yang menggunakan Roboto. Ini menonaktifkan kerning untuk bagian yang cocok dengan ukuran font di bawah 100 poin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk teks yang cocok di bawah ambang, pengaturan ini mencegah kerning dan dapat membantu menyamakan hasil render Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi perilaku khusus PowerPoint ini.

## **Manage Text Font Properties**

Properti font dapat diatur pada tingkat paragraf melalui [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) atau pada bagian individual melalui [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Contoh berikut menetapkan font default paragraf pertama menjadi Times New Roman 12 poin dengan tebal, miring, dan garis bawah titik. Pemformatan eksplisit pada bagian individual memiliki prioritas lebih tinggi daripada default ini.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Atur properti font untuk paragraf.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh berikut menerapkan Times New Roman 13 poin, pemformatan miring, dan garis bawah titik pada bagian yang format efektifnya tebal:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Atur properti font untuk bagian teks.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Control Text Height Normalization**

Gunakan [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) ketika mereproduksi tipografi templat atau menyelidiki perbedaan tinggi karakter. Di PowerPoint, mengaktifkan normalisasi meregangkan atau memampatkan karakter secara vertikal agar memiliki tinggi visual yang seragam dalam bagian teks. Ini tidak menjamin tinggi teks yang sama antar font yang berbeda.

Atur properti ke [NullableBool.True or False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) untuk secara eksplisit mengaktifkan atau menonaktifkan normalisasi. `NullableBool.NotDefined` membiarkan pengaturan lokal tidak ditetapkan sehingga bagian mewarisi nilainya, misalnya dari [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) paragraf. Itu bukan berarti `False`. Gunakan [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) dan baca [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) untuk memperoleh nilai Boolean yang telah diputuskan.

Contoh mandiri berikut memerlukan **Arial** terpasang. Ia membuat dua blok teks berisi huruf kapital, huruf kecil, descender, dan karakter beraksen pada 54 poin. Kedua paragraf mengaktifkan normalisasi secara default. Bagian atas secara eksplisit menonaktifkannya; bagian bawah mewarisinya. Ukuran frame, margin, dan jarak paragraf identik, dengan pembungkus dan autofit dinonaktifkan agar perbandingan konsisten. Contoh mencetak `False: false` dan `NotDefined: true`, lalu menyimpan "text_height_normalization.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah diekspor dari presentasi yang disimpan. Baris atas memiliki normalisasi dinonaktifkan (`False`); baris bawah mewarisi pengaturan aktif (`NotDefined` → `True`). Pastikan Arial terpasang untuk mereproduksi tampilan ini.

![Teks Arial 54‑poin dengan normalisasi dinonaktifkan di atas dan normalisasi yang diwariskan di bawah](text_height_normalization.png)

Normalisasi mengubah tinggi karakter tanpa mengubah nilai [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) yang ditetapkan, yang menentukan ukuran font dalam poin. [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) paragraf mengontrol jarak baris, sementara [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) pada frame teks mengontrol bagaimana teks atau kontainernya menyesuaikan diri. Pengaturan ini melayani tujuan berbeda dan dapat memengaruhi tata letak secara independen. Untuk informasi lebih lanjut tentang pemformatan paragraf dan pewarisan, lihat [Manage Paragraph](/slides/id/nodejs-java/manage-paragraph/).

## **Apply and Remove Strikethrough**

Gunakan [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) pada bagian teks untuk menampilkan koreksi, istilah yang dibatalkan, atau harga sebelumnya tanpa menghapus teks asli. Atur ke [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) untuk satu atau dua garis melalui teks.

Untuk menghapus coret, gunakan [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Ini secara eksplisit menonaktifkan efek, bahkan bila pemformatan di sekitarnya menetapkan coret. Sebaliknya, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) membiarkan pengaturan lokal tidak terdefinisi, memungkinkan bagian mewarisi pemformatan, misalnya dari paragraf. Itu tidak menjamin coret dihapus. Gunakan [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) untuk membaca pemformatan hasil, termasuk nilai yang diwariskan.

Contoh mandiri berikut membuat tiga perbandingan harga. Setiap paragraf memiliki bagian terpisah untuk label, harga sebelumnya, dan harga saat ini, sehingga hanya harga sebelumnya yang terpengaruh. Baris pertama menerapkan dan kemudian menghapus coret; baris lain mempertahankan coret tunggal dan ganda. Mengubah pengaturan ini mempertahankan teks serta pemformatan lainnya, termasuk harga sebelumnya yang tebal.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Terapkan coret, kemudian hapus secara eksplisit dari harga sebelumnya yang pertama.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya, dari atas ke bawah: tanpa coret, coret tunggal, dan coret ganda.

![Harga sebelumnya tanpa coret, dengan coret tunggal, dan dengan coret ganda](strikethrough.png)

## **Set Text Rotation**

Gunakan [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) untuk menetapkan orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut menetapkan orientasi teks dalam bentuk ke [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), yang memutar teks **90 derajat berlawanan arah jarum jam**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Set Custom Rotation for Text Frames**

Gunakan [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) untuk menetapkan sudut rotasi khusus bagi sebuah [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Contoh kode di bawah memutar frame teks sebesar 3 derajat searah jarum jam dalam bentuk:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi teks khusus](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides menyediakan [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore), dan [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) untuk mengontrol jarak paragraf. Properti‑properti ini digunakan sebagai berikut:

* Nilai positif menentukan jarak baris sebagai persentase tinggi baris.
* Nilai negatif menentukan jarak baris dalam poin.

Contoh berikut mengatur jarak dalam paragraf pertama menjadi 200 % dari tinggi baris (jarak ganda):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Jarak baris dalam paragraf](line_spacing.png)

## **Control Line Breaking**

Aturan pemotongan baris paragraf berguna dalam blok teks sempit dan presentasi yang mencampur teks Latin dan Asia Timur. Metode‑metode berikut milik [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), sehingga berlaku untuk seluruh paragraf:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) mengontrol aturan pemotongan baris Latin. Pada teks campuran, mengubahnya dapat juga mengubah tempat pembungkus teks dan tanda baca Asia Timur yang berdekatan.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) mengontrol aturan pemotongan baris Asia Timur, termasuk pembatasan karakter di awal atau akhir baris.

Aturan ini tidak menggantikan [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), yang mengaktifkan pembungkus otomatis dalam sebuah frame teks. Mereka memengaruhi tata letak ketika pembungkus terjadi; mereka tidak menyisipkan karakter pemutus baris. Pemutusan baris eksplisit memaksa baris baru dalam paragraf secara independen dari lebar yang tersedia.

Contoh mandiri berikut membuat blok teks sempit yang berisi teks Cina dan Latin. Ia mengatur kedua opsi pemotongan baris secara eksplisit dan menyimpan "line_breaking.pptx". Untuk bereksperimen dengan salah satu aturan, ubah nilai yang bersangkutan sambil menjaga pengaturan lainnya tetap. Contoh memakai Arial 24 poin dan SimSun dengan lebar frame 160 poin serta margin horizontal frame teks nol. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) dipanggil dengan [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) sehingga ukuran teks dan dimensi frame tetap tetap.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Control Hanging Punctuation**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) memungkinkan tanda baca yang memenuhi syarat melampaui tepi kanan baris teks alih‑alih menempati baris berikutnya. Itu berlaku untuk seluruh paragraf dan berbeda dari indentasi menggantung.

Contoh mandiri berikut mengaktifkan hanging punctuation dalam frame teks selebar 100 poin dan menyimpan "hanging_punctuation.pptx". Dengan Arial 24 poin dan margin horizontal frame teks nol, titik akhir tetap setelah "sentence" dan melampaui tepi kanan teks. Atur properti ke [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) untuk membandingkan: dengan pengaturan ini, titik berada pada baris terpisah. Pembungkus diaktifkan dan autofit dinonaktifkan untuk menjaga lebar tersedia tetap.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tidak setiap tanda baca dapat menggantung. [Kondisi font dan tata letak yang dijelaskan di atas](#control-line-breaking) juga berlaku untuk perbandingan ini: mengubah font, lebar tersedia, margin, atau pengaturan autofit dapat menghilangkan perbedaan tampilan.

## **Set Autofit Type for Text Frames**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) menentukan bagaimana teks berperilaku ketika melampaui batas kontainernya. Gunakan untuk mengontrol apakah teks diperkecil, meluber, atau mengubah ukuran bentuk secara otomatis. Contoh berikut mengonfigurasi bentuk agar menyesuaikan ukuran agar muat teks dan menyimpan hasil ke "autofit_type.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghitung baris setelah pembungkus otomatis dan melihat bagaimana lebar teks atau bentuk mengubah hasil, lihat [Count Rendered Lines](/slides/id/nodejs-java/manage-paragraph/). Jumlah baris saja tidak menunjukkan apakah teks meluber dari kontainer.

## **Set Anchor of Text Frames**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) mendefinisikan cara teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah. Contoh berikut menambatkan teks ke bagian bawah bentuk pertama dan menyimpan hasil ke "text_anchor.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Tabulation**

Gunakan [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) dan [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) untuk mengonfigurasi tab stop dalam sebuah paragraf. Contoh berikut menetapkan interval tab default menjadi 100 poin dan menambahkan tab stop rata kiri pada 30 poin. Pengaturan ini memengaruhi teks yang berisi karakter tab.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Tabulasi paragraf](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides menyediakan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), yang memungkinkan Anda mengatur bahasa pemeriksaan ejaan untuk sebuah bagian teks. Bahasa pemeriksaan menentukan bahasa yang dipakai untuk pengecekan ejaan dan tata bahasa di PowerPoint.

Contoh berikut memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama dan setidaknya satu paragraf. Ia mengganti isi paragraf pertama menjadi "1。", mengatur SimSun sebagai fontnya, dan menetapkan bahasa pemeriksaan Simplified Chinese (`zh-CN`). Hasil disimpan ke "proofing_language.pptx":

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Atur Id bahasa pemeriksaan.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copy Language Metadata**

Saat menyalin teks multibahasa dari templat, pertahankan baik [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) maupun [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Contoh mandiri berikut membuat bagian sumber dengan bahasa US English dan bahasa alternatif French, lalu menyalin teks serta identifier ke bagian dalam presentasi baru.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Jika sumber tidak memiliki bahasa alternatif, null akan menghapus nilai tujuan.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk mencoba sumber tanpa bahasa alternatif, hapus penetapan `"fr-FR"`. Identifier alternatif kemudian menjadi `null`, dan pernyataan salin yang sama mempertahankan ketidakhadirannya tanpa menambahkan nilai default, bahkan jika tujuan sebelumnya memiliki bahasa alternatif yang ditetapkan.

Identifier ini menyimpan metadata bahasa. Mempertahankannya tidak menentukan kamus mana yang dipilih PowerPoint untuk pengecekan ejaan atau tata bahasa.

## **Set Default Language**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) untuk mendefinisikan bahasa default bagi teks yang dibuat saat memuat atau membuat presentasi. Contoh berikut membuat presentasi dengan US English sebagai bahasa teks default, menambahkan kotak teks, dan mencetak `en-US` untuk bagian teks pertamanya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Tambahkan bentuk persegi panjang baru dengan teks.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Periksa bahasa bagian pertama.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Set Default Text Style**

Untuk menerapkan pemformatan teks default pada level presentasi, gunakan [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Contoh berikut menetapkan font tebal 14 poin sebagai default untuk paragraf tingkat atas dalam presentasi baru dan menyimpannya ke "default_text_style.pptx". Teks dapat mewarisi default ini kecuali ada pemformatan yang lebih spesifik yang menimpanya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Dapatkan format paragraf tingkat atas.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extract Text with the All-Caps Effect**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks tampil dalam huruf kapital di slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, pustaka mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan tampilan, periksa [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf kapital bila nilai tersebut `All`.

Contoh ini memerlukan "sample2.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Bagian pertama paragraf pertamanya berisi "Hello, Aspose!" dengan efek All Caps diterapkan, seperti yang ditunjukkan di bawah.

![Efek All Caps](all_caps_effect.png)

Contoh kode berikut memperlihatkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
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

Untuk memodifikasi teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Iterasi sel‑sel dan perbarui setiap sel melalui [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) serta pemformatan paragraf melalui [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Atur [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) ke [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) dan konfigurasikan titik‑titik gradien, arah, serta transparansi.