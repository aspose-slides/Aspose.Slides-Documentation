---
title: Zarządzanie indeksem górnym i dolnym w prezentacjach przy użyciu Pythona poprzez Java
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/python-java/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Opanuj indeksy górny i dolny w Aspose.Slides dla Pythona poprzez Java i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides oferuje funkcje umożliwiające wstawianie tekstu w formacie indeksu górnego i dolnego do prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz wyróżnić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować przejrzystość i precyzję. W tym artykule dowiesz się, jak płynnie zastosować style indeksu górnego i dolnego oraz zapewnić profesjonalny wygląd na każdym slajdzie.

## **Zarządzanie tekstem w indeksie górnym i dolnym**

Możesz dodać tekst w indeksie górnym i dolnym do dowolnej części akapitu. Aby zastosować to formatowanie w ramce tekstowej Aspose.Slides, użyj metody [setEscapement](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#setEscapement) klasy [PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/).

Wartość escapement waha się od -100 % (indeks dolny) do 100 % (indeks górny). Na przykład:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Pobierz slajd według jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Rectangle) do slajdu.
- Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
- Wyczyść istniejące akapity.
- Utwórz akapit przechowujący tekst w indeksie górnym i dodaj go do [kolekcji akapitów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParagraphs) ramki tekstowej.
- Utwórz fragment.
- Użyj [setEscapement](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#setEscapement), aby ustawić wartość od 0 do 100 dla indeksu górnego (0 oznacza brak indeksu górnego).
- Ustaw tekst [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) i dodaj go do kolekcji fragmentów akapitu.
- Utwórz akapit przechowujący tekst w indeksie dolnym i dodaj go do [kolekcji akapitów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParagraphs) ramki tekstowej.
- Utwórz fragment.
- Użyj [setEscapement](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#setEscapement), aby ustawić wartość od -100 do 0 dla indeksu dolnego (0 oznacza brak indeksu dolnego).
- Ustaw tekst [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) i dodaj go do kolekcji fragmentów akapitu.
- Zapisz prezentację jako plik PPTX.

Poniższy przykład implementuje te kroki:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Utwórz prezentację.
presentation = Presentation()
try:
    # Pobierz slajd.
    slide = presentation.getSlides().get_Item(0)

    # Utwórz pole tekstowe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Utwórz akapit dla tekstu w indeksie górnym.
    superscript_paragraph = Paragraph()

    # Utwórz fragment z normalnym tekstem.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Utwórz fragment z tekstem w indeksie górnym.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Utwórz akapit dla tekstu w indeksie dolnym.
    subscript_paragraph = Paragraph()

    # Utwórz fragment z normalnym tekstem.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Utwórz fragment z tekstem w indeksie dolnym.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Dodaj akapity do pola tekstowego.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy indeksy górny i dolny są zachowywane przy eksportowaniu do PDF lub innych formatów?**

Tak, Aspose.Slides prawidłowo zachowuje formatowanie indeksu górnego i dolnego podczas eksportowania prezentacji do PDF, PPT/PPTX, obrazów i innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje nienaruszone we wszystkich plikach wyjściowych.

**Czy indeksy górny i dolny można łączyć z innymi stylami formatowania, takimi jak pogrubienie lub kursywa?**

Tak, Aspose.Slides umożliwia mieszanie różnych stylów tekstu w ramach jednego fragmentu. Możesz włączyć pogrubienie, kursywę, podkreślenie oraz jednocześnie zastosować indeks górny lub dolny, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/).

**Czy formatowanie indeksu górnego i dolnego działa na tekst wewnątrz tabel, wykresów lub SmartArt?**

Tak, Aspose.Slides obsługuje formatowanie w większości obiektów, w tym w tabelach i elementach wykresów. Pracując z SmartArt, należy uzyskać dostęp do odpowiednich elementów (takich jak [SmartArtNode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/)) i ich kontenerów tekstowych, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/) w podobny sposób.