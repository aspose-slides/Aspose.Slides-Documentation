---
title: Betűkészlet kiválasztási sorrend az Aspose.Slides for .NET-ben
linktitle: Betűkészlet kiválasztás
type: docs
weight: 80
url: /hu/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki a betűkészleteket az Aspose.Slides for .NET, biztosítva a tiszta, következetes PPT, PPTX és ODP fájlok megjelenítését – javítsa diákját most."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűkészletek elérhetők-e az operációs rendszerben. Ha egy szükséges betűkészlet hiányzik, az Aspose.Slides egy helyettesítő betűkészletet választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keres a kiválasztott betűkészlet után. Ha a betűkészlet megtalálható, azt használja. Ha nem található, megfelelő helyettesítő kerül alkalmazásra. Ha a betűkészlet helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, azokat is figyelembe veszi.

Betűkészleteket is hozzáadhat alkalmazás futási időben, használhat beágyazott betűkészleteket egy prezentációból, vagy betölthet külső betűkészleteket a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűkészlet kiválasztás**

Bizonyos szabályok vonatznak a prezentáció betűkészleteire, amikor a prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik. Például, ha megpróbálja a prezentációt (a diákat) képekké konvertálni, a prezentáció betűkészleteit ellenőrzik, hogy a kiválasztott betűkészletek elérhetők legyenek az operációs rendszerben. Ha a betűkészletek hiányának megerősítése megtörténik, helyettesítésre kerülnek — lásd [**Font Replacement**](https://docs.aspose.com/slides/hu/net/font-replacement/) és [**Font Substitution**](https://docs.aspose.com/slides/hu/net/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides követ a betűkészletekkel kapcsolatban:

1. Az Aspose.Slides betűkészleteket keres az operációs rendszerben, hogy megtalálja a prezentáció által választott betűkészletnek megfelelő betűt. 
2. Ha a kiválasztott betűkészlet megtalálható, az Aspose.Slides használja azt. Ellenkező esetben az Aspose.Slides egy helyettesítő betűkészletet használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha a betűkészlet helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstrule/) segítségével lettek beállítva, akkor azokat alkalmazzák. 

Az Aspose.Slides lehetővé teszi betűkészletek hozzáadását az alkalmazás futási idejére, és ezek használatát. Lásd [**Custom fonts**](https://docs.aspose.com/slides/hu/net/custom-font/). 

Ha további betűkészletek egy prezentációban vannak elhelyezve, ezeket [**Embedded fonts**](https://docs.aspose.com/slides/hu/net/embedded-font/) nevezik.

Az Aspose.Slides lehetővé teszi olyan betűkészletek hozzáadását, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-be konvertálni kívánt prezentáció betűkészletei hiányoznak a rendszeréből és a beágyazott betűkészletekből, a szükséges betűkészleteket **external fonts**‑ként adhatja hozzá vagy töltheti be. 

{{% alert title="Note" color="primary" %}} 
Nem terjesztünk semmilyen betűkészletet, legyen az fizetős vagy ingyenes. API‑nk lehetővé teszi a külső betűkészletek betöltését és azok dokumentumokba való beágyazását, de ezt saját belátás és felelősség szerint kell megtennie.
{{% /alert %}}

## **GYIK**

**Hogyan határozhatom meg, hogy mely betűkészletek vannak ténylegesen használatban egy prezentációban a konvertálás előtt?**

Az Aspose.Slides lehetővé teszi a használt betűkészletek megtekintését a [font manager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) segítségével, így eldöntheti, hogy [embed](/slides/hu/net/embedded-font/)-t, [replace](/slides/hu/net/font-replacement/)-t vagy [external sources](/slides/hu/net/custom-font/)-t szeretne-e használni. Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűkészlet-könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhat [external font sources](/slides/hu/net/custom-font/) könyvtárakat vagy memóriában lévő adatfolyamokat a rendereléshez és exportáláshoz. Ez eltávolítja a függőséget a gazda rendszer betűkészleteitől és előreláthatóvá teszi az elrendezést.

**Hogyan előzhetem meg, hogy egy hiányzó glif esetén csendes visszaesés történjen egy nem megfelelő betűkészletre?**

Előzetesen definiáljon explicit [font replacement](/slides/hu/net/font-replacement/) és betűkészlet [fallBack rules](/slides/hu/net/fallback-font/) szabályokat. Azáltal, hogy elemezi a használt betűkészleteket és szabályozott prioritást állít be a helyettesítőkre, biztosítja a konzisztens tipográfiát és elkerüli a váratlan eredményeket.