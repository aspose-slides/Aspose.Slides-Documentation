---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w Pythonie
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/python-net/extract-text-from-presentation/
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
- Python
- Aspose.Slides
description: "Szybko wyodrębniaj tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie istotnym zadaniem dla programistów pracujących z treścią slajdów. Niezależnie od tego, czy chodzi o pliki Microsoft PowerPoint w formacie PPT lub PPTX, czy o prezentacje OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być kluczowe dla analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł zapewnia kompleksowy przewodnik, jak skutecznie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for Python via .NET. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for Python via .NET udostępnia przestrzeń nazw [aspose.slides.util](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/), która zawiera klasę [SlideUtil](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu.

Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [get_all_text_boxes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Metoda ta przyjmuje jako parametr obiekt typu [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/). Po wykonaniu metoda przeszukuje cały slajd pod kątem tekstu i zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Wyodrębnianie tekstu z prezentacji**

Aby zeskanować tekst z całej prezentacji, użyj statycznej metody [get_all_text_frames](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/get_all_text_frames/) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/). Przyjmuje ona dwa parametry:

1. Po pierwsze, obiekt [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), reprezentujący prezentację PowerPoint lub OpenDocument, z której zostanie wyodrębniony tekst.  
1. Po drugie, wartość `Boolean` wskazująca, czy podczas skanowania tekstu z prezentacji należy uwzględnić slajdy główne.

Metoda zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania z prezentacji, w tym slajdy główne.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Argument wyliczenia [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjąć następujące wartości:
- `UNARRANGED` - Surowy tekst bez uwzględniania jego pozycji na slajdzie.  
- `ARRANGED` - Tekst jest ułożony w takiej samej kolejności, jak na slajdzie.

Tryb `UNARRANGED` może być używany, gdy kluczowa jest prędkość; jest szybszy niż tryb `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego właściwość `slides_text` zwraca tablicę obiektów tekstu slajdu. Każdy obiekt reprezentuje tekst na odpowiednim slajdzie i ma następujące właściwości:

- `text` - Tekst wewnątrz kształtów slajdu.  
- `master_text` - Tekst wewnątrz kształtów slajdu głównego powiązanego z tym slajdem.  
- `layout_text` - Tekst wewnątrz kształtów slajdu układu powiązanego z tym slajdem.  
- `notes_text` - Tekst wewnątrz kształtów slajdu notatek powiązanego z tym slajdem.  
- `comments_text` - Tekst w komentarzach powiązanych z tym slajdem.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowany pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/python-net/open-presentation/), co czyni go odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub masowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym tabel i obiektów związanych z wykresami, dzięki czemu możesz uzyskać dostęp do treści tekstowych i analizować je w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst za pomocą darmowej wersji próbnej Aspose.Slides, choć będzie ona miała [pewne ograniczenia](/slides/pl/python-net/licensing/), takie jak przetwarzanie tylko ograniczonej liczby slajdów. Dla nieograniczonego użytku i obsługi większych prezentacji zaleca się zakup pełnej licencji.