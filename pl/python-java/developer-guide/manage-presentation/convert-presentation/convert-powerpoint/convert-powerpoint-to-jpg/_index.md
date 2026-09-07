---
title: Konwertuj PPT i PPTX do JPG w Pythonie
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/python-java/convert-powerpoint-to-jpg/
keywords:
- konwertować PowerPoint
- konwertować prezentację
- konwertować slajd
- PowerPoint do JPG
- PPT do JPG
- PPTX do JPG
- zapisać slajd jako JPG
- eksportować PPT do JPG
- eksportować PPTX do JPG
- Python
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na obrazy JPG w Pythonie za pomocą Java. Ustaw niestandardowe wymiary obrazu i renderuj notatki oraz komentarze przy pomocy Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java pozwala konwertować prezentacje PowerPoint i OpenDocument (PPT, PPTX i ODP) na obrazy JPEG. Możesz eksportować każdy slajd lub wybrany slajd, aby tworzyć miniatury, budować przeglądarkę prezentacji lub osadzać podglądy slajdów w witrynie lub aplikacji.

## **Konwertuj PowerPoint PPT/PPTX do JPG**

1. Załaduj prezentację przy użyciu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz slajdy za pomocą [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides).
3. Wywołaj [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z poziomymi i pionowymi współczynnikami skalowania, aby renderować każdy slajd.
4. Zapisz każdy wyrenderowany obraz jako JPEG przy użyciu [ImageFormat.Jpeg](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/#Jpeg), a następnie zwolnij zasoby obrazu.

{{% alert color="info" title="Note" %}}
Eksportowanie do JPG tworzy osobny obraz dla każdego slajdu. Zapisz wyrenderowany obraz zamiast zapisywać prezentację bezpośrednio w formacie obrazu.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konwertuj PowerPoint PPT/PPTX do JPG z niestandardowymi wymiarami**

Oblicz poziome i pionowe współczynniki skalowania na podstawie żądanych wymiarów w pikselach oraz oryginalnego rozmiaru slajdu, a następnie przekaż je do [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage). W poniższym przykładzie docelowy rozmiar obrazu to 1200 × 800 dla każdego slajdu.

Użycie różnych współczynników skalowania może rozciągnąć slajd. Aby zachować jego proporcje, użyj tego samego współczynnika dla obu osi; wówczas uzyskana szerokość i wysokość będą odpowiadały oryginalnym proporcjom slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Renderuj komentarze przy zapisywaniu slajdów jako obrazy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/), aby skonfigurować notatki i komentarze, oraz zastosuj układ poprzez [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Ten przykład umieszcza notatki na dole, obcinając te, które nie mieszczą się, oraz wyświetla komentarze po prawej stronie w obszarze o szerokości 200 pikseli. Zapisuje każdy wyrenderowany slajd jako obraz JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę konwertować wiele slajdów lub prezentacji do JPG?**

Tak. Przykłady iterują przez wszystkie slajdy i zapisują po jednym pliku JPG dla każdego slajdu. Aby przetworzyć wiele prezentacji, powtórz konwersję dla każdego pliku wejściowego i użyj oddzielnych folderów wyjściowych lub unikalnych nazw plików, aby uniknąć nadpisywania obrazów.

**Czy wykresy, SmartArt, tabele i kształty są uwzględniane w obrazach?**

Te obiekty są renderowane jako część slajdu. Udostępnij czcionki używane w prezentacji w środowisku konwersji, aby zredukować różnice spowodowane podstawianiem czcionek.

**Jak mogę zmniejszyć zużycie pamięci przy eksportowaniu dużych prezentacji?**

Przetwarzaj obrazy pojedynczo, zwalniając każdy obraz po jego zapisaniu, i unikaj niepotrzebnie dużych wymiarów wyjściowych. Wymagania pamięciowe zależą od zawartości slajdu i rozmiaru obrazu.

## **Zobacz także**

- [Konwertuj PowerPoint do PNG](/slides/pl/python-java/convert-powerpoint-to-png/).
- [Renderuj slajd jako obraz SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/).