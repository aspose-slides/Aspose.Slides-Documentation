---
title: Zarządzanie grafikami SmartArt w prezentacjach na Androidzie
linktitle: Grafiki SmartArt
type: docs
weight: 20
url: /pl/androidjava/manage-smartart-shape/
keywords:
- Obiekt SmartArt
- Grafika SmartArt
- Styl SmartArt
- Kolor SmartArt
- Tworzenie SmartArt
- Dodawanie SmartArt
- Edycja SmartArt
- Zmiana SmartArt
- Dostęp do SmartArt
- Typ układu SmartArt
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizację grafik SmartArt w PowerPoint przy użyciu Aspose.Slides dla Androida, oferując zwięzłe przykłady kodu Java oraz wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt za pośrednictwem kolekcji kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides dla Androida za pośrednictwem Javy udostępnia interfejs API do tworzenia kształtów SmartArt. Aby utworzyć kształt SmartArt na slajdzie, należy postępować zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
1. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) ustawiając jego [LayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj kształt Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Zapisz prezentację
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt dodany do slajdu**|

## **Dostęp do kształtu SmartArt na slajdzie**
Poniższy kod będzie używany do uzyskania dostępu do kształtów SmartArt dodanych w slajdzie prezentacji. W przykładowym kodzie przejdziemy przez każdy kształt wewnątrz slajdu i sprawdzimy, czy jest on kształtem [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt). Jeśli kształt jest typu SmartArt, dokonamy rzutowania go na instancję [**SmartArt**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt).

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
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt) o określonym LayoutType. Należy zauważyć, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i jest ustawiany wyłącznie w momencie dodania kształtu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu przy użyciu jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
1. Sprawdź kształt SmartArt o określonym LayoutType i wykonaj niezbędne działania.

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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu przy użyciu jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
1. Znajdź kształt SmartArt o określonym stylu.
1. Ustaw nowy styl dla kształtu SmartArt.
1. Zapisz prezentację.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Pobierz pierwszy slajd
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
|**Rysunek: Kształt SmartArt ze zmienionym stylem**|

## **Zmiana stylu kolorów kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładowym kodzie uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy go.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
1. Uzyskaj referencję do pierwszego slajdu przy użyciu jego indeksu.
1. Przejdź przez każdy kształt w pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
1. Znajdź kształt SmartArt o określonym stylu kolorów.
1. Ustaw nowy styl kolorów dla kształtu SmartArt.
1. Zapisz prezentację.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Pobierz pierwszy slajd
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
|**Rysunek: Kształt SmartArt ze zmienionym stylem kolorów**|

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/androidjava/powerpoint-animation/) za pomocą API animacji (animacje wejścia, wyjścia, podkreślenia, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego ID?**

Ustaw i użyj tekstu alternatywnego (AltText) i wyszukaj kształt po tej wartości — jest to zalecany sposób na zlokalizowanie docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/androidjava/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturkę/obraz kształtu; biblioteka może [renderować pojedyncze kształty](/slides/pl/androidjava/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwersji całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej jakości przy [eksportowaniu do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), oferując różne opcje jakości i kompatybilności.