---
title: Zarządzanie grafiką SmartArt w prezentacjach przy użyciu Javy
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /pl/java/manage-smartart-shape/
keywords:
- obiekt SmartArt
- grafika SmartArt
- styl SmartArt
- kolor SmartArt
- tworzenie SmartArt
- dodawanie SmartArt
- edycja SmartArt
- zmiana SmartArt
- dostęp do SmartArt
- typ układu SmartArt
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizację grafiki SmartArt w PowerPoint przy użyciu Javy i Aspose.Slides, oferując zwięzłe przykłady kodu oraz wskazówki skupiające się na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt za pośrednictwem kolekcji kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides for Java udostępnia API do tworzenia kształtów SmartArt. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) ustawiając jego [LayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj kształt SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Zapisywanie prezentacji
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: Kształt SmartArt dodany do slajdu**|

## **Dostęp do kształtu SmartArt na slajdzie**
Poniższy kod będzie używany do dostępu do kształtów SmartArt dodanych w slajdzie prezentacji. W przykładzie kodu przejdziemy przez każdy kształt wewnątrz slajdu i sprawdzimy, czy jest to kształt [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt). Jeśli kształt jest typu SmartArt, zostanie rzutowany na instancję [**SmartArt**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt).

```java
// Załaduj żądaną prezentację
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Przejdź przez każdy kształt w pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do kształtu SmartArt o określonym typie układu**
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) o określonym LayoutType. Należy pamiętać, że nie można zmienić LayoutType w SmartArt, ponieważ jest on tylko do odczytu i ustawia się go wyłącznie podczas dodawania kształtu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i załaduj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli jest to SmartArt.
1. Sprawdź kształt SmartArt o określonym LayoutType i wykonaj wymagane działania.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Przejdź przez każdy kształt w pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Sprawdzanie układu SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmiana stylu kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać szybki styl dowolnego kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i załaduj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli jest to SmartArt.
1. Znajdź kształt SmartArt o określonym Stylu.
1. Ustaw nowy Styl dla kształtu SmartArt.
1. Zapisz prezentację.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Uzyskaj pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Przejdź przez każdy kształt w pierwszym slajdzie
    for (IShape shape : slide.getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Sprawdzanie stylu SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Zmienianie stylu SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Zapisywanie prezentacji
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: Kształt SmartArt ze zmienionym stylem**|

## **Zmiana stylu kolorów kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładowym kodzie uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy jego styl.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i załaduj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) i rzutuj wybrany kształt na SmartArt, jeśli jest to SmartArt.
1. Znajdź kształt SmartArt o określonym Stylu Koloru.
1. Ustaw nowy Styl Koloru dla kształtu SmartArt.
1. Zapisz prezentację.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Uzyskaj pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Przejdź przez każdy kształt w pierwszym slajdzie
    for (IShape shape : slide.getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Sprawdzanie typu koloru SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Zmienianie typu koloru SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Zapisywanie prezentacji
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: Kształt SmartArt ze zmienionym stylem kolorów**|

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/java/powerpoint-animation/) za pomocą API animacji (wejście, wyjście, uwydatnienie, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego ID?**

Ustaw i użyj tekstu alternatywnego (AltText) oraz wyszukaj kształt po tej wartości — jest to zalecany sposób na zlokalizowanie docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/java/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturę/obraz kształtu; biblioteka może [renderować poszczególne kształty](/slides/pl/java/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwersji całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksportcie do PDF](/slides/pl/java/convert-powerpoint-to-pdf/), oferując różne opcje jakości i kompatybilności.