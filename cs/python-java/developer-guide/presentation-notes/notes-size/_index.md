---
title: Změna velikosti a orientace stránky poznámek v Pythonu přes Java
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/python-java/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost letáku
- PowerPoint
- prezentace
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Čtěte a měňte rozměry stránky poznámek v Aspose.Slides pro Python přes Java, změňte orientaci, ověřte uložené velikosti a exportujte poznámky nebo letáky do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getNotesSize) k získání nastavení stránky poznámek prezentace. Vrací objekt [NotesSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notessize/) , jehož metoda [setSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notessize/#setSize) nastavuje rozměry stránky. I když nelze objekt nastavení nahradit, můžete pomocí této metody přiřadit nové rozměry.

Šířka a výška jsou uváděny v **bodech**, přičemž 1 palec = 72 bodů. Například 900 × 600 bodů je 12,5 × 8⅓ palce. Tato nastavení se vztahují na celou prezentaci, nikoli na poznámky jednotlivých snímků.

| Nastavení | Účel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getNotesSize) | Řídí rozměry stránky poznámek a rozměry stránky použité při exportu letáků. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideSize) | Řídí rozměry běžných snímků prezentace prostřednictvím [SlideSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/). |

Změna jednoho nastavení automaticky nemění druhé. Změna orientace stránky poznámek také neotáčí běžné snímky. Viz [Slide Size](/slides/cs/python-java/slide-size/) pro změnu rozměrů běžných snímků.

Příklady níže používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky pro přednášejícího. Každý příklad může být spuštěn samostatně.

## **Přečíst velikost a orientaci stránky poznámek**

Přečtěte šířku a výšku a porovnejte je pro určení orientace: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vytiskne skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Přepnout na šířku bez změny velikosti papíru**

Pro změnu pouze orientace vyměňte stávající šířku a výšku. Tím se zachová délka obou stran, včetně těch u vlastní velikosti papíru. Podmínka níže zabraňuje převrácení již na šířku nastavené stránky zpět na výšku a ponechává čtvercovou stránku beze změny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro orientaci na výšku použijte stejný přiřazení, když `size.getWidth() > size.getHeight()`. Nezaměňujte rozměry A4 nebo Letter, pokud nechcete zároveň změnit velikost papíru.

## **Nastavit a ověřit vlastní velikost stránky poznámek**

Přiřaďte oba rozměry najednou a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k uložení prezentace. Tento příklad nastaví stránku formátu 900 × 600 bodů na šířku, uloží ji jako PPTX a znovu otevře uložený soubor pro kontrolu uložených hodnot. Porovnání umožňuje toleranci 0,01 bodu pro hodnoty s plovoucí desetinnou čárkou; není to záruka přesnosti pro každý formát souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Očekávaný výsledek je `900.0 x 600.0 points` a `Size preserved: True`. Kontrola nově otevřené prezentace ověřuje uložený soubor, nikoli jen nastavení v paměti.

## **Exportovat poznámky a letáky**

Rozměry stránky definují dostupnou oblast pro rozvržení poznámek nebo letáků. Samy o sobě neumožňují tato rozvržení; je třeba také nastavit možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Exportovat poznámky do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) k [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) pro zahrnutí poznámek do PDF. Tento příklad také vykreslí první snímek s poznámkami do PNG pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) a [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/) ponechává poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky o rozměrech 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitým níže je PNG 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Pro export PDF s dlouhými poznámkami [BottomFull](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/) umožňuje podle potřeby další stránky. Tento režim nepoužívejte s voláním pro jeden snímek obrazu výše, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů poznámkového masteru; změna rozměrů stránky sama o sobě není zárukou, že veškerý obsah bude pasovat. Viz [Convert PowerPoint to PDF with Notes](/slides/cs/python-java/convert-powerpoint-to-pdf-with-notes/) pro více informací o exportu poznámek.

### **Exportovat letáky do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku o rozměrech 900 × 600 bodů a použije [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handouttype/) k uspořádání až čtyř snímků na stránku. Vodorovné přednastavení řídí pořadí snímků; orientace stránky vychází z její šířky a výšky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Změna velikosti stránky mění oblast dostupnou pro mřížku letáku, aniž by měnila rozměry zdrojových snímků. Pro obrázky letáků použijte [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s rozvržením letáku, nikoli metodu obrázku jednotlivého snímku. V Aspose.Slides používá vykreslování letáků na úrovni prezentace rozměry stránky poznámek, zatímco volání pro obrázek jednotlivého snímku nevytváří stránku letáku. Viz [Handout Mode](/slides/cs/python-java/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky ve prohlížečích, exportu a tisku**

Uchovávejte odlišně uloženou velikost prezentace, velikost exportované stránky a velikost tištěného papíru:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky pomocí vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, znovu jej otevřete a zkontrolujte rozměry; konverze formátu této aplikace je může normalizovat.
- **Formáty exportu:** Příklady PDF s poznámkami a letáky výše používají nastavené rozměry stránky. Rastrové obrázky používají celočíselné rozměry pixelů a měřítko vykreslení, takže desetinné hodnoty bodů mohou být zaokrouhleny ve výstupu obrázku. Export běžných snímků neaplikuje velikost stránky poznámek.
- **Ovladače tiskáren:** Výběr papíru, automatická rotace a nastavení přizpůsobení na stránku mohou změnit fyzický výstup aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru sladťe nastavení tiskárny a zkontrolujte náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek pouze pro jeden snímek?**

Velikost stránky poznámek je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít různý obsah poznámek, ale tato vlastnost neposkytuje samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila mé snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Použijte nastavení rozměrů běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte její rozměry poznámek. Pokud se změnily, zkontrolujte, zda ukládání nebo konverze souboru v jiné aplikaci nezměnila nastavení stránky. Pokud ne, zkontrolujte rozvržení exportu, měřítko obrazu, nastavení prohlížeče a výběr papíru tiskárny.