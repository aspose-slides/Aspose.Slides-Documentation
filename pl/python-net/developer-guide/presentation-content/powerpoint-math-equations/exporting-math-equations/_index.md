---
title: Eksport równań matematycznych z prezentacji w Pythonie
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/python-net/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Umożliw płynny eksport równań matematycznych z PowerPointa do MathML przy użyciu Aspose.Slides dla Pythona w .NET — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania z konkretnych slajdów i ponownie wykorzystać je w innym programie lub platformie.

{{% alert color="primary" %}}

Możesz wyeksportować równania do MathML, szeroko stosowanego standardu reprezentacji treści matematycznej w sieci i wielu aplikacjach.

{{% /alert %}}

## **Zapisywanie równań matematycznych jako MathML**

Chociaż ludzie łatwo piszą LaTeX, MathML jest zazwyczaj generowany automatycznie przez aplikacje. Ponieważ MathML jest oparty na XML, programy mogą go odczytywać i analizować w sposób niezawodny, więc jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach.

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

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/)), jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/). Obrazy i zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzne dla PowerPoint, czy jest standardem?**

Eksportuje się do standardowego MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacji standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksport formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwany?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie modyfikuje pliku prezentacji.