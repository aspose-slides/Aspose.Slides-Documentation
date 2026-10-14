---
title: Konwertuj slajdy PowerPoint na PNG w Pythonie
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /pl/python-net/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint na PNG
- konwertuj prezentację na PNG
- konwertuj slajd na PNG
- konwertuj PPT na PNG
- konwertuj PPTX na PNG
- konwertuj ODP na PNG
- PowerPoint na PNG
- prezentacja na PNG
- slajd na PNG
- PPT na PNG
- PPTX na PNG
- ODP na PNG
- Python
- Aspose.Slides
description: "Szybko konwertuj prezentacje PowerPoint i OpenDocument na wysokiej jakości obrazy PNG przy użyciu Aspose.Slides dla Pythona w .NET, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides dla Pythona w .NET. Możesz ładować prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako oddzielny obraz PNG.

Poniższe przykłady pokazują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint na PNG**

Załaduj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów przez kolekcję [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Przykład renderuje każdy slajd przy użyciu [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) z [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), aby zapisać każdy renderowany slajd jako obraz PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Przeciążenie [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) bez parametrów renderuje w skali 0.2. Na przykład slajd o wymiarach 720 × 540 punktów generuje miniaturę 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skalowania lub explicite określonym rozmiarem obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint na PNG z własnymi wymiarami**

Przekaż poziome i pionowe współczynniki skalowania do [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/), aby kontrolować renderowane wymiary. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów generuje obraz 1440 × 1080 pikseli. Równe współczynniki skalowania zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konwertuj PowerPoint na PNG z własnym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) zamiast współczynników skalowania. Ten przykład renderuje każdy slajd w rozdzielczości 960 × 720 pikseli i zapisuje wynik przy użyciu [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Wybierz wymiary odpowiadające proporcjom slajdu, aby uniknąć rozciągania obrazu.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym pliku PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Możesz użyć właściwości [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) klasy [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: od cyjanu do pomarańczu na górze oraz od niebieskiego do żółci na dole. Każdy gradient ma dwa przystanki, w 0% i 100%.

Poniższy przykład ładuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Poniższe obrazy przedstawiają wynik tego samego slajdu, z oboma gradientami w każdym obrazie:

| Domyślny | PowerPointUI |
| --- | --- |
| ![Gradienty od cyjanu do pomarańczu oraz od niebieskiego do żółci renderowane przy użyciu domyślnego](gradient-Default.png) | ![Te same gradienty renderowane przy użyciu PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `DEFAULT` generuje jaśniejsze pośrednie kolory, podczas gdy `POWER_POINT_UI` generuje ciemniejsze pośrednie kolory. Różnica zależy od kolorów i przystanków w gradiencie.

Wybierz `DEFAULT`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `POWER_POINT_UI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z oczekiwanym rezultatem; żaden tryb nie jest uniwersalnie lepszy.

## **FAQ**

**Jak mogę wyeksportować konkretny kształt, taki jak wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla pojedynczych kształtów](/slides/pl/python-net/create-shape-thumbnails/), umożliwiając renderowanie kształtu jako obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak. Używaj osobnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji między wątkami](/slides/pl/python-net/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksporcie do PNG?**

Tryb ewaluacyjny dodaje znak wodny do obrazów wyjściowych i stosuje [inne ograniczenia](/slides/pl/python-net/licensing/), dopóki nie zostanie zastosowana licencja.