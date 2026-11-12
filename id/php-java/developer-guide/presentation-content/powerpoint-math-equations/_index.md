---
title: Tambahkan Persamaan Matematika ke Presentasi PowerPoint dalam PHP
linktitle: Persamaan Matematika PowerPoint
type: docs
weight: 80
url: /id/php-java/powerpoint-math-equations/
keywords:
- persamaan matematika
- simbol matematika
- rumus matematika
- teks matematika
- tambahkan persamaan matematika
- tambahkan simbol matematika
- tambahkan rumus matematika
- tambahkan teks matematika
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Masukkan dan edit persamaan matematika dalam PowerPoint PPT dan PPTX dengan Aspose.Slides untuk PHP via Java, mendukung OMML, kontrol pemformatan, dan contoh kode PHP yang jelas."
---
## **Gambaran Umum**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat konten matematika serupa secara programatik: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika terformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![Tab Insert PowerPoint dengan perintah Equation dipilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit di slide:

![Slide PowerPoint yang berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah shape matematika, dibuat dengan [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), adalah shape yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) menyimpan konten matematika di dalam frame teks shape.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) berisi satu atau lebih objek [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) dan metode fluent dari [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) untuk membuat kode singkat dan mudah dibaca.

Untuk ekspor MathML, lihat [Ekspor Persamaan Matematika dari Presentasi dalam PHP via Java](/slides/id/php-java/exporting-math-equations/).

## **Buat Persamaan**

Contoh ini menggunakan [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) untuk membuat shape matematika dan menambahkan teorema Pythagoras:

![Persamaan c kuadrat sama dengan a kuadrat ditambah b kuadrat](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) membuat shape yang sudah berisi paragraf matematika. Akses [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) pertama, panggil [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), dan tambahkan blok matematika atau elemen matematika ke dalamnya.
{{% /alert %}}

## **Tambahkan Pecahan**

Gunakan [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) untuk membuat pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Pecahan matematika miring yang menunjukkan satu dibagi x](powerpoint-math-equations_4.png)

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

Untuk pecahan bertumpuk, gunakan [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Tambahkan Radikal**

Gunakan [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajatnya.

![Ekspresi radikal akar ke-n dengan x di bawah tanda radikal](powerpoint-math-equations_5.png)

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

## **Tambahkan Fungsi dan Limit**

Gunakan [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) atau [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi khusus. Untuk limit, letakkan `lim` dalam [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) atau gunakan [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Limit x saat x mendekati tak hingga](powerpoint-math-equations_8.png)

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

Untuk nama fungsi khusus, jadikan nama fungsi sebagai elemen saat ini dan panggil [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) dengan argumennya:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Tambahkan Operator N-ary dan Integral**

Gunakan [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) untuk penjumlahan, union, irisan, dan operator besar lainnya. Gunakan [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) untuk integral. Kedua metode memungkinkan Anda mengatur limit bawah dan atas.

![Penjumlahan dengan limit bawah dan atas](powerpoint-math-equations_7.png)

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

Operator N-ary digunakan untuk operator besar dengan limit opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Tambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) untuk baris dan kolom. Matriks tidak menyertakan kurung secara default, jadi kelilingi matriks dengan tanda kurung, kurung siku, atau kurung kurawal bila diperlukan.

![Matriks matematika dua baris dengan satu sel kosong](powerpoint-math-equations_10.png)

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

## **Tambahkan Array Persamaan**

Gunakan [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) ketika Anda memerlukan persamaan yang disejajarkan atau tumpukan vertikal ekspresi.

![Array matematika vertikal dengan x di atas y](powerpoint-math-equations_11.png)

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

### **Ratakan Array dengan Elemen Sekitar**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) mengontrol perataan vertikal sebuah array relatif terhadap elemen matematika di sebelahnya. Contoh di bawah membandingkan perataan dengan baris pertama, tengah array, dan baris terakhir.

Contoh berikut membuat tiga array identik, masing-masing tiga baris dan elemen tetangga `A=` dan `=B`. Semua teks matematika menggunakan Cambria Math ukuran 24 poin. Hanya perataan array yang berubah.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Perbandingan berikut menampilkan presentasi yang disimpan di PowerPoint. Perhatikan posisi `A=` dan `=B` di sebelah tiap array.

![Array persamaan di PowerPoint dengan perataan Atas, Tengah, dan Bawah serta elemen tetangga yang identik](equation-array-alignment.png)

### **Konfigurasikan Jarak Baris**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) memilih aturan jarak untuk baris dalam array. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) memberikan nilai numerik untuk aturan jarak eksplisit dan diabaikan oleh aturan bawaan.

Untuk jarak tepat, nilai diukur dalam poin. Untuk jarak proporsional, diukur dalam setengah baris: nilai `3` dalam contoh berarti 1,5 baris. Atur kedua properti saat menentukan nilai eksplisit; mengubah nilai numerik saja tidak memilih aturan jarak.

Contoh di bawah menyimpan lima presentasi dengan persamaan, perataan, dan pengaturan font yang sama. Tiga pertama menggunakan preset; dua terakhir menunjukkan nilai eksplisit.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

Jarak baris array terpisah dari jarak paragraf. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) dan [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) menambahkan ruang di sekitar paragraf yang mengandungnya, bukan antara baris array. Begitu pula, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) memposisikan seluruh paragraf matematika secara horizontal; tidak menggantikan pengaturan perataan vertikal array.

## **Tambahkan Fungsi Trigonometri**

Gunakan [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

![Fungsi trigonometri cos diterapkan pada 2x](powerpoint-math-equations_6.png)

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

## **Tambahkan Subskrip dan Superskrip**

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Huruf Y kapital dengan subskrip 1 di sisi kiri dan superskrip n](powerpoint-math-equations_9.png)

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

## **Tambahkan Pembatas**

Gunakan [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) untuk menempatkan ekspresi di dalam pembatas. Anda juga dapat mengatur karakter pemisah untuk ekspresi pembatas yang berisi beberapa elemen.

![Ekspresi pembatas yang berisi x, y, dan z dipisahkan oleh garis vertikal](powerpoint-math-equations_13.png)

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

### **Ukuran dan Align Pembatas**

Berikan `true` ke [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) agar tanda kurung tumbuh mengelilingi operand tinggi, atau berikan `false` untuk mempertahankan ukuran normal. Gunakan [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) dengan salah satu dari dua nilai [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` menempatkan tanda kurung di tengah sumbu matematika, yang melewati tengah tanda sama dengan. `Match` menyesuaikannya dengan konten yang diapit. Kedua pengaturan hanya memengaruhi pembatas. Ekspresi di dalam tetap sama.

Contoh menempatkan pecahan pada eksponen `x` sehingga ekspresi menjulur lebih tinggi di atas garis dasar daripada di bawahnya. Semua empat persamaan menggunakan tanda kurung dan pengaturan font yang sama.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Di PowerPoint, bandingkan baris untuk melihat efek pertumbuhan. Pada baris atas, tanda kurung tumbuh mengelilingi eksponen dan tampak sama untuk kedua bentuk. Pada baris bawah, pertumbuhan dimatikan. Tanda kurung lebih kecil di kiri (`Centered`) sejajar dengan tanda sama dengan, sementara yang di kanan (`Match`) berada lebih tinggi di sekitar ekspresi.

![Empat persamaan di PowerPoint dengan pertumbuhan pembatas diaktifkan di atas dan dinonaktifkan di bawah, serta Centered di kiri dan Match di kanan](delimiter-sizing.png)

## **Tambahkan Kotak Batas**

Panggil [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) pada sebuah pecahan untuk memberi bingkai pada seluruh ekspresi. [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) yang dikembalikan menampilkan keempat sisi secara default. Gunakan [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), dan [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) untuk menghilangkan sisi tertentu.

Contoh menempatkan enam salinan pecahan yang sama pada satu slide. Untuk menunjukkan pembatalan, sembunyikan semua empat sisi dan berikan `true` ke [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) untuk diagonal naik (↗) atau [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) untuk diagonal turun (↘). Anda juga dapat menggunakan [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) atau [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) dengan kombinasi sisi yang terlihat.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Enam pecahan yang dapat diedit di PowerPoint. Baris atas: border penuh, sisi bawah dan kiri, diagonal naik. Baris bawah: diagonal turun, coretan horizontal, coretan vertikal dengan border penuh.](border-box-fractions.png)

Pada pecahan ini, coretan horizontal menutupi batang pecahan. Coretan vertikal melintasi pembilang dan penyebut sekaligus border di sekeliling tetap terlihat. Garis-garis ini menghiasi seluruh ekspresi. Coretan teks biasa berlaku pada karakter dalam satu rangkaian teks. Setelah membuka kembali presentasi di PowerPoint, Anda masih dapat mengedit pembilang dan penyebut secara terpisah.

## **Kelompokkan Istilah**

Gunakan [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) untuk menempatkan karakter pengelompokkan di atas atau di bawah sebuah ekspresi. Tambahkan limit untuk memberi label pada istilah yang dikelompokkan.

![Ekspresi x plus y dikelompokkan dengan label teks apa pun di bawahnya](powerpoint-math-equations_15.png)

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

## **Format Elemen Matematika**

Gunakan pembantu pemformatan hanya di mana mereka memperjelas rumus. Misalnya, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) menempatkan garis di atas sebuah elemen matematika.

![Ekspresi matematika ABC dengan overbar](powerpoint-math-equations_14.png)

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

### **Format Teks dalam Persamaan yang Ada**

Untuk memformat teks di seluruh persamaan yang ada, telusuri setiap pohon elemen blok matematika. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) hanya mengembalikan anak langsung, jadi panggil secara rekursif untuk mencapai teks di dalam pecahan, skrip, radikal, dan struktur bersarang lainnya. Periksa elemen saat ini serta anak‑anaknya untuk menyertakan elemen awal ketika itu adalah [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Contoh ini mengasumsikan bahwa `input.pptx` berisi persamaan seperti `z = xᵢ / ∛y`, dengan pecahan yang memiliki subskrip di pembilang dan radikal di penyebut. Memproses hanya elemen tingkat atas blok akan melewatkan teks di dalam pecahan. Contoh menemukan bagian matematika dalam frame teks slide, mengakses blok mereka melalui [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), dan menggunakan [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk mengatur ukuran font menjadi 28 poin melalui metode [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) setiap elemen teks.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Presentasi yang disimpan berisi pemformatan teks yang diperbarui di setiap level masing‑masing persamaan yang diproses, sambil mempertahankan konten teks dan struktur matematikanya.

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Gabungkan elemen | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Buat pecahan | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah superskrip atau subskrip | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah fungsi | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah radikal | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah limit | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah skrip sisi kiri | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah penjumlahan dan integral | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah matriks | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Tambah array persamaan | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah pembatas | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tambah bar dan border | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Apakah saya dapat mengedit persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan shape yang berisi [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), panggil [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), dan perbarui blok matematika di paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office math yang dapat diedit.

**Apakah saya dapat mengekspor persamaan ke LaTeX?**

Ya. Dapatkan [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) persamaan dari [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), dan panggil [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) untuk mengekspornya secara langsung. Untuk contoh lengkap, lihat [Ekspor Persamaan Matematika dari Presentasi dalam PHP via Java](/slides/id/php-java/exporting-math-equations/#export-math-equations-to-latex).