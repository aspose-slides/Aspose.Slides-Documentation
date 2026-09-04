---
title: Ulepsz przetwarzanie obrazów przy użyciu nowoczesnego API w Pythonie
linktitle: Nowoczesne API
type: docs
weight: 237
url: /pl/python-java/modern-api/
keywords:
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd do obrazu
- miniatura kształtu
- kształt do obrazu
- miniatura prezentacji
- prezentacja do obrazów
- dodaj obraz
- dodaj grafikę
- Python
- Java
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów w Pythonie przy użyciu Java: renderuj slajdy i kształty, dodawaj obrazy i migruj przestarzałe wywołania obrazowania do nowoczesnego API Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java uzyskuje dostęp do biblioteki Java przy użyciu JPype. Jego starsze API przetwarzania obrazów wykorzystywało [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) i [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) z `java.awt`.

Biblioteka Java oznaczyła jako przestarzałe te API obrazu począwszy od wersji 24.4. Nowoczesne API używa [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/) do ładowania, renderowania i zapisywania obrazów. Używaj go w nowym kodzie Pythona oraz przy migracji istniejących przepływów przetwarzania obrazów.

{{% alert color="info" title="Uwaga" %}}

Stare nazwy metod poniżej służą jako odnośniki migracyjne. Nie są już dostępne w bieżących wersjach. Przykłady wykonywalne używają nowoczesnego API.

Ta zmiana nie eliminuje wszystkich typów `java.awt`: przeciążenia określające rozmiar obrazu i kolor wzoru wciąż przyjmują [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) oraz [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Nowoczesne API**

Główne typy przetwarzania obrazów to:

- [IImage] — reprezentuje obraz rastrowy lub wektorowy.  
- [ImageFormat] — udostępnia stałe formatów plików graficznych.  
- [Images] — tworzy obrazy, na przykład przy użyciu [Images.fromFile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/images/#fromFile).

Użyj [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) lub [Shape.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage), aby wyrenderować pojedynczy slajd lub kształt. Użyj [Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z opcjami renderowania, aby wyrenderować wiele slajdów. Przeciążenie bez argumentów zwraca kolekcję obrazów prezentacji.

Załaduj obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/images/#fromFile), dodaj go przy pomocy [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage) lub zaktualizuj istniejący obraz prezentacji przy użyciu [PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage). Obie operacje na kolekcji obrazów akceptują [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/).

Zwolnij każdy obraz, który załadujesz lub wyrenderujesz, wywołując jego metodę `dispose` w bloku `finally`. Zwolnij prezentację przy pomocy [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose).

### **Przygotowanie środowiska Python**

Zainstaluj pakiety zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM. Przykłady pozostawiają JVM uruchomioną, aby można było ją ponownie wykorzystać. Zobacz [Limitations and API Differences](/slides/pl/python-java/limitations-and-api-differences/#import-the-library) po poradniki dotyczące notebooków i cyklu życia JVM.

Przykłady otwierające `pres.pptx` wymagają pliku prezentacji w bieżącym katalogu. Przykłady ładujące `image.png` wymagają istniejącego pliku obrazu.

### **Załaduj obraz i wyrenderuj slajd**

Ten przykład dodaje obraz do pierwszego slajdu i zapisuje slajd jako plik JPEG. [IImage.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/#save) zapisuje wyrenderowany obraz w określonym formacie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Zastępowanie starego kodu nowoczesnym API**

Zastąp wywołania przestarzałych miniatur metodami zwracającymi [IImage], a następnie zapisz wynik przy pomocy [IImage.save]. Dzięki temu nie trzeba już przekazywać wyrenderowanych obrazów do [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Renderowanie slajdu w określonym rozmiarze**

Zastąp przestarzałe wywołanie `slide.getThumbnail(image_size)` metodą [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) używając tego samego rozmiaru obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Uzyskiwanie miniatury slajdu**

Zastąp przestarzałe wywołanie `slide.getThumbnail()` metodą [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) bez argumentów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Uzyskiwanie miniatury kształtu**

Zastąp przestarzałe wywołanie `shape.getThumbnail()` metodą [Shape.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage). Upewnij się, że slajd zawiera kształt przed dostępem do niego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Uzyskiwanie miniatury prezentacji**

Zastąp przestarzałe wywołanie `presentation.getThumbnails(options, image_size)` metodą [Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages). Użyj [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/) do skonfigurowania renderowania.

Iteruj po zwróconej tablicy bezpośrednio przy pomocy `enumerate` w Pythonie. Zwolnij każdy zwrócony obraz w bloku `finally`, aby awaria zapisu nie pozostawiła niewyzwolonych obrazów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Dodawanie obrazu do prezentacji**

Zastąp wczytywanie przy pomocy [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) metodą [Images.fromFile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/images/#fromFile), a następnie przekaż otrzymany obraz do [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage). Dodaj obraz do slajdu i zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zdeprecjonowane metody i ich zamienniki w nowoczesnym API**

Tabele używają notacji wywołań w Pythonie. Nazwy w kolumnie „Stara metoda” identyfikują usunięte API; użyj powiązanych metod zastępczych. Nowoczesne metody renderowania obrazów zwracają obiekty [IImage] zamiast Java BufferedImage.

### **Prezentacja**

[Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) zwraca tablicę wyrenderowanych obrazów po wywołaniu z opcjami renderowania.

| Stara metoda | Zamiennik |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z `options, image_size` |

Tutaj `slides` jest tablicą Java `int[]` liczb slajdów (numerowanych od 1); utwórz ją jako `jpype.JArray(jpype.JInt)([1, 3])`, aby wybrać slajdy 1 i 3. `image_size` jest [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Kształt**

| Stara metoda | Zamiennik |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) bez argumentów |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) z `bounds, scale_x, scale_y` |

### **Slajd**

| Stara metoda | Zamiennik |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) bez argumentów |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) z `image_size` |
| `slide.renderToGraphics(options, graphics)` | Brak bezpośredniego zamiennika; renderuj do obrazu zamiast tego |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Brak bezpośredniego zamiennika; renderuj do obrazu zamiast tego |
| `slide.renderToGraphics(options, graphics, image_size)` | Brak bezpośredniego zamiennika; renderuj do obrazu zamiast tego |

Tutaj `options` to [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/), a `tiff_options` to [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/).

### **Wyjście**

| Stara metoda | Zamiennik |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/output/#add) z `path, image`, gdzie `image` jest [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Stara metoda | Zamiennik |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage) z [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/) |

### **PPImage**

| Stara metoda | Zamiennik |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getImage) |

Aby zastąpić zawartość istniejącego obrazu w prezentacji, użyj [PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage) z [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Stara metoda | Zamiennik |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternformat/#getTile) z `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternformat/#getTile) z `background, foreground` |

Argumenty koloru pozostają obiektami Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Dla efektywnych danych wzoru zwracanych przez API Java przez JPype, metoda zamienna zachowuje nazwę `getTileIImage`.

| Stara metoda | Zamiennik |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, zwracający [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/) |

## **Obsługa API dla Graphics2D**

Starsze przeciążenia `renderToGraphics` rysowały do kontekstu [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dostarczonego przez wywołującego. Nowoczesne API nie posiada bezpośredniego zamiennika rysującego do tego kontekstu.

Użyj [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) do renderowania slajdu lub [Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) do renderowania kilku slajdów, a następnie zapisz zwrócone obrazy przy pomocy [IImage.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/#save). Aplikacje, które łączyły renderowanie slajdów z własnym rysowaniem w Java, muszą dostosować krok kompozycji.

## **FAQ**

**Dlaczego stare API obrazowania Java zostało zastąpione?**

Nowoczesne API przenosi ładowanie, renderowanie i zapisywanie obrazów do [IImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/iimage/). Dzięki temu przepływy pracy mają wspólną abstrakcję obrazu zamiast Java BufferedImage lub kontekstu graficznego Java.

**Czy nadal potrzebuję Java i JPype?**

Tak. Aspose.Slides for Python via Java nadal działa na JVM. Nowoczesne API zmienia tylko wywołania przetwarzania obrazów, a nie wymagania środowiskowe. Zobacz [System Requirements](/slides/pl/python-java/system-requirements/).

**Jak zwalniać obrazy w Pythonie?**

Wywołaj `dispose` na każdym obrazie, który załadujesz lub wyrenderujesz, w bloku `finally`. Jeśli renderujesz kilka slajdów, zwolnij każdy obraz w zwróconej tablicy. Prezentację zwolnij osobno przy pomocy [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose).

**Czy przejście na nowoczesne API gwarantuje szybsze generowanie miniatur?**

Nie ma gwarancji przyspieszenia. Zamienniki obsługują opcje renderowania, skalowanie i rozmiary obrazów; zmierz wydajność na własnych prezentacjach i ustawieniach wyjścia.

**Dlaczego metoda pobierająca obraz czasami zwraca kolekcję?**

[Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) bez argumentów zwraca osadzone obrazy prezentacji. Jej przeciążenia z opcjami renderowania zwracają wyrenderowane obrazy slajdów.