---
title: "Diák összehasonlítása C++ nyelven"
linktitle: "Diák összehasonlítása"
type: docs
weight: 50
url: /hu/cpp/compare-slides/
keywords:
- "diák összehasonlítása"
- "dia összehasonlítás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Programozottan hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides for C++ könyvtárral. Gyorsan azonosítsa a diák közötti különbségeket a kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy összehasonlítsa a diákot, elrendezési diát és mesterdiát a `IBaseSlide` felület és a `BaseSlide` osztály által biztosított `Equals` metódus használatával. Ez a metódus `true`‑t ad vissza, ha a összehasonlított diák azonosak a struktúrájukban és a statikus tartalmukban.

## **Két dia összehasonlítása**
Az `Equals` metódus hozzá lett adva az `IBaseSlide` felülethez és a `BaseSlide` osztályhoz. true‑t ad vissza azon diákra / elrendezési diára / mesterdiára, amelyek azonosak a struktúrájukban és a statikus tartalmukban.

Két dia egyenlő, ha minden alakzat, stílus, szöveg, animáció és egyéb beállítás megegyezik stb. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId‑t, és a dinamikus tartalmat, például a Dátumhelyőrzőben lévő aktuális dátum értékét.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **GYIK**

**A dia rejtett státusza befolyásolja a diák közti összehasonlítást?**

[Rejtett állapot](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/get_hidden/) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két konkrét dia egyenlősége a struktúrájuk és a statikus tartalmuk alapján dől el; a dia egyszerűen rejtett státusza önmagában nem változtatja meg a diák közötti különbséget.

**Figyelembe veszik a hiperhivatkozásokat és azok paramétereit?**

Igen. A hivatkozások a dia statikus tartalmának részei. Ha az URL vagy a hiperhivatkozás művelete eltér, ez általában a statikus tartalom különbségeként szerepel.

**Ha egy diagram egy külső Excel fájlra hivatkozik, figyelembe veszik-e a fájl tartalmát?**

Nem. Az összehasonlítást kizárólag a diák alapján végzik. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlításkor; csak az, ami a dia struktúrájában és statikus állapotában jelen van, számít.