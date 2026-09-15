---
title: Eksportuj prezentacje do HTML z zewnętrznie linkowanymi obrazami
type: docs
weight: 100
url: /pl/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- linkowany obraz
- zewnętrznie linkowany obraz
- linkowany zasób
- zewnętrzny zasób
- Python
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w języku Python przy użyciu Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie linkowane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zwykle jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla strony internetowej, systemu CMS ani potoku konwersji po stronie serwera.

Używaj zewnętrznie linkowanych zasobów, gdy chcesz:

- zmniejszyć rozmiar dokumentu HTML;
- buforować obrazy, czcionki, audio lub wideo osobno w przeglądarce lub CDN;
- przeanalizować, zastąpić, skompresować lub poddać dalszej obróbce wygenerowane zasoby po eksporcie;
- zachować strukturę wyjścia bliższą temu, czego oczekuje aplikacja internetowa.

Ogólny przepływ konwersji HTML opisano w [Konwertuj prezentacje PowerPoint na HTML](/slides/pl/python-java/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu polegającej na linkowaniu zasobów.

## **Jak działa eksport z linkowanymi zasobami**

`ILinkEmbedController` pozwala Twojej aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i zapisuje odnośnik.

Interfejs zawiera trzy metody:

- `ILinkEmbedController.getObjectStoringLocation` decyduje, czy zasób powinien być linkowany, czy osadzony.
- `ILinkEmbedController.getUrl` zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym linkowanym zasobie.
- `ILinkEmbedController.saveExternal` zapisuje dane linkowanego zasobu na dysku lub w innym celu przechowywania.

Ścieżka systemu plików i URL przeglądarki to odrębne zagadnienia. Na przykład poniższy przykład zapisuje pliki zasobów w `html-output/assets` na dysku, podczas gdy HTML zawiera względne URL‑e takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te URL‑e względem pliku zawierającego odnośnik. Dlatego odnośnik z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, a odnośnik z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Eksportuj HTML z linkowanymi zasobami**

Poniższy przykład w języku Python tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje linkowane zasoby w podkatalogu `assets`. Kontroler linkuje typowe obrazy, czcionki, audio, wideo i zasoby CSS, gdy Aspose.Slides dostarcza lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby nie rozpoznane pozostają osadzone.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Po eksporcie folder wyjściowy ma następującą strukturę:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zazwyczaj eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż użyty w prezentacji źródłowej, jeśli daje to mniejszy lub lepszy plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór URL‑ów do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden linkowany zasób odwołuje się do innego linkowanego zasobu, przykład używa parametru `referrer` w `ILinkEmbedController.getUrl` i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrażane w innym miejscu:

- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów jest o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera statycznych plików.

URL zwrócony przez `ILinkEmbedController.getUrl` musi odpowiadać ostatecznej lokalizacji pliku zapisanego przez `ILinkEmbedController.saveExternal`. W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w magazynie obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML z Base64 nadal jest przydatny, gdy wynik musi być pojedynczym plikiem, np. załącznikiem e‑mail, podglądem offline lub dokumentem, który będzie przenoszony bez folderu zasobów. Linkowane zasoby lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację webową, przechowywany w CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę zewnętrznie zapisać tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. W `ILinkEmbedController.getObjectStoringLocation` zwróć [LinkEmbedDecision.Link](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linkembeddecision/#Link) tylko dla typów treści, które chcesz zapisać jako osobne pliki, i zwróć [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linkembeddecision/#Embed) dla wszystkiego innego.

**Dlaczego wyeksportowane rozszerzenie obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie kodować obrazy rastrowe podczas eksportu HTML, aby poprawić rozmiar lub kompatybilność z przeglądarką. Na przykład obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od uzyskanego wyniku renderowania.

**Czy względne URL‑e działają po przeniesieniu pliku HTML?**

Względne URL‑e działają tylko wtedy, gdy zachowana zostanie ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu magazynu dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i chroni przed nadpisaniem zasobów wygenerowanych przez inny eksport.