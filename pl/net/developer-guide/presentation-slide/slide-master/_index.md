---
title: "Zarządzanie masterami slajdów w .NET"
linktitle: "Master slajdu"
type: docs
weight: 80
url: /pl/net/slide-master/
keywords:
- master slajdów prezentacji
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównaj master slajdy
- tło
- pole zastępcze
- klonuj master slajd
- kopiuj master slajd
- duplikuj master slajd
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla .NET: dostęp, edycja, klonowanie, porównywanie i usuwanie masterów slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**slide master** definiuje wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu oraz ustawienia stopki. W programie PowerPoint edytowanie slide mastera jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for .NET obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master slajdu może zawierać kilka slajdów układu. Normalne slajdy zwykle nie odwołują się bezpośrednio do mastera slajdu. Zamiast tego normalny slajd używa slajdu układu, a ten slajd układu należy do mastera slajdu.

Hierarchia:

1. **Slide master** – definiuje wspólny projekt i motyw.
1. **Layout slide** – definiuje określony układ pól zastępczych i formatowanie na poziomie układu.
1. **Normal slide** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia masterów slajdów, slajdów układu i slajdów normalnych](slide-master_2.jpg)

W Aspose.Slides master slajd jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/). Wszystkie master slajdy w prezentacji są dostępne poprzez kolekcję [Presentation.Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Kiedy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, zwycięża bardziej szczegółowy poziom. Na przykład, jeśli master slajd i slajd układu oba definiują tło, slajdy oparte na tym układzie używają tła układu. Aby uzyskać więcej informacji o slajdach układu, zobacz [Apply or Change Slide Layouts](/slides/pl/net/slide-layout/).
{{% /alert %}}

## **Dostęp do masterów slajdów**

W programie PowerPoint możesz otworzyć widok **View** > **Slide Master**.

![Polecenie Slide Master na karcie View w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `Masters`, aby uzyskać dostęp do master slajdów:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Możesz także uzyskać master slajd używany przez normalny slajd poprzez jego układ:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Co zawiera master slajdu**

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu, które są używane przez normalne i układowe slajdy. Członkowie specyficzni dla mastera są wymienieni na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/).

Często używane członki master slajdu obejmują:

| Członek | Cel |
| --- | --- |
| `Background` | Ustawia tło slajdu na poziomie mastera. |
| `Shapes` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazów i wspólny tekst. |
| `LayoutSlides` | Przechowuje slajdy układu, które należą do mastera. |
| `ThemeManager` | Udostępnia dostęp do API motywu mastera. |
| `HeaderFooterManager` | Steruje nagłówkami, stopkami, datami i numerami slajdów dla mastera i jego podrzędnych układów. |
| `GetDependingSlides` | Zwraca normalne slajdy, które zależą od mastera poprzez ich układy. |

## **Dodaj obraz do mastera slajdu**

Kiedy dodajesz obraz do mastera slajdu, pojawia się on na slajdach, które używają układów z tego mastera. Jest to przydatne dla logotypów, znaków wodnych, dekoracyjnych pasków i innych powtarzających się elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Aby uzyskać więcej informacji o ramkach obrazów, zobacz [Picture Frame](/slides/pl/net/picture-frame/).

## **Praca z polami zastępczymi**

Pola zastępcze są zazwyczaj definiowane na slajdach układu. Master slajd zapewnia wspólny styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które pola zastępcze są dostępne i gdzie są umieszczone.

W PowerPoint polecenia pól zastępczych są dostępne w widoku Slide Master.

![Polecenie Insert Placeholder w widoku Slide Master w PowerPoint](slide-master_5.png)

Aby dodać nowe pola zastępcze przy użyciu Aspose.Slides, pracuj ze slajdem układu, który należy do mastera:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Możesz także formatować kształty pól zastępczych, które już istnieją na masterze slajdu. Poniższy przykład znajduje pole zastępcze tytułu i stosuje wypełnienie gradientem liniowym:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Sformatowane pole zastępcze tytułu dziedziczone przez normalne slajdy](slide-master_8.png)

Aby uzyskać więcej opcji dotyczących pól zastępczych i formatowania tekstu, zobacz [Set Prompt Text in Placeholder](/slides/pl/net/manage-placeholder/) oraz [Text Formatting](/slides/pl/net/text-formatting/).

## **Zmień tło mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Aby uzyskać powiązane tematy, zobacz [Presentation Background](/slides/pl/net/presentation-background/) oraz [Presentation Theme](/slides/pl/net/presentation-theme/).

## **Sklonuj master slajdu do innej prezentacji**

Użyj [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/), aby skopiować master slajd do innej prezentacji. Skopiowany master może następnie być używany przez układy i slajdy w docelowej prezentacji.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Jeśli potrzebujesz sklonować normalne slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/net/clone-slides/).

## **Dodaj wiele masterów slajdów**

Prezentacja może zawierać wiele master slajdów. Jest to przydatne, gdy różne sekcje wymagają innego brandingu, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania master slajdami](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Porównaj master slajdów**

Master slajdy można porównać metodą `Equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje ono unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości pól zastępczych, takich jak bieżąca data.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Aby uzyskać więcej informacji, zobacz [Compare Presentation Slides](/slides/pl/net/compare-slides/).

## **Ustaw widok master slajdu jako domyślny widok**

Użyj właściwości `LastView` w [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Aby uzyskać więcej ustawień widoku, zobacz [Save Presentation](/slides/pl/net/save-presentation/).

## **Usuń nieużywane master slajdy**

Prezentacje czasami zawierają master slajdy, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslidecollection/removeunused/) aby usunąć nieużywane mastery z kolekcji `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Możesz także użyć metody low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) ,

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między masterem slajdu a slajdem układu?**

Master slajdu definiuje wspólne ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera slajdu i definiuje określony układ pól zastępczych. Normalny slajd używa slajdu układu, więc dziedziczy zarówno po układzie, jak i po masterze.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka master slajdów. Używaj wielu masterów, gdy różne sekcje wymagają różnych systemów wizualnych lub brandingu.

**Czy powinienem dodawać pola zastępcze do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj pola zastępcze do slajdów układu. Umieść współdzielone elementy wizualne i formatowanie na masterze slajdu, a pola zawartości na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć master slajd, który jest nadal używany?**

Nie. Master slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery, które nie są używane.