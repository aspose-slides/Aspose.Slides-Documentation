---
title: Dostęp do slajdów prezentacji na Androidzie
linktitle: Dostęp do slajdu
type: docs
weight: 20
url: /pl/androidjava/access-slide-in-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak uzyskać dostęp do slajdów i zarządzać nimi w prezentacjach PowerPoint oraz OpenDocument przy użyciu Aspose.Slides dla Androida. Zwiększ wydajność dzięki przykładom kodu w Javie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać dostęp do slajdów w prezentacji i zarządzać nimi przy użyciu Aspose.Slides. Pokazuje, jak pobierać slajdy według ich indeksu zerowego z kolekcji slajdów oraz jak uzyskać dostęp do slajdu po jego unikalnym identyfikatorze za pomocą metody `getSlideById`.

Dowiesz się również, jak zmienić pozycję slajdu za pomocą metody `setSlideNumber` oraz jak określić początkowy numer slajdu w prezentacji przy użyciu metody `setFirstSlideNumber`. Przykłady pokazują ładowanie prezentacji, uzyskiwanie odniesień do slajdów, aktualizację kolejności lub numeracji slajdów oraz zapisywanie zmodyfikowanej prezentacji.

## **Dostęp do slajdu według indeksu**

Wszystkie slajdy w prezentacji są uporządkowane numerycznie w oparciu o pozycję slajdu, zaczynając od 0. Pierwszy slajd jest dostępny pod indeksem 0; drugi slajd jest dostępny pod indeksem 1; itd.

Klasa Presentation, reprezentująca plik prezentacji, udostępnia wszystkie slajdy jako kolekcję [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) (kolekcję obiektów [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/)). Ten kod Java pokazuje, jak uzyskać dostęp do slajdu za pomocą jego indeksu:

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("demo.pptx");
try {
    // Uzyskuje dostęp do slajdu przy użyciu jego indeksu
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Dostęp do slajdu po ID**

Każdy slajd w prezentacji ma przypisany unikalny identyfikator (ID). Możesz użyć metody [getSlideById](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/)), aby odwołać się do tego ID. Ten kod Java pokazuje, jak podać prawidłowy identyfikator slajdu i uzyskać dostęp do tego slajdu za pomocą metody [getSlideById](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("demo.pptx");
try {
    // Pobiera identyfikator slajdu
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Uzyskuje dostęp do slajdu za pomocą jego ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Zmienianie pozycji slajdu**

Aspose.Slides umożliwia zmianę pozycji slajdu. Na przykład możesz określić, że pierwszy slajd ma stać się drugim slajdem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu (którego pozycję chcesz zmienić) za pomocą jego indeksu
1. Ustaw nową pozycję slajdu za pomocą właściwości [setSlideNumber](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. Zapisz zmodyfikowaną prezentację.

Ten kod Java demonstruje operację, w której slajd znajdujący się na pozycji 1 zostaje przeniesiony na pozycję 2: 

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Pobiera slajd, którego pozycja zostanie zmieniona
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ustawia nową pozycję slajdu
    sld.setSlideNumber(2);
    
    // Zapisuje zmodyfikowaną prezentację
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Pierwszy slajd stał się drugim; drugi slajd stał się pierwszym. Gdy zmieniasz pozycję slajdu, pozostałe slajdy są automatycznie przestawiane.

## **Ustawianie numeru slajdu**

Za pomocą właściwości [setFirstSlideNumber](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/)) możesz określić nowy numer pierwszego slajdu w prezentacji. Ta operacja powoduje przeliczenie numerów pozostałych slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Uzyskaj numer slajdu.
1. Ustaw numer slajdu.
1. Zapisz zmodyfikowaną prezentację.

Ten kod Java demonstruje operację, w której numer pierwszego slajdu jest ustawiony na 10: 

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Pobiera numer pierwszego slajdu
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Ustawia numer pierwszego slajdu
    pres.setFirstSlideNumber(10);
	
    // Zapisuje zmodyfikowaną prezentację
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Jeśli wolisz pominąć pierwszy slajd, możesz rozpocząć numerację od drugiego slajdu (i ukryć numerację dla pierwszego slajdu) w ten sposób:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Ustawia numer dla pierwszego slajdu prezentacji
    presentation.setFirstSlideNumber(0);

    // Wyświetla numery slajdów dla wszystkich slajdów
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Ukrywa numer slajdu dla pierwszego slajdu
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Zapisuje zmodyfikowaną prezentację
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Czy numer slajdu widziany przez użytkownika odpowiada zerowo‑indeksowanej kolekcji?**

Numer wyświetlany na slajdzie może zaczynać się od dowolnej wartości (np. 10) i nie musi odpowiadać indeksowi; zależność jest kontrolowana przez ustawienie [first slide number](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) w prezentacji.

**Czy ukryte slajdy wpływają na indeksowanie?**

Tak. Ukryty slajd pozostaje w kolekcji i jest uwzględniany w indeksowaniu; „ukryty” odnosi się do wyświetlania, a nie do jego pozycji w kolekcji.

**Czy indeks slajdu zmienia się, gdy dodawane lub usuwane są inne slajdy?**

Tak. Indeksy zawsze odzwierciedlają aktualny porządek slajdów i są przeliczane po operacjach wstawiania, usuwania i przenoszenia.