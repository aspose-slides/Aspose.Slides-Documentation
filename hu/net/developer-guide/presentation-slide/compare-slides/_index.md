---
title: .NET-ben prezentációs diák összehasonlítása
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/net/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Programozott módon hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides for .NET segítségével. Azonosítsa gyorsan a diaeltéréseket a kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a diák, elrendezési diák és mesterdiák összehasonlítását a `IBaseSlide` interfész és a `BaseSlide` osztály által biztosított `Equals` metódus segítségével. Ez a metódus `true` értéket ad vissza, ha a összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**

Az Equals metódus hozzá lett adva az [IBaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide) interfészhez és a [BaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslide) osztályhoz. `true` értéket ad vissza azoknál a diák/előzetes és diák/mester diák esetén, amelyek struktúrájukban és statikus tartalmukban azonosak.

Két dia akkor egyenlő, ha minden alakzat, stílus, szöveg, animáció és egyéb beállítás megegyezik stb. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId-t, és a dinamikus tartalmat, például a Dátumhelyőrzőben szereplő aktuális dátum értékét.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **GYIK**

**A dia rejtett állapota hatással van-e a diák összehasonlítására?**

[Hidden status](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/) egy prezentáció/lejátszás szintű tulajdonság, nem vizuális tartalom. Két adott dia egyenlősége a struktúrájukon és statikus tartalmukon alapul; a dia egyszerűen rejtett volta nem teszi a diák különbözővé.

**Figyelembe vannak véve a hiperhivatkozások és azok paraméterei?**

Igen. A hivatkozások a dia statikus tartalmának részét képezik. Ha az URL vagy a hiperhivatkozás művelete eltér, ez általában a statikus tartalom különbségének tekinthető.

**Ha egy diagram egy külső Excel-fájlra hivatkozik, akkor a fájl tartalma figyelembe lesz véve?**

Nem. Az összehasonlítás a diákat magukat veszi alapul. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia struktúrájában és statikus állapotában jelen lévő elemeket veszik figyelembe.