---
title: Zarządzanie liniami pomocniczymi w prezentacjach w JavaScript
linktitle: Linie pomocnicze
type: docs
weight: 85
url: /pl/nodejs-java/drawing-guides/
keywords:
- linia pomocnicza
- linia pozioma
- linia pionowa
- linia wyrównania
- widok slajdu
- slajd wzorca
- slajd układu
- wzorzec notatek
- wzorzec materiałów rozdawniczych
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome oraz pionowe linie pomocnicze w prezentacjach PowerPoint przy użyciu Aspose.Slides for Node.js via Java."
---
## **Przegląd**

Linie pomocnicze są regulowanymi poziomymi i pionowymi liniami, które pomagają użytkownikom wyrównywać kształty konsekwentnie podczas edytowania prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie dopracowywać: aplikacja może zapisać te same pomoce wyrównywania, których autorzy powinni przestrzegać przy dodawaniu lub przemieszczaniu treści.

Linie pomocnicze są narzędziami edycyjnymi, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w renderowanym wyjściu. Aspose.Slides for Node.js via Java udostępnia je poprzez klasę [DrawingGuidesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/). Linia pomocnicza jest reprezentowana przez [DrawingGuide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub wzorca. Pionowa linia pomocnicza używa współrzędnej poziomej, zazwyczaj pomiędzy zerem a szerokością slajdu. Pozioma linia pomocnicza używa współrzędnej pionowej, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodawanie linii pomocniczych do widoku slajdu**

Użyj [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) aby zarządzać liniami pomocniczymi wyświetlanymi podczas edytowania zwykłych slajdów. Wywołaj [DrawingGuidesCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/#add) z wartością [Orientation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową linię pomocniczą po prawej stronie środka slajdu oraz jedną poziomą linię pomocniczą pod nią:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp do linii pomocniczych**

Metody [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/#getCount) oraz [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) zapewniają dostęp do istniejących linii pomocniczych. Metody [DrawingGuide.getOrientation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguide/#getPosition) i [DrawingGuide.getColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguide/#getColor) zwracają wartości, które można również zmienić za pomocą odpowiednich metod ustawiających.

Poniższy przykład odczytuje linie pomocnicze widoku slajdu z prezentacji utworzonej powyżej:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Dodawanie linii pomocniczych do slajdów wzorca i układu**

Wzorzec slajdu oraz każdy z jego slajdów układu mogą mieć własne kolekcje linii pomocniczych. Użyj [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) dla slajdu wzorca oraz [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) dla slajdu układu.

Poniższy przykład dodaje pionową linię pomocniczą do pierwszego slajdu wzorca oraz poziomą linię pomocniczą do pierwszego slajdu układu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodawanie linii pomocniczych do wzorców notatek i materiałów rozdawniczych**

Wzorce notatek i materiały rozdawnicze również obsługują linie pomocnicze. Użyj [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) oraz [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych wzorców, `MasterNotesSlideManager.setDefaultMasterNotesSlide` lub `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` tworzy domyślny wzorzec i zwraca go.

Poniższy przykład dodaje poziomą linię pomocniczą do wzorca notatek oraz pionową linię pomocniczą do wzorca materiałów rozdawniczych:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie linii pomocniczych**

Wywołaj [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/#clear) aby usunąć wszystkie linie pomocnicze z danej kolekcji. Czyszczenie jednej kolekcji nie wpływa na linie pomocnicze przechowywane w innym zakresie.

Poniższy przykład usuwa linie pomocnicze widoku slajdu oraz wszystkie linie pomocnicze na wzorcach slajdów, slajdach układu, wzorcu notatek i wzorcu materiałów rozdawniczych, nie tworząc brakujących wzorców:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy linie pomocnicze pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Linie pomocnicze są narzędziami wyrównywania podczas edycji i nie są renderowane jako zawartość prezentacji.

**Czy linię pomocniczą można dodać bezpośrednio do pojedynczego zwykłego slajdu?**

Linie pomocnicze edycji zwykłych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje linii pomocniczych są dostępne dla wzorców slajdów, slajdów układu, wzorców notatek i wzorców materiałów rozdawniczych.

**Jakie jednostki są używane dla pozycji linii pomocniczych?**

Pozycje podawane są w punktach, gdzie 72 punkty równa się jednemu calowi. Pozycje pionowe mierzone są od lewego brzegu, a pozycje poziome od górnego brzegu.

**Czy usuwanie linii pomocniczych usuwa kształty lub zmienia zawartość slajdu?**

Nie. Metoda [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/drawingguidescollection/#clear) usuwa tylko linie pomocnicze w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.