---
title: Převod PPT a PPTX do PDF v Pythonu prostřednictvím Javy [Pokročilé funkce zahrnuty]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Pythonu prostřednictvím Javy pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v Pythonu pomocí Javy nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce fontů, vybrat konkrétní snímky pro převod a použít standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save). Třída [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) vystavuje metodu [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save), která se běžně používá k převodu prezentace do PDF.

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides pro Python prostřednictvím Javy vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF tak, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní převod používá výchozí nastavení exportu PDF. Použijte vlastní možnosti, když potřebujete řídit kvalitu obrázků, obsah stránky nebo soulad PDF.

Nainstalujte [Aspose.Slides for Python via Java](/slides/cs/python-java/installation/) a kompatibilní Java runtime před spuštěním příkladů. Každý příklad načítá `presentation.pptx` z aktuálního pracovního adresáře; nahraďte jej svým souborem PPT, PPTX nebo ODP. JVM spusťte jednou na proces Pythonu.

Tento kód převádí prezentaci do PDF:

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

{{% alert color="info" title="Poznámka" %}}
Aspose nabízí zdarma online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete si vyzkoušet tento konvertor pro živou implementaci postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti – vlastnosti pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) – které vám umožní přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastním nastavením**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak se mají zacházet s metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Níže uvedený ukázkový kód demonstruje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Detekce substitucí fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setWarningCallback) pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/), která vám umožní detekovat substituce fontů během procesu převodu prezentace do PDF.

Použijte JPype proxy k přijímání varování z Java API. Převěďte řetězec popisu Java na řetězec Python před kontrolou jeho předpony:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Poznámka" %}}
Pro více informací o přijímání zpětných volání pro substituce fontů během procesu renderování, viz [Getting Warning Callbacks for Fonts Substitution](/slides/cs/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o substituci fontů si přečtěte článek [Font Substitution](/slides/cs/python-java/font-substitution/).
{{% /alert %}}

## **Převod vybraných snímků v PowerPointu do PDF**

Čísla snímků předávaná metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) jsou 1‑based. Tento příklad exportuje snímky 1 a 3, pokud oba existují:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento příklad exportuje první snímek na stránce o rozměrech 612 × 792 bodů (US Letter). Zkopíruje snímek do nové prezentace se zadaným rozměrem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standardy přístupnosti a souladu pro PDF**

Při tvorbě přístupných PDF se řiďte [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Pomocí [PdfOptions.setCompliance](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setCompliance) můžete vybrat výstupní standard: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF podle různých standardů souladu:

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

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrázkem. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý obrázek.

## **Často kladené otázky**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, kvalitu obrázků můžete řídit metodami jako [setJpegQuality](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setJpegQuality) a [setSufficientResolution](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/), aby byly ve vašem PDF zachovány obrázky ve vysoké kvalitě.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, které vyhovují [různým standardům](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, pro přístupnost nebo archivaci. Vyberte vhodný standard a zkontrolujte výstup podle vašich požadavků.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Python prostřednictvím Javy](/slides/cs/python-java/)
- [API reference Aspose.Slides pro Python prostřednictvím Javy](https://reference.aspose.com/slides/cs/python-java/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/cs/conversion)