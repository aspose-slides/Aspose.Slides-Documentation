---
title: Zmień rozmiar slajdu prezentacji w JavaScript
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/nodejs-java/slide-size/
keywords:
- rozmiar slajdu
- proporcje
- standard
- szerokokątny
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- pełnowymiarowy slajd
- typ ekranu
- nie skalować
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Node.js i Aspose.Slides, optymalizując prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary i proporcje slajdów:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zachowaj spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Dla optymalnych rezultatów ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" title="Note" %}}
Domyślnie prezentacje tworzone przy pomocy Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały pomocnicze mają odrębne wymiary od zwykłych slajdów. Zobacz [Rozmiar strony notatek](/slides/pl/nodejs-java/notes-size/) aby zmienić ich rozmiar i orientację.

## **Zmiana rozmiaru slajdu w prezentacjach**

Poniższy przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w JavaScript przy użyciu Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie spełniają Twoich wymagań, możesz zdecydować się na użycie określonego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze na własnym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Poniższy przykładowy kod pokazuje, jak używać Aspose.Slides for Node.js w Java do określenia niestandardowego rozmiaru slajdu w prezentacji w JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu można określić ustawienie, które definiuje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co chcesz osiągnąć, możesz użyć jednego z poniższych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdu tak, aby wszystkie zmieściły się na slajdzie (w ten sposób unikasz utraty treści), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdu, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Poniższy przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

**Czy mogę ustawić niestandardowy rozmiar slajdu przy użyciu jednostek innych niż cale (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania zwiększają zużycie pamięci i wydłużają czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjściową.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scal prezentacje](/slides/pl/nodejs-java/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość jest obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla pojedynczych kształtów lub określonych regionów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów]https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage oraz dla [wybranych kształtów]https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage. Powstałe obrazy odzwierciedlają aktualny rozmiar i proporcje slajdu, zapewniając spójne kadrowanie i geometrię.