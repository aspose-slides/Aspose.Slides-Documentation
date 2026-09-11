---
title: Eksport równań matematycznych z prezentacji w Pythonie
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/python-java/exporting-math-equations/
keywords:
- eksport równań matematycznych
- eksport równań do LaTeX
- PowerPoint do LaTeX
- MathML
- LaTeX
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Eksportuj równania matematyczne z prezentacji PowerPoint do LaTeX lub MathML bezpośrednio przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Wprowadzenie**

Aspose.Slides umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład, możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z określonej prezentacji) i użyć ich w innym programie lub platformie. 

{{% alert color="info" title="Uwaga" %}} 

Możesz eksportować równania bezpośrednio do LaTeX lub do MathML, popularnego standardu treści matematycznych używanego w sieci i w wielu aplikacjach.

{{% /alert %}}

## **Eksportowanie równań matematycznych do LaTeX**

Aspose.Slides może konwertować równanie matematyczne z PowerPointa bezpośrednio do LaTeX; nie jest wymagany pośredni plik MathML ani zewnętrzny konwerter. Równanie matematyczne jest przechowywane w ramce tekstowej jako [MathPortion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathportion/). Użyj [MathPortion.getMathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathportion/#getMathParagraph), aby uzyskać [MathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/), a następnie wywołaj [MathParagraph.toLatex](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/#toLatex). Metoda zwraca łańcuch znaków, który możesz zapisać, wyświetlić, wysłać do innej aplikacji lub dalszej przetworzyć.

Poniższy przykład przegląda każdą ramkę tekstową na każdym slajdzie, znajduje wszystkie fragmenty matematyczne i zapisuje każde równanie do osobnego pliku `.tex`:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#getAllTextBoxes) zwraca wszystkie ramki tekstowe znalezione na slajdzie. Sprawdzenie typu [MathPortion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathportion/) oddziela prawdziwe edytowalne równania od zwykłego tekstu i obrazów.

Silniki LaTeX i szablony dokumentów nie obsługują wszystkich tych samych poleceń, pakietów ani znaków Unicode. Przetestuj zwrócony łańcuch za pomocą silnika LaTeX używanego w Twojej aplikacji. Jeśli symbol lub element Office Math nie ma odpowiedniej reprezentacji w tym środowisku, zastąp go w zwróconym łańcuchu poleceniem specyficznym dla projektu lub pomiń równanie i zanotuj problem do przeglądu.

## **Zapis równań matematycznych jako MathML**

Chociaż programiści mogą łatwo pisać kod dla niektórych formatów równań, takich jak LaTeX, MathML jest trudniejszy do ręcznego pisania, ponieważ jest przeznaczony do automatycznego generowania przez aplikacje. Programy mogą łatwo odczytywać i analizować MathML, ponieważ jest on oparty na XML, więc MathML jest powszechnie używany jako format wyjściowy i drukowania w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **Najczęściej zadawane pytania**

**Co dokładnie jest eksportowane do MathML — cały akapit czy pojedynczy blok formuły?**

Możesz wyeksportować zarówno cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/)) jak i pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathblock/)). Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę rozpoznać, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — czy jest specyficzny dla PowerPointa, czy jest standardem?**

Eksportowany jest standardowy MathML (XML). Aspose używa Presentation MathML — podzbioru prezentacyjnego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksportowanie formuł znajdujących się w tabelach, SmartArt, grupach itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są one eksportowane. Jeśli formuła jest osadzona jako obraz, nie zostanie wyeksportowana.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapis MathML jest serializacją zawartości formuły; nie modyfikuje pliku prezentacji.