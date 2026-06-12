---
title: Převod PPT a PPTX do PDF v Pythonu | Pokročilé možnosti
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/python-net/convert-powerpoint-to-pdf/
keywords:
- převést PowerPoint
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
description: "Podrobný průvodce převodem PPT, PPTX a ODP na vysoce kvalitní PDF splňující WCAG v Pythonu s Aspose.Slides — zahrnuje ochranu heslem, výběr snímků a kontrolu kvality obrázků."
showReadingTime: true
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP) do formátu PDF v Pythonu nabízí několik výhod, včetně zajištění kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, využít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF dokumenty heslem, detekovat náhrady fontů, vybrat konkrétní snímky pro převod a použít normy pro soulad výstupních dokumentů.

## **Převody PowerPoint na PDF**

Pomocí Aspose.Slides můžete převést prezentace v těchto formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete‑li převést prezentaci do PDF v Pythonu, stačí předat název souboru jako argument ve třídě [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) a poté prezentaci uložit jako PDF pomocí metody [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods). Třída [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) poskytuje metodu [Save](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/#methods), která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro Python přímo zapisuje informace o API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides pro Python vyplní pole Application hodnotou '*Aspose.Slides*' a pole PDF Producer hodnotou ve formátu '*Aspose.Slides v XX.XX*'. **Poznámka** že nemůžete Aspose.Slides pro Python instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky v prezentaci do PDF

Aspose.Slides exportuje prezentace do PDF, což zajišťuje, že obsah výsledných PDF úzce odpovídá původním prezentacím. Prvky a atributy jsou během převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní operace převodu PowerPoint do PDF je prováděna s výchozími možnostmi. V tomto případě se Aspose.Slides pokusí převést poskytnutou prezentaci do PDF s optimálním nastavením při maximální úrovni kvality. Tento Python kód vám ukazuje, jak převést PowerPoint do PDF:

_*Kroky: Převody PowerPoint na PDF v Pythonu*_

Následující ukázkový kód vysvětluje tyto převody pomocí Pythonu přes .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Kroky: Převod PowerPoint do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Kroky: Převod PPT do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Kroky: Převod PPTX do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Kroky: Převod ODP do PDF pomocí Pythonu přes .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Kroky: Převod PPS do PDF pomocí Pythonu přes .NET</strong></a>

_Kroky kódu:_

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a poskytněte jí soubor PowerPoint.
  * Rozšíření _.ppt_ pro načtení souboru **PPT** ve třídě _Presentation_.
  * Rozšíření _.pptx_ pro načtení souboru **PPTX** ve třídě _Presentation_.
  * Rozšíření _.odp_ pro načtení souboru **ODP** ve třídě _Presentation_.
  * Rozšíření _.pps_ pro načtení souboru **PPS** ve třídě _Presentation_.
- Uložte _Presentation_ do formátu **PDF** voláním metody **Save** a použitím výčtu **SaveFormat.PDF**.
  

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Uloží prezentaci jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose poskytuje bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Pro živou implementaci popsaného postupu můžete vyzkoušet převodník.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit PDF (vytvořené během převodu), uzamknout PDF heslem nebo dokonce určit, jak má probíhat proces převodu.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete nastavit preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, DPI pro obrázky atd. 

Ukázkový kód níže demonstruje operaci, při níž je prezentace PowerPoint převedena do PDF s několika vlastními možnostmi:

```python
import aspose.slides as slides

# Vytvoří instanci třídy PdfOptions
pdf_options = slides.export.PdfOptions()

# Nastaví kvalitu pro JPG obrázky
pdf_options.jpeg_quality = 90

# Nastaví DPI pro obrázky
pdf_options.sufficient_resolution = 300

# Nastaví chování metafilů
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

Pokud prezentace obsahuje skryté snímky, můžete použít vlastní možnost — vlastnost `show_hidden_slides` ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/) — která instruuje Aspose.Slides zahrnout skryté snímky jako stránky do výsledného PDF.

Tento Python kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

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

Tento Python kód ukazuje, jak převést PowerPoint do PDF chráněného heslem (pomocí parametrů ochrany ze třídy [PdfOptions](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Vytvoří objekt Presentation, který představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Vytvoří instanci třídy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Nastaví heslo PDF a oprávnění k přístupu
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Uloží prezentaci jako PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Převod vybraných snímků v PowerPointu do PDF**

Tento Python kód ukazuje, jak převést konkrétní snímky v prezentaci PowerPoint do PDF:

```python
import aspose.slides as slides

# Vytvoří objekt Presentation, který představuje soubor PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Nastaví pole pozic snímků
slides_array = [ 1, 3 ]

# Uloží prezentaci jako PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Tento Python kód ukazuje, jak převést PowerPoint, jehož velikost snímku je nastavena, do PDF:

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

        # Klonuje první snímek z původní prezentace.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Uloží prezentaci s upravenou velikostí do PDF s poznámkami.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento Python kód ukazuje, jak převést PowerPoint do PDF s poznámkami:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Uloží prezentaci do PDF poznámek
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Přístupnost a normy souladnosti pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který vyhovuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některé z těchto norem souladnosti: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento Python kód demonstruje operaci převodu PowerPoint do PDF, při níž jsou získány více PDF na základě různých norem souladnosti:

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

Aspose.Slides podpora pro operace převodu PDF rozšiřuje možnost převádět PDF do nejpopulárnějších formátů souborů. Můžete provést převody [PDF na HTML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-jpg/), a [PDF na PNG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-png/) . Ostatní převody PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-tiff/), a [PDF na XML](https://products.aspose.com/slides/cs/python-net/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou jako jsou SmartArt, grafy a vzorce jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Může Aspose.Slides pro Python odstranit informace o aplikaci z PDF?**

Ne, Aspose.Slides pro Python automaticky zahrnuje informace o API a číslo verze do výstupního PDF. Tyto informace nelze upravit ani odstranit.

**Jak zahrnout pouze konkrétní snímky do převodu PDF?**

Můžete specifikovat indexy snímků, které chcete převést, tím že předáte pole pozic snímků metodě `save`.

**Je možné během převodu PDF chránit heslem?**

Ano, můžete nastavit heslo a definovat přístupová oprávnění pomocí třídy `PdfOptions` před uložením prezentace jako PDF.

**Podporuje Aspose.Slides převod PDF do jiných formátů?**

Ano, Aspose.Slides podporuje převod PDF do formátů jako HTML, obrazových formátů (JPG, PNG), SVG, TIFF a XML.

**Jak zajistím, aby moje PDF splňovalo standardy přístupnosti?**

Nastavte vlastnost `compliance` v `PdfOptions` na standardy jako `PDF_A1A`, `PDF_A1B` nebo `PDF_UA`, aby bylo zajištěno splnění směrnic přístupnosti.

**Mohu zahrnout skryté snímky do výstupu PDF?**

Ano, nastavením vlastnosti `show_hidden_slides` v `PdfOptions` na `True` budou skryté snímky zahrnuty do PDF.

**Jak během převodu nastavit kvalitu a rozlišení obrázků?**

Použijte vlastnosti `jpeg_quality` a `sufficient_resolution` v `PdfOptions` pro řízení kvality a rozlišení obrázků ve výsledném PDF.

**Zvládá Aspose.Slides automaticky náhrady fontů?**

Aspose.Slides detekuje náhrady fontů během převodu a můžete je zpracovat pomocí vlastnosti `warning_callback` ve `SaveOptions` (v současné době omezené).

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](https://docs.aspose.com/slides/cs/python-net/)
- [Reference API Aspose.Slides](https://reference.aspose.com/slides/cs/python-net/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/cs/conversion)