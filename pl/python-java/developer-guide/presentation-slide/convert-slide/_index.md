---
title: "Konwertowanie slajdów prezentacji na obrazy w Pythonie"
linktitle: "Slajd na obraz"
type: docs
weight: 35
url: /pl/python-java/convert-slide/
keywords:
- "konwertowanie slajdu"
- "eksport slajdu"
- "slajd na obraz"
- "zapisz slajd jako obraz"
- "slajd na EMF"
- "slajd na PNG"
- "slajd na JPEG"
- "slajd na bitmapę"
- "slajd na TIFF"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF i inne formaty graficzne w Pythonie przy użyciu Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty graficzne.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Wczytaj prezentację przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Wybierz slajd, który chcesz zrenderować.
3. W razie potrzeby skonfiguruj renderowanie przy pomocy klasy [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/) .
4. Wywołaj metodę [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) . Zwraca ona obiekt obrazu.
5. Zapisz obraz i określ format wyjściowy za pomocą wartości [ImageFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/) .

## **Konwertowanie slajdu na obraz PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Uzyskany obiekt obrazu może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład w Pythonie renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Użyj przeciążenia [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) , które przyjmuje wartość [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) , aby renderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o rozmiarach 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) do metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) , aby kontrolować, gdzie pojawiają się notatki i komentarze.

Poniższy przykład umieszcza obcięte notatki pod slajdem, a komentarze po jego prawej stronie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz nie przekazuj [BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull) do metody [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) . Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Użyj zamiast tego [BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomTruncated) .
{{% /alert %}}

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/) umożliwia kontrolowanie rozmiaru, rozdzielczości i innych właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Obsługa TIFF nie jest gwarantowana w wersjach Javy starszych niż JDK 9.
{{% /alert %}}

## **Konwertowanie wszystkich slajdów na obrazy**

Iteruj po kolekcji slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pominiesz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomym i pionowym współczynnikiem skali równym 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi pliki metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysowania wektorowego, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz kontenera metafile wektorowego.

### **Eksport slajdu do EMF**

Metoda [Slide.writeAsEmf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) zapisuje [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Wywołujący posiada strumień przekazany do [Slide.writeAsEmf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) i jest odpowiedzialny za jego zamknięcie, jak pokazano powyżej.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [SvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) , aby przekonwertować zawartość SVG na EMF. Uzyskane bajty można dodać do prezentacji za pomocą [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage) i umieścić na slajdzie przy pomocy [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addPictureFrame) .

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) z kodu SVG, konwertuje go na EMF w pamięci, wstawia metafile na pierwszy slajd i zapisuje prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) nie przejmuje własności docelowego strumienia. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) przechowuje wszystkie wygenerowane dane w pamięci, więc nie jest wymagane resetowanie pozycji przed wywołaniem [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) . Zwrócona tablica bajtów pozostaje ważna po zamknięciu strumienia.

Generowanie EMF jest dostępne na systemach operacyjnych wspieranych przez wybraną wersję Aspose.Slides for Python via Java i konfigurację JDK, ale renderowanie może się różnić między platformami, gdy czcionki lub zależności graficzne są niedostępne. Zainstaluj czcionki używane w zawartości źródłowej lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [platform requirements](/slides/pl/python-java/system-requirements/) dla Aspose.Slides for Python via Java i zweryfikuj wynik w docelowej aplikacji konsumującej EMF. Aplikacje na Linuksie i macOS często mają ograniczone lub niejednolite wsparcie dla wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby poprawnie renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest brakująca, emoji mogą pojawiać się w monochromatycznej formie w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.