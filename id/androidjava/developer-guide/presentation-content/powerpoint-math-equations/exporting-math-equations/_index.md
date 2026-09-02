---
title: Ekspor Persamaan Matematika dari Presentasi pada Android
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/androidjava/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk Android via Java."
---
## **Pengantar**

Aspose.Slides for Android via Java memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain.

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan langsung ke LaTeX atau ke MathML, standar populer untuk konten matematis yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; file MathML perantara dan konverter eksternal tidak diperlukan. Sebuah persamaan matematika disimpan dalam bingkai teks sebagai [IMathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/). Gunakan [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) untuk mendapatkan [IMathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathparagraph/), lalu panggil [IMathParagraph.toLatex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Metode ini mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada tiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) mengembalikan semua bingkai teks yang ditemukan pada sebuah slide. Pemeriksaan tipe [IMathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/) memisahkan persamaan yang dapat diedit secara nyata dari teks biasa dan gambar.

Mesin LaTeX dan templat dokumen tidak semua mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang sesuai di lingkungan tersebut, ganti dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan dan catat masalah untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berupa XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang.

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

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

**Apa sebenarnya yang diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/)) atau blok individu ([MathBlock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Target ekspor adalah MathML standar (XML). Aspose menggunakan Presentation MathML—subseksi presentasi dari standar—yang banyak dipakai di aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek-objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang nyata), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; tidak mengubah file presentasi.