---
title: Betűtípus kiválasztási sorozat az Aspose.Slides for Android via Java-ban
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki a betűtípusokat az Aspose.Slides for Android Java használatával, biztosítva a PPT, PPTX és ODP fájlok tiszta, konzisztens megjelenítését – javítsa most diái minőségét."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűtípusok elérhetők-e az operációs rendszerben. Ha egy szükséges betűtípus hiányzik, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amelyet a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keres a kiválasztott betűtípus után. Ha a betűtípus megtalálható, akkor azt használja. Ha nem található, akkor egy megfelelő helyettesítőt alkalmaz. Ha a betűtípus helyettesítési szabályok a `FontSubstRule` segítségével vannak definiálva, akkor ezeket a szabályokat is figyelembe veszi.

Betűtípusokat is hozzáadhatsz az alkalmazás futási ideje alatt, használhatsz beágyazott betűtípusokat egy prezentációból, vagy betölthetsz külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztása**

Bizonyos szabályok vonatznak a prezentációban lévő betűtípusokra, amikor a prezentáció betöltődik, renderelődik vagy más formátumba konvertálódik. Például, amikor egy prezentációt (a diait) képekké próbálod konvertálni, a prezentáció betűtípusait ellenőrzik, hogy a kiválasztott betűtípusok elérhetők-e az operációs rendszerben. Ha a betűtípusok hiányának megerősítése megtörtént, helyettesítik őket – lásd [**Betűtípus csere**](https://docs.aspose.com/slides/hu/androidjava/font-replacement/) és [**Betűtípus helyettesítés**](https://docs.aspose.com/slides/hu/androidjava/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides a betűtípusok kezelése során követ:

1. Az Aspose.Slides az operációs rendszerben keres betűtípusokat, hogy megtalálja a prezentáció által kiválasztott betűtípusnak megfelelőt. 
2. Ha a kiválasztott betűtípus megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűtípust alkalmaz, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna. 
3. Ha a betűtípus helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstrule/) segítségével lettek beállítva, akkor alkalmazásra kerülnek.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adj hozzá az alkalmazás futási idejéhez, majd ezeket használd. Lásd [**Egyedi betűtípusok**](https://docs.aspose.com/slides/hu/androidjava/custom-font/).

Amikor további betűtípusok vannak egy prezentációban, ezt a [**Beágyazott betűtípusoknak**](https://docs.aspose.com/slides/hu/androidjava/embedded-font/) hívják.

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adj hozzá, amelyek *csak* kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-re konvertálni kívánt prezentációban olyan betűtípusok vannak, amelyek hiányoznak a rendszeredből és a beágyazott betűtípusokból, a szükséges betűtípusokat **külső betűtípusokként** adhatod hozzá vagy töltheted be.

{{% alert title="Note" color="info" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetős, sem ingyenes. Az API-nk lehetővé teszi, hogy külső betűtípusokat tölts be és beágyazd őket a dokumentumokba, de ezt saját belátásod és felelősséged szerint teszed.
{{% /alert %}}

## **GYIK**

### Hogyan határozhatom meg, hogy mely betűtípusok valóban használtak egy prezentációban a konvertálás előtt?

Az Aspose.Slides lehetővé teszi, hogy a [font manager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/) segítségével megvizsgáld a használt betűtípusokat, így eldöntheted, hogy [beágyazd](/slides/hu/androidjava/embedded-font/), [cseréld](/slides/hu/androidjava/font-replacement/) vagy [külső forrásokat adj hozzá](/slides/hu/androidjava/custom-font/). Ez segít megelőzni a nem kívánt helyettesítéseket a renderelés és exportálás során.

### Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?

Igen. Regisztrálhatsz [külső betűtípus forrásokat](/slides/hu/androidjava/custom-font/) olyan mappákként vagy memóriában tárolt adatfolyamokként a rendereléshez és exportáláshoz. Ez megszünteti a függőséget a gazdarendszer betűtípusaitól és előre láthatóvá teszi az elrendezést.

### Hogyan akadályozhatom meg a néma visszaesést egy nem megfelelő betűtípusra, ha egy glif hiányzik?

Határozz meg előre explicit [betűtípus cserét](/slides/hu/androidjava/font-replacement/) és betűtípus [visszaesési szabályokat](/slides/hu/androidjava/fallback-font/). A használt betűtípusok elemzésével és a helyettesítők kontrollált prioritásának beállításával biztosítod a következetes tipográfiát és elkerülöd a váratlan eredményeket.