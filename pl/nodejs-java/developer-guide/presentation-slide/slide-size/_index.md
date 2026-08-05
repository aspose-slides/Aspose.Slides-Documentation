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
- szeroki ekran
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- pełnowymiarowy slajd
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
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Node.js i Aspose.Slides, optymalizuj prezentacje pod każdy ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie.

Popularne rozmiary i proporcje slajdów:

- **Standard (4:3)**: Idealny dla starszych ekranów i urządzeń.  
- **Szeroki ekran (16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obowiązują wszystkie slajdy. Aby uzyskać najlepsze wyniki, ustaw wymiary slajdu na początku tworzenia prezentacji, co zapobiega późniejszym komplikacjom.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3. 
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

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) są nieodpowiednie dla Twojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować pełnowymiarowe slajdy z prezentacji na własnym układzie strony lub wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for Node.js poprzez Java, aby określić niestandardowy rozmiar slajdu w prezentacji w JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Radzenie sobie z problemami przy zmianie rozmiaru slajdów w prezentacjach**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby dopasować się do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu możesz określić ustawienie, które definiuje, w jaki sposób Aspose.Slides obchodzi się z zawartością slajdów.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć jednego z następujących ustawień:

- `DoNotScale`

  Jeśli **nie** chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdu, aby wszystkie zmieściły się na slajdzie (co zapobiega utracie treści), użyj tego ustawienia.

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdu, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

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

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punkty lub milimetry)?**

Tak. Aspose.Slides wewnętrznie używa punktów, gdzie 1 punkt to 1/72 cala. Możesz przekonwertować dowolną jednostkę (taką jak milimetry lub centymetry) na punkty i użyć tych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpływa na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci oraz dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scalić prezentacji](/slides/pl/nodejs-java/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać sposób obsługi istniejącej zawartości za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

**Czy mogę generować miniatury poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one uwzględniały nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury zarówno dla [całych slajdów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage), jak i dla [wybranych kształtów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage). Powstałe obrazy odzwierciedlają aktualny rozmiar slajdu i proporcje, zapewniając spójne kadrowanie oraz geometrię.