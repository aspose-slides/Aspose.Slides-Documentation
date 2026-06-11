---
title: Zarządzanie grafiką SmartArt w prezentacjach przy użyciu JavaScript
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /pl/nodejs-java/manage-smartart-shape/
keywords:
- obiekt SmartArt
- grafika SmartArt
- styl SmartArt
- kolor SmartArt
- tworzenie SmartArt
- dodawanie SmartArt
- edycja SmartArt
- modyfikacja SmartArt
- dostęp do SmartArt
- typ układu SmartArt
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizowanie SmartArt w PowerPoint przy użyciu JavaScript i Aspose.Slides, oferując zwięzłe przykłady kodu oraz wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt poprzez kolekcję kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides for Node.js via Java udostępnia API do tworzenia kształtów SmartArt. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) ustawiając jego [LayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtLayoutType).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Dodaj kształt Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Zapisywanie prezentacji
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt dodany do slajdu**|

## **Dostęp do kształtu SmartArt na slajdzie**
Poniższy kod zostanie użyty do uzyskania dostępu do kształtów SmartArt dodanych w prezentacji. W przykładowym kodzie przejdziemy przez każdy kształt wewnątrz slajdu i sprawdzimy, czy jest on kształtem [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt). Jeśli kształt jest typu SmartArt, dokonamy rzutowania go na instancję [**SmartArt**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt).

```javascript
// Wczytaj wybraną prezentację
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Przejdź przez każdy kształt wewnątrz pierwszego slajdu
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do kształtu SmartArt o określonym typie układu**
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) o konkretnym LayoutType. Należy pamiętać, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i ustawia się go wyłącznie podczas dodawania kształtu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
1. Sprawdź kształt SmartArt o określonym LayoutType i wykonaj wymagane operacje.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Przejdź przez każdy kształt wewnątrz pierwszego slajdu
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArtEx
            var smart = shape;
            // Sprawdzanie układu SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmienianie stylu kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać szybki styl dowolnego kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
1. Znajdź kształt SmartArt o określonym stylu.
1. Ustaw nowy styl dla kształtu SmartArt.
1. Zapisz prezentację.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Przejdź przez każdy kształt wewnątrz pierwszego slajdu
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArtEx
            var smart = shape;
            // Sprawdzanie stylu SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Zmiana stylu SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Zapisywanie prezentacji
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem**|

## **Zmienianie stylu kolorów kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładzie kodu uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy go.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
1. Znajdź kształt SmartArt o określonym stylu kolorów.
1. Ustaw nowy styl kolorów dla kształtu SmartArt.
1. Zapisz prezentację.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Przejdź przez każdy kształt wewnątrz pierwszego slajdu
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArtEx
            var smart = shape;
            // Sprawdzanie typu koloru SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Zmienianie typu koloru SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Zapisywanie prezentacji
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem kolorów**|

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/nodejs-java/powerpoint-animation/) za pomocą API animacji (wejścia, wyjścia, podkreślenia, ścieżki ruchu) tak samo, jak w przypadku innych kształtów.

**Jak znaleźć konkretny SmartArt na slajdzie, gdy nie znam jego wewnętrznego identyfikatora?**

Ustaw i użyj tekstu alternatywnego (AltText) oraz przeszukaj kształt po tej wartości – jest to zalecany sposób lokalizacji docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/nodejs-java/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturę/obraz kształtu; biblioteka może [renderować pojedyncze kształty](/slides/pl/nodejs-java/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwersji całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksportowaniu do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), oferując szereg opcji jakości i kompatybilności.