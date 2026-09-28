---
title: Zarządzaj mistrzami slajdów prezentacji w JavaScript
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
- zduplikuj slajd mistrza
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

A **mistrz slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i ustawienia stopki. W programie PowerPoint edycja mistrza slajdu jest typowym sposobem zachowania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Node.js via Java obsługuje ten sam model. Prezentacja może zawierać jedną lub więcej slajdów mistrza, a każdy slajd mistrza może zawierać kilka slajdów układu. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do slajdu mistrza. Zamiast tego zwykły slajd używa slajdu układu, który należy do slajdu mistrza.

Hierarchia wygląda następująco:

1. **Mistrz slajdu** - definiuje wspólny projekt i motyw.  
1. **Slajd układu** - definiuje konkretne rozmieszczenie pól zastępczych i formatowanie na poziomie układu.  
1. **Zwykły slajd** - zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.  

![Hierarchia slajdów mistrza, slajdów układu i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides slajd mistrza jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/). Wszystkie slajdy mistrza w prezentacji są dostępne poprzez kolekcję `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Kiedy ta sama właściwość jest określona na więcej niż jednym poziomie, wygrywa bardziej szczegółowy poziom. Na przykład, jeśli slajd mistrza i slajd układu oba definiują tło, slajdy oparte na tym układzie używają tła układu. Aby uzyskać więcej informacji o slajdach układu, zobacz [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Uzyskiwanie dostępu do mistrzów slajdów**

W programie PowerPoint można otworzyć widok Mistrza slajdu z **Widok** > **Mistrz slajdu**.

![Polecenie Mistrz slajdu na karcie Widok w programie PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `getMasters()`, aby uzyskać dostęp do slajdów mistrza:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Można również uzyskać slajd mistrza używany przez zwykły slajd poprzez jego układ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Co zawiera slajd mistrza**

Slajd mistrza jest obiektem podobnym do slajdu. Dziedziczy wspólne zachowanie slajdu z [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez zwykłe i slajdy układu. Członkowie specyficzni dla mistrza są wymienieni na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/).

Często używane członkowie slajdu mistrza obejmują:

| Członek | Cel |
| --- | --- |
| `getBackground()` | Ustawia tło slajdu poziomu mistrza. |
| `getShapes()` | Przechowuje kształty umieszczone na mistrzu, takie jak logotypy, ramki obrazów i współdzielony tekst. |
| `getLayoutSlides()` | Przechowuje slajdy układu, które należą do mistrza. |
| `getThemeManager()` | Udostępnia dostęp do interfejsów API motywu mistrza. |
| `getHeaderFooterManager()` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mistrza i jego podległych układów. |
| `getDependingSlides()` | Zwraca zwykłe slajdy zależne od mistrza poprzez ich układy. |

## **Dodaj obraz do slajdu mistrza**

Gdy dodasz obraz do slajdu mistrza, pojawia się on na slajdach używających układów z tego mistrza. Jest to przydatne dla logotypów, znaków wodnych, dekoracyjnych pasów i innych powtarzających się elementów wizualnych.

Poniższy przykład dodaje logotyp do pierwszego slajdu mistrza:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Aby uzyskać więcej informacji o ramkach obrazu, zobacz [Picture Frame](/nodejs-java/picture-frame/).

## **Kontrola widoczności grafiki mistrza**

Użyj [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes), aby ukryć odziedziczoną grafikę mistrza, taką jak logotypy lub kształty dekoracyjne, bez usuwania ich z mistrza. Przekaż `false` do [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#setShowMasterShapes) na slajdzie, który ma pomijać te grafiki, i pozostaw `true` na slajdach, które mają je wyświetlać.

Poniższy samodzielny przykład tworzy niebieski dekoracyjny pas na mistrzu oraz dwa slajdy używające tego samego pustego układu. Pas jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie jest wymagane żadne wejściowe przedstawienie ani obraz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przykład używa układu **Blank** dostarczonego z nową prezentacją i usuwa własne pola zastępcze początkowego slajdu.

### **Wybierz zakres ustawienia**

Zwykły slajd używa swojego mistrza poprzez [Slide.getLayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getLayoutSlide) i [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Przekazanie `false` do [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) ukrywa grafikę mistrza dla slajdów używających tego współdzielonego układu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafikę tylko na jednym slajdzie, zmień właściwość slajdu i pozostaw niezmieniony współdzielony układ.

Ustawienie nie jest obsługiwane jako kontrola widoczności na samym slajdzie mistrza. Na mistrzu [getShowMasterShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) zawsze zwraca `false`, a przekazanie `true` do [setShowMasterShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) powoduje wyjątek. Zastosuj je do zwykłego slajdu lub układu.

### **Rozróżnij grafikę od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mistrza | Kontroluje widoczność dziedziczonych kształtów mistrza bez ich usuwania ani zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mistrza jest oddzielnym kształtem i może pozostać widoczna na tym tle. Zobacz [Presentation Background](/slides/pl/nodejs-java/presentation-background/). |
| Usuń kształt z mistrza | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu używającego tego mistrza. |

## **Praca z polami zastępczymi**

Pola zastępcze są zazwyczaj definiowane na slajdach układu. Slajd mistrza zapewnia współdzielony styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które pola zastępcze są dostępne i gdzie są umieszczone.

W programie PowerPoint polecenia pola zastępczego są dostępne w widoku Mistrza slajdu.

![Polecenie Wstawianie pola zastępczego w widoku Mistrza slajdu programu PowerPoint](slide-master_5.png)

Aby dodać nowe pola zastępcze z Aspose.Slides, pracuj z slajdem układu, który należy do mistrza:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Można również sformatować kształty pól zastępczych, które już istnieją na slajdzie mistrza. Poniższy przykład znajduje pole zastępcze tytułu i stosuje liniowe wypełnienie gradientem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sformatowane pole zastępcze tytułu dziedziczone przez zwykłe slajdy](slide-master_8.png)

Aby uzyskać więcej opcji formatowania pól zastępczych i tekstu, zobacz [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) oraz [Text Formatting](/nodejs-java/text-formatting/).

## **Zmienianie tła slajdu mistrza**

Tło mistrza jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego slajdu mistrza:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Powiązane tematy znajdziesz w [Presentation Background](/nodejs-java/presentation-background/) oraz [Presentation Theme](/nodejs-java/presentation-theme/).

## **Klony slajdu mistrza do innej prezentacji**

Użyj `MasterSlideCollection.addClone`, aby skopiować slajd mistrza do innej prezentacji. Skopiowany mistrz może wtedy być używany przez układy i slajdy w docelowej prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Jeśli potrzebujesz sklonować zwykłe slajdy wraz z ich mistrzem, zobacz [Clone Slides](/nodejs-java/clone-slides/).

## **Dodaj wiele slajdów mistrza**

Prezentacja może zawierać wiele slajdów mistrza. Jest to przydatne, gdy różne sekcje wymagają innej identyfikacji wizualnej, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania slajdami mistrza](slide-master_9.jpg)

Poniższy przykład klonuje domyślnego mistrza, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym mistrzem i dodaje nowy slajd oparty na tym układzie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Porównaj slajdy mistrza**

Slajdy mistrza można porównać metodą `equals` odziedziczoną po [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości pól zastępczych, takich jak bieżąca data.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Aby uzyskać więcej informacji, zobacz [Compare Presentation Slides](/slides/pl/nodejs-java/compare-slides/).

## **Ustaw widok Mistrza slajdu jako widok domyślny**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Mistrza slajdu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/nodejs-java/save-presentation/).

## **Usuń nieużywane slajdy mistrza**

Prezentacje czasami zawierają slajdy mistrza, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych mistrzów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused`, aby usunąć nieużywane mistrze z kolekcji `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Można również użyć metody niskokodowej `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między slajdem mistrza a slajdem układu?**

Slajd mistrza definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do slajdu mistrza i definiuje konkretne rozmieszczenie pól zastępczych. Zwykły slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mistrza.

**Czy jedna prezentacja może zawierać kilka slajdów mistrza?**

Tak. Prezentacja może zawierać kilka slajdów mistrza. Używaj wielu mistrzów, gdy różne sekcje wymagają różnych systemów wizualnych lub identyfikacji marki.

**Czy powinienem dodawać pola zastępcze do slajdu mistrza czy do slajdu układu?**

W większości przypadków dodawaj pola zastępcze do slajdów układu. Umieść wspólne elementy wizualne i współdzielone formatowanie na slajdzie mistrza, a pola zastępcze treści umieść na układach, które będą używane przez zwykłe slajdy.

**Czy mogę usunąć slajd mistrza, który jest nadal używany?**

Nie. Slajd mistrza, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym mistrzem lub użyj metody czyszczenia nieużywanych mistrzów, która usuwa tylko mistrze, które nie są używane.