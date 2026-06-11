---
title: Konwertuj PPT i PPTX do JPG w Javie
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/java/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do JPG
- prezentacja do JPG
- slajd do JPG
- PPT do JPG
- PPTX do JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) do wysokiej jakości obrazów JPG w Javie przy użyciu Aspose.Slides dla Javy, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG ułatwia udostępnianie slajdów, optymalizację wydajności oraz osadzanie treści w witrynach internetowych lub aplikacjach. Aspose.Slides umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo zaimplementować własną przeglądarkę prezentacji i utworzyć miniaturkę dla każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub przedstawić prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub wybrany slajd do formatów graficznych.

## **Konwertuj PowerPoint PPT/PPTX do JPG**

1. Utwórz instancję typu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide) z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) .
3. Utwórz miniaturkę każdego slajdu, a następnie przekonwertuj ją na JPG. Metoda [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-float-float-) służy do pobrania miniaturki slajdu i zwraca obiekt [Images](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Images). Metodę [getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) należy wywołać na wymaganym slajdzie typu [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide), przy czym skale wynikowej miniaturki są przekazywane do metody.
4. Po uzyskaniu miniaturki slajdu wywołaj metodę [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) na obiekcie miniaturki. Przekaż do niej nazwę pliku wyjściowego oraz format obrazu.

{{% alert color="primary" %}}
**Uwaga**: konwersja PPT/PPTX do JPG różni się od konwersji do innych typów w API Aspose.Slides. Dla innych typów zazwyczaj używa się metody [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), ale tutaj należy użyć metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Tworzy obraz w pełnej skali
        IImage slideImage = sld.getImage(1f, 1f);

        // Zapisuje obraz na dysku w formacie JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwertuj PowerPoint PPT/PPTX do JPG z niestandardowymi wymiarami**

Aby zmienić rozmiar wynikowej miniaturki i obrazu JPG, możesz ustawić wartości *ScaleX* i *ScaleY*, przekazując je do metod [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiuje wymiary
    int desiredX = 1200;
    int desiredY = 800;
    // Pobiera przeskalowane wartości X i Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Tworzy obraz w pełnej skali
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Zapisuje obraz na dysku w formacie JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Renderuj komentarze przy zapisywaniu slajdów jako obrazy**

Aspose.Slides for Java udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas ich konwersji na obrazy. Ten kod Java demonstruje działanie:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Używając tych samych zasad opisanych w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Po więcej informacji zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/); konwertuj [JPG na obraz](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/); konwertuj [JPG na PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/), konwertuj [PNG na JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/); konwertuj [PNG na SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/), konwertuj [SVG na PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą treść, w tym SmartArt, wykresy, tabele, kształty i inne. Jednak dokładność renderowania może nieco różnić się od PowerPointa, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

**Czy istnieją ograniczenia liczby slajdów, które można przetworzyć?**

Aspose.Slides nie narzuca ścisłych ograniczeń liczby przetwarzanych slajdów. Jednak przy dużych prezentacjach lub obrazach wysokiej rozdzielczości może wystąpić błąd braku pamięci.

## **Zobacz także**

Zobacz inne opcje konwersji PPT/PPTX do obrazu, takie jak:

- [Konwersja PPT/PPTX do SVG](/slides/pl/java/render-a-slide-as-an-svg-image/).