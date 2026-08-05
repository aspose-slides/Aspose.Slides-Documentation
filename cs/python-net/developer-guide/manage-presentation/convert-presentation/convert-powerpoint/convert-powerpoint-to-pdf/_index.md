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
  - Aspose.Slides pro Python
description: "Podrobný průvodce převodem PPT, PPTX a ODP na vysoce kvalitní PDF splňující WCAG v Pythonu s Aspose.Slides – zahrnuje ochranu heslem, výběr snímků a řízení kvality obrázků."
showReadingTime: true
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP) do formátu PDF v Pythonu nabízí několik výhod, včetně zajištění kompatibility napříč různými zařízeními a zachování rozložení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, využít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a použít standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v těchto formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF v Pythonu stačí předat název souboru jako argument do třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) a poté uložit prezentaci jako PDF pomocí metody [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods). Třída [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) poskytuje metodu [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods), která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro Python přímo zapisuje informace o API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides pro Python vyplní pole Application hodnotou '*Aspose.Slides*' a pole PDF Producer hodnotou ve formátu '*Aspose.Slides v XX.XX*'. **Poznámka** že nelze Aspose.Slides pro Python instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky v prezentaci do PDF

Aspose.Slides exportuje prezentace do PDF, čímž zajišťuje, že obsah výsledných PDF úzce odpovídá originálním prezentacím. Prvky a atributy jsou v převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní operace převodu PowerPoint do PDF je prováděna s výchozími možnostmi. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálního nastavení na nejvyšší úrovni kvality. Tento Python kód vám ukazuje, jak převést PowerPoint do PDF:

*Steps: PowerPoint to PDF Conversions in Python*

- <a name="python-net-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF using Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Steps: Convert PPT to PDF using Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF using Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert ODP to PDF using Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert PPS to PDF using Python via .NET</strong></a>

**Kroky v kódu:**

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a předávejte jí soubor PowerPoint.
  * Přípona _.ppt_ pro načtení souboru **PPT** do třídy _Presentation_.
  * Přípona _.pptx_ pro načtení souboru **PPTX** do třídy _Presentation_.
  * Přípona _.odp_ pro načtení souboru **ODP** do třídy _Presentation_.
  * Příloha _.pps_ pro načtení souboru **PPS** do třídy _Presentation_.
- Uložte _Presentation_ do formátu **PDF** voláním metody **Save** a použitím výčtu **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Uloží prezentaci jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose poskytuje bezplatný online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Pro živou implementaci popsaného postupu můžete provést test s tímto převodníkem.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit PDF (vytvořené převodovým procesem), zabezpečit PDF heslem nebo dokonce specifikovat, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete nastavit preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, DPI pro obrázky atd.

Níže uvedený příklad kódu demonstruje operaci, při které je PowerPoint prezentace převedena do PDF s několika vlastními možnostmi:

```python
import aspose.slides as slides

# Vytvoří instanci třídy PdfOptions
pdf_options = slides.export.PdfOptions()

# Nastaví kvalitu JPG obrázků
pdf_options.jpeg_quality = 90

# Nastaví DPI pro obrázky
pdf_options.sufficient_resolution = 300

# Nastaví chování metafilek
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

Pokud prezentace obsahuje skryté snímky, můžete použít vlastní možnost — vlastnost `show_hidden_slides` ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — která instruuje Aspose.Slides zahrnout skryté snímky jako stránky ve výsledném PDF.

Tento Python kód vám ukazuje, jak převést PowerPoint prezentaci do PDF se zahrnutými skrytými snímky:

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

Tento Python kód vám ukazuje, jak převést PowerPoint do PDF chráněného heslem (použitím parametrů ochrany ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/)):

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

Tento Python kód vám ukazuje, jak převést konkrétní snímky v PowerPoint prezentaci do PDF:

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

Tento Python kód vám ukazuje, jak převést PowerPoint, jehož velikost snímku je specifikována, do PDF:

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

        # Zklonuje první snímek z originální prezentace.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Uloží změněnou velikost prezentace do PDF s poznámkami.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento Python kód vám ukazuje, jak převést PowerPoint do PDF poznámek:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Uloží prezentaci do PDF poznámek
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Přístupnost a standardy souladu pro PDF**

Aspose.Slides vám umožňuje použít převodní postup, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat PowerPoint dokument do PDF pomocí libovolného z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento Python kód demonstruje operaci převodu PowerPoint do PDF, při které jsou získány různé PDF na základě různých standardů souladu:

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

Podpora Aspose.Slides pro operace převodu PDF se rozšiřuje tak, že umožňuje převádět PDF do nejoblíbenějších formátů souborů. Můžete provést převody [PDF to HTML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-jpg/), a [PDF to PNG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrázkem. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý obrázek.

## **Často kladené otázky**

**Může Aspose.Slides pro Python odstranit informace o aplikaci z PDF?**

Ne, Aspose.Slides pro Python automaticky zahrnuje informace o API a číslo verze do výstupního PDF. Tyto informace nelze upravit ani odstranit.

**Jak zahrnout pouze konkrétní snímky do převodu PDF?**

Můžete specifikovat indexy snímků, které chcete převést, tím, že předáte pole pozic snímků metodě `save`.

**Je možné během převodu PDF nastavit ochranu heslem?**

Ano, můžete nastavit heslo a definovat oprávnění přístupu pomocí třídy `PdfOptions` před uložením prezentace jako PDF.

**Podporuje Aspose.Slides převod PDF do jiných formátů?**

Ano, Aspose.Slides podporuje převod PDF do formátů jako HTML, obrázkové formáty (JPG, PNG), SVG, TIFF a XML.

**Jak zajistit, aby mé PDF splňovalo standardy přístupnosti?**

Nastavte vlastnost `compliance` v `PdfOptions` na standardy jako `PDF_A1A`, `PDF_A1B` nebo `PDF_UA`, aby PDF odpovídalo směrnicím přístupnosti.

**Mohu zahrnout skryté snímky do výstupu PDF?**

Ano, nastavením vlastnosti `show_hidden_slides` v `PdfOptions` na `True` budou skryté snímky zahrnuty do PDF.

**Jak upravit kvalitu a rozlišení obrázků během převodu?**

Použijte vlastnosti `jpeg_quality` a `sufficient_resolution` v `PdfOptions` pro řízení kvality a rozlišení obrázků ve výsledném PDF.

**Zpracovává Aspose.Slides automaticky náhrady písem?**

Aspose.Slides detekuje náhrady písem během převodu a můžete je zpracovat pomocí vlastnosti `warning_callback` v `SaveOptions` (v současnosti omezené).

## **Další zdroje**

- [Aspose.Slides pro .NET Documentation](https://docs.aspose.com/slides/cs/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/cs/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/cs/conversion)