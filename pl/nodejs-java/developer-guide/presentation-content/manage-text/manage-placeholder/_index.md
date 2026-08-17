---
title: Zarządzanie placeholderami prezentacji w JavaScript
linktitle: Zarządzanie placeholderami
type: docs
weight: 10
url: /pl/nodejs-java/manage-placeholder/
keywords:
- placeholder
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder zawartości
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstu, obrazu, wykresu i zawartości oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla Node.js w Javie."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu głównego.

Aspose.Slides udostępnia informacje o placeholderze poprzez metodę [Shape.getPlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoda zwraca obiekt [Placeholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [Placeholder.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/#getType), aby określić, co placeholder ma zawierać.

Klasa kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstu, obrazu, wykresu lub zawartości jest zwykle reprezentowany przez [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/).
- Placeholder zawartości może zawierać kilka rodzajów treści. Sprawdź zarówno [Placeholder.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/#getType), jak i klasę kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/#getType) opisuje rolę placeholdera; nie gwarantuje on rzeczywistego typu kształtu w czasie wykonania. Zawsze używaj sprawdzania typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd główny definiuje wielokrotnie używalne style i, w niektórych przypadkach, placeholdery na poziomie master.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej zwykłych slajdów i może dziedziczyć z mastera.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getBasePlaceholder), aby przesunąć się o jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca placeholder układu; placeholder układu może zwrócić placeholder mastera. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wymienia placeholdery na pierwszym slajdzie i raportuje ich bazowe placeholdery:

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

Edycja placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może mieć wpływ na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Zmiana tekstu w placeholderze**

Placeholdery tytułu, tytułu wyśrodkowanego, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy jest to [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#getTextFrame).

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

Ten wzorzec unika traktowania placeholderów obrazu, wykresu, tabeli lub mediów jako obiektów [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/). Identyfikuje również placeholder według przeznaczenia, zamiast polegać na kruchym indeksie kształtu.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw własny tekst podpowiedzi na placeholderze układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów zwykłego slajdu. Uzyskaj dostęp do układu za pomocą [Slide.getLayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getLayoutSlide) i iteruj po kolekcji zwróconej przez [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getShapes).

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

Tekst podpowiedzi nie jest zwykłą treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytorskich, takich jak PowerPoint. Gdy użytkownik lub program dostarczy rzeczywistą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), zamień obraz poprzez [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#getPicture) oraz [Picture.setImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/#setImage).
- Jeśli nadal jest to pusty placeholder, dodaj ramkę obrazu w współrzędnych placeholdera za pomocą [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) i usuń pusty placeholder.

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

Zastąpienie utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [Shape.getPlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getPlaceholder) nie udostępnia settera. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie relacji placeholdera jest istotne, przygotuj i wypełnij placeholder w PowerPoint najpierw, a potem zaktualizuj wynikową [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

Aby uzyskać przezroczystość obrazu, przycinanie i inne efekty specyficzne dla obrazu, zobacz [Manage Picture Frames](/slides/pl/nodejs-java/picture-frame/). Te operacje należą do ramki obrazu lub wypełnienia obrazu, a nie do metadanych placeholdera.

## **Praca z placeholderami wykresów i zawartości**

Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i klasie wykonawczej, zmienia jego tytuł i zapisuje plik:

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

Ogólny placeholder zawartości zazwyczaj ma [PlaceholderType.Object](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Object). W PowerPoint działa jako uruchamiacz dla kilku typów zawartości, w tym wykresów, tabel, diagramów, obrazów i mediów. Po jego wypełnieniu należy sprawdzić rzeczywistą klasę kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Media) lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nie konwertuje pustego placeholdera [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) w [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/) jedynie przez zmianę [Placeholder.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/#getType); typ nie może być zmieniony przez obiekt. Aby programowo wypełnić pusty obszar wykresu lub zawartości, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Korzystaj z dedykowanych [artykułów o zarządzaniu wykresami](/slides/pl/nodejs-java/powerpoint-charts/), gdy potrzebujesz zamienić kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład końcowy otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub traktowania każdego placeholdera jako tego samego typu.

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

## **FAQ**

**Co to jest bazowy placeholder?**

Bazowy placeholder to odpowiedni kształt na układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getBasePlaceholder), aby go pobrać. Zwykły lokalny kształt zwróci `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułów jest przechowywana na zwykłych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, przeiteruj slajdy i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajd, układ, master, notatki lub materiały rozdawnicze. Zobacz [Manage Presentation Header and Footer](/slides/pl/nodejs-java/presentation-header-and-footer/) po pełne przykłady.