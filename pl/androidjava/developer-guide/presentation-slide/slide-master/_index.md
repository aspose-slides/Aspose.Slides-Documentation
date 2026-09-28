---
title: Zarządzanie masterami slajdów prezentacji na Androidzie
linktitle: Master slajdu
type: docs
weight: 70
url: /pl/androidjava/slide-master/
keywords:
- master slajdu
- master slajd
- PPT master slajd
- wiele master slajdów
- porównywanie master slajdów
- tło
- element zastępczy
- klonowanie master slajdu
- kopiowanie master slajdu
- duplikowanie master slajdu
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla Androida za pomocą Javy: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

A **master slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu i ustawienia stopki. W programie PowerPoint edytowanie mastera slajdów jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Android via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master slajdu może zawierać kilka slajdów układu. Normalne slajdy zazwyczaj nie odwołują się bezpośrednio do mastera slajdu. Zamiast tego normalny slajd używa slajdu układu, a ten slajd układu należy do mastera slajdu.

Hierarchia jest:

1. **Master slajdu** – definiuje wspólny projekt i motyw.  
1. **Slajd układu** – definiuje konkretne rozmieszczenie elementów zastępczych i formatowanie na poziomie układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia masterów slajdów, slajdów układu i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajdu jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) . Wszystkie master slajdy w prezentacji są dostępne poprzez kolekcję [Presentation.getMasters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getMasters--) , która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/). Aby zobaczyć pełną powierzchnię API Android via Java, zobacz referencję API [com.aspose.slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Gdy to samo właściwość jest zdefiniowane na więcej niż jednym poziomie, wygrywa bardziej szczegółowy poziom. Na przykład, jeśli master slajdu i slajd układu definiują tło, slajdy oparte na tym układzie używają tła układu. Aby uzyskać więcej informacji o slajdach układu, zobacz [Apply or Change Slide Layouts](/slides/pl/androidjava/slide-layout/).
{{% /alert %}}

## **Dostęp do masterów slajdów**

W PowerPoint możesz otworzyć widok Master slajdów z **Widok** > **Master slajdów**.

![Polecenie Master slajdów na karcie Widok w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `getMasters()` aby uzyskać dostęp do masterów slajdów:

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

Możesz także pobrać master slajdu używany przez normalny slajd poprzez jego układ:

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

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez normalne i układowe slajdy.

Często używane członki mastera slajdu obejmują:

| Członek | Zastosowanie |
| --- | --- |
| `getBackground()` | Ustawia tło slajdu na poziomie mastera. |
| `getShapes()` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazu i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu należące do mastera. |
| `getThemeManager()` | Udostępnia dostęp do API motywu mastera. |
| `getHeaderFooterManager()` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego układów podrzędnych. |
| `getDependingSlides()` | Zwraca normalne slajdy zależne od mastera poprzez ich układy. |

## **Dodaj obraz do mastera slajdu**

Po dodaniu obrazu do mastera slajdu pojawia się on na slajdach używających układów z tego mastera. Jest to przydatne dla logotypów, znaków wodnych, ozdobnych pasków i innych powtarzających się elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

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

Aby uzyskać więcej informacji o ramkach obrazu, zobacz [Picture Frame](/slides/pl/androidjava/picture-frame/).

## **Kontroluj widoczność grafiki mastera**

Użyj [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) aby ukryć dziedziczoną grafikę mastera, taką jak loga lub ozdobne kształty, bez usuwania ich z mastera. Przekaż `false` do [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) na slajdzie, który ma pominąć tę grafikę i pozostaw `true` na slajdach, które mają ją wyświetlać.

Poniższy przykład samodzielny tworzy niebieski ozdobny pasek na masterze i dwa slajdy używające tego samego pustego układu. Pasek jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie wymaga żadnej wejściowej prezentacji ani obrazu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

Przykład używa układu **Blank** dostarczonego z nową prezentacją i usuwa początkowe elementy zastępcze slajdu.

### **Wybierz zakres ustawienia**

Normalny slajd używa swojego mastera poprzez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getLayoutSlide--) i [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Przekazanie `false` do [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) ukrywa grafikę mastera dla slajdów używających tego współdzielonego układu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafikę tylko na jednym slajdzie, zmień właściwość slajdu i pozostaw niezmieniony wspólny układ.

Ustawienie nie jest obsługiwane jako kontrola widoczności na samym masterze slajdu. Na masterze, [getShowMasterShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) zawsze zwraca `false`, a przekazanie `true` do [setShowMasterShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) powoduje wyjątek. Zastosuj je do normalnego slajdu lub układu.

### **Rozróżnij grafikę od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mastera | Kontroluje widoczność dziedziczonych kształtów mastera bez ich usuwania lub zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mastera to oddzielne kształty i może pozostać widoczna na tym tle. Zobacz [Presentation Background](/slides/pl/androidjava/presentation-background/). |
| Usuń kształt z mastera | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu używającego tego mastera. |

## **Praca z elementami zastępczymi**

Elementy zastępcze są zwykle definiowane na slajdach układu. Master slajd zapewnia wspólny styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które elementy zastępcze są dostępne i gdzie są umieszczone.

W PowerPoint polecenia elementów zastępczych są dostępne w widoku Master slajdów.

![Polecenie Wstaw element zastępczy w widoku Master slajdów PowerPoint](slide-master_5.png)

Aby dodać nowe elementy zastępcze w Aspose.Slides, pracuj z slajdem układu należącym do mastera:

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

Możesz także formatować kształty elementów zastępczych, które już istnieją na masterze. Poniższy przykład znajduje element zastępczy tytułu i stosuje liniowe wypełnienie gradientem:

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

![Sformatowany element zastępczy tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Aby uzyskać więcej opcji formatowania elementów zastępczych i tekstu, zobacz [Set Prompt Text in Placeholder](/slides/pl/androidjava/manage-placeholder/) i [Text Formatting](/slides/pl/androidjava/text-formatting/).

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

Dla powiązanych tematów zobacz [Presentation Background](/slides/pl/androidjava/presentation-background/) i [Presentation Theme](/slides/pl/androidjava/presentation-theme/).

## **Klonuj master slajdu do innej prezentacji**

Użyj [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) aby skopiować master slajdu do innej prezentacji. Skopiowany master może być następnie używany przez układy i slajdy w prezentacji docelowej.

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

Jeśli potrzebujesz sklonować normalne slajdy wraz z ich masterem, zobacz [Clone Slides](/slides/pl/androidjava/clone-slides/).

## **Dodaj wiele masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają innej identyfikacji wizualnej, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania masterami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

Master slajdy można porównać metodą `equals` dziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości elementów zastępczych, takich jak bieżąca data.

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

Dla uzyskania dalszych informacji zobacz [Compare Presentation Slides](/slides/pl/androidjava/compare-slides/).

## **Ustaw widok mastera slajdu jako domyślny widok**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdów:

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

Aby uzyskać więcej ustawień widoku, zobacz [Save Presentation](/slides/pl/androidjava/save-presentation/).

## **Usuń nieużywane mastery slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused`, aby usunąć nieużywane mastery z kolekcji `getMasters()`:

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

Możesz także użyć niskokodowej metody [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

Master slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera slajdu i definiuje konkretną aranżację elementów zastępczych. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje potrzebują różnych systemów wizualnych lub identyfikacji.

**Czy powinienem dodawać elementy zastępcze do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj elementy zastępcze do slajdów układu. Umieść współdzielone elementy wizualne i formatowanie na masterze, a elementy zawartości na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć master slajdu, który jest nadal używany?**

Nie. Master slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery niebędące w użyciu.