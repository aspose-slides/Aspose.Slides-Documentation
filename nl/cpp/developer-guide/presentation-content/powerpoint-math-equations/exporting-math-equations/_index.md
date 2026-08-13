---
title: Export wiskundige vergelijkingen vanuit presentaties in C++
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/cpp/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- vergelijkingen exporteren naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties rechtstreeks naar LaTeX of MathML met Aspose.Slides voor C++."
---
## **Introductie**

Aspose.Slides for C++ stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en ze in een ander programma of platform gebruiken. 

{{% alert color="info" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populair standaardformaat voor wiskundige inhoud dat op het internet en in veel toepassingen wordt gebruikt.
{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking direct omzetten naar LaTeX; een tussenliggende MathML‑file en een externe converter zijn niet vereist. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [IMathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/). Gebruik [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) om een [IMathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph::ToLatex](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere applicatie sturen of verder verwerken.

Het volgende voorbeeld onderzoekt elk tekstvak op elke dia, vindt alle wiskundige delen, en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextboxes/) retourneert alle tekstvakken die op een dia worden gevonden. De typecontrole van [IMathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die uw applicatie gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervangt u het in de geretourneerde string door een projectspecifiek commando of slaat u de vergelijking over en noteert u het probleem voor nadere beoordeling.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk de code voor sommige vergelijkingsformaten zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML omdat die bedoeld is om automatisch door applicaties te worden gegenereerd. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML is, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

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

## **Veelgestelde vragen**

**Hoe precies wordt geëxporteerd naar MathML — een alinea of een individueel formule‑blok?**

U kunt ofwel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathblock/)) exporteren naar MathML. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML in een presentatie vandaan — is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatie‑subset van de standaard — die breed ingezet wordt in verschillende applicaties en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatiedocument niet.