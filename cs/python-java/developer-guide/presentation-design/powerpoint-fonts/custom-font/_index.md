---
title: Přizpůsobení písem PowerPoint v Pythonu přes Java
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/python-java/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro Python přes Java, aby vaše prezentace byly ostré a konzistentní na každém zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci pomocí zdrojů písem na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také popisuje, jak zkontrolovat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vložení písem do souboru PPTX. Pokud je nutné, aby písmo bylo uloženo přímo v prezentaci, použijte funkce vkládání písem explicitně.

Téma prezentace může odkazovat na různé rodiny písem pro jednotlivé psací systémy. Tyto mapování ukládají názvy písem, ale neinstalují ani neinicializují soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/python-java/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby byla odkazovaná písma dostupná pro konzistentní vykreslování.

{{% alert color="info" title="Poznámka" %}}

Aspose.Slides vám umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více adresářů obsahujících soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFonts) pro načtení písem z těchto adresářů.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#clearCache), aby se vymazala mezipaměť písem.

Následující příklad kódu demonstruje proces načítání písem:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definujte složky obsahující soubory vlastních písem.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Načtěte vlastní písma ze zadaných složek.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Vykreslete/exportujte prezentaci pomocí načtených písem.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Vymažte mezipaměť písem po dokončení práce.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Poznámka" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFonts) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.  
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené přes [FontsLoader](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat složky s vlastními písmy**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#getFontFolders), která vám umožňuje najít složky s písmy. Tato metoda vrací složky přidané pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFonts) a systémové složky s písmy.

Tento Python kód vám ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Získat složky přidané pomocí loadExternalFonts a systémové složky s písmy.
font_folders = FontsLoader.getFontFolders()
```

## **Specifikovat vlastní písma použité v prezentaci**
Aspose.Slides poskytuje metodu [getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources), která vám umožňuje specifikovat externí písma, která budou použita v prezentaci. 

Tento Python kód vám ukazuje, jak použít metodu [getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Pracovat s prezentací.
    # CustomFont1, CustomFont2 a písma z assets/fonts a global/fonts
    # a jejich podsložky jsou k dispozici pro prezentaci.
    pass
finally:
    presentation.dispose()
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFont), která vám umožňuje načíst externí písma z binárních dat.

Tento Python kód demonstruje proces načítání písem z pole bajtů:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Externí písma jsou načtena během životnosti prezentace.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána renderovačem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitní [vkládací funkce](/slides/cs/python-java/embedded-font/).

**Mohu řídit chování náhradního písma, když vlastní písmo postrádá určité glyfy?**

Ano. Nakonfigurujte [nahrazení písem](/slides/cs/python-java/font-substitution/), [pravidla nahrazování](/slides/cs/python-java/font-replacement/), a [sady náhrad](/slides/cs/python-java/fallback-font/), aby bylo přesně určeno, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich instalace na úrovni systému?**

Ano. Odkazujte na vlastní složky s písmy nebo načítejte písma z polí bajtů. Tím se odstraní jakákoli závislost na systémových složkách s písmy v obrazu kontejneru.

**Co se týče licencování – mohu vložit jakékoli vlastní písmo bez omezení?**

Vy jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte smluvní podmínky (EULA) daného písma.