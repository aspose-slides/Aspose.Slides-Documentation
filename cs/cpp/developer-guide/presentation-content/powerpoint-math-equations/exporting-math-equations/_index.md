---
title: Export matematických rovnic z prezentací v C++
linktitle: Export rovnic
type: docs
weight: 30
url: /cs/cpp/exporting-math-equations/
keywords:
- exportovat matematické rovnice
- exportovat rovnice do LaTeXu
- PowerPoint do LaTeXu
- MathML
- LaTeX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Exportujte matematické rovnice z prezentací PowerPoint do LaTeXu nebo MathML přímo s Aspose.Slides pro C++."
---
## **Úvod**

Aspose.Slides pro C++ vám umožňuje exportovat matematické rovnice z prezentací. Například můžete potřebovat extrahovat matematické rovnice na snímcích (z konkrétní prezentace) a použít je v jiném programu nebo na jiné platformě. 

{{% alert color="primary" %}} 
Můžete exportovat rovnice přímo do LaTeXu nebo do MathML, populárního standardu pro matematický obsah používaného na webu a v mnoha aplikacích.
{{% /alert %}}

## **Export matematických rovnic do LaTeXu**

Aspose.Slides dokáže převést rovnici PowerPointu přímo do LaTeXu; není zapotřebí mezilehlý soubor MathML ani externí konvertor. Matematická rovnice je uložena v textovém rámci jako [IMathPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathportion/). Použijte [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) pro získání [IMathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathparagraph/), a poté zavolejte [IMathParagraph::ToLatex](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Metoda vrací řetězec, který můžete uložit, zobrazit, odeslat do jiné aplikace nebo dále zpracovat.

Následující příklad prochází každý textový rámec na každém snímku, najde všechny matematické části a zapíše každou rovnici do samostatného souboru `.tex`:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/getalltextboxes/) vrací všechny textové rámce nalezené na snímku. Kontrola typu [IMathPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathportion/) odděluje pravé editovatelné rovnice od běžného textu a obrázků.

LaTeXové enginy a šablony dokumentů nepodporují všechny stejné příkazy, balíčky ani Unicode znaky. Otestujte vrácený řetězec pomocí LaTeXového enginu, který vaše aplikace používá. Pokud symbol nebo prvek Office Math nemá v tomto prostředí vhodnou reprezentaci, nahraďte jej ve vráceném řetězci projektovým příkazem nebo rovnici přeskočte a zaznamenejte problém k revizi.

## **Uložení matematických rovnic jako MathML**

Zatímco lidé snadno píší kód pro některé formáty rovnic, jako je LaTeX, mají potíže s psaním kódu pro MathML, protože ten je určen k automatickému generování aplikacemi. Programy snadno čtou a parsují MathML, protože jeho kód je v XML, takže MathML je běžně používáno jako výstupní a tiskový formát v mnoha oborech. 

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

**Co přesně se exportuje do MathML – odstavec nebo jednotlivý blok vzorce?**

Můžete exportovat buď celý matematický odstavec ([MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/)) nebo jednotlivý blok ([MathBlock](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy poskytují metodu pro zápis do MathML.

**Jak mohu poznat, že objekt na snímku je matematický vzorec, a ne běžný text nebo obrázek?**

Vzorec se nachází v [MathPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathportion/) a má [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/). Obrázky a běžné textové části bez [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/) nejsou exportovatelné vzorce.

**Odkud v prezentaci pochází MathML – je specifické pro PowerPoint nebo je to standard?**

Export cílí na standardní MathML (XML). Aspose používá Presentation MathML – prezentační podmnožinu standardu, která je široce používána v různých aplikacích i na webu.

**Je podporován export vzorců uvnitř tabulek, SmartArt, skupin atd.?**

Ano, pokud tyto objekty obsahují textové části s [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/) (tj. skutečné PowerPointové vzorce), jsou exportovány. Pokud je vzorec vložen jako obrázek, není.

**Mění export do MathML původní prezentaci?**

Ne. Zapisování MathML je serializace obsahu vzorce; neprovádí úpravy souboru prezentace.