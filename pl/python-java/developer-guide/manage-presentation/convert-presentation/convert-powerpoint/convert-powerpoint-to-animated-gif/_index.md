---
title: Konwertuj prezentacje PowerPoint na animowane GIF-y w Pythonie
linktitle: PowerPoint do GIF
type: docs
weight: 65
url: /pl/python-java/convert-powerpoint-to-animated-gif/
keywords:
- animowany GIF
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do GIF
- prezentację do GIF
- slajd do GIF
- PPT do GIF
- PPTX do GIF
- zapisz PPT jako GIF
- zapisz PPTX jako GIF
- eksportuj PPT jako GIF
- eksportuj PPTX jako GIF
- ustawienia domyślne
- ustawienia niestandardowe
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIF-y za pomocą Aspose.Slides for Python via Java. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia konwersję prezentacji PowerPoint na animowane pliki GIF przy pomocy zaledwie kilku wierszy kodu. Jest to przydatne do udostępniania zawartości slajdów na stronach internetowych, w komunikatorach lub w dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację przy użyciu ustawień domyślnych oraz jak dostosować rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pomocą [GifOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gifoptions/).

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień domyślnych**

Poniższy przykład w języku Python wczytuje `pres.pptx` i zapisuje go jako animowany GIF przy standardowych ustawieniach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Wskazówka" %}}
Aby dostosować wyjście GIF, przekaż obiekt [GifOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gifoptions/) podczas zapisywania, jak pokazano poniżej.
{{% /alert %}}

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień niestandardowych**

Użyj [setFrameSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gifoptions/#setFrameSize), aby określić wymiary wyjściowe w pikselach, [setDefaultDelay](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gifoptions/#setDefaultDelay), aby ustawić domyślne opóźnienie slajdu w milisekundach, oraz [setTransitionFps](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gifoptions/#setTransitionFps), aby kontrolować liczbę klatek na sekundę w trakcie przejścia.

Poniższy przykład eksportuje GIF o wymiarach 960 × 720 pikseli z domyślnym opóźnieniem slajdu wynoszącym dwie sekundy oraz 35 klatkami na sekundę dla przejść. Domyślne opóźnienie ma zastosowanie, gdy nie jest ustawiony czas przejścia slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}}
Możesz także wypróbować darmowy konwerter Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif).
{{% /alert %}}

## **FAQ**

**Co zrobić, gdy czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zapasowe](/slides/pl/python-java/powerpoint-fonts/). Zastąpienie czcionek może zmienić wygląd wyeksportowanego GIF‑a. Upewnij się, że oryginalne czcionki są dostępne, gdy ważne jest zachowanie projektu prezentacji.

**Czy mogę nałożyć znak wodny na klatki GIF?**

Tak. [Dodaj półprzezroczysty obiekt lub logo](/slides/pl/python-java/watermark/) do odpowiednich slajdów wzorcowych lub do poszczególnych slajdów przed eksportem. Znak wodny stanie się częścią renderowanej zawartości slajdu.