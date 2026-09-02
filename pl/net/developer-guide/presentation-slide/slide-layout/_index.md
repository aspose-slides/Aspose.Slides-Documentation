---
title: "Zastosowanie lub zmiana układów slajdów w .NET"
linktitle: "Układ slajdu"
type: docs
weight: 60
url: /pl/net/slide-layout/
keywords:
- "układ slajdu"
- "układ treści"
- "placeholder"
- "projektowanie prezentacji"
- "projektowanie slajdu"
- "nieużywany układ"
- "widoczność stopki"
- "slajd tytułowy"
- "tytuł i zawartość"
- "nagłówek sekcji"
- "dwa elementy treści"
- "porównanie"
- "tylko tytuł"
- "pusty układ"
- "treść z podpisem"
- "obraz z podpisem"
- "tytuł i pionowy tekst"
- "pionowy tytuł i tekst"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla .NET, dodawaj placeholdery, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie placeholderów, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia spójną strukturę slajdów, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy to:

- **Title Slide**: Zawiera placeholdery tytułu i podtytułu.
- **Title and Content**: Zawiera placeholder tytułu oraz ogólny placeholder treści.
- **Blank**: Nie zawiera placeholderów i jest przydatny, gdy wszystkie kształty będą pozycjonowane ręcznie.

## **Zrozumienie dziedziczenia układu**

Prezentacja posiada trzy powiązane poziomy:

1. [master slide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.
2. [layout slide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/) należy do mastera i określa konkretny układ placeholderów.
3. [normal slide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) używa jednego układu i przechowuje wprowadzoną treść tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie nadpisuje odziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego placeholdery są generowane na podstawie wybranego układu, a treść wprowadzona w tych placeholderach należy do normalnego slajdu.

Dodaj wymagane placeholdery do układu przed tworzeniem z niego slajdów. Dodanie kolejnego placeholdera do układu później nie spowoduje automatycznego dodania odpowiadającego kształtu placeholdera do istniejących normalnych slajdów.

Ta zależność ma dwa istotne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii placeholdera w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją używanego układu sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przed usunięciem najpierw przypisz jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Więcej informacji o najwyższym poziomie tej hierarchii znajdziesz w sekcji [Slide Master](/slides/pl/net/slide-master/).

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Title and Content** w pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie niestandardowe układy. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu poprzez właściwość [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje placeholderów, dziedziczone formatowanie oraz powiązania istniejących placeholderów z nowym układem mogą ulec zmianie, więc sprawdź wynik przy przełączaniu między znacząco różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/masterlayoutslidecollection/add/) na kolekcji układów wybranego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje na jego podstawie normalny slajd. Nazwy układów muszą być unikalne w kolekcji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Dodawaj układ tylko wtedy, gdy szablon rzeczywiście potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj placeholdery do układu slajdu**

Właściwość [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/placeholdermanager/) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów placeholderów do układu.

| Placeholder programu PowerPoint | Metoda `ILayoutPlaceholderManager` |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Poniższy przykład weryfikuje, że układ **Blank** istnieje, dodaje do niego cztery placeholdery, a następnie tworzy normalny slajd wykorzystujący zmodyfikowany układ. Kolejność jest zamierzona: placeholdery są dodawane przed stworzeniem normalnego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające im kształty placeholderów na tym slajdzie.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących placeholderów układu może wpłynąć na zależne slajdy. Nowo dodany placeholder układu nie jest automatycznie wstawiany do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nienaruszone układy wciąż używane.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Aby usunąć konkretny układ, najpierw użyj jego właściwości [HasDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/hasdependingslides/) lub metody [GetDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/getdependingslides/). Przed wywołaniem [ILayoutSlide.Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/remove/) przesuń wszystkie zależne slajdy. Próba usunięcia używanego układu spowoduje rzutowanie [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki w układzie slajdu**

Układ posiada własne placeholdery stopki, numeru slajdu i daty‑czasu. Użyj właściwości [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/headerfootermanager/), aby kontrolować te placeholdery dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopkę, a układy tytułowe nie.

Poniższy przykład bezpiecznie wybiera układ i udostępnia jego elementy stopki:

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

## **Kontroluj widoczność stopki w masterze i jego układach podrzędnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj właściwości [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/headerfootermanager/). Metody propagacji [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

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

**Jaka jest różnica między master slajdem a layout slajdem?**

Master slajd definiuje motyw prezentacji i wspólne formatowanie. Layout slajd należy do mastera i określa jedną wielokrotnego użytku aranżację placeholderów. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/globallayoutslidecollection/addclone/). Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby użyte w źródłowym układzie.

**Co się stanie, gdy zmodyfikuję układ już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria placeholderów i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [GetDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/getdependingslides/), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłosi [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), aby usunąć tylko niepowiązane układy.