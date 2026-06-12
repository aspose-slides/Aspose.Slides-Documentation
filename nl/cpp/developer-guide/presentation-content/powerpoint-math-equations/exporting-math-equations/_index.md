---
title: "Wiskundige vergelijkingen exporteren vanuit presentaties in С++"
linktitle: "Vergelijkingen exporteren"
type: docs
weight: 30
url: /nl/cpp/exporting-math-equations/
keywords:
  - "wiskundige vergelijkingen exporteren"
  - MathML
  - LaTeX
  - PowerPoint
  - presentatie
  - С++
  - Aspose.Slides
description: "Ontgrendel probleemloze export van wiskundige vergelijkingen van PowerPoint naar MathML met Aspose.Slides voor С++ — behoud de opmaak en verhoog de compatibiliteit."
---
## **Introductie**

Aspose.Slides for C++ stelt u in staat wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt mogelijk de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 

U kunt vergelijkingen exporteren naar MathML, een populair formaat of standaard voor wiskundige vergelijkingen en soortgelijke inhoud die op het web en in vele toepassingen wordt gezien. 

{{% /alert %}}

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk de code voor sommige vergelijkingsformaten zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML, omdat dit later automatisch door toepassingen moet worden gegenereerd. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML is, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in vele vakgebieden. 

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

## **FAQ**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een afzonderlijk formuleblok?**

U kunt ofwel een volledige wiskunde‑paragraaf ([MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/)) of een afzonderlijk blok ([MathBlock](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathblock/)) exporteren naar MathML. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is in plaats van gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstonderdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML vandaan in een presentatie—een PowerPoint‑specifiek formaat of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML—het presentatie‑deel van de standaard—dat breed wordt toegepast in toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz., ondersteund?**

Ja, als die objecten tekstonderdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.mathtext/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als een afbeelding, niet.

**Wijzigt het exporteren naar MathML de originele presentatie?**

Nee. Het genereren van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.