---
title: Konwertuj prezentacje PowerPoint na dokumenty Word w Javie
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /pl/java/convert-powerpoint-to-word/
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
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint PPT i PPTX na edytowalne dokumenty Word w Javie przy użyciu Aspose.Slides, zachowując precyzyjny układ, obrazy i formatowanie."
---
## **Przegląd**

Ten artykuł dostarcza rozwiązanie dla programistów umożliwiające konwersję prezentacji PowerPoint i OpenDocument do dokumentów Word przy użyciu Aspose.Slides i Aspose.Words. Przewodnik krok po kroku prowadzi Cię przez każdy etap procesu konwersji.

## **Konwertuj PowerPoint na Word**

Postępuj zgodnie z poniższymi instrukcjami, aby przekonwertować prezentację PowerPoint lub OpenDocument na dokument Word:

1. Pobierz biblioteki [Aspose.Slides for Java](https://downloads.aspose.com/slides/pl/java) i [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Dodaj *aspose-slides-x.x-jdk16.jar* i *aspose-words-x.x-jdk16.jar* do swojej CLASSPATH.
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

**Jakie komponenty należy zainstalować, aby konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word?**

Wystarczy dodać odpowiedni pakiet [Aspose.Slides for Java](https://releases.aspose.com/slides/pl/java/) oraz [Aspose.Words for Java](https://releases.aspose.com/words/java/) do swojego projektu. Obie biblioteki działają jako samodzielne API i nie ma wymogu instalacji Microsoft Office.

**Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?**

Aspose.Slides [obsługuje wszystkie formaty prezentacji](/slides/pl/java/supported-file-formats/), w tym PPT, PPTX, ODP i inne popularne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.