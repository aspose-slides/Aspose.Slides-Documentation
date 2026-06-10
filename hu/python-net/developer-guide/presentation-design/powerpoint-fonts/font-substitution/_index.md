---
title: "Python segítségével betűtípus helyettesítés beállítása a prezentációkban"
linktitle: "Betűtípus helyettesítés"
type: docs
weight: 70
url: /hu/python-net/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus helyettesítés
- betűtípus csere
- betűtípus csere
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Engedélyezze az optimális betűtípus helyettesítést az Aspose.Slides Python számára .NET-en keresztül, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi, hogy az Aspose.Slides egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem áll rendelkezésre a renderelés vagy a konverzió során. Ellenőrizheti, mely betűtípusok lettek helyettesítve a `FontsManager` osztály `get_substitutions` metódusának használatával.

Az Aspose.Slides lehetővé teszi, hogy betűtípus helyettesítési szabályokat definiáljon. Például megadhatja, hogy egy nem elérhető betűtípust egy másik elérhető betűtípusra cseréljen, és ezeket a szabályokat a prezentáció betűtípuskezelőjén keresztül alkalmazza.

## **Helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi, hogy betűtípusokra vonatkozó szabályokat állítson be, amelyek meghatározzák, mi teendő bizonyos feltételek esetén (például amikor egy betűtípus nem érhető el) a következő módon:

1. Töltsük be a megfelelő prezentációt.
2. Töltsük be a helyettesítendő betűtípust.
3. Töltsük be az új betűtípust.
4. Adjunk hozzá egy szabályt a helyettesítéshez.
5. Adjuk hozzá a szabályt a prezentáció betűtípus helyettesítési szabálygyűjteményéhez.
6. Generáljuk le a diaképet a hatás megfigyeléséhez.

Ez a Python kód bemutatja a betűtípus helyettesítési folyamatot:

```python
import aspose.slides as slides

# Betölt egy prezentációt
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Betölti a helyettesítendő forrás betűtípust
    sourceFont = slides.FontData("SomeRareFont")

    # Betölti az új betűtípust
    destFont = slides.FontData("Arial")

    # Hozzáad egy betűtípus szabályt a betűtípus cseréhez
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Hozzáadja a szabályt a betűtípus helyettesítési szabálygyűjteményhez
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Hozzáadja a betűtípus szabály gyűjteményt a szabálylistához
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial betűtípust a SomeRareFont helyett használja, ha az utóbbi nem érhető el
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Mentse a képet a lemezre JPEG formátumban
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni a [**Betűtípus helyettesítés**](/slides/hu/python-net/font-replacement/). 
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusok esetén**

A betűtípus helyettesítési szabályok részt vesznek a renderelés és konverzió során használt szabványos betűtípus kijelölési folyamatban. Alkalmazhatók a szokásos szöveg esetében, ahol az Aspose.Slides a beállított szabály szerint egy nem elérhető betűtípust egy másik elérhető betűtípusra cserél.

Azonban az Office matematikai egyenletek fontos korlátozással rendelkeznek. Ha egy egyenletet **Cambria Math** betűtípussal hoztak létre, az Aspose.Slides továbbra is a tényleges **Cambria Math** betűtípust igényelheti az egyenlet elrendezésének helyes kiszámításához és rendereléséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például a **STIX Two Math**-szal, nem támogatott az egyenlet renderelésében, és még mindig olyan kivételt eredményezhet, amely azt jelzi, hogy **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződjön meg arról, hogy a **Cambria Math** betűtípus elérhető az Aspose.Slides számára futásidőben. Telepítheti a betűtípust az operációs rendszerbe, vagy biztosíthatja azt [külső betűtípusként](/slides/hu/python-net/custom-font/), hogy részt vehessen a normál betűtípus kiválasztási folyamatban a renderelés és konverzió során.

Ez a korlátozás kifejezetten az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűtípus helyettesítési szabályok továbbra is érvényesek a normál prezentációszövegre, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípus csere és betűtípus helyettesítés között?**  
[Csere](/slides/hu/python-net/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikra cserél a teljes prezentációban. A helyettesítés egy olyan szabály, amely egy meghatározott feltétel esetén aktiválódik, például amikor az eredeti betűtípus nem elérhető, ekkor egy kijelölt tartalék betűtípust használ.

**Mikor pontosan alkalmazzák a helyettesítési szabályokat?**  
A szabályok részt vesznek a szabványos [betűtípus kiválasztás](/slides/hu/python-net/font-selection-sequence/) sorozatban, amely a betöltés, renderelés és konverzió során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a csere vagy helyettesítés alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem a csere, sem a helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**  
A könyvtár megpróbálja a legközelebbi elérhető rendszerbetűtípust választani, hasonlóan ahhoz, ahogy a PowerPoint viselkedne.

**Csatolhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**  
Igen. Futásidőben [külső betűtípusokat adhat hozzá](/slides/hu/python-net/custom-font/), így a könyvtár figyelembe veszi őket a kiválasztás és renderelés során, beleértve a későbbi konverziókat is.

**Terjeszt-e az Aspose bármilyen betűtípust a könyvtárral?**  
Nem. Az Aspose nem oszt meg fizetett vagy ingyenes betűtípusokat; Ön saját belátása és felelőssége szerint ad hozzá és használ betűtípusokat.

**Vannak-e különbségek a helyettesítési viselkedésben Windows, Linux és macOS rendszereken?**  
Igen. A betűtípusok felderítése az operációs rendszer betűtárkönyvtáraiból indul. Az alapértelmezett elérhető betűtípusok halmaza és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konverziók során?**  
Szinkronizálja a betűtípuskészletet a gépek vagy konténerek között, [adja hozzá a szükséges külső betűtípusokat](/slides/hu/python-net/custom-font/) a kimeneti dokumentumokhoz, és ahol lehetséges, [ágyazza be a betűtípusokat](/slides/hu/python-net/embedded-font/) a prezentációkba, hogy a kiválasztott betűtípusok elérhetők legyenek a renderelés során.