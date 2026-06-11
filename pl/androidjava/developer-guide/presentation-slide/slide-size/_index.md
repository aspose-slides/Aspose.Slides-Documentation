---
title: Zmień rozmiar slajdu prezentacji na Androidzie
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/androidjava/slide-size/
keywords:
- rozmiar slajdu
- proporcja obrazu
- standardowy
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
- Android
- Java
- Aspose.Slides
descriptions: "Szybko zmień rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Java i Aspose.Slides dla Androida, zoptymalizuj prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest istotne zarówno dla druku, jak i wyświetlania na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obrazu obowiązują wszystkie slajdy. Dla uzyskania optymalnych wyników ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmiana rozmiaru slajdu w prezentacjach**

Ten przykład kodu pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku Java przy użyciu Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie są dla Ciebie odpowiednie, możesz zdecydować się na użycie konkretnego lub unikatowego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na własnym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru dla swojej prezentacji. 

Ten przykład kodu pokazuje, jak używać Aspose.Slides dla Androida w Javie, aby określić własny rozmiar slajdu dla prezentacji w języku Java:

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

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdów tak, aby wszystkie zmieściły się na slajdach (w ten sposób unikasz utraty zawartości), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdów, aby były proporcjonalne do nowego rozmiaru slajdu, użyj tego ustawienia. 

Ten przykład kodu pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ustawić własny rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przekonwertować dowolną jednostkę (taką jak milimetry lub centymetry) na punkty i użyć skonwertowanych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży własny rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [merge presentations](/slides/pl/androidjava/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować ją do drugiej. Podczas zmiany rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsługiwana, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy zachowując formatowanie.

**Czy mogę generować miniatury pojedynczych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury zarówno [entire slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) jak i [selected shapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Powstałe obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.