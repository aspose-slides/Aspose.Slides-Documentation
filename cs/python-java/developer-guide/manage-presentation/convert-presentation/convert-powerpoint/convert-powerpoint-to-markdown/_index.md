---
title: Převod prezentací PowerPoint do Markdownu v Pythonu přes Java
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/python-java/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do MD
- prezentace do MD
- snímek do MD
- PPT do MD
- PPTX do MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- export obrázků do Markdownu
- CDN odkazy na obrázky
- PowerPoint
- prezentace
- Markdown
- Python
- Java
- Aspose.Slides
description: "Převod prezentací PPT a PPTX do Markdownu v Pythonu přes Java a řízení, kde jsou exportované bitmapové, metafile a SVG obrázky uloženy a na které odkazy se odkazuje."
---
## **Přehled**

Aspose.Slides pro Python přes Java může převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a workflow verzování. Můžete si vybrat variantu Markdownu, řídit, jak je obsah snímků vykreslen, a rozhodnout, kde jsou exportované obrázky uloženy a jak na ně generovaný Markdown odkazuje.

Ve výchozím nastavení export do Markdownu používá výstup pouze s textem. Pro export vizuálního obsahu nastavte typ exportu metodou [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setExportType) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownexporttype/). `Sequential` vykresluje položky snímku samostatně a v pořadí, zatímco `Visual` zachovává seskupené položky společně, aby se udržel jejich vizuální vztah. Hodnota `TextOnly` nevytváří obrazové zdroje, takže v tomto režimu není volána žádná zpětná volání pro ukládání obrázků.

## **Převést prezentaci do Markdownu**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a poté zavolejte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/).

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

Každý příklad čte soubor `presentation.pptx` z aktuálního pracovního adresáře. Před spuštěním příkladů nainstalujte Aspose.Slides pro Python přes Java a kompatibilní Java runtime. JVM spusťte jednou na jeden Python proces.

## **Vybrat variantu Markdownu**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setFlavor) určuje, která specifikace Markdownu se použije pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci jako CommonMark:

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

## **Exportovat obrázky pomocí výchozího lokálního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci lokálně uložených obrázků:

- [setBasePath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setBasePath) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) určuje podadresář pro obrázky. Výchozí hodnota je `Images`.

Následující příklad vykresluje vizuální obsah, zapisuje obrázky do `output/assets` a vytváří relativní odkazy na obrázky v dokumentu Markdown:

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

Toto chování také slouží jako náhradní řešení, když vlastní handler pro ukládání obrázků vrátí `False`.

## **Přizpůsobit ukládání obrázků a odkazy v Markdownu**

Použijte metodu [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/) k registraci zpětné volání pro bitmapové a metafile zdroje, které nejsou ve formátu SVG, a jsou emitovány během exportu do Markdownu. Jeho callback `MarkdownImageSavingHandler` přijímá objekt obrázku, jeho hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/) a vygenerovaný odkaz v Markdownu jako jednoprvkový parametr `String[]`. Uložte nebo nahrajte obrázek ve zvoleném formátu a nahraďte `link[0]` odkazem, který má být v Markdown výstupu.

Zdroje emitované ve formátu SVG se zpracovávají odděleně. Registrovat zpětnou volání pomocí metody [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/). Jeho callback `MarkdownSvgImageSavingHandler` přijímá objekt [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) a jednoprvkový parametr `String[] link`. SVG nemá argument `ImageFormat`; místo toho zapište nebo nahrajte jeho XML data pomocí metody [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/#getSvgData). V závislosti na režimu exportu a vizuálním seskupení může být SVG v zdrojové prezentaci rasterizováno nebo sloučeno s jiným obsahem; výsledný ne‑SVG zdroj je pak předán callbacku pro ukládání obrázku. Zaregistrujte oba callbacky, pokud každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

Návratová hodnota handleru určuje, kdo obrázek zpracuje:

- Vraťte `True`, pokud handler obrázek uložil, nahrál, transformoval nebo jinak zpracoval a přiřadil platnou hodnotu do `link[0]`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovádí výchozí lokální uložení.
- Vraťte `False`, aby Aspose.Slides uložil obrázek lokálně a vygeneroval odkaz podle hodnot nastavených metodami [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setBasePath) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Důležité" %}}

Handler, který vrátí `True`, přebírá odpovědnost za obrázek. Pokud vrátí `True` bez přiřazení platného, ne‑prázdného odkazu, export selže s výjimkou `InvalidOperationException`.

{{% /alert %}}

V Pythonu zaregistrujte tyto callbacky pomocí `jpype.JProxy`, implementující Java rozhraní callbacku prostřednictvím jeho metody `invoke`. Argument `link` je měnitelné pole řetězců Java: před zpracováním převěďte `link[0]` na Python řetězec, poté přiřaďte nahrazující URL zpět do `link[0]`.

### **Uložit obrázky do adresáře CDN origin a použít externí URL**

Následující příklad zachází s `cdn-origin/presentations/quarterly-report` jako připojeným nebo synchronizovaným CDN origin adresářem. Každý handler získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí lokální odkaz veřejnou CDN URL. Samotný příklad neprovádí žádné síťové nahrávání: URL je platná až po připojení adresáře jako CDN origin nebo po publikaci souborů na CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrání SDK úložiště a přiřaďte `link[0]` až po úspěšném nahrání.

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

Bitmapový handler úmyslně vrací `False` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides ukládá tyto obrázky do `output/fallback-images` pomocí výchozího chování. Větší bitmapy a metafile zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz jako `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery používají cesty operačního systému jen při zápisu souborů; odkazy zapisované do Markdownu používají lomítka a URL‑kódované názvy souborů. Používejte stejný pravidlo i při vytváření relativních odkazů: použijte `/`, ne platformově specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jeden handler zpracovávat jak rastrové obrázky, tak SVG obrázky?**

Ne. Použijte [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/) pro bitmapové a metafile zdroje a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/) pro zdroje emitované jako SVG. První poskytuje objekt obrázku a hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/); druhý poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/), jehož SVG data lze načíst metodou [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/#getSvgData). SVG zdroj, který je během exportu rasterizován, je zpracován pomocí callbacku pro ukládání obrázku.

**Co se stane, když handler pro ukládání obrázků vrátí `False`?**

Aspose.Slides použije své výchozí chování lokálního ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny hodnotami nastavenými pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setBasePath) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Může handler poskytnout URL bez lokálního uložení obrázku?**

Ano. Handler může obrázek nahrát do objektového úložiště nebo jej předat jinému servisu, přiřadit vzniklou URL do `link[0]` a vrátit `True`. Handler musí zpracování dokončit sám; vrácení `True` zabraňuje výchozímu lokálnímu uložení.

**Proč export do Markdownu vyvolá `InvalidOperationException` z handleru?**

Tato výjimka nastane, když handler vrátí `True`, ale neposkytne platný odkaz. Před vrácením `True` přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu.

**Jaký oddělovač cesty by měly používat odkazy na obrázky?**

V Markdown odkazech a URL používejte lomítka (`/`). Pro cesty souborového systému používejte `pathlib.Path`, pak samostatně vytvořte nebo normalizujte odkaz v Markdownu.

**Zachovají se hypertextové odkazy během exportu do Markdownu?**

Ano. Textové [hyperlinky](/slides/cs/python-java/manage-hyperlinks/) jsou zachovány jako standardní Markdown odkazy. [Přechody](/slides/cs/python-java/slide-transition/) a [animace](/slides/cs/python-java/powerpoint-animation/) snímků nejsou konvertovány.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) mezi vlákny. Dodržujte [pokyny pro multithreading](/slides/cs/python-java/multithreading/) a použijte samostatnou instanci pro každý soubor.