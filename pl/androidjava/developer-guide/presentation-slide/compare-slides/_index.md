---
title: Porównywanie slajdów prezentacji na Androidzie
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/androidjava/compare-slides/
keywords:
- porównywanie slajdów
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Porównuj prezentacje PowerPoint i OpenDocument programowo przy użyciu Aspose.Slides dla Androida. Szybko wykrywaj różnice w slajdach w kodzie Java."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów podstawowych przy użyciu metody `equals` udostępnionej przez interfejs `IBaseSlide` oraz klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem struktury i treści statycznej.

## **Porównaj dwa slajdy**
Metoda Equals została dodana do interfejsu [IBaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBaseSlide) oraz klasy [BaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/BaseSlide). Zwraca ona wartość true dla slajdów/layoutów oraz slajdów/master, które są identyczne pod względem struktury i treści statycznej.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia itp. są identyczne. Porównanie nie uwzględnia wartości unikalnych identyfikatorów, np. SlideId, oraz treści dynamicznych, np. bieżącej wartości daty w kontrolce Data.

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

[Stan ukrycia](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#getHidden--) jest właściwością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów określana jest przez ich strukturę i treść statyczną; sam fakt, że slajd jest ukryty, nie powoduje, że slajdy są różne.

**Czy hiperlinki i ich parametry są brane pod uwagę?**

Tak. Linki są częścią statycznej treści slajdu. Jeśli URL lub akcja hiperłącza różnią się, jest to zazwyczaj traktowane jako różnica w treści statycznej.

**Jeśli wykres odwołuje się do zewnętrznego pliku Excel, czy zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brana jest pod uwagę jedynie zawartość struktury i stanu statycznego slajdu.