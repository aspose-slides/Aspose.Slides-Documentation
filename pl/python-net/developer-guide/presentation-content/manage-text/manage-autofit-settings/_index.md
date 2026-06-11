---
title: Ulepsz swoje prezentacje za pomocą AutoFit w Pythonie
linktitle: Ustawienia AutoFit
type: docs
weight: 30
url: /pl/python-net/manage-autofit-settings/
keywords:
- pole tekstowe
- autodopasowanie
- nie dopasowuj automatycznie
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla Pythona przez .NET, aby optymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, gdy dodajesz pole tekstowe, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla pola tekstowego — automatycznie zmienia rozmiar pola, aby tekst zawsze w nim się mieścił. 

![pole tekstowe w PowerPoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększa jego wysokość — aby pomieścić więcej tekstu. 
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejsza jego wysokość — aby usunąć zbędną przestrzeń. 

W PowerPoint istnieją 4 ważne parametry lub opcje kontrolujące zachowanie autofit dla pola tekstowego: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opcje autofit w PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET udostępnia podobne opcje — niektóre właściwości w klasie [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) — które pozwalają kontrolować zachowanie autofit dla pól tekstowych w prezentacjach. 

## **Zmiana rozmiaru kształtów, aby dopasować tekst**

Jeśli chcesz, aby tekst w ramce zawsze mieścił się w tej ramce po wprowadzeniu zmian w tekście, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, ustaw właściwość [autofit_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) na `SHAPE`. 

![ustawienie zawsze dopasowane w PowerPoint](alwaysfit-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że tekst musi zawsze mieścić się w swojej ramce w prezentacji PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie zmienione rozmiarem (zwiększenie wysokości), aby zapewnić, że cały tekst w nim zmieści się. Jeśli tekst stanie się krótszy, zachodzi odwrotna sytuacja. 

## **Nie dopasowuj automatycznie**

Jeśli chcesz, aby pole tekstowe lub kształt zachowały swoje wymiary niezależnie od zmian w tekście, który zawierają, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, ustaw właściwość [autofit_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) na `NONE`. 

![ustawienie nie dopasowuj automatycznie w PowerPoint](donotautofit-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że pole tekstowe musi zawsze zachowywać swoje wymiary w prezentacji PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Gdy tekst stanie się zbyt długi dla swojej ramki, wycieka poza nią. 

## **Zmniejsz tekst przy przepełnieniu**

Jeśli tekst stanie się zbyt długi dla swojej ramki, za pomocą opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu mają być zmniejszone, aby zmieścił się w ramce. Aby określić to ustawienie, ustaw właściwość [autofit_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) na `NORMAL`. 

![ustawienie zmniejsz tekst przy przepełnieniu w PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod w Pythonie pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Gdy użyta jest opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla swojej ramki. 
{{% /alert %}}

## **Zawijanie tekstu**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy tekst wykracza poza jego granicę (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, ustaw właściwość [wrap_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) na `NullableBool.TRUE`. 

Ten kod w Pythonie pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Jeśli ustawisz właściwość `wrap_text` na `NullableBool.FALSE` dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż szerokość kształtu, tekst zostanie wydłużony poza granice kształtu w jednej linii. 
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstowej wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępną powierzchnię dla tekstu, więc AutoFit zostanie uruchomiony wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami linii?**

Wymuszone podziały pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych podziałów często zmniejsza agresywność AutoFit w zwężaniu tekstu.

**Czy zmiana czcionki tematu lub wywołanie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Zastąpienie czcionki czcionką o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może wpłynąć na ostateczny rozmiar czcionki i zawijanie linii. Po każdej zmianie lub podstawieniu czcionki, ponownie sprawdź slajdy.