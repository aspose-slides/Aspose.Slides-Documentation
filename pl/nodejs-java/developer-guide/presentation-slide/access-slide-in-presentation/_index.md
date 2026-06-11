---
title: Dostęp do slajdów prezentacji w JavaScript
linktitle: Dostęp do slajdu
type: docs
weight: 20
url: /pl/nodejs-java/access-slide-in-presentation/
keywords:
- dostęp do slajdu
- indeks slajdu
- identyfikator slajdu
- pozycja slajdu
- zmiana pozycji
- właściwości slajdu
- numer slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak uzyskać dostęp i zarządzać slajdami w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js. Zwiększ produktywność dzięki przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać dostęp do slajdów i zarządzać nimi w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak pobrać slajdy według ich zerowo‑indeksowanego numeru z kolekcji slajdów oraz jak uzyskać dostęp do slajdu po jego unikalnym identyfikatorze przy użyciu metody `getSlideById`.

Dowiesz się również, jak zmienić pozycję slajdu przy użyciu metody `setSlideNumber` oraz jak określić początkowy numer slajdu w prezentacji metodą `setFirstSlideNumber`. Przykłady demonstrują ładowanie prezentacji, pobieranie odwołań do slajdów, aktualizację kolejności lub numeracji slajdów oraz zapisywanie zmodyfikowanej prezentacji.

## **Dostęp do slajdu według indeksu**

Wszystkie slajdy w prezentacji są uporządkowane numerycznie według pozycji slajdu, zaczynając od 0. Pierwszy slajd jest dostępny pod indeksem 0; drugi slajd pod indeksem 1; itd.

Klasa Presentation, reprezentująca plik prezentacji, udostępnia wszystkie slajdy jako kolekcję [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) (kolekcję obiektów [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/)). Ten kod JavaScript pokazuje, jak uzyskać dostęp do slajdu przez jego indeks:

```javascript
// Instancjonuje obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Uzyskuje dostęp do slajdu przy użyciu jego indeksu
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Dostęp do slajdu według identyfikatora**

Każdy slajd w prezentacji ma przypisany unikalny identyfikator. Możesz użyć metody [getSlideById](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/)), aby odwołać się do tego identyfikatora. Ten kod JavaScript pokazuje, jak podać prawidłowy identyfikator slajdu i uzyskać dostęp do tego slajdu metodą [getSlideById](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Instancjonuje obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Pobiera identyfikator slajdu
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Uzyskuje dostęp do slajdu poprzez jego identyfikator
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Zmienianie pozycji slajdu**

Aspose.Slides umożliwia zmianę pozycji slajdu. Na przykład możesz określić, że pierwszy slajd ma stać się drugim slajdem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu (którego pozycję chcesz zmienić) przez jego indeks.
1. Ustaw nową pozycję slajdu przy użyciu właściwości [setSlideNumber](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript demonstruje operację, w której slajd znajdujący się na pozycji 1 jest przenoszony na pozycję 2:

```javascript
// Instancjonuje obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Pobiera slajd, którego pozycja ma zostać zmieniona
    var sld = pres.getSlides().get_Item(0);
    // Ustawia nową pozycję slajdu
    sld.setSlideNumber(2);
    // Zapisuje zmodyfikowaną prezentację
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Pierwszy slajd stał się drugim; drugi slajd stał się pierwszym. Gdy zmieniasz pozycję slajdu, pozostałe slajdy są automatycznie dostosowywane.

## **Ustawianie numeru slajdu**

Korzystając z właściwości [setFirstSlideNumber](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/)), możesz określić nowy numer pierwszego slajdu w prezentacji. Operacja ta powoduje przeliczenie numerów pozostałych slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Pobierz numer slajdu.
1. Ustaw numer slajdu.
1. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript demonstruje operację, w której numer pierwszego slajdu jest ustawiony na 10:

```javascript
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Pobiera numer slajdu
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Ustawia numer slajdu
    pres.setFirstSlideNumber(10);
    // Zapisuje zmodyfikowaną prezentację
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Jeśli wolisz pominąć pierwszy slajd, możesz rozpocząć numerację od drugiego slajdu (i ukryć numerację dla pierwszego slajdu) w następujący sposób:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Ustawia numer pierwszego slajdu prezentacji
    // Wyświetla numery slajdów dla wszystkich slajdów
    // Ukrywa numer slajdu pierwszego slajdu
    // Zapisuje zmodyfikowaną prezentację
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Czy numer slajdu widziany przez użytkownika odpowiada zerowo‑indeksowanemu indeksowi kolekcji?**

Numer wyświetlany na slajdzie może zaczynać się od dowolnej wartości (np. 10) i nie musi odpowiadać indeksowi; zależność jest kontrolowana przez ustawienie [first slide number](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) w prezentacji.

**Czy ukryte slajdy wpływają na indeksowanie?**

Tak. Ukryty slajd pozostaje w kolekcji i jest liczony w indeksowaniu; „ukryty” odnosi się do wyświetlania, a nie do jego pozycji w kolekcji.

**Czy indeks slajdu zmienia się, gdy dodane lub usunięte są inne slajdy?**

Tak. Indeksy zawsze odzwierciedlają bieżącą kolejność w kolekcji slajdów i są przeliczane po operacjach wstawiania, usuwania i przenoszenia.