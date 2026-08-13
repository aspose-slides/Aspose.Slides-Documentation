---
title: Zarządzanie motywami prezentacji w .NET
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/net/presentation-theme/
keywords:
- Motyw PowerPoint
- Motyw prezentacji
- Motyw slajdu
- Ustaw motyw
- Zmień motyw
- Zarządzaj motywem
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- Prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj motywami prezentacji w Aspose.Slides dla .NET, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z jednolitą identyfikacją marki."
---
## **Wstęp**

Motyw prezentacji definiuje właściwości elementów projektowych. Wybierając motyw prezentacji, zasadniczo wybierasz określony zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw składa się z kolorów, [czcionek](/slides/pl/net/powerpoint-fonts/), [stylów tła](/slides/pl/net/presentation-background/) oraz efektów.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli nie podoba Ci się kolorystyka, możesz zmienić ją, stosując nowe kolory w motywie. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/).

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Możesz określić efektywną wartość uzyskanego koloru w następujący sposób:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Kolor [A=255, R=128, G=100, B=162])
}
```

Aby dodatkowo zobrazować operację zmiany koloru, tworzymy kolejny element i przypisujemy mu kolor akcentu (z początkowej operacji). Następnie zmieniamy kolor w motywie:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Nowy kolor jest stosowany automatycznie w obu elementach.

### **Ustaw kolor motywu z dodatkowej palety**

Gdy zastosujesz transformacje luminancji do głównego koloru motywu (1), powstają kolory z dodatkowej palety (2). Następnie możesz ustawiać i pobierać te kolory motywu. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Główne kolory motywu

**2** - Kolory z dodatkowej palety.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akcent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akcent 4, jaśniejszy 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, jaśniejszy 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, jaśniejszy 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, ciemniejszy 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, ciemniejszy 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mapuj `SchemeColor` na kolory `IColorScheme`**

Gdy pracujesz z [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/), możesz zauważyć, że zawiera on następujące wartości kolorów motywu:

`Background1`, `Background2`, `Text1`, i `Text2`.

Jednak `Presentation.MasterTheme.ColorScheme` zwraca [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/), który udostępnia odpowiadające kolory jako:

`Dark1`, `Dark2`, `Light1`, i `Light2`.

Ta różnica dotyczy wyłącznie nazewnictwa. Wartości odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nie ma dynamicznej konwersji między `Text`/`Background` a `Dark`/`Light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

Różnica w nazewnictwie wynika z terminologii Microsoft Office. Starsze wersje Office używały `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, natomiast nowsze wersje interfejsu wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa następujących specjalnych identyfikatorów (podobnych do tych używanych w PowerPoint):

* **+mn-lt** - Czcionka treści łacińska (Minor Latin Font)
* **+mj-lt** - Czcionka nagłówka łacińska (Major Latin Font)
* **+mn-ea** - Czcionka treści wschodnioazjatycka (Minor East Asian Font)
* **+mj-ea** - Czcionka treści wschodnioazjatycka (Minor East Asian Font)

Ten kod C# pokazuje, jak przypisać czcionkę łacińską do elementu motywu:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Ten kod C# pokazuje, jak zmienić czcionkę motywu prezentacji:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Czcionka we wszystkich polach tekstowych zostanie zaktualizowana.

{{% alert color="info" title="TIP" %}} 
Możesz chcieć zobaczyć [czcionki PowerPoint](/slides/pl/net/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie aplikacja PowerPoint udostępnia 12 predefiniowanych teł, ale w typowej prezentacji zapisane są tylko 3 z tych 12 teł. 

![todo:image_alt_text](presentation-design_8.png)

Na przykład po zapisaniu prezentacji w aplikacji PowerPoint możesz uruchomić ten kod C#, aby dowiedzieć się, ile predefiniowanych teł znajduje się w prezentacji:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Korzystając z właściwości [BackgroundFillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) klasy [FormatScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/), możesz dodać lub uzyskać dostęp do stylu tła w motywie PowerPoint. 
{{% /alert %}}

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Przewodnik po indeksach**: 0 oznacza brak wypełnienia. Indeks zaczyna się od 1.

{{% alert color="info" title="TIP" %}} 
Możesz chcieć zobaczyć [tło PowerPoint](/slides/pl/net/presentation-background/).
{{% /alert %}}

## **Zmień efekt motywu**

Motyw PowerPoint zazwyczaj zawiera 3 wartości dla każdej tablicy stylów. Te tablice są łączone w 3 efekty: subtelny, umiarkowany i intensywny. Na przykład, oto wynik zastosowania efektów do konkretnego kształtu:

![todo:image_alt_text](presentation-design_10.png)

Korzystając z 3 właściwości ([FillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/effectstyles)) klasy [FormatScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme) możesz zmieniać elementy w motywie (nawet bardziej elastycznie niż opcje w PowerPoint).

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Powstałe zmiany w kolorze wypełnienia, typie wypełnienia, efekcie cienia itp.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?

Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, pozostawiając motyw mastera nietknięty (za pomocą [SlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/slidethememanager/)).

### Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?

[Klonuj slajdy](/slides/pl/net/clone-slides/) wraz z ich masterem do docelowej prezentacji. Zachowuje to oryginalny master, układy oraz powiązany motyw, dzięki czemu wygląd pozostaje spójny.

### Jak mogę zobaczyć „efektywne” wartości po wszystkich dziedziczeniach i nadpisaniach?

Użyj widoków „effective” API [/slides/pl/net/shape-effective-properties/] dla motywu/koloru/czcionki/efektu. Zwracają one rozstrzygnięte, ostateczne właściwości po zastosowaniu mastera oraz wszelkich lokalnych nadpisań.