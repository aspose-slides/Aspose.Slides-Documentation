---
title: Androidon a prezentációk hozzáférhetőségének kezelése
linktitle: Prezentáció hozzáférhetőség
type: docs
weight: 30
url: /hu/androidjava/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- megjelölés díszítő elemként
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides for Android Java-val automatizálni a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban—javítva a képernyőolvasók élményét és növelve a megfelelőséget."
---
## **Áttekintés**

Az előadás hozzáférhetősége biztosítja, hogy a segítő technológiákat—például képernyőolvasókat, Braille‑kijelzőket vagy kizárólag billentyűzetes navigációt—használó személyek megértsék és navigálhassák a diáidat olyan hatékonyan, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a tiszta olvasási sorrendre, a tájékoztató vizuális elemek értelmes alternatív szövegére, a megfelelő színkontrasztra, a könnyen olvasható tipográfiára, a leíró hivatkozásszövegre, valamint arra összpontosít, hogy a jelentést ne csak szín vagy pozíció alapján közvetítsék. Ha a hozzáférhetőség már a kezdetektől be van építve, az eredmény tisztább szerkezet, egységesebb vizuális elemek és olyan tartalom, amely minden nézőhöz eljut megkerülés nélkül.

## **Megjelölés díszítő elemként**

A „Megjelölés díszítő elemként” jelző a csupán dekoratív vizuális elemeket jelöli, hogy a képernyőolvasók átugorják őket, csökkentve a zajt és a figyelmet az értelmes tartalomra irányítva. Alkalmazható háttérképekre, díszítőelemekre és elválasztókra—soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felismeréshez és az ellenőrzéshez, lehetővé téve az automatikus hozzáférhetőségi vizsgálatokat és tisztítást.

![Mark as Decorative](mark_as_decorative.png)

A következő kódrészlet bemutatja, hogyan lehet meghatározni, hogy egy alakzat díszítőként van‑e jelölve.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```