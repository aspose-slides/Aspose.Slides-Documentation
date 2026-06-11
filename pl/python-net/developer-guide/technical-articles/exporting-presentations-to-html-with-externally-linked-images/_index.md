---
title: Eksportowanie prezentacji do HTML z zewnętrznie powiązanymi obrazami w Pythonie
linktitle: Eksportowanie prezentacji do HTML z zewnętrznie powiązanymi obrazami
type: docs
weight: 100
url: /pl/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- eksport slajdu
- eksport PPT
- eksport PPTX
- eksport ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- powiązany obraz
- zewnętrznie powiązany obraz
- powiązany zasób
- zewnętrzny zasób
- Python
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w Pythonie przy użyciu Aspose.Slides, zapisując obrazy jako zewnętrznie powiązane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zwykle jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla witryny internetowej, systemu CMS ani potoku konwersji po stronie serwera.

Używaj zewnętrznie powiązanych obrazów, gdy chcesz:
- zmniejszyć rozmiar dokumentu HTML;
- przechowywać obrazy w pamięci podręcznej przeglądarki lub CDN oddzielnie;
- przeglądać, zastępować, kompresować lub poddawać dalszej obróbce wygenerowane obrazy po eksporcie;
- utrzymać strukturę wyjściową bliższą temu, czego oczekuje aplikacja internetowa.

Aby zapoznać się z ogólnym przepływem konwersji HTML, zobacz [Convert PowerPoint Presentations to HTML](/slides/pl/python-net/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu związanej z linkowaniem obrazów.

## **Jak działa eksport z linkowanymi obrazami**

W .NET i Javie, [ILinkEmbedController](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/ilinkembedcontroller/) reprezentuje interfejs zwrotny używany przez eksporter do decyzji, czy zasób ma być osadzony, czy linkowany. W Pythonie przez .NET klasy Pythona nie mogą obecnie bezpośrednio implementować tego interfejsu zwrotnego .NET, więc praktyczny przepływ pracy wygląda następująco:
1. Wyeksportuj prezentację do HTML przy użyciu [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/).
2. Użyj [SlideImageFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/slideimageformat/) wraz z [SVGOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/), aby slajdy były reprezentowane jako SVG w HTML.
3. Przenieś dane obrazów w formacie Base64 z adresów URL HTML `data:` do oddzielnych plików.
4. Zastąp oryginalne adresy URL `data:` względnymi linkami, takimi jak `assets/resource-1.jpg`.

Ścieżka systemu plików i adres URL przeglądarki to odrębne kwestie. Na przykład, poniższy przykład zapisuje pliki obrazów w `html-output/assets` na dysku, podczas gdy HTML zawiera względne adresy URL, takie jak `assets/resource-1.jpg`. Przeglądarka rozwiązuje te adresy URL względem pliku HTML, który zawiera link.

## **Eksport HTML z linkowanymi obrazami**

Poniższy przykład w Pythonie tworzy katalog wyjściowy, zapisuje tam plik HTML, przechowuje wyodrębnione obrazy w podkatalogu `assets` i zamienia adresy URL obrazów w formacie Base64 na linki względne. Przykład wyodrębnia typowe formaty obrazów Base64, gdy Aspose.Slides dostarcza bezpieczne rozszerzenie pliku. Nie rozpoznane adresy URL danych pozostają osadzone.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Po eksporcie folder wyjściowy może mieć taką strukturę:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zwykle eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż użyty w prezentacji źródłowej, jeśli daje to mniejszy lub bardziej odpowiedni plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór adresów URL do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.jpg`.

Użyj innej nazwy katalogu zasobów lub przepisz wygenerowane linki, gdy pliki są wdrażane w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów znajduje się jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera plików statycznych.

W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu storage obiektowego dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy osadzać zamiast linkowania**

Osadzony HTML w formacie Base64 jest nadal przydatny, gdy wyjście musi być jednym plikiem, takim jak załącznik e‑mail, podgląd offline lub dokument, który zostanie przeniesiony bez towarzyszącego katalogu zasobów. Linkowane obrazy lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację internetową, przechowywany w CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę wyodrębnić tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. Przykład wyodrębnia tylko adresy URL danych Base64 typu `image/*`, których typy treści są wymienione w `EXTENSIONS_BY_CONTENT_TYPE`. Inne adresy URL danych pozostają osadzone.

**Dlaczego wyeksportowane rozszerzenie obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie kodować obrazy rastrowe podczas eksportu HTML, aby poprawić rozmiar lub kompatybilność z przeglądarką. Na przykład obraz z pliku źródłowego może być zapisany jako JPEG lub PNG w zależności od uzyskanego wyniku renderowania.

**Czy względne adresy URL działają po przeniesieniu pliku HTML?**

Względne adresy URL działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, katalog `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego katalogu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu storage dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia jednemu eksportowi nadpisywanie zasobów wygenerowanych przez inny eksport.