---
title: Wsparcie dla biblioteki z możliwością przerywania
type: docs
weight: 120
url: /pl/python-java/support-for-interruptable-library/
keywords:
- biblioteka z możliwością przerywania
- token przerywania
- token anulowania
- zadanie długotrwałe
- przerwać zadanie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Umożliwienie anulowania długotrwałych zadań przy użyciu Aspose.Slides dla Pythona w środowisku Java. Bezpieczne przerywanie renderowania i konwersji dla PowerPoint i OpenDocument, wraz z przykładami."
---
## **Przegląd**

Aspose.Slides udostępnia mechanizm przetwarzania z możliwością przerwania dla długotrwałych zadań związanych z prezentacjami, takich jak deserializacja, serializacja i renderowanie. Mechanizm ten opiera się na klasach [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/) i [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/).

Obiekt [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/) może być przypisany do [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/) i przekazany do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Gdy wywołana zostanie metoda [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt), powiązane długotrwałe zadanie zostaje przerwane.

## **Biblioteka z możliwością przerwania**

Aspose.Slides for Python via Java udostępnia klasy [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/) i [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/). Umożliwiają one przerywanie długotrwałych zadań, takich jak deserializacja, serializacja i renderowanie.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/) jest źródłem tokenu(ów) przekazywanych do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Gdy wywołana zostanie metoda [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setInterruptionToken), a instancja [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/) zostanie przekazana do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt) przerywa każde długotrwałe zadanie powiązane z tym [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).

Poniższy fragment kodu demonstruje przerwanie działającego zadania:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Uruchom akcję w osobnym wątku.
    time.sleep(10)  # Limit czasu.
    token_source.interrupt()  # Zatrzymaj konwersję.
    conversion_task.result()
```

## **FAQ**

**Jaki jest cel biblioteki przerywania w Aspose.Slides?**

Zapewnia mechanizm przerywania długotrwałych operacji—takich jak ładowanie, zapisywanie lub renderowanie prezentacji—zanim zostaną zakończone. Jest to przydatne, gdy czas przetwarzania musi być ograniczony lub zadanie nie jest już potrzebne.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/) jest przekazywany do API Aspose.Slides i sprawdzany podczas długotrwałych operacji.
- [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/) jest używany w Twoim kodzie do tworzenia tokenów oraz wywoływania przerwań poprzez wywołanie [interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Jakie zadania można przerywać?**

Każde zadanie Aspose.Slides, które przyjmuje [InterruptionToken](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontoken/), takie jak ładowanie prezentacji przy użyciu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) lub zapisywanie przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), może zostać przerwane.

**Czy przerwanie następuje natychmiast?**

Nie. Przerwanie jest współpracujące: operacja okresowo sprawdza token i zatrzymuje się, gdy tylko wykryje, że wywołano [interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Co się stanie, jeśli wywołam [interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt) po zakończeniu zadania?**

Nic—wywołanie nie ma żadnego efektu, jeśli odpowiadające zadanie już się zakończyło.

**Czy mogę ponownie użyć tego samego [InterruptionTokenSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/) dla wielu zadań?**

Tak—ale po wywołaniu [interrupt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/interruptiontokensource/#interrupt) na tym źródle, wszystkie zadania korzystające z jego tokenów zostaną przerwane. Używaj oddzielnych źródeł tokenów, aby zarządzać zadaniami niezależnie.