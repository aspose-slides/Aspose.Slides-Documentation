---
title: Betűtípus helyettesítés beállítása prezentációkban Java használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Engedélyezze az optimális betűtípus helyettesítést az Aspose.Slides for Java-ban a PowerPoint és OpenDocument prezentációk más fájlformátumokra történő konvertálásakor."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi, hogy az Aspose.Slides egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem elérhető renderelés vagy konverzió során. A helyettesített betűtípusok listáját a `IFontsManager` interfész `getSubstitutions` metódusával ellenőrizheted.

Az Aspose.Slides emellett lehetővé teszi betűtípus helyettesítési szabályok meghatározását. Például megadhatod, hogy egy nem elérhető betűtípust egy másik elérhető betűtípusra cseréljen, majd ezeket a szabályokat a prezentáció betűtípuskezelőjén keresztül alkalmazhatod.

## **Betűtípus helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi betűtípusokra vonatkozó szabályok beállítását, amelyek meghatározzák, mi történjen bizonyos körülmények között (például amikor egy betűtípus nem érhető el) a következő módon:

1. Töltsd be a megfelelő prezentációt.  
2. Töltsd be a cserélendő betűtípust.  
3. Töltsd be az új betűtípust.  
4. Adj hozzá egy szabályt a cseréhez.  
5. Add hozzá a szabályt a prezentáció betűtípuscsere‑szabály gyűjteményéhez.  
6. Generáld le a diaképet, hogy megfigyeld a hatást.

Ez a Java kód bemutatja a betűtípus helyettesítési folyamatot:

```java
// Betölt egy prezentációt
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Betölti a cserélni kívánt forrás betűtípust
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Betölti az új betűtípust
    IFontData destFont = new FontData("Arial");
    
    // Betűtípus cserére szabályt ad hozzá
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Hozzáadja a szabályt a betűtípus helyettesítési szabályok gyűjteményéhez
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Hozzáad egy betűtípus szabály gyűjteményt a szabálistához
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Az Arial betűtípus kerül használatra a SomeRareFont helyett, ha az utóbbi nem érhető el
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Elmenti a képet a lemezre JPEG formátumban
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
Érdemes megnézni a [**Betűtípus csere**](/slides/hu/java/font-replacement/). 
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus helyettesítési szabályok részt vesznek a renderelés és konverzió során használt szabványos betűtípus‑kiválasztási folyamatban. Ezek megfelelőek a szokásos szöveges helyzetekhez, ahol az Aspose.Slides a konfigurált szabály alapján egy nem elérhető betűtípust egy másik elérhető betűtípusra cserél.

Az Office matematikai egyenletek azonban egy fontos korláttal rendelkeznek. Ha egy egyenletet **Cambria Math**‑szel hoztak létre, az Aspose.Slides valószínűleg továbbra is az eredeti **Cambria Math** betűtípust igényli az egyenlet elrendezésének helyes kiszámításához és rendereléséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például **STIX Two Math**‑szal, nem támogatott az egyenlet renderelése során, és még mindig előfordulhat olyan kivétel, amely a **Cambria Math** szükségességét jelzi.

Az ilyen prezentációk sikeres konvertálásához győződj meg arról, hogy a **Cambria Math** betűtípus elérhető az Aspose.Slides számára futásidőben. A betűtípust telepítheted az operációs rendszerbe, vagy megadhatsz egy [külső betűtípust](/slides/hu/java/custom-font/), hogy részt vegyen a normál betűtípus‑kiválasztási folyamatban renderelés és konverzió közben.

Ez a korlátozás kizárólag az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűtípus helyettesítési szabályok továbbra is érvényesek a prezentáció normál szövegeire, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

[Csere](/slides/hu/java/font-replacement/) egy kényszerített felülírás, amely az egész prezentációban egy betűtípust egy másikra cserél. A helyettesítés egy szabály, amely egy adott feltétel (például az eredeti betűtípus hiánya) esetén lép életbe, és ekkor egy kijelölt tartalékbetűtípus kerül felhasználásra.

**Mikor alkalmazódnak pontosan a helyettesítési szabályok?**

A szabályok a szabványos [betűtípus‑kiválasztási](/slides/hu/java/font-selection-sequence/) sorozat részei, amely a betöltés, renderelés és konverzió során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a csere vagy helyettesítés alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem csere, sem helyettesítés nincs konfigurálva, és a betűtípus hiányzik a rendszerről?**

A könyvtár megpróbálja a legközelebbi elérhető rendszer‑betűtípust választani, hasonlóan ahhoz, ahogy a PowerPoint viselkedne.

**Hozzáadhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**

Igen. [Külső betűtípusokat](/slides/hu/java/custom-font/) adhatsz hozzá futásidőben, így a könyvtár figyelembe veszi őket a kiválasztás és renderelés során, beleértve a későbbi konverziókat is.

**Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral együtt?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata a saját belátásod és felelősséged szerint történik.

**Vannak különbségek a helyettesítés viselkedésében Windows, Linux és macOS rendszereken?**

Igen. A betűtípus‑felfedezés az operációs rendszer betűtárakból indul. Az alapértelmezett elérhető betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konverziók során?**

Szinkronizáld a betűtípus‑készletet a gépek vagy konténerek között, [add hozzá a szükséges külső betűtípusokat](/slides/hu/java/custom-font/) a kimeneti dokumentumokhoz, és [ágyazd be a betűtípusokat](/slides/hu/java/embedded-font/) a prezentációkba, ahol lehetséges, hogy a kiválasztott betűtípusok a renderelés során elérhetők legyenek.