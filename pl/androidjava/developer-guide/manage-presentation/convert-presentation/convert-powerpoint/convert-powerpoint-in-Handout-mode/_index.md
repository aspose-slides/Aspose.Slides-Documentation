---
title: Konwertuj prezentacje PowerPoint w trybie Handout na Androidzie
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb Handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje do handoutów w języku Java. Ustaw liczbę slajdów na stronie, zachowaj notatki, eksportuj do PDF lub obrazów za pomocą Aspose.Slides dla Androida, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji do różnych formatów, w tym tworzenia notatek do druku w trybie Handout. Ten tryb pozwala skonfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając metodę `setSlidesLayoutOptions` w interfejsach [IPdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihtmloptions/), oraz [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) .

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/androidjava/notes-size/).

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów jest umieszczanych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```java
import com.aspose.slides.*;

// Załaduj prezentację.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ustaw opcje eksportu.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie w poziomie
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // wydrukuj numery slajdów
	slidesLayoutOptions.setPrintFrameSlide(true);                     // wydrukuj ramkę wokół slajdów
	slidesLayoutOptions.setPrintComments(false);                      // brak komentarzy

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Eksportuj prezentację do PDF z wybranym układem.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniaturek slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handouttype/) umożliwiając do 9 miniaturek na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniaturek są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/), lub [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/).