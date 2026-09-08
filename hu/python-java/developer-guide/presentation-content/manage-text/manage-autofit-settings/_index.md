---
title: "Fejlessze előadásaikat az AutoFit használatával Pythonban"
linktitle: "Autofit beállítások"
type: docs
weight: 30
url: /hu/python-java/manage-autofit-settings/
keywords:
- szövegdoboz
- autofit
- ne alkalmazzon automatikus illesztést
- szöveg illesztése
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti az AutoFit beállításokat az Aspose.Slides for Python via Java-ban, a szöveg megjelenítésének optimalizálásához PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor szövegdobozt ad hozzá, a Microsoft PowerPoint a **Resize shape to fix text** beállítást használja a szövegdobozhoz – automatikusan átméretezi a szövegdobozt, hogy a szövege mindig elférjen benne. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Ha a szövegdoboz szövege hosszabbá vagy nagyobbra válik, a PowerPoint automatikusan megnöveli a szövegdobozt – megnöveli a magasságát –, hogy több szöveget tudjon tartalmazni. 
* Ha a szövegdoboz szövege rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegdobozt – csökkenti a magasságát –, hogy a felesleges helyet eltávolítsa. 

A PowerPointben ezek a 4 fontos paraméter vagy beállítás, amelyek szabályozzák a szövegdoboz automatikus illesztésének viselkedését: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Az Aspose.Slides for Python via Java hasonló lehetőségeket kínál – néhány tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályban – amelyekkel a szövegdobozok automatikus illesztésének viselkedését szabályozhatja a prezentációkban. 

## **Alakzat átméretezése a szöveghez való illeszkedéshez**

Ha azt szeretné, hogy a szöveg egy dobozban mindig beleférjen a szöveg módosítása után is, a **Resize shape to fix text** beállítást kell használnia. Ennek a beállításnak a megadásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#Shape) értékkel.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ez a Python kód megmutatja, hogyan adhatja meg, hogy a szövegnek mindig bele kell férnie a PowerPoint prezentációban lévő dobozba:

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

Ha a szöveg hosszabbá vagy nagyobbra válik, a szövegdoboz automatikusan átméreteződik (magasságban nő), hogy az összes szöveg elférjen benne. Ha a szöveg rövidebbé válik, a fordított történik. 

## **Ne alkalmazzon automatikus illesztést**

Ha azt szeretné, hogy egy szövegdoboz vagy alakzat megtartsa méreteit függetlenül attól, hogy a benne lévő szöveg hogyan változik, a **Do not Autofit** beállítást kell használnia. Ennek a beállításnak a megadásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#None) értékkel. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ez a Python kód megmutatja, hogyan adhatja meg, hogy a szövegdoboz mindig megtartsa méreteit egy PowerPoint prezentációban:

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Amikor a szöveg túl hosszúvá válik a dobozához képest, az kilóg. 

## **Szöveg zsugorítása túlcsordulás esetén**

Ha egy szöveg túl hosszú lesz a dobozához képest, a **Shrink text on overflow** beállítással megadhatja, hogy a szöveg méretét és távolságát csökkenteni kell, hogy beleférjen a dobozba. Ennek a beállításnak a megadásához használja a [setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódust (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [Normal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/#Normal) értékkel.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ez a Python kód megmutatja, hogyan adhatja meg, hogy a szöveget zsugorítani kell túlcsordulás esetén egy PowerPoint prezentációban:

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

{{% alert title="Megjegyzés" color="info" %}}
Amikor a **Shrink text on overflow** opciót használják, a beállítás csak akkor lép életbe, amikor a szöveg túl hosszúvá válik a dobozához képest. 
{{% /alert %}}

## **Szöveg tördelése**

Ha azt szeretné, hogy a szöveg egy alakzaton belül legyen megtördelve, amikor a szöveg meghaladja az alakzat szélét (csak a szélességet), a **Wrap text in shape** paramétert kell használnia. Ennek a beállításnak a megadásához a [setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) metódust kell használnia (a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) osztályból) a [NullableBool.True](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#True) értékkel. 

Ez a Python kód megmutatja, hogyan használja a Szöveg tördelése beállítást egy PowerPoint prezentációban:

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

{{% alert title="Figyelmeztetés" color="warning" %}} 
Ha a [setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) metódust a [NullableBool.False](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/#False) értékkel használja egy alakzatra, amikor a szöveg az alakzat szélességénél hosszabb lesz, a szöveg egyetlen sorban a forma szélén túlra nyúlik. 
{{% /alert %}}

## **GYIK**

**Érintik a szövegkeret belső margói az AutoFit működését?**

Igen. A kitöltés (belső margók) csökkenti a szöveg használható területét, ezért az AutoFit korábban lép életbe – a betűméretet vagy az alakzat méretét hamarabb csökkentve. Ellenőrizze és állítsa be a margókat, mielőtt finomhangolná az AutoFit-et.

**Hogyan működik az AutoFit a manuális és puha sortörésekkel?**

A kényszerített sortörések megmaradnak, az AutoFit a betűméretet és a távolságot az ő körülöttük igazítja. A felesleges sortörések eltávolítása gyakran csökkenti az AutoFit által igényelt szövegzsugorítás mértékét.

**A téma betűtípusának megváltoztatása vagy a betűtípus-helyettesítés beindítása befolyásolja az AutoFit eredményét?**

Igen. Egy olyan betűtípusra való helyettesítés, amelynek eltérő glifmetrikái vannak, megváltoztatja a szöveg szélességét/magasságát, ami módosíthatja a végső betűméretet és a sortörést. Bármely betűtípus‑változtatás vagy helyettesítés után ellenőrizze újra a diák tartalmát.