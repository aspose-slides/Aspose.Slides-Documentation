---
title: Diák összehasonlítása Androidon
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/androidjava/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "A PowerPoint és OpenDocument prezentációk programozott összehasonlítása az Aspose.Slides for Android segítségével. Gyorsan azonosíthatja a diák közötti eltéréseket Java kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi diák, elrendezési diák és mesterdiák összehasonlítását a `IBaseSlide` interfész és a `BaseSlide` osztály által biztosított `equals` metódus használatával. Ez a metódus `true` értéket ad vissza, ha a összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**
Az Equals metódus hozzá lett adva az [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBaseSlide) interfészhez és a [BaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/BaseSlide) osztályhoz. `true` értéket ad vissza az elrendezési diákra és a mesterdiákra, ha azok szerkezetükben és statikus tartalmukban azonosak.  
Két dia akkor egyenlő, ha az összes alakzat, stílus, szöveg, animáció és egyéb beállítás, stb. egyenlő. Az összehasonlítás nem veszi figyelembe az egyedi azonosítók értékét, például a SlideId-t, valamint a dinamikus tartalmat, például a dátumhelyőrzőben lévő aktuális dátumot.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**A dia rejtett státusza befolyásolja-e a diák összehasonlítását?**

[Hidden status](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getHidden--) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két adott dia egyenlősége a szerkezetükön és statikus tartalmukon alapul; az, hogy egy dia rejtett, önmagában nem teszi a diákat különbözővé.

**Figyelembe veszik-e a hiperhivatkozásokat és azok paramétereit?**

Igen. A hivatkozások egy dia statikus tartalmának részei. Ha az URL vagy a hiperhivatkozás művelete eltér, azt általában a statikus tartalom különbözésének tekintik.

**Ha egy diagram egy külső Excel-fájlra hivatkozik, figyelembe veszik-e a fájl tartalmát?**

Nem. Az összehasonlítás kizárólag a diákon alapul. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia szerkezetében és statikus állapotában jelen lévő információkat veszik figyelembe.