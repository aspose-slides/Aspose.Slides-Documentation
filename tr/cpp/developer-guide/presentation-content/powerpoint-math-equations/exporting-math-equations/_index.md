---
title: Sunumlardan C++ ile Matematik Denklemlerini Dışa Aktar
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/cpp/exporting-math-equations/
keywords:
- matematik denklemleri dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını sağlayın — biçimlendirmeyi koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for C++ sunumlardan matematik denklemlerini dışa aktarmanıza izin verir. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarıp başka bir programda veya platformda kullanmanız gerekebilir.

{{% alert color="primary" %}} 
Denklikleri MathML'ye dışa aktarabilirsiniz; bu, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir format veya standarttır. 
{{% /alert %}}

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML için kod yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML'nin kodu XML olduğu için MathML'yi kolayca okuyup ayrıştırabilir; bu nedenle MathML birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır.

Bu örnek kod, bir sunumdan matematik denklemini MathML'ye nasıl dışa aktaracağınızı gösterir:

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

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa bireysel bir formül bloğu mu?**

MathML'ye ya tüm bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/)) ya da bireysel bir blok ([MathBlock](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tip de MathML'ye yazmak için bir yöntem sağlar.

**Bir slayttaki nesnenin normal metin veya görüntü yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Sunumdaki MathML nereden gelir—PowerPoint'e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML)'yi hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web üzerinde yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılırlar. Formül bir görsel olarak gömülü ise dışa aktarılmaz.

**MathML'ye dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.