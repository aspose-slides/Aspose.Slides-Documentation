---
title: Konwertuj PPT i PPTX na JPG w Androidzie
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /pl/androidjava/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na JPG
- prezentacja na JPG
- slajd na JPG
- PPT na JPG
- PPTX na JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w Javie przy użyciu Aspose.Slides dla Androida, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu treści w witrynach internetowych lub aplikacjach. Aspose.Slides for Android via Java umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo zaimplementować własny przeglądacz prezentacji i utworzyć miniaturę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub pokazać prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub wybrany slajd do formatów obrazów.

## **Konwertowanie slajdów prezentacji na obrazy JPG**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) z kolekcji zwracanej przez metodę [Presentation.getSlides()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--).
1. Utwórz obraz slajdu przy użyciu metody [ISlide.getImage(float, float)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-float-float-).
1. Wywołaj metodę [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego oraz format obrazu jako argumenty.

{{% alert color="info" %}} 
**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides Android via Java. Dla innych formatów zazwyczaj używasz metody [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Jednak w przypadku konwersji do JPG musisz użyć metody [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).
{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Utwórz obraz slajdu w określonej skali.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Zapisz obraz na dysku w formacie JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie slajdów do JPG z niestandardowymi wymiarami**

Możesz zmienić wymiary wygenerowanych obrazów JPG, ustawiając rozmiar obrazu poprzez przekazanie go do metody [ISlide.getImage(Size)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Umożliwia to tworzenie obrazów o konkretnych wartościach szerokości i wysokości, zapewniając, że wynik spełnia wymagania dotyczące rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy generowaniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagane są precyzyjne wymiary obrazu.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Utwórz obraz slajdu o określonym rozmiarze.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Zapisz obraz na dysku w formacie JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Renderowanie komentarzy podczas zapisywania slajdów jako obrazy**

Aspose.Slides for Android via Java oferuje funkcję umożliwiającą renderowanie komentarzy na slajdach prezentacji podczas ich konwersji do obrazów JPG. Ta funkcjonalność jest szczególnie przydatna do zachowania adnotacji, uwag lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz, że komentarze będą widoczne na wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie uwag bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx” ze slajdem zawierającym komentarze:

![Slajd z komentarzami](slide_with_comments.png)

Poniższy kod Java konwertuje slajd na obraz JPG, zachowując komentarze:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Konwertuj pierwszy slajd na obraz.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Wynik:

![Obraz JPG z komentarzami](image_with_comments.png)

## **Zobacz także**

Zobacz inne opcje konwersji PPT, PPTX lub ODP do obrazów, takie jak:

- [Konwertuj PowerPoint do GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/)
- [Konwertuj PowerPoint do PNG](/slides/pl/androidjava/convert-powerpoint-to-png/)
- [Konwertuj PowerPoint do TIFF](/slides/pl/androidjava/convert-powerpoint-to-tiff/)
- [Konwertuj PowerPoint do SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Aby zobaczyć, jak Aspose.Slides konwertuje prezentacje PowerPoint do obrazów JPG, wypróbuj te bezpłatne konwertery online: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) i [PPT to JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Darmowy konwerter online PPTX do JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG to JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG to PNG, tworzyć [photo grids](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Korzystając z tych samych zasad opisanych w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Więcej informacji znajdziesz na następujących stronach: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Czy ta metoda obsługuje konwersję wsadową?

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

### Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne. Jednak dokładność renderowania może nieco różnić się od PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

### Czy istnieją ograniczenia liczby slajdów, które można przetworzyć?

Aspose.Slides nie narzuca żadnych sztywnych ograniczeń liczby slajdów, które możesz przetworzyć. Jednak przy pracy z dużymi prezentacjami lub obrazami o wysokiej rozdzielczości możesz napotkać błąd braku pamięci.