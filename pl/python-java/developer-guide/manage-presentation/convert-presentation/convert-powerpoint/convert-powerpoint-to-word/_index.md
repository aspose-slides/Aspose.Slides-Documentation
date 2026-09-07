---
title: Konwertuj prezentacje PowerPoint na dokumenty Word w Pythonie przy użyciu Java
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /pl/python-java/convert-powerpoint-to-word/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- PowerPoint do Word
- prezentacja do Word
- PPT do Word
- PPTX do Word
- ODP do Word
- PowerPoint do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- zapisz PPT jako DOCX
- zapisz PPTX jako DOCX
- eksportuj PPT do DOCX
- eksportuj PPTX do DOCX
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na Word w Pythonie przy użyciu Java z Aspose.Slides i Aspose.Words, łącząc obrazy slajdów z edytowalnym tekstem."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word przy użyciu Aspose.Slides for Python via Java razem z Aspose.Words for Java. Aspose.Slides renderuje każdy slajd i odczytuje jego tekst, podczas gdy Aspose.Words tworzy dokument Word za pomocą JPype. Microsoft Office nie jest wymagany.

Wynikowy dokument zawiera obraz slajdu, po którym znajduje się edytowalny tekst wyodrębniony z automatycznych kształtów najwyższego poziomu tego slajdu. Obraz zachowuje wizualny wygląd slajdu; poszczególne kształty, wykresy i tabele nie są konwertowane na edytowalne obiekty Word. Wyodrębniony tekst nie zachowuje oryginalnego formatowania ani położenia.

## **Konwertuj PowerPoint do Word**

1. Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) oraz kompatybilne środowisko uruchomieniowe Java.
2. Pobierz [Aspose.Words for Java](https://releases.aspose.com/words/java/). Umieść jego główny plik JAR w katalogu `lib` obok skryptu i zmień jego nazwę na `aspose-words.jar`, albo dostosuj ścieżkę w przykładzie do pobranego pliku.
3. Umieść wejściową prezentację `sample.pptx` w katalogu roboczym. Ścieżka `lib/aspose-words.jar` jest również względna względem tego katalogu.
4. Uruchom poniższy kod Pythona, aby utworzyć `output.docx`.

Przykład ładuje źródło za pomocą [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i renderuje slajdy przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage). Używa [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) z Aspose.Words do wstawiania obrazów i tekstu do dokumentu Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Dopasuj obraz slajdu do szerokości obszaru tekstowego, zachowując proporcje.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Dodaj zwykły tekst z automatycznych kształtów najwyższego poziomu, w tym pola tekstowe.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Każdy slajd zaczyna się na nowej stronie. Długi wyodrębniony tekst lub wyjątkowo wysokie obrazy slajdów mogą wymagać dodatkowych stron. Kod dodaje podziały stron tylko pomiędzy slajdami i zwalnia prezentację oraz renderowane obrazy w blokach `finally`. JVM pozostaje dostępny dla kolejnych konwersji w tym samym procesie Pythona.

## **FAQ**

**Jakie biblioteki są wymagane?**

Użyj Aspose.Slides for Python via Java, JPype, kompatybilnego środowiska uruchomieniowego Java oraz Aspose.Words for Java. Obie biblioteki Aspose działają w tej samej JVM. Aspose.Slides obsługuje prezentację; Aspose.Words zapisuje dokument Word.

**Czy mogę konwertować pliki PPT i ODP, a nie tylko PPTX?**

Tak. Zamień `sample.pptx` na plik PPT lub ODP. Zobacz [Obsługiwane formaty plików](/slides/pl/python-java/supported-file-formats/) aby poznać obsługiwane formaty wejściowe prezentacji.

**Czy cała zawartość slajdu jest edytowalna w Wordzie?**

Nie. Każdy slajd jest wstawiany jako statyczny obraz, a pod nim dodawany jest zwykły tekst z automatycznych kształtów najwyższego poziomu. Tekst wewnątrz grup, tabel, SmartArt i wykresów, a także notatki prelegenta, nie są wyodrębniane w tym przykładzie. Animacje i przejścia nie są odtwarzane w dokumencie Word.

**Czy mogę zapisać jako DOC zamiast DOCX?**

Tak. Zmień nazwę pliku wyjściowego na `output.doc`. Aspose.Words wybiera format wyjściowy na podstawie rozszerzenia nazwy pliku przy użyciu tego przeciążenia metody zapisu.