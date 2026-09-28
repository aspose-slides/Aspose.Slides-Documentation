---
title: "Zarządzanie masterami slajdów prezentacji w Javie"
linktitle: "Master slajdu"
type: docs
weight: 70
url: /pl/java/slide-master/
keywords:
- master slajdu
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównanie masterów slajdów
- tło
- placeholder
- klonowanie master slajdu
- kopiowanie master slajdu
- duplikowanie master slajdu
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla Javy: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

A **master slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i ustawienia stopki. W programie PowerPoint edycja mastera slajdów jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master slajdu może zawierać kilka slajdów układu. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do mastera slajdu. Zamiast tego zwykły slajd używa slajdu układu, który należy do mastera slajdu.

Hierarchia jest:

1. **Master slajdu** - definiuje wspólny projekt i motyw.  
1. **Slajd układu** - definiuje określone rozmieszczenie placeholderów i formatowanie na poziomie układu.  
1. **Zwykły slajd** - zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.  

![Hierarchia masterów slajdów, slajdów układu i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajdu jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/) . Wszystkie mastery slajdów w prezentacji są dostępne poprzez kolekcję [Presentation.getMasters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasters--) , która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Dziedziczenie" %}}
Kiedy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master slajd i slajd układu oba definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o slajdach układu znajdziesz w [Apply or Change Slide Layouts](/slides/pl/java/slide-layout/).
{{% /alert %}}

## **Dostęp do masterów slajdów**

W programie PowerPoint możesz otworzyć widok Master slajdu z **Widok** > **Master slajdu**.

![Polecenie Master slajdu na karcie Widok w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `getMasters()` , aby uzyskać dostęp do masterów slajdów:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Możesz również uzyskać master slajd używany przez zwykły slajd poprzez jego układ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Co zawiera master slajdu**

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez zwykłe i slajdy układu. Specyficzne elementy mastera wymienione są na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/) .

Często używane elementy mastera slajdu to:

| Członek | Cel |
| --- | --- |
| `getBackground()` | Ustawia tło slajdu na poziomie mastera. |
| `getShapes()` | Przechowuje kształty umieszczone na masterze, takie jak logotypy, ramki obrazu i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu należące do mastera. |
| `getThemeManager()` | Zapewnia dostęp do API motywu mastera. |
| `getHeaderFooterManager()` | Steruje nagłówkami, stopkami, datami i numerami slajdów dla mastera i jego podrzędnych układów. |
| `getDependingSlides()` | Zwraca zwykłe slajdy zależne od mastera poprzez ich układy. |

## **Dodaj obraz do mastera slajdu**

Kiedy dodajesz obraz do mastera slajdu, pojawia się on na slajdach korzystających z układów tego mastera. Jest to przydatne dla logotypów, znaków wodnych, ozdobnych pasów i innych powtarzających się elementów wizualnych.

Poniższy przykład dodaje logotyp do pierwszego mastera slajdu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Więcej informacji o ramkach obrazu znajdziesz w [Picture Frame](/slides/pl/java/picture-frame/).

## **Kontroluj widoczność grafiki mastera**

Użyj [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) , aby ukryć dziedziczoną grafikę mastera, taką jak logotypy lub ozdobne kształty, bez usuwania ich z mastera. Przekaż `false` do [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) na slajdzie, który ma pominąć te elementy, i pozostaw `true` na slajdach, które mają je wyświetlać.

Poniższy samodzielny przykład tworzy niebieski ozdobny pas na masterze oraz dwa slajdy korzystające z tego samego pustego układu. Pas jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie jest wymagane żadne wejściowe pliki prezentacji ani obrazu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przykład używa układu **Blank** dostarczonego z nową prezentacją i usuwa własne placeholdery początkowego slajdu.

### **Wybierz zakres ustawienia**

Zwykły slajd używa swojego mastera poprzez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getLayoutSlide--) i [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) . Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Przekazanie `false` do [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) ukrywa grafikę mastera dla wszystkich slajdów używających tego wspólnego układu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafikę tylko na jednym slajdzie, zmień właściwość tego slajdu i pozostaw wspólny układ niezmieniony.

Ustawienie nie jest obsługiwane jako kontrola widoczności bezpośrednio na masterze. Na masterze [getShowMasterShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/#getShowMasterShapes--) zawsze zwraca `false`, a przekazanie `true` do [setShowMasterShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) powoduje wyjątek. Zastosuj je na zwykłym slajdzie lub na układzie.

### **Rozróżnij grafikę od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mastera | Kontroluje widoczność dziedziczonych kształtów mastera bez usuwania ich ani zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mastera jest oddzielnym kształtem i może pozostać widoczna na tym tle. Zobacz [Presentation Background](/slides/pl/java/presentation-background/). |
| Usuń kształt z mastera | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu używającego tego mastera. |

## **Praca z placeholderami**

Placeholdery są zazwyczaj definiowane na slajdach układu. Master slajd zapewnia wspólny styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które placeholdery są dostępne i gdzie są rozmieszczone.

W programie PowerPoint polecenia placeholderów są dostępne w widoku Master slajdu.

![Polecenie Wstaw placeholder w widoku Master slajdu w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery przy użyciu Aspose.Slides, pracuj ze slajdem układu należącym do mastera:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz również sformatować istniejące już na masterze kształty placeholderów. Poniższy przykład znajduje placeholder tytułu i stosuje liniowe wypełnienie gradientem:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sformatowany placeholder tytułu dziedziczony przez zwykłe slajdy](slide-master_8.png)

Więcej opcji placeholderów i formatowania tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/java/manage-placeholder/) i [Text Formatting](/slides/pl/java/text-formatting/).

## **Zmień tło mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zobacz [Presentation Background](/slides/pl/java/presentation-background/) oraz [Presentation Theme](/slides/pl/java/presentation-theme/) po więcej tematów powiązanych.

## **Sklonuj master slajdu do innej prezentacji**

Użyj [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) , aby skopiować master slajd do innej prezentacji. Skopiowany master może być następnie używany przez układy i slajdy w docelowej prezentacji.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Jeśli potrzebujesz sklonować zwykłe slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/java/clone-slides/).

## **Dodaj wiele masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają odrębnych elementów brandingowych, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania masterami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Porównaj mastery slajdów**

Mastery slajdów mogą być porównywane metodą `equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdów, ani dynamicznych wartości placeholderów, np. bieżącej daty.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Więcej informacji znajdziesz w [Compare Presentation Slides](/slides/pl/java/compare-slides/).

## **Ustaw widok Master slajdu jako domyślny widok**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/) , aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Po więcej ustawień widoku zobacz [Save Presentation](/slides/pl/java/save-presentation/).

## **Usuń nieużywane mastery slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused` , aby usunąć nieużywane mastery z kolekcji `getMasters()` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także użyć metody niskokodowej [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między masterem slajdu a slajdem układu?**

Master slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera i określa konkretne rozmieszczenie placeholderów. Zwykły slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odrębnych systemów wizualnych lub brandingu.

**Czy powinienem dodać placeholdery do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj placeholdery do slajdów układu. Umieszczaj wspólne elementy wizualne i wspólne formatowanie na masterze, a placeholdery zawartości na układach, które będą używane przez zwykłe slajdy.

**Czy mogę usunąć master slajd, który jest nadal używany?**

Nie. Master slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te mastery, które nie są używane.