---
title: Porównywanie slajdów prezentacji w JavaScript
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/nodejs-java/compare-slides/
keywords:
- porównywanie slajdów
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Porównuj prezentacje PowerPoint i OpenDocument programowo przy użyciu Aspose.Slides dla Node.js via Java. Szybko identyfikuj różnice między slajdami w kodzie."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów wzorca przy użyciu metody `equals` udostępnionej przez klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem struktury i statycznej zawartości.

## **Porównanie dwóch slajdów**

Metoda Equals została dodana do klasy [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BaseSlide). Zwraca ona true dla slajdów/layoutów oraz slajdów master, które są identyczne pod względem struktury i statycznej zawartości.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia itp. są identyczne. Porównanie nie uwzględnia unikalnych wartości identyfikatorów, np. SlideId, oraz dynamicznej zawartości, np. bieżącej wartości daty w pustym miejscu daty.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

[Hidden status](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/gethidden/) jest właściwością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów jest określana przez ich strukturę i statyczną zawartość; sam fakt, że slajd jest ukryty, nie powoduje, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Hiperłącza są częścią statycznej zawartości slajdu. Jeśli adres URL lub akcja hiperłącza różnią się, zwykle jest to traktowane jako różnica w treści statycznej.

**Czy jeśli wykres odwołuje się do zewnętrznego pliku Excel, zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; brane pod uwagę są tylko elementy obecne w strukturze i statycznym stanie slajdu.