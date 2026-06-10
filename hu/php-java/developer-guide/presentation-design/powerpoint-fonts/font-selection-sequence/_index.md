---
title: Betűtípus Kiválasztási Sorozat az Aspose.Slides-ben PHP-hez
linktitle: Betűtípus Kiválasztás
type: docs
weight: 80
url: /hu/php-java/font-selection-sequence/
keywords:
- betűtípus kiválasztás
- betűtípus helyettesítés
- betűtípus csere
- helyettesítési szabály
- elérhető betűtípus
- hiányzó betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan választja ki a betűtípusokat az Aspose.Slides for PHP Java-vel, biztosítva a tiszta, konzisztens PPT, PPTX és ODP fájlok megjelenítését – javítsa most diái minőségét."
---
## **Áttekintés**

Amikor egy prezentációt betöltenek, renderelnek vagy egy másik formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides kiválaszt egy helyettesítő betűtípust, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keres a kiválasztott betűtípus után. Ha megtalálja a betűtípust, azt használja. Ha nem találja, akkor egy megfelelő helyettesítőt alkalmaz. Amikor a betűtípus‑helyettesítési szabályok a `FontSubstRule` segítségével vannak meghatározva, ezeket a szabályokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futásidejében, használhatsz beágyazott betűtípusokat a prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF‑fájlokhoz.

## **Betűtípus kiválasztás**

Bizonyos szabályok érvényesek a prezentáció betűtípusaira, amikor a prezentációt betöltik, renderelik vagy egy másik formátumba konvertálják. Például, amikor megpróbálod a prezentációt (a diákját) képekké konvertálni, a prezentáció betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányát megerősítik, helyettesítésre kerülnek—lásd [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/php-java/font-replacement/) és [**Betűtípus szubsztituáció**](https://docs.aspose.com/slides/hu/php-java/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides betűtípusok kezelésekor követ:

1. Az Aspose.Slides az operációs rendszerben keresi a betűtípusokat, hogy megtalálja a prezentáció által kiválasztott betűtípust.  
2. Ha a kiválasztott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy olyan helyettesítő betűtípust használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.  
3. Ha a betűtípus helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstrule/) segítségével vannak beállítva, azokat alkalmazza.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az Aspose futtatókörnyezethez, majd használd azokat. Lásd [**Egyedi betűtípusok**](https://docs.aspose.com/slides/hu/php-java/custom-font/).

Amikor további betűtípusokat helyeznek el egy prezentációban, azokat [**Beágyazott betűtípusoknak**](https://docs.aspose.com/slides/hu/php-java/embedded-font/) hívják.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha a PDF‑re konvertálni kívánt prezentáció olyan betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, akkor a szükséges betűtípusokat **Külső betűtípusokként** adhatod hozzá vagy töltheted be.

## **GYIK**

**Hogyan határozhatom meg, hogy mely betűtípusok vannak ténylegesen használatban egy prezentációban a konvertálás előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/) segítségével megvizsgáld a használt betűtípusokat, így eldöntheted, hogy [beágyazz](/slides/hu/php-java/embedded-font/), [helyettesíts](/slides/hu/php-java/font-replacement/) vagy [külső forrásokat adj hozzá](/slides/hu/php-java/custom-font/). Ez segít megelőzni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűtípus mappákat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhatsz [külső betűtípus forrásokat](/slides/hu/php-java/custom-font/), például mappákat vagy memóriában lévő adatfolyamokat a rendereléshez és exportáláshoz. Ez eltávolítja a függőséget a gazdarendszer betűtípusaitól és előre jelezhető elrendezést biztosít.

**Hogyan akadályozhatom meg, hogy hiányzó glif esetén csendes visszaesés történjen egy nem megfelelő betűtípusra?**

Határozd meg előre a kifejezett [betűtípus helyettesítést](/slides/hu/php-java/font-replacement/) és a betűtípus [visszaesési szabályokat](/slides/hu/php-java/fallback-font/). A használt betűtípusok elemzésével és a helyettesítők vezérelt prioritásának beállításával biztosítod a következetes tipográfiát és elkerülöd a váratlan eredményeket.