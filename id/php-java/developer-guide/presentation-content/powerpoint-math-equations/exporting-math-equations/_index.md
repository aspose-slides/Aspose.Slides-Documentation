---
title: Ekspor Persamaan Matematika dari Presentasi di PHP
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/php-java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

Aspose.Slides for PHP via Java memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain.

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; file MathML perantara dan konverter eksternal tidak diperlukan. Sebuah persamaan matematika disimpan dalam bingkai teks sebagai [MathPortion](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/). Gunakan [MathPortion::getMathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/#getMathParagraph) untuk mendapatkan [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/), dan kemudian panggil [MathParagraph::toLatex](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/#toLatex). Metode tersebut mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#getAllTextBoxes) mengembalikan semua bingkai teks yang ditemukan pada sebuah slide. Pemeriksaan tipe [MathPortion](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/) memisahkan persamaan yang dapat diedit secara nyata dari teks biasa dan gambar.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang cocok di lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalah untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya dalam XML, sehingga MathML umum digunakan sebagai format keluaran dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—paragraf atau blok formula individual?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/)) atau blok individual ([MathBlock](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di seluruh aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll., didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang sebenarnya), mereka akan diekspor. Jika sebuah formula disematkan sebagai gambar, tidak akan.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; itu tidak mengubah file presentasi.