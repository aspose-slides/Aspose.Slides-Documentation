---
title: Zarządzanie tłem prezentacji w Pythonie poprzez Java
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/python-java/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- kolor jednolity
- kolor gradientowy
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Java, z wskazówkami kodu, które wzmocnią Twoje prezentacje."
---
## **Wprowadzenie**

Kolory jednolite, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczego slajdu) lub **slajdu głównego** (obowiązuje dla wielu slajdów jednocześnie).

![Tło PowerPoint](powerpoint-background.png)

## **Ustaw jednolite tło kolorowe dla normalnego slajdu**

Aspose.Slides umożliwia ustawienie koloru jednolitego jako tła dla konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu głównego. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Ustaw właściwość [BackgroundType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getsolidfillcolor) na [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić niebieski jednolity kolor jako tło dla normalnego slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ustaw kolor tła slajdu na niebieski.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Zapisz prezentację na dysku.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw jednolite tło kolorowe dla slajdu głównego**

Aspose.Slides umożliwia ustawienie koloru jednolitego jako tła dla slajdu głównego w prezentacji. Slajd główny działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc po wybraniu jednolitego koloru tła slajdu głównego, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/backgroundtype/) slajdu głównego (poprzez [getMasters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getmasters)) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) tła slajdu głównego na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getsolidfillcolor), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić jednolity kolor (zielony) jako tło dla slajdu głównego:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Ustaw kolor tła slajdu głównego na zielony.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Zapisz prezentację na dysku.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Używany jako tło slajdu, może sprawić, że prezentacje będą wyglądały bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie koloru gradientowego jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getgradientformat) na [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić kolor gradientowy jako tło dla slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Zastosuj efekt gradientu do tła.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Dodaj kolory gradientu. Bez przystanków gradientu tło domyślnie przechodzi w czarno-białą rampę.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Zapisz prezentację na dysku.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw obraz jako tło slajdu**

Oprócz wypełnień jednolitych i gradientowych, Aspose.Slides umożliwia użycie obrazów jako tła slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) tła slajdu na `Picture`.
4. Wczytaj obraz, którego chcesz użyć jako tła slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getpicturefillformat) na [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić obraz jako tło slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ustaw właściwości obrazu tła.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Wczytaj obraz.
    image = Images.fromFile("Tulips.jpg")
    # Dodaj obraz do kolekcji obrazów prezentacji.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Zapisz prezentację na dysku.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kafelkowany i zmodyfikować właściwości kafelkowania:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Ustaw obraz używany do wypełnienia tła.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Ustaw tryb wypełnienia obrazu na kafelkowanie i dostosuj właściwości kafelkowania.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}}
Czytaj więcej: [Tile Picture as Texture](/slides/pl/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby podkreślić zawartość slajdu. Poniższy kod w języku Python pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Na przykład.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Pobierz kolekcję operacji transformacji obrazu.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Znajdź istniejący efekt przezroczystości o stałym procencie.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Ustaw nową wartość przezroczystości.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pobierz wartość tła slajdu**

Aspose.Slides umożliwia pobranie efektywnych wartości tła slajdu za pomocą metody [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/background/#geteffective) na [Background](https://reference.aspose.com/slides/pl/python-java/aspose.slides/background/). Zwrócone dane udostępniają efektywne formaty wypełnienia i efektu.

Korzystając z metody [getBackground](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getbackground) klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/), możesz uzyskać tło slajdu.

Poniższy przykład w języku Python pokazuje, jak pobrać efektywną wartość tła slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Utwórz instancję klasy Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Pobierz efektywne tło, uwzględniając slajd główny, układ i motyw.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/python-java/slide-layout/)/[master](/slides/pl/python-java/slide-master/) (czyli z [theme background](/slides/pl/python-java/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/python-java/slide-layout/)/[master](/slides/pl/python-java/slide-master/), zostanie zaktualizowane, aby odpowiadało [new theme](/slides/pl/python-java/presentation-theme/).