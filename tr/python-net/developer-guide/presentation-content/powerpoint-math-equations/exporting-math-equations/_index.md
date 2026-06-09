---
title: Sunumlardan Python’da Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/python-net/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint’ten MathML’ye matematik denklemlerinin sorunsuz dışa aktarımının kilidini açın—biçimlendirmeyi koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for Python via .NET, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli slaytlardan denklemleri çıkartıp başka bir programda veya platformda yeniden kullanmanız gerekebilir.

{{% alert color="primary" %}}
Denklikleri MathML'ye dışa aktarabilirsiniz; web'de ve birçok uygulamada matematiksel içeriği temsil etmek için yaygın olarak kullanılan bir standarttır.
{{% /alert %}}

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX'i kolayca yazabilse de, MathML genellikle uygulamalar tarafından otomatik olarak üretilir. MathML XML tabanlı olduğundan, programlar onu güvenilir bir şekilde okuyup ayrıştırabilir; bu nedenle birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır.

Aşağıdaki örnek kod, bir sunumdaki matematik denklemini MathML'ye nasıl dışa aktaracağınızı gösterir:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **SSS**

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

MathML'ye ya tüm bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/)) ya da ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'ye yazmak için bir yöntem sunar.

**Bir slayttaki nesnenin normal metin veya resim yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içermeyen resimler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Sunumda MathML nereden gelir—PowerPoint'e özel mi yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri barındırıyorsa (yani gerçek PowerPoint formülleri), dışa aktarılır. Formül bir resim olarak gömülmüşse, dışa aktarılmaz.

**MathML'ye dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formül içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.