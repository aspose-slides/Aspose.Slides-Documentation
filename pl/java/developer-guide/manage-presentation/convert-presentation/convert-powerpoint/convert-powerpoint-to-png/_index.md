---
title: Konwertuj slajdy PowerPoint na PNG w Javie
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla Javy, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak wczytywać pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł demonstruje również, jak dostosować wygenerowane obrazy PNG, ustawiając wartości skalowania lub określając żądaną szerokość i wysokość.

## **Konwersja PowerPoint do PNG**

Przejdź przez te kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz obiekt slajdu z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) dostępnej pod interfejsem [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide).
3. Użyj metody [ISlide.getImage()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide), aby uzyskać miniaturkę dla każdego slajdu.
4. Użyj metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)), aby zapisać miniaturkę slajdu w formacie PNG.

Ten kod Java pokazuje, jak skonwertować prezentację PowerPoint do formatu PNG:

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

## **Konwersja PowerPoint do PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG w określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary wynikowej miniaturki.

Ten kod w języku Java demonstruje opisaną operację:

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

## **Konwersja PowerPoint do PNG z niestandardowym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać swoje preferowane argumenty `width` i `height` dla `ImageSize`.

Ten kod pokazuje, jak skonwertować PowerPoint do PNG, określając rozmiar obrazów:

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

**Jak mogę wyeksportować tylko określony kształt (np. wykres lub obraz), a nie cały slajd?**

Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/java/create-shape-thumbnails/); możesz renderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/java/multithreading/) jednej instancji prezentacji między wątkami. Użyj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do obrazów wyjściowych i wymusza [inne ograniczenia](/slides/pl/java/licensing/), dopóki nie zostanie zastosowana licencja.