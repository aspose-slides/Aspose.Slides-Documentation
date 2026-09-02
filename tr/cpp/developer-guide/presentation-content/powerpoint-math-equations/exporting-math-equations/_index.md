---
title: Sunumlardan C++ ile Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/cpp/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "PowerPoint sunumlarından matematik denklemlerini doğrudan Aspose.Slides for C++ ile LaTeX ya da MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides for C++ sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarmanız ve bunları başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 
Denklikleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içeriği standardı olan MathML'e aktarabilirsiniz.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktar**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücü gerekmez. Bir matematik denklemi, bir metin çerçevesinde bir [IMathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/) olarak depolanır. Bir [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) kullanarak bir [IMathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathparagraph/) alın ve ardından [IMathParagraph::ToLatex](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) metodunu çağırın. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki her metin çerçevesini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextboxes/) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/) tip kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görsellerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen dizeyi uygulamanızda kullanılan LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsil bulamazsa, döndürülen dizede onu proje‑özel bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML için kod yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML'in kodu XML olduğu için MathML'i kolayca okur ve ayrıştırır; bu nedenle MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML'e nasıl dışa aktaracağınızı gösterir:

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

**MathML'e tam olarak ne aktarılır—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

MathML'e ya tüm bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/)) ya da ayrı bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sunar.

**Bir slayttaki nesnenin düzenli metin veya görsel yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içermeyen görseller ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Sunumda MathML nereden gelir — PowerPoint'e özgü mü yoksa standart bir şey mi?**

Dışa aktarma, standart MathML (XML)'i hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılmaktadır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarımı destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içeren metin bölümlerine sahipse (yani gerçek PowerPoint formülleri), dışa aktarılırlar. Formül bir görsel olarak gömülü ise dışa aktarılmaz.

**MathML'e dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.