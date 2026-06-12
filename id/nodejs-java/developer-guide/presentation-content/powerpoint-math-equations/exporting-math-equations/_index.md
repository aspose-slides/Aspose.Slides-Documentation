---
title: Ekspor Persamaan Matematika dari Presentasi dalam JavaScript
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/nodejs-java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buka ekspor persamaan matematika yang mulus dari PowerPoint ke MathML menggunakan JavaScript dan Aspose.Slides untuk Node.js—pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan ke MathML, format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 
{{% /alert %}}

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berada dalam XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang. 

Contoh kode ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tanya Jawab**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok rumus individu?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/)) maupun blok individu ([MathBlock](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah rumus matematika, bukan teks biasa atau gambar?**

Sebuah rumus berada dalam [MathPortion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/) tidak dapat diekspor sebagai rumus.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor rumus di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, bila objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/) (yaitu rumus PowerPoint yang asli), mereka akan diekspor. Jika sebuah rumus disematkan sebagai gambar, tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten rumus; itu tidak mengubah file presentasi.