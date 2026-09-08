---
title: Animowanie tekstu PowerPoint w Pythonie przez Java
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
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona przez Java, korzystając z prostych, zoptymalizowanych przykładów kodu w Pythonie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do pojedynczych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Metoda [addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) klasy [Sequence](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/) pozwala dodać efekty animacji do pojedynczego akapitu. Poniższy przykładowy kod pokazuje, jak dodać efekt animacji do jednego akapitu:

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

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu — na przykład w jednej sytuacji chcesz pobrać efekty animacji z akapitu, aby zastosować je w innym akapicie lub kształcie.

Aspose.Slides for Python via Java umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów zawartych w ramce tekstowej (kształcie). Poniższy przykładowy kod pokazuje, jak uzyskać efekty animacji w akapicie:

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

**Czym różnią się animacje tekstu od przejść slajdów i czy można je łączyć?**
Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, natomiast [przejścia](/slides/pl/python-java/slide-transition/) kontrolują, jak zmieniają się slajdy. Są niezależne i mogą być używane razem; kolejność odtwarzania jest określana przez oś czasu animacji i ustawienia przejść.

**Czy animacje tekstu są zachowywane przy eksportowaniu do PDF lub obrazów?**
Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie jedną, nieruchomą wersję slajdu. Aby zachować ruch, użyj eksportu do [wideo](/slides/pl/python-java/convert-powerpoint-to-video/) lub [HTML](/slides/pl/python-java/export-to-html5/).

**Czy animacje tekstu działają w układach i wzorcu slajdów?**
Efekty zastosowane do obiektów układu/matrycy są dziedziczone przez slajdy, jednak ich timing i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.