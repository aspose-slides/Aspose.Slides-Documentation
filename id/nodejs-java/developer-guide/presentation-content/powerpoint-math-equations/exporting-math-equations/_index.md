---
title: Ekspor Persamaan Matematika dari Presentasi dalam JavaScript
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/nodejs-java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk Node.js melalui Java."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 

Anda dapat mengekspor persamaan langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.

{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; file MathML perantara dan konverter eksternal tidak diperlukan. Persamaan matematika disimpan dalam bingkai teks sebagai [MathPortion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/). Gunakan [MathPortion.getMathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) untuk mendapatkan [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/), dan kemudian panggil [MathParagraph.toLatex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Metode ini mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) mengembalikan semua bingkai teks yang ditemukan pada slide. Pemeriksaan tipe [MathPortion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/) memisahkan persamaan yang dapat diedit secara asli dari teks biasa dan gambar.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika suatu simbol atau elemen Office Math tidak memiliki representasi yang sesuai di lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalahnya untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berada dalam XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari sebuah presentasi ke MathML:

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

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/)) atau blok individual ([MathBlock](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa suatu objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/) bukanlah formula yang dapat diekspor.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—sub‑set presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll., didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang sebenarnya), mereka akan diekspor. Jika sebuah formula tertanam sebagai gambar, tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; tidak mengubah file presentasi.