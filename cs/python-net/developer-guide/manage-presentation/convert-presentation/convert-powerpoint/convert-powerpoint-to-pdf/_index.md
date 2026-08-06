---
title: Převod PPT a PPTX do PDF v Pythonu | Pokročilé možnosti
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - převod PowerPoint
  - prezentace
  - PowerPoint do PDF
  - PPT do PDF
  - PPTX do PDF
  - uložit PowerPoint jako PDF
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Podrobný návod na převod PPT, PPTX a ODP do vysoce kvalitních PDF splňujících standard WCAG v Pythonu s Aspose.Slides – zahrnuje ochranu heslem, výběr snímků a řízení kvality obrázků."
showReadingTime: true
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP) do formátu PDF v Pythonu nabízí několik výhod, včetně zajištění kompatibility napříč různými zařízeními a zachování rozložení a formátování vaší prezentace. Tento průvodce ukazuje, jak převádět prezentace do PDF dokumentů, využívat různé možnosti pro řízení kvality obrázků, zahrnovat skryté snímky, chránit PDF heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Instalace**

```bash
pip install aspose.slides
```

Balíček obsahuje potřebné runtime, takže Microsoft PowerPoint nemusí být nainstalován na počítači provádějícím převod.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v těchto formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF v Pythonu stačí předat název souboru jako argument třídě [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) a poté uložit prezentaci jako PDF pomocí metody [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods). Třída [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) poskytuje metodu [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods), která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Python přímo zapisuje informace o API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides for Python vyplní pole Application hodnotou '*Aspose.Slides*' a pole PDF Producer hodnotou ve formátu '*Aspose.Slides v XX.XX*'. **Poznámka** že nemůžete Aspose.Slides for Python instruovat, aby tuto informaci ve výstupních dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky v prezentaci do PDF

Aspose.Slides exportuje prezentace do PDF, zajišťuje, že obsah výsledných PDF úzce odpovídá původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a patičky
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní operace převodu PowerPoint do PDF se provádí pomocí výchozích možností. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF s optimálním nastavením a maximální kvalitou. Tento Python kód vám ukáže, jak převést PowerPoint do PDF:

_Kroky: Převody PowerPoint do PDF v Pythonu_

Následující ukázkový kód vysvětluje tyto převody pomocí Pythonu přes .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Kroky: Převod PowerPoint do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Kroky: Převod PPT do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Kroky: Převod PPTX do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Kroky: Převod ODP do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Kroky: Převod PPS do PDF pomocí Pythonu přes .NET</strong></a>

_Kroky kódu:_

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a poskytněte jí soubor PowerPoint.
  * _.ppt_ přípona pro načtení souboru **PPT** ve třídě _Presentation_.
  * _.pptx_ přípona pro načtení souboru **PPTX** ve třídě _Presentation_.
  * _.odp_ přípona pro načtení souboru **ODP** ve třídě _Presentation_.
  * _.pps_ přípona pro načtení souboru **PPS** ve třídě _Presentation_.
- Uložte _Presentation_ do formátu **PDF** voláním metody **Save** a použitím výčtu **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Uloží prezentaci jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 
Aspose poskytuje bezplatný online [**Převodník PowerPoint do PDF**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Pro živou implementaci popsaného postupu můžete provést test s tímto převodníkem.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit PDF (vzniklé během převodu), zamknout PDF heslem nebo dokonce určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete nastavit preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, nastavit DPI pro obrázky atd.

Níže uvedený příklad kódu ukazuje operaci, při které je PowerPoint prezentace převedena do PDF s několika vlastními možnostmi:

```python
import aspose.slides as slides

# Vytvoří instanci třídy PdfOptions
pdf_options = slides.export.PdfOptions()

# Nastaví kvalitu pro JPG obrázky
pdf_options.jpeg_quality = 90

# Nastaví DPI pro obrázky
pdf_options.sufficient_resolution = 300

# Nastaví chování pro metafily
pdf_options.save_metafiles_as_png = True

# Nastaví úroveň komprese textu pro textový obsah
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definuje režim souladu PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Vytvoří instanci třídy Presentation, která představuje dokument PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Uloží prezentaci jako PDF dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastní možnost — vlastnost `show_hidden_slides` ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — která Aspose.Slides instruuje, aby zahrnula skryté snímky jako stránky ve výsledném PDF.

Tento Python kód vám ukáže, jak převést PowerPoint prezentaci do PDF se zahrnutými skrytými snímky:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Vytvoří instanci třídy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Přidá skryté snímky
pdfOptions.show_hidden_slides = True

# Uloží prezentaci jako PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento Python kód vám ukáže, jak převést PowerPoint do PDF chráněného heslem (použitím parametrů ochrany ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Vytvoří objekt Presentation, který představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Vytvoří instanci třídy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Nastaví heslo PDF a přístupová oprávnění
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Uloží prezentaci jako PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Převod vybraných snímků v PowerPoint do PDF**

Tento Python kód vám ukáže, jak převést konkrétní snímky v PowerPoint prezentaci do PDF:

```python
import aspose.slides as slides

# Vytvoří objekt Presentation, který představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Nastaví pole pozic snímků
slides_array = [ 1, 3 ]

# Uloží prezentaci jako PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento Python kód vám ukáže, jak převést PowerPoint, když je jeho rozměr snímku specifikován, do PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Vytvoří novou prezentaci s upravenou velikostí snímku.
    with slides.Presentation() as resized_presentation:

        # Nastaví vlastní velikost snímku.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Naklonuje první snímek z původní prezentace a odstraní výchozí prázdný snímek.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Uloží upravenou prezentaci jako PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento Python kód vám ukáže, jak převést PowerPoint do PDF s poznámkami:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Nakonfiguruje PDF možnosti s rozvržením poznámek
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Uloží prezentaci jako PDF s poznámkami
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento Python kód demonstruje operaci převodu PowerPoint do PDF, při které jsou získány různé PDF založené na různých standardech souladu:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 
Můžete provést [PDF na HTML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-jpg/), a [PDF na PNG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-png/) převody. Další převody PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-tiff/), a [PDF na XML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrázkem. Jednotlivé elementy cest nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý obrázek.

## **Často kladené otázky**

### Může Aspose.Slides for Python odstranit informace o aplikaci z PDF?

Ne, Aspose.Slides for Python automaticky zahrnuje informace o API a číslo verze do výstupního PDF. Tyto informace nelze upravit ani odstranit.

### Jak mohu zahrnout pouze konkrétní snímky při převodu PDF?

Můžete určit indexy snímků, které chcete převést, tím, že předáte pole pozic snímků metodě `save`.

### Je možné během převodu PDF nastavit heslo?

Ano, můžete nastavit heslo a definovat přístupová oprávnění pomocí třídy `PdfOptions` před uložením prezentace jako PDF.

### Podporuje Aspose.Slides převod PDF do jiných formátů?

Ano, Aspose.Slides podporuje převod PDF do formátů jako HTML, obrazové formáty (JPG, PNG), SVG, TIFF a XML.

### Jak mohu zajistit, že moje PDF splňuje standardy přístupnosti?

Nastavte vlastnost `compliance` v `PdfOptions` na standardy jako `PDF_A1A`, `PDF_A1B` nebo `PDF_UA`, aby PDF odpovídalo směrnicím přístupnosti.

### Mohu zahrnout skryté snímky do výstupu PDF?

Ano, nastavením vlastnosti `show_hidden_slides` v `PdfOptions` na `True` budou skryté snímky zahrnuty do PDF.

### Jak mohu během převodu upravit kvalitu a rozlišení obrázků?

Použijte vlastnosti `jpeg_quality` a `sufficient_resolution` v `PdfOptions` pro řízení kvality a rozlišení obrázků ve výsledném PDF.

### Zpracovává Aspose.Slides náhrady písem automaticky?

Aspose.Slides detekuje náhrady písem během převodu a můžete s nimi pracovat pomocí vlastnosti `warning_callback` v `SaveOptions` (aktuálně omezené).

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](https://docs.aspose.com/slides/cs/python-net/)
- [Reference API Aspose.Slides](https://reference.aspose.com/slides/cs/python-net/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/cs/conversion)