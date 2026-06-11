---
title: Ulepsz swoje prezentacje dzięki AutoFit w .NET
linktitle: Ustawienia Autofit
type: docs
weight: 30
url: /pl/net/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie autofit
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- prezentacja
- C#
- .NET
- Aspose.Slides
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla .NET, aby optymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, gdy dodajesz pole tekstowe, Microsoft PowerPoint używa ustawienia **Resize shape to fit text** dla pola tekstowego — automatycznie zmienia rozmiar pola tekstowego, aby jego tekst zawsze w nim się mieścił.

![Pole tekstowe w PowerPoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększając jego wysokość — aby pomieścił więcej tekstu.  
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejszając jego wysokość — aby usunąć nadmiarową przestrzeń.

W PowerPoint istnieją cztery ważne parametry lub opcje kontrolujące zachowanie autofitu dla pola tekstowego:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Opcje Autofitu w PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides dla .NET udostępnia podobne opcje — właściwości klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat) — które pozwalają kontrolować zachowanie autofitu dla pól tekstowych w prezentacjach.

## **Zmienianie Rozmiaru Kształtu, aby Pasował do Tekstu**

Jeśli chcesz, aby tekst w ramce zawsze mieścił się w tej ramce po wprowadzeniu zmian, musisz użyć opcji **Resize shape to fit text**. Aby określić to ustawienie, ustaw właściwość `AutofitType` klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat) na `Shape`.

![Ustawienie Resize shape to fit text](alwaysfit-setting-powerpoint.png)

Ten kod C# pokazuje, jak określić, że tekst musi zawsze mieścić się w swojej ramce w prezentacji PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie zmienione (zwiększone w wysokości), aby zapewnić, że cały tekst się w nim mieści. Jeśli tekst stanie się krótszy, zachodzi odwrotny proces.

## **Nie automatyczne dopasowanie**

Jeśli chcesz, aby pole tekstowe lub kształt zachował swoje wymiary niezależnie od zmian w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, ustaw właściwość `AutofitType` klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat) na `None`.

![Ustawienie "Do not Autofit" w PowerPoint](donotautofit-setting-powerpoint.png)

Ten kod C# pokazuje, jak określić, że pole tekstowe musi zawsze zachowywać swoje wymiary w prezentacji PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Gdy tekst stanie się zbyt długi dla swojej ramki, wypływa poza nią.

## **Zmniejszanie Tekstu przy Przepełnieniu**

Jeśli tekst stanie się zbyt długi dla swojej ramki, za pomocą opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu mają zostać zmniejszone, aby zmieścił się w ramce. Aby określić to ustawienie, ustaw właściwość `AutofitType` klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat) na `Normal`.

![Ustawienie "Shrink text on overflow" w PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod C# pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
Gdy opcja **Shrink text on overflow** jest używana, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla swojej ramki.
{{% /alert %}}

## **Zawijanie Tekstu**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy tekst wyjdzie poza jego granicę (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, ustaw właściwość `WrapText` klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat) na `NullableBool.True`.

Ten kod C# pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}
Jeśli ustawisz właściwość `WrapText` na `NullableBool.False` dla kształtu, kiedy tekst wewnątrz kształtu stanie się dłuższy niż jego szerokość, tekst będzie wykraczał poza granice kształtu w jednej linii.
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstowej wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępny obszar dla tekstu, więc AutoFit uruchamia się wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed strojeniem AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi wymuszeniami linii?**

Wymuszone łamania pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych łamań często zmniejsza agresywność, z jaką AutoFit musi zmniejszać tekst.

**Czy zmiana czcionki motywu lub wywołanie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Podstawienie czcionki o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić końcowy rozmiar czcionki i zawijanie linii. Po każdej zmianie lub podstawieniu czcionki ponownie sprawdź slajdy.