---
title: Změna velikosti a orientace stránky s poznámkami v Pythonu
linktitle: Velikost stránky s poznámkami
type: docs
weight: 10
url: /cs/python-net/notes-size/
keywords:
- velikost stránky s poznámkami
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladu
- PowerPoint
- prezentace
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Přečtěte a změňte rozměry stránky s poznámkami v Aspose.Slides pro Python přes .NET, přepněte orientaci, ověřte uložené velikosti a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.notes_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/notes_size/) k přístupu k nastavení stránky s poznámkami prezentace. Vrací objekt [NotesSize](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notessize/), jehož vlastnost [size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notessize/size/) je zapisovatelná. Ačkoli je samotný objekt nastavení jen pro čtení, můžete přiřadit nové rozměry jeho vlastnosti size.

Šířka a výška jsou zadány v **bodech**, přičemž 72 bodů odpovídá jednomu palci. Například 900 × 600 bodů je 12,5 × 8⅓ palce. Tato nastavení se vztahují k celé prezentaci, nikoli k poznámkám jednotlivých snímků.

| Nastavení | Účel |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/notes_size/) | Řídí rozměry stránky s poznámkami a rozměry stránky používané pro export podkladů. |
| [Presentation.slide_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slide_size/) | Řídí rozměry běžných snímků prezentace pomocí [SlideSize](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/). |

Změna jednoho nastavení automaticky nemění druhé. Změna orientace stránky s poznámkami také neotočí běžné snímky. Viz [Slide Size](/slides/cs/python-net/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky k řečníkovi. Každý příklad lze spustit nezávisle.

## **Přečíst velikost a orientaci stránky s poznámkami**

Přečtěte šířku a výšku a porovnejte je, abyste určili orientaci: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vypisuje skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Přepnout na šířku bez změny velikosti papíru**

Pro změnu pouze orientace prohoďte stávající šířku a výšku. Tím se zachová délka obou stran, včetně těch u vlastní velikosti papíru. Níže uvedená podmínka zabraňuje přepnutí již orientované stránky na šířku zpět na výšku a ponechává čtvercovou stránku nezměněnou.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Pro orientaci na výšku použijte stejné přiřazení, když `size.width > size.height`. Nezáměňujte rozměry A4 nebo Letter, pokud zároveň nechcete změnit velikost papíru.

## **Nastavit a ověřit vlastní velikost stránky s poznámkami**

Přiřaďte oba rozměry najednou a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k uložení prezentace. Tento příklad nastaví stránku na šířku s rozměry 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor pro kontrolu zachovaných hodnot. Porovnání povoluje toleranci 0,01 bodu pro hodnoty s plovoucí řádovou čárkou; není to záruka přesnosti pro každý formát souboru.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Očekávaný výsledek je `900 x 600 points` a `Size preserved: True`. Kontrola nově otevřené prezentace ověřuje uložený soubor, nikoli pouze nastavení v paměti.

## **Exportovat poznámky a podklady**

Rozměry stránky definují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě těchto rozvržení neaktivují: je třeba také nastavit možnosti exportu. Export běžných snímků i nadále používá rozměry snímku.

### **Exportovat poznámky do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) k [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/slides_layout_options/), aby se poznámky zahrnuly do PDF. Tento příklad také vykreslí první snímek s poznámkami do PNG pomocí [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/) a [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/).

Režim [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notespositions/) uchovává poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky o velikosti 900 × 600 bodů. Při měřítku obrázku 1 × 1 použitém níže je PNG 900 × 600 pixelů. Body popisují geometrickou strukturu stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Pro export PDF s dlouhými poznámkami [BOTTOM_FULL](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notespositions/) povoluje podle potřeby další stránky. Tento režim nepoužívejte s voláním pro obrázek jednoho snímku výše, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů notes-master; změna rozměrů stránky samotná by neměla být považována za záruku, že veškerý obsah se vejde. Viz [Convert PowerPoint to PDF with Notes](/slides/cs/python-net/convert-powerpoint-to-pdf-with-notes/) pro více informací o exportu poznámek.

### **Exportovat podklady do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku o velikosti 900 × 600 bodů a používá [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handouttype/) k uspořádání až čtyř snímků na stránce. Horizontální předvolba řídí pořadí snímků; orientace stránky vychází z její šířky a výšky.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by se změnily rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation.get_images](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/) s rozvržením podkladů, namísto metody obrázku jednotlivého snímku. V Aspose.Slides se rendering podkladů na úrovni prezentace používá rozměry stránky s poznámkami, zatímco volání pro obrázek jednotlivého snímku nevytváří stránku podkladu. Viz [Handout Mode](/slides/cs/python-net/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky v prohlížečích, exportu a tisku**

Uchovávejte odlišné uloženou velikost prezentace, velikost exportované stránky a velikost tištěného papíru:

- **Presentation viewers:** Prohlížeč může zobrazovat nebo tisknout poznámky podle vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, otevřete jej znovu a zkontrolujte rozměry; konverze formátu v této aplikaci je může normalizovat.
- **Export formats:** Výše uvedené příklady PDF pro poznámky a podklady používají nastavené rozměry stránky. Rastrové obrázky používají celočíselné rozměry pixelů a měřítko vykreslování, takže zlomkové hodnoty bodů mohou být v obrázkovém výstupu zaokrouhleny. Export běžných snímků nepoužívá velikost stránky s poznámkami.
- **Printer drivers:** Volba papíru, automatické otáčení a nastavení přizpůsobení velikosti stránky mohou změnit fyzický výstup, aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru sladťe nastavení tiskárny a zkontrolujte náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek jen pro jeden snímek?**

Velikost stránky s poznámkami je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít odlišný obsah poznámek, ale tato vlastnost neposkytuje samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila mé snímky?**

Stránky s poznámkami a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve otevřete uloženou prezentaci znovu a porovnejte její rozměry poznámek. Pokud se změnily, zkontrolujte, zda ukládání nebo konverze souboru v jiné aplikaci neovlivnila nastavení stránky. Pokud ne, prověřte rozvržení exportu, měřítko obrazu, nastavení prohlížeče a volbu papíru tiskárny.