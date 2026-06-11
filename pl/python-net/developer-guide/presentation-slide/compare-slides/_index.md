---
title: Porównaj slajdy prezentacji w Pythonie
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/python-net/compare-slides/
keywords:
- porównaj slajdy
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Porównuj prezentacje PowerPoint i OpenDocument programowo przy użyciu Aspose.Slides dla Pythona w .NET. Szybko wykrywaj różnice między slajdami w kodzie."
---
## **Przegląd**

Aspose.Slides pozwala porównywać slajdy, slajdy układu i slajdy master przy użyciu metody `equals` udostępnionej przez klasę `BaseSlide`. Metoda ta zwraca `True`, gdy porównywane slajdy są identyczne pod względem struktury i treści statycznej.

## **Porównaj dwa slajdy**
Metoda `equals` została dodana do klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/) . Zwraca ona true dla slajdów/layoutów i slajdów/master, które są identyczne pod względem struktury i treści statycznej.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia itp. są takie same. Porównanie nie uwzględnia unikalnych identyfikatorów, np. SlideId, ani treści dynamicznej, np. bieżącej wartości daty w polu daty.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Hidden status](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) jest właściwością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów określana jest na podstawie ich struktury i treści statycznej; sam fakt, że slajd jest ukryty, nie powoduje różnicy między slajdami.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Linki są częścią statycznej treści slajdu. Jeśli adres URL lub akcja hiperłącza różni się, zazwyczaj traktuje się to jako różnicę w treści statycznej.

**Czy jeśli wykres odwołuje się do zewnętrznego pliku Excel, zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brane pod uwagę są jedynie elementy obecne w strukturze i stanie statycznym slajdu.