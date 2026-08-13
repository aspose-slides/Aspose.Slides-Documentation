---
title: Sunumlardan Matematik Denklemlerini C++ ile Dışa Aktarma
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
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarından matematik denklemlerini doğrudan LaTeX veya MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides for C++ sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="info" %}} 
Denklemleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içeriği standardı olan MathML'e dışa aktarabilirsiniz.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktarma**

Aspose.Slides bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyasına ve harici bir dönüştürücüye ihtiyaç duyulmaz. Bir matematik denklemi, bir metin çerçevesinde bir [IMathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/) olarak depolanır. Bir [IMathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathparagraph/) elde etmek için [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) kullanın ve ardından [IMathParagraph::ToLatex](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) yöntemini çağırın. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha ileri işleyebileceğiniz bir dize döndürür.

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/getalltextboxes/) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/imathportion/) tür kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve resimlerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoru ile test edin. Bir sembol veya Office Math öğesinin o ortamda uygun bir temsili yoksa, döndürülen dizede proje‑spesifik bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem biçimlerinin kodunu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'i kolayca okuyup ayrıştırır çünkü kodu XML formatındadır; bu nedenle MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan bir matematik denklemini MathML'e dışa aktarmayı gösterir:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

**MathML'e tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa ayrı bir formül bloğu mu?**  
Bir MathML'e ya tüm matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/)) ya da ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sağlar.

**Bir slayttaki nesnenin normal metin veya resim yerine matematik formülü olduğunu nasıl anlayabilirim?**  
Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içermeyen resimler ve normal metin bölümleri dışa aktarılabilir formül değildir.

**Bir sunumdaki MathML nereden geliyor—PowerPoint'e özgü mü yoksa bir standart mı?**  
Dışa aktarma, standart MathML (XML) hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılmaktadır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**  
Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.mathtext/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılır. Formül bir resim olarak gömülmüşse dışa aktarılmaz.

**MathML'e dışa aktarmak orijinal sunumu değiştirir mi?**  
Hayır. MathML yazma, formülün içeriğinin serileştirilmesidir; sunum dosyasını değiştirmez.