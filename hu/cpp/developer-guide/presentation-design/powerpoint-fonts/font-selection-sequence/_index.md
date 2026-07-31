---
title: Betűtípus-kiválasztási sorozat az Aspose.Slides C++ számára
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
description: "Fedezze fel, hogyan választja ki az Aspose.Slides C++ a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok tiszta, következetes megjelenítését - javítsa most diáidat."
---
## **Áttekintés**

Amikor egy bemutatót betöltenek, renderelnek vagy egy másik formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a bemutatóban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keresi a kiválasztott betűtípust. Ha megtalálja, azt használja. Ha nem találja, megfelelő helyettesítőt alkalmaz. Ha a betűtípus helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, ezeket a szabályokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futásidejében, használhatod a bemutatóból származó beágyazott betűtípusokat, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztás**

Bizonyos szabályok vonatkoznak a bemutató betűtípusaira, amikor a bemutatót betöltik, renderelik vagy egy másik formátumba konvertálják. Például, amikor megpróbálod a bemutatót (a diákját) képekké konvertálni, a bemutató betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megállapításra kerül, helyettesítésre kerülnek – lásd [**Betűtípus csere**](https://docs.aspose.com/slides/hu/cpp/font-replacement/) és [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/cpp/font-substitution/).

Az alábbi folyamatot követi az Aspose.Slides a betűtípusok kezelésénél:

1. Az Aspose.Slides keres a betűtípusok között az operációs rendszerben, hogy megtalálja a bemutató által kiválasztott betűtípussal megegyező betűtípust.  
2. Ha a kiválasztott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.  
3. Ha betűtípus helyettesítési szabályok lettek beállítva a [FontSubstRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstrule/) segítségével, azok alkalmazásra kerülnek.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futásidejéhez, majd használd őket. Lásd [**Egyedi betűtípusok**](https://docs.aspose.com/slides/hu/cpp/custom-font/).

Amikor további betűtípusok kerülnek a bemutatóba, azokat [**Beágyazott betűtípusok**](https://docs.aspose.com/slides/hu/cpp/embedded-font/)-nek hívják.

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-re konvertálni kívánt bemutató betűtípusai hiányoznak a rendszeredből és a beágyazott betűtípusok közül is, a szükséges betűtípusokat **külső betűtípusokként** adhatod hozzá vagy töltheted be.

{{% alert title="Note" color="primary" %}} 
Nincs jogaid között bármilyen betűtípust terjeszteni, sem fizetett, sem ingyenes. API‑nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd őket a dokumentumokba, de ezt a betűtípusokkal saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

**Hogyan határozhatom meg, hogy mely betűtípusok vannak ténylegesen használatban egy bemutatóban konverzió előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) segítségével megtekintsd a használt betűtípusokat, így eldöntheted, hogy [beágyazod](/slides/hu/cpp/embedded-font/), [cseréled](/slides/hu/cpp/font-replacement/) vagy [külső forrásokat adsz hozzá](/slides/hu/cpp/custom-font/). Ez segít megakadályozni a nem kívánt helyettesítéseket a renderelés és az exportálás során.

**Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhatsz [külső betűtípus forrásokat](/slides/hu/cpp/custom-font/), például mappákat vagy memóriafolyamokat a rendereléshez és exportáláshoz. Ez megszünteti a függőséget a gazdarendszer betűtípusaival és előre láthatóvá teszi a kiosztást.

**Hogyan akadályozhatom meg, hogy hiányzó glif esetén csendes visszaesés egy nem megfelelő betűtípusra történjen?**

Határozz meg előre explicit [betűtípus csere](/slides/hu/cpp/font-replacement/) és betűtípus [fallback szabályokat](/slides/hu/cpp/fallback-font/). Az használt betűtípusok elemzésével és helyettesítők szabályozott prioritásának beállításával biztosítod a konzisztens tipográfiát és elkerülöd a váratlan eredményeket.