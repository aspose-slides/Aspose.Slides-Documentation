---
title: Zmiana rozmiaru slajdu prezentacji w JavaScript
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/nodejs-java/slide-size/
keywords:
- rozmiar slajdu
- proporcje obrazu
- standard
- szerokokątny
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- slajd w pełnym rozmiarze
- typ ekranu
- nie skaluj
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Node.js i Aspose.Slides, optymalizować prezentacje na dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno dla druku, jak i wyświetlania na ekranie.

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Widescreen (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

## **Zmiana rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w JavaScript przy użyciu Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie są odpowiednie dla Twojej pracy, możesz zdecydować się na określony lub unikalny rozmiar slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru dla swojej prezentacji.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for Node.js via Java do określenia własnego rozmiaru slajdu dla prezentacji w JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Radzenie sobie z problemami przy zmianie rozmiaru slajdów w prezentacjach**

Po zmianie rozmiaru slajdu w prezentacji, zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu prezentacji możesz określić ustawienie, które definiuje, w jaki sposób Aspose.Slides obsługuje zawartość na slajdach.

W zależności od tego, co chcesz zrobić lub osiągnąć, możesz użyć któregoś z poniższych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikniesz utraty treści), użyj tego ustawienia.

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę ustawić własny rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży własny rozmiar slajdu wpływa na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i wydłużonych czasów przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby osiągnąć pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [merge presentations](/slides/pl/nodejs-java/merge-presentation/), gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak obsługiwana jest istniejąca zawartość, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scaląć slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla pojedynczych kształtów lub określonych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [entire slides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage) oraz dla [selected shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage). Uzyskane obrazy odzwierciedlają bieżący rozmiar i proporcje slajdu, zapewniając spójne kadrowanie i geometrię.