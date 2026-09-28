---
title: "Použití nebo změna rozložení snímků v Pythonu prostřednictvím Javy"
linktitle: "Rozložení snímku"
type: docs
weight: 60
url: /cs/python-java/slide-layout/
keywords:
  - "rozložení snímku"
  - "rozložení obsahu"
  - "zástupný objekt"
  - "návrh prezentace"
  - "návrh snímku"
  - "nepoužité rozložení"
  - "viditelnost zápatí"
  - "snímek s titulkem"
  - "titulek a obsah"
  - "hlavička sekce"
  - "dvě oblasti obsahu"
  - "porovnání"
  - "pouze titulek"
  - "prázdné rozložení"
  - "obsah s popiskem"
  - "obrázek s popiskem"
  - "titulek a vertikální text"
  - "vertikální titulek a text"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentace"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Použijte, vytvořte a upravujte rozložení snímků v Aspose.Slides pro Python prostřednictvím Javy, přidejte zástupné objekty, odstraňte nepoužitá rozložení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům jednotnou strukturu a zároveň umožňuje, aby každý snímek obsahoval svůj vlastní obsah.

Nejběžnější rozložení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty nadpisu a podnadpisu.
- **Title and Content**: Obsahuje zástupný objekt nadpisu a obecný zástupný objekt obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečné, když bude každá forma umístěna ručně.

## **Porozumění dědičnosti rozložení**

Prezentace má tři související úrovně:

1. [master slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/) určuje motiv, sdílené formátování, pozadí a společné objekty.
2. [layout slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných objektů.
3. [normal slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí od svého masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu v této úrovni. Když je normální snímek vytvořen, tvary zástupných objektů jsou generovány ze zvoleného rozložení, zatímco obsah zadaný do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozložení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupných objektů v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které už je používáno, prohlédněte jeho závislé snímky a zkontrolujte výslednou prezentaci.
- Rozložení, které je stále používáno snímkem, nemůže být odstraněno. Předtím přesuňte jeho závislé snímky na jiné rozložení, nebo odstraňte pouze nepoužívaná rozložení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/python-java/slide-master/).

Chcete-li skrýt zděděná loga nebo dekorativní tvary masteru na jednom snímku nebo prostřednictvím sdíleného rozložení, viz [Control the Visibility of Master Graphics](/slides/cs/python-java/slide-master/). Příklad porovnává dva snímky používající stejný master.

## **Vyberte a použijte rozložení snímku**

Používejte typ rozložení, když prezentace používá standardní definice rozložení PowerPointu. Názvy rozložení lze uživatelem upravit a mohou být lokalizovány, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud toto rozložení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na `None` je nutná, protože prezentace může obsahovat pouze vlastní rozložení. Vybrané rozložení je pak aplikováno na první normální snímek pomocí metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setLayoutSlide).

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

Změna rozložení snímku neodstraní běžné tvary přidané přímo na snímek. Nicméně pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozložením se může změnit, proto zkontrolujte výstup při přepínání mezi podstatně odlišnými rozloženími.

## **Přidat rozložení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybírá existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

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

Přidejte rozložení pouze tehdy, když šablona skutečně potřebuje další opakovaně použitelné uspořádání. Pokud již existuje vhodné rozložení, vyberte a znovu jej použijte místo vytváření duplikátu.

## **Přidat zástupné objekty do rozložení snímku**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozložení.

| Zástupný objekt PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| -------------------------- | ---------------------------------- |
| ![Obsah](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Obsah (vertikální)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (vertikální)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obrázek](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graf](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabulka](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online obrázek](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověřuje, že rozložení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozložení. Pořadí je záměrné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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

![Zástupné objekty na rozložení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů rozložení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozložení není doplněn do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a prověřte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozložení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechává rozložení, která jsou stále používána, beze změny.

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

Pro odstranění konkrétního rozložení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getDependingSlides). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#remove) přesuňte všechny závislé snímky. Pokus o odstranění používaného rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozložení snímku**

Rozložení má vlastní zástupné objekty zápatí, čísla snímku a datum‑čas. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) k řízení těchto zástupných objektů pro jedno rozložení. To je užitečné například, když rozložení obsahu mají zobrazovat zápatí, ale rozložení nadpisů ne.

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

## **Ovládání viditelnosti zápatí na masteru a jeho podřízených rozloženích**

Pro použití jednotných nastavení zápatí v celé hierarchii masteru použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření třídy [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslideheaderfootermanager/) působí na master a jeho závislé rozložení snímků a normální snímky; necílí pouze na jeden normální snímek.

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

## **FAQ**

**Jaký je rozdíl mezi master snímkem a layout snímkem?**

Master snímek určuje motiv prezentace a sdílené formátování. Layout snímek patří k masteru a určuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozložení a ukládají obsah specifický pro snímek.

**Mohu zkopírovat layout snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité zdrojovým rozložením.

**Co se stane, když upravím rozložení, které už je používáno?**

Závislé snímky zdědí změny rozložení, pokud lokálně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděný styl se tak mohou změnit na mnoha snímcích najednou. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, pokud odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění pouze neodkazovaných rozložení.