---
title: Přizpůsobení písem PowerPointu v Pythonu
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/python-net/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- správa písem
- složka s písmy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vložte vlastní písma do snímků PowerPointu pomocí Aspose.Slides pro Python přes .NET, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides pro Python vám umožňuje poskytovat vlastní písma za běhu, takže prezentace jsou vykresleny správně i v případě, že požadovaná písma nejsou nainstalována v hostitelském systému. Při exportu do PDF nebo obrázků můžete dodat složky s písmy nebo data písem v paměti, aby byl zachován rozvrh textu, metriky glifů a typografie. To činí vykreslování na serveru předvídatelným napříč různými prostředími, odstraňuje závislosti na písmenech na úrovni OS a zabraňuje nechtěným náhradám nebo přetékání. Článek ukazuje, jak zaregistrovat zdroje písem.

Motiv prezentace může odkazovat na různé rodiny písem pro jednotlivé písmo systémy. Tyto mapování ukládají názvy písem, ale neinstalují ani nenačítají soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/python-net/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby byly odkazované fonty k dispozici pro konzistentní vykreslování.

Aspose.Slides vám umožňuje načíst následující písma pomocí metod `load_external_font` a `load_external_fonts` třídy [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Uveďte jeden nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/load_external_fonts/) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clear_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/clear_cache/) pro vymazání mezipaměti písem.

Následující příklad kódu demonstruje proces načítání písem:

```py
import aspose.slides as slides

# Definujte složky, které obsahují vlastní soubory písem.
font_folders = ["fonts", "external_fonts"]

# Načtěte vlastní písma ze specifikovaných složek.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Vymažte mezipaměť písem po dokončení práce.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/load_external_fonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené prostřednictvím [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat složku s vlastními písmy**

Aspose.Slides poskytuje metodu `get_font_folders` pro získání složek s písmy. Vrací jak složky přidané pomocí `load_external_fonts`, tak systémové složky s písmy.

Následující kód v Pythonu ukazuje, jak použít `get_font_folders`:

```python
import aspose.slides as slides

# Toto volání vrací složky kontrolované pro soubory písem.
# Tyto zahrnují složky přidané pomocí metody load_external_fonts a systémové složky s písmy.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Určit vlastní písma pro prezentaci**

Aspose.Slides poskytuje vlastnost `document_level_font_sources`, která vám umožňuje určit externí písma k použití v prezentaci.

Následující příklad v Pythonu ukazuje, jak použít `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Pracujte s prezentací.
    # CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts (včetně jejich podsložek) jsou k dispozici v prezentaci.
    # ...
    print(len(presentation.slides))
```

## **Načíst externí písma z binárních dat**

Aspose.Slides poskytuje metodu `load_external_font` pro načtení externích písem z binárních dat.

Následující příklad v Pythonu demonstruje načtení písma z pole bytů:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Načtěte externí písma z pole bytů.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externí písma jsou k dispozici po celou životnost této instance prezentace.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Často kladené otázky**

### Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?

Ano. Připojená písma jsou používána rendererem ve všech exportních formátech.

### Are custom fonts automatically embedded into the resulting PPTX?

Ne. Zaregistrování písma pro vykreslení není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/python-net/embedded-font/).

### Can I control fallback behavior when a custom font lacks certain glyphs?

Ano. Nakonfigurujte [font substitution](/slides/cs/python-net/font-substitution/), [replacement rules](/slides/cs/python-net/font-replacement/), a [fallback sets](/slides/cs/python-net/fallback-font/), abyste přesně definovali, které písmo se použije, když požadovaný glif chybí.

### Can I use fonts in Linux/Docker containers without installing them system-wide?

Ano. Odkazujte na vlastní složky s písmy nebo načítejte písma z polí bytů. Tím se odstraní jakákoli závislost na systémových adresářích s písmy v obrazu kontejneru.

### What about licensing—can I embed any custom font without restrictions?

Jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční používání. Vždy si před distribucí výstupů prostudujte EULA daného písma.