---
title: Sunumlardan C++'ta Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/cpp/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını sağlayın — biçimlendirmeyi koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for C++ sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 
Denklemleri, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir format veya standart olan MathML'ye dışa aktarabilirsiniz. 
{{% /alert %}}

## **Math Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML'nin XML tabanlı olması nedeniyle onu kolayca okuyup ayrıştırabilir, bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

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

## **SSS**

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa tek bir formül bloğu mu?**  

MathML'ye bir bütün math paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/)) veya tek bir blok ([MathBlock](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tip de MathML'ye yazma yöntemi sunar.  

**Bir slayd üzerindeki bir nesnenin normal metin veya resim yerine bir matematik formülü olduğunu nasıl anlayabilirim?**  

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içermeyen resimler ve normal metin bölümleri dışa aktarılabilir formüller değildir.  

**Bir sunumda MathML nereden gelir—PowerPoint'e özgü mü yoksa bir standart mı?**  

Dışa aktarma, standart MathML (XML)'i hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.  

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**  

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri barındırıyorsa (yani gerçek PowerPoint formülleri), dışa aktarılırlar. Formül bir resim olarak gömülü ise dışa aktarılmaz.  

**MathML'ye dışa aktarma orijinal sunumu değiştirir mi?**  

Hayır. MathML yazmak, formül içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.