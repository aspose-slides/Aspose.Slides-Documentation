---
title: Ekspor Persamaan Matematika dari Presentasi di Android
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/androidjava/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buka ekspor mulus persamaan matematika dari PowerPoint ke MathML menggunakan Aspose.Slides untuk Android via Java—pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides for Android via Java memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain.

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan ke MathML, sebuah format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 
{{% /alert %}}

## **Mengekspor Persamaan Matematika dari Presentasi**

Meskipun manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berbasis XML, sehingga MathML biasanya digunakan sebagai format output dan pencetakan di banyak bidang.

Contoh kode ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tanya Jawab**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/)) atau blok individu ([MathBlock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika, bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah bersifat khusus PowerPoint atau standar?**

Target ekspor adalah MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar yang banyak digunakan di aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) (yaitu formula PowerPoint asli), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, maka tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Penulisan MathML adalah serialisasi konten formula; tidak mengubah file presentasi.