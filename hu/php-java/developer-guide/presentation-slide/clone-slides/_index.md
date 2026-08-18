---
title: Prezentáció diák klónozása PHP-ben
linktitle: Dia klónozása
type: docs
weight: 35
url: /hu/php-java/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Gyorsan duplikálja a PowerPoint diákat az Aspose.Slides for PHP segítségével. Kövesse egyértelmű kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a manuális munkát."
---
## **Bevezetés**

Klónozás a pontos másolat vagy replikáció elkészítésének folyamata. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy bármely diát lemásoljuk vagy klónozzuk, majd a klónozott diát beilleszthessük az aktuális vagy bármely más nyitott bemutatóba. A diaklónozás folyamata egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Többféle módon lehet egy diát klónozni:

- Klónozás a prezentáció végén.
- Klónozás a prezentáción belül egy másik pozícióban.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik prezentációban egy másik pozícióban.
- Klónozás egy másik prezentációban egy adott pozícióban.

Az Aspose.Slides for PHP via Java-ban a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum által biztosított (a [Dia](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Slide) objektumok gyűjteménye) a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) és a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusokat kínálja a fenti diaklónozási típusok végrehajtásához

## **Dia klónozása a prezentáció végén**
Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban a meglévő diák végén használni, használja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumot a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum által biztosított dia gyűjtemény hivatkozásával.
3. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumon, és adja át a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
4. Írja ki a módosított prezentációfájlt.

Az alábbi példában egy diát (a prezentáció első pozíciójában – nulla indexen – elhelyezkedő) a prezentáció végére klónoztuk.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klónozza a kívánt diát a prezentációban lévő diák gyűjteményének végére
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Írja a módosított prezentációt lemezre
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Dia klónozása egy másik pozícióba ugyanabban a prezentációban**
Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban más pozícióban használni, használja a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) objektumot a [**Slides**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) gyűjtemény hivatkozásával, amelyet a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum biztosít.
3. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumon, és adja át a klónozandó diát valamint az új pozíció indexét paraméterként a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusnak.
4. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy diát (a prezentáció nulla indexén – 1. pozíció – elhelyezkedő) az 1-es indexre – 2. pozícióra – klónoztuk.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klónozza a kívánt diát a prezentációban lévő diák gyűjteményének végére
    $slds = $pres->getSlides();
    # Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Írja a módosított prezentációt lemezre
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Dia klónozása egy másik prezentáció végén**
Ha egy diát egy prezentációból kell klónozni, és azt egy másik prezentációfájlban a meglévő diák végén használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely tartalmazza azt a prezentációt, amelyből a diát klónozni fogja.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely a célprezentációt tartalmazza, amelyhez a diát hozzá fogja adni.
3. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) objektumot a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma által biztosított [**Slides**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) gyűjtemény hivatkozásával.
4. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumon, és adja át a forrásprezentációból származó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
5. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrásprezentáció első indexéről) a célprezentáció végére klónoztuk.

```php
  # Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a diát klónozni fogjuk)
    $destPres = new Presentation();
    try {
      # Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Írja a cél prezentációt lemezre
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**
Ha egy diát egy prezentációból kell klónozni, és azt egy másik prezentációfájlban egy adott pozícióban használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely a forrásprezentációt tartalmazza, amelyből a diát klónozni fogja.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely a célprezentációt tartalmazza, amelyhez a diát hozzá fogja adni.
3. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) osztályt a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma által biztosított Slides gyűjtemény hivatkozásával.
4. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumon, és adja át a forrásprezentációból származó diát valamint a kívánt pozíciót paraméterként a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusnak.
5. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrásprezentáció nulla indexéről) az 1-es indexre (2. pozíció) a célprezentációban klónoztuk.

```php
  # Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a diát klónozni fogjuk)
    $destPres = new Presentation();
    try {
      # Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Írja a cél prezentációt lemezre
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy adott pozícióba egy másik prezentációban**
Ha egy diát fő diával (master slide) kell klónozni egy prezentációból egy másikba, először a kívánt fő diát kell klónozni a forrásprezentációból a célprezentációba. Ezután ezt a fő diát kell használni a diák fő diával történő klónozásához. A [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) egy a célprezentációból származó fő diát vár, nem a forrásból. A diák fő diával történő klónozáshoz kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely a forrásprezentációt tartalmazza, amelyből a diát klónozni fogja.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályú példányt, amely a célprezentációt tartalmazza, amelyhez a diát hozzá fogja adni.
3. Hozzáférés a klónozandó diához a fő diával együtt.
4. Példányosítsa a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterSlideCollection) osztályt a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma által biztosított Masters gyűjtemény hivatkozásával.
5. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterSlideCollection) objektumon, és adja át a forrás PPTX-ből származó klónozandó fő diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
6. Példányosítsa a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) osztályt a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma által biztosított Slides gyűjtemény hivatkozásával.
7. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumon, és adja át a forrásprezentációból származó klónozandó diát és a fő diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
8. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy fő diával rendelkező diát (a forrásprezentáció nulla indexén elhelyezkedő) a célprezentáció végére klónoztuk a forrásdiából származó fő diát felhasználva.

```php
  # Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Példányosítsa a Presentation osztályt a célprezentációhoz (ahová a diát klónozni fogjuk)
    $destPres = new Presentation();
    try {
      # Példányosítsa az ISlide-ot a forrás prezentáció diagyűjteményéből együtt
      # Mester dia
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klónozza a kívánt mester diát a forrás prezentációból a mester gyűjteménybe a
      # Célprezentáció
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klónozza a kívánt mester diát a forrás prezentációból a mester gyűjteménybe a
      # Célprezentáció
      $iSlide = $masters->addClone($SourceMaster);
      # Klónozza a kívánt diát a forrás prezentációból a kívánt mesterrel a végére a
      # A célprezentáció diagyűjteménye
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Mentse a célprezentációt lemezre
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy megadott szakasz végén**
Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban egy másik szakaszba beilleszteni, használja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) osztály biztosít. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egy diát az első szakaszból klónozzunk, majd azt a klónozott diát a ugyanazon prezentáció második szakaszába illesszük be.

Az alábbi kódrészlet bemutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy megadott szakaszba beilleszteni.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Mentse a célprezentációt lemezre
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **A diaméret egyezésének biztosítása**
Diák egy másik prezentációba történő klónozásakor győződjön meg arról, hogy a célprezentáció diamérete megegyezik a forrással. Ha a diaméretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – eredeti koordinátáik és méreteik megmaradnak, ami azt eredményezheti, hogy a tartalom eltolódik vagy a diák határain túlra nyúlik.

Beállíthatja a célprezentáció diaméretét, hogy egyezzen a forrásával, mielőtt a fő dia és a dia klónozná:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Ezt tegye a fő dia és a dia klónozása előtt.

## **GYIK**

**A beszélői jegyzetek és a lektorálási megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a lektorálási megjegyzések szerepelnek a klónban. Ha nem szeretné őket, a beillesztés után [távolítsa el őket](/slides/hu/php-java/presentation-notes/).

**Hogyan kezelik a diagramok és adatforrásaik?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például OLE-beágyazott munkafüzethez) volt kapcsolva, ez a kapcsolat [OLE objektum](/slides/hu/php-java/manage-ole/)ként marad meg. A fájlok közötti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és szekcióit?**

Igen. A klónt beszúrhatja egy adott diaindexre, és egy kiválasztott [szakasz](/slides/hu/php-java/slide-section/)ba helyezheti. Ha a cél szakasz nem létezik, előbb hozza létre, majd mozgassa át a diát oda.