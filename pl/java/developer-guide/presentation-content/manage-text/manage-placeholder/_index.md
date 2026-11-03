---
title: Zarządzanie placeholderami prezentacji w języku Java
linktitle: Zarządzanie placeholderami
type: docs
weight: 10
url: /pl/java/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder zawartości
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazkowe, wykresu i zawartości oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla języka Java."
---
## **Przegląd**

Placeholder jest kształtem, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to tytuł, treść, obraz, wykres i placeholdery ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu nadrzędnego.

Aspose.Slides udostępnia informacje o placeholderach za pomocą metody [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/). Metoda zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazkowy, wykresu lub zawartości jest zwykle reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Placeholder zawartości może zawierać różne rodzaje treści. Sprawdź zarówno [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), jak i interfejs kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) opisuje rolę placeholdera; nie gwarantuje typu kształtu w czasie wykonywania. Zawsze używaj sprawdzania typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje style wielokrotnego użytku i, w niektórych przypadkach, placeholdery na poziomie mastera.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej normalnych slajdów i może dziedziczyć z mastera.
3. Normalny slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) aby przejść o jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder mastera. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

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

Edytowanie placeholdera na normalnym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edytowanie powiązanego układu lub mastera może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Lokalny zwykły kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Usunięcie statusu placeholdera**

Podczas adaptacji szablonu użyj [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) aby zachować istniejący obiekt jako zwykły kształt. Jego [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) zwraca `null`, ale kształt pozostaje w kolekcji slajdu. W przeciwieństwie do tego, [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga pliku `template.pptx` z co najmniej jednym slajdem i niepustym placeholderem tekstowym na pierwszym slajdzie. Użyj placeholdera z formatowaniem odziedziczonym z jego układu lub mastera, aby zobaczyć efekt usunięcia tego powiązania. Przykład sprawdza, że ten sam kształt pozostaje, ponownie wywołuje metodę na teraz zwykłym kształcie i zapisuje wynik.

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

        // Wywołanie metody na zwykłym kształcie nie ma wpływu.
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

Dla pasującego placeholdera wszystkie trzy sprawdzenia zwracają `true`. Tekst pozostaje, ale odziedziczona pozycja, rozmiar, rotacja, czcionka, wyrównanie akapitu, marginesy ramki tekstowej, pionowe kotwiczenie, wypełnienie i ustawienia linii mogą się zmienić po usunięciu powiązania placeholdera. Na przykład formatowanie tytułu dziedziczonego może przejść na zwykłe formatowanie tekstu. Zobacz [Slide Layout](/slides/pl/java/slide-layout/) po więcej informacji o układach.

Aby zachować zamierzony wygląd, przed wywołaniem przechwyć obliczoną pozycję, rozmiar i rotację oraz skopiuj wymagane wartości efektywnego formatowania do oddzielnych zmiennych. Pobierz te wartości poprzez [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), oraz [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Nie polegaj wyłącznie na obiektach efektywnego formatowania, ponieważ ich wartości formatowania tekstu mogą ulec zmianie po usunięciu powiązania. Następnie jawnie zastosuj przechwycone wartości do zwykłego kształtu, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstowej, wypełnienie i linię używaną w szablonie.

Dziedziczona geometria kształtu może również wymagać jawnego przypisania poprzez [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Dla prostokątnego placeholdera tekstowego oznacza to przypisanie [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); przywrócenie jedynie wypełnienia i linii może nie przywrócić widzialnego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają obsługi tych ustawień.

## **Zmiana tekstu w placeholderze**

Tytuł, tytuł wyśrodkowany, podtytuł, treść i placeholdery tekstowe zazwyczaj obsługują tekst. Sprawdź, czy kształt jest [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) przed użyciem jego metody [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

Poniższy przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

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

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub mediów na [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Identyfikuje również placeholder ze względu na przeznaczenie, zamiast polegać na kruchym indeksie kształtu.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w trybie projektowania w pustym placeholderze, np. *Kliknij, aby dodać tytuł*. Ustaw własny tekst podpowiedzi w placeholderze układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów normalnego slajdu. Uzyskaj dostęp do układu poprzez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) i iteruj po kolekcji zwróconej przez [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

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

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytorskich, takich jak PowerPoint. Gdy użytkownik lub program dostarczy rzeczywistą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), zamień obraz przy użyciu [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) oraz [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Jeśli jest to nadal pusty placeholder, dodaj ramkę obrazu w współrzędnych placeholdera przy pomocy [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) i usuń pusty placeholder.

Kolejny przykład obsługuje oba przypadki i zapisuje prezentację:

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

Zastępstwo utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) nie udostępnia settera. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie powiązania placeholdera jest kluczowe, przygotuj i wypełnij placeholder w PowerPoint najpierw, a następnie zaktualizuj wynikowy [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) przy użyciu Aspose.Slides.

W celu uzyskania przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Manage Picture Frames](/slides/pl/java/picture-frame/). Operacje te należą do ramki obrazu lub wypełnienia obrazu, a nie do metadanych placeholdera.

## **Praca z placeholderami wykresów i zawartości**

Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i interfejsie wykonawczym, zmienia jego tytuł i zapisuje plik:

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

Ogólny placeholder zawartości zwykle ma typ [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po jego wypełnieniu, sprawdź rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides nie przekształca pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) w [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) jedynie zmianą [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); typu nie można zmienić przez interfejs. Aby programowo wypełnić pusty wykres lub obszar zawartości, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych [chart management articles](/slides/pl/java/powerpoint-charts/) gdy potrzebujesz zamienić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy kompleksowy przykład otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

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

**Co to jest podstawowy placeholder?**

Podstawowy placeholder to odpowiedni kształt w układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułów jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówków i stopek w odpowiednim zakresie: slajd, układ, master, notatki lub rozdanie. Zobacz [Manage Presentation Header and Footer](/slides/pl/java/presentation-header-and-footer/) po pełne przykłady.