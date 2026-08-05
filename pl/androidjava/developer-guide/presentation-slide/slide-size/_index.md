---
title: Zmień rozmiar slajdu prezentacji na Androidzie
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/androidjava/slide-size/
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
- nie skalować
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Szybko zmień rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Java i Aspose.Slides dla Androida, optymalizuj prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia wszechstronne narzędzia do zmiany rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (4:3)**: Idealny dla starszych ekranów i urządzeń.  
- **Widescreen (16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.  

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obrazu obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć problemów.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy pomocy Aspose.Slides używają standardowej proporcji 4:3.  
{{% /alert %}}

## **Zmiana rozmiaru slajdu w prezentacjach**

 Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku Java przy użyciu Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określanie własnych rozmiarów slajdu w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie spełniają Twoich wymagań, możesz zdecydować się na określony lub unikalny rozmiar slajdu. Na przykład, gdy planujesz drukować slajdy w pełnym rozmiarze na niestandardowym układzie strony lub wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru slajdu.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides dla Androida w Javie, aby określić własny rozmiar slajdu w prezentacji:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby dopasować się do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu możesz określić ustawienie, które definiuje, w jaki sposób Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co chcesz osiągnąć, możesz użyć jednego z następujących ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli zmniejszasz rozmiar slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty, aby wszystkie zmieściły się na slajdzie (w ten sposób unikniesz utraty treści), użyj tego ustawienia.

- `Maximize`

  Jeśli powiększasz rozmiar slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

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

**Czy mogę ustawić własny rozmiar slajdu używając jednostek innych niż cale (np. punktów lub milimetrów)?**

Tak. Aspose.Slides wewnętrznie używa punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży własny rozmiar slajdu wpływa na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania zwiększają zużycie pamięci i wydłużają czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko wtedy, gdy jest to konieczne, aby uzyskać pożądaną jakość wyniku.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a potem łączyć slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [łączyć prezentacji](/slides/pl/androidjava/merge-presentation/), gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsłużona, korzystając z opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz łączyć slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla poszczególnych kształtów lub określonych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury zarówno dla [całych slajdów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) jak i dla [wybranych kształtów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Uzyskane obrazy odzwierciedlają aktualny rozmiar i proporcje slajdu, zapewniając spójną ramkę i geometrię.