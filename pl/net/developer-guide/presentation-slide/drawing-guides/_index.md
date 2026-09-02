---
title: Zarządzanie prowadnicami rysunkowymi w prezentacjach w .NET
linktitle: Prowadnice rysunkowe
type: docs
weight: 85
url: /pl/net/drawing-guides/
keywords:
- prowadnica rysunkowa
- prowadnica pozioma
- prowadnica pionowa
- prowadnica wyrównania
- widok slajdu
- slajd master
- slajd układu
- master notatek
- master wersji rozdawniczej
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome i pionowe prowadnice rysunkowe w prezentacjach PowerPoint przy użyciu Aspose.Slides for .NET."
---
## **Przegląd**

Rysunkowe prowadnice to regulowane poziome i pionowe linie, które pomagają użytkownikom wyrównywać kształty konsekwentnie podczas edycji prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie doskonalono: aplikacja może zapisać te same pomoce wyrównywania, których autorzy powinni używać przy dodawaniu lub przemieszczaniu treści.

Rysunkowe prowadnice są pomocnikami edycji, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w wygenerowanym wyniku. Aspose.Slides for .NET udostępnia je za pośrednictwem interfejsu [IDrawingGuidesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguidescollection/) . Prowadnica jest reprezentowana przez [IDrawingGuide](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub mastera. Prowadnica pionowa wykorzystuje współrzędną poziomą, zazwyczaj pomiędzy zerem a szerokością slajdu. Prowadnica pozioma wykorzystuje współrzędną pionową, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodaj prowadnice do widoku slajdu**

Użyj [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/pl/net/aspose.slides/icommonslideviewproperties/drawingguides/) do zarządzania prowadnicami wyświetlanymi podczas edycji zwykłych slajdów. Wywołaj [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguidescollection/add/) z wartością [Orientation](https://reference.aspose.com/slides/pl/net/aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową prowadnicę po prawej stronie środka slajdu oraz jedną poziomą prowadnicę poniżej niego:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Dostęp do rysunkowych prowadnic**

Właściwość [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguidescollection/count/) oraz indeksator umożliwiają dostęp do istniejących prowadnic. Właściwości [IDrawingGuide.Orientation](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguide/position/) i [IDrawingGuide.Color](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguide/color/) można odczytywać i zmieniać.

Poniższy przykład odczytuje prowadnice widoku slajdu z prezentacji utworzonej powyżej:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Dodaj prowadnice do slajdów master i układu**

Slajd master oraz każdy z jego slajdów układu mogą mieć własne kolekcje rysunkowych prowadnic. Użyj [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/drawingguides/) dla slajdu master oraz [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/drawingguides/) dla slajdu układu.

Poniższy przykład dodaje pionową prowadnicę do pierwszego slajdu master oraz poziomą prowadnicę do pierwszego slajdu układu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Dodaj prowadnice do masterów notatek i wersji rozdawniczych**

Mastery notatek i mastery wersji rozdawniczych również obsługują rysunkowe prowadnice. Użyj [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslide/drawingguides/) i [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslide/drawingguides/) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych masterów, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) lub [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) tworzy domyślny master i go zwraca.

Poniższy przykład dodaje poziomą prowadnicę do mastera notatek oraz pionową prowadnicę do mastera wersji rozdawniczej:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Wyczyść rysunkowe prowadnice**

Wywołaj [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/idrawingguidescollection/clear/) , aby usunąć wszystkie prowadnice z danej kolekcji. Czyszczenie jednej kolekcji nie wpływa na prowadnice przechowywane w innym zakresie.

Poniższy przykład czyści prowadnice widoku slajdu oraz wszystkie prowadnice na masterach slajdów, slajdach układu, masterze notatek i masterze wersji rozdawniczej, bez tworzenia brakujących masterów:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy rysunkowe prowadnice pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**  
Nie. Rysunkowe prowadnice są pomocyami wyrównywania podczas edycji i nie są renderowane jako treść prezentacji.

**Czy rysunkową prowadnicę można dodać bezpośrednio do pojedynczego zwykłego slajdu?**  
Prowadnice edycyjne zwykłych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje prowadnic są dostępne dla masterów slajdów, slajdów układu, masterów notatek i masterów wersji rozdawniczej.

**Jakie jednostki są używane do określania pozycji prowadnic?**  
Pozycje podaje się w punktach, przy czym 72 punkty równa się jednemu calowi. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy wyczyszczenie rysunkowych prowadnic usuwa kształty lub zmienia treść slajdu?**  
Nie. Metoda `Clear` usuwa tylko prowadnice w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.