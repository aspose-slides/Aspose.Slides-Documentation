---
title: Vylepšete své prezentace pomocí AutoFit v Pythonu
linktitle: Nastavení AutoFit
type: docs
weight: 30
url: /cs/python-java/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neautofitovat
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak spravovat nastavení AutoFit v Aspose.Slides pro Python prostřednictvím Javy, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fit text** – automaticky mění velikost textového pole, aby se do něj vždy vešly jeho texty.

![Textové pole v PowerPointu](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky rozšíří výšku textového pole, aby mohl pojmout více textu.
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky sníží výšku textového pole a odstraní přebytečný prostor.

V PowerPointu jsou 4 důležité parametry nebo možnosti, které řídí chování autofitu pro textové pole:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![Možnosti autofitu v PowerPointu](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java poskytuje podobné možnosti – některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/) – které vám umožní řídit chování autofitu pro textová pole v prezentacích.

## **Resize a Shape to Fit Text**

Pokud chcete, aby text v rámečku vždy pasoval do tohoto rámečku po změně textu, musíte použít možnost **Resize shape to fit text**. K nastavení této volby použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#Shape).

![vždy-pasuje-nastavení-powerpoint](alwaysfit-setting-powerpoint.png)

Tento kód v Pythonu ukazuje, jak nastavit, aby text vždy pasoval do svého rámečku v prezentaci PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud se text prodlouží nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby se do něj veškerý text vešel. Pokud se text zkrátí, nastane opačný efekt.

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, musíte použít možnost **Do not Autofit**. K nastavení této volby použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [None](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#None).

![není-autofit-nastavení-powerpoint](donotautofit-setting-powerpoint.png)

Tento kód v Pythonu ukazuje, jak nastavit, aby textové pole vždy zachovávalo své rozměry v prezentaci PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Když se text stane příliš dlouhým pro své pole, přetéká ven.

## **Shrink Text on Overflow**

Pokud se text stane příliš dlouhým pro své pole, můžete použít možnost **Shrink text on overflow**, která určuje, že velikost a rozestupy textu se zmenší, aby se vešel do pole. K nastavení této volby použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [Normal](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#Normal).

![zmenšení-textu-při-přetečení-nastavení-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento kód v Pythonu ukazuje, jak nastavit, aby se text při přetečení zmenšil v prezentaci PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}

Když je použita možnost **Shrink text on overflow**, nastavení se aplikuje pouze tehdy, když se text stane příliš dlouhým pro své pole.

{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text v tvaru zalamoval uvnitř tohoto tvaru, když text přesáhne jeho šířku, musíte použít parametr **Wrap text in shape**. K nastavení této volby použijte metodu [setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [NullableBool.True_](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#True).

Tento kód v Pythonu ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 

Pokud použijete metodu [setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText) s hodnotou [NullableBool.False](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#False) pro tvar, když se text uvnitř tvaru prodlouží přes šířku tvaru, text bude pokračovat mimo hranice tvaru v jedné řádce.

{{% /alert %}}

## **Často kladené otázky**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Okraje (vnitřní odsazení) snižují použitelné místo pro text, takže AutoFit se aktivuje dříve – zmenšuje písmo nebo dříve mění velikost tvaru. Před laděním AutoFit zkontrolujte a upravte okraje.

**Jak AutoFit spolupracuje s ručně vloženými a měkkými konci řádků?**

Vynucené zalomení zůstává zachováno a AutoFit přizpůsobuje velikost písma a rozestupy kolem nich. Odstranění zbytečných zalomení často snižuje agresivitu, s níž AutoFit zmenšuje text.

**Mění změna tématu písma nebo vyvolání substituce písma výsledek AutoFit?**

Ano. Nahrazení písma jiným s odlišnými metrikami znaků mění šířku/výšku textu, což může změnit konečnou velikost písma a zalamování řádků. Po jakékoli změně či substituci písma znovu zkontrolujte snímky.