---
title: Python'da Sunumlardan Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/python-net/exporting-math-equations/
keywords:
- matematik denklemleri dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint sunumlarından matematik denklemlerini doğrudan LaTeX veya MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via .NET, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli slaytlardan denklemleri çıkartıp başka bir programda veya platformda yeniden kullanmanız gerekebilir.

{{% alert color="primary" %}}
Denklemleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içeriği standardı olan MathML'e dışa aktarabilirsiniz.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktarma**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücüye ihtiyaç yoktur. Bir matematik denklemi, bir metin çerçevesinde [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) olarak depolanır. Bir [MathPortion.math_paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) kullanarak bir [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) elde edin ve ardından [MathParagraph.to_latex](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metodunu çağırın. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha ileri işlem yapabileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) bir slaytta bulunan tüm metin çerçevelerini döndürür. [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) tür kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemeyebilir. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoruyla test edin. Eğer bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizede onu proje‑özelliği bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydetme**

İnsanlar LaTeX'i kolaylıkla yazabilse de, MathML genellikle uygulamalar tarafından otomatik olarak üretilir. MathML, XML tabanlı olduğu için programlar bunu güvenilir bir şekilde okuyup ayrıştırabilir; bu yüzden birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır.

Aşağıdaki örnek kod, bir sunumdan matematik denklemini MathML'e nasıl dışa aktaracağınızı gösterir:

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

**MathML'e tam olarak ne dışa aktarılır—bir paragraf mı yoksa ayrı bir formül bloğu mu?**  
MathML'e ya bir bütün matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/)) ya da ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sağlar.

**Bir slayttaki nesnenin düzenli metin veya resim yerine bir matematik formülü olduğunu nasıl anlayabilirim?**  
Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Sunumdaki MathML nereden gelmektedir—PowerPoint'e özgü mü yoksa bir standart mı?**  
Dışa aktarma, standart MathML (XML) hedef alır. Aspose, standartın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**  
Evet, bu nesneler [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılırlar. Formül bir resim olarak gömülü ise dışa aktarılmaz.

**MathML'e dışa aktarmak orijinal sunumu değiştirir mi?**  
Hayır. MathML yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.