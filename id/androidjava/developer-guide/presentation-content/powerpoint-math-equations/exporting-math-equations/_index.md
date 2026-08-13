---
title: Ekspor Persamaan Matematika dari Presentasi di Android
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
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk Android melalui Java."
---
## **Pendahuluan**

Aspose.Slides untuk Android via Java memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain.

{{% alert color="info" %}} 
Anda dapat mengekspor persamaan langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; file MathML perantara dan konverter eksternal tidak diperlukan. Persamaan matematika disimpan dalam bingkai teks sebagai sebuah [IMathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/). Gunakan [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) untuk mendapatkan sebuah [IMathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathparagraph/), lalu panggil [IMathParagraph.toLatex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Metode ini mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) mengembalikan semua bingkai teks yang ditemukan pada sebuah slide. Pemeriksaan tipe [IMathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imathportion/) memisahkan persamaan yang dapat diedit secara nyata dari teks dan gambar biasa.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang cocok di lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalahnya untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Sementara manusia dapat dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya dalam XML, sehingga MathML umum digunakan sebagai format keluaran dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari sebuah presentasi ke MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok rumus individu?**  
Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/)) maupun blok individu ([MathBlock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah rumus matematika bukan teks biasa atau gambar?**  
Sebuah rumus berada dalam sebuah [MathPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) bukanlah rumus yang dapat diekspor.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**  
Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor rumus di dalam tabel, SmartArt, grup, dll., didukung?**  
Ya, jika objek-objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/mathparagraph/) (yaitu rumus PowerPoint yang sebenarnya), mereka akan diekspor. Jika sebuah rumus disematkan sebagai gambar, maka tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**  
Tidak. Menulis MathML adalah serialisasi konten rumus; tidak mengubah file presentasi.