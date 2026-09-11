---
title: Prezentáció hozzáférhetőség kezelése Pythonon keresztül Java segítségével
linktitle: Prezentáció hozzáférhetőség
type: docs
weight: 30
url: /hu/python-java/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- díszítőként jelölt
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides Python számára Java-n keresztül az előadások hozzáférhetőségi ellenőrzéseinek automatizálásában PPT, PPTX és ODP fájlokban — javítja a képernyőolvasók élményét és növeli a megfelelőséget."
---
## **Bevezetés**

Az előadás hozzáférhetősége biztosítja, hogy a segítő technológiákat—például képernyőolvasókat, Braille‑kijelzőket vagy csak billentyűzetes navigációt—használó emberek is olyan hatékonyan megértsék és navigálják a diákat, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a világos olvasási sorrendre, a tájékoztató képek értelmes alternatív szövegére, a megfelelő színkontrasztra, a jól olvasható tipográfiára, a leíró hivatkozásszövegre, és arra összpontosít, hogy ne hordozzon jelentést kizárólag szín vagy pozíció alapján. Ha a hozzáférhetőséget már az elejétől tervezik, a végeredmény egy tisztább struktúra, egységesebb vizuálok és olyan tartalom, amely minden nézőhöz eljut kerülőmegoldások nélkül.

## **Díszítőként jelölés**

A „Díszítőként jelölt” jelző a pusztán dekoratív képeket jelöli meg, így a képernyőolvasók átugorják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazzuk háttérképekre, díszítésekre és elválasztókra – soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi felderítésre és ellenőrzésre, lehetővé téve az automatikus hozzáférhetőségi ellenőrzéseket és tisztítást.

![Díszítőként jelölt](mark_as_decorative.png)

A következő kódrészlet bemutatja, hogyan lehet meghatározni, hogy egy alakzat díszítőként van‑e jelölve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```