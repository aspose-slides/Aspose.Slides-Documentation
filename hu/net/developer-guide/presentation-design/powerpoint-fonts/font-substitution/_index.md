---
title: Betűtípus helyettesítés beállítása prezentációkban .NET-ben
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Engedélyezze az optimális betűtípus helyettesítést az Aspose.Slides .NET-ben, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi, hogy az Aspose.Slides egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem érhető el a renderelés vagy konvertálás során. A helyettesített betűtípusok listáját a `GetSubstitutions` metódus segítségével ellenőrizheti az `IFontsManager` interfészen.

Az Aspose.Slides továbbá lehetővé teszi betűtípus helyettesítési szabályok meghatározását. Például megadhatja, hogy egy nem elérhető betűtípust egy másik elérhető betűtípussal helyettesítsen, majd ezeket a szabályokat a prezentáció betűtípus-kezelőjén keresztül alkalmazza.

## **Betűtípus helyettesítések lekérése**

Annak érdekében, hogy megtudja, mely prezentációs betűtípusok kerülnek helyettesítésre a renderelés során, az Aspose.Slides a [GetSubstitution](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getsubstitutions/) metódust kínálja az [IFontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/) interfészen keresztül.

A C# kód bemutatja, hogyan lehet lekérni az összes betűtípus helyettesítést, amely egy prezentáció renderelésekor végrehajtásra kerül:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Betűtípus helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi a betűtípusok szabályainak beállítását, amelyek meghatározzák, mi történjen bizonyos feltételek esetén (például amikor egy betűtípus nem érhető el), a következő módon:

1. Töltse be a megfelelő prezentációt.
2. Töltse be a helyettesítendő betűtípust.
3. Töltse be az új betűtípust.
4. Adjon hozzá egy szabályt a helyettesítéshez.
5. Adja hozzá a szabályt a prezentáció betűtípus helyettesítési szabálykészletéhez.
6. Generáljon dia képet a hatás megfigyeléséhez.

Ez a C# kód bemutatja a betűtípus helyettesítési folyamatot:
```c#
// Betölt egy prezentációt
Presentation presentation = new Presentation("Fonts.pptx");

// Betölti a forrás betűtípust, amelyet fel kell cserélni
IFontData sourceFont = new FontData("SomeRareFont");

// Betölti az új betűtípust
IFontData destFont = new FontData("Arial");

// Hozzáad egy betűtípus szabályt a betűtípus cseréhez
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Hozzáadja a szabályt a betűtípus helyettesítési szabályok gyűjteményéhez
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Hozzáadja a betűtípus szabálygyűjteményt a szabálylistához
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Mentse a képet a lemezre JPEG formátumban
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni a [**Betűtípus csere**](/slides/hu/net/font-replacement/) oldalt. 
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra**

A betűtípus helyettesítési szabályok részt vesznek a renderelés és konvertálás során használt szabványos betűtípus-kiválasztási folyamatban. Alkalmasak a szokásos szöveges helyzetekre, ahol az Aspose.Slides a konfigurált szabály alapján egy nem elérhető betűtípust egy másik elérhető betűtípussal helyettesíthet.

Azonban az Office matematikai egyenletek fontos korlátozással rendelkeznek. Ha egy egyenletet **Cambria Math** betűtípussal hoztak létre, az Aspose.Slides továbbra is igényelheti az eredeti **Cambria Math** betűtípust az egyenlet elrendezésének helyes kiszámításához és rendereléséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például a **STIX Two Math**‑szal, nem támogatott az egyenlet renderelése során, és továbbra is előfordulhat, hogy kivétel keletkezik, jelezve, hogy **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződjön meg róla, hogy a **Cambria Math** betűtípus elérhető az Aspose.Slides számára futásidőben. A betűtípust telepítheti az operációs rendszerbe, vagy biztosíthatja [külső betűtípusként](/slides/hu/net/custom-font/), hogy részt vegyen a normál betűtípus-kiválasztási folyamatban a renderelés és konvertálás során.

Ez a korlátozás kifejezetten az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűtípus helyettesítési szabályok továbbra is érvényesek a normál prezentációs szövegre, ha az eredeti betűtípus nem elérhető.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

[Replacement](/slides/hu/net/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikkal helyettesít az egész prezentációban. A helyettesítés egy szabály, amely egy adott feltétel esetén aktiválódik, például amikor az eredeti betűtípus nem áll rendelkezésre, ekkor egy meghatározott tartalék betűtípust használ.

**Mikor alkalmazzák pontosan a helyettesítési szabályokat?**

A szabályok részt vesznek a szabványos [betűtípus kiválasztási](/slides/hu/net/font-selection-sequence/) sorozatban, amely a betöltés, renderelés és konvertálás során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a csere vagy helyettesítés alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem csere, sem helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszerből?**

A könyvtár megpróbálja a legközelebbi elérhető rendszerbetűtípust kiválasztani, hasonlóan ahhoz, ahogy a PowerPoint viselkedik.

**Csatolhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülésére?**

Igen. Futásidőben [külső betűtípusokat adhat hozzá](/slides/hu/net/custom-font/), így a könyvtár figyelembe veszi őket a kiválasztás és renderelés során, beleértve a későbbi konvertálásokat is.

**Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral együtt?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata a saját belátásán és felelősségén múlik.

**Vannak-e eltérések a helyettesítés viselkedésében Windows, Linux és macOS rendszereken?**

Igen. A betűtípus-felfedezés az operációs rendszer betűtárakból indul. Az alapértelmezett elérhető betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimálisra csökkentsem a váratlan helyettesítéseket kötegelt konvertálások során?**

Szinkronizálja a betűtípus-készletet a gépek vagy konténerek között, [adja hozzá a szükséges külső betűtípusokat](/slides/hu/net/custom-font/) a kimeneti dokumentumokhoz, és ahol lehetséges, [ágyazza be a betűtípusokat](/slides/hu/net/embedded-font/) a prezentációkba, hogy a kiválasztott betűtípusok a renderelés során rendelkezésre álljanak.