---
title: Převod prezentací PowerPoint do HTML v Pythonu
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/python-net/convert-powerpoint-to-html/
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
- Aspose.Slides
description: "Převod prezentací PowerPoint do HTML v Pythonu. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a multimédií."
---
## **Přehled**

Aspose.Slides for Python via .NET může uložit prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní převod spočívá v načtení jedné [Prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a volání `save` s [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) v případě, že potřebujete řídit exportovaný rozvrh, písma, obrázky, poznámky, komentáře, SVG výstup nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu do HTML:

- Export celé prezentace nebo vybraných snímků.
- Vytvoření pevného rozvrhu, responzivního nebo na SVG založeného HTML.
- Zahrnutí poznámek přednášejícího a komentářů.
- Řízení kvality obrázků a oříznutých dat obrázků.
- Vkládání písem nebo ukládání souborů písem odděleně.
- Výběr, jak budou externí zdroje a mediální soubory zapsány a odkazovány.

Ve výchozím nastavení export HTML vytvoří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je pohodlné pro sdílení jednoho souboru, ale může zvýšit velikost výstupu. Pro publikaci na webu zvažte externí zdroje, nižší DPI obrázků a vkládání pouze písem, která nejsou spolehlivě k dispozici v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a uložte pomocí [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Tento příklad zapíše jeden HTML soubor. Příkaz `with` uvolní objekt prezentace a uvolní souborové popisovače a vykreslovací prostředky po exportu.

## **Použití HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) je hlavní konfigurační třída pro export do HTML. Běžná nastavení zahrnují:

- `slides_layout_options`: přidává poznámky, komentáře, podklady nebo jiné informace o rozvrhu.
- `html_formatter`: mění strukturu HTML dokumentu nebo deleguje formátování na řadič.
- `slide_image_format`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `pictures_compression`: řídí DPI obrázků a velikost výstupu.
- `delete_pictures_cropped_areas`: uchovává nebo odstraňuje oříznutá data obrázků.
- `svg_responsive_layout`: umožňuje, aby exportovaný SVG obsah reagoval na svůj kontejner.
- `show_hidden_slides`: zahrnuje skryté snímky, když je to požadováno.

Následující sekce ukazují nejčastější možnosti samostatně, abyste mohli kombinovat jen ty, které váš pracovní postup potřebuje.

## **Převod vybraných snímků do HTML**

Přetížení `save`, které přijímá čísla snímků, používá pozice snímků číslované od 1. Smyčka níže uloží každý snímek do samostatného HTML souboru.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má mít každý snímek stejný rozvrh, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) a předávejte ji každému volání `save`.

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/responsivehtmlcontroller/) poskytuje responzivní HTML výstup prostřednictvím [HtmlFormatter](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmlformatter/). Použijte ho, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Pro responzivní rozvrh založený na SVG nastavte `svg_responsive_layout` na [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Zahrnutí poznámek přednášejícího a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) přes `html_options.slides_layout_options` pro zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud nevyberete jejich pozice.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Snímek s poznámkami přednášejícího v PowerPointu](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami pod snímkem.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Exportované HTML zahrnuje oblast poznámek:

![HTML výstup se snímkem a poznámkami přednášejícího](HTML_with_notes.png)

Pro export komentářů nastavte `comments_position`, například na `CommentsPositions.RIGHT` nebo `CommentsPositions.BOTTOM`. Pokud potřebujete jen komentáře, vynechte `notes_position`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Řízení kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků za účelem zmenšení velikosti výstupu. Nastavte `pictures_compression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/picturescompression/), když potřebujete vyšší kvalitu obrázků.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z exportovaného výstupu odebrány. Uchovávejte oříznutá data jen tehdy, pokud uživatelé musí být schopni tyto skryté části obrázku obnovit nebo je zkontrolovat. Uchování může zvýšit velikost HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Přidání CSS**

Pro jednoduché stylování předávejte řetězec CSS do [HtmlFormatter](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmlformatter/). Tím se změní okolní HTML dokument, zatímco Aspose.Slides bude nadále vykreslovat obsah snímku.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Pro vlastní záhlaví dokumentu, odkazovaný CSS soubor nebo vlastní značkování okolo snímků a tvarů použijte vlastní řadič formátování a předávejte jej [HtmlFormatter](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmlformatter/) pomocí `create_custom_formatter`.

## **Vkládání písem**

Pokud cílové prostředí nemusí mít písma použité v prezentaci nainstalována, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální přesnost, ale zvětšuje velikost výstupu.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Vylučujte písmo jen tehdy, když jste si jisti, že cílové prohlížeče nebo systémy jej již poskytují. Pro firemní písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Odkazování na soubory písem místo jejich vkládání**

Pro zmenšení velikosti HTML souboru můžete data písem zapsat do samostatných souborů WOFF a přidat pravidla `@font-face` do HTML. To vyžaduje řadič, který přizpůsobí způsob zápisu dat písem během exportu. V Pythonu přes .NET implementujte tento řadič v malé .NET pomocné sestavě, načtěte jej v Pythonu a předávejte pomocný objekt [HtmlFormatter](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmlformatter/) pomocí `create_custom_formatter`.

Když externalizujete písma, vyberte dvě cesty úmyslně:

- Složku v souborovém systému, kam budou generované soubory WOFF zapsány.
- URL cestu, která se objeví v HTML dokumentu a kterou prohlížeč použije k načtení těchto souborů písem.

Uchovávejte HTML soubor a generované soubory písem společně až do finálního nasazení. Pokud jsou soubory nasazeny na jiné místo, upravte URL předponu tak, aby odpovídala nasazené URL cestě.

## **Ukládání zdrojů externě**

Samostatné HTML je snadno přenositelné, ale vložené Base64 zdroje mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, písem, audia nebo videa, použijte vlastní řadič odkazů/vkládání a předávejte jej konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/).

Když externalizujete zdroje, vyberte dvě cesty úmyslně:

- Výstupní cestu v souborovém systému, kde vaše aplikace zapíše generované obrázky, písma, audio nebo video.
- URL cestu, kterou prohlížeč použije z HTML dokumentu k načtení těchto souborů.

Pro podrobnou diskusi o propojování obrázků viz [Export Prezentací do HTML s externě odkazovanými obrázky](/slides/cs/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou generované mediální soubory zapsány.
- `file_name`: název generovaného HTML souboru.
- `base_uri`: absolutní URI předpona použita v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `base_uri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro lokální náhled můžete vytvořit `file:///` URI ze složky s médii. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Používejte výstupní složky, které jsou jedinečné pro každý exportní úkol, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit, že soubory z různých konverzí přepíší jedna druhou.

## **Výkon a správa prostředků**

Konverze do HTML je vykreslovací operace, takže doba zpracování a spotřeba paměti závisí na počtu snímků, rozlišení obrázků, písmech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI v `pictures_compression`, vložená písma, SVG výstup a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvýší velikost výstupu.

Pro dávkový převod:

- Okamžitě uvolňujte každou instance [Prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
- Používejte samostatné výstupní složky pro různé úkoly.
- Vyhněte se vkládání běžných písem, pokud to věrnost nevyžaduje.
- Snižujte DPI obrázků, když je HTML určeno jen pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně až do finálního nasazení cest.

## **Často kladené otázky**

**Zůstávají hypertextové odkazy v HTML výstupu zachovány?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílové URL platné.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentací, oddělenými proudy a oddělenými výstupními složkami. Viz [pokyny k vícevláknovému zpracování](/slides/cs/python-net/multithreading/).

**Je objekt Prezentace vláknově bezpečný?**

Ne. Jedna instance [Prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci na každé vlákno nebo proces.

**Proč je generovaný HTML soubor velký?**

Výchozí export může vložit zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také zvyšují velikost. Použijte externí zdroje, vylučte běžná písma z vkládání a snižte `pictures_compression`, když je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma v PowerPointu 24 pt zobrazí v HTML jako 17,999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají různé DPI modely. PowerPoint ukládá velikosti textu v typografických bodech založených na 72 DPI, zatímco rozvržení HTML vychází z CSS pixelů v modelu 96 DPI. Když Aspose.Slides exportuje prezentaci do HTML, velikost písma je přeložena mezi těmito systémy a konverze může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jsou pouze matematickým vedlejším efektem převodu textových metrik mezi PowerPointem a HTML.

**Jak vybrat `base_uri` pro export médií?**

Zvolte `base_uri` z pohledu prohlížeče a předávejte ji jako absolutní URI. Pro lokální náhled ji můžete odvodit z výstupní složky pomocí `Path(media_directory).as_uri() + "/"`. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový systém `path` a prohlížečský `base_uri` nemusí být stejný řetězec, ale musí popisovat stejnou polohu zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `show_hidden_slides = True` na [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/), když musí být skryté snímky exportovány.