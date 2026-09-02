---
title: Sunumlardan .NET'te Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/net/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint sunumlarından matematik denklemlerini Aspose.Slides for .NET ile doğrudan LaTeX ya da MathML'e dışa aktar."
---
## **Introduction**

Aspose.Slides for .NET, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarmanız ve bunları başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 
Denklemleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içeriği standardı olan MathML'e dışa aktarabilirsiniz.
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides, bir PowerPoint matematik denklemını doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ya da harici bir dönüştürücüye gerek yoktur. Bir matematik denklemi, bir metin çerçevesinde [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) olarak depolanır. Bir [IMathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/) elde etmek için [MathPortion.MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/mathparagraph/) kullanın ve ardından [IMathParagraph.ToLatex](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/tolatex/) metodunu çağırın. Metod, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextboxes/) bir slaytta bulunan tüm metin çerçevelerini döndürür. [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) tür kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri ya da Unicode karakterlerini desteklemez. Dönen dizeyi uygulamanızın kullandığı LaTeX motoruyla test edin. Eğer bir simge veya Office Math öğesi o ortamda uygun bir temsil bulamazsa, dönen dizede onu proje‑özel bir komutla değiştirin ya da denklemi atlayıp sorunu inceleme için kaydedin.

## **Save Math Equations as MathML**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'i kodunun XML olması nedeniyle kolayca okur ve ayrıştırır; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML'e nasıl dışa aktaracağınızı gösterir:

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

**MathML'e tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

Tam bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/)) veya ayrı bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathblock/)) MathML'e dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sağlar.

**Bir slayttaki nesnenin normal metin veya görüntü yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) olmayan görüntüler ve normal metin bölümleri dışa aktarılabilir formül değildir.

**MathML bir sunumda nereden geliyor—PowerPoint’e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılmaktadır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılırlar. Formül bir görüntü olarak yerleştirilmişse dışa aktarılmaz.

**MathML'e dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazma, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.