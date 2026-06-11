---
title: "Konwertuj prezentacje PowerPoint do dokumentów Word w Pythonie"
linktitle: "PowerPoint do Word"
type: docs
weight: 110
url: /pl/python-net/convert-powerpoint-to-word/
keywords:
- "PowerPoint do DOCX"
- "OpenDocument do DOCX"
- "prezentacja do DOCX"
- "slajd do DOCX"
- "PPT do DOCX"
- "PPTX do DOCX"
- "ODP do DOCX"
- "PowerPoint do DOC"
- "OpenDocument do DOC"
- "prezentacja do DOC"
- "slajd do DOC"
- "PPT do DOC"
- "PPTX do DOC"
- "ODP do DOC"
- "PowerPoint do Word"
- "OpenDocument do Word"
- "prezentacja do Word"
- "slajd do Word"
- "PPT do Word"
- "PPTX do Word"
- "ODP do Word"
- "konwertuj PowerPoint"
- "konwertuj OpenDocument"
- "konwertuj prezentację"
- "konwertuj slajd"
- "konwertuj PPT"
- "konwertuj PPTX"
- "konwertuj ODP"
- "Python"
- "Aspose.Slides"
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word przy użyciu Aspose.Slides for Python via .NET. Nasz szczegółowy przewodnik z przykładowym kodem w Pythonie zapewnia rozwiązanie dla programistów, którzy chcą usprawnić swoje procesy dokumentacyjne."
---
## **Przegląd**

Ten artykuł dostarcza rozwiązanie dla programistów umożliwiające konwertowanie prezentacji PowerPoint i OpenDocument do dokumentów Word przy użyciu Aspose.Slides for Python via .NET oraz Aspose.Words for Python via .NET. Poradnik krok po kroku przeprowadza Cię przez każdy etap procesu konwersji.

## **Konwersja prezentacji do dokumentu Word**

Postępuj zgodnie z poniższymi instrukcjami, aby przekonwertować prezentację PowerPoint lub OpenDocument na dokument Word:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj plik prezentacji.  
2. Utwórz instancje klas [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) oraz [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/), aby wygenerować dokument Word.  
3. Ustaw rozmiar strony dokumentu Word, aby odpowiadał rozmiarowi prezentacji, używając właściwości [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. Ustaw marginesy w dokumencie Word, używając właściwości [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. Przejdź przez wszystkie slajdy prezentacji, używając właściwości [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/).  
   - Wygeneruj obraz slajdu za pomocą metody `get_image` z klasy [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) i zapisz go do strumienia pamięci.  
   - Dodaj obraz slajdu do dokumentu Word, używając metody `insert_image` z klasy [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).  
6. Zapisz dokument Word do pliku.

Załóżmy, że mamy prezentację „sample.pptx”, która wygląda następująco:

![Prezentacja PowerPoint](PowerPoint.png)

Poniższy przykład kodu w języku Python pokazuje, jak przekonwertować prezentację PowerPoint na dokument Word:

```py
import aspose.slides as slides
import aspose.words as words

# Załaduj plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:

    # Utwórz obiekty Document i DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Ustaw rozmiar strony w dokumencie Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Ustaw marginesy w dokumencie Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Przejdź przez wszystkie slajdy prezentacji.
    for slide in presentation.slides:

        # Wygeneruj obraz slajdu i zapisz go do strumienia pamięci.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Dodaj obraz slajdu do dokumentu Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Zapisz dokument Word do pliku.
    document.save("output.docx")
```

Wynik:

![Dokument Word](Word.png)

{{% alert color="primary" %}} 
Wypróbuj nasz [**Internetowy konwerter PPT do Word**](https://products.aspose.app/slides/pl/conversion/ppt-to-word), aby zobaczyć, co możesz zyskać, konwertując prezentacje PowerPoint i OpenDocument do dokumentów Word. 
{{% /alert %}}

## **FAQ**

**Jakie składniki należy zainstalować, aby konwertować prezentacje PowerPoint i OpenDocument do dokumentów Word?**

Wystarczy dodać odpowiednie pakiety dla [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) oraz [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) do swojego projektu Python. Oba pakiety działają jako samodzielne API i nie ma potrzeby instalowania Microsoft Office.

**Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?**

Aspose.Slides for Python .NET [obsługuje wszystkie formaty prezentacji](/slides/pl/python-net/supported-file-formats/), w tym PPT, PPTX, ODP i inne popularne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.