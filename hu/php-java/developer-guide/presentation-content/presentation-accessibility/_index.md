---
title: Prezentáció hozzáférhetőségének kezelése PHP-ben
linktitle: Prezentáció hozzáférhetősége
type: docs
weight: 30
url: /hu/php-java/presentation-accessibility/
keywords:
- prezentáció hozzáférhetősége
- dekorációként jelöl
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan segít az Aspose.Slides automatizálni a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban - javítva a képernyőolvasók élményét és növelve a megfelelőséget."
---
## **Áttekintés**

A prezentációk hozzáférhetősége biztosítja, hogy a segítő technológiákat – például képernyőolvasókat, braille kijelzőket vagy kizárólag billentyűzettel történő navigációt – használó emberek is megértsék és végigkövethessék a diáidat ugyanolyan hatékonyan, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a tiszta olvasási sorrendre, az információt közlő képek értelmes alternatív szövegére, a megfelelő színkontrasztra, a olvasható tipográfiára, a leíró hivatkozásszövegre, valamint arra összpontosít, hogy a jelentést ne csak szín vagy pozíció alapján közvetítsük. Ha a hozzáférhetőséget már a kezdetektől tervezik, tisztább szerkezet, egységesebb vizuális elemek és minden néző számára elérhető tartalom születik, anélkül, hogy megkerülő megoldásokat kellene alkalmazni.

## **Dekorációként jelöl**

A „Dekorációként jelöl” jelző a pusztán díszítő elemeket jelöli meg, így a képernyőolvasók átugorják őket, csökkentve a zajt és a figyelmet a jelentős tartalomra összpontosítva. Alkalmazható háttérképekre, díszítőelemekre és hézagokra – semmiképp sem diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felismeréshez és az ellenőrzéshez, lehetővé téve az automatikus hozzáférhetőségi ellenőrzéseket és a takarítást.

![Dekorációként jelöl](mark_as_decorative.png)

Az alábbi kódrészlet bemutatja, hogyan lehet meghatározni, hogy egy alakzat dekorációként van‑e megjelölve.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```