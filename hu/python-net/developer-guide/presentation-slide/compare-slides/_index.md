---
title: Prezentációs diák összehasonlítása Pythonban
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/python-net/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Programozottan hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Python via .NET segítségével. Azonosítsa gyorsan a diaeltéréseket a kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a diák, elrendezési diák és mesterdiák összehasonlítását a `BaseSlide` osztály által biztosított `equals` metódussal végezzük. Ez a metódus `True` értéket ad vissza, ha a összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**
Az `equals` metódus hozzá lett adva a [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályhoz. Igaz értéket ad vissza a diák/elrendezések és diák/mesterdiák esetében, ha azok szerkezetükben és statikus tartalmukban azonosak.

Két dia akkor egyenlő, ha az összes alakzat, stílus, szöveg, animáció és egyéb beállítás megegyezik stb. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId‑t, illetve a dinamikus tartalmakat, például a Dátumhelyőrzőben megjelenő aktuális dátumértéket.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **GYIK**

**A dia rejtett állapota befolyásolja-e a diák közötti összehasonlítást?**

[Hidden status](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két konkrét dia egyenlősége a szerkezetükön és statikus tartalmukon alapul; a dia egyszerűen rejtett állapota önmagában nem teszi a diákat különbözővé.

**Figyelembe veszik-e a hiperhivatkozásokat és azok paramétereit?**

Igen. A hivatkozások a dia statikus tartalmának részét képezik. Ha az URL vagy a hiperhivatkozás művelete eltér, azt általában statikus tartalom különbségként kezelik.

**Ha egy diagram egy külső Excel-fájlra hivatkozik, figyelembe veszik-e annak tartalmát?**

Nem. Az összehasonlítás a diákon magukon alapul. A külső adatforrásokat általában nem olvassák be az összehasonlításkor; csak a dia szerkezetében és statikus állapotában jelen lévő adatot veszik figyelembe.