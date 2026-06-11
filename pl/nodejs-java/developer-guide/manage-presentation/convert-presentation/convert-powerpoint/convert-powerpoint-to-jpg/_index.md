---
title: Konwertuj PPT i PPTX do JPG w JavaScript
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w JavaScript przy użyciu Aspose.Slides dla Node.js via Java, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wstęp**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu zawartości w witrynach internetowych lub aplikacjach. Aspose.Slides umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo wdrożyć własny przeglądarka prezentacji i utworzyć miniaturę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub zaprezentować prezentację w trybie tylko do odczytu. Aspose.Slides umożliwia konwersję całej prezentacji lub wybranego slajdu do formatów obrazów.

## **Konwersja PowerPoint PPT/PPTX do JPG**
Oto kroki konwersji PPT/PPTX do JPG:

1. Utwórz instancję typu [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj obiekt slajdu typu [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide) z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Utwórz miniaturę każdego slajdu, a następnie skonwertuj ją do JPG. Metoda [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide#getImage-float-float-) jest używana do uzyskania miniatury slajdu i zwraca obiekt [Imagess](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Images). Metodę [getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) należy wywołać na wybranym slajdzie typu [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide), a skale wynikowej miniatury są przekazywane do metody.
4. Po uzyskaniu miniatury slajdu wywołaj metodę [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save). Przekaż do niej nazwę pliku wynikowego oraz format obrazu.

{{% alert color="primary" %}}
**Uwaga**: konwersja PPT/PPTX do JPG różni się od konwersji do innych typów w API Aspose.Slides. Dla innych typów zazwyczaj używasz metody [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), ale tutaj musisz użyć metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save).
{{% /alert %}}

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tworzy obraz w pełnej skali
        var slideImage = sld.getImage(1.0, 1.0);
        // Zapisuje obraz na dysku w formacie JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwersja PowerPoint PPT/PPTX do JPG z niestandardowymi wymiarami**
Aby zmienić wymiary wynikowej miniatury i obrazu JPG, możesz ustawić wartości *ScaleX* i *ScaleY*, przekazując je do metod [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiuje wymiary
    var desiredX = 1200;
    var desiredY = 800;
    // Pobiera przeskalowane wartości X i Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tworzy obraz w pełnej skali
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Zapisuje obraz na dysku w formacie JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Renderowanie komentarzy podczas zapisywania prezentacji jako obrazu**
Aspose.Slides for Node.js via Java oferuje możliwość renderowania komentarzy w slajdach prezentacji podczas konwertowania tych slajdów na obrazy. Ten kod JavaScript pokazuje działanie:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i inne.
{{% /alert %}}

## **Zobacz także**

Zobacz inne opcje konwersji PPT/PPTX do obrazu, takie jak:

- [Konwersja PPT/PPTX do SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne. Jednak dokładność renderowania może nieco się różnić w porównaniu do PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

**Czy istnieją jakiekolwiek ograniczenia dotyczące liczby slajdów, które można przetworzyć?**

Aspose.Slides nie narzuca ścisłych ograniczeń co do liczby slajdów, które możesz przetworzyć. Jednak przy pracy z dużymi prezentacjami lub obrazami wysokiej rozdzielczości możesz napotkać błąd braku pamięci.