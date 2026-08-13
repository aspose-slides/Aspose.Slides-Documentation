---
title: Konwertowanie PPT i PPTX do JPG w Javie
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
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w Javie przy użyciu Aspose.Slides dla Javy, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności i osadzaniu treści na stronach internetowych lub w aplikacjach. Aspose.Slides umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo jest zaimplementować własną przeglądarkę prezentacji i utworzyć miniaturkę dla każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub przedstawić prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub konkretny slajd do formatów obrazu.

## **Konwertowanie PowerPoint PPT/PPTX do JPG**

Oto kroki konwersji PPT/PPTX do JPG:

1. Utwórz instancję typu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide) z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) .
3. Utwórz miniaturkę każdego slajdu, a następnie przekształć ją w JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-float-float-) metoda jest używana do uzyskania miniaturki slajdu, zwraca obiekt [Images](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Images). Metoda [getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) musi być wywołana z wymaganego slajdu typu [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide), a skalowanie wynikowej miniaturki jest przekazywane do metody.
4. Po uzyskaniu miniaturki slajdu, wywołaj metodę [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) z obiektu miniaturki. Przekaż do niej nazwę pliku wynikowego oraz format obrazu.  

{{% alert color="info" %}}

**Uwaga**: Konwersja PPT/PPTX do JPG różni się od konwersji do innych typów w API Aspose.Slides. Dla innych typów zazwyczaj używa się metody [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), ale tutaj należy użyć metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).  

{{% /alert %}} 

```java
import com.aspose.slides.*;

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

## **Konwertowanie PowerPoint PPT/PPTX do JPG z niestandardowymi wymiarami**

Aby zmienić wymiary wynikowej miniaturki i obrazu JPG, możesz ustawić wartości *ScaleX* i *ScaleY*, przekazując je do metod [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
import com.aspose.slides.*;

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

## **Renderowanie komentarzy podczas zapisywania slajdów jako obrazy**

Aspose.Slides for Java udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas konwersji tych slajdów na obrazy. Poniższy kod Java demonstruje to działanie:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}

Aspose udostępnia [FREE Collage web app](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć [JPG to JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [photo grids](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej.  

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Po więcej informacji zobacz te strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/); konwertuj [JPG to image](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/); konwertuj [JPG to PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/); konwertuj [PNG to JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/); konwertuj [PNG to SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/); konwertuj [SVG to PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

### Czy ta metoda obsługuje konwersję wsadową?

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

### Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne. Jednak dokładność renderowania może nieco się różnić w porównaniu do PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

### Czy istnieją ograniczenia co do liczby slajdów, które można przetworzyć?

Aspose.Slides nie narzuca sztywnych limitów liczby slajdów, które możesz przetworzyć. Jednak przy dużych prezentacjach lub obrazach wysokiej rozdzielczości możesz napotkać błąd braku pamięci.

## **Zobacz również**

Zobacz inne opcje konwersji PPT/PPTX do obrazu, takie jak:

- [PPT/PPTX to SVG conversion](/slides/pl/java/render-a-slide-as-an-svg-image/).