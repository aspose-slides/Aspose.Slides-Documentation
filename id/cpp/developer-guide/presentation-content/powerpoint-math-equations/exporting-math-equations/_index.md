---
title: Ekspor Persamaan Matematika dari Presentasi dalam С++
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/cpp/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Buka ekspor mulus persamaan matematika dari PowerPoint ke MathML menggunakan Aspose.Slides untuk С++ — pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides untuk C++ memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan ke MathML, format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 
{{% /alert %}}

## **Simpan Persamaan Matematika sebagai MathML**

Meskipun manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena format tersebut dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berada dalam XML, sehingga MathML biasanya digunakan sebagai format output dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathparagraph/)) maupun blok individual ([MathBlock](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada di dalam [MathPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subet presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll., didukung?**

Ya, jika objek-objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.mathtext/mathparagraph/) (yaitu formula PowerPoint yang asli), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, maka tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; tidak mengubah file presentasi.