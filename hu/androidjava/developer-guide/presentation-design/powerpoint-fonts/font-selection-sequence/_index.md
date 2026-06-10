---
title: Betűkészlet kiválasztási sorrend az Aspose.Slides for Android via Java esetén
linktitle: Betűkészlet kiválasztása
type: docs
weight: 80
url: /hu/androidjava/font-selection-sequence/
keywords:
- betűkészlet kiválasztása
- betűkészlet helyettesítése
- betűkészlet cseréje
- helyettesítési szabály
- elérhető betűkészlet
- hiányzó betűkészlet
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezd fel, hogyan választja ki az Aspose.Slides for Android via Java a betűkészleteket, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését—javítsd most diáidat."
---
## **Áttekintés**

Amikor egy prezentációt betöltenek, renderelnek vagy más formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűkészletek elérhetők-e az operációs rendszerben. Ha egy szükséges betűkészlet hiányzik, az Aspose.Slides egy helyettesítő betűkészletet választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először a kiválasztott betűkészletet keresi az operációs rendszerben. Ha megtalálja, azt használja. Ha nem találja, megfelelő helyettesítőt alkalmaz. Ha a betűkészlet helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, ezeket a szabályokat is figyelembe veszi.

Betűkészleteket is hozzáadhatsz az alkalmazás futási időben, használhatsz beágyazott betűkészleteket egy prezentációból, vagy betölthetsz külső betűkészleteket a kimeneti dokumentumokhoz, például PDF-fájlokhoz.

## **Betűkészlet kiválasztása**

Bizonyos szabályok érvényesek a prezentáció betűkészleteire, amikor a prezentációt betöltik, renderelik vagy más formátumba konvertálják. Például, amikor megpróbálsz egy prezentációt (a diákját) képekké konvertálni, a prezentáció betűkészleteit ellenőrzik, hogy a kiválasztott betűkészletek elérhetők-e az operációs rendszerben. Ha a betűkészletek hiányának megállapítása megtörténik, felcserélik őket — lásd [**Betűkészlet cseréje**](https://docs.aspose.com/slides/hu/androidjava/font-replacement/) és [**Betűkészlet helyettesítése**](https://docs.aspose.com/slides/hu/androidjava/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides követ a betűkészletekkel való munkavégzés során:

1. Az Aspose.Slides betűkészleteket keres az operációs rendszerben, hogy megtalálja a prezentáció által kiválasztott betűkészletnek megfelelő betűt. 
2. Ha a kiválasztott betűkészletet megtalálja, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy olyan helyettesítő betűkészletet használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha betűkészlet csere szabályok vannak beállítva a [FontSubstRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstrule/) segítségével, akkor azokat alkalmazzák.

Az Aspose.Slides lehetővé teszi, hogy betűkészleteket adj a futási időben az alkalmazáshoz, majd ezeket a betűkészleteket használd. Lásd [**Egyéni betűkészletek**](https://docs.aspose.com/slides/hu/androidjava/custom-font/).

Amikor további betűkészleteket helyeznek el egy prezentációban, ezeket [**Beágyazott betűkészletek**](https://docs.aspose.com/slides/hu/androidjava/embedded-font/)nek nevezik.

Az Aspose.Slides lehetővé teszi, hogy olyan betűkészleteket adj hozzá, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-re konvertálandó prezentáció olyan betűkészleteket tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűkészletekből, akkor a szükséges betűkészleteket **külső betűkészletekként** adhatsz hozzá vagy töltheted be.

{{% alert title="Note" color="primary" %}} 
Nem terjesztünk semmilyen betűkészletet, sem fizetettet, sem ingyenest. API-nk lehetővé teszi, hogy külső betűkészleteket tölts be és beágyazd őket a dokumentumokba, de ezt a betűkészleteket saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

**Hogyan tudom meghatározni, hogy mely betűkészletek vannak ténylegesen használatban egy prezentációban a konverzió előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [betűkészlet-kezelő](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/) segítségével megvizsgáld a használt betűkészleteket, így eldöntheted, hogy [beágyazod](/slides/hu/androidjava/embedded-font/), [lecseréled](/slides/hu/androidjava/font-replacement/) vagy hozzáadsz [külső forrásokat](/slides/hu/androidjava/custom-font/). Ez segít megakadályozni a nem kívánt helyettesítéseket a renderelés és az exportálás során.

**Hozzáadhatok extra betűkészlet-könyvtárakat anélkül, hogy telepíteném őket az operációs rendszeren?**

Igen. Regisztrálhatsz [külső betűkészlet-forrásokat](/slides/hu/androidjava/custom-font/), például mappákat vagy memóriafolyamokat a rendereléshez és az exportáláshoz. Ez eltávolítja a függőséget a gazda rendszer betűkészleteitől és a layoutot előreláthatóvá teszi.

**Hogyan előzhetem meg a csendes visszaesést egy nem megfelelő betűkészletre, amikor egy glif hiányzik?**

Határozz meg előre explicit [betűkészlet-cserét](/slides/hu/androidjava/font-replacement/) és betűkészlet [visszaesési szabályokat](/slides/hu/androidjava/fallback-font/). A használt betűkészletek elemzésével és a helyettesítők irányított prioritásának beállításával biztosíthatod a konzisztens tipográfiát és elkerülheted a váratlan eredményeket.