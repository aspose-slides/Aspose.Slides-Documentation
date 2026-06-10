---
title: Prezentációs diák összehasonlítása JavaScriptben
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/nodejs-java/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációkat programozott módon hasonlíthatja össze az Aspose.Slides for Node.js segítségével Java-n keresztül. Azonosítsa gyorsan a diák közötti különbségeket a kódban."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy a diák, elrendezési diák és fő diák összehasonlításra kerüljenek a `BaseSlide` osztály által biztosított `equals` metódus segítségével. Ez a metódus `true` értéket ad vissza, ha a összehasonlított diák azonosak a szerkezetükben és statikus tartalmukban.

## **Két dia összehasonlítása**

Az Equals metódus hozzá lett adva a [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide) osztályhoz és a [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide) osztályhoz. A visszatérési érték `true` azoknál a diák/nemzeteknél és fő diákoknál, amelyek szerkezetük és statikus tartalmuk szerint azonosak.

Két dia akkor egyenlő, ha minden alakzat, stílus, szöveg, animáció és egyéb beállítás stb. egyenlő. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId-t, illetve a dinamikus tartalmat, például a dátumhelyőrző aktuális dátumértékét.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**Azt befolyásolja-e, hogy egy dia rejtett, a diák közötti összehasonlítást?**

[Rejtett állapot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/gethidden/) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két adott dia egyenlősége a szerkezetük és statikus tartalmuk alapján dől el; a dia rejtettnek lenni önmagában nem teszi a diát különbözővé.

**Figyelembe veszik-e a hiperhivatkozásokat és azok paramétereit?**

Igen. A linkek a dia statikus tartalmának részei. Ha az URL vagy a hiperhivatkozás művelete eltér, ez általában a statikus tartalom különbségeként kezelődik.

**Ha egy diagram egy külső Excel fájlra hivatkozik, figyelembe veszi-e a fájl tartalmát?**

Nem. Az összehasonlítás a diákon magukon alapul. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia szerkezetében és statikus állapotában lévő adatok számítanak.