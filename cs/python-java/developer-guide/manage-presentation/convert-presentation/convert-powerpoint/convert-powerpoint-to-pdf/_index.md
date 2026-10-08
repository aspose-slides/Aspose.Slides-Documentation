---
title: Převod PPT a PPTX do PDF v Pythonu přes Java [Zahrnuty pokročilé funkce]
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
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Pythonu přes Java pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v Pythonu přes Java nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převádět prezentace do PDF dokumentů, používat různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Prezentace](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody [uložit](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Třída [Prezentace](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) poskytuje metodu [uložit](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java vkládá informace o své API a verzi do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve tvaru "*Aspose.Slides v XX.XX*". **Poznámka**: nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnilo nebo odstranilo.

{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF tak, aby výsledná PDF úzce odpovídala původním prezentacím. Prvky a vlastnosti jsou během převodu vykresleny přesně, včetně:

* Obrázky
* Textové rámečky a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní převod používá výchozí nastavení exportu PDF. Použijte vlastní možnosti, když potřebujete řídit kvalitu obrázků, obsah stránky nebo soulad PDF.

Nainstalujte [Aspose.Slides for Python via Java](/slides/cs/python-java/installation/) a kompatibilní běhové prostředí Java před spuštěním příkladů. Každý příklad načítá `presentation.pptx` z aktuálního pracovního adresáře; nahraďte jej svým souborem PPT, PPTX nebo ODP. JVM spustíte jednou na jeden proces Pythonu.

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

Aspose nabízí zdarma online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Tento konvertor můžete použít k testování živé implementace popsaného postupu.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti třídy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastru obrázků, určit, jak se mají zacházet s metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s nastavenou JPEG kvalitou 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

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

### **Zachování vložených OLE souborů jako příloh PDF**

Pokud prezentace obsahuje vložený Excel sešit, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `True` a zachováte vložené OLE soubory jako přílohy ve výsledném PDF.

Výchozí hodnota je `False`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale vložený soubor není zahrnut jako příloha. Nastavení na `True` navíc zahrne i data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nestane interaktivním listem Excelu na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený Excel sešit, a exportuje ji do PDF s přiloženým sešitem.

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

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, např. Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}

Standardy PDF/A ukládají omezení na přílohy: PDF/A‑1 zakazuje vložené soubory, PDF/A‑2 povoluje pouze přílohy PDF/A a PDF/A‑3 povoluje i jiné typy souborů, včetně Excel sešitů. Jedná se o požadavky standardů, ne omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.

{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) a zahrnout skryté snímky jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

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

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku vysoké kvality.

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

### **Detekce substitucí písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), která vám umožní detekovat substituce písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypisuje varování o substituci písem do konzole. Varování se vypíše pouze tehdy, když je během exportu použito nedostupné písmo. Použijte proxy JPype pro příjem varování z Java API. Před kontrolou prefixu převeďte popis řetězce z Java na Python řetězec:

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

Více informací o substituci písem najdete v článku [Substituce písem](/slides/cs/python-java/font-substitution/).

{{% /alert %}}

### **Zpracování písem bez dedikovaného tučného řezu**

Prezentace může použít tučné formátování textu, i když dané písmo nemá vlastní tučný řez. Text se může i tak jevit tučně díky syntetickému ztučnění, které uměle zahušťuje běžné glyphy. Když takový text v PDF vypadá příliš těžko nebo jinak neodpovídá zamýšlenému vzhledu, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) s hodnotou `True`. Tato volba při exportu PDF vykreslí postižený text jako bitmapu a může zlepšit jeho vzhled u některých písem. Výchozí hodnota je `False`.

Ukázková prezentace obsahuje dva textové rámečky: jeden s běžným textem a druhý s tučným formátováním stejného písma, které nemá dedikovaný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. Po zapnutí jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky před tím, než si zvolíte nastavení pro svou prezentaci.

| Volba vypnuta (`False`, výchozí) | Volba zapnuta (`True`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí volby převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a hrany se při 800 % přiblížení jeví měkčeji. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud písmo nemá vlastní tučný řez. [Substituce písem](/slides/cs/python-java/font-substitution/) místo toho vybere jiné písmo, když originál není k dispozici.

## **Převod vybraných snímků z PowerPoint do PDF**

Čísla snímků předávaná metodě [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) jsou 1‑základní. Tento příklad exportuje snímky 1 a 3, pokud oba existují:

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

Tento příklad exportuje první snímek na stránku o rozměrech 612 × 792 bodů (US Letter). Klonuje snímek do nové prezentace se zadanou velikostí a škáluje obsah snímku, aby se vešel.

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

Následující příklad exportuje prezentaci do PDF a umístí poznámky přednášejícího pod každý snímek. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

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

## **Přístupnost a standardy souladu pro PDF**

Při tvorbě přístupných PDF konzultujte [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Pomocí [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) vyberte výstupní standard: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF podle různých standardů souladu:

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

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází se složitou grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené dotazy**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné zabezpečit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) s hodnotou `True` ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) a zahrňte skryté snímky do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, kvalitu obrázků můžete řídit pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) a [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ve třídě [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, pro přístupnost nebo archivaci. Vyberte vhodný standard a zkontrolujte výstup podle svých požadavků.

## **Další zdroje**

- [Aspose.Slides for Python via Java Dokumentace](/slides/cs/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)