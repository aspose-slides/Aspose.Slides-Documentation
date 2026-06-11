---
title: Zarządzanie masterami slajdów prezentacji na Androidzie
linktitle: Master slajd
type: docs
weight: 70
url: /pl/androidjava/slide-master/
keywords:
- master slajdu
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównanie masterów slajdów
- tło
- element zastępczy
- klonuj master slajd
- kopiuj master slajd
- duplikuj master slajd
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla Androida przy użyciu Javy: uzyskuj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Master slajdów** definiuje wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu oraz stopki. W programie PowerPoint edycja mastera slajdów jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides dla Android via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master może zawierać kilka slajdów układu. Normalne slajdy zwykle nie odwołują się bezpośrednio do mastera. Zamiast tego używają slajdu układu, który należy do mastera slajdów.

Hierarchia wygląda następująco:

1. **Master slajdów** – definiuje wspólny projekt i motyw.  
1. **Slajd układu** – definiuje konkretny układ elementów zastępczych i formatowanie na poziomie układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i korzysta z jednego slajdu układu.

![Hierarchia masterów slajdów, slajdów układu i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajdu jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/). Wszystkie mastery slajdów w prezentacji są dostępne poprzez kolekcję [Presentation.getMasters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getMasters--) implementującą [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/). Pełną powierzchnię API Android via Java znajdziesz w [odniesieniu API com.aspose.slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Gdy to samo własność jest zdefiniowane na kilku poziomach, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master slajdów i slajd układu definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o slajdach układu znajdziesz w [Zastosuj lub zmień układy slajdów](/slides/pl/androidjava/slide-layout/).
{{% /alert %}}

## **Dostęp do masterów slajdów**

W programie PowerPoint możesz otworzyć widok Master slajdów z **Widok** > **Master slajdów**.

![Polecenie Master slajdów na karcie Widok w programie PowerPoint](slide-master_3.jpg)

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

Możesz także pobrać master slajdu używany przez normalny slajd poprzez jego układ:

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

## **Co zawiera master slajdu**

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez slajdy normalne i układu.

Typowo używane członkowie mastera slajdu to:

| Członek | Przeznaczenie |
| --- | --- |
| `getBackground()` | Ustawia tło na poziomie mastera. |
| `getShapes()` | Przechowuje kształty umieszczone na masterze, takie jak logotypy, ramki obrazów i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu należące do mastera. |
| `getThemeManager()` | Udostępnia dostęp do interfejsów API motywu mastera. |
| `getHeaderFooterManager()` | Steruje nagłówkami, stopkami, datami i numerami slajdów dla mastera i jego układów podrzędnych. |
| `getDependingSlides()` | Zwraca normalne slajdy, które zależą od mastera poprzez ich układy. |

## **Dodanie obrazu do mastera slajdu**

Kiedy dodasz obraz do mastera slajdu, pojawi się on na slajdach korzystających z układów z tego mastera. Jest to przydatne przy logotypach, znakach wodnych, dekoracyjnych pasach i innych powtarzających się elementach wizualnych.

Poniższy przykład dodaje logotyp do pierwszego mastera slajdu:

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

Więcej informacji o ramkach obrazu znajdziesz w [Ramka obrazu](/slides/pl/androidjava/picture-frame/).

## **Praca z elementami zastępczymi**

Elementy zastępcze są zazwyczaj definiowane na slajdach układu. Master slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, natomiast każdy układ decyduje, które elementy zastępcze są dostępne i gdzie są umieszczone.

W programie PowerPoint polecenia elementów zastępczych są dostępne w widoku Master slajdów.

![Polecenie Wstaw element zastępczy w widoku Master slajdów w programie PowerPoint](slide-master_5.png)

Aby dodać nowe elementy zastępcze w Aspose.Slides, pracuj ze slajdem układu należącym do mastera:

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

Możesz także formatować istniejące kształty elementów zastępczych na masterze. Poniższy przykład znajduje element zastępczy tytułu i stosuje wypełnienie gradientem liniowym:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

Więcej opcji formatowania elementów zastępczych i tekstu znajdziesz w [Ustaw tekst podpowiedzi w elemencie zastępczym](/slides/pl/androidjava/manage-placeholder/) oraz [Formatowanie tekstu](/slides/pl/androidjava/text-formatting/).

## **Zmiana tła mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolite tło koloru dla pierwszego mastera slajdu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Powiązane tematy: [Tło prezentacji](/slides/pl/androidjava/presentation-background/) oraz [Motyw prezentacji](/slides/pl/androidjava/presentation-theme/).

## **Klonowanie mastera slajdu do innej prezentacji**

Użyj [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) aby skopiować master slajdu do innej prezentacji. Skopiowany master może następnie być używany przez układy i slajdy w docelowej prezentacji.

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

Jeśli potrzebujesz sklonować normalne slajdy wraz z ich masterem, zobacz [Klonowanie slajdów](/slides/pl/androidjava/clone-slides/).

## **Dodanie wielu masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych elementów brandingowych, struktury strony lub ustawień motywu.

![Polecenia programu PowerPoint do wstawiania i zarządzania masterami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

Mastery slajdów można porównać metodą `equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak identyfikatory slajdów, ani dynamicznych wartości elementów zastępczych, takich jak bieżąca data.

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

Więcej informacji znajdziesz w [Porównywanie slajdów prezentacji](/slides/pl/androidjava/compare-slides/).

## **Ustawienie widoku Master slajdów jako widoku domyślnego**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdów:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Więcej ustawień widoku znajdziesz w [Zapisz prezentację](/slides/pl/androidjava/save-presentation/).

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

Możesz także skorzystać z metody niskokodowej [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

Master slajdu definiuje wspólne ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera i definiuje konkretny układ elementów zastępczych. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Gdzie powinienem dodać elementy zastępcze – do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj elementy zastępcze do slajdów układu. Umieść współdzielone elementy wizualne i formatowanie na masterze, a elementy zastępcze treści na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć master slajdu, który jest nadal używany?**

Nie. Master slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery nie będące w użyciu.