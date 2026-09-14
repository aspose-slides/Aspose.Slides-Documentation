---
title: Zmienianie rozmiaru slajdu prezentacji w Pythonie za pośrednictwem Javy
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/python-java/slide-size/
keywords:
- rozmiar slajdu
- proporcje obrazu
- standardowy
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
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Pythona za pośrednictwem Javy i Aspose.Slides oraz zoptymalizować prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie.

Popularne rozmiary slajdów i proporcje:

- **Standard (4:3 Aspect Ratio)**: Idealny dla starszych ekranów i urządzeń.
- **Widescreen (16:9 Aspect Ratio)**: Polecany dla nowoczesnych projektorów i wyświetlaczy.

Upewnij się, że w całej prezentacji używany jest jeden rozmiar slajdu i jedna proporcja obrazu, które odnoszą się do wszystkich slajdów. Dla optymalnych rezultatów ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" title="Uwaga" %}}
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmienianie rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w Pythonie za pośrednictwem Javy przy użyciu Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie są odpowiednie dla Twojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze na niestandardowym układzie strony lub chcesz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru dla prezentacji.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for Python via Java, aby określić niestandardowy rozmiar slajdu dla prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak zmieniając rozmiar slajdu w prezentacji, możesz określić ustawienie, które definiuje, jak Aspose.Slides radzi sobie z zawartością na slajdach.

W zależności od tego, co chcesz osiągnąć, możesz użyć dowolnego z następujących ustawień:

- [DoNotScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Jeśli nie chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- [EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdów, aby wszystkie zmieściły się na slajdzie (w ten sposób unikniesz utraty zawartości), użyj tego ustawienia.

- [Maximize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia [Maximize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#Maximize) podczas zmiany rozmiaru slajdu w prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (np. punktów lub milimetrów)?**

Tak. Aspose.Slides używa punktów wewnętrznie, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (taką jak milimetry lub centymetry) na punkty i użyć przeliczone wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i reguluj skalę renderowania tylko w razie potrzeby, aby osiągnąć wymaganą jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [merge presentations](/slides/pl/python-java/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Podczas zmiany rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsłużona, korzystając z opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla pojedynczych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [entire slides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) oraz dla [selected shapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage). Powstałe obrazy odzwierciedlają aktualny rozmiar i proporcję slajdu, zapewniając spójne kadrowanie i geometrię.