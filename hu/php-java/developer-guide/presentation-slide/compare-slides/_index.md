---
title: Prezentációs diák összehasonlítása PHP-ben
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/php-java/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Programozottan hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides PHP számára Java-n keresztül. Azonosítsa gyorsan a dia különbségeket a kódban."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy összehasonlítsa a diát, az elrendezési diákat és a mester diákat a `BaseSlide` osztály által biztosított `equals` metódus segítségével. Ez a metódus `true` értéket ad vissza, ha a összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**

Az Equals metódus hozzá lett adva a [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/BaseSlide) osztályhoz. Igaz értéket ad vissza a diák/ elrendezési és diák/ mester diák esetén, ha azok struktúrájukban és statikus tartalmukban azonosak.  

Két dia egyenlő, ha minden alakzat, stílus, szöveg, animáció és egyéb beállítás, stb. egyenlő. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a SlideId-t, és a dinamikus tartalmakat, például a Dátumhelyőrzőben lévő aktuális dátumértéket.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **GYIK**

**A tény, hogy egy dia rejtett, befolyásolja-e a diák közti összehasonlítást?**

[Hidden status](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/gethidden/) egy prezentáció/lejátszás szintű tulajdonság, nem vizuális tartalom. Két konkrét dia egyenlősége a szerkezetükön és a statikus tartalmukon alapul; a tény, hogy egy dia rejtett, önmagában nem teszi a diákat különbözővé.

**Figyelembe vannak véve a hiperhivatkozások és azok paraméterei?**

Igen. A hivatkozások a dia statikus tartalmának részét képezik. Ha az URL vagy a hiperhivatkozás művelete eltér, ez általában a statikus tartalom különbségeként van kezelve.

**Ha egy diagram külső Excel fájlra hivatkozik, figyelembe veszi-e a fájl tartalmát?**

Nem. Az összehasonlítást a diák maguk alapján végzik. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia szerkezetében és statikus állapotában jelen lévő adatot veszik figyelembe.