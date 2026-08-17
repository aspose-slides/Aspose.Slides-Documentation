---
title: Zarządzanie placeholderami prezentacji w Javie
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/java/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstu, obrazu, wykresu i treści oraz zrozumieć dziedziczenie placeholderów w Aspose.Slides dla Javy."
---
## **Przegląd**

Placeholder jest kształtem, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu i ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu master.

Aspose.Slides udostępnia informacje o placeholderze poprzez metodę [IShape.getPlaceholder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/). Metoda zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [IPlaceholder.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholder/), aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po określeniu typu placeholdera:

- Pusty placeholder tekstu, obrazu, wykresu lub treści jest zazwyczaj reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/).
- Placeholder treści może zawierać kilka rodzajów treści. Sprawdź zarówno [IPlaceholder.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholder/), jak i interfejs kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Ostrzeżenie" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholder/) opisuje rolę placeholdera; nie gwarantuje on typu kształtu w czasie wykonywania. Zawsze wykonuj sprawdzenie typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje wielokrotnego użytku style i, w niektórych przypadkach, placeholdery na poziomie master.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej normalnych slajdów i może dziedziczyć z master.
3. Normalny slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), aby przejść o poziom wyżej w tej hierarchii. Placeholder slajdu zwykle zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder master. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wymienia placeholdery na pierwszym slajdzie i raportuje ich bazowe placeholdery:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Edycja placeholdera na normalnym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć tylko dlatego, że zajmuje te same współrzędne.

## **Zmienianie tekstu w placeholderze**

Placeholdery tytułu, wyśrodkowanego tytułu, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy to [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub mediów do [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/). Identyfikuje również placeholder po przeznaczeniu, zamiast polegać na kruchym indeksie kształtu.

## **Ustaw tekst podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi na placeholderze układu, zamiast próbować sięgnąć po niego przez kolekcję kształtów normalnego slajdu. Dostęp do układu uzyskaj przez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/) i iteruj po kolekcji zwróconej przez [ILayoutSlide.getShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tekst podpowiedzi nie jest zwykłą treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edycyjnych, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach, które używają tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/), zamień obraz przez [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/) i [ISlidesPicture.setImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/).
- Jeśli jest nadal pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/) i usuń pusty placeholder.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zastąpienie utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape.getPlaceholder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) nie udostępnia setteru. Zachowuje ono zarezerwowaną pozycję, ale nie dziedziczy już zachowania specyficznego dla placeholdera. Jeśli zachowanie relacji placeholdera jest kluczowe, przygotuj i wypełnij placeholder w PowerPoint najpierw, a następnie zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) przy użyciu Aspose.Slides.

W sprawie przeźroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu zobacz [Manage Picture Frames](/slides/pl/java/picture-frame/). Te operacje należą do ramki obrazu lub wypełnienia obrazu, nie do metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i po interfejsie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ogólny placeholder treści zwykle ma [PlaceholderType.Object](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po wypełnieniu, sprawdź rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą także udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/), lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) w [IChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/) jedynie przez zmianę [IPlaceholder.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/placeholder/); typ nie może być zmieniony przez interfejs. Aby programowo wypełnić pusty obszar wykresu lub treści, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Używaj dedykowanych [artykułów o zarządzaniu wykresami](/slides/pl/java/powerpoint-charts/), gdy potrzebujesz zastąpić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czym jest bazowy placeholder?**

Bazowy placeholder to odpowiadający mu kształt na układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi przez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakreślonym slajdzie, układzie, masterze, notatkach lub materiałach rozdawniczych. Zobacz [Manage Presentation Header and Footer](/slides/pl/java/presentation-header-and-footer/) po pełne przykłady.