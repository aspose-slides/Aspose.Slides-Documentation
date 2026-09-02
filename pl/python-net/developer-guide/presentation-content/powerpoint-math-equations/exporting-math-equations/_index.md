---
title: Eksport równań matematycznych z prezentacji w Pythonie
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/python-net/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Eksportuj równania matematyczne z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio za pomocą Aspose.Slides dla Pythona poprzez .NET."
---
## **Wprowadzenie**

Aspose.Slides dla Pythona poprzez .NET umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład może być konieczne wyodrębnienie równań z wybranych slajdów i ponowne użycie ich w innym programie lub platformie.

{{% alert color="primary" %}}
Możesz eksportować równania bezpośrednio do LaTeX lub MathML, popularnego standardu treści matematycznych używanego w sieci i w wielu aplikacjach.
{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeX**

Aspose.Slides może konwertować równanie matematyczne PowerPoint bezpośrednio do LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [MathPortion](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/). Użyj [MathPortion.math_paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) aby uzyskać [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/), a następnie wywołaj [MathParagraph.to_latex](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). Metoda zwraca ciąg znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalej przetworzyć.

Przykład poniżej przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie części matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [MathPortion](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie obsługują wszystkich tych samych poleceń, pakietów ani znaków Unicode. Przetestuj zwrócony ciąg przy użyciu silnika LaTeX używanego w twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym ciągu poleceniem specyficznym dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapisz równania matematyczne jako MathML**

Chociaż ludzie łatwo piszą LaTeX, MathML jest zazwyczaj generowany automatycznie przez aplikacje. Ponieważ MathML jest oparty na XML, programy mogą go czytać i analizować niezawodnie, dlatego jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach.

Poniższy przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**Co dokładnie jest eksportowane do MathML — paragraf czy pojedynczy blok formuły?**

Możesz wyeksportować cały paragraf matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/)) lub pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę stwierdzić, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/) i ma [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/). Obrazy i zwykłe części tekstowe bez [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**

Eksport kieruje się do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacji tego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksportowanie formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają części tekstowe z [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.