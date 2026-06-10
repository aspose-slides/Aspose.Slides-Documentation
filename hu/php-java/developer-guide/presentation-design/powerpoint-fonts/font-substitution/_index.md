---
title: Betűtípushelyettesítés beállítása prezentációkban PHP használatával
linktitle: Betűtípushelyettesítés
type: docs
weight: 70
url: /hu/php-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípushelyettesítés
- betűtípus cseréje
- betűtípus helyettesítés
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Aktiválja az optimális betűtípushelyettesítést az Aspose.Slides for PHP-ben Java-on keresztül, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra."
---
## **Bevezetés**

A betűtípushelyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem érhető el a megjelenítés vagy konvertálás során. A `getSubstitutions` metódus segítségével a `FontsManager` osztályból ellenőrizheti, mely betűtípusok lettek helyettesítve.

Az Aspose.Slides emellett lehetővé teszi betűtípushelyettesítési szabályok definiálását. Például megadhatja, hogy egy nem elérhető betűtípust egy másik elérhető betűtípusra cseréljenek, és ezeket a szabályokat a prezentáció betűtípuskezelőjén keresztül alkalmazza.

## **Betűtípushelyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi, hogy betűtípusokra vonatkozó szabályokat állítson be, amelyek meghatározzák, mi teendő bizonyos feltételek mellett (például amikor egy betűtípus nem érhető el) a következő módon:

1. Töltse be a megfelelő prezentációt.
2. Töltse be a helyettesítendő betűtípust.
3. Töltse be az új betűtípust.
4. Adjon hozzá egy szabályt a helyettesítéshez.
5. Adja hozzá a szabályt a prezentáció betűtípushelyettesítési szabálykollekciójához.
6. Generálja le a dia képét a hatás megfigyeléséhez.

Ez a PHP kód bemutatja a betűtípushelyettesítési folyamatot:

```php
  # Betölt egy prezentációt
  $pres = new Presentation("Fonts.pptx");
  try {
    # Betölti a cserélendő forrás betűtípust
    $sourceFont = new FontData("SomeRareFont");
    # Betölti az új betűtípust
    $destFont = new FontData("Arial");
    # Hozzáad egy betűtípus szabályt a betűtípus helyettesítéshez
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Hozzáadja a szabályt a betűtípus helyettesítési szabályok gyűjteményéhez
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Hozzáad egy betűtípus szabály gyűjteményt a szabálistához
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Az Arial betűtípust fogja használni a SomeRareFont helyett, ha az utóbbi nem érhető el
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Elmenti a képet a lemezre JPEG formátumban
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni a [**Betűtípus helyettesítés**](/slides/hu/php-java/font-replacement/)-t.
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípushelyettesítési szabályok részt vesznek a megjelenítés és konvertálás során használt szabványos betűtípus-kiválasztási folyamatban. Alkalmazhatók általános szöveges esetekben, ahol az Aspose.Slides a beállított szabály szerint egy nem elérhető betűtípust egy másik elérhető betűtípusra cserél.

Azonban az Office matematikai egyenletek fontos korlátozással rendelkeznek. Ha egy egyenlet **Cambria Math** betűtípussal készült, az Aspose.Slides továbbra is igényelheti az eredeti **Cambria Math** betűtípust az egyenlet elrendezésének helyes kiszámításához és megjelenítéséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, mint például a **STIX Two Math**, nem támogatott az egyenlet megjelenítésére, és továbbra is kivételt eredményezhet, amely jelzi, hogy a **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződjön meg arról, hogy a **Cambria Math** elérhető az Aspose.Slides számára futásidőben. A betűtípust telepítheti az operációs rendszerbe, vagy megadhatja [külső betűtípusként](/slides/hu/php-java/custom-font/), így részt vehet a normál betűtípus-kiválasztási folyamatban a megjelenítés és konvertálás során.

Ez a korlátozás az egyenlet megjelenítésére vonatkozik. A fent leírt szabványos betűtípushelyettesítési szabályok továbbra is érvényesek a szabályos prezentációs szövegre, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípus helyettesítés és a betűtípushelyettesítés között?**

[Replacement](/slides/hu/php-java/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikkal cserél ki az egész prezentációban. A helyettesítés egy szabály, amely egy adott feltétel esetén aktiválódik, például ha az eredeti betűtípus nem érhető el, ekkor egy kijelölt tartalék betűtípust használ.

**Mikor alkalmazzák pontosan a helyettesítési szabályokat?**

A szabályok részt vesznek a szabványos [betűtípus kiválasztás](/slides/hu/php-java/font-selection-sequence/) sorozatban, amely a betöltés, megjelenítés és konvertálás során kerül kiértékelésre; ha a kiválasztott betűtípus nem érhető el, a helyettesítés vagy betűtípus helyettesítése alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem helyettesítés, sem betűtípushelyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**

A könyvtár megpróbálja a legközelebbi elérhető rendszerbetűtípust választani, hasonlóan ahhoz, ahogy a PowerPoint működne.

**Csatolhatok egyéni külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**

Igen. Futásidőben [hozzáadhat külső betűtípusokat](/slides/hu/php-java/custom-font/), hogy a könyvtár figyelembe vegye őket a kiválasztás és megjelenítés során, beleértve a későbbi konvertálásokat is.

**Terjeszt az Aspose bármilyen betűtípust a könyvtárral?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusok hozzáadása és használata teljesen az Ön belátásán és felelősségén múlik.

**Vannak különbségek a helyettesítési viselkedésben Windows, Linux és macOS esetén?**

Igen. A betűtípus-felfedezés az operációs rendszer betűtárgyai alapján indul. Az alapértelmezett elérhető betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja az elérhetőséget és a helyettesítés szükségességét.

**Hogyan készítsem elő a környezetet, hogy minimalizáljam a váratlan helyettesítéseket kötegelt konvertálás során?**

Szinkronizálja a betűtípuskészletet a gépek vagy konténerek között, [adja hozzá a szükséges külső betűtípusokat](/slides/hu/php-java/custom-font/) a kimeneti dokumentumokhoz, és [ágyazza be a betűtípusokat](/slides/hu/php-java/embedded-font/) a prezentációkba, amikor csak lehetséges, hogy a kiválasztott betűtípusok elérhetők legyenek a megjelenítés során.