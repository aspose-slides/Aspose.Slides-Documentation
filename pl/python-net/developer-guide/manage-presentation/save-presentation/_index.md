---
title: Zapisywanie prezentacji w Pythonie
linktitle: Zapisywanie prezentacji
type: docs
weight: 80
url: /pl/python-net/save-presentation/
keywords:
- zapis PowerPoint
- zapis OpenDocument
- zapis prezentacji
- zapis slajdu
- zapis PPT
- zapis PPTX
- zapis ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie określony typ widoku
- format Strict Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- Python
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje w Pythonie przy użyciu Aspose.Slides — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Otwieranie prezentacji w Pythonie](/slides/pl/python-net/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Z Aspose.Slides for Python możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides for Python.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    
    # Wykonaj tutaj pewne operacje...

    # Zapisz prezentację do pliku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Zapisz prezentację do strumienia.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides for Python pozwala ustawić początkowy widok, który PowerPoint używa przy otwieraniu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/). Ustaw właściwość `last_view` na wartość z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapisz prezentacje w formacie Strict Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w formacie Strict Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/) i ustaw jej właściwość `conformance` podczas zapisywania. Jeśli ustawisz `Conformance.ISO_29500_2008_STRICT`, plik wyjściowy zostanie zapisany w formacie Strict Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w formacie Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    # Zapisz prezentację w formacie Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na niekompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Właściwość [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta właściwość zapewnia następujące tryby:

- `IF_NECESSARY` używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- `NEVER` nigdy nie używa rozszerzeń formatu ZIP64.
- `ALWAYS` zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Podczas zapisywania z `Zip64Mode.NEVER` zostaje zgłoszony [PptxException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxexception/), jeśli nie można zapisać prezentacji w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Pracując z dużymi prezentacjami, możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz woleć szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides zapewnia właściwość [PptxOptions.compression_level](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/compression_level/), która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne poziomy kompresji:

- [**NONE**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Kompresja nie jest stosowana. Pliki są przechowywane w oryginalnej postaci.
- [**LEVEL1**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Najszybsza kompresja przy najniższym współczynniku kompresji.
- [**LEVEL2**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Szybsza kompresja z nieco lepszym współczynnikiem kompresji niż **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Zapewnia lepszą kompresję niż **LEVEL2**, przy umiarkowanym wpływie na czas przetwarzania.
- [**LEVEL4**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Zapewnia lepszą kompresję niż **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Zapewnia jeszcze lepszą kompresję niż **LEVEL4**, przy dodatkowym czasie przetwarzania.
- [**LEVEL6**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Standardowa kompresja, oferująca dobrą równowagę między szybkością przetwarzania a rozmiarem pliku. Jest to *domyślny poziom kompresji*.
- [**LEVEL7**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Zapewnia lepszą kompresję niż **LEVEL6**, przy wolniejszym przetwarzaniu.
- [**LEVEL8**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Zapewnia lepszą kompresję niż **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/): Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Zapisz prezentacje bez odświeżania miniatury**

Właściwość [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `True`, miniatura jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `False`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose opracowało [bezpłatną aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystując własne API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwane jest „szybkie zapisywanie” (zapis przyrostowy), aby zapisywać tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) nie jest bezpieczna wątkowo; zapisz ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami przy zapisywaniu?**

[Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są zachowane. Zewnętrznie powiązane pliki (np. wideo za pomocą ścieżek względnych) nie są kopiowane automatycznie — należy zapewnić, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [document properties](/slides/pl/python-net/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.