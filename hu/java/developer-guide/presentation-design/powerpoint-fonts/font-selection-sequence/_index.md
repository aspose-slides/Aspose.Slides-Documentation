---
title: Betűtípus kiválasztási folyamat az Aspose.Slides for Java-ban
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides for Java a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését – javítsa most diákját."
---
## **Áttekintés**

Amikor egy prezentációt betöltenek, renderelnek vagy egy másik formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Az Aspose.Slides először a kiválasztott betűtípust keresi az operációs rendszerben. Ha a betűtípus megtalálható, azt használja. Ha nem található, akkor egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus‑helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, azokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futásidejében, használhatsz beágyazott betűtípusokat egy prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztás**

Bizonyos szabályok vonatznak a prezentációban használt betűtípusokra, amikor a prezentációt betöltik, renderelik vagy egy másik formátumba konvertálják. Például amikor egy prezentációt (a diákját) képekké konvertálsz, a prezentáció betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányát megállapítják, helyettesítésre kerülnek – lásd [**Font Replacement**](https://docs.aspose.com/slides/hu/java/font-replacement/) és [**Font Substitution**](https://docs.aspose.com/slides/hu/java/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides a betűtípusok kezelése során követ:

1. Az Aspose.Slides a betűtípusokat az operációs rendszerben keresi, hogy megtalálja a prezentáció által kiválasztott betűtípussal megegyezőt. 
2. Ha a kiválasztott betűtípust megtalálja, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy olyan helyettesítő betűtípust alkalmaz, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna. 
3. Ha a betűtípus helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrule/) segítségével lettek beállítva, azokat alkalmazzák. 

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futásidejéhez, majd azokat használd. Lásd [**Custom fonts**](https://docs.aspose.com/slides/hu/java/custom-font/). 

Amikor további betűtípusokat helyeznek el egy prezentációban, azokat [**Embedded fonts**](https://docs.aspose.com/slides/hu/java/embedded-font/) néven hívják. 

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF‑re konvertálni kívánt prezentáció olyan betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, akkor a szükséges betűtípusokat **external fonts**‑ként adhatod hozzá vagy töltheted be. 

{{% alert title="Note" color="primary" %}} 
Nem terjesztünk semmilyen betűtípust, legyen az fizetős vagy ingyenes. Az API‑nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd a dokumentumokba, de ezt a betűtípusok saját belátásod és felelősséged szerint kell megtenned.
{{% /alert %}}

## **GYIK**

**Hogyan határozhatom meg, hogy mely betűtípusok vannak ténylegesen használatban egy prezentációban a konvertálás előtt?**

Az Aspose.Slides lehetővé teszi a használt betűtípusok ellenőrzését a [font manager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/) segítségével, így eldöntheted, hogy [embed](/slides/hu/java/embedded-font/), [replace](/slides/hu/java/font-replacement/) vagy [external sources](/slides/hu/java/custom-font/) hozzáadását szeretnéd-e alkalmazni. Ez segít megelőzni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhatsz [external font sources](/slides/hu/java/custom-font/) olyan elemeket, mint mappák vagy memóriában lévő adatfolyamok a rendereléshez és az exporthoz. Ez eltünteti a függőséget a gazda rendszer betűtípusaival, és előre láthatóvá teszi az elrendezést.

**Hogyan akadályozhatom meg a csendes visszaesést egy nem megfelelő betűtípusra, ha egy glif hiányzik?**

Határozz meg előre explicit [font replacement](/slides/hu/java/font-replacement/) és betűtípus [fallback rules](/slides/hu/java/fallback-font/) szabályokat. A használt betűtípusok elemzésével és a helyettesítők szabályozott prioritásának beállításával biztosítod a konzisztens tipográfiát és elkerülöd a váratlan eredményeket.