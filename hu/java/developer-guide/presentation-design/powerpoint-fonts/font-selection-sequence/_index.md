---
title: Betűkészlet kiválasztási sorozat az Aspose.Slides for Java-ban
linktitle: Betűkészlet kiválasztás
type: docs
weight: 80
url: /hu/java/font-selection-sequence/
keywords:
- betűkészlet kiválasztás
- betűkészlet helyettesítés
- betűkészlet cseréje
- helyettesítési szabály
- elérhető betűkészlet
- hiányzó betűkészlet
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan választja ki a betűkészleteket az Aspose.Slides for Java, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését – javítsa most diái minőségét."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, renderelődik vagy egy másik formátumba konvertálódik, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Aspose.Slides először az operációs rendszerben keresi a kiválasztott betűtípust. Ha megtalálja, azt használja. Ha nem találja, egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus‑helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, azokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futási idejében, használhatsz beágyazott betűtípusokat egy prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűkészlet kiválasztása**

Bizonyos szabályok vonatznak a prezentáció betűtípusaira, amikor az betöltődik, renderelődik vagy egy másik formátumba konvertálódik. Például, ha megpróbálod a prezentációt (a diákjait) képekké konvertálni, a prezentáció betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megerősítése megtörténik, helyettesítésre kerülnek — lásd [**Betűkészlet helyettesítés**](https://docs.aspose.com/slides/hu/java/font-replacement/) és [**Betűkészlet szubsztitúció**](https://docs.aspose.com/slides/hu/java/font-substitution/).

Az alábbi folyamatot követi az Aspose.Slides a betűtípusok kezelésekor:
1. Az Aspose.Slides az operációs rendszerben keresi a betűtípusokat, hogy megtalálja a prezentáció által választott betűtípussal megegyezőt. 
2. Ha a választott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha a betűtípus‑helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrule/) segítségével vannak beállítva, alkalmazásra kerülnek. 

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futásidejéhez, és azután ezeket használd. Lásd [**Egyéni betűkészletek**](https://docs.aspose.com/slides/hu/java/custom-font/). 

Ha további betűtípusok egy prezentációba vannak ágyazva, ezeket [**Beágyazott betűkészletek**](https://docs.aspose.com/slides/hu/java/embedded-font/)nek nevezik.

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF‑re konvertálni kívánt prezentáció olyan betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűkészletekből, akkor a szükséges betűtípusokat **külső betűkészletekként** adhatod hozzá vagy töltheted be.

{{% alert title="Megjegyzés" color="info" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetettet, sem ingyeneset. API‑nk lehetővé teszi külső betűtípusok betöltését és beágyazását a dokumentumokba, de ezt a betűtípusokkal Ön saját belátása és felelőssége szerint teszi.
{{% /alert %}}

## **GYIK**

### Hogyan tudom meghatározni, mely betűtípusok vannak ténylegesen használatban egy prezentációban a konvertálás előtt?

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/) segítségével megvizsgáld a használt betűtípusokat, így eldöntheted, hogy [beágyazz](/slides/hu/java/embedded-font/), [helyettesíts](/slides/hu/java/font-replacement/) vagy [külső forrásokat adj hozzá](/slides/hu/java/custom-font/). Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és exportálás során.

### Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?

Igen. Regisztrálhatsz [külső betűtípus forrásokat](/slides/hu/java/custom-font/) olyan mappák vagy memóriaáramok formájában, a rendereléshez és exportáláshoz. Ez eltávolítja a függőséget a host rendszer betűtípusaival, és előre jelezhető elrendezést biztosít.

### Hogyan előzhetem meg a csendes visszalépést egy nem megfelelő betűtípusra, ha egy glif hiányzik?

Definiálj előre explicit [betűtípus helyettesítést](/slides/hu/java/font-replacement/) és betűtípus [fallback szabályokat](/slides/hu/java/fallback-font/). A használt betűtípusok elemzésével és a helyettesítők kontrollált prioritásának beállításával biztosíthatod a következetes tipográfiát és elkerülheted a váratlan eredményeket.