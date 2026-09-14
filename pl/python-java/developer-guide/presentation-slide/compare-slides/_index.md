---
title: Porównaj slajdy prezentacji w Pythonie
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/python-java/compare-slides/
keywords:
- porównaj slajdy
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Porównuj prezentacje PowerPoint i OpenDocument programowo przy użyciu Aspose.Slides dla Pythona przy użyciu Javy. Szybko identyfikuj różnice slajdów w kodzie."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów master przy użyciu metody [equals](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#equals) udostępnionej przez klasę [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/). Metoda ta zwraca `True`, gdy porównywane slajdy są identyczne pod względem ich struktury i zawartości statycznej.

## **Porównaj dwa slajdy**

Metoda [equals](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#equals) w klasie [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/) zwraca `True` dla slajdów, slajdów układu i slajdów master, które są identyczne pod względem struktury i zawartości statycznej.

Dwa slajdy są równe, jeśli wszystkie ich kształty, style, tekst, animacje i inne ustawienia są identyczne. Porównanie nie uwzględnia unikalnych wartości identyfikatorów, takich jak identyfikatory slajdów, ani dynamicznej zawartości, takiej jak bieżąca data w polu zastępczym daty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Hidden status](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getHidden) jest właściwością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów określana jest na podstawie ich struktury i zawartości statycznej; sam fakt, że slajd jest ukryty, nie powoduje, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Linki są częścią statycznej zawartości slajdu. Jeśli różni się URL lub akcja hiperłącza, zwykle jest to traktowane jako różnica w zawartości statycznej.

**Jeśli wykres odwołuje się do zewnętrznego pliku Excel, czy zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brane pod uwagę są jedynie elementy obecne w strukturze i stanie statycznym slajdu.