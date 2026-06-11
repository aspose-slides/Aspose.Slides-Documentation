---
title: Porównaj slajdy prezentacji w .NET
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/net/compare-slides/
keywords:
- porównaj slajdy
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Programowo porównuj prezentacje PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Szybko identyfikuj różnice między slajdami w kodzie."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów głównych przy użyciu metody `Equals` udostępnionej przez interfejs `IBaseSlide` oraz klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem ich struktury i statycznej zawartości.

## **Porównaj dwa slajdy**

Metoda Equals została dodana do interfejsu [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide) i klasy [BaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide). Zwraca ona `true` dla slajdów/layoutów oraz slajdów/masters, które są identyczne pod względem ich struktury i statycznej zawartości.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia są identyczne itd. Porównanie nie uwzględnia unikalnych wartości identyfikatorów, takich jak SlideId, oraz treści dynamicznej, np. bieżącej wartości daty w polu zastępczym Daty.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Hidden status](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/hidden/) jest właściwością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów jest określana przez ich strukturę i statyczną zawartość; sam fakt, że slajd jest ukryty, nie powoduje, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Linki są częścią statycznej zawartości slajdu. Jeśli URL lub akcja hiperłącza różni się, jest to zazwyczaj traktowane jako różnica w statycznej zawartości.

**Jeśli wykres odwołuje się do zewnętrznego pliku Excel, czy zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie jest wykonywane na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brana jest pod uwagę jedynie zawartość struktury i stanu statycznego slajdu.