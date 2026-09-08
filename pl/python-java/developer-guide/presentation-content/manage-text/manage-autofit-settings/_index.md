---
title: Ulepsz swoje prezentacje dzięki AutoFit w Pythonie
linktitle: Ustawienia Autofitu
type: docs
weight: 30
url: /pl/python-java/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- brak autofitu
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla Pythona via Java, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wstęp**

Domyślnie, po dodaniu pola tekstowego, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla pola tekstowego — automatycznie zmienia rozmiar pola, aby jego tekst zawsze w nim zmieścił się.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Gdy tekst w polu staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole — zwiększa jego wysokość — aby pomieścić więcej tekstu.  
* Gdy tekst w polu staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole — zmniejsza jego wysokość — aby usunąć nadmiarowy pusty obszar.

W PowerPoint istnieją 4 istotne parametry lub opcje kontrolujące zachowanie autofitu dla pola tekstowego:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java udostępnia podobne opcje — niektóre właściwości w klasie [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/) — które pozwalają kontrolować zachowanie autofitu dla pól tekstowych w prezentacjach.

## **Zmień rozmiar kształtu, aby dopasować tekst**

Jeśli chcesz, aby tekst w polu zawsze mieścił się w tym polu po wprowadzeniu zmian, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z parametrem [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że tekst musi zawsze mieścić się w swoim polu w prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie powiększone (wzrośnie wysokość), aby zapewnić, że cały tekst się w nim zmieści. Jeśli tekst stanie się krótszy, nastąpi odwrotna operacja.

## **Do Not Autofit**

Jeśli chcesz, aby pole tekstowe lub kształt zachowały swoje wymiary bez względu na zmiany w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z parametrem [None](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że pole tekstowe musi zawsze zachować swoje wymiary w prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gdy tekst stanie się zbyt długi dla swojego pola, wypłynie poza nie.

## **Shrink Text on Overflow**

Jeśli tekst stanie się zbyt długi dla swojego pola, za pomocą opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu mają zostać zmniejszone, aby zmieścił się w polu. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z parametrem [Normal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Uwaga" color="info" %}}
Kiedy użyta zostanie opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla swojego pola.
{{% /alert %}}

## **Wrap Text**

Jeśli chcesz, aby tekst w kształcie był łamany wewnątrz tego kształtu, gdy wyjdzie poza jego granicę (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, użyj metody [setWrapText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setWrapText) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z parametrem [NullableBool.True](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#True).

Ten kod w Pythonie pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Ostrzeżenie" color="warning" %}}
Jeśli użyjesz metody [setWrapText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setWrapText) z parametrem [NullableBool.False](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#False) dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż szerokość kształtu, tekst będzie wyświetlany poza granicami kształtu w jednej linii.
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstu wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępną powierzchnię dla tekstu, więc AutoFit uruchamia się wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi łamaniem linii?**

Wymuszone łamania pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych łamań często zmniejsza agresywność AutoFit.

**Czy zmiana czcionki motywu lub wymuszenie zamiany czcionki wpływa na wyniki AutoFit?**

Tak. Zastąpienie czcionki czcionką o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić końcowy rozmiar czcionki i układ linii. Po każdej zmianie lub zamianie czcionki należy ponownie sprawdzić slajdy.