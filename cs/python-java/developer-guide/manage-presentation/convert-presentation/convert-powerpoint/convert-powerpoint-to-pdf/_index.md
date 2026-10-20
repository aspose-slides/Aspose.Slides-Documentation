---
title: Převod PPT a PPTX do PDF v Pythonu pomocí Javy [Obsahuje pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/python-java/convert-powerpoint-to-pdf/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převést PPT do PDF
- PPTX do PDF
- převést PPTX do PDF
- uložit PowerPoint jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF v Pythonu pomocí Javy s využitím Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v Pythonu prostřednictvím Javy nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento návod ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti k řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Třída [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), která se obvykle používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Python prostřednictvím Javy vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že neexistuje možnost nasměrovat Aspose.Slides k změně nebo odstranění těchto informací z výstupních dokumentů.
{{% /alert %}}

Aspose.Slides vám umožňuje převádět:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a patičky
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní převod používá výchozí nastavení exportu PDF. Použijte vlastní možnosti, když potřebujete řídit kvalitu obrázků, obsah stránky nebo soulad s PDF standardy.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertorem pro živou ukázku postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), které vám umožňují upravit výsledné PDF, zamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metah soubory, nastavit úroveň komprese pro text, nakonfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s kvalitou JPEG nastavenou na 90, rozlišením obrázku 300 DPI, metah soubory uložené jako PNG a kompresí textu Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Automatický výběr komprese obrázků**

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, snížení velikosti exportovaného PDF může usnadnit jeho odeslání e-mailem nebo stažení. Zavolejte [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) s hodnotou `True`, aby se během exportu PDF automaticky vybral nejvhodnější kompresní algoritmus pro každý obrázek.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechna ostatní nastavení exportu PDF si ponechají výchozí hodnoty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Tato volba vybírá kompresní algoritmus pro každý obrázek. Snížení hodnoty předané metodě [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) místo toho snižuje kvalitu JPEG obrázku, zatímco snížení hodnoty předané metodě [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) umožňuje obrázkům být downsamplovány na nižší rozlišení, což může snížit detail. Povolení automatického výběru komprese samo o sobě nesnižuje žádné z těchto nastavení.

Výběr kompresních algoritmů pro obrázky vyžaduje dodatečný čas zpracování a paměť. Snížení velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevné snížení není zaručeno pro každou prezentaci.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k prohlížení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `True`, aby se vložené OLE soubory zachovaly jako přílohy v výsledném PDF.

Výchozí hodnota je `False`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavení volby na `True` navíc zahrne data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se na stránce PDF nestane interaktivním sešitem Excel.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s připojeným sešitem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Pro kontrolu výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze PDF/A přílohy a PDF/A-3 povoluje další typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF a zahrne všechny skryté snímky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, které vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), která vám umožňuje detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradách písem do konzole. Varování se vypíše jen když je během exportu nahrazen nedostupný font. Použijte JPype proxy k získání zpětných volání varování z Java API. Převeďte řetězec popisu z Javy na řetězec v Pythonu před kontrolou jeho prefixu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Pro více informací o náhradě písem viz článek [Font Substitution](/slides/cs/python-java/font-substitution/).
{{% /alert %}}

### **Zpracování písem bez samostatného tučného řezu**

Prezentace může použít tučné formátování textu i když její písmo nemá samostatný tučný řez. Text může být stále zobrazen tučně pomocí syntetického tučného řezání, které uměle zesiluje běžné glyfy. Pokud tento text vypadá příliš těžce nebo se jinak liší od požadovaného vzhledu v PDF, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) s hodnotou `True`. Tato volba během exportu PDF vykreslí ovlivněný text jako bitmapu a může zlepšit jeho vzhled u některých písem. Výchozí hodnota je `False`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním aplikovaným na stejné písmo, které nemá samostatný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text silnější tahy při vypnuté volbě. Při zapnuté volbě jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnuta (`False`, výchozí) | Volba zapnuta (`True`) |
|---|---|
| ![PDF se zakázanou rasterizací nepodporovaného stylu písma](unsupported-bold-disabled.png) | ![PDF se povolenou rasterizací nepodporovaného stylu písma](unsupported-bold-enabled.png) |

V tomto příkladu povolení volby převádí jen tučný text na bitmapu: nelze jej vybrat, zkopírovat ani vyhledávat jako text bez OCR a jeho hrany se při 800 % zoomu jeví měkče. Běžný text zůstává vyhledatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud jeho písmo nemá samostatný tučný řez. [Font substitution](/slides/cs/python-java/font-substitution/) místo toho vybere jiné písmo, když originál není dostupný.

## **Převod vybraných snímků z PowerPoint do PDF**

Čísla snímků předávaná metodě [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) jsou číslována od jedné. Tento příklad exportuje snímky 1 a 3, pokud oba existují:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Tento příklad exportuje první snímek na stránku o rozměrech 612 × 792 bodů (US Letter). Klonuje snímek do nové prezentace se zadanou velikostí a přepočítá obsah snímku tak, aby se vešel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Odstraňte prázdný snímek, se kterým byla nová prezentace vytvořena.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF tak, že umístí poznámky řečníka každého snímku pod snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standardy přístupnosti a souladu pro PDF**

Při vytváření přístupných PDF se odkazujte na [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Použijte [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) k výběru výstupního standardu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF na základě různých standardů souladu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu převádět více PowerPoint souborů do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné chránit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) s hodnotou `True` ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) a [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, pro přístupnost nebo archivaci. Vyberte vhodný standard a zkontrolujte výstup podle vašich požadavků.

## **Další zdroje**

- [Aspose.Slides pro Python prostřednictvím Java – Dokumentace](/slides/cs/python-java/)
- [Aspose.Slides pro Python prostřednictvím Java – API reference](https://reference.aspose.com/slides/python-java/)
- [Aspose bezplatné online konvertory](https://products.aspose.app/slides/conversion)