---
title: Animowanie tekstu PowerPoint w Pythonie
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/python-net/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez .NET, z łatwymi do zrozumienia, zoptymalizowanymi przykładami kodu."
---
## **Przegląd**

Ten artykuł pokazuje, jak animować tekst w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona. Nauczysz się dodawać efekty do pojedynczych akapitów, dostosowywać wyzwalacze i odczytywać istniejące sekwencje animacji. Po zakończeniu będziesz w stanie tworzyć wielokrotnego użytku przepływy pracy animacji tekstu, które eksportują do standardowego pliku PPTX i odtwarzają się prawidłowo w programie PowerPoint.

## **Dodaj efekty animacji akapitu**

Metoda [add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/) klasy [Sequence](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/) umożliwia zastosowanie efektu animacji do pojedynczego akapitu. Poniższy kod przykładowy pokazuje, jak to zrobić:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Wybierz akapit, do którego chcesz dodać efekt.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Dodaj efekt animacji Fly do wybranego akapitu.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobierz efekty animacji akapitu**

Możesz chcieć ustalić, które efekty animacji są zastosowane do akapitu — na przykład, jeśli planujesz skopiować te efekty do innego akapitu lub kształtu.

Aspose.Slides dla Pythona umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów w ramce tekstowej (kształcie). Poniższy kod przykładowy pokazuje, jak uzyskać efekty animacji akapitu:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**Czym różnią się animacje tekstu od przejść slajdów i czy można je łączyć?**

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [przejścia](/slides/pl/python-net/slide-transition/) kontrolują, w jaki sposób zmieniają się slajdy. Są niezależne i mogą być używane razem; kolejność odtwarzania jest określana przez oś czasu animacji oraz ustawienia przejść.

**Czy animacje tekstu są zachowywane przy eksporcie do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie jedną, nieruchomą wersję slajdu. Aby zachować ruch, użyj eksportu do [video](/slides/pl/python-net/convert-powerpoint-to-video/) lub [HTML](/slides/pl/python-net/export-to-html5/).

**Czy animacje tekstu działają w układach i w masterze slajdów?**

Efekty zastosowane do obiektów układu/mastera są dziedziczone przez slajdy, ale ich timing oraz interakcja z animacjami na poziomie slajdu zależą od ostatecznej sekcji na slajdzie.