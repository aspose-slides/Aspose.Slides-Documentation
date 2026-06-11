---
title: Porównaj slajdy prezentacji w Javie
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/java/compare-slides/
keywords:
- porównywanie slajdów
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Porównuj prezentacje PowerPoint i OpenDocument programowo przy użyciu Aspose.Slides dla Javy. Szybko wykrywaj różnice w slajdach w kodzie."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów wzorcowych przy użyciu metody `equals` udostępnionej przez interfejs `IBaseSlide` oraz klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem ich struktury i treści statycznej.

## **Porównaj dwa slajdy**
Metoda Equals została dodana do interfejsu [IBaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IBaseSlide) oraz klasy [BaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/BaseSlide). Zwraca true dla slajdów/układów oraz slajdów/wzorców, które są identyczne pod względem ich struktury i treści statycznej.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia itp. są takie same. Porównanie nie uwzględnia unikalnych wartości identyfikatorów, np. SlideId, ani treści dynamicznej, np. bieżącej wartości daty w Symbolu zastępczym daty.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Hidden status](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getHidden--) jest właściwością poziomu prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów jest określana przez ich strukturę i treść statyczną; sam fakt, że slajd jest ukryty, nie sprawia, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Łącza są częścią statycznej treści slajdu. Jeśli URL lub akcja hiperłącza różnią się, jest to zazwyczaj traktowane jako różnica w treści statycznej.

**Czy jeśli wykres odwołuje się do zewnętrznego pliku Excel, zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brane pod uwagę są tylko elementy obecne w strukturze i stanie statycznym slajdu.