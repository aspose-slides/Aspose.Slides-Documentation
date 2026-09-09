---
title: Převod PowerPoint prezentací do HTML v Pythonu přes Java
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/python-java/convert-powerpoint-to-html/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- uložit PowerPoint jako HTML
- uložit prezentaci jako HTML
- uložit snímek jako HTML
- uložit PPT jako HTML
- uložit PPTX jako HTML
- exportovat PPT do HTML
- exportovat PPTX do HTML
- Python
- Java
- Aspose.Slides
description: "Převod PowerPoint prezentací do HTML v Pythonu přes Java. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a multimédií."
---
## **Přehled**

Aspose.Slides for Python via Java může uložit prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní konverze spočívá v načtení jediné [Prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a volání [uložit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/), pokud potřebujete řídit exportované rozvržení, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu do HTML:

- Export celé prezentace nebo vybraných snímků.
- Generování pevného rozvržení, responzivního nebo založeného na SVG HTML.
- Zahrnutí poznámek přednášejícího a komentářů.
- Řízení kvality obrázků a oříznutých částí obrázků.
- Vložení písem nebo samostatné uložení souborů písem.
- Výběr způsobu zápisu a odkazování na externí zdroje a mediální soubory.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, ve kterém je většina zdrojů vložena. To je vhodné pro sdílení jedné souboru, ale může to zvětšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vložení pouze písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML načtěte ji pomocí [Prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a uložte ji s [SaveFormat.Html](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Každý příklad načítá `presentation.pptx` z aktuálního pracovního adresáře. Před spuštěním nainstalujte Aspose.Slides for Python via Java a kompatibilní Java runtime. JVM se spustí jednou na jeden proces Pythonu.

Tento příklad zapíše jeden HTML soubor. Objekt prezentace je uvolněn v bloku `finally`, který po exportu uvolní souborové handly a zdroje renderování.

## **Konfigurace exportu HTML**

[HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): přidává poznámky, komentáře, podklady nebo jiné informace o rozvržení.
- [setHtmlFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setHtmlFormatter): mění strukturu HTML dokumentu nebo deleguje formátování na kontroler.
- [setSlideImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlideImageFormat): mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression): řídí DPI obrázků a velikost výstupu.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): zachovává nebo odstraňuje oříznutá data obrázků.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- [setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): zahrnuje skryté snímky, pokud je to požadováno.

Následující sekce ukazují nejčastější možnosti samostatně, abyste je mohli kombinovat jen podle potřeby vašeho pracovního postupu.

## **Převod vybraných snímků do HTML**

Přetížení [Prezentace.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save), které přijímá čísla snímků, používá 1‑základní indexování snímků. Smyčka níže ukládá každý snímek do samostatného HTML souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má každý snímek stejné rozvržení, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/) a předávejte ji každému volání [Prezentace.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save).

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/responsivehtmlcontroller/) poskytuje responzivní výstup HTML prostřednictvím [HtmlFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/). Použijte jej, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Pro responzivní rozvržení založené na SVG zavolejte [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) s hodnotou `True`. To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Zahrnutí poznámek přednášejícího a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) přes [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) k zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud si nevyberete jejich pozice.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Snímek s poznámkami přednášejícího v PowerPointu](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami přednášejícího pod snímkem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Exportované HTML obsahuje oblast poznámek:

![HTML výstup se snímkem a poznámkami přednášejícího](HTML_with_notes.png)

Pro export komentářů zavolejte [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), například s [CommentsPositions.Right](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentspositions/#Right) nebo [CommentsPositions.Bottom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentspositions/#Bottom). Pokud potřebujete jen komentáře, vynechte [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Pokud potřebujete oba, poznámky i komentáře, zavolejte obě metody.

## **Řízení kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků, aby se snížila velikost výstupu. Při potřebě vyšší kvality obrázků předávejte hodnotu do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression) z [PicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturescompression/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z exportovaného výstupu odstraněny. Zachovávejte oříznutá data jen tehdy, když uživatelé musí být schopni tyto skryté části obrázku obnovit nebo zkontrolovat. Zachování může zvýšit velikost HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Přidání CSS**

Pro jednoduché stylování předávejte řetězec CSS do [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Tím se změní obklopující HTML dokument, zatímco Aspose.Slides nadále renderuje obsah snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Pro vlastní hlavičku dokumentu, odkazovaný soubor CSS nebo vlastní značkování okolo snímků a tvarů použijte vlastní řídící formátování přes proxy rozhraní JPype a předávejte jej [HtmlFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/) pomocí [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Vložení písem**

Pokud cílové prostředí nemusí mít písma z prezentace nainstalována, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvětšuje velikost výstupu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Vylučujte písma jen tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní nebo méně běžná písma je vložení obvykle bezpečnější.

## **Ukládání zdrojů externě**

Samostatné HTML je snadno přenositelné, ale vložené zdroje Base64 mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte řídící odkazování na zdroje přes proxy rozhraní JPype a předávejte jej konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/).

Když externalizujete zdroje, zvolte dvě cesty úmyslně:

- Cestu výstupu na souborovém systému, kam aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- URL cestu, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů.

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je dokáže přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou zapisovány vygenerované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI předpona použitá v HTML odkazech na mediální soubory.

Následující příklad exportuje média již vložená v `presentation.pptx`. Vygenerované HTML odkazuje na mediální soubory jen názvem souboru, relativně k HTML dokumentu, takže `path` musí být adresář, který také přijímá HTML soubor. `baseUri` musí být absolutní URI: pro lokální náhled vytvořte `file:///` URI z výstupního adresáře; pro nasazenou aplikaci použijte absolutní URL publikovaného adresáře.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Používejte výstupní adresáře, které jsou jedinečné pro každý exportní úkol, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit přepsání souborů z různých konverzí.

## **Výkon a správa zdrojů**

Konverze HTML je renderovací operace, takže čas zpracování a využití paměti závisí na počtu snímků, rozlišení obrázků, písmům, efektech, grafech a vložených médiích. Vyšší DPI obrázků předávané do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression), vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolňujte každou instanci [Prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Používejte samostatné výstupní adresáře pro různé úkoly.
- Vyhýbejte se vkládání běžných písem, pokud to není nezbytné pro věrnost.
- Snižujte DPI obrázků, když je HTML určeno pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje spolu, dokud nejsou konečné cesty nasazení.

## **Často kladené otázky**

**Zachovají se hypertextové odkazy v HTML výstupu?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentací, oddělenými proudy a oddělenými výstupními adresáři. Viz [průvodce vícevláknovým zpracováním](/slides/cs/python-java/multithreading/) pro podrobnosti.

**Je objekt prezentace bezpečný pro více vláken?**

Ne. Jedna instance [Prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna na jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci na každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vkládat zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také velikost zvyšují. Použijte externí zdroje, vylučte běžná písma z vkládání a předávejte nižší DPI hodnotu do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression), když je menší výstup důležitější než maximální věrnost.

**Proč se hodnoty font-size v HTML liší od hodnot v PowerPointu?**

Exportovaná stránka může používat SVG souřadnicové systémy a škálovací transformace. Samotná hodnota CSS nebo SVG font-size nepopisuje finální zobrazenou velikost. Porovnejte vykreslený snímek při zamýšlené úrovni přiblížení a zkontrolujte dostupnost písem, pokud text vypadá jinak.

**Jak si mám vybrat baseUri pro export médií?**

Vyberte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled jej můžete odvodit z výstupního adresáře pomocí `output_directory.as_uri() + "/"`. Pro nasazení použijte absolutní URL publikovaného adresáře. Souborový systém `path` a prohlížeč `baseUri` nemusí být stejný řetězec, ale musí popisovat stejné umístění a to umístění musí být adresář, který obsahuje vygenerovaný HTML soubor, protože odkazy na média jsou k němu relativní.

**Mohu zahrnout skryté snímky?**

Ano. Zavolejte [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) s hodnotou `True`, když je nutné exportovat skryté snímky.