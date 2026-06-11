---
title: Konwertuj prezentacje PowerPoint w trybie Handout na Androidzie
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje na notatki w Javie. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla Androida, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji do różnych formatów, w tym tworzenie notatek do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się znaleźć na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Można włączyć ten tryb, ustawiając metodę `setSlidesLayoutOptions` w interfejsach [IPdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihtmloptions/), oraz [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) .

## **Eksport w trybie Handout**

Do skonfigurowania trybu Handout użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów zostanie umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```java
// Załaduj prezentację.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ustaw opcje eksportu.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie w poziomie
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // drukuj numery slajdów
	slidesLayoutOptions.setPrintFrameSlide(true);                     // drukuj ramkę wokół slajdów
	slidesLayoutOptions.setPrintComments(false);                      // brak komentarzy

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Eksportuj prezentację do PDF z wybranym układem.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy. 
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronę w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handouttype/) do 9 miniatur na stronę z układami poziomymi lub pionowymi: 1, 2, 3, 4 (poziomo/pionowo), 6 (poziomo/pionowo) oraz 9 (poziomo/pionowo).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/), lub [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/).