---
title: Betűtípus helyettesítés konfigurálása prezentációkban C++ használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/cpp/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus helyettesítés
- betűtípus cseréje
- betűtípus csere
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Engedélyezze az optimális betűtípus helyettesítést az Aspose.Slides C++-ban, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem érhető el renderelés vagy konvertálás során. Ellenőrizheti, mely betűtípusok lettek helyettesítve a `IFontsManager` interfész `GetSubstitutions` metódusával.

Az Aspose.Slides emellett lehetővé teszi betűtípus helyettesítési szabályok meghatározását. Például megadhatja, hogy egy nem elérhető betűtípust egy másik elérhető betűtípussal helyettesítsen, és ezeket a szabályokat a prezentáció betűtípus-kezelőjén keresztül alkalmazza.

## **Betűtípus helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi betűtípusokra vonatkozó szabályok beállítását, amelyek meghatározzák, mi történjen bizonyos feltételek esetén (például ha egy betűtípus nem érhető el) a következő módon:

1. Töltse be a megfelelő prezentációt.
2. Töltse be a helyettesítendő betűtípust.
3. Töltse be az új betűtípust.
4. Adjon hozzá egy szabályt a helyettesítéshez.
5. Adja hozzá a szabályt a prezentáció betűtípus helyettesítési szabálygyűjteményéhez.
6. Generálja le a dia képet a hatás megfigyeléséhez.

Ez a C++ kód bemutatja a betűtípus helyettesítési folyamatot:

```c++
// Az dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Betölti a prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Meghatározza a helyettesítendő betűtípust és az új betűtípust
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Hozzáad egy betűtípus szabályt a betűtípus cseréhez
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Hozzáadja a szabályt a betűtípus helyettesítési szabályok gyűjteményéhez
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Hozzáadja a betűtípus szabálygyűjteményt a szabálygyűjteményhez
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Mentés PPTX fájlként a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni a [**Betűtípus csere**](/slides/hu/cpp/font-replacement/) oldalt. 
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusok esetén**

A betűtípus helyettesítési szabályok részt vesznek a renderelés és konvertálás során használt szabványos betűtípus kiválasztási folyamatban. Alkalmazhatók a szokásos szöveges helyzetekben, ahol az Aspose.Slides a konfigurált szabály szerint egy nem elérhető betűtípust egy másik elérhető betűtípussal helyettesíthet.

Az Office matematikai egyenleteknél azonban fontos korlátozás van. Ha egy egyenletet **Cambria Math** betűtípussal hoztak létre, az Aspose.Slides továbbra is igényelheti az eredeti **Cambria Math** betűtípust az egyenlet elrendezésének helyes kiszámításához és rendereléséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például **STIX Two Math**-szal, nem támogatott az egyenlet rendereléséhez, és továbbra is olyan kivételt eredményezhet, amely jelzi, hogy **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződjön meg róla, hogy a **Cambria Math** betűtípus elérhető az Aspose.Slides számára futásidőben. A betűtípust telepítheti a operációs rendszerbe, vagy biztosíthatja [külső betűtípusként](/slides/hu/cpp/custom-font/), hogy részt vehessen a normál betűtípus kiválasztási folyamatban renderelés és konvertálás során.

Ez a korlátozás kifejezetten az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűtípus helyettesítési szabályok továbbra is alkalmazandók a normál prezentációs szövegre, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

[Replacement](/slides/hu/cpp/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikkal helyettesít az egész prezentációban. A helyettesítés egy olyan szabály, amely egy adott feltétel esetén lép életbe, például amikor az eredeti betűtípus nem érhető el, ekkor egy meghatározott tartalék betűtípust használ.

**Mikor alkalmazzák pontosan a helyettesítési szabályokat?**

A szabályok részt vesznek a szabványos [betűtípus kiválasztás](/slides/hu/cpp/font-selection-sequence/) sorozatban, amely a betöltés, renderelés és konvertálás során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a csere vagy helyettesítés alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem csere, sem helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**

A könyvtár megpróbálja kiválasztani a legközelebbi elérhető rendszerbetűtípust, hasonlóan ahhoz, ahogy a PowerPoint is működik.

**Csatolhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülésére?**

Igen. Futásidőben [hozzáadhat külső betűtípusokat](/slides/hu/cpp/custom-font/), hogy a könyvtár figyelembe vegye őket a kiválasztás és renderelés során, beleértve a későbbi konvertálásokat is.

**Terjeszt-e az Aspose bármilyen betűtípust a könyvtárral?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata a saját belátásán és felelősségén múlik.

**Vannak-e különbségek a helyettesítés viselkedésében Windows, Linux és macOS rendszereken?**

Igen. A betűtípusok felderítése az operációs rendszer betűtár könyvtáraiból indul. Az alapértelmezett elérhető betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konvertálás során?**

Szinkronizálja a betűtárkészletet a gépek vagy konténerek között, [adjon hozzá a szükséges külső betűtípusokat](/slides/hu/cpp/custom-font/) a kimeneti dokumentumokhoz, és [ágyazza be a betűtípusokat](/slides/hu/cpp/embedded-font/) a prezentációkba, ha lehetséges, hogy a kiválasztott betűtípusok a renderelés során elérhetők legyenek.