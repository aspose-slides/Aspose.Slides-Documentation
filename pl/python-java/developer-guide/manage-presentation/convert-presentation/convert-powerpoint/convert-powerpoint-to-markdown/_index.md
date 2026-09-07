---
title: Konwertuj prezentacje PowerPoint do Markdown w Pythonie za pomocą Javy
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/python-java/convert-powerpoint-to-markdown/
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
- linki do obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX do Markdown w Pythonie za pomocą Javy oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metapliky i SVG."
---
## **Przegląd**

Aspose.Slides for Python via Java może konwertować prezentacje PPT i PPTX do formatu Markdown w celu dokumentacji, statycznych witryn, migracji treści i procesów kontroli wersji. Można wybrać odmianę Markdown, kontrolować sposób renderowania treści slajdów oraz określić, gdzie zapisywane są eksportowane obrazy i jak generowany Markdown je odwołuje.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować treści wizualne, ustaw typ eksportu metodą [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setExportType) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownexporttype/). `Sequential` renderuje elementy slajdu osobno i w kolejności, natomiast `Visual` utrzymuje elementy pogrupowane razem, aby zachować ich relacje wizualne. Wartość `TextOnly` nie generuje zasobów obrazu, więc w tym trybie nie są wywoływane funkcje zwrotne zapisu obrazów.

## **Konwertuj prezentację do Markdown**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), a następnie wywołaj metodę [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Każdy przykład odczytuje `presentation.pptx` z bieżącego katalogu roboczego. Przed uruchomieniem przykładów zainstaluj Aspose.Slides for Python via Java oraz kompatybilne środowisko uruchomieniowe Javy. Uruchom JVM raz na proces Pythona.

## **Wybierz odmianę Markdown**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setFlavor) kontroluje specyfikację Markdown używaną w wyjściu. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/flavor/) zawiera CommonMark, GitHub Flavored Markdown oraz inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Eksportuj obrazy przy użyciu domyślnego zachowania zapisu lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/) udostępnia dwie metody konfigurowania lokalnie zapisywanych obrazów:

- [setBasePath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) określa katalog bazowy dla dokumentu Markdown i jego zasobów.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) określa podkatalog obrazów. Jego domyślna wartość to `Images`.

Poniższy przykład renderuje treści wizualne, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

To zachowanie służy również jako rozwiązanie awaryjne, gdy niestandardowy handler zapisu obrazu zwraca `False`.

## **Dostosuj zapisywanie obrazów i odnośniki Markdown**

Użyj metody [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/) aby zarejestrować funkcję zwrotną dla bitmap i metaplików nie‑SVG generowanych podczas eksportu Markdown. Jej callback `MarkdownImageSavingHandler` otrzymuje obiekt obrazu, jego wartość [ImageFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/), oraz wygenerowany odnośnik Markdown jako jednoselementową tablicę `String[]`. Zapisz lub prześlij obraz w podanym formacie i zamień `link[0]` na odnośnik, który ma się pojawić w wyjściu Markdown.

Zasoby w formacie SVG są obsługiwane osobno. Zarejestruj callback metodą [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/). Jego callback `MarkdownSvgImageSavingHandler` otrzymuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) oraz jednoselementową tablicę `String[] link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub prześlij jego dane XML przy użyciu metody [SvgImage.getSvgData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/#getSvgData). W zależności od trybu eksportu i grupowania wizualnego, SVG w prezentacji źródłowej może być zrastryzowane lub połączone z inną treścią; powstały zasób nie‑SVG jest następnie przekazywany do callbacku zapisu obrazu. Zarejestruj oba callbacki, gdy każdy wyeksportowany zasób wizualny wymaga niestandardowego przetwarzania.

Wartość zwracana przez handler określa, kto przetwarza obraz:

- Zwróć `True` po tym, jak handler zapisał, przesłał, przekształcił lub w inny sposób przetworzył obraz i przypisał prawidłową wartość do `link[0]`. Aspose.Slides zapisuje tę wartość w dokumencie Markdown i nie wykonuje domyślnego lokalnego zapisu.
- Zwróć `False`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować odnośnik zgodnie z wartościami ustawionymi w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) oraz [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
Handler, który zwraca `True`, przejmuje odpowiedzialność za obraz. Jeśli zwróci `True` bez przypisania prawidłowego, niepustego odnośnika, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

W Pythonie zarejestruj te callbacki przy pomocy `jpype.JProxy`, implementując interfejs wywołania zwrotnego Javy poprzez jego metodę `invoke`. Argument `link` jest mutowalną tablicą łańcuchów Java: przed przetworzeniem zamień `link[0]` na łańcuch Pythona, a następnie przypisz zamienny URL z powrotem do `link[0]`.

### **Zapisz obrazy w katalogu pochodzenia CDN i użyj zewnętrznych URL‑i**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog pochodzenia CDN. Każdy handler wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia wygenerowane lokalne odwołanie na publiczny URL CDN. Sam przykład nie wykonuje przesyłania sieciowego: URL staje się ważny dopiero po zamontowaniu katalogu jako pochodzenia CDN lub po opublikowaniu jego plików w CDN. W przypadku przechowywania obiektowego zamień zapis na systemie plików na operację przesyłania SDK i przypisz `link[0]` dopiero po pomyślnym przesłaniu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Handler bitmapów celowo zwraca `False` dla obrazów mniejszych niż 128 × 128 pikseli, dlatego Aspose.Slides zapisuje te obrazy w `output/fallback-images` korzystając z domyślnego zachowania. Większe zasoby bitmap oraz metaplików, podobnie jak zasoby SVG, są obsługiwane przez kod niestandardowy. Na przykład wygenerowane lokalne odwołanie `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery używają ścieżek systemowych tylko przy zapisie plików; odnośniki zapisywane w Markdown używają ukośników (`/`) i nazwy plików kodowanej w URL. Stosuj tę samą regułę przy budowaniu względnych odnośników: używaj `/`, a nie separatora specyficznego dla platformy.

## **FAQ**

**Czy jeden handler może przetwarzać zarówno obrazy rastrowe, jak i SVG?**

Nie. Użyj [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/) dla bitmap i metaplików oraz [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/) dla zasobów emitowanych jako SVG. Pierwszy przekazuje obiekt obrazu i wartość [ImageFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/); drugi przekazuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/), którego dane SVG można odczytać metodą [SvgImage.getSvgData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/#getSvgData). SVG źródłowe, które jest rastrowane podczas eksportu, jest przetwarzane przez callback zapisu obrazu.

**Co się dzieje, gdy handler zapisu obrazu zwraca `False`?**

Aspose.Slides używa swojego domyślnego zachowania zapisu lokalnego. Lokalizacja obrazu i wygenerowany odnośnik są kontrolowane przez wartości ustawione w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) oraz [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Czy handler może podać URL bez zapisywania obrazu lokalnie?**

Tak. Handler może przesłać obraz do magazynu obiektowego lub przekazać go do innej usługi, przypisać powstały URL do `link[0]` i zwrócić `True`. Handler musi samodzielnie zakończyć przetwarzanie; zwrócenie `True` zapobiega domyślnemu zapisowi lokalnemu.

**Dlaczego eksport Markdown rzuca `InvalidOperationException` z handlera?**

Ten wyjątek pojawia się, gdy handler zwraca `True`, ale nie przekazuje prawidłowego odnośnika. Przypisz względną ścieżkę lub zewnętrzny URL, który ma być zapisany w Markdown, przed zwróceniem `True`.

**Jakiego separatora ścieżki powinny używać odnośniki do obrazów?**

Używaj ukośników (`/`) w odnośnikach Markdown i URL‑ach. `pathlib.Path` stosuj wyłącznie do ścieżek systemu plików, a odnośnik Markdown twórz lub normalizuj oddzielnie.

**Czy hiperłącza są zachowywane podczas eksportu Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/python-java/manage-hyperlinks/) są zachowywane jako standardowe odnośniki Markdown. Przejścia [slajdów](/slides/pl/python-java/slide-transition/) i [animacje](/slides/pl/python-java/powerpoint-animation/) nie są konwertowane.

**Czy prezentacje można konwertować do Markdown równolegle?**

Można przetwarzać różne pliki prezentacji równocześnie, ale nie należy współdzielić tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) między wątkami. Postępuj zgodnie z [wytycznymi dotyczącymi wielowątkowości](/slides/pl/python-java/multithreading/) i używaj osobnej instancji dla każdego pliku.