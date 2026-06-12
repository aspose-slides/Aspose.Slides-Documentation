---
title: Menambahkan Persamaan Matematika ke Presentasi PowerPoint dalam PHP
linktitle: Persamaan Matematika PowerPoint
type: docs
weight: 80
url: /id/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Menyisipkan dan mengedit persamaan matematika di PowerPoint PPT dan PPTX dengan Aspose.Slides untuk PHP via Java, mendukung OMML, kontrol format, dan contoh kode PHP yang jelas."
---
## **Gambaran Umum**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat konten matematika serupa secara programatik: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika terformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit di slide:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah bentuk matematika, yang dibuat dengan [addMathShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addMathShape), adalah bentuk yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/) menyimpan konten matematika di dalam bingkai teks bentuk.
- [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/) berisi satu atau lebih objek [MathBlock](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathematicaltext/) dan metode fluent dari [MathElementBase](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk menjaga kode tetap singkat dan mudah dibaca.

Untuk skenario ekspor MathML, lihat [Export Math Equations from Presentations in PHP via Java](/slides/id/php-java/exporting-math-equations/).

## **Membuat Persamaan**

Contoh ini membuat bentuk matematika dan menambahkan teorema Pythagoras:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` membuat sebuah bentuk yang sudah berisi paragraf matematika. Akses `MathPortion` pertama, dapatkan `MathParagraph`‑nya, dan tambahkan blok matematika atau elemen matematika ke dalamnya.
{{% /alert %}}

## **Menambahkan Pecahan**

Gunakan [`divide`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk membuat sebuah pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Untuk pecahan bertumpuk, gunakan `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Menambahkan Radikal**

Gunakan [`radical`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk membuat akar kuadrat, akar pangkat tiga, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajat.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Fungsi dan Limit**

Gunakan [`asArgumentOfFunction`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) atau [`function`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi khusus. Untuk limit, tempatkan `lim` dalam sebuah [MathLimit](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathlimit/) atau gunakan [`setLowerLimit`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Untuk nama fungsi khusus, jadikan nama fungsi sebagai elemen saat ini:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Menambahkan Operator N-ary dan Integral**

Gunakan [`nary`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk penjumlahan, gabungan, irisan, dan operator besar lainnya. Gunakan [`integral`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk integral. Kedua metode memungkinkan Anda mengatur limit bawah dan atas.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Operator N-ary digunakan untuk operator besar dengan limit opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai `MathematicalText` dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Menambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathmatrix/) untuk baris dan kolom. Matriks tidak menyertakan kurung secara default, jadi balut matriks dengan tanda kurung, siku, atau kurawal bila diperlukan.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Array Persamaan**

Gunakan [`toMathArray`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) ketika Anda memerlukan persamaan yang rata atau tumpukan vertikal dari ekspresi.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Fungsi Trigonometri**

Gunakan [`asArgumentOfFunction`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Subskrip dan Superskrip**

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Delimiter**

Gunakan [`enclose`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk menempatkan ekspresi di dalam delimiter. Anda juga dapat mengatur karakter pemisah untuk ekspresi delimiter yang berisi beberapa elemen.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Menambahkan Kotak Batas**

Gunakan [`toBorderBox`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) ketika persamaan itu sendiri harus dibingkai.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Mengelompokkan Istilah**

Gunakan [`group`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) untuk menempatkan karakter pengelompokkan di atas atau di bawah sebuah ekspresi. Tambahkan limit untuk memberi label pada istilah yang dikelompokkan.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Memformat Elemen Matematika**

Gunakan pembantu pemformatan hanya bila memperjelas rumus. Misalnya, [`overbar`](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) menempatkan garis di atas elemen matematika.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Membuat teks matematika | [MathematicalText](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathematicaltext/) |
| Menggabungkan elemen | [join](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Membuat pecahan | [divide](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan superskrip atau subskrip | [setSuperscript](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan fungsi | [function](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan radikal | [radical](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan limit | [setLowerLimit](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan skrip sisi kiri | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan penjumlahan dan integral | [nary](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan matriks | [MathMatrix](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathmatrix/) |
| Menambahkan array persamaan | [toMathArray](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan delimiter | [enclose](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Menambahkan bar dan border | [overbar](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |
| Mengelompokkan istilah | [group](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Apakah saya dapat mengedit persamaan PowerPoint yang sudah ada?**

Ya. Buka presentasi, temukan bentuk yang berisi `MathPortion`, dapatkan `MathParagraph`‑nya, dan perbarui blok matematika di paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office Math yang dapat diedit.

**Apakah saya dapat mengekspor persamaan ke LaTeX?**

Aspose.Slides mengekspor persamaan matematika ke MathML. Jika Anda memerlukan LaTeX, ekspor ke MathML terlebih dahulu, lalu konversi MathML dengan alat yang mendukung dialek LaTeX target Anda.