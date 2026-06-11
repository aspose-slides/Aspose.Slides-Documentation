---
title: Zarządzanie indeksem górnym i dolnym w Pythonie
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/python-net/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj indeksy górny i dolny w Aspose.Slides dla Pythona w środowisku .NET i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu o maksymalnym oddziaływaniu."
---
## **Overview**

Aspose.Slides oferuje funkcje umożliwiające wstawianie tekstu w indeksie górnym i dolnym do prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz wyróżnić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować przejrzystość i precyzję. W tym artykule dowiesz się, jak płynnie zastosować style indeksu górnego i dolnego oraz zapewnić profesjonalny wygląd na każdym slajdzie.

## **Add Superscript and Subscript Text**

Możesz dodać tekst w indeksie górnym i dolnym do dowolnej części akapitu. W Aspose.Slides użyj własności `escapement` klasy [PortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/), aby to kontrolować.

`escapement` jest procentem w zakresie od **-100% do 100%**:

- **> 0** → indeks górny (np. 25% = lekkie podniesienie; 100% = pełny indeks górny)
- **0** → linia bazowa (brak indeksu górnego/dolnego)
- **< 0** → indeks dolny (np. -25% = lekkie obniżenie; -100% = pełny indeks dolny)

Kroki:

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i pobierz slajd.
2. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) i uzyskaj dostęp do jej [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/).
3. Wyczyść istniejące akapity.
4. Dla indeksu górnego: utwórz akapit i fragment, ustaw `portion.portion_format.escapement` na wartość w przedziale od **0 do 100**, ustaw tekst i dodaj fragment.
5. Dla indeksu dolnego: utwórz kolejny akapit i fragment, ustaw `escapement` na wartość w przedziale od **-100 do 0**, ustaw tekst i dodaj fragment.
6. Zapisz prezentację jako PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Pobierz slajd.
    slide = presentation.slides[0]

    # Utwórz pole tekstowe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Utwórz akapit dla tekstu w indeksie górnym.
    superscript_paragraph = slides.Paragraph()

    # Utwórz fragment tekstu z zwykłym tekstem.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Utwórz fragment tekstu w indeksie górnym.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Utwórz akapit dla tekstu w indeksie dolnym.
    subscript_paragraph = slides.Paragraph()

    # Utwórz fragment tekstu z zwykłym tekstem.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Utwórz fragment tekstu w indeksie dolnym.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Dodaj akapity do pola tekstowego.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zastosować indeks górny/dolny w tabelach i innych kontenerach, a nie tylko w zwykłych polach tekstowych?**

Tak. Możesz formatować tekst jako indeks górny lub dolny w dowolnym obiekcie, który udostępnia [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) (w tym w komórkach tabel). Formatowanie ma zastosowanie do fragmentów tekstu w ramach tej ramki.

**Czy indeksy górny i dolny zostaną zachowane podczas eksportu do PDF, HTML lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie indeksu górnego/dolnego podczas eksportu do popularnych formatów, takich jak [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) i [obrazy rastrowe](/slides/pl/python-net/convert-powerpoint-to-png/), ponieważ potok renderowania respektuje formatowanie tekstu na poziomie fragmentów.

**Czy mogę połączyć indeks górny/dolny z hiperłączami w tym samym fragmencie tekstu?**

Tak. [Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są przypisywane na poziomie fragmentu (portion), więc fragment może jednocześnie mieć hiperłącze i być sformatowany jako indeks górny lub dolny.