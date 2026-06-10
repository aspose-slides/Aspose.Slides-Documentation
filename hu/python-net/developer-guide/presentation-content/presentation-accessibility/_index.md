---
title: Prezentációk hozzáférhetőségének kezelése Pythonban
linktitle: Prezentáció hozzáférhetőség
type: docs
weight: 30
url: /hu/python-net/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- dekorációnak jelölés
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan segít a Python számára készült Aspose.Slides automatizálni a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban—javítja a képernyőolvasó élményét és növeli a megfelelőséget."
---
## **Bevezetés**

A prezentációk hozzáférhetősége biztosítja, hogy a segítő technológiákat—például képernyőolvasókat, braille-kijelzőket vagy csak billentyűzettel történő navigációt—használó személyek megértsék és navigáljanak a diákon olyan hatékonyan, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a tiszta olvasási sorrendre, a szemléltető grafikák értelmes alternatív szövegére, a megfelelő színkontrasztra, az olvasható tipográfiára, a leíró hivatkozás szövegre, valamint arra összpontosít, hogy ne a szín vagy a pozíció egyedül közvetítsen jelentést. Ha a hozzáférhetőséget már a kezdetektől megtervezzük, az eredmény egy tisztább struktúra, következetesebb képi elemek és olyan tartalom, amely minden nézőhöz eljut anélkül, hogy megkerüléseket kellene alkalmazni.

## **Dekorációként jelölés**

A „Dekorációnak jelölés” jelző a pusztán díszítő elemeket jelöli, így a képernyőolvasók kihagyják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazza háttérre, díszítő motívumokra és elválasztókra—soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felderítéshez és ellenőrzéshez, lehetővé téve az automatizált hozzáférhetőségi ellenőrzéseket és a tisztítást.

![Dekorációnak jelölés](mark_as_decorative.png)

Az alábbi kódminta bemutatja, hogyan lehet meghatározni, hogy egy alakzat dekoratívként van-e jelölve.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```