---
title: Ekspor Persamaan Matematika dari Presentasi di PHP
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/php-java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buka ekspor mulus persamaan matematika dari PowerPoint ke MathML menggunakan Aspose.Slides untuk PHP via Java — pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain.

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan ke MathML, format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 
{{% /alert %}}

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berupa XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang. 

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

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula tunggal?**

Anda dapat mengekspor seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/)) atau blok individu ([MathBlock](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathblock/)) ke MathML. Kedua jenis menyediakan metode untuk menulis ke MathML.

**Bagaimana saya mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/). Gambar dan potongan teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek tersebut berisi potongan teks dengan [MathParagraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang sah), mereka akan diekspor. Jika sebuah formula disisipkan sebagai gambar, tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah proses serialisasi konten formula; tidak mengubah file presentasi.