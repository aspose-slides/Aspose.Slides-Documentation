---
title: Konwertuj slajdy PowerPoint na PNG w Pythonie
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/python-java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Python
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint na obrazy PNG w Pythonie za pomocą Java. Eksportuj prezentacje PPT, PPTX i ODP z własnymi skalami lub dokładnymi wymiarami obrazu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides for Python via Java. Możesz ładować prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Poniższe przykłady pokazują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint na PNG**

Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów poprzez kolekcję [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Przykład renderuje każdy slajd za pomocą [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) z [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png), aby zapisać każdy wyrenderowany slajd jako obraz PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Przeciążenie [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) bez parametrów renderuje w skali 0.2. Na przykład slajd o wymiarach 720 × 540 punktów tworzy miniaturę 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skali lub wyraźnym rozmiarem obrazu pokazanym poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint na PNG z niestandardowymi wymiarami**

Przekaż poziome i pionowe współczynniki skali do [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage), aby kontrolować wymiary renderowanego obrazu. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów tworzy obraz 1440 × 1080 pikseli. Równe współczynniki skali zachowują proporcje slajdu. Każdy wyrenderowany obraz jest zapisywany w formacie PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Konwertuj PowerPoint na PNG z niestandardowym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) zamiast współczynników skali. Ten przykład renderuje każdy slajd w rozmiarze 960 × 720 pikseli i zapisuje wynik w formacie PNG. Wybierz wymiary odpowiadające proporcjom slajdu, aby uniknąć rozciągania obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Możesz użyć metody [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) dziedziczonej po [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: od cyjanu do pomarańczu u góry oraz od niebieskiego do żółtego u dołu. Każdy gradient ma dwa przystanki, przy 0% i 100%.

Poniższy przykład ładuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach za pomocą [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Poniższe obrazy pokazują wynik z tego samego slajdu, z dwoma gradientami w każdym obrazie:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty od cyjanu do pomarańczy i od niebieskiego do żółci renderowane trybem Default](gradient-Default.png) | ![Te same gradienty renderowane trybem PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` powoduje jaadsze kolory pośrednie, podczas gdy `PowerPointUI` generuje ciemniejsze kolory pośrednie. Różnica zależy od kolorów i przystanków w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z zamierzonym efektem; żaden tryb nie jest uniwersalnie lepszy.

## **Najczęściej zadawane pytania**

**Jak mogę wyeksportować konkretny kształt, taki jak wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla pojedynczych kształtów](/slides/pl/python-java/create-shape-thumbnails/), umożliwiając renderowanie kształtu jako obrazu PNG.

**Czy równoległa konwersja jest obsługiwana na serwerze?**

Tak. Użyj osobnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji w wielu wątkach](/slides/pl/python-java/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksportowaniu do PNG?**

Tryb ewaluacyjny dodaje znak wodny do wygenerowanych obrazów i nakłada [inne ograniczenia](/slides/pl/python-java/licensing/), dopóki nie zostanie zastosowana licencja.