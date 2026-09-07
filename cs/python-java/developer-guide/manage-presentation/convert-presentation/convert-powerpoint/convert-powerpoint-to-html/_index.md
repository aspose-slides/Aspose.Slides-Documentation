---
title: Převod prezentací PowerPoint do HTML v Pythonu přes Java
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/python-java/convert-powerpoint-to-html/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
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
description: "Převod prezentací PowerPoint do HTML v Pythonu přes Java. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides for Python via Java může uložit prezentace PowerPoint jako HTML bez Microsoft PowerPointu. Základní konverze spočívá v načtení jedné [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a volání [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/), když potřebujete kontrolovat exportovaný rozvrh, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu HTML:

- Exportovat celou prezentaci nebo vybrané snímky.
- Vytvořit HTML s pevnou stránkou, responzivní nebo založené na SVG.
- Zahrnout poznámky přednášejícího a komentáře.
- Řídit kvalitu obrázků a oříznutá data obrázků.
- Vložit písma nebo uložit soubory písem samostatně.
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je výhodné pro sdílení jediného souboru, ale může zvýšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vkládání jen těch písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a uložte pomocí [SaveFormat.Html](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Html).

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

Každý příklad načítá `presentation.pptx` z aktuálního pracovního adresáře. Před spuštěním nainstalujte Aspose.Slides for Python via Java a kompatibilní runtime Java. JVM se spustí jednou na každý proces Pythonu.

Tento příklad zapíše jeden HTML soubor. Objekt prezentace je uvolněn v bloku `finally`, který po exportu uvolní souborové handly a prostředky vykreslování.

## **Nastavení exportu HTML**

[HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): přidává poznámky, komentáře, podklady nebo jiné informace o rozvržení.
- [setHtmlFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setHtmlFormatter): mění strukturu HTML dokumentu nebo deleguje formátování na řadič.
- [setSlideImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlideImageFormat): mění způsob reprezentace snímků, například jako SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression): řídí DPI obrázků a velikost výstupu.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): zachovává nebo odstraňuje oříznutá data obrázků.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- [setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): zahrnuje skryté snímky, pokud jsou požadovány.

Následující sekce ukazují nejčastější možnosti samostatně, aby jste mohli spojit jen ty, které vaše pracovní postup potřebuje.

## **Převod vybraných snímků do HTML**

Přetížení [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save), které přijímá čísla snímků, používá 1‑založené pozice snímků. Smyčka níže uloží každý snímek do samostatného HTML souboru.

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

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má mít každý snímek stejný rozvrh, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/) a předávejte ji každému volání [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save).

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

Pro responzivní rozvrh založený na SVG zavolejte [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) s hodnotou `True`. To je užitečné, když je obsah snímku exportován jako škálovatelný SVG kód.

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

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) skrze [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), abyste zahrnuli poznámky přednášejícího nebo komentáře. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud nevyberete jejich pozice.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

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

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pro export komentářů zavolejte [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) např. s [CommentsPositions.Right](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentspositions/#Right) nebo [CommentsPositions.Bottom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentspositions/#Bottom). Pokud potřebujete jen komentáře, vynechte [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Pokud potřebujete jak poznámky, tak komentáře, zavolejte obě metody.

## **Řízení kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků, aby snížil velikost výstupu. Při potřebě vyšší kvality obrázků předávejte hodnotu do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression) z [PicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturescompression/).

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

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z exportovaného výstupu odstraněny. Uchovávejte oříznutá data pouze tehdy, když uživatelé musí mít možnost obnovit nebo prohlédnout tyto skryté části obrázku. Uchování může zvýšit velikost HTML.

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

Pro jednoduché stylování předávejte řetězec CSS do [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Tím změníte okolní HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímku.

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

Pro vlastní hlavičku dokumentu, propojený soubor CSS nebo vlastní značkování kolem snímků a tvarů použijte vlastní řadič formátování přes proxy rozhraní JPype a předávejte jej [HtmlFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/) pomocí [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Vkládání písem**

Pokud cílové prostředí nemusí mít nainstalována písma prezentace, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvyšuje velikost výstupu.

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

Vylučujte písma jen tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Ukládání zdrojů externě**

Samostatný HTML je snadno přenositelný, ale vložené Base64 zdroje mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte řadič pro propojování zdrojů přes proxy rozhraní JPype a předávejte jej konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/).

Při externalizaci zdrojů zvolte dva cesty úmyslně:

- Cestu výstupu v souborovém systému, kam vaše aplikace zapisuje generované obrázky, písma, audio nebo video.
- Cestu URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů.

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, do kterého budou zapisovány generované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI předpona používaná v HTML odkazech na mediální soubory.

Následující příklad exportuje média již vložená v `presentation.pptx`. Vytvořené HTML odkazuje na mediální soubory pouze podle názvu souboru, relativně k HTML dokumentu, takže `path` musí být adresář, který také přijímá HTML soubor. `baseUri` musí být absolutní URI: pro lokální náhled vytvořte `file:///` URI z výstupního adresáře; pro nasazenou aplikaci použijte absolutní URL publikovaného adresáře.

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

Používejte výstupní adresáře jedinečné pro každou úlohu exportu, zvláště v serverových aplikacích. Sdílené výstupní cesty mohou způsobit přepsání souborů z různých konverzí.

## **Výkon a správa zdrojů**

Konverze HTML je operace vykreslování, takže doba zpracování a využití paměti závisí na počtu snímků, rozlišení obrázků, písmenech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI obrázků předávané do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression), vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkový převod:

- Okamžitě uvolněte každou instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Používejte oddělené výstupní adresáře pro různé úlohy.
- Vyhněte se vkládání běžných písem, pokud to není nezbytné pro věrnost.
- Snižte DPI obrázků, když je HTML určeno pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální nasazovací cesty.

## **Často kladené otázky**

**Zůstávají hyper odkazy v HTML výstupu?**

Ano. Hyper odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými streamy a oddělenými výstupními adresáři. Podívejte se na [multithreading guidance](/slides/cs/python-java/multithreading/) pro podrobnosti.

**Je objekt prezentace bezpečný pro vlákna?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci pro každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vkládat zdroje přímo do HTML. Vložená písma, vysoké DPI obrázky, média, SVG obsah a zachování oříznutých oblastí obrázků také zvyšují velikost. Použijte externí zdroje, vyloučte běžná písma z vkládání a předávejte nižší hodnotu DPI do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setPicturesCompression), pokud je menší výstup důležitější než maximální věrnost.

**Proč se hodnoty font-size v HTML mohou lišit od hodnot v PowerPointu?**

Exportovaná stránka může používat souřadnicové systémy SVG a transformace škálování. Samotná surová hodnota CSS nebo SVG font-size nepopisuje konečnou zobrazovanou velikost. Porovnejte vykreslený snímek na zamýšlené úrovni přiblížení a zkontrolujte dostupnost fontů, pokud text vypadá jinak.

**Jak mám zvolit baseUri pro export médií?**

Zvolte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled jej můžete odvodit z výstupního adresáře pomocí `output_directory.as_uri() + "/"`. Pro nasazení použijte absolutní URL publikovaného adresáře. Souborový `path` a prohlížečový `baseUri` nemusí být stejný řetězec, ale musí popisovat stejné místo, a to místo musí být adresář, který obsahuje vygenerovaný HTML soubor, protože odkazy na média jsou zapisovány relativně k němu.

**Mohu zahrnout skryté snímky?**

Ano. Zavolejte [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) s hodnotou `True`, když je nutné exportovat skryté snímky.