---
title: Mengekspor Persamaan Matematika dari Presentasi dalam Java
linktitle: Mengekspor Persamaan
type: docs
weight: 30
url: /id/java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buka kemampuan ekspor mulus persamaan matematika dari PowerPoint ke MathML menggunakan Aspose.Slides untuk Java—pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 

Anda dapat mengekspor persamaan ke MathML, format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 

{{% /alert %}}

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dapat dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena format tersebut dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berada dalam XML, sehingga MathML biasa digunakan sebagai format output dan pencetakan di banyak bidang. 

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

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individual?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathparagraph/)) maupun blok individual ([MathBlock](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathblock/)) ke MathML. Kedua jenis menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika daripada teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathparagraph/) bukanlah formula yang dapat diekspor.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll., didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang sesungguhnya), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML merupakan serialisasi konten formula; tidak mengubah file presentasi.