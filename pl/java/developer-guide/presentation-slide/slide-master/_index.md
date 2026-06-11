---
title: Zarządzanie masterami slajdów w Javie
linktitle: Master slajdu
type: docs
weight: 70
url: /pl/java/slide-master/
keywords:
- master slajdu
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównywanie masterów slajdów
- tło
- placeholder
- klonowanie master slajdu
- kopiowanie master slajdu
- duplikowanie master slajdu
- nieużywany master slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla Javy: uzyskuj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Master slajd** definiuje wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i stopki. W PowerPoint edycja mastera slajdu jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master slajdu może zawierać kilka slajdów układu. Normalne slajdy zazwyczaj nie odwołują się bezpośrednio do mastera. Zamiast tego, normalny slajd używa slajdu układu, który należy do mastera.

Hierarchia wygląda następująco:

1. **Master slajd** – definiuje współdzielony projekt i motyw.  
1. **Slajd układu** – definiuje konkretny układ placeholderów i formatowanie na poziomie układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia slajdów master, slajdów układu i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajd jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/). Wszystkie mastery slajdów w prezentacji są dostępne przez kolekcję [Presentation.getMasters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasters--) implementującą [IMasterSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Dziedziczenie" %}}

Gdy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master slajd i slajd układu definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o slajdach układu znajdziesz w [Apply or Change Slide Layouts](/slides/pl/java/slide-layout/).

{{% /alert %}}

## **Dostęp do masterów slajdów**

W PowerPoint możesz otworzyć widok Master slajdu z **Widok** > **Master slajdów**.

![Polecenie Master slajdów na karcie Widok w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `getMasters()` aby uzyskać dostęp do masterów slajdów:

```java
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

Możesz także pobrać master slajd używany przez normalny slajd poprzez jego układ:

```java
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

## **Co zawiera master slajd**

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez slajdy normalne i układu. Członkowie specyficzni dla mastera są wymienieni na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/).

Często używane członki mastera slajdu obejmują:

| Członek | Cel |
| --- | --- |
| `getBackground()` | Ustawia tło slajdu na poziomie mastera. |
| `getShapes()` | Przechowuje kształty umieszczone na masterze, takie jak logo, ramki obrazu i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu, które należą do mastera. |
| `getThemeManager()` | Udostępnia dostęp do API motywu mastera. |
| `getHeaderFooterManager()` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego podrzędnych układów. |
| `getDependingSlides()` | Zwraca normalne slajdy zależne od mastera poprzez ich układy. |

## **Dodanie obrazu do mastera slajdu**

Gdy dodasz obraz do mastera slajdu, pojawia się on na slajdach korzystających z układów tego mastera. Jest to przydatne przy logotypach, znakach wodnych, dekoracyjnych pasach i innych powtarzalnych elementach wizualnych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

```java
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

## **Praca z placeholderami**

Placeholdery są zazwyczaj definiowane na slajdach układu. Master slajd zapewnia wspólny styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W PowerPoint polecenia placeholderów są dostępne w widoku Master slajdu.

![Polecenie Wstaw placeholder w widoku Master slajdu w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery w Aspose.Slides, pracuj ze slajdem układu należącym do mastera:

```java
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

Możesz także formatować istniejące kształty placeholderów na masterze. Poniższy przykład znajduje placeholder tytułu i stosuje liniowe wypełnienie gradientowe:

```java
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sformatowany placeholder tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Więcej opcji formatowania placeholderów i tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/java/manage-placeholder/) oraz [Text Formatting](/slides/pl/java/text-formatting/).

## **Zmiana tła mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

```java
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

Powiązane tematy: [Presentation Background](/slides/pl/java/presentation-background/) i [Presentation Theme](/slides/pl/java/presentation-theme/).

## **Klonowanie mastera slajdu do innej prezentacji**

Użyj [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) aby skopiować master slajd do innej prezentacji. Skopiowany master może być następnie używany przez układy i slajdy w docelowej prezentacji.

```java
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

Jeśli potrzebujesz sklonować normalne slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/java/clone-slides/).

## **Dodanie wielu masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają innego brandingu, struktury stron lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania slajdami master](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```java
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

## **Porównywanie masterów slajdów**

Mastery slajdów można porównać metodą `equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdów, ani dynamicznych wartości placeholderów, takich jak bieżąca data.

```java
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

## **Ustawienie widoku Master slajdu jako domyślnego widoku**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/java/save-presentation/).

## **Usuwanie nieużywanych masterów slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused`, aby usunąć nieużywane mastery z kolekcji `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także użyć niskokodowej metody [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

```java
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

Master slajd definiuje współdzielone ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera i definiuje konkretny układ placeholderów. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają innych systemów wizualnych lub brandingu.

**Czy powinienem dodawać placeholdery do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj placeholdery do slajdów układu. Umieść wspólne elementy wizualne i formatowanie na masterze, a placeholdery treści na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć master slajd, który jest nadal używany?**

Nie. Master slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te, które nie są używane.