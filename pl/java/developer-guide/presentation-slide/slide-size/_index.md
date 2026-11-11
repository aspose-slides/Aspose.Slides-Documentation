---
title: Zmiana rozmiaru slajdu prezentacji w Javie
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/java/slide-size/
keywords:
- rozmiar slajdu
- proporcje
- standard
- szeroki ekran
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Javy i Aspose.Slides, optymalizując prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest istotne zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedne proporcje obowiązują wszystkie slajdy. Dla uzyskania optymalnych rezultatów ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" title="Note" %}}
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały informacyjne mają odrębne wymiary od zwykłych slajdów. Zobacz [Rozmiar strony notatek](/slides/pl/java/notes-size/), aby zmienić ich rozmiar i orientację.

## **Zmiana rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w Javie przy użyciu Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie są odpowiednie dla Twojej pracy, możesz zdecydować się na użycie określonego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for Java do określenia niestandardowego rozmiaru slajdu w prezentacji w Javie:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością na slajdach.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć któregokolwiek z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdów, aby wszystkie mieściły się na slajdach (w ten sposób unikniesz utraty treści), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` podczas zmiany rozmiaru slajdu w prezentacji:

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

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cal (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania powodują zwiększone zużycie pamięci i dłuższy czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać wymaganą jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scalania prezentacji](/slides/pl/java/merge-presentation/), gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasowała do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość będzie obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

**Czy mogę generować miniatury poszczególnych kształtów lub określonych obszarów slajdu i czy będą one uwzględniały nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-). Powstałe obrazy odzwierciedlają aktualny rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.