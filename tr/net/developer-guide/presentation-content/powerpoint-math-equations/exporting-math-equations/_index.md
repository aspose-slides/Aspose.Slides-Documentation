---
title: Sunumlardan .NET'te Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/net/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını sağlayın—biçimlendirmeyi koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for .NET, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 
Denklikleri MathML'ye dışa aktarabilirsiniz; bu, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir biçim veya standarttır. 
{{% /alert %}}

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem biçimleri için kodu kolayca yazabilirken, MathML için kod yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML'nin kodu XML olduğu için kolayca okur ve ayrıştırır; bu nedenle MathML, birçok alanda sıklıkla çıktı ve baskı biçimi olarak kullanılır. 

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **SSS**

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa tek bir formül bloğu mu?**

MathML'ye bir bütün matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/)) ya da tek bir blok ([MathBlock](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tip de MathML'ye yazmak için bir yöntem sağlar.

**Bir slayttaki nesnenin normal metin veya resim yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/)’a sahiptir. [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içermeyen resimler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Bir sunumda MathML nereden gelir—PowerPoint'e özgü müdür yoksa bir standart mıdır?**

Dışa aktarma, standart MathML (XML)'yi hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'yi kullanır; bu, uygulamalar ve web genelinde yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri barındırıyorsa (yani gerçek PowerPoint formülleri), dışa aktarılırlar. Formül bir resim olarak gömülü ise dışa aktarılmaz.

**MathML'ye dışa aktarma orijinal sunumu değiştiriyor mu?**

Hayır. MathML yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.