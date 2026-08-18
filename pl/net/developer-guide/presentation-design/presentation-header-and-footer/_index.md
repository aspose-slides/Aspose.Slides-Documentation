---
title: Zarządzanie nagłówkami i stopkami prezentacji w .NET
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/net/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiały rozdawnicze
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty i godziny, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach rozdawniczych przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides dla .NET umożliwia kontrolowanie tekstu i widoczności tych pól zastępczych za pomocą interfejsów menedżera nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz materiałów rozdawniczych | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie posiada pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i materiałach rozdawniczych. Dla zwykłych slajdów należy używać pól zastępczych stopki, daty/godziny oraz numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Interfejs [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/islideheaderfootermanager/) kontroluje jeden zwykły slajd. Interfejs [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/inotesslideheaderfootermanager/) kontroluje jeden slajd notatek. Menedżerowie mistrza i układu mogą także propagować ustawienia do slajdów zależnych, podczas gdy interfejs [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslideheaderfootermanager/) kontroluje mistrz materiałów rozdawniczych.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych oraz zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc wystarczy kontrolować ich widoczność.

Użyj [`SetFooterText`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) i [`SetDateTimeText`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/), aby ustawić tekst, oraz [`SetFooterVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), i [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/), aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład end‑to‑end stosuje tę samą stopkę, tekst daty/godziny oraz widoczność numeru slajdu do wszystkich zwykłych slajdów:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Jeśli musisz zaktualizować tylko jeden slajd, uzyskaj dostęp do tego slajdu bezpośrednio poprzez kolekcję [`Slides`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/), zamiast iterować po całej kolekcji.

## **Ustaw nagłówki i stopki w mistrzu notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj interfejsu [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslideheaderfootermanager/) gdy chcesz zmienić tylko sam mistrz notatek.

Poniższy przykład ustawia nagłówek, stopkę i tekst daty/godziny w mistrzu notatek oraz sprawia, że wszystkie obsługiwane pola zastępcze są widoczne w tym mistrzu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Właściwość [`MasterNotesSlide`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslidemanager/masternotesslide/) zwraca `null`, gdy prezentacja nie zawiera mistrza notatek.

## **Zastosuj ustawienia mistrza notatek do podrzędnych slajdów notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki do siebie oraz do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji w interfejsie [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslideheaderfootermanager/) gdy te same ustawienia mają być zastosowane w całej hierarchii notatek.

Na przykład, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) i [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizują nagłówek mistrza notatek oraz wszystkie nagłówki podrzędne. Równoważne metody są dostępne dla stopek, daty/godziny i numerów slajdów.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Metody propagacji użyte powyżej to [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), i [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ustaw nagłówki i stopki na pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego interfejsu [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/inotesslideheaderfootermanager/) gdy chcesz spersonalizować tylko tę stronę notatek.

Metoda [`AddNotesSlide`](https://reference.aspose.com/slides/pl/net/aspose.slides/inotesslidemanager/addnotesslide/) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Jeśli najpierw rozpowszechnisz ustawienia z mistrza notatek, a następnie zmienisz pojedynczy slajd notatek, późniejsze ustawienia indywidualne umożliwiają niezależną modyfikację tej strony notatek.

## **Ustaw nagłówki i stopki w mistrzu materiałów rozdawniczych**

Strony materiałów rozdawniczych używają mistrza materiałów rozdawniczych jako pola zastępcze nagłówka, stopki, daty/godziny i numeru strony. W przeciwieństwie do stron notatek, ustawienia materiałów rozdawniczych są zarządzane przez mistrza materiałów rozdawniczych, a nie przez pojedyncze slajdy rozdawnicze.

Użyj własności [`MasterHandoutSlide`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/), aby uzyskać dostęp do mistrza materiałów rozdawniczych. Jeśli nie istnieje, wywołaj [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/), aby utworzyć domyślnego mistrza materiałów rozdawniczych.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki odpowiadającego zakresowi, który chcesz zmienić:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/islideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslideheaderfootermanager/) kontroluje slajd układu i może propagować obsługiwane ustawienia do slajdów zależnych.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslideheaderfootermanager/) kontroluje zwykły szablon slajdów i może propagować obsługiwane ustawienia do slajdów zależnych.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslideheaderfootermanager/) kontroluje mistrz notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/inotesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje pole zastępcze nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslideheaderfootermanager/) zmienia mistrz materiałów rozdawniczych i obsługuje wszystkie cztery typy pól zastępczych.

Użyj propagacji z mistrza lub układu, gdy to samo ustawienie ma obowiązywać w całej jego hierarchii. Użyj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebne jest lokalne ustawienie dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola zastępcze nagłówka są dostępne na stronach notatek i materiałach rozdawniczych.

**Co zrobić, jeśli pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład [`IsFooterVisible`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) informuje, czy pole zastępcze stopki jest obecne, a [`SetFooterVisibility`](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Ustaw właściwość [`FirstSlideNumber`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/firstslidenumber/) prezentacji. Pola zastępcze numeru slajdu będą wtedy używać zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z resztą treści prezentacji w formacie wyjściowym. Ich wygląd zależy od eksportowanego typu strony oraz odpowiednich ustawień widoczności pól zastępczych.