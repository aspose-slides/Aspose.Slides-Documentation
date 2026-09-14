---
title: Použít nebo změnit rozložení snímků v Pythonu přes Java
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/python-java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný objekt
- design prezentace
- design snímku
- nepoužité rozložení
- viditelnost patičky
- titulní snímek
- název a obsah
- hlavička sekce
- dvě části obsahu
- porovnání
- pouze název
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- název a vertikální text
- vertikální název a text
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použít, vytvořit a upravit rozložení snímků v Aspose.Slides pro Python přes Java, přidávat zástupné objekty, odstraňovat nepoužitá rozložení a řídit viditelnost patičky."
---
## **Přehled**

Rozložení snímku určuje pozice a formátování zástupných objektů, jako jsou názvy, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům jednotnou strukturu a zároveň umožňuje každému snímku obsahovat vlastní obsah.

Nejběžnější rozložení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty názvu a podnadpisu.
- **Title and Content**: Obsahuje zástupný objekt názvu a obecný zástupný objekt obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečný, když bude každá forma umístěna ručně.

## **Pochopení dědičnosti rozložení**

Prezentace má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. A [layout slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/) patří k hlavnímu snímku a určuje konkrétní uspořádání zástupných objektů.
1. A [normal slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí ze svého hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou vygenerovány ze zvoleného rozložení, zatímco obsah zadaný do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozložení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozložení, které je stále používáno snímkem, nelze odebrat. Nejprve přiřaďte jeho závislé snímky k jinému rozložení nebo odeberte jen nepoužívaná rozložení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/python-java/slide-master/).

## **Vybrat a použít rozložení snímku**

Použijte typ rozložení, když prezentace používá standardní definice rozložení PowerPointu. Názvy rozložení lze upravovat a lokalizovat, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Title and Content** v prvním hlavním snímku. Pokud není toto rozložení k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na `None` je nutná, protože prezentace může obsahovat pouze vlastní rozložení. Vybrané rozložení je pak použito na první normální snímek pomocí metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Změna rozložení snímku neodstraňuje běžné tvary přidané přímo do snímku. Nicméně pozice zástupných objektů, zděděné formátování a odpovídající vazba mezi existujícími zástupnými objekty a novým rozložením se mohou změnit, proto zkontrolujte výstup při přepínání mezi podstatně odlišnými rozloženími.

## **Přidat rozložení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybírá existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozložení cílového hlavního snímku.

Následující příklad vždy přidá nové rozložení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přidejte rozložení pouze tehdy, když šablona skutečně potřebuje další opakovaně použitelnou strukturu. Pokud již existuje vhodné rozložení, vyberte a použijte jej místo vytváření duplicitního.

## **Přidat zástupné objekty do rozložení snímku**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/) pro přidání tvarů zástupných objektů do rozložení.

| Zástupný objekt PowerPoint | Metoda LayoutPlaceholderManager |
| -------------------------- | -------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověří, že rozložení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který použije upravené rozložení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Zástupné objekty na snímku rozložení](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozložení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozložení není doplněn do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odebrat nepoužívaná rozložení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odebrání rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, beze změny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro odebrání konkrétního rozložení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getDependingSlides). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#remove) přiřaďte všechny závislé snímky. Pokus o odebrání rozložení, které je používáno, vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxeditexception/).

## **Řídit viditelnost patičky na rozložení snímku**

Rozložení má své vlastní zástupné objekty patičky, čísla snímku a data/času. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) pro řízení těchto zástupných objektů u konkrétního rozložení. To je užitečné například, když by obsahová rozložení měla zobrazovat patičky, ale titulní rozložení ne.

Následující příklad bezpečně vybere rozložení a zobrazí jeho prvky patičky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Řídit viditelnost patičky na hlavním snímku a jeho podřízených rozloženích**

Pro jednotné nastavení patiček v celé hierarchii hlavního snímku použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření třídy [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslideheaderfootermanager/) působí na hlavní snímek i na jeho závislé rozložení snímků a normální snímky; neovlivňují pouze jeden normální snímek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozložením snímku?**

Hlavní snímek definuje motiv a sdílené formátování prezentace. Rozložení snímku patří k hlavnímu snímku a určuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu kopírovat rozložení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte fonty, motivy, obrázky a další zdroje použité ve zdrojovém rozložení.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud místně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou změnit na mnoha snímcích najednou. Před úpravou rozložení použijte [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků.

**Co se stane, pokud odeberu rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky jinde nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odebrání pouze neodkazovaných rozložení.