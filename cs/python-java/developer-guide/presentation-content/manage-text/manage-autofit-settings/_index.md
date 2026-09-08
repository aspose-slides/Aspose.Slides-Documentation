---
title: Vylepšete své prezentace pomocí AutoFit v Pythonu
linktitle: Nastavení Autofit
type: docs
weight: 30
url: /cs/python-java/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neautofit
- přizpůsobení textu
- zmenšení textu
- zalamování textu
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak spravovat nastavení AutoFit v Aspose.Slides pro Python prostřednictvím Javy, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fix text** pro textové pole – automaticky mění velikost textového pole, aby se text vždy vešel. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky rozšíří textové pole – zvětší jeho výšku – aby pojmul více textu.  
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole – zmenší jeho výšku – aby odstranil přebytečný prostor.  

V PowerPointu jsou to 4 důležité parametry nebo možnosti, které řídí chování autofitu pro textové pole:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java poskytuje podobné možnosti – některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/) – které vám umožňují řídit chování autofitu pro textová pole v prezentacích. 

## **Změnit velikost tvaru, aby text pasoval**

Pokud chcete, aby text v rámečku vždy pasoval do tohoto rámečku po úpravě textu, musíte použít možnost **Resize shape to fix text**. Pro nastavení tohoto chování použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby text vždy pasoval do svého rámečku v prezentaci PowerPoint:

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

Když se text prodlouží nebo zvětší, textové pole se automaticky zvětší (zvýší se výška), aby se do něj vešel celý text. Pokud se text zkrátí, nastane opačný efekt. 

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, musíte použít možnost **Do not Autofit**. Pro nastavení tohoto chování použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [None](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby textové pole vždy zachovalo své rozměry v prezentaci PowerPoint:

```python
import jpime
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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Když se text stane příliš dlouhým pro svůj rámeček, vyteče mimo něj. 

## **Shrink Text on Overflow**

Pokud se text stane příliš dlouhým pro svůj rámeček, pomocí možnosti **Shrink text on overflow** můžete nastavit, aby se velikost a mezery textu zmenšily, aby se vešel do rámečku. Pro nastavení tohoto chování použijte metodu [setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) (ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [Normal](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby byl text zmenšen při přetečení v prezentaci PowerPoint:

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
Když je použita možnost **Shrink text on overflow**, nastavení se aplikuje pouze v případě, že text přesáhne velikost svého rámečku. 
{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text v tvaru zalamoval uvnitř tohoto tvaru, když text přesáhne šířku tvaru, musíte použít parametr **Wrap text in shape**. Pro nastavení tohoto chování použijte metodu [setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText) (ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/)) s hodnotou [NullableBool.True](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#True). 

Tento Python kód ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Pokud použijete metodu [setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText) s hodnotou [NullableBool.False](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#False) pro tvar, když se text uvnitř tvaru prodlouží nad jeho šířku, text se rozšíří za hranice tvaru na jediný řádek. 
{{% /alert %}}

## **FAQ**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Vnitřní odsazení (padding) zmenšuje použitelné místo pro text, takže AutoFit se spustí dříve – zmenší písmo nebo dříve změní velikost tvaru. Zkontrolujte a upravte okraje před laděním AutoFitu.

**Jak AutoFit spolupracuje s ručními a měkkými konci řádků?**

Vynucené konce řádků zůstávají na svém místě a AutoFit přizpůsobuje velikost písma a mezery kolem nich. Odstranění zbytečných konců řádků často snižuje agresivitu, s jakou AutoFit musí text zmenšovat.

**Mění změna tématického písma nebo substituce písma výsledky AutoFitu?**

Ano. Náhrada písma za jiné s odlišnými metrikami glyfů mění šířku/výšku textu, což může ovlivnit finální velikost písma a zalamování řádků. Po jakékoli změně nebo substituci písma znovu zkontrolujte snímky.