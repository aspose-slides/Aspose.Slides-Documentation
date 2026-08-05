---
title: Wiskundige vergelijkingen exporteren vanuit presentaties in C++
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/cpp/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- MathML
- LaTeX
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Naadloze export van wiskundige vergelijkingen vanuit PowerPoint naar MathML met Aspose.Slides for C++ — behoud de opmaak en verhoog de compatibiliteit."
---
## **Inleiding**

Aspose.Slides for C++ stelt je in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, je moet mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 
Je kunt vergelijkingen exporteren naar MathML, een populair formaat of standaard voor wiskundige vergelijkingen en soortgelijke inhoud die op het web en in vele applicaties wordt gebruikt. 
{{% /alert %}}

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen de code voor sommige vergelijkingsformaten zoals LaTeX gemakkelijk kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML omdat dit laatste automatisch door applicaties moet worden gegenereerd. Programma's lezen en parseren MathML gemakkelijk omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in vele sectoren. 

Deze voorbeeldcode laat zien hoe je een wiskundige vergelijking vanuit een presentatie kunt exporteren naar MathML:

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

**Wat wordt er precies geëxporteerd naar MathML – een alinea of een individueel formuleblok?**

Je kunt ofwel een volledige wiskunde‑alinea ([MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen of een object op een dia een wiskundige formule is in plaats van gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) kunnen niet worden geëxporteerde formules.

**Waar komt de MathML in een presentatie vandaan – is het specifiek voor PowerPoint of een standaard?**

De export richt zich op de standaard MathML (XML). Aspose gebruikt Presentation MathML – de presentatiesubset van de standaard – die breed wordt toegepast in applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, gebeurt dat niet.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.