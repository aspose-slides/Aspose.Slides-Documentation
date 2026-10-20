---
title: Převod PPT a PPTX do PDF v Pythonu | Pokročilé možnosti
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- převést PowerPoint
- prezentace
- PowerPoint do PDF
- PPT do PDF
- PPTX do PDF
- uložit PowerPoint jako PDF
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Průvodce krok za krokem převodem PPT, PPTX a ODP na vysoce kvalitní, WCAG-kompatibilní PDF v Pythonu s Aspose.Slides — zahrnuje ochranu heslem, výběr snímků a kontrolu kvality obrázků."
showReadingTime: true
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP) do formátu PDF v Pythonu nabízí několik výhod, včetně zajištění kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento návod ukazuje, jak převést prezentace do PDF dokumentů, využít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF dokumenty heslem, detekovat nahrazení písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v těchto formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF v Pythonu stačí předat název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a poté uložit prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), která se obvykle používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Python vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides pro Python vyplní pole Application hodnotou '*Aspose.Slides*' a pole PDF Producer hodnotou ve formátu '*Aspose.Slides v XX.XX*'. **Poznámka** že nemůžete Aspose.Slides pro Python instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* Konkrétní snímky v prezentaci do PDF

Aspose.Slides exportuje prezentace do PDF, přičemž zajišťuje, že obsah výsledných PDF úzce odpovídá původním prezentacím. Prvky a atributy jsou při převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálních nastavení při maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozích nastavení exportu.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose poskytuje bezplatný online [**Převodník PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Pro živou implementaci postupu popsaného zde můžete provést test pomocí převodníku.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — které vám umožňují přizpůsobit PDF (vytvořené v průběhu převodu), uzamknout PDF heslem nebo dokonce určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete nastavit preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese pro text, nastavit DPI pro obrázky atd.

Následující příklad exportuje prezentaci do PDF 1.5 s nastavenou kvalitou JPEG na 90, rozlišením obrázku na 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Automatický výběr komprese obrázků**

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, zmenšení velikosti exportovaného PDF může usnadnit jeho odeslání e‑mailem nebo stažení. Nastavte [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) na `True`, aby se během exportu PDF automaticky vybral nejvhodnější kompresní algoritmus pro každý obrázek.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechna ostatní nastavení exportu PDF si zachovají své výchozí hodnoty.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Tato možnost vybere kompresní algoritmus pro každý obrázek. Snížení [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) spíše snižuje kvalitu JPEG obrázku, zatímco snížení [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) umožní obrázkům být downsampleovány na nižší rozlišení, což může zmenšit detail. Povolení automatického výběru komprese samo o sobě nesnižuje žádné z těchto nastavení.

Výběr kompresních algoritmů pro obrázky vyžaduje další čas zpracování a paměť. Snížení velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevné zmenšení není u každé prezentace zaručeno.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i prohlížet snímky. Nastavte [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) na `True`, aby se vložené OLE soubory zachovaly jako přílohy v vzniklém PDF.

Výchozí hodnota je `False`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením volby na `True` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se na stránce PDF nestane interaktivním listem Excelu.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excelu, a exportuje ji do PDF s připojeným sešitem.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Pro kontrolu výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excelu. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastní možnost — vlastnost [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — která Aspose.Slides instruuje zahrnout skryté snímky jako stránky v vzniklém PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` k otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Zpracování písem bez samostatného tučného řezu**

Prezentace může použít tučné formátování textu, i když má písmo žádný samostatný tučný řez. Text může i tak vypadat tučně díky syntetickému tučení, které uměle zahušťuje běžné glyfy. Pokud text vypadá příliš tučně nebo se liší od zamýšleného vzhledu v PDF, zkuste nastavit [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) na `True`. Tato volba při exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled u některých písem. Výchozí hodnota je `False`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a jedno s aplikovaným tučným formátováním na stejné písmo, které nemá samostatný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písem a exportuje ji do PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text s vypnutou volbou silnější tahy. S zapnutou volbou jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky, než si vyberete nastavení pro svou prezentaci.

| Volba vypnuta (`False`, výchozí) | Volba zapnuta (`True`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí volby převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany vypadají měkčeji při 800 % zvětšení. Běžný text zůstává vyhledávatelný. S vypnutou volbou zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud jeho písmo nemá samostatný tučný řez. [Náhrada písem](/slides/cs/python-net/font-substitution/) místo toho vybere jiné písmo, když původní není dostupné.

## **Převod vybraných snímků v PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou číslována od jedné a vstupní prezentace musí obsahovat alespoň tři snímky.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Odstraňte prázdný snímek, který byl vytvořen novou prezentací.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Převod PowerPoint do PDF v zobrazení poznámkových snímků**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka každého snímku pod snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Pokyny pro přístupnost webového obsahu (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí kterýchkoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Ukázkový Python kód demonstruje operaci převodu PowerPoint do PDF, při níž jsou získány různé PDF založené na různých standardech souladu:

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

{{% alert color="info" title="Note" %}}
Podpora Aspose.Slides pro operace převodu PDF vám umožňuje převést PDF do nejoblíbenějších formátů souborů. Můžete provést [PDF do HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) převody. Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou jako jsou SmartArt, grafy a vzorce jako s jedním objektem. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý objekt.

## **Často kladené otázky**

**Může Aspose.Slides pro Python odstranit informace o aplikaci z PDF?**

Ne, Aspose.Slides pro Python automaticky zahrnuje informace o API a číslo verze do výstupního PDF. Tyto informace nelze upravit ani odstranit.

**Jak zahrnout pouze konkrétní snímky do převodu PDF?**

Můžete určit indexy snímků, které chcete převést, tím, že předáte pole pozic snímků metodě [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Je možné během převodu PDF chránit heslem?**

Ano, můžete nastavit heslo a definovat přístupová oprávnění pomocí třídy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) před uložením prezentace jako PDF.

**Podporuje Aspose.Slides převod PDF do jiných formátů?**

Ano, Aspose.Slides podporuje převod PDF do formátů jako HTML, formáty obrázků (JPG, PNG), SVG, TIFF a XML.

**Jak mohu zajistit, aby mé PDF splňovalo standardy přístupnosti?**

Nastavte vlastnost [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) ve [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na standardy jako `PDF_A1A`, `PDF_A1B` nebo `PDF_UA`, aby bylo zajištěno splnění pokynů pro přístupnost.

**Mohu zahrnout skryté snímky do výstupního PDF?**

Ano, nastavením vlastnosti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ve [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na `True` budou skryté snímky zahrnuty do PDF.

**Jak upravit kvalitu a rozlišení obrázků během převodu?**

Použijte vlastnosti [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) a [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) ve [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), abyste řídili kvalitu a rozlišení obrázků ve výsledném PDF.

**Zpracovává Aspose.Slides automaticky náhrady písem?**

Aspose.Slides detekuje náhrady písem během převodu a můžete je zpracovat pomocí vlastnosti `warning_callback` v `SaveOptions` (v současnosti omezené).

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Python přes .NET](/slides/cs/python-net/)
- [Reference API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/conversion)