---
title: Sunumlardan .NET'te Matematik Denklemlerini Dışa Aktarma
linktitle: Denklikleri Dışa Aktar
type: docs
weight: 30
url: /tr/net/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'ten LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarındaki matematik denklemlerini doğrudan LaTeX veya MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides for .NET, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumdaki slaytlardaki matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="info" %}} 

Denklikleri doğrudan LaTeX'e ya da web ve çeşitli uygulamalarda kullanılan popüler bir standart olan MathML'e dışa aktarabilirsiniz. 

{{% /alert %}}

## **Denklikleri LaTeX'e Dışa Aktarma**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücüye ihtiyaç yoktur. Bir matematik denklemi, bir metin çerçevesinde bir [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) olarak saklanır. Bir [MathPortion.MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/mathparagraph/) kullanarak bir [IMathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/) elde edin ve ardından [IMathParagraph.ToLatex](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/tolatex/) metodunu çağırın. Metod, bir dize döndürür; bu dizeyi kaydedebilir, görüntüleyebilir, başka bir uygulamaya gönderebilir veya daha ileri işleyebilirsiniz. 

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar: 

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextboxes/) bir slaytta bulunan tüm metin çerçevelerini döndürür. [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) tip kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır. 

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemeyebilir. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsil bulamazsa, döndürülen dizede project-spesifik bir komutla değiştirin veya denklemi atlayıp sorunu gözden geçirme için kaydedin. 

## **Denklikleri MathML Olarak Kaydetme**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmesi amaçlanan bir formattır. Programlar MathML'i kolayca okuyup ayrıştırır çünkü kodu XML'dir; bu nedenle MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan bir matematik denklemini MathML olarak dışa aktarmayı gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

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

**MathML'e tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa tek bir formül bloğu mu?**

Bir bütün matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/)) ya da tek bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathblock/)) MathML'e dışa aktarabilirsiniz. Her iki tür de MathML'e yazma metoduna sahiptir. 

**Bir slayttaki nesnenin normal metin veya görüntü yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir. 

**MathML sunumda nereden geliyor—PowerPoint’e özgü mü yoksa bir standart mı?**

Dışa aktarma hedefi standart MathML (XML)’dir. Aspose, sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır. 

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri içeriyorsa (yani gerçek PowerPoint formülleri), dışa aktarılır. Formül bir görüntü olarak gömülü ise dışa aktarılmaz. 

**MathML'e dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazma, formül içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.