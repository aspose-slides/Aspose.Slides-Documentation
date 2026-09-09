---
title: Javítsa prezentációit az AutoFit segítségével Pythonban
linktitle: Autofit beállítások
type: docs
weight: 30
url: /hu/python-java/manage-autofit-settings/
keywords:
- szövegdoboz
- autofit
- ne használjon autofit-et
- szövegillesztés
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti az AutoFit beállításokat az Aspose.Slides for Python via Java könyvtárban, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor szövegdobozt ad hozzá, a Microsoft PowerPoint a **Resize shape to fit text** beállítást használja a szövegdobozhoz – automatikusan átméretezi a szövegdobozt, hogy a szöveg mindig beleférjen.

![Szövegdoboz PowerPointban](textbox-in-powerpoint.png)

* Amikor a szöveg a szövegdobozban hosszabbá vagy nagyobbra nő, a PowerPoint automatikusan megnöveli a szövegdobozt – magasságát növeli – hogy több szöveget tudjon tartalmazni.
* Amikor a szöveg a szövegdobozban rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegdobozt – magasságát csökkenti – hogy eltávolítsa a felesleges helyet.

PowerPointban ezek a 4 fontos paraméter vagy beállítás, amelyek a szövegdoboz automatikus méretezését (autofit) szabályozzák:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit opciók PowerPointban](autofit-options-powerpoint.png)

Az Aspose.Slides for Python via Java hasonló lehetőségeket kínál – néhány tulajdonság a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályban – amelyek lehetővé teszik a szövegdobozok automatikus méretezésének (autofit) irányítását a prezentációkban.

## **Alakzat átméretezése a szöveghez igazodóan**

Ha azt szeretné, hogy a szöveg a dobozban mindig beleférjen a szöveg módosítása után, a **Resize shape to fit text** beállítást kell használnia. Ennek meghatározásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#Shape) értékkel.

![alwaysfit beállítás PowerPointban](alwaysfit-setting-powerpoint.png)

Ez a Python kód bemutatja, hogyan lehet megadni, hogy a szöveg mindig beleférjen a saját dobozába egy PowerPoint prezentációban:

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

Ha a szöveg hosszabbá vagy nagyobbá válik, a szövegdobozt automatikusan átméretezi (magasságát növeli), hogy az összes szöveg beleférjen. Ha a szöveg rövidebb lesz, a fordított történik.

## **Ne használjon AutoFit-et**

Ha azt szeretné, hogy egy szövegdoboz vagy alakzat megtartsa a méreteit a tartalmazott szöveg módosításától függetlenül, a **Do not Autofit** opciót kell használnia. Ennek meghatározásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#None) értékkel.

![donotautofit beállítás PowerPointban](donotautofit-setting-powerpoint.png)

Ez a Python kód bemutatja, hogyan lehet megadni, hogy egy szövegdoboz mindig megtartsa a méreteit egy PowerPoint prezentációban:

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

Ha a szöveg túl hosszú lesz a dobozhoz képest, kifolyik.

## **Szöveg zsugorítása túlcsordulás esetén**

Ha a szöveg túl hosszú lesz a dobozhoz képest, használhatja a **Shrink text on overflow** opciót, hogy a szöveg méretét és távolságát csökkentse, így belefér a dobozba. Ennek meghatározásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [Normal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#Normal) értékkel.

![shrinktextonoverflow beállítás PowerPointban](shrinktextonoverflow-setting-powerpoint.png)

Ez a Python kód bemutatja, hogyan lehet megadni, hogy a szöveget zsugorítani kell a túlcsordulás esetén egy PowerPoint prezentációban:

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
Amikor a **Shrink text on overflow** opciót használják, a beállítás csak akkor érvényesül, amikor a szöveg túl hosszú lesz a dobozhoz képest.
{{% /alert %}}

## **Wrap Text**

Ha azt szeretné, hogy a szöveg egy alakzaton belül megtörjön, amikor a szöveg túllépi az alakzat szélét (csak szélesség), a **Wrap text in shape** paramétert kell használnia. Ennek meghatározásához a [setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) metódust kell használni (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [NullableBool.True_](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#True) értékkel.

Ez a Python kód bemutatja, hogyan kell használni a Wrap Text beállítást egy PowerPoint prezentációban:

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
Ha a [setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) metódust a [NullableBool.False](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#False) értékkel használja egy alakzatra, akkor amikor a szöveg az alakzaton belül hosszabb lesz az alakzat szélességénél, a szöveg egy sorban a határvonalakon túlra nyúlik.
{{% /alert %}}

## **FAQ**

**Befolyásolják a szövegkeret belső margói az AutoFit-et?**

Igen. A kitöltés (belső margók) csökkentik a szöveg használható területét, ezért az AutoFit korábban aktiválódik – a betűtípus csökkentésével vagy az alakzat átméretezésével. Ellenőrizze és állítsa be a margókat, mielőtt finomhangolná az AutoFit-et.

**Hogyan működik az AutoFit a kézi és lágy sortörésekkel?**

A kényszerített sortörések megmaradnak, és az AutoFit a betűméretet és a távolságot körülöttük igazítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy az AutoFit mennyire kell szigorúan zsugorítani a szöveget.

**A témabetű módosítása vagy a betűcsere kiváltása befolyásolja az AutoFit eredményét?**

Igen. Egy másik metrikájú betűtípus helyettesítése megváltoztatja a szöveg szélességét/magasságát, ami módosíthatja a végső betűméretet és a sortörést. Bármilyen betűtípus-változtatás vagy -csere után ellenőrizze újra a diák tartalmát.