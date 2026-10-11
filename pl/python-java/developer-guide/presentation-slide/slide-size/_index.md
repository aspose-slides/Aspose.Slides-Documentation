---
title: Zmień rozmiar slajdu prezentacji w Pythonie za pośrednictwem Javy
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/python-java/slide-size/
keywords:
- rozmiar slajdu
- proporcje obrazu
- standardowy
- panoramiczny
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

Aspose.Slides udostępnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy druku, jak i wyświetlaniu na ekranie.

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Panorama (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdu na początku tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" title="Note" %}}
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały pomocnicze mają odrębne wymiary od zwykłych slajdów. Zobacz [Rozmiar strony notatek](/slides/pl/python-java/notes-size/), aby zmienić ich rozmiar i orientację.

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

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie odpowiadają Twoim potrzebom, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides dla Pythona za pośrednictwem Javy, aby określić niestandardowy rozmiar slajdu w prezentacji:

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

## **Obsługa zawartości slajdów po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu prezentacji możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością na slajdach.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- [DoNotScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Jeśli nie chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- [EnsureFit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikniesz utraty treści), użyj tego ustawienia.

- [Maximize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia [Maximize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/#Maximize) przy zmianie rozmiaru slajdu w prezentacji:

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

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (np. punkty lub milimetry)?**

Tak. Aspose.Slides wewnętrznie używa punktów, przy czym 1 punkt to 1/72 cala. Możesz przekonwertować dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczone wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie łączyć slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [łączyć prezentacji](/slides/pl/python-java/merge-presentation/), gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość zostanie obsłużona, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz łączyć slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage). Uzyskane obrazy odzwierciedlają bieżący rozmiar i proporcje slajdu, zapewniając spójne kadrowanie i geometrię.