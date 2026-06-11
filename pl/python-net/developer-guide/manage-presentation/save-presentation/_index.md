---
title: Zapisywanie prezentacji w Pythonie
linktitle: Zapisywanie prezentacji
type: docs
weight: 80
url: /pl/python-net/save-presentation/
keywords:
- zapisz PowerPoint
- zapisz OpenDocument
- zapisz prezentację
- zapisz slajd
- zapisz PPT
- zapisz PPTX
- zapisz ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie określony typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisywania
- Python
- Aspose.Slides
description: "Odkryj, jak zapisywać prezentacje w Pythonie przy użyciu Aspose.Slides — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open a Presentation in Python](/slides/pl/python-net/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Z Aspose.Slides for Python możesz zapisywać do **file** lub **stream**. Ten artykuł wyjaśnia różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides for Python.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    
    # Wykonaj tutaj jakieś operacje...

    # Zapisz prezentację do pliku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację, dodajemy tekst do kształtu i zapisujemy ją do strumienia.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Zapisz prezentację do strumienia.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides for Python umożliwia ustawienie początkowego widoku, którego PowerPoint używa, gdy otwiera się wygenerowana prezentacja, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/). Ustaw właściwość `last_view` na wartość z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje w ściśle określonym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ściśle określonym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/) i ustaw jej właściwość `conformance` podczas zapisywania. Jeśli ustawisz `Conformance.ISO_29500_2008_STRICT`, plik wyjściowy zostanie zapisany w ściśle określonym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ściśle określonym formacie Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    # Zapisz prezentację w ściśle określonym formacie Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na niekompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza archiwum do 65 535 (2^16‑1) plików. Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Właściwość [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta właściwość zapewnia następujące tryby:

- `IF_NECESSARY` używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- `NEVER` nigdy nie używa rozszerzeń formatu ZIP64.
- `ALWAYS` zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami formatu ZIP64:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z `Zip64Mode.NEVER`, zostaje zgłoszony [PptxException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxexception/) , jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje bez odświeżania miniatury**

Właściwość [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) kontroluje generowanie miniatury podczas zapisywania prezentacji do PPTX:

- Jeśli ustawiona na `True`, miniatura jest odświeżana podczas zapisu. To domyślne ustawienie.
- Jeśli ustawiona na `False`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

W poniższym kodzie prezentacja jest zapisana do PPTX bez odświeżania jej miniatury.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga zmniejszyć czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose opracowało [free PowerPoint Splitter app](https://products.aspose.app/slides/pl/splitter) używając własnego API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany tak, że zapisywane są tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) nie jest bezpieczna wątkowo; zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie połączonymi plikami podczas zapisywania?**

Hiperłącza [Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są zachowywane. Zewnętrznie połączone pliki (np. wideo przez ścieżki względne) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [document properties](/slides/pl/python-net/presentation-properties/) są obsługiwane i zostaną zapisane do pliku przy zapisie.