---
title: Konwertuj slajdy PowerPoint na PNG w Androidzie
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /pl/androidjava/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na PNG
- prezentacja na PNG
- slajd na PNG
- PPT na PNG
- PPTX na PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla Androida w języku Java, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak ładować pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł również demonstruje, jak dostosować generowane obrazy PNG, ustawiając wartości skalowania lub określając żądaną szerokość i wysokość.

## **Konwertuj PowerPoint na PNG**

Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Pobierz obiekt slajdu z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) dostępnej przez interfejs [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide).
3. Użyj metody [ISlide.getImage()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide), aby uzyskać miniaturę każdego slajdu.
4. Użyj metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)), aby zapisać miniaturę slajdu w formacie PNG.

Ten kod w języku Java pokazuje, jak przekonwertować prezentację PowerPoint na PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwertuj PowerPoint na PNG z własnymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary powstałej miniatury.

Ten kod w języku Java demonstruje opisane działanie:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwertuj PowerPoint na PNG z własnym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać wybrane argumenty `width` i `height` dla `ImageSize`.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint na PNG, określając rozmiar obrazów:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak mogę wyeksportować tylko konkretny kształt (np. wykres lub obraz), a nie cały slajd?**

Aspose.Slides obsługuje [generowanie miniatur dla pojedynczych kształtów](/slides/pl/androidjava/create-shape-thumbnails/); możesz renderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/androidjava/multithreading/) jednej instancji prezentacji pomiędzy wątkami. Używaj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do wyjściowych obrazów i egzekwuje [inne ograniczenia](/slides/pl/androidjava/licensing/), dopóki nie zostanie zastosowana licencja.