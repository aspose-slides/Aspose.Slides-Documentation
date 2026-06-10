---
title: Betűkészlet helyettesítés konfigurálása prezentációkban Androidon
linktitle: Betűkészlet helyettesítés
type: docs
weight: 70
url: /hu/androidjava/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűkészlet helyettesítés
- betűtípus cseréje
- betűkészlet csere
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Engedélyezze az optimális betűkészlet helyettesítést az Aspose.Slides Android verzióban Java segítségével, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Áttekintés**

A betűkészlet helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem érhető el a megjelenítés vagy a konvertálás során. Megnézheted, mely betűkészletek lettek helyettesítve a `IFontsManager` interfész `getSubstitutions` metódusának használatával.

Az Aspose.Slides továbbá lehetővé teszi betűkészlet helyettesítési szabályok megadását. Például megadhatod, hogy egy nem elérhető betűtípus helyettesítve legyen egy másik elérhető betűtípussal, majd ezeket a szabályokat a prezentáció betűkészlet-kezelőjén keresztül alkalmazhatod.

## **Betűkészlet helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi betűtípusok szabályainak beállítását, amelyek meghatározzák, hogy bizonyos feltételek mellett (például ha egy betűtípust nem lehet elérni) mi a teendő, a következő módon:

1. Töltsd be a megfelelő prezentációt.
2. Töltsd be a helyettesítendő betűtípust.
3. Töltsd be az új betűtípust.
4. Adj hozzá egy szabályt a helyettesítéshez.
5. Add hozzá a szabályt a prezentáció betűkészlet helyettesítési szabálykészletéhez.
6. Generálj diaképet a hatás megfigyeléséhez.

Ez a Java kód bemutatja a betűkészlet helyettesítési folyamatot:

```java
// Betölt egy prezentációt
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Betölti a forrás betűtípust, amelyet helyettesíteni fognak
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Betölti az új betűtípust
    IFontData destFont = new FontData("Arial");
    
    // Hozzáad egy betűtípusszabályt a betűcseréhez
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Hozzáadja a szabályt a betűkészlet helyettesítési szabálygyűjteményhez
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Hozzáad egy betűtípusszabály-gyűjteményt a szabálistáshoz
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Az Arial betűtípus lesz használva a SomeRareFont helyett, ha az utóbbi nem érhető el
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Elmenti a képet lemezre JPEG formátumban
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni [**Betűcserélés**](/slides/hu/androidjava/font-replacement/).
{{% /alert %}}

## **Matematikai egyenlet betűkészletek korlátozásai**

A betűkészlet helyettesítési szabályok részt vesznek a renderelés és konvertálás során használt szabványos betűtípus kiválasztási folyamatban. Alkalmazhatók a szokásos szöveges esetekben, ahol az Aspose.Slides a konfigurált szabály szerint egy nem elérhető betűtípust egy másik elérhető betűtípussal helyettesíthet.

Azonban az Office matematikai egyenleteknek fontos korlátozásuk van. Ha egy egyenletet **Cambria Math**-tel hoztak létre, az Aspose.Slides továbbra is megkövetelheti az eredeti **Cambria Math** betűtípust az egyenlet elrendezésének helyes kiszámításához és megjelenítéséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például **STIX Two Math**-tal, nem támogatott az egyenlet renderelésében, és továbbra is kivételt eredményezhet, amely jelzi, hogy **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződj meg arról, hogy a **Cambria Math** betűtípus elérhető legyen az Aspose.Slides számára futásidőben. A betűtípust telepítheted az operációs rendszerbe, vagy biztosíthatod [külső betűtípusként](/slides/hu/androidjava/custom-font/), hogy részt vehessen a normál betűtípus kiválasztási folyamatban a renderelés és konvertálás során.

Ez a korlátozás kifejezetten az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűkészlet helyettesítési szabályok továbbra is alkalmazhatók a prezentáció szokásos szövegére, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűcserélés és a betűkészlet helyettesítés között?**

[Replacement](/slides/hu/androidjava/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikra cserél az egész prezentációban. A helyettesítés egy olyan szabály, amely egy meghatározott feltétel esetén aktiválódik, például amikor az eredeti betűtípus nem érhető el, ekkor egy kijelölt tartalék betűtípus kerül használatra.

**Mikor pontosan alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a szabványos [betűtípus kiválasztás](/slides/hu/androidjava/font-selection-sequence/) sorrendben, amely a betöltés, a renderelés és a konvertálás során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a helyettesítés vagy csere alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem a csere, sem a helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**

A könyvtár megpróbálja a legközelebbi elérhető rendszerbetűtípust kiválasztani, hasonlóan ahhoz, ahogy a PowerPoint viselkedne.

**Csatolhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**

Igen. Futásidőben [hozzáadhatsz külső betűtípusokat](/slides/hu/androidjava/custom-font/), így a könyvtár figyelembe veszi őket a kiválasztás és a renderelés során, beleértve a későbbi konvertálásokat is.

**Terjeszt az Aspose bármilyen betűtípust a könyvtárral együtt?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata saját belátásod és felelősséged szerint történik.

**Vannak különbségek a helyettesítési viselkedésben Windows, Linux és macOS rendszereken?**

Igen. A betűtípusok felderítése az operációs rendszer betűtípuskönyvtáraiból indul. Az alapértelmezett elérhető betűtípusok halmaza és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konvertálás során?**

Szinkronizáld a betűtípus-készletet a gépek vagy konténerek között, [add hozzá a szükséges külső betűtípusokat](/slides/hu/androidjava/custom-font/) a kimeneti dokumentumokhoz, és amennyiben lehetséges [ágyazd be a betűtípusokat](/slides/hu/androidjava/embedded-font/) a prezentációkba, hogy a kiválasztott betűtípusok elérhetők legyenek a renderelés során.