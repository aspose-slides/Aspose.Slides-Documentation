---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w Javie
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/java/extract-text-from-presentation/
keywords:
- wyodrębnij tekst
- wyodrębnij tekst ze slajdu
- wyodrębnij tekst z prezentacji
- wyodrębnij tekst z PowerPoint
- wyodrębnij tekst z OpenDocument
- wyodrębnij tekst z PPT
- wyodrębnij tekst z PPTX
- wyodrębnij tekst z ODP
- pobierz tekst
- pobierz tekst ze slajdu
- pobierz tekst z prezentacji
- pobierz tekst z PowerPoint
- pobierz tekst z OpenDocument
- pobierz tekst z PPT
- pobierz tekst z PPTX
- pobierz tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Szybko wyodrębnij tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Java. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie kluczowym zadaniem dla programistów pracujących z treścią slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być niezbędne do analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł zawiera kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for Java. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/). Klasa ta zawiera kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Metoda ta przyjmuje jako parametr obiekt typu [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/). Po wykonaniu metoda przeszukuje cały slajd pod kątem tekstu i zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/), zachowując wszelkie formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie tekstu z prezentacji**

Aby przeszukać tekst w całej prezentacji, użyj statycznej metody [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/). Przyjmuje ona dwa parametry:

1. Pierwszy – obiekt [IPresentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/) reprezentujący prezentację PowerPoint lub OpenDocument, z której zostanie wyodrębiony tekst.  
2. Drugi – wartość `boolean` określająca, czy slajdy master mają być uwzględnione przy skanowaniu tekstu w prezentacji.

Metoda zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania w prezentacji, w tym slajdy master:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argument wyliczeniowy [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:

- `Unarranged` – surowy tekst bez uwzględnienia jego pozycji na slajdzie.  
- `Arranged` – tekst ułożony w takiej samej kolejności, jak na slajdzie.

Tryb nieuporządkowany (`Unarranged`) można stosować, gdy liczy się prędkość; jest szybszy niż tryb uporządkowany.

[IPresentationText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego metoda `getSlidesText` zwraca tablicę obiektów typu [ISlideText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidetext/). Każdy obiekt reprezentuje tekst na odpowiadającym slajdzie. Obiekt typu [ISlideText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidetext/) posiada następujące metody:

- `getText` – tekst znajdujący się w kształtach slajdu.  
- `getMasterText` – tekst w kształtach slajdu master powiązanym z tym slajdem.  
- `getLayoutText` – tekst w kształtach slajdu układu powiązanego z tym slajdem.  
- `getNotesText` – tekst w kształtach notatek powiązanych z tym slajdem.  
- `getCommentsText` – tekst w komentarzach powiązanych z tym slajdem.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowane pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/java/open-presentation/), co czyni je odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub masowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdów, w tym z tabel i obiektów związanych z wykresami, co umożliwia dostęp i analizę treści tekstowych w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Można wyodrębniać tekst przy użyciu wersji próbnej Aspose.Slides, choć będzie ona miała [określone ograniczenia](/slides/pl/java/licensing/), takie jak przetwarzanie ograniczonej liczby slajdów. Dla nieograniczonego użycia i obsługi większych prezentacji zaleca się zakup pełnej licencji.