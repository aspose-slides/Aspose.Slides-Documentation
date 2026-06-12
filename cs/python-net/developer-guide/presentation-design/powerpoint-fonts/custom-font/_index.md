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
- spravovat písma
- složka s písmy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vložte vlastní písma do snímků PowerPointu pomocí Aspose.Slides for Python přes .NET, aby byly vaše prezentace ostře a konzistentně zobrazeny na všech zařízeních."
---
## **Přehled**

Aspose.Slides pro Python vám umožňuje poskytovat vlastní písma za běhu, aby se prezentace vykreslovaly správně i v případě, že požadovaná písma nejsou nainstalována v hostitelském systému. Během exportu do PDF nebo obrázků můžete poskytnout složky s písmy nebo data písem v paměti, aby byl zachován rozvrh textu, metriky glifů a typografie. To dělá vykreslování na serveru předvídatelným napříč různými prostředími, odstraňuje závislosti na písmech na úrovni operačního systému a zabraňuje nechtěným náhradám nebo přeskupení textu. Článek ukazuje, jak zaregistrovat zdroje písem.

Aspose.Slides vám umožňuje načíst následující písma pomocí metod `load_external_font` a `load_external_fonts` třídy [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použitá v prezentaci bez jejich instalace do systému. To ovlivňuje výstup při exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více adresářů, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/load_external_fonts/), která načte písma z těchto adresářů.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clear_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/clear_cache/) pro vymazání mezipaměti písem.

Následující ukázkový kód demonstruje proces načítání písem:

```py
import aspose.slides as slides

# Definujte složky, které obsahují vlastní soubory písem.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Načíst vlastní písma ze specifikovaných složek.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Vykreslit/exportovat prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Vyčistit mezipaměť písem po dokončení práce.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Poznámka" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/load_external_fonts/) přidává další adresáře do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat složku vlastních písem**

Aspose.Slides poskytuje metodu `get_font_folders` pro získání složek s písmy. Vrací jak složky přidané pomocí `load_external_fonts`, tak systémové složky písem.

Následující Python kód ukazuje, jak použít `get_font_folders`:

```python
import aspose.slides as slides

# Toto volání vrací složky kontrolované pro soubory písem.
# Tyto zahrnují složky přidané pomocí metody load_external_fonts a systémové složky s písmy.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Zadat vlastní písma pro prezentaci**

Aspose.Slides poskytuje vlastnost `document_level_font_sources`, která vám umožní zadat externí písma pro použití v prezentaci.

Následující Python příklad ukazuje, jak použít `document_level_font_sources`:

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
    # Práce s prezentací.
    # CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts (a jejich podsložek) jsou dostupná v prezentaci.
    # ...
    print(len(presentation.slides))
```

## **Načíst externí písma z binárních dat**

Aspose.Slides poskytuje metodu `load_external_font` pro načtení externích písem z binárních dat.

Následující Python příklad demonstruje načtení písma z pole bajtů:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Načíst externí písma z bytových polí.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externí písma jsou k dispozici po celou dobu životnosti této instance prezentace.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána rendererem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít explicitní [funkce vložení](/slides/cs/python-net/embedded-font/).

**Mohu řídit chování náhrad při absenci určitých glifů ve vlastním písmu?**

Ano. Nakonfigurujte [substituce písem](/slides/cs/python-net/font-substitution/), [pravidla nahrazení](/slides/cs/python-net/font-replacement/) a [sady náhrad](/slides/cs/python-net/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glif chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich systémové instalace?**

Ano. Ukazujte na vlastní složky s písmy nebo načítejte písma z polí bajtů. Tím se odstraní jakákoli závislost na systémových adresářích s písmy v obrazu kontejneru.

**Co licenci — mohu vložit libovolné vlastní písmo bez omezení?**

Jste zodpovědní za dodržování licenčních podmínek písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před šířením výstupů přečtěte licenční smlouvu (EULA) daného písma.