---
title: Betűtípus kiválasztási sorrend az Aspose.Slides for .NET-ben
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides for .NET a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését – javítsa most diáinak minőségét."
---
## **Áttekintés**

Amikor egy prezentációt betölt, renderel vagy egy másik formátumba konvertál, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keres a kiválasztott betűtípus után. Ha a betűtípus megtalálható, azt használja. Ha nem található, egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus-helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, ezeket a szabályokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futásidejében, használhatsz beágyazott betűtípusokat a prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztás**

Bizonyos szabályok vonatznak a prezentáció betűtípusaira, amikor a prezentációt betöltik, renderelik vagy egy másik formátumba konvertálják. Például, amikor egy prezentációt (a diákját) képekké próbálod konvertálni, a prezentáció betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megállapítása megtörténik, helyettesítik őket — lásd [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/net/font-replacement/) és [**Betűtípus szubsztitúció**](https://docs.aspose.com/slides/hu/net/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides a betűtípusok kezelésénél követ:

1. Az Aspose.Slides az operációs rendszerben keres betűtípusokat, hogy megtalálja a prezentáció által kiválasztott betűtípusnak megfelelő betűtípust.  
2. Ha a kiválasztott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.  
3. Ha a betűtípus helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstrule/) segítségével lettek beállítva, akkor alkalmazásra kerülnek.  

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futásidejében, majd azokat használd. Lásd [**Egyéni betűtípusok**](https://docs.aspose.com/slides/hu/net/custom-font/).  

Amikor további betűtípusok vannak beágyazva a prezentációba, ezeket [**Beágyazott betűtípusoknak**](https://docs.aspose.com/slides/hu/net/embedded-font/) hívják.  

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-re konvertálandó prezentációban olyan betűtípusok vannak, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, hozzáadhatod vagy betöltheted a szükséges betűtípusokat **külső betűtípusokként**.

{{% alert title="Note" color="info" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetettet, sem ingyeneset. Az API-nk lehetővé teszi külső betűtípusok betöltését és dokumentumokba ágyazását, de ezt saját belátásod és felelősséged szerint kell megtenned.
{{% /alert %}}

## **GYIK**

### Hogyan határozhatom meg, mely betűtípusok vannak ténylegesen használatban egy prezentációban a konvertálás előtt?

Az Aspose.Slides lehetővé teszi, hogy a [betűtípuskezelő](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) segítségével ellenőrizd a használt betűtípusokat, így eldöntheted, hogy [beágyazod](/slides/hu/net/embedded-font/), [helyettesíted](/slides/hu/net/font-replacement/) vagy hozzáadsz [külső forrásokat](/slides/hu/net/custom-font/). Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és exportálás során.

### Hozzáadhatok extra betűtípus-könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerben?

Igen. Regisztrálhatsz [külső betűtípus forrásokat](/slides/hu/net/custom-font/), például mappákat vagy memóriafolyamokat a rendereléshez és exportáláshoz. Ez eltávolítja a függőséget a gazda rendszer betűtípusaitól, és az elrendezést kiszámíthatóvá teszi.

### Hogyan akadályozhatom meg, hogy egy hiányzó glif esetén csendes visszaesés egy nem megfelelő betűtípusra történjen?

Egyértelműen határozz meg előre [betűtípus helyettesítést](/slides/hu/net/font-replacement/) és betűtípus [fallback szabályokat](/slides/hu/net/fallback-font/). Azáltal, hogy elemezed a használt betűtípusokat és szabályozott prioritást állítasz be a helyettesítőkre, biztosítod a konzisztens tipográfiát és elkerülöd a váratlan eredményeket.