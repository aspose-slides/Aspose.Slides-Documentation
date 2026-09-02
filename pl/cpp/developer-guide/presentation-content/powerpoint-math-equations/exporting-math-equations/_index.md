---
title: Eksport równań matematycznych z prezentacji w C++
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/cpp/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Eksportuj równania matematyczne z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

Aspose.Slides dla C++ umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z określonej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="primary" %}} 

Możesz eksportować równania bezpośrednio do LaTeX lub do MathML, popularnego standardu treści matematycznych używanego w Internecie i w wielu aplikacjach.

{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeX**

Aspose.Slides może konwertować równanie matematyczne PowerPoint bezpośrednio do LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [IMathPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/imathportion/). Użyj [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/), aby uzyskać [IMathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/imathparagraph/), a następnie wywołaj [IMathParagraph::ToLatex](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Metoda zwraca ciąg znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetworzyć.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie części matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/getalltextboxes/) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [IMathPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/imathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie zawsze obsługują te same polecenia, pakiety ani znaki Unicode. Przetestuj zwrócony ciąg znaków przy użyciu silnika LaTeX używanego w twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym ciągu poleceniem specyficznym dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapisz równania matematyczne jako MathML**

Podczas gdy ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukarski w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

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

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPoint, czy jest standardem?**

Eksport skierowany jest do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacyjnego standardu, który jest szeroko stosowany w aplikacjach i w Internecie.

**Czy eksportowanie formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie modyfikuje pliku prezentacji.