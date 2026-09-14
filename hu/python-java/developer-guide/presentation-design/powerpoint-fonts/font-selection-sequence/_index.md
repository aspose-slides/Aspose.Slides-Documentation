---
title: Betűkészlet kiválasztási sorozat az Aspose.Slides-ban Python számára Java-n keresztül
linktitle: Betűkészlet kiválasztása
type: docs
weight: 80
url: /hu/python-java/font-selection-sequence/
keywords:
- betűkészlet kiválasztása
- betűkészlet helyettesítés
- betűkészlet csere
- helyettesítési szabály
- elérhető betűkészlet
- hiányzó betűkészlet
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides for Python via Java a betűkészleteket, biztosítva a tiszta, konzisztens megjelenítést PPT, PPTX és ODP fájlok esetén — javítsa most diáit."
---
## **Áttekintés**

Amikor egy bemutatót betöltenek, renderelnek vagy más formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a bemutatóban használt betűkészletek elérhetők-e az operációs rendszerben. Ha egy szükséges betűkészlet hiányzik, az Aspose.Slides egy helyettesítő betűkészletet választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keresi a kiválasztott betűkészletet. Ha a betűkészlet megtalálható, azt használja. Ha nem található, megfelelő helyettesítést alkalmaz. Ha a betűkészlet helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstrule/) segítségével vannak definiálva, azokat is figyelembe veszi.

Betűkészleteket is hozzáadhatsz az alkalmazás futási ideje alatt, használhatsz beágyazott betűkészleteket egy bemutatóból, vagy betölthetsz külső betűkészleteket a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűkészlet kiválasztása**

Bizonyos szabályok alkalmazandók a bemutató betűkészleteire, amikor a bemutatót betöltik, renderelik vagy más formátumba konvertálják. Például, amikor megpróbálod a bemutatót (diáit) képekké konvertálni, a bemutató betűkészleteit ellenőrzik, hogy a kiválasztott betűkészletek elérhetők-e az operációs rendszerben. Ha a betűkészletek hiányát megerősítik, helyettesítésre kerülnek – lásd a [Font Replacement](/slides/hu/python-java/font-replacement/) és a [Font Substitution](/slides/hu/python-java/font-substitution/) oldalakat.

Ez a folyamat, amelyet az Aspose.Slides a betűkészletekkel kapcsolatban követ:

1. Az Aspose.Slides az operációs rendszerben keres betűkészleteket, hogy megtalálja a bemutató által választott betűkészletnek megfelelő betűt.
2. Ha a választott betűkészlet megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűkészletet alkalmaz, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha betűkészlet helyettesítési szabályok lettek beállítva a [FontSubstRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstrule/) segítségével, azokat alkalmazzák.

Az Aspose.Slides lehetővé teszi, hogy betűkészleteket adj hozzá az alkalmazás futási ideje alatt, majd ezeket a betűkészleteket használd. Lásd a [Custom fonts](/slides/hu/python-java/custom-font/) oldalt.

Ha további betűkészleteket helyezel el egy bemutatóban, azokat [Embedded fonts](/slides/hu/python-java/embedded-font/) néven hívják.

Az Aspose.Slides lehetővé teszi, hogy betűkészleteket adj hozzá, amelyek *csak* a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF‑be konvertálni kívánt bemutató olyan betűkészleteket használ, amelyek sem a rendszeredben nincsenek telepítve, sem be vannak ágyazva a bemutatóba, akkor a szükséges betűkészleteket **külső betűkészletekként** adhatod hozzá vagy töltheted be.

{{% alert title="Note" color="info" %}}
Nem terjesztünk semmilyen betűkészletet, sem fizetős, sem ingyenes formában. API‑nk lehetővé teszi, hogy külső betűkészleteket tölts be és beágyazd őket a dokumentumokba, de ezt saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

**Hogyan tudom meghatározni, hogy mely betűkészletek vannak ténylegesen használatban egy bemutatóban a konvertálás előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) segítségével megvizsgáld a használt betűkészleteket, így eldöntheted, hogy [beágyazod](/slides/hu/python-java/embedded-font/), [helyettesíted](/slides/hu/python-java/font-replacement/) vagy hozzáadsz [külső forrásokat](/slides/hu/python-java/custom-font/). Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűkészlet‑könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerben?**

Igen. Regisztrálhatsz [külső betűkészlet forrásokat](/slides/hu/python-java/custom-font/), például mappákat vagy memóriában lévő adatfolyamokat a rendereléshez és exportáláshoz. Ez megszünteti a függőséget a gazda rendszer betűkészleteitől, és előre láthatóvá teszi a megjelenést.

**Hogyan akadályozhatom meg, hogy hiányzó glif esetén csendes visszaesés történjen egy nem megfelelő betűkészletre?**

Határozd meg előre a kifejezett [font replacement](/slides/hu/python-java/font-replacement/) és betűkészlet [fallback rules](/slides/hu/python-java/fallback-font/) szabályokat. A használt betűkészletek elemzésével és a helyettesítők kontrollált prioritásának beállításával biztosíthatod a konzisztens tipográfiát, és elkerülheted a nem várt eredményeket.