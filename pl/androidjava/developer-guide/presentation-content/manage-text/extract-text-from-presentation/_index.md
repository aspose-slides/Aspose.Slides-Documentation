---
title: Zaawansowane wyodrębnianie tekstu z prezentacji na Androidzie
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/androidjava/extract-text-from-presentation/
keywords:
- wyodrębnić tekst
- wyodrębnić tekst ze slajdu
- wyodrębnić tekst z prezentacji
- wyodrębnić tekst z PowerPoint
- wyodrębnić tekst z OpenDocument
- wyodrębnić tekst z PPT
- wyodrębnić tekst z PPTX
- wyodrębnić tekst z ODP
- pobrać tekst
- pobrać tekst ze slajdu
- pobrać tekst z prezentacji
- pobrać tekst z PowerPoint
- pobrać tekst z OpenDocument
- pobrać tekst z PPT
- pobrać tekst z PPTX
- pobrać tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Szybko wyodrębniaj tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie kluczowym zadaniem dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być istotny dla analizy, automatyzacji, indeksowania lub migracji treści.

W tym artykule znajdziesz kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for Android via Java. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for Android via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [getAllTextBoxes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Metoda ta przyjmuje jako parametr obiekt typu [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/). Po uruchomieniu metoda przeszukuje cały slajd pod kątem tekstu i zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), zachowując formatowanie tekstu.

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

Aby zeskanować tekst z całej prezentacji, użyj statycznej metody [getAllTextFrames](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/). Przyjmuje ona dwa parametry:

1. Obiekt [IPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/) reprezentujący prezentację PowerPoint lub OpenDocument, z której ma zostać wyodrębniony tekst.
2. Wartość `boolean` określająca, czy slajdy wzorcowe mają być uwzględnione podczas skanowania tekstu z prezentacji.

Metoda zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania z prezentacji, w tym ze slajdów wzorcowych.

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

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argument wyliczenia [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:
- `Unarranged` – surowy tekst bez uwzględnienia jego położenia na slajdzie.
- `Arranged` – tekst uporządkowany w takiej samej kolejności, jak na slajdzie.

Tryb nieuporządkowany może być używany, gdy liczy się prędkość; jest szybszy niż tryb uporządkowany.

[IPresentationText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego metoda `getSlidesText` zwraca tablicę obiektów typu [ISlideText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidetext/). Każdy obiekt reprezentuje tekst na odpowiadającym mu slajdzie. Obiekt typu [ISlideText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidetext/) posiada następujące metody:

- `getText` – tekst znajdujący się w kształtach slajdu.
- `getMasterText` – tekst znajdujący się w kształtach slajdu wzorcowego powiązanego z tym slajdem.
- `getLayoutText` – tekst znajdujący się w kształtach slajdu układu powiązanego z tym slajdem.
- `getNotesText` – tekst znajdujący się w kształtach slajdu notatek powiązanego z tym slajdem.
- `getCommentsText` – tekst znajdujący się w komentarzach powiązanych z tym slajdem.

```java
String presentationPath = "presentation.pptx";
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

Aspose.Slides jest zoptymalizowany pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/androidjava/open-presentation/), co czyni go odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub hurtowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides potrafi wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów związanych z wykresami, dzięki czemu możesz uzyskać dostęp i analizować treść tekstową w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu darmowej wersji próbnej Aspose.Slides, choć będzie ona miała [określone ograniczenia](/slides/pl/androidjava/licensing/), takie jak przetwarzanie jedynie ograniczonej liczby slajdów. Dla nieograniczonego użycia i obsługi większych prezentacji zaleca się zakup pełnej licencji.