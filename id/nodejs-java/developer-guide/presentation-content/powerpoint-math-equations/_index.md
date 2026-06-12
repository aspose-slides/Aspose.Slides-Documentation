---
title: Menambahkan Persamaan Matematika ke Presentasi PowerPoint dalam JavaScript
linktitle: Persamaan Matematika PowerPoint
type: docs
weight: 80
url: /id/nodejs-java/powerpoint-math-equations/
keywords:
- persamaan matematika
- simbol matematika
- formula matematika
- teks matematika
- tambahkan persamaan matematika
- tambahkan simbol matematika
- tambahkan formula matematika
- tambahkan teks matematika
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Menyisipkan dan mengedit persamaan matematika dalam PowerPoint PPT dan PPTX dengan Aspose.Slides untuk Node.js via Java, mendukung OMML, kontrol pemformatan, dan contoh kode JavaScript yang jelas."
---
## **Ikhtisar**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides untuk Node.js via Java, Anda dapat membuat konten matematika yang sama secara programatis: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika yang diformat.

Dalam PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![Tab Sisipkan PowerPoint dengan perintah Persamaan terpilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit pada slide:

![Slide PowerPoint yang berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah bentuk matematika, dibuat dengan [addMathShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addMathShape), adalah bentuk yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/) menyimpan konten matematika di dalam bingkai teks bentuk.
- [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/) berisi satu atau beberapa objek [MathBlock](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathematicaltext/) dan metode fluently dari [MathElementBase](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk menjaga kode tetap singkat dan mudah dibaca.

Untuk skenario ekspor MathML, lihat [Export Math Equations from Presentations in Node.js via Java](/slides/id/nodejs-java/exporting-math-equations/).

## **Buat Persamaan**

Contoh ini membuat bentuk matematika dan menambahkan teorema Pythagoras:

![Persamaan c kuadrat sama dengan a kuadrat ditambah b kuadrat](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` membuat sebuah bentuk yang sudah berisi paragraf matematika. Akses `MathPortion` pertama, dapatkan `MathParagraph`‑nya, dan tambahkan blok matematika atau elemen matematika ke dalamnya.
{{% /alert %}}

## **Tambah Pecahan**

Gunakan [`divide`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk membuat sebuah pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathfractiontypes/).

![Pecahan matematika miring yang menunjukkan satu dibagi x](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pecahan bertumpuk, gunakan `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Tambah Radikal**

Gunakan [`radical`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajat.

![Ekspresi radikal akar ke-n dengan x di bawah tanda radikal](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Fungsi dan Limit**

Gunakan [`asArgumentOfFunction`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) atau [`function`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi kustom. Untuk limit, letakkan `lim` dalam sebuah [MathLimit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathlimit/) atau gunakan [`setLowerLimit`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/).

![Limit x saat x mendekati tak hingga](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk nama fungsi kustom, jadikan nama fungsi sebagai elemen saat ini:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Tambah Operator N-ary dan Integral**

Gunakan [`nary`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk penjumlahan, union, irisan, dan operator besar lainnya. Gunakan [`integral`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk integral. Kedua metode memungkinkan Anda mengatur limit bawah dan atas.

![Penjumlahan dengan limit bawah dan atas](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operator N-ary untuk operator besar dengan limit opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai `MathematicalText` dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Tambah Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathmatrix/) untuk baris dan kolom. Matriks secara default tidak menyertakan kurung, jadi balut matriks dengan tanda kurung, kurung siku, atau kurung kurawal bila diperlukan.

![Matriks matematika dua baris dengan satu sel kosong](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Array Persamaan**

Gunakan [`toMathArray`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) ketika Anda membutuhkan persamaan yang dirapatkan atau tumpukan vertikal ekspresi.

![Array matematika vertikal dengan x di atas y](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Fungsi Trigonometri**

Gunakan [`asArgumentOfFunction`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

![Fungsi trigonometri cos diterapkan pada 2x](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Subskrip dan Superskrip**

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/).

![Huruf Y kapital dengan subskrip 1 di sisi kiri dan superskrip n](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Pembatas**

Gunakan [`enclose`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk menempatkan ekspresi di dalam pembatas. Anda juga dapat mengatur karakter pemisah untuk ekspresi pembatas yang berisi beberapa elemen.

![Ekspresi pembatas yang berisi x, y, dan z dipisahkan oleh garis vertikal](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambah Kotak Batas**

Gunakan [`toBorderBox`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) ketika persamaan itu sendiri harus dibingkai.

![Persamaan dalam kotak yang menunjukkan a kuadrat sama dengan b kuadrat ditambah c kuadrat](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelompokkan Istilah**

Gunakan [`group`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) untuk menempatkan karakter pengelompokan di atas atau di bawah sebuah ekspresi. Tambahkan limit untuk memberi label pada istilah yang dikelompokkan.

![Ekspresi x ditambah y dikelompokkan dengan label teks apa pun di bawahnya](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Elemen Matematika**

Gunakan pembantu pemformatan hanya ketika mereka memperjelas rumus. Misalnya, [`overbar`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) menempatkan bar di atas elemen matematika.

![Ekspresi matematika ABC dengan overbar](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathematicaltext/) |
| Gabungkan elemen | [join](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Buat pecahan | [divide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah superskrip atau subskrip | [setSuperscript](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah fungsi | [function](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah radikal | [radical](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah limit | [setLowerLimit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah skrip sisi kiri | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah penjumlahan dan integral | [nary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah matriks | [MathMatrix](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathmatrix/) |
| Tambah array persamaan | [toMathArray](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah pembatas | [enclose](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Tambah bar dan batas | [overbar](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Bisakah saya mengedit persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan bentuk yang berisi `MathPortion`, dapatkan `MathParagraph`‑nya, dan perbarui blok matematika dalam paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office Math yang dapat diedit.

**Bisakah saya mengekspor persamaan ke LaTeX?**

Aspose.Slides mengekspor persamaan matematika ke MathML. Jika Anda membutuhkan LaTeX, ekspor ke MathML terlebih dahulu lalu konversi MathML dengan alat yang mendukung dialek LaTeX target Anda.