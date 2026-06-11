---
title: Konwertuj prezentacje PowerPoint na dokumenty Word w systemie Android
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /pl/androidjava/convert-powerpoint-to-word/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do Word
- prezentacja do Word
- slajd do Word
- PPT do Word
- PPTX do Word
- PowerPoint do DOCX
- prezentacja do DOCX
- slajd do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentacja do DOC
- slajd do DOC
- PPT do DOC
- PPTX do DOC
- zapisz PPT jako DOCX
- zapisz PPTX jako DOCX
- eksportuj PPT do DOCX
- eksportuj PPTX do DOCX
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint PPT i PPTX na edytowalne dokumenty Word w języku Java przy użyciu Aspose.Slides dla Android, zachowując dokładny układ, obrazy i formatowanie."
---
## **Przegląd**

Ten artykuł zapewnia rozwiązanie dla programistów dotyczące konwertowania prezentacji PowerPoint i OpenDocument na dokumenty Word przy użyciu Aspose.Slides i Aspose.Words. Przewodnik krok po kroku prowadzi przez każdy etap procesu konwersji.

## **Aspose.Slides i Aspose.Words**

Aby przekonwertować plik PowerPoint (PPTX lub PPT) na Word (DOCX lub DOC), potrzebne są zarówno [Aspose.Slides for Android via Java](https://products.aspose.com/slides/pl/androidjava/) jak i [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Jako samodzielne API, [Aspose.Slides](https://products.aspose.app/slides) dla java udostępnia funkcje pozwalające na wyodrębnianie tekstu z prezentacji. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) to zaawansowane API przetwarzania dokumentów, które umożliwia aplikacjom generowanie, modyfikowanie, konwertowanie, renderowanie, drukowanie plików oraz wykonywanie innych zadań na dokumentach bez użycia Microsoft Word.

## **Konwertuj PowerPoint na Word**

1. Pobierz biblioteki [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/pl/java) oraz [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Dodaj *aspose-slides-x.x-jdk16.jar* i *aspose-words-x.x-jdk16.jar* do swojego CLASSPATH.
3. Użyj poniższego fragmentu kodu, aby przekonwertować PowerPoint na Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // generuje obraz slajdu jako strumień bajtów
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // wstawia teksty slajdu
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **FAQ**

**Jakie komponenty muszą być zainstalowane, aby konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word?**

Wystarczy dodać odpowiedni pakiet dla [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/pl/androidjava/) i [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) do projektu. Obie biblioteki działają jako samodzielne API i nie ma wymogu instalacji Microsoft Office.

**Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?**

Aspose.Slides [obsługuje wszystkie formaty prezentacji](/slides/pl/androidjava/supported-file-formats/), w tym PPT, PPTX, ODP i inne powszechne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.