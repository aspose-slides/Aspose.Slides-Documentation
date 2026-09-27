---
title: Tworzenie prezentacji w Node.js za pośrednictwem .NET
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/nodejs-net/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- tworzenie PowerPoint
- tworzenie PPTX
- dodaj pole tekstowe
- dodaj slajd
- rozmiar slajdu
- szerokokątny
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz prezentacje PowerPoint w JavaScript przy użyciu Aspose.Slides dla Node.js za pośrednictwem .NET: dodaj pole tekstowe i slajdy, ustaw rozmiar slajdu 16:9 i zapisz wynik jako PPTX."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację przy użyciu Aspose.Slides for Node.js via .NET, dodać pole tekstowe do pierwszego slajdu i zapisać wynik jako plik PPTX. Pokazuje także, jak dodać kolejne slajdy oraz jak przełączyć prezentację na slajdy w formacie szerokokątnym (16:9).

Przykłady wymagają projektu skonfigurowanego zgodnie z opisem w [Instalacja](/slides/pl/nodejs-net/installation/). Zapisz każdy przykład jako plik `.js` w katalogu projektu i uruchom go z tego katalogu poleceniem `node`, na przykład `node create-presentation.js`.

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for Node.js via .NET nie posiada własnej dokumentacji API. Odzwierciedla API Aspose.Slides for .NET, używając nazw w stylu camelCase, więc linki API w tym artykule prowadzą do odpowiadających klas i członków w [dokumentacji API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Utworzenie prezentacji z polem tekstowym**

Aby utworzyć prezentację i umieścić pole tekstowe na jej pierwszym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Nowa prezentacja zawiera już jeden pusty slajd.  
1. Pobierz ten slajd z kolekcji [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Kolekcje w tym pakiecie odczytuje się metodą `get(index)`, a indeksy zaczynają się od 0.  
1. Dodaj prostokąt metodą [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) i ustaw [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) jego [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
1. Zapisz prezentację metodą [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) i wartością `SaveFormat.Pptx`.  
1. Wywołaj `dispose` w bloku `finally`, aby zwolnić zasoby .NET powiązane z prezentacją.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozycja (x, y) i rozmiar (szerokość, wysokość) są podawane w punktach.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Skrypt zapisuje `new-presentation.pptx` w katalogu projektu. Plik zawiera jeden slajd z wypełnionym prostokątem, którego lewy górny róg znajduje się 50 punktów od lewej i górnej krawędzi slajdu. Prostokąt ma szerokość 400 punktów i wysokość 100 punktów, a jego tekst jest wyśrodkowany. Jeden punkt to 1/72 cala. Bez licencji Aspose.Slides dodaje także znak wodny „Evaluation only” do slajdu; zobacz [Licencjonowanie](/slides/pl/nodejs-net/licensing/).

## **Dodawanie slajdów**

Nowa prezentacja ma jeden slajd. Aby dodać kolejne, przekaż slajd układu do metody [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) kolekcji `slides`. Metoda [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) kolekcji [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) zwraca pierwszy układ określonego typu [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

Poniższy przykład dodaje dwa slajdy z układem Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrypt wyświetla `Slide count: 3` i zapisuje `three-slides.pptx`. Nowe slajdy są dołączane po pierwszym i nie zawierają żadnych kształtów. Nowa prezentacja zawsze ma układ Blank, ale prezentacja otwarta z pliku może nie mieć układu żądanego typu; w takim wypadku `getByType` zwraca `null`, więc sprawdź wynik przed dalszym użyciem.

## **Ustawienie rozmiaru slajdu**

Nowa prezentacja używa slajdów 4:3 o wymiarach 720 × 540 punktów (10 × 7,5 cala). Aby zamiast tego utworzyć slajdy szerokokątne, wywołaj metodę [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) obiektu [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) prezentacji, podając wartość [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) oraz wartość [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Typ skalowania określa, co Aspose.Slides ma zrobić z istniejącymi już kształtami; `DoNotScale` pozostawia je bez zmian, co jest właściwym wyborem dla prezentacji, w której jeszcze nie ma treści.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrypt wyświetla `Slide size: 960 x 540 points`, co odpowiada 13,33 × 7,5 cala, i zapisuje `widescreen.pptx`. `SlideSizeType.OnScreen16x9` ma ten sam stosunek 16:9, ale jest mniejszy: 720 × 405 punktów.

## **FAQ**

**W jakich jednostkach mierzone są pozycje i rozmiary?**

W punktach. Jeden cal to 72 punkty, więc domyślny slajd 4:3 ma wymiary 720 × 540 punktów, a slajd szerokokątny 16:9 – 960 × 540 punktów.

**Do jakich formatów mogę zapisać nową prezentację?**

Do dowolnej wartości z enumeracji [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), na przykład `SaveFormat.Ppt` dla PowerPoint 97–2003, `SaveFormat.Odp` dla OpenDocument lub `SaveFormat.Pdf`. Informacje o konwersji do PDF znajdziesz w artykule [Konwertowanie PowerPoint na PDF](/slides/pl/nodejs-net/convert-powerpoint-to-pdf/).

**Dlaczego zapisana prezentacja zawiera tekst „Evaluation only”?**

Bez licencji Aspose.Slides dodaje znak wodny „Evaluation only” do zapisywanych slajdów. Aby go usunąć, zastosuj licencję zgodnie z opisem w [Licencjonowanie](/slides/pl/nodejs-net/licensing/).

**Dlaczego powinienem wywołać `dispose`?**

Obiekt `Presentation` jest powiązany z obiektem .NET, który zajmuje pamięć i inne zasoby. Wywołanie `dispose` zwalnia je natychmiast po zakończeniu korzystania z prezentacji, a umieszczenie tego wywołania w bloku `finally` zapewnia zwolnienie zasobów także w przypadku wystąpienia błędu.