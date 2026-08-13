---
title: Exportera matematiska ekvationer från presentationer i C++
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/cpp/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- exportera ekvationer till LaTeX
- PowerPoint till LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Exportera matematiska ekvationer från PowerPoint-presentationer till LaTeX eller MathML direkt med Aspose.Slides för C++."
---
## **Introduktion**

Aspose.Slides for C++ låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="info" %}} 

Du kan exportera ekvationer direkt till LaTeX eller till MathML, en populär standard för matematiskt innehåll som används på webben och i många applikationer.

{{% /alert %}}

## **Exportera matematiska ekvationer till LaTeX**

Aspose.Slides kan konvertera en PowerPoint-matteekvation direkt till LaTeX; en mellanstegs‑MathML‑fil och en extern konverterare krävs inte. En matteekvation lagras i en textruta som en [IMathPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathportion/). Använd [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) för att hämta ett [IMathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathparagraph/), och anropa sedan [IMathParagraph::ToLatex](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Metoden returnerar en sträng som du kan spara, visa, skicka till ett annat program eller bearbeta vidare.

Följande exempel undersöker varje textruta på varje bild, hittar alla matteportioner och skriver varje ekvation till en separat `.tex`‑fil:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/getalltextboxes/) returnerar alla textrutor som hittas på en bild. Typkontrollen för [IMathPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathportion/) skiljer äkta redigerbara ekvationer från vanlig text och bilder.

LaTeX‑motorer och dokumentmallar stödjer inte alla samma kommandon, paket eller Unicode‑tecken. Testa den returnerade strängen med den LaTeX‑motor som används av din applikation. Om en symbol eller Office‑Math‑element saknar en lämplig representation i den miljön, ersätt den i den returnerade strängen med ett projektspecifikt kommando eller hoppa över ekvationen och registrera problemet för granskning.

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av appar. Program läser och tolkar MathML enkelt eftersom koden är i XML, så MathML används ofta som ett utskrifts‑ och utskriftsformat i många områden. 

Den här exempelkoden visar hur du exporterar en matteekvation från en presentation till MathML:

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

## **FAQ**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matte‑stycke ([MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathblock/)) till MathML. Båda typerna har en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en mattematikformel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/). Bilder och vanliga textportioner utan ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/) kan inte exporteras som formler.

**Varifrån kommer MathML i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationsdelmängden av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textportioner med ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.