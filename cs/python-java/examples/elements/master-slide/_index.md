---
title: Hlavní snímek
type: docs
weight: 30
url: /cs/python-java/examples/elements/master-slide/
keywords:
- příklad kódu
- hlavní snímek
- přidat hlavní snímek
- přístup k hlavnímu snímku
- odstranit hlavní snímek
- nepoužitý hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte hlavní snímky pomocí Aspose.Slides pro Python přes Java: vytvářejte, přistupujte, odstraňujte a čistěte master snímky v prezentacích PowerPoint a OpenDocument."
---
Master slides tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **master slide** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **layout slides** dědí z master slides a **normal slides** dědí z layout slides.

Tento článek ukazuje, jak vytvářet, upravovat a spravovat master slides pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle pokynů v [Installation](/slides/cs/python-java/installation/). Každý příklad nejprve importuje `asposeslides` před spuštěním JVM, poté importuje API po spuštění JVM.

## **Přidat master slide**

Tento příklad ukazuje, jak vytvořit nový master slide klonováním výchozího. Pak přidá banner s názvem společnosti ke všem snímkům pomocí dědičnosti rozvržení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Zkopírujte výchozí hlavní snímek.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Přidejte banner s názvem společnosti na vrchol hlavního snímku.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Přiřaďte nový hlavní snímek k rozložení snímku.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Přiřaďte rozložení snímku k prvnímu snímku v prezentaci.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Master slides poskytují způsob, jak aplikovat konzistentní značku nebo sdílené designové prvky napříč všemi snímky. Změny provedené v masteru se automaticky projeví na závislých layout a normal slides.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Tvary a formátování přidané do master slide jsou zděděny layout slides a následně všemi normal slides, které tyto rozvržení používají. Obrázek níže ukazuje, jak textové pole přidané do master slide je automaticky vykresleno na finálním snímku.
{{% /alert %}}

![Příklad dědičnosti master](master-slide-banner.png)

## **Přístup k master slide**

K master slides můžete přistupovat prostřednictvím kolekce masterů prezentace. Tento příklad načte první master slide a změní jeho typ pozadí.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Odstranit master slide**

Master slide lze odstranit podle indexu nebo reference poté, co již není používán. Tento příklad přiřadí klonovaný master slide prezentaci a poté odstraní původní master podle indexu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Odstraňte nepoužitý původní hlavní snímek podle indexu.
    # Alternativně odstraňte nepoužitý hlavní snímek podle reference:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Odstranit nepoužívané master snímky**

Některé prezentace obsahují master slides, které nejsou použity. Odstraněním těchto snímků můžete snížit velikost souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Odstraňte všechny nepoužívané hlavní snímky, včetně těch označených jako Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```