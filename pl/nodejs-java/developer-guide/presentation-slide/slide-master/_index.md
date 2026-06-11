---
title: Zarządzanie mistrzami slajdów prezentacji w JavaScript
linktitle: Mistrz slajdu
type: docs
weight: 70
url: /pl/nodejs-java/slide-master/
keywords:
- mistrz slajdu
- slajd mistrza
- slajd mistrza PPT
- wiele slajdów mistrza
- porównaj slajdy mistrza
- tło
- pole zastępcze
- klonuj slajd mistrza
- kopiuj slajd mistrza
- duplikuj slajd mistrza
- nieużywany slajd mistrza
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj mistrzami slajdów w Aspose.Slides dla Node.js via Java: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj slajdy mistrza w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

A **slide master** definiuje wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i ustawienia stopki. W programie PowerPoint edycja mistrza slajdów jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Node.js via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub wiele mistrzów slajdów, a każdy mistrz slajdów może zawierać kilka slajdów układu. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do mistrza slajdów. Zamiast tego zwykły slajd używa slajdu układu, a ten slajd układu należy do mistrza slajdów.

The hierarchy is:

1. **Slide master** - definiuje wspólny projekt i motyw.
1. **Layout slide** - definiuje określone rozmieszczenie kontenerów i formatowanie na poziomie układu.
1. **Normal slide** - zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia mistrzów slajdów, slajdów układu i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides mistrz slajdu jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) . Wszystkie mistrze slajdów w prezentacji są dostępne poprzez kolekcję `Presentation.getMasters()`.

{{% alert color="info" title="Dziedziczenie" %}}
Gdy to samo właściwość jest zdefiniowane na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli mistrz slajdu i slajd układu definiują tło, slajdy oparte na tym układzie używają tła układu. Aby uzyskać więcej informacji o slajdach układu, zobacz [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Dostęp do Mistrzów Slajdów**

W programie PowerPoint możesz otworzyć widok Mistrza slajdów z menu **View** > **Slide Master**.

![Polecenie Mistrz slajdów na karcie Widok w programie PowerPoint](slide-master_3.jpg)

W Aspose.Slides, użyj kolekcji `getMasters()` aby uzyskać dostęp do mistrzów slajdów:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Możesz także uzyskać mistrza slajdu używanego przez normalny slajd poprzez jego układ:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Co zawiera mistrz slajdów**

Mistrz slajdu jest obiektem podobnym do slajdu. Dziedziczy wspólne zachowanie slajdu z [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez normalne i układowe slajdy. Członkowie specyficzni dla mistrza są wymienieni na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/).

Często używane członkowie mistrza slajdu obejmują:

| Member | Purpose |
| --- | --- |
| `getBackground()` | Ustawia tło slajdu na poziomie mistrza. |
| `getShapes()` | Przechowuje kształty umieszczone na mistrzu, takie jak logotypy, ramki obrazów i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu należące do mistrza. |
| `getThemeManager()` | Udostępnia dostęp do interfejsów API tematu mistrza. |
| `getHeaderFooterManager()` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mistrza oraz jego układów podrzędnych. |
| `getDependingSlides()` | Zwraca normalne slajdy zależne od mistrza poprzez ich układy. |

## **Dodaj obraz do mistrza slajdów**

Gdy dodasz obraz do mistrza slajdu, pojawia się on na slajdach, które używają układów z tego mistrza. Jest to przydatne dla logotypów, znaków wodnych, dekoracyjnych pasów i innych powtarzających się elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego mistrza slajdu:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby uzyskać więcej informacji o ramach obrazów, zobacz [Picture Frame](/nodejs-java/picture-frame/).

## **Praca z Zastępcami**

Zastępcy są zazwyczaj definiowani na slajdach układu. Mistrz slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, a każdy układ decyduje, które zastępcy są dostępni i gdzie są umieszczone.

W programie PowerPoint polecenia zastępców są dostępne w widoku Mistrza slajdów.

![Polecenie Wstaw zastępca w widoku Mistrza slajdów w programie PowerPoint](slide-master_5.png)

Aby dodać nowe zastępcy przy użyciu Aspose.Slides, pracuj ze slajdem układu, który należy do mistrza:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także sformatować kształty zastępców, które już istnieją na mistrzu slajdu. Poniższy przykład znajduje zastępca tytułu i stosuje wypełnienie gradientem liniowym:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sformatowany zastępca tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Aby uzyskać więcej opcji dotyczących zastępców i formatowania tekstu, zobacz [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) i [Text Formatting](/nodejs-java/text-formatting/).

## **Zmień tło mistrza slajdów**

Tło mistrza jest dziedziczone przez układy i slajdy, które go nie zastępują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mistrza slajdu:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Powiązane tematy: zobacz [Presentation Background](/nodejs-java/presentation-background/) i [Presentation Theme](/nodejs-java/presentation-theme/).

## **Sklonuj mistrza slajdów do innej prezentacji**

Użyj `MasterSlideCollection.addClone`, aby skopiować mistrza slajdu do innej prezentacji. Skopiowany mistrz może następnie być używany przez układy i slajdy w docelowej prezentacji.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Jeśli potrzebujesz sklonować normalne slajdy wraz z ich mistrzem, zobacz [Clone Slides](/nodejs-java/clone-slides/).

## **Dodaj wiele mistrzów slajdów**

Prezentacja może zawierać wiele mistrzów slajdów. Jest to przydatne, gdy różne sekcje wymagają innej identyfikacji wizualnej, struktury stron lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania mistrzami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślnego mistrza, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym mistrzem i dodaje nowy slajd oparty na tym układzie:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Porównaj mistrzów slajdów**

Mistrze slajdów mogą być porównywane za pomocą metody `equals` odziedziczonej z [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdów, ani dynamicznych wartości zastępców, takich jak bieżąca data.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Aby uzyskać więcej informacji, zobacz [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Ustaw widok mistrza slajdów jako domyślny widok**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Mistrza slajdów:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby uzyskać więcej ustawień widoku, zobacz [Save Presentation](/nodejs-java/save-presentation/).

## **Usuń nieużywane mistrzy slajdów**

Prezentacje czasami zawierają mistrze slajdów, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych mistrzów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused`, aby usunąć nieużywane mistrze z kolekcji `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także użyć metody niskokodowej `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między mistrzem slajdów a slajdem układu?**

Mistrz slajdu definiuje wspólne ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mistrza slajdu i definiuje określone rozmieszczenie zastępców. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mistrza.

**Czy jedna prezentacja może zawierać kilka mistrzów slajdów?**

Tak. Prezentacja może zawierać kilka mistrzów slajdów. Używaj wielu mistrzów, gdy różne sekcje potrzebują różnych systemów wizualnych lub identyfikacji marki.

**Czy powinienem dodać zastępcy do mistrza slajdu czy do slajdu układu?**

W większości przypadków dodawaj zastępcy do slajdów układu. Umieść wspólne elementy wizualne i wspólne formatowanie na mistrzu slajdu, a następnie umieść zastępcy treści na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć mistrza slajdu, który jest nadal używany?**

Nie. Mistrz slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym mistrzem lub użyj metody czyszczenia nieużywanych mistrzów, która usuwa tylko mistrze, które nie są używane.