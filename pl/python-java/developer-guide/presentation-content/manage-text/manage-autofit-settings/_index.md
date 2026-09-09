---
title: Ulepsz swoje prezentacje za pomocą AutoFit w Pythonie
linktitle: Ustawienia Autofit
type: docs
weight: 30
url: /pl/python-java/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie używaj autofitu
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
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla Pythona poprzez Javę, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, po dodaniu pola tekstowego, Microsoft PowerPoint używa ustawienia **Resize shape to fit text** dla tego pola — automatycznie zmienia rozmiar pola, aby tekst zawsze w nim mieścił się.

![Pole tekstowe w programie PowerPoint](textbox-in-powerpoint.png)

* Gdy tekst w polu staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole — zwiększa jego wysokość — aby pomieścić więcej tekstu.
* Gdy tekst w polu staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole — zmniejsza jego wysokość — aby usunąć nadmiarową przestrzeń.

W programie PowerPoint są to 4 ważne parametry lub opcje kontrolujące zachowanie autofitu dla pola tekstowego:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java oferuje podobne opcje — niektóre właściwości klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/) — które umożliwiają kontrolowanie zachowania autofitu dla pól tekstowych w prezentacjach.

## **Resize a Shape to Fit Text**

Jeśli chcesz, aby tekst w polu zawsze mieścił się w tym polu po wprowadzeniu zmian, musisz użyć opcji **Resize shape to fit text**. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z wartością [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ten kod w języku Python pokazuje, jak określić, że tekst musi zawsze mieścić się w swoim polu w prezentacji PowerPoint:

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

Jeśli chcesz, aby pole tekstowe lub kształt zachowało swoje wymiary niezależnie od zmian w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z wartością [None](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ten kod w języku Python pokazuje, jak określić, że pole tekstowe musi zawsze zachować swoje wymiary w prezentacji PowerPoint:

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gdy tekst stanie się zbyt długi dla swojego pola, wypłynie na zewnątrz.

## **Shrink Text on Overflow**

Jeśli tekst stanie się zbyt długi dla swojego pola, możesz użyć opcji **Shrink text on overflow**, aby określić, że rozmiar i odstępy tekstu mają być zmniejszone, aby zmieściły się w polu. Aby określić to ustawienie, użyj metody [setAutofitType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setAutofitType) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z wartością [Normal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod w języku Python pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

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

{{% alert title="Note" color="info" %}}
Kiedy użyta jest opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla swojego pola.
{{% /alert %}}

## **Wrap Text**

Jeśli chcesz, aby tekst w kształcie zawijał się wewnątrz tego kształtu, gdy przekroczy jego granicę (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, użyj metody [setWrapText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setWrapText) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/)) z wartością [NullableBool.True_](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#True).

Ten kod w języku Python pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Jeśli użyjesz metody [setWrapText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setWrapText) z wartością [NullableBool.False](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/#False) dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż szerokość kształtu, tekst wyjdzie poza jego granice w jednej linii.
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstu wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępną przestrzeń dla tekstu, więc AutoFit uruchomi się wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami wierszy?**

Wymuszone podziały pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych podziałów często zmniejsza agresywność AutoFit w zmniejszaniu tekstu.

**Czy zmiana czcionki motywu lub wymuszenie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Zastąpienie czcionki inną o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić ostateczny rozmiar czcionki i zawijanie wierszy. Po każdej zmianie lub podstawieniu czcionki, ponownie sprawdź slajdy.