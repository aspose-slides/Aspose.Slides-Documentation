---
title: Export matematických rovnic z prezentací v С++
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/cpp/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- MathML
- LaTeX
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Odhalte bezproblémový export matematických rovnic z PowerPointu do MathML pomocí Aspose.Slides pro С++ — zachovejte formátování a zvyšte kompatibilitu."
---
## **Úvod**

Aspose.Slides pro C++ vám umožňuje exportovat matematické rovnice z prezentací. Například může být potřeba extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo platformě. 

{{% alert color="primary" %}} 
Můžete exportovat rovnice do MathML, populárního formátu nebo standardu pro matematické rovnice a podobný obsah, který se objevuje na webu a v mnoha aplikacích. 
{{% /alert %}}

## **Uložit matematické rovnice jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže s psaním kódu pro MathML, protože tento formát má být generován automaticky aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže MathML je běžně používáno jako výstupní a tiskový formát v mnoha oblastech. 

Tento ukázkový kód vám ukazuje, jak exportovat matematickou rovnici z prezentace do MathML:
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

## **Často kladené otázky**

**Co přesně se exportuje do MathML – odstavec nebo samostatný blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak poznám, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML – je specifické pro PowerPoint nebo je to standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – podmnožinu standardu určenou pro prezentace, která je široce využívána v aplikacích a na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPoint vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není exportován.

**Mění export do MathML původní prezentaci?**

Ne. Zápis MathML je serializací obsahu vzorce; neovlivňuje soubor prezentace.