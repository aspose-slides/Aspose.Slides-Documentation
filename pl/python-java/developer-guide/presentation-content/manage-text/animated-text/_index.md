---
title: Animowanie tekstu PowerPoint w Pythonie przy użyciu Javy
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/python-java/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via Java, z łatwymi do śledzenia, zoptymalizowanymi przykładami kodu w Pythonie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do poszczególnych akapitów oraz pobierając efekty już przypisane akapitom w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Metoda [addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) klasy [Sequence](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/) umożliwia dodanie efektów animacji do jednego akapitu. Ten przykładowy kod pokazuje, jak dodać efekt animacji do pojedynczego akapitu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Wybierz akapit, do którego chcesz dodać efekt.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Dodaj efekt animacji Fly do wybranego akapitu.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pobieranie efektów animacji akapitów**

Możesz chcieć pobrać efekty animacji zastosowane do akapitu — na przykład, aby zastosować te efekty do innego akapitu lub kształtu.

Aspose.Slides for Python via Java umożliwia uzyskanie wszystkich efektów animacji zastosowanych do akapitów zawartych w ramce tekstowej (kształcie). Ten przykładowy kod pokazuje, jak pobrać efekty animacji zastosowane do akapitu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [przejścia](/slides/pl/python-java/slide-transition/) kontrolują, jak slajdy się zmieniają. Są niezależne i mogą być używane razem; kolejność odtwarzania jest sterowana przez oś czasu animacji i ustawienia przejść.

**Czy animacje tekstu są zachowywane podczas eksportu do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie pojedynczy stan slajdu bez ruchu. Aby zachować animację, użyj eksportu do [wideo](/slides/pl/python-java/convert-powerpoint-to-video/) lub [HTML](/slides/pl/python-java/export-to-html5/).

**Czy animacje tekstu działają w układach i szablonie slajdu?**

Efekty zastosowane do obiektów układu/szablonu są dziedziczone przez slajdy, ale ich synchronizacja i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.