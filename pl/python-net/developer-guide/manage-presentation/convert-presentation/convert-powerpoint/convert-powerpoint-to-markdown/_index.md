---
title: Konwertuj prezentacje PowerPoint do Markdown w Pythonie
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/python-net/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do MD
- prezentacja do MD
- slajd do MD
- PPT do MD
- PPTX do MD
- zapisz PowerPoint jako Markdown
- zapisz prezentację jako Markdown
- zapisz slajd jako Markdown
- zapisz PPT jako MD
- zapisz PPTX jako MD
- eksportuj PPT do MD
- eksportuj PPTX do MD
- eksport obrazów do Markdown
- odnośniki obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX do Markdown w Pythonie oraz kontroluj, gdzie zapisywane są wyeksportowane obrazy i jak generowany Markdown je odwołuje."
---
## **Przegląd**

Aspose.Slides for Python via .NET może konwertować prezentacje PPT i PPTX do formatu Markdown przeznaczonego do dokumentacji, stron statycznych, migracji treści i przepływów pracy z kontrolą wersji. Możesz wybrać wariant Markdown, kontrolować sposób renderowania zawartości slajdów oraz zdecydować, gdzie będą przechowywane wyeksportowane obrazy i jak generowany Markdown będzie je odwoływał.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować zawartość wizualną, ustaw właściwość [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/export_type/) na wartość `SEQUENTIAL` lub `VISUAL` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` renderuje elementy slajdu osobno i kolejno, natomiast `VISUAL` utrzymuje grupowane elementy razem, aby zachować ich relację wizualną. Wartość `TEXT_ONLY` nie generuje zasobów obrazów.

## **Konwertowanie prezentacji do Markdown**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), a następnie wywołaj metodę [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) z wartością `MD` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Wybierz wariant Markdown**

Właściwość [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/flavor/) kontroluje specyfikację Markdown używaną w wyniku. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/flavor/) zawiera CommonMark, GitHub Flavored Markdown oraz inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Eksportowanie obrazów przy użyciu domyślnego zachowania zapisu lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/) udostępnia dwie właściwości dla lokalnie zapisywanych obrazów:

- [base_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) określa podstawowy katalog dla dokumentu Markdown i jego zasobów.
- [images_save_folder_name](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) określa podkatalog obrazów. Jego domyślną wartością jest `Images`.

Poniższy przykład renderuje zawartość wizualną, zapisuje obrazy w `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides tworzy podkatalog obrazów, gdy eksport generuje zasoby obrazów, ale aplikacja musi utworzyć `base_path` przed zapisaniem pliku Markdown.

## **Przygotowanie Markdown i obrazów do publikacji**

Aspose.Slides for Python via .NET nie udostępnia wywołań zwrotnych .NET zapisywania obrazu do zastępowania każdego wygenerowanego odnośnika obrazu w trakcie eksportu. Zamiast tego wyeksportuj dokument Markdown i jego folder z obrazami do katalogu publikacji, a następnie opublikuj ten katalog nie zmieniając jego względnej struktury.

Poniższy przykład przygotowuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog publikacji. Sam przykład nie wykonuje żadnego przesyłania sieciowego: wygenerowane odnośniki stają się ważne po opublikowaniu katalogu w docelowej witrynie lub lokalizacji CDN.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Opublikuj `presentation.md` razem z katalogiem `assets`. Dokument Markdown używa względnych odwołań do obrazów, więc oba elementy muszą zachować tę samą relację w miejscu docelowym. Jeśli system publikacji wymaga bezwzględnych zewnętrznych adresów URL, przepisz wygenerowane odnośniki w osobnym kroku post‑processingu po opublikowaniu wszystkich plików obrazu.

## **FAQ**

**Czy wywołania zwrotne Pythona mogą dostosowywać pojedyncze pliki obrazów i odnośniki podczas eksportu do Markdown?**

Nie. Aspose.Slides for Python via .NET nie udostępnia wywołań zwrotnych .NET `ImageSaving` i `SvgImageSaving`. Skonfiguruj lokalny wynik przy użyciu [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) i [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), a następnie opublikuj lub poddaj generowane zasoby post‑processingu.

**Gdzie są zapisywane wyeksportowane obrazy?**

Lokalizacją obrazów sterują [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) i [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Dokument Markdown odwołuje się do tych obrazów za pomocą względnych ścieżek.

**Jaki separator ścieżek powinny używać odnośniki do obrazów?**

Używaj ukośników (/) w odnośnikach Markdown i adresach URL. `os.path.join` stosuj wyłącznie do ścieżek systemu plików, a wszelkie odnośniki tworzone w trakcie post‑processingu normalizuj oddzielnie.

**Czy odnośniki hipertekstowe są zachowywane podczas eksportu do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/python-net/manage-hyperlinks/) są zachowywane jako standardowe odnośniki Markdown. [Przejścia](/slides/pl/python-net/slide-transition/) i [animacje](/slides/pl/python-net/powerpoint-animation/) slajdów nie są konwertowane.

**Czy prezentacje mogą być konwertowane do Markdown równolegle?**

Możesz przetwarzać różne pliki prezentacji równolegle, ale nie udostępniaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) między wątkami. Postępuj zgodnie z [multithreading guidelines](/slides/pl/python-net/multithreading/) i używaj osobnej instancji dla każdego pliku.