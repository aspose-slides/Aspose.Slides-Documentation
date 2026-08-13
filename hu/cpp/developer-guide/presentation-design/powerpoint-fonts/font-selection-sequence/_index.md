---
title: Betűtípus-kiválasztási sorrend az Aspose.Slides C++-ban
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
- bemutató
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides C++ a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését—javítsa most diáit."
---
## **Áttekintés**

Amikor egy bemutatót betöltenek, renderelnek vagy más formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a bemutatóban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keresi a kiválasztott betűtípust. Ha megtalálja, azt használja. Ha nem találja, egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus helyettesítési szabályokat a `FontSubstRule` segítségével definiálják, azokat is figyelembe veszi.

Betűtípusokat hozzáadhatsz az alkalmazás futási ideje alatt, használhatsz a bemutatóból származó beágyazott betűtípusokat, vagy betölthetsz külső betűtípusokat kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztás**

Bizonyos szabályok vonatkoznak a bemutató betűtípusaira, amikor a bemutatót betöltik, renderelik vagy más formátumba konvertálják. Például, ha megpróbálod a bemutatót (a diákját) képekké konvertálni, a bemutató betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők legyenek az operációs rendszerben. Ha a betűtípusok hiányának megállapítása megtörténik, helyettesítve lesznek – lásd [**Font Replacement**](https://docs.aspose.com/slides/hu/cpp/font-replacement/) és [**Font Substitution**](https://docs.aspose.com/slides/hu/cpp/font-substitution/).

Ez az a folyamat, amelyet az Aspose.Slides betűtípusok kezelésénél követ:

1. Az Aspose.Slides az operációs rendszerben keresi a betűtípusokat, hogy megtalálja a bemutató által választott betűtípusnak megfelelő betűtípust. 
2. Ha a választott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust alkalmaz, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha betűtípus helyettesítési szabályok vannak beállítva a [FontSubstRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstrule/) segítségével, azokat alkalmazzák. 

Az Aspose.Slides lehetővé teszi betűtípusok hozzáadását az alkalmazás futási ideje alatt, majd azok használatát. Lásd [**Custom fonts**](https://docs.aspose.com/slides/hu/cpp/custom-font/). 

Ha további betűtípusok kerülnek a bemutatóba, ezeket [**Embedded fonts**](https://docs.aspose.com/slides/hu/cpp/embedded-font/) hívják.

Az Aspose.Slides lehetővé teszi betűtípusok hozzáadását, amelyek csak a kimeneti dokumentumokra alkalmazandók. Például, ha egy PDF-re konvertálni kívánt bemutató olyan betűtípusokat tartalmaz, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, a szükséges betűtípusokat **external fonts**‑ként hozzáadhatod vagy betöltheted. 

{{% alert title="Megjegyzés" color="info" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetett, sem ingyenes formában. Az API-nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd őket a dokumentumokba, de ezt a betűtípusok saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

### Hogyan tudom meghatározni, mely betűtípusok vannak ténylegesen használatban egy bemutatóban a konverzió előtt?

Az Aspose.Slides lehetővé teszi a használt betűtípusok ellenőrzését a [font manager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) segítségével, így eldöntheted, hogy [beágyaz](/slides/hu/cpp/embedded-font/), [helyettesíts](/slides/hu/cpp/font-replacement/) vagy hozzáadj [külső források](/slides/hu/cpp/custom-font/) . Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és az export során.

### Hozzáadhatok extra betűtípus mappákat anélkül, hogy telepíteném őket az operációs rendszerre?

Igen. Regisztrálhatsz [külső betűtípus források](/slides/hu/cpp/custom-font/) például mappákat vagy memóriában lévő adatfolyamokat a rendereléshez és az exporthoz. Ez eltávolítja a függőséget a gazdaszámítógép betűtípusaival, és előre jelezhető elrendezést biztosít.

### Hogyan előzhetem meg a csendes visszaesést egy nem megfelelő betűtípusra, ha egy glif hiányzik?

Határozd meg előre a kifejezett [betűtípus helyettesítés](/slides/hu/cpp/font-replacement/) és a betűtípus [fallback szabályok](/slides/hu/cpp/fallback-font/) szabályait. Azáltal, hogy elemezed a használt betűtípusokat és szabályozott prioritást állítasz be a helyettesítőkre, biztosítod a konzisztens tipográfiát és elkerülöd a váratlan eredményeket.