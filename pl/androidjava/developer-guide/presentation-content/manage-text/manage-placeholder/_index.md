---
title: Zarządzanie placeholderami prezentacji na Androidzie
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/androidjava/manage-placeholder/
keywords:
- element zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder zawartości
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazowe, wykresów oraz zawartości oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu głównego.

Aspose.Slides udostępnia informacje o placeholderze poprzez metodę [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/). Metoda zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po określeniu typu placeholdera:

- Pusty placeholder tekstu, obrazu, wykresu lub zawartości jest zwykle reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Placeholder zawartości może zawierać kilka rodzajów treści. Sprawdź zarówno [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) jak i interfejs kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) opisuje rolę placeholdera; nie gwarantuje typu kształtu w czasie wykonywania. Zawsze używaj sprawdzenia typu przed dostępem do tekstu, obrazu, wykresu, tabeli lub elementów specyficznych dla mediów.
{{% /alert %}}

## **Zrozum dziedziczenie placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd główny definiuje style wielokrotnego użycia i, w niektórych przypadkach, placeholdery na poziomie mastera.
2. Slajd układu definiuje układ używany przez jeden lub więcej normalnych slajdów i może dziedziczyć po masterze.
3. Normalny slajd zawiera placeholdery dla tego slajdu i może dziedziczyć po jego układzie.

Wywołaj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) aby przejść o jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder mastera. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wymienia placeholdery na pierwszym slajdzie i podaje ich bazowe placeholdery:

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

Edycja placeholdera na normalnym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może wpłynąć na wszystkie slajdy, które wciąż dziedziczą to ustawienie. Lokalny zwykły kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Usuń status placeholdera**

Podczas dostosowywania szablonu użyj [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) aby zachować istniejący obiekt jako zwykły kształt. Jego [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) zwraca `null`, ale kształt pozostaje w kolekcji slajdu. Natomiast [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga `template.pptx` z co najmniej jednym slajdem i niepustym placeholderem tekstowym na pierwszym slajdzie. Użyj placeholdera z formatowaniem dziedziczonym z jego układu lub mastera, aby zobaczyć efekt usunięcia tego powiązania. Przykład sprawdza, że ten sam kształt pozostaje, wywołuje metodę ponownie na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu placeholdera nie zachowuje automatycznie odziedziczonych ustawień wyglądu. Poniższy przykład celowo pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są całkowicie dziedziczone, może po wywołaniu mieć zerowe współrzędne i wymiary oraz stać się niewidoczny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Wywołanie metody na zwykłym kształcie nie ma efektu.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Dla pasującego placeholdera wszystkie trzy sprawdzenia wypisują `true`. Tekst pozostaje, ale odziedziczona pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstowej, pionowe zakotwiczenie, wypełnienie i ustawienia linii mogą się zmienić po usunięciu powiązania placeholdera. Na przykład, odziedziczone formatowanie tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Układ slajdu](/slides/pl/androidjava/slide-layout/) po więcej o układach.

Aby zachować zamierzony wygląd, przechwyć rozpoznaną pozycję, rozmiar i obrót przed wywołaniem i skopiuj wymagane efektywne wartości formatowania do oddzielnych zmiennych. Pobierz te wartości poprzez [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), i [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Nie polegaj wyłącznie na obiektach efektywnego formatowania, ponieważ ich wartości formatowania tekstu mogą się zmienić po usunięciu powiązania. Wyraźnie zastosuj przechwycone wartości do zwykłego kształtu po zakończeniu, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstowej, wypełnienie i linię używaną w szablonie.

Dziedziczona geometria kształtu może także wymagać jawnego przypisania poprzez [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Dla prostokątnego placeholdera tekstowego oznacza to przypisanie [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); przywrócenie tylko wypełnienia i linii może nie przywrócić widocznego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają również obsługi tych ustawień.

## **Zmień tekst w placeholderze**

Placeholdery tytułu, tytułu wyśrodkowanego, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy istnieje [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) przed użyciem jego metody [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

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

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub mediów do [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Identyfikuje także placeholder według przeznaczenia, zamiast polegać na kruchej indeksacji kształtów.

## **Ustaw tekst podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi w placeholderze układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów normalnego slajdu. Dostęp do układu uzyskaj przez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) i iteruj po kolekcji zwróconej przez [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

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

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytujących, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje się wyświetlać. Zmiana podpowiedzi nie nadpisuje istniejącego tekstu na slajdach wykorzystujących dany układ.

## **Zaktualizuj placeholder obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), zamień obraz poprzez [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) i [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Jeśli jest to nadal pusty placeholder, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) i usuń pusty placeholder.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

Zastępstwo stworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) nie udostępnia settera. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli istotne jest zachowanie powiązania placeholdera, najpierw przygotuj i wypełnij placeholder w PowerPoint, a potem zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) przy użyciu Aspose.Slides.

W sprawie przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Zarządzanie klatkami obrazu](/slides/pl/androidjava/picture-frame/). Te operacje dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Pracuj z placeholderami wykresów i zawartości**

Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i interfejsie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

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

Ogólny placeholder zawartości zazwyczaj ma [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów zawartości, w tym wykresów, tabel, diagramów, obrazów i mediów. Po wypełnieniu go, sprawdź rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą także eksponować [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) w [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) jedynie poprzez zmianę [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); typ nie może być zmieniony przez interfejs. Aby programowo wypełnić pusty obszar wykresu lub zawartości, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy po placeholderze układu. Użyj dedykowanych [artykuły o zarządzaniu wykresami](/slides/pl/androidjava/powerpoint-charts/) kiedy potrzebujesz zastąpić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład end-to-end otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

**Co to jest bazowy placeholder?**

Bazowy placeholder to odpowiadający kształt w układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów edytując placeholder układu?**

Możesz zmienić odziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zamienić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i aktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajdu, układu, mastera, notatek lub wersji do rozdania. Zobacz [Zarządzanie nagłówkiem i stopką prezentacji](/slides/pl/androidjava/presentation-header-and-footer/) po pełne przykłady.