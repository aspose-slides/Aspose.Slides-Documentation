---
title: Prezentáció hozzáférhetőségének kezelése C++-ban
linktitle: Prezentáció hozzáférhetősége
type: docs
weight: 30
url: /hu/cpp/presentation-accessibility/
keywords:
- prezentáció hozzáférhetősége
- dekoratívként jelölés
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides for C++ automatizálni a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban – javítja a képernyőolvasó élményt és növeli a megfelelőséget."
---
## **Áttekintés**

Az előadás hozzáférhetősége biztosítja, hogy a segédtechnológiákat—például képernyőolvasókat, braille kijelzőket vagy kizárólag billentyűzettel történő navigálást—használó emberek megértsék és végigmenjenek a diáidon, ugyanolyan hatékonyan, mint a látó, egérrel vezérelt közönség. A jó gyakorlat a tiszta olvasási sorrendre, a tájékoztató képek értelmes alternatív szövegére, a megfelelő színkontrasztra, az olvasható tipográfiára, a leíró hivatkozásszövegre, valamint arra összpontosít, hogy ne csak szín vagy elhelyezkedés alapján közvetítsünk jelentést. Ha a hozzáférhetőséget már a kezdetektől tervezik, az eredmény egy tisztább struktúra, egységesebb vizuális elemek, és olyan tartalom, amely minden nézőhöz eljut anélkül, hogy megkerülő megoldásokat kellene alkalmazni.

## **Megjelölés dekoratívként**

A „Mark as decorative” jelző a pusztán díszítő elemeket jelöli, így a képernyőolvasók kihagyják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazd háttérképekre, díszítésekre és elválasztókra – soha nem diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felderítés és ellenőrzés számára, lehetővé téve az automatikus hozzáférhetőségi ellenőrzéseket és tisztítást.

![Mark as Decorative](mark_as_decorative.png)

A következő kódrészlet azt mutatja, hogyan lehet meghatározni, hogy egy alakzat dekoratívként van‑e megjelölve.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```