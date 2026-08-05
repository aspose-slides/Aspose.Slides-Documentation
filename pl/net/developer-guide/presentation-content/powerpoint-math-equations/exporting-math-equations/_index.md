---
title: Eksport równań matematycznych z prezentacji w .NET
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/net/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeXa
- PowerPoint do LaTeXa
- MathML
- LaTeX
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Eksportuj równania matematyczne z prezentacji PowerPoint do LaTeXa lub MathML bezpośrednio przy pomocy Aspose.Slides dla .NET."
---
## **Wprowadzenie**

Aspose.Slides dla .NET umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z konkretnej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="primary" %}} 

Możesz eksportować równania bezpośrednio do LaTeXa lub do MathML, popularnego standardu treści matematycznych używanego w sieci i w wielu aplikacjach.

{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeXa**

Aspose.Slides może przekształcić równanie matematyczne PowerPoint bezpośrednio do LaTeXa; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/). Użyj [MathPortion.MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/mathparagraph/), aby uzyskać [IMathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathparagraph/), a następnie wywołaj [IMathParagraph.ToLatex](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathparagraph/tolatex/). Metoda zwraca ciąg znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetwarzać.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie fragmenty matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextboxes/) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/) rozdziela autentyczne edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie obsługują wszystkich tych samych poleceń, pakietów ani znaków Unicode. Przetestuj zwrócony ciąg znaków za pomocą silnika LaTeX używanego w Twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zamień go w zwróconym ciągu na polecenie specyficzne dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapis równań matematycznych jako MathML**

Chociaż ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z kodem MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do formatu MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Najczęściej zadawane pytania**

**Co dokładnie jest eksportowane do MathML — cały akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/)), jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/). Obrazy i zwykłe fragmenty tekstowe bez [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**

Eksportowany jest standardowy MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacji standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy obsługiwany jest eksport formuł znajdujących się w tabelach, SmartArt, grupach itp.?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/) (czyli autentyczne formuły PowerPoint), zostaną wyeksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje pierwotną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie zmienia pliku prezentacji.