---
title: Prezentáció hozzáférhetőségének kezelése JavaScript-ben
linktitle: Prezentáció hozzáférhetősége
type: docs
weight: 30
url: /hu/nodejs-java/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- dekoratívként jelölés
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizálja a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban az Aspose.Slides for Node.js segítségével – javítsa a képernyőolvasók élményét és növelje a megfelelőséget."
---
## **Áttekintés**

A prezentációk hozzáférhetősége biztosítja, hogy a segédtechnológiákat – például képernyőolvasókat, braille kijelzőket vagy kizárólag billentyűzetes navigációt – használó emberek is olyan hatékonyan értsék és navigálják a diákat, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a tiszta olvasási sorrendre, az információs vizuális elemek értelmes alternatív szövegére, a megfelelő színkontrasztra, a olvasható tipográfiára, a leíró hivatkozásszövegre, valamint arra összpontosít, hogy a jelentést ne csak szín vagy pozíció alapján közvetítsük. Ha a hozzáférhetőség már a tervezés kezdetétől szerepel, a végeredmény rendezettebb struktúra, konzisztensabb vizuális elemek és minden néző számára elérhető tartalom, kerülve a kikerülő megoldásokat.

## **Dekoratívként jelölés**

A dekoratívként jelölés flag a pusztán díszítő elemeket jelöli, így a képernyőolvasók átugorják őket, csökkentve a zajt és a fókuszt a lényeges tartalomra irányítva. Alkalmazható háttérképekre, díszítésekre és elválasztókra – soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a flag-et elérhetővé teszi felderítésre és validálásra, lehetővé téve az automatikus hozzáférhetőségi ellenőrzéseket és tisztítást.

![Dekoratívként jelölt](mark_as_decorative.png)

A következő kódrészlet bemutatja, hogyan lehet meghatározni, hogy egy alakzat dekoratívként van‑e jelölve.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```