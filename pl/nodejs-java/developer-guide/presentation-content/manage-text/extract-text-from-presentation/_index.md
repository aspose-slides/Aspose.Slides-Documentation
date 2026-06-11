---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w JavaScript
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko wyodrębniaj tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Node.js via Java. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji to powszechne, a jednocześnie kluczowe zadanie dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być istotny dla analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł zawiera kompleksowy przewodnik, jak efektywnie wyodrębnić tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for Node.js via Java. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie uzyskać potrzebną treść tekstową.

## **Pobieranie tekstu ze slajdu**

Aspose.Slides for Node.js via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/). Klasa ta posiada kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby pobrać tekst ze slajdu w prezentacji, użyj metody [getAllTextBoxes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Metoda ta przyjmuje obiekt slajdu jako parametr. Po uruchomieniu metoda skanuje cały slajd w poszukiwaniu tekstu i zwraca tablicę obiektów [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pobieranie tekstu z prezentacji**

Aby zeskanować tekst z całej prezentacji, użyj statycznej metody [getAllTextFrames](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/). Przyjmuje ona dwa parametry:

1. Pierwszy, obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), reprezentujący prezentację PowerPoint lub OpenDocument, z której ma zostać wyodrębniony tekst.
1. Drugi, wartość typu `boolean` określająca, czy slajdy-matryce mają być uwzględnione przy skanowaniu tekstu w prezentacji.

Metoda zwraca tablicę obiektów [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), zawierających informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania w prezentacji, włączając slajdy-matryce.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategoryzowane i szybkie pobieranie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Argument wyliczenia [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:
- `Unarranged` – surowy tekst bez uwzględniania jego położenia na slajdzie.
- `Arranged` – tekst ułożony w takiej samej kolejności, w jakiej występuje na slajdzie.

Tryb nieuporządkowany może być używany, gdy istotna jest szybkość; jest szybszy niż tryb uporządkowany.

[PresentationText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego metoda `getSlidesText` zwraca tablicę obiektów, z których każdy reprezentuje tekst na odpowiednim slajdzie. Obiekt tekstu slajdu posiada następujące metody:

- Metoda `getText` zwraca tekst znajdujący się w kształtach slajdu.
- Metoda `getMasterText` zwraca tekst znajdujący się w kształtach slajdu‑matrycy powiązanej z tym slajdem.
- Metoda `getLayoutText` zwraca tekst znajdujący się w kształtach slajdu‑układu powiązanego z tym slajdem.
- Metoda `getNotesText` zwraca tekst znajdujący się w kształtach notatek powiązanych z tym slajdem.
- Metoda `getCommentsText` zwraca tekst znajdujący się w komentarzach powiązanych z tym slajdem.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Najczęściej zadawane pytania**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas pobierania tekstu?**

Aspose.Slides jest zoptymalizowane pod kątem wysokiej wydajności i potrafi przetwarzać nawet [duże prezentacje](/slides/pl/nodejs-java/open-presentation/), co czyni je odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub hurtowego.

**Czy Aspose.Slides może wyodrębnić tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów związanych z wykresami, dzięki czemu możesz uzyskać dostęp i analizować treść tekstową w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu bezpłatnej wersji próbnej Aspose.Slides, choć będzie ona miała [pewne ograniczenia](/slides/pl/nodejs-java/licensing/), takie jak przetwarzanie ograniczonej liczby slajdów. Dla nieograniczonego użycia i obsługi większych prezentacji zaleca się zakup pełnej licencji.