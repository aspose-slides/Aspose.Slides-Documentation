---
title: Zmień rozmiar slajdu prezentacji w języku Java
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/java/slide-size/
keywords:
- rozmiar slajdu
- proporcja obrazu
- standard
- szerokokątny
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- slajd pełnowymiarowy
- typ ekranu
- nie skaluj
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
descriptions: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP za pomocą Javy i Aspose.Slides, optymalizować prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides oferuje kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obrazu obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmienianie rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w Javie przy użyciu Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli uznasz typowe rozmiary slajdów (4:3 i 16:9) za nieodpowiednie dla swojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for Java do określenia niestandardowego rozmiaru slajdu w prezentacji w Javie:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu prezentacji możesz określić ustawienie, które decyduje, w jaki sposób Aspose.Slides traktuje zawartość na slajdach.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć jednego z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikasz utraty treści), użyj tego ustawienia.

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjściową.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scalać prezentacji](/slides/pl/java/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować ją do drugiej. Zmieniając rozmiar slajdu, możesz wybrać, jak istniejąca zawartość zostanie obsłużona, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-). Powstałe obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójną ramkę i geometrię.