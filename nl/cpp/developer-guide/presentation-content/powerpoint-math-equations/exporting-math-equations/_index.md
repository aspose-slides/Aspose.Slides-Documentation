---
title: Wiskundige vergelijkingen exporteren uit presentaties in C++
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
description: "Wiskundige vergelijkingen exporteren uit PowerPoint-presentaties naar LaTeX of MathML direct met Aspose.Slides voor C++."
---
## **Introductie**

Aspose.Slides for C++ stelt u in staat wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en ze in een ander programma of platform gebruiken. 

{{% alert color="primary" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in veel toepassingen wordt gebruikt.
{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking rechtstreeks naar LaTeX converteren; een tussenliggende MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [IMathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/). Gebruik [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) om een [IMathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph::ToLatex](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen, of verder kunt verwerken.

Het volgende voorbeeld onderzoekt elk tekstvak op elke dia, zoekt alle wiskundige porties, en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextboxes/) retourneert alle tekstvakken die op een dia worden gevonden. De type‑controle van [IMathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documentsjablonen ondersteunen niet allemaal dezelfde commando's, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die door uw toepassing wordt gebruikt. Als een symbool of Office Math‑element geen geschikte weergave heeft in die omgeving, vervang het dan in de geretourneerde string door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor controle.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk de code voor enkele vergelijkingstypen zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML omdat die uiteindelijk automatisch door applicaties moet worden gegenereerd. Programma's lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie kunt exporteren naar MathML:

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

## **Veelgestelde vragen**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formuleblok?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/)) als een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstporties zonder een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML in een presentatie vandaan—is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatie‑subset van de standaard — die breed wordt toegepast in verschillende applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstporties bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) (dat wil zeggen, echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.