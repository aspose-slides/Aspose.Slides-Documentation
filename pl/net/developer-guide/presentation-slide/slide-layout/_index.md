---
title: Zastosowanie lub zmiana układów slajdów w .NET
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/net/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
- projektowanie prezentacji
- projektowanie slajdów
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwie treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- C#
- .NET
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla .NET, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy obejmują:

- **Title Slide**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Title and Content**: Zawiera element zastępczy tytułu oraz uniwersalny element zastępczy treści.
- **Blank**: Nie zawiera elementów zastępczych treści i jest przydatny, gdy każdy kształt będzie pozycjonowany ręcznie.

## **Zrozum dziedziczenie układów**

Prezentacja ma trzy powiązane poziomy:

1. [master slide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/) określa motyw, współdzielone formatowanie, tła i wspólne obiekty.
2. [layout slide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/) należy do mastera i definiuje określone rozmieszczenie elementów zastępczych.
3. [normal slide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) używa jednego układu i przechowuje wprowadzoną treść dla tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie nadpisuje dziedziczoną wartość na tym poziomie. Podczas tworzenia normalnego slajdu, jego kształty elementów zastępczych są generowane z wybranego układu, podczas gdy treść wprowadzona do tych elementów należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie później kolejnego elementu zastępczego do układu nie spowoduje automatycznego dodania odpowiadającego kształtu elementu zastępczego do istniejących normalnych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementów zastępczych w układzie może zaktualizować wszystkie slajdy od niego zależne. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez jakiś slajd, nie może być usunięty. Najpierw przypisz jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/net/slide-master/).

Aby ukryć dziedziczone logo lub dekoracyjne kształty mastera na jednym slajdzie lub przy użyciu współdzielonego układu, zobacz [Control the Visibility of Master Graphics](/slides/pl/net/slide-master/). Przykład porównuje dwa slajdy używające tego samego mastera.

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym masterze. Jeśli ten układ nie jest dostępny, celowo przechodzi do **Blank**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie własne układy. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu za pomocą właściwości [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie oraz zgodność istniejących elementów zastępczych z nowym układem mogą się zmienić, dlatego sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to oddzielne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/masterlayoutslidecollection/add/) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w ramach kolekcji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Dodawaj układ tylko wtedy, gdy szablon rzeczywiście potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj elementy zastępcze do układu slajdu**

Właściwość [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/placeholdermanager/) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutplaceholdermanager/) służący do dodawania kształtów elementów zastępczych do układu.

| Element zastępczy PowerPoint | `ILayoutPlaceholderManager` Metoda |
| ---------------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Poniższy przykład sprawdza, czy układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd wykorzystujący zmodyfikowany układ. Kolejność jest celowa: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające kształty elementów zastępczych na tym slajdzie.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Wynik:

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych układu może wpływać na zależne slajdy. Nowo dodany element zastępczy układu nie jest automatycznie uzupełniany w istniejących normalnych slajdach. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), aby usunąć układy, do których nie odwołują się żadne normalne slajdy. Metoda pozostawia nienaruszone układy, które są nadal używane.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Aby usunąć konkretny układ, najpierw użyj jego właściwości [HasDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/hasdependingslides/) lub metody [GetDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/getdependingslides/). Przypisz ponownie wszystkie zależne slajdy przed wywołaniem [ILayoutSlide.Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/remove/). Próba usunięcia używanego układu powoduje zgłoszenie [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki na układzie slajdu**

Układ posiada własne elementy zastępcze stopki, numeru slajdu oraz daty i czasu. Użyj właściwości [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/headerfootermanager/), aby kontrolować te elementy zastępcze dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułowe nie.

Poniższy przykład bezpiecznie wybiera układ i sprawia, że jego elementy stopki są widoczne:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Kontroluj widoczność stopki w masterze i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj właściwości [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/headerfootermanager/). Metody propagacji z [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach slajdów i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między master slidem a layout slidem?**

Master slide definiuje motyw prezentacji i wspólne formatowanie. Layout slide należy do mastera i definiuje jedno wielokrotnego użytku rozmieszczenie elementów zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować layout slide z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do kolekcji docelowej metodą [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/globallayoutslidecollection/addclone/). Przy kopiowaniu między prezentacjami, sprawdź również czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się dzieje, gdy modyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria elementów zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [GetDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/getdependingslides/), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/). Najpierw przypisz ponownie zależne slajdy lub użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), aby usunąć tylko nieodwołane układy.