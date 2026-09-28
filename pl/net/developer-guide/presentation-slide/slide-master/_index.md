---
title: Zarządzanie master‑slajdami prezentacji w .NET
linktitle: Master slajd
type: docs
weight: 80
url: /pl/net/slide-master/
keywords:
- master slajdu
- master slajd
- PPT master slajd
- wiele master‑slajdów
- porównaj master‑slajdy
- tło
- placeholder
- klonuj master‑slajd
- kopiuj master‑slajd
- zduplikuj master‑slajd
- nieużywany master‑slajd
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj master‑slajdami w Aspose.Slides dla .NET: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj master‑slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Slide master** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i stopki. W programie PowerPoint edycja slide mastera jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides dla .NET obsługuje ten sam model. Prezentacja może zawierać jedną lub więcej master‑slajdów, a każdy master‑slajd może zawierać kilka layout‑slajdów. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do master‑slajdu. Zamiast tego używają layout‑slajdu, a ten layout‑slajd należy do master‑slajdu.

Hierarchia wygląda następująco:

1. **Slide master** – definiuje wspólny projekt i motyw.  
1. **Layout slide** – definiuje konkretny układ placeholderów i formatowanie na poziomie layoutu.  
1. **Normal slide** – zawiera rzeczywistą treść prezentacji i używa jednego layout‑slajdu.

![Hierarchia master‑slajdów, layout‑slajdów i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides slide master jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/). Wszystkie master‑slajdy w prezentacji są dostępne poprzez kolekcję [Presentation.Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Gdy to samo właściwość jest zdefiniowana na kilku poziomach, wygrywa poziom bardziej szczegółowy. Na przykład, jeżeli master‑slajd i layout‑slajd definiują tło, slajdy oparte na tym layoutzie używają tła layoutu. Więcej informacji o layout‑slajdach znajdziesz w [Apply or Change Slide Layouts](/slides/pl/net/slide-layout/).
{{% /alert %}}

## **Dostęp do Slide Masterów**

W PowerPoint możesz otworzyć widok Slide Master z menu **Widok** > **Slide Master**.

![Polecenie Slide Master na karcie Widok w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `Masters`, aby uzyskać dostęp do master‑slajdów:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Możesz także pobrać master‑slajd używany przez zwykły slajd poprzez jego layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Co Zawiera Slide Master**

Master‑slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/), dzięki czemu udostępnia wiele tych samych właściwości slajdu, które są używane w slajdach normalnych i layout‑slajdach. Członkowie specyficzni dla master‑slajdu wymienieni są na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/).

Często używane członki master‑slajdu:

| Członek | Przeznaczenie |
| --- | --- |
| `Background` | Ustawia tło slajdu na poziomie master. |
| `Shapes` | Przechowuje kształty umieszczone na masterze, np. logotypy, ramki obrazów i wspólny tekst. |
| `LayoutSlides` | Przechowuje layout‑slajdy należące do mastera. |
| `ThemeManager` | Udostępnia dostęp do API motywu mastera. |
| `HeaderFooterManager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego layoutów. |
| `GetDependingSlides` | Zwraca zwykłe slajdy zależne od mastera poprzez ich layouty. |

## **Dodanie Obrazu do Slide Mastera**

Gdy dodasz obraz do master‑slajdu, pojawi się on na slajdach korzystających z layoutów tego mastera. Jest to przydatne przy logotypach, znakach wodnych, dekoracyjnych pasach i innych powtarzalnych elementach wizualnych.

Poniższy przykład dodaje logotyp do pierwszego master‑slajdu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Więcej informacji o ramkach obrazów znajdziesz w [Picture Frame](/slides/pl/net/picture-frame/).

## **Kontrola Widoczności Grafik Mastera**

Użyj [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/showmastershapes/), aby ukryć dziedziczone grafiki mastera, takie jak logotypy lub dekoracyjne kształty, bez ich usuwania z mastera. Ustaw [Slide.ShowMasterShapes](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/showmastershapes/) na `false` na slajdzie, który ma te grafiki pominąć, i pozostaw `true` na slajdach, które mają je wyświetlać.

Poniższy, samodzielny przykład tworzy niebieski dekoracyjny pas na masterze oraz dwa slajdy używające tego samego pustego layoutu. Pas jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie wymaga żadnej wejściowej prezentacji ani obrazu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Przykład używa layoutu **Blank** dostarczonego z nową prezentacją i usuwa początkowe placeholdery ze slajdu.

### **Wybór Zakresu Ustawienia**

Zwykły slajd używa swojego mastera przez [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/) i [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/masterslide/). Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Ustawienie [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/showmastershapes/) na `false` ukrywa grafiki mastera dla wszystkich slajdów korzystających z tego współdzielonego layoutu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafiki tylko na jednym slajdzie, zmień właściwość slajdu i pozostaw niezmieniony współdzielony layout.

Ustawienie to nie jest obsługiwane jako kontrola widoczności bezpośrednio na master‑slajdzie. Na masterze zawsze zwraca `false`, a przypisanie `true` generuje `NotSupportedException`. Zastosuj je do zwykłego slajdu lub layoutu.

### **Rozróżnienie Grafik od Tła**

| Operacja | Efekt |
| --- | --- |
| Ukrycie grafik mastera | Kontroluje widoczność dziedziczonych kształtów mastera bez ich usuwania ani zmiany własnych kształtów slajdu. |
| Zmiana wypełnienia tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafiki mastera są odrębnymi kształtami i mogą pozostać widoczne nad tłem. Zobacz [Presentation Background](/slides/pl/net/presentation-background/). |
| Usunięcie kształtu z mastera | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu korzystającego z tego mastera. |

## **Praca z Placeholderami**

Placeholdery są zazwyczaj definiowane w layout‑slajdach. Master‑slajd zapewnia wspólny styl i motyw, które layouty dziedziczą, a każdy layout decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W PowerPoint polecenia placeholderów są dostępne w widoku Slide Master.

![Polecenie Wstaw Placeholder w widoku Slide Master w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery przy użyciu Aspose.Slides, pracuj z layout‑slajdem należącym do mastera:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Możesz także formatować kształty placeholderów, które już istnieją na master‑slajdzie. Poniższy przykład znajduje placeholder tytułu i stosuje liniowe wypełnienie gradientowe:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Sformatowany placeholder tytułu dziedziczony przez zwykłe slajdy](slide-master_8.png)

Więcej opcji formatowania placeholderów i tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/net/manage-placeholder/) oraz [Text Formatting](/slides/pl/net/text-formatting/).

## **Zmiana Tła Slide Mastera**

Tło mastera jest dziedziczone przez layouty i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego master‑slajdu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Powiązane tematy: [Presentation Background](/slides/pl/net/presentation-background/) i [Presentation Theme](/slides/pl/net/presentation-theme/).

## **Klonowanie Slide Mastera do Innej Prezentacji**

Użyj [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/), aby skopiować master‑slajd do innej prezentacji. Skopiowany master może być następnie używany przez layouty i slajdy w prezentacji docelowej.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Jeśli potrzebujesz sklonować zwykłe slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/net/clone-slides/).

## **Dodawanie Wielu Slide Masterów**

Prezentacja może zawierać wiele master‑slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych elementów identyfikacyjnych, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania master‑slajdami](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy layout pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym layoutcie:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Porównywanie Slide Masterów**

Master‑slajdy można porównać przy użyciu metody `Equals` odziedziczonej z [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdów, ani dynamicznych wartości placeholderów, np. bieżącej daty.

```csharp
using Aspose.Slides;

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

Więcej informacji znajdziesz w [Compare Presentation Slides](/slides/pl/net/compare-slides/).

## **Ustawienie Widoku Slide Master jako Domyślnego Widoku**

Użyj właściwości `LastView` na [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/net/save-presentation/).

## **Usuwanie Nieużywanych Master‑slajdów**

Prezentacje czasami zawierają master‑slajdy, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslidecollection/removeunused/), aby usunąć nieużywane master‑slajdy z kolekcji `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Możesz także skorzystać z niskokodowego metody [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między slide masterem a layout‑slajdem?**

Slide master definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Layout‑slajd należy do mastera i określa konkretny układ placeholderów. Zwykły slajd używa layout‑slajdu, więc dziedziczy zarówno po layoutzie, jak i po masterze.

**Czy jedna prezentacja może zawierać kilka slide masterów?**

Tak. Prezentacja może mieć wiele slide masterów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub identyfikacji marki.

**Czy powinienem dodawać placeholdery do master‑slajdu czy do layout‑slajdu?**

W większości przypadków dodawaj placeholdery do layout‑slajdów. Umieść wspólne elementy wizualne i wspólne formatowanie na master‑slajdzie, a placeholdery treści na layoutach, które będą używane przez zwykłe slajdy.

**Czy mogę usunąć master‑slajd, który jest jeszcze używany?**

Nie. Master‑slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty. Najpierw przenieś te slajdy do layoutów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te, które nie są używane.