---
title: Java-ban prezentációs diák összehasonlítása
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/java/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Programozott módon hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Java segítségével. Gyorsan azonosítsa a diák közötti eltéréseket a kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy diákat, elrendezési diát és mesterdiát hasonlítsunk össze az `IBaseSlide` interfész és a `BaseSlide` osztály által biztosított `equals` metódus segítségével. Ez a metódus `true` értéket ad vissza, ha az összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**

Az equals metódus hozzá lett adva az [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBaseSlide) interfészhez és a [BaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/BaseSlide) osztályhoz. Igaz értéket ad vissza azoknál a diák/elrendezési diák és diák/mester diák esetén, amelyek szerkezetükben és statikus tartalmukban azonosak.

Két dia egyenlő, ha minden alakzat, stílus, szöveg, animáció és egyéb beállítás, stb. egyenlő. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId-t, és a dinamikus tartalmakat, például a Dátum helyőrzőben lévő aktuális dátumértéket.

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

## **GYIK**

**A diák rejtett állapota befolyásolja a diák összehasonlítását?**

[Hidden status](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getHidden--) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két adott dia egyenlősége a szerkezetük és statikus tartalmuk alapján kerül meghatározásra; a dia egyszerűen rejtettnek lenni nem teszi a diákat különbözővé.

**A hyperlinkek és azok paraméterei figyelembe vannak véve?**

Igen. A linkek a dia statikus tartalmának részei. Ha az URL vagy a hyperlink művelet eltér, ez általában a statikus tartalom különbségeként kezelhető.

**Ha egy diagram egy külső Excel fájlra hivatkozik, a fájl tartalma figyelembe lesz véve?**

Nem. Az összehasonlítást maguk a diák alapján végzik. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia szerkezetében és statikus állapotában jelen lévő információkat veszik figyelembe.