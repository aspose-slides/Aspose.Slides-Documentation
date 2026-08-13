---
title: Zmień rozmiar slajdu prezentacji w systemie Android
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/androidjava/slide-size/
keywords:
- rozmiar slajdu
- proporcje
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
description: "Szybko zmień rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Javy i Aspose.Slides dla Androida, optymalizuj prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest istotne zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Widescreen (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zachowaj spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmienianie rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku Java przy użyciu Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli uznasz, że typowe rozmiary slajdów (4:3 i 16:9) nie są odpowiednie dla Twojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak używać Aspose.Slides dla Androida w Javie, aby określić własny rozmiar slajdu dla prezentacji w języku Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji można określić ustawienie, które definiuje, w jaki sposób Aspose.Slides radzi sobie z zawartością na slajdach.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikasz utraty treści), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdów, aby były proporcjonalne do nowego rozmiaru slajdu, użyj tego ustawienia. 

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Czy mogę ustawić własny rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonych wartości do określenia szerokości i wysokości slajdu.

### Czy bardzo duży własny rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania powodują zwiększone zużycie pamięci i dłuższy czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

### Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?

Nie możesz [scalić prezentacji](/slides/pl/androidjava/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

### Czy mogę generować miniatury dla pojedynczych kształtów lub konkretnych obszarów slajdu i czy będą one uwzględniały nowy rozmiar slajdu?

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Powstałe obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.