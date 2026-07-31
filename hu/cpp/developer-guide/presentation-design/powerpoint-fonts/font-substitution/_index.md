---
title: Betűtípus helyettesítés beállítása prezentációkban C++ használatával
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
- cserélési szabály
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides C++ számára optimális betűtípus helyettesítést tesz lehetővé, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Áttekintés**

A betűtípushelyettesítés lehetővé teszi, hogy az Aspose.Slides egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem áll rendelkezésre a megjelenítés vagy a konvertálás során. Megtekintheted, mely betűtípusok lettek helyettesítve a `IFontsManager` interfész `GetSubstitutions` metódusával.

Az Aspose.Slides lehetővé teszi a betűtípushelyettesítési szabályok meghatározását is. Például megadhatod, hogy egy nem hozzáférhető betűtípust egy másik elérhető betűtípusra cseréljen, majd ezeket a szabályokat a prezentáció betűtípus-kezelőjén keresztül alkalmazhatod.

## **Betűtípushelyettesítési szabályok beállítása**

Az Aspose.Slides úgy teszi lehetővé a betűtípusokra vonatkozó szabályok megadását, hogy meghatározza, mi történjen bizonyos feltételek esetén (például, ha egy betűtípus nem érhető el) a következő módon:

1. Töltsd be a megfelelő prezentációt.  
2. Töltsd be a helyettesítendő betűtípust.  
3. Töltsd be az új betűtípust.  
4. Adj hozzá egy szabályt a helyettesítéshez.  
5. Add hozzá a szabályt a prezentáció betűtípus‑csereszabály‑gyűjteményéhez.  
6. Generáld le a dia képet, hogy megfigyeld a hatást.

Ez a C++ kód bemutatja a betűtípushelyettesítési folyamatot:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Betölti a prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Meghatározza a helyettesítendő betűtípust és az új betűtípust
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Betűtípuscsere szabályt ad hozzá
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// A szabályt hozzáadja a betűtípus helyettesítési szabályok gyűjteményéhez
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// A betűtípus szabálygyűjteményt hozzáadja a szabálylistához
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Mentés PPTX fájlként a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Érdemes megnézni a [**Betűtípuscsere**](/slides/hu/cpp/font-replacement/). 

{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípushelyettesítési szabályok részt vesznek a szabványos betűtípus‑kiválasztási folyamatban, amely a megjelenítés és a konvertálás során használatos. Ezek a szabályok megfelelőek a normál szöveges esetekhez, ahol az Aspose.Slides egy hozzáférhetetlen betűtípust egy másik elérhető betűtípusra cserél a konfigurált szabály szerint.

Az Office matematikai egyenletek azonban fontos korlátozással bírnak. Ha egy egyenletet **Cambria Math**‑sal hoztak létre, az Aspose.Slides még mindig a **Cambria Math** eredeti betűtípusra támaszkodhat az egyenlet elrendezésének helyes kiszámításához és megjelenítéséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például **STIX Two Math**‑szal, nem támogatott az egyenletek renderelése során, és továbbra is olyan kivételt eredményezhet, amely jelzi, hogy a **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához biztosítsd, hogy a **Cambria Math** elérhető legyen az Aspose.Slides számára futásidőben. Telepítheted a betűtípust az operációs rendszerbe, vagy megadhatsz egy [külső betűtípust](/slides/hu/cpp/custom-font/), hogy részt vehessen a normál betűtípus‑kiválasztási folyamatban a megjelenítés és a konvertálás során.

Ez a korlátozás kifejezetten az egyenlet‑renderelésre vonatkozik. A fent leírt szabványos betűtípushelyettesítési szabályok továbbra is érvényesek a prezentáció normál szövegeire, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípuscsere és a betűtípushelyettesítés között?**

[Replacement](/slides/hu/cpp/font-replacement/) egy kényszerített felülírás, amely az egyik betűtípust egy másikra cseréli a teljes prezentációban. A helyettesítés egy szabály, amely egy adott feltétel esetén aktiválódik, például amikor az eredeti betűtípus nem áll rendelkezésre, ekkor egy kijelölt tartalék betűtípust használ.

**Mikor alkalmazzák pontosan a helyettesítési szabályokat?**

A szabályok részt vesznek a szabványos [font selection](/slides/hu/cpp/font-selection-sequence/) sorozatban, amely a betöltés, a renderelés és a konvertálás során kiértékelődik; ha a kiválasztott betűtípus nem érhető el, a cserét vagy helyettesítést alkalmazzák.

**Mi a viselkedés alapértelmezés szerint, ha sem a csere, sem a helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**

A könyvtár megpróbálja a legközelebbi elérhető rendszer‑betűtípust választani, hasonlóan ahhoz, ahogy a PowerPoint viselkedik.

**Csatolhatok saját külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**

Igen. A [külső betűtípusok](/slides/hu/cpp/custom-font/) hozzáadhatók futásidőben, így a könyvtár azok figyelembevételével választhat és renderelhet, beleértve a későbbi konvertálásokat is.

**Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata a felhasználó saját belátása és felelőssége.

**Vannak-e különbségek a helyettesítés viselkedésében Windows, Linux és macOS rendszereken?**

Igen. A betűtípus‑felderítés az operációs rendszer betűtár könyvtáraiból indul. Az elérhető alapértelmezett betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készíthetem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konvertálások során?**

Szinkronizáld a betűtípus‑készletet a gépek vagy konténerek között, [add hozzá a szükséges külső betűtípusokat](/slides/hu/cpp/custom-font/), és ahol lehetséges, [ágyazz be betűtípusokat](/slides/hu/cpp/embedded-font/) a prezentációkba, hogy a választott betűtípusok a renderelés során elérhetők legyenek.