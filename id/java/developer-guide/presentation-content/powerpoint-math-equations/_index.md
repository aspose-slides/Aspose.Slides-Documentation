---
title: Menambahkan Persamaan Matematika ke Presentasi PowerPoint dalam Java
linktitle: Persamaan Matematika PowerPoint
type: docs
weight: 80
url: /id/java/powerpoint-math-equations/
keywords:
- persamaan matematika
- simbol matematika
- rumus matematika
- teks matematika
- menambahkan persamaan matematika
- menambahkan simbol matematika
- menambahkan rumus matematika
- menambahkan teks matematika
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Menyisipkan dan mengedit persamaan matematika dalam PowerPoint PPT dan PPTX dengan Aspose.Slides untuk Java, mendukung OMML, kontrol pemformatan, dan contoh kode Java yang jelas."
---
## **Ikhtisar**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides for Java, Anda dapat membuat konten matematika yang sama secara programatis: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika berformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![Tab Insert PowerPoint dengan perintah Equation dipilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit pada slide:

![Slide PowerPoint yang berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah shape matematika, dibuat dengan [addMathShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), adalah shape yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathportion/) menyimpan konten matematika di dalam bingkai teks shape.
- [MathParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathparagraph/) berisi satu atau lebih objek [MathBlock](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathematicaltext/) dan metode fluent dari [IMathElement](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/) untuk menjaga kode tetap singkat dan mudah dibaca.

Untuk skenario ekspor MathML, lihat [Export Math Equations from Presentations in Java](/slides/id/java/exporting-math-equations/).

## **Buat Persamaan**

Contoh ini membuat sebuah shape matematika dan menambahkan teorema Pythagoras:

![Persamaan c kuadrat sama dengan a kuadrat ditambah b kuadrat](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

`addMathShape` membuat sebuah shape yang sudah berisi sebuah paragraf matematika. Akses `MathPortion` pertama, dapatkan `MathParagraph`‑nya, dan tambahkan blok matematika atau elemen matematika ke dalamnya.

{{% /alert %}}

## **Tambahkan Pecahan**

Gunakan `divide` untuk membuat sebuah pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathfractiontypes/).

![Pecahan matematika miring yang menunjukkan satu dibagi x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pecahan bertumpuk, gunakan `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Tambahkan Radikal**

Gunakan `radical` untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi tingkatnya.

![Ekspresi radikal akar ke-n dengan x di bawah tanda radikal](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Fungsi dan Limit**

Gunakan `asArgumentOfFunction` atau `function` untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi kustom. Untuk limit, letakkan `lim` dalam sebuah [MathLimit](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathlimit/) atau gunakan `setLowerLimit`.

![Limit dari x ketika x mendekati tak terhingga](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk nama fungsi kustom, jadikan nama fungsi sebagai elemen saat ini:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Tambahkan Operator N-ary dan Integral**

Gunakan `nary` untuk penjumlahan, union, irisan, dan operator besar lainnya. Gunakan `integral` untuk integral. Kedua metode memungkinkan Anda mengatur limit bawah dan atas.

![Penjumlahan dengan limit bawah dan atas](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operator N-ary digunakan untuk operator besar dengan limit opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai `MathematicalText` dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Tambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathmatrix/) untuk baris dan kolom. Matriks secara default tidak menyertakan tanda kurung, jadi bungkus matriks dengan tanda kurung, kurung siku, atau kurung kurawal bila diperlukan.

![Matriks matematika dua baris dengan satu sel kosong](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Array Persamaan**

Gunakan `toMathArray` ketika Anda memerlukan persamaan yang diratakan atau tumpukan vertikal dari ekspresi.

![Array matematika vertikal dengan x di atas y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Fungsi Trigonometri**

Gunakan `asArgumentOfFunction` ketika argumen adalah elemen saat ini dan nama fungsi diketahui.

![Fungsi trigonometri cos diterapkan pada 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Subskrip dan Superskrip**

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan `setSubSuperscriptOnTheLeft`.

![Huruf Y kapital dengan subskrip sisi kiri 1 dan superskrip n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Pembatas**

Gunakan `enclose` untuk menempatkan sebuah ekspresi di dalam pembatas. Anda juga dapat mengatur karakter pemisah untuk ekspresi pembatas yang berisi beberapa elemen.

![Ekspresi pembatas yang berisi x, y, dan z dipisahkan oleh garis vertikal](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Kotak Bingkai**

Gunakan `toBorderBox` ketika persamaan itu sendiri harus dibingkai.

![Persamaan berbingkai yang menunjukkan a kuadrat sama dengan b kuadrat ditambah c kuadrat](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelompokkan Istilah**

Gunakan `group` untuk menempatkan karakter pengelompokkan di atas atau di bawah sebuah ekspresi. Tambahkan limit untuk memberi label pada istilah yang dikelompokkan.

![Ekspresi x ditambah y dikelompokkan dengan label teks apa pun di bawahnya](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Elemen Matematika**

Gunakan pembantu format hanya bila mereka memperjelas rumus. Misalnya, `overbar` menempatkan sebuah garis di atas elemen matematika.

![Ekspresi matematika ABC dengan overbar](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathematicaltext/) |
| Gabungkan elemen | [IMathElement.join](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Buat pecahan | [IMathElement.divide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Tambahkan superskrip atau subskrip | [setSuperscript](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Tambahkan fungsi | [function](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Tambahkan radikal | [IMathElement.radical](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Tambahkan limit | [setLowerLimit](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Tambahkan skrip sisi kiri | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Tambahkan penjumlahan dan integral | [nary](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Tambahkan matriks | [MathMatrix](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathmatrix/) |
| Tambahkan array persamaan | [toMathArray](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#toMathArray--) |
| Tambahkan pembatas | [enclose](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Tambahkan bar dan bingkai | [overbar](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/id/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Bisakah saya mengedit persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan shape yang berisi `MathPortion`, dapatkan `MathParagraph`‑nya, dan perbarui blok matematika dalam paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office math yang dapat diedit.

**Bisakah saya mengekspor persamaan ke LaTeX?**

Aspose.Slides mengekspor persamaan matematika ke MathML. Jika Anda memerlukan LaTeX, pertama ekspor ke MathML lalu konversi MathML dengan alat yang mendukung dialek LaTeX target Anda.