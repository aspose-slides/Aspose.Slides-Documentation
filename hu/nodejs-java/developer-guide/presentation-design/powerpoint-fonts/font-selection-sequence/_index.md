---
title: Betűtípus kiválasztási sorozat az Aspose.Slides Node.js (Java) számára
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/nodejs-java/font-selection-sequence/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides Node.js (Java) változata a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok éles és következetes megjelenítését – javítsa most diák minőségét."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, megjelenik vagy más formátumba konvertálódik, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Az Aspose.Slides először a kiválasztott betűtípust keresi az operációs rendszerben. Ha a betűtípus megtalálható, azt használja. Ha nem található, egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, azokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futási ideje alatt, használhatsz beágyazott betűtípusokat egy prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztása**

Néhány szabály vonatkozik a prezentáció betűtípusaira, amikor a prezentáció betöltődik, megjelenik vagy más formátumba konvertálódik. Például, ha egy prezentációt (diáit) képekké szeretnéd konvertálni, a prezentáció betűtípusait ellenőrizni kell, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megállapításra kerül, helyettesítésre kerülnek — lásd [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/nodejs-java/font-replacement/) és [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/nodejs-java/font-substitution/).

Az Aspose.Slides a betűtípusok kezelésénél az alábbi folyamatot követi:

1. Az Aspose.Slides a betűtípusokat az operációs rendszerben keresi, hogy megtalálja a prezentáció által választott betűtípussal megegyezőt. 
2. Ha a választott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust alkalmaz, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha a betűtípus helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstrule/) segítségével lettek beállítva, azokat alkalmazzák.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futási ideje alatt, majd használd őket. Lásd [**Egyedi betűtípusok**](https://docs.aspose.com/slides/hu/nodejs-java/custom-font/).

Ha további betűtípusok vannak beágyazva egy prezentációba, ezeket [**Beágyazott betűtípusok**](https://docs.aspose.com/slides/hu/nodejs-java/embedded-font/) nevezik.

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha a PDF‑re konvertálni kívánt prezentáció olyan betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusok közül is, akkor a szükséges betűtípusokat **külső betűtípusokként** adhatod hozzá vagy töltheted be.

{{% alert title="Note" color="primary" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetett, sem ingyenes. Az API-nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd őket dokumentumokba, de ezt a betűtípusok saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

**Hogyan tudom meghatározni, hogy mely betűtípusok vannak ténylegesen használatban egy prezentációban konvertálás előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [betűtípuskezelő](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getfontsmanager/) segítségével megvizsgáld a használt betűtípusokat, így eldöntheted, hogy [beágyazod](/slides/hu/nodejs-java/embedded-font/), [helyettesíted](/slides/hu/nodejs-java/font-replacement/) vagy [külső forrásokat adsz hozzá](/slides/hu/nodejs-java/custom-font/). Ez segít megelőzni a nem kívánt helyettesítéseket a megjelenítés és az export során.

**Hozzáadhatok extra betűtípus könyvtárakat a rendszer telepítése nélkül?**

Igen. Regisztrálhatsz [külső betűtípusforrásokat](/slides/hu/nodejs-java/custom-font/), például mappákat vagy memóriafolyamokat a megjelenítéshez és exporthoz. Ez eltávolítja a függőséget a gazda rendszer betűtípusaiktól, és előre láthatóvá teszi az elrendezést.

**Hogyan akadályozhatom meg a csendes visszalépést egy nem megfelelő betűtípusra, ha egy glif hiányzik?**

Definiálj előre explicit [betűtípus helyettesítést](/slides/hu/nodejs-java/font-replacement/) és betűtípus [fallback szabályokat](/slides/hu/nodejs-java/fallback-font/). A használt betűtípusok elemzésével és a helyettesítők szabályozott prioritásának beállításával biztosítod a konzisztens tipográfiát, és elkerülöd a váratlan eredményeket.