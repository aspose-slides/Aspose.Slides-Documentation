---
title: Zarządzanie placeholderami prezentacji w JavaScript
linktitle: Zarządzanie placeholderami
type: docs
weight: 10
url: /pl/nodejs-java/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazowe, wykresów i treści oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla Node.js przez Java."
---
## **Przegląd**

Placeholder jest kształtem, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowymi przykładami są placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu master.

Aspose.Slides udostępnia informacje o placeholderach poprzez metodę [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoda zwraca obiekt [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType), aby określić, co placeholder ma zawierać.

Klasa kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazu, wykresu lub treści jest zwykle reprezentowany przez [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Placeholder treści może zawierać różne rodzaje treści. Sprawdź zarówno [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType), jak i klasę kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) opisuje rolę placeholdera; nie gwarantuje on typu kształtu w czasie wykonywania. Zawsze sprawdzaj typ przed dostępem do tekstu, obrazu, wykresu, tabeli lub elementów specyficznych dla mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje style wielokrotnego użytku i, w niektórych przypadkach, placeholdery poziomu master.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej zwykłych slajdów i może dziedziczyć z mastera.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder), aby przejść jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca placeholder układu; placeholder układu może zwrócić placeholder master. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wypisuje placeholdery na pierwszym slajdzie i raportuje ich bazowe placeholdery:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Edytowanie placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edytowanie powiązanego układu lub mastera może wpływać na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Usunięcie statusu placeholdera**

Podczas dostosowywania szablonu użyj [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder), aby zachować istniejący obiekt jako zwykły kształt. Jego metoda [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) zwraca `null`, ale kształt pozostaje w kolekcji slajdu. Natomiast [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga pliku `template.pptx` zawierającego co najmniej jeden slajd oraz niepusty placeholder tekstowy na pierwszym slajdzie. Użyj placeholdera, którego formatowanie jest dziedziczone z układu lub mastera, aby zobaczyć efekt usunięcia tego powiązania. Przykład sprawdza, że ten sam kształt pozostaje, ponownie wywołuje metodę na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu placeholdera nie zachowuje automatycznie dziedziczonych ustawień wyglądu. Poniższy przykład celowo pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są w pełni dziedziczone, może po wywołaniu mieć współrzędne i wymiary równe zero i stać się niewidoczny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Wywołanie metody na zwykłym kształcie nie ma efektu.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Dla pasującego placeholdera wszystkie trzy sprawdzenia zwracają `true`. Tekst pozostaje, ale dziedziczone pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstowej, kotwiczenie pionowe, wypełnienie i ustawienia linii mogą się zmienić po usunięciu powiązania placeholdera. Na przykład dziedziczone formatowanie tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Slide Layout](/slides/pl/nodejs-java/slide-layout/) po więcej informacji o układach.

Aby zachować zamierzony wygląd, przed wywołaniem przechwyć rozwiązaną pozycję, rozmiar i obrót oraz skopiuj wymagane wartości formatowania efektywnego do oddzielnych zmiennych. Pobierz te wartości przez [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) i [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Nie polegaj wyłącznie na obiektach formatów efektywnych, ponieważ ich wartości formatowania tekstu mogą ulec zmianie po usunięciu powiązania. Następnie wyraźnie zastosuj przechwycone wartości do zwykłego kształtu, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstowej, wypełnienie i linię używaną w szablonie.

Dziedziczona geometria kształtu może również wymagać jawnego przypisania poprzez [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Dla prostokątnego placeholdera tekstowego oznacza to przypisanie [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); przywrócenie jedynie wypełnienia i linii może nie odtworzyć widzialnego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają również obsługi tych ustawień.

## **Zmienianie tekstu w placeholderze**

Placeholdery tytułu, wyśrodkowanego tytułu, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy kształt jest [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ten wzorzec unika traktowania placeholderów obrazu, wykresu, tabeli lub mediów jako obiektów [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Identyfikuje także placeholder według przeznaczenia, zamiast polegać na kruchym indeksie kształtu.

## **Ustawienie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi na placeholderze układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów zwykłego slajdu. Uzyskaj dostęp do układu poprzez [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) i iteruj po kolekcji zwróconej przez [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytujących, takich jak PowerPoint. Gdy użytkownik lub program wprowadzi rzeczywistą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), zamień obraz przy użyciu [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) oraz [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Jeśli nadal jest pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) i usuń pusty placeholder.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zastępstwo utworzone dla pustego placeholdera jest lokalną ramką obrazu, nie nowym placeholderem, ponieważ [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) nie udostępnia settera. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie powiązania placeholdera jest kluczowe, przygotuj i wypełnij placeholder w PowerPoint, a następnie zaktualizuj powstały [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

W sprawie przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Manage Picture Frames](/slides/pl/nodejs-java/picture-frame/). Operacje te dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i klasie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ogólny placeholder treści zwykle ma typ [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). W PowerPoint działa jako uruchamiacz dla różnych typów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po wypełnieniu, sprawdź rzeczywistą klasę kształtu, aby dowiedzieć się, co zawiera. Specjalne układy mogą również udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nie konwertuje pustego placeholdera [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) na [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) jedynie poprzez zmianę [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); typ nie może być zmieniony przez obiekt. Aby wypełnić pusty wykres lub obszar treści programowo, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Korzystaj z dedykowanych [chart management articles](/slides/pl/nodejs-java/powerpoint-charts/) gdy potrzebujesz zamienić kategorie, serie lub dane z skoroszytu.

## **Pełny przykład: aktualizacja treści tekstowej lub obrazowej**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub traktowania każdego placeholdera jako tego samego typu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Najczęściej zadawane pytania**

**Czym jest podstawowy placeholder?**

Podstawowy placeholder to odpowiadający mu kształt w układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder), aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów poprzez edycję placeholdera w układzie?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułów jest przechowywana na normalnych slajdach. Aby zastąpić faktyczny tekst tytułu w całej prezentacji, iteruj po slajdach i aktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajdu, układu, mastera, notatek lub wersji drukowanej. Zobacz [Manage Presentation Header and Footer](/slides/pl/nodejs-java/presentation-header-and-footer/) po pełne przykłady.