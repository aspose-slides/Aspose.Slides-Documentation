---
title: Betűtípus kiválasztási sorrend az Aspose.Slides for C++-ban
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides for C++ a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok tiszta, következetes megjelenítését - javítsa most a diák minőségét."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először a kiválasztott betűtípust keresi meg az operációs rendszerben. Ha a betűtípust megtalálja, azt használja. Ha nem találja, egy megfelelő helyettesítő kerül alkalmazásra. Ha a betűtípus‑helyettesítési szabályok a `FontSubstRule` segítségével vannak meghatározva, ezeket a szabályokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz a futási időben, használhatsz beágyazott betűtípusokat egy prezentációból, vagy betölthetsz külső betűtípusokat kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztása**

Bizonyos szabályok vonatznak a prezentációban használt betűtípusokra, amikor a prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik. Például, amikor megpróbálod a prezentációt (a diákját) képekké konvertálni, a prezentáció betűtípusait ellenőrizni kell, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megállapítása megtörténik, helyettesítőkkel kerülnek helyettesítésre — lásd [**Font Replacement**](https://docs.aspose.com/slides/hu/cpp/font-replacement/) és [**Font Substitution**](https://docs.aspose.com/slides/hu/cpp/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides a betűtípusok kezelésekor követ:

1. Az Aspose.Slides a betűtípusokat az operációs rendszerben keresi, hogy megtalálja a prezentáció által kiválasztott betűtípusnak megfelelőt.  
2. Ha a kiválasztott betűtípust megtalálja, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.  
3. Ha a betűtípus helyettesítési szabályokat a [FontSubstRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstrule/) segítségével állították be, azok alkalmazásra kerülnek.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá a futási időben, majd azokat használd. Lásd [**Custom fonts**](https://docs.aspose.com/slides/hu/cpp/custom-font/).

Ha további betűtípusokat helyeznek el egy prezentációban, ezeket [**Embedded fonts**](https://docs.aspose.com/slides/hu/cpp/embedded-font/) néven ismerik.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF‑re konvertálni kívánt prezentáció betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, a szükséges betűtípusokat **external fonts**‑ként adhatod hozzá vagy töltheted be.

{{% alert title="Note" color="primary" %}} 
Mi nem terjesztünk semmilyen betűtípust, sem fizetettet, sem ingyenest. Az API‑nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd őket a dokumentumokba, de ezt a betűtípusok felhasználásával a saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

**Hogyan állapíthatom meg, hogy a konverzió előtt mely betűtípusok vannak ténylegesen használatban egy prezentációban?**

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) segítségével megvizsgáld a használt betűtípusokat, így eldöntheted, hogy [embed](/slides/hu/cpp/embedded-font/), [replace](/slides/hu/cpp/font-replacement/) vagy [external sources](/slides/hu/cpp/custom-font/) hozzáadását alkalmazod-e. Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhatsz [external font sources](/slides/hu/cpp/custom-font/) mint például mappákat vagy memóriafolyamokat a rendereléshez és exportáláshoz. Ez eltávolítja a függőséget a host rendszer betűtípusaival, és előre láthatóvá teszi a elrendezést.

**Hogyan akadályozhatom meg, hogy egy hiányzó glif esetén csendes visszalépés történjen egy nem megfelelő betűtípusra?**

Határozz meg előre explicit [font replacement](/slides/hu/cpp/font-replacement/) és betűtípus [fallBack rules](/slides/hu/cpp/fallback-font/) szabályokat. A használt betűtípusok elemzésével és a helyettesítők vezérelt prioritásának beállításával biztosíthatod a következetes tipográfiát, és elkerülheted a váratlan eredményeket.