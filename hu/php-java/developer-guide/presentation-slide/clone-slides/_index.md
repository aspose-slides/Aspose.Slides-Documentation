---
title: "Prezentációs diák klónozása PHP-ben"
linktitle: "Dia klónozása"
type: docs
weight: 35
url: /hu/php-java/clone-slides/
keywords:
- "dia klónozása"
- "dia másolása"
- "dia mentése"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Az Aspose.Slides for PHP segítségével gyorsan duplikálhatja a PowerPoint diákat. Kövesse a világos kódpéldáinkat a PPT létrehozásának másodpercek alatt automatizálásához és a manuális munka megszüntetéséhez."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció készítésének folyamata. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy bármely dia másolatát vagy klónját elkészítsük, majd azt a klónozott diát a jelenlegi vagy bármely más megnyitott prezentációba illesszük. A diaklónozási folyamat egy új diát hoz létre, amelyet a fejlesztők módosíthatnak az eredeti dia megváltoztatása nélkül. Többféle módja van a dia klónozásának:

- Klónozás a prezentáció végén.
- Klónozás a prezentáció másik pozíciójában.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik prezentáció másik pozíciójában.
- Klónozás egy adott pozícióban egy másik prezentációban.

Az Aspose.Slides for PHP via Java-ban a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum által kiadott (a [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Slide) objektumok gyűjteménye) biztosítja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) és a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusokat a fenti diaklónozási típusok végrehajtásához.

## **Dia klónozása a prezentáció végén**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációs fájlban a meglévő diák végén használni, használja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust az alább felsorolt lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektumot a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum által kiadott dia gyűjtemény hivatkozásával.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektum által ki van adva, és adja át a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
1. Írja ki a módosított prezentációfájlt.

Az alábbi példában egy diát (amely a prezentáció első pozíciójában – nulla index – helyezkedik) klónoztunk a prezentáció végére.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Írja a módosított prezentációt a lemezre
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Dia klónozása egy másik pozícióba a prezentációon belül**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációs fájlban, de másik pozícióban használni, használja a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) objektumot a [**Slides**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) gyűjtemény hivatkozásával, amelyet a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektum tesz elérhetővé.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektum által ki van adva, és adja át a klónozandó diát a kívánt új pozíció indexével együtt paraméterként a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusnak.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy diát (amely a nulla index – 1. pozíció – helyén van a prezentációban) klónoztunk az 1-es indexre – 2. pozícióra – a prezentációban.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    $slds = $pres->getSlides();
    # Klónozza a kívánt diát a ugyanabban a prezentációban a megadott indexen
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Írja a módosított prezentációt a lemezre
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Dia klónozása egy másik prezentáció végén**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációban, a meglévő diák végén szeretné használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, amelyhez a dia hozzá lesz adva.
1. Szerezze meg a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) objektumot a [**Slides**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) gyűjtemény hivatkozásával, amelyet a cél prezentáció Presentation objektuma tesz elérhetővé.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektum által ki van adva, és adja át a forrás prezentációból származó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrás prezentáció első indexéből) klónoztunk a célprezentáció végére.

```php
  # A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # A Presentation osztály példányosítása a cél PPTX-hez (ahová a dia klónozandó)
    $destPres = new Presentation();
    try {
      # Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Írja a cél prezentációt a lemezre
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációban, egy adott pozícióban szeretné használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni kell.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, amelyhez a dia hozzá lesz adva.
1. Szerezze meg a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) osztályt a Slides gyűjtemény hivatkozásával, amelyet a cél prezentáció Presentation objektuma tesz elérhetővé.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektum által ki van adva, és adja át a forrás prezentációból származó diát a kívánt pozícióval együtt paraméterként a [insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#insertClone) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrás prezentáció nulla indexéből) klónoztunk az 1-es indexre (2. pozíció) a célprezentációban.

```php
  # A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # A Presentation osztály példányosítása a cél PPTX-hez (ahová a dia klónozandó)
    $destPres = new Presentation();
    try {
      # Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Írja a cél prezentációt a lemezre
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy adott pozícióban egy másik prezentációban**
Ha egy diát master diával együtt kell klónozni egy prezentációból, és egy másik prezentációba szeretné helyezni, először a kívánt master diát kell klónozni a forrás prezentációból a cél prezentációba. Ezután ezt a master diát kell használni a masteres dia klónozásához. A [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) egy a cél prezentációból származó master diát vár, nem a forrásból. A masteres dia klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni kell.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, ahová a dia klónozva lesz.
1. Hozzáférés a klónozandó diához a master diával együtt.
1. Hozza létre a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterSlideCollection) osztályt a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma által kitetts Masters gyűjtemény hivatkozásával.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amely a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterSlideCollection) objektum által ki van adva, és adja át a forrás PPTX‑ből származó master diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
1. Hozza létre a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) osztályt a Slides gyűjtemény hivatkozásával, amelyet a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) objektuma tesz elérhetővé.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSlides) objektum által ki van adva, és adja át a forrás prezentációból származó diát és a master diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy masteres diát (a forrás prezentáció nulla indexén) klónoztunk a célprezentáció végére a forrás diából származó master használatával.

```php
  # A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # A Presentation osztály példányosítása a cél prezentációhoz (ahová a diát klónozni kell)
    $destPres = new Presentation();
    try {
      # ISlide példányosítása a forrás prezentáció diagyűjteményéből együtt
      # Master dia
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # A kívánt master dia klónozása a forrás prezentációból a masterek gyűjteményébe a
      # Cél prezentációban
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # A kívánt master dia klónozása a forrás prezentációból a masterek gyűjteményébe a
      # Cél prezentációban
      $iSlide = $masters->addClone($SourceMaster);
      # A kívánt dia klónozása a forrás prezentációból a kívánt masterrel a végére a
      # Dia gyűjteménynek a cél prezentációban
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # A cél prezentáció mentése a lemezre
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Dia klónozása egy megadott szekció végén**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációs fájlban, de egy másik szekcióban használni, használja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection/#addClone) metódust, amely a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection) osztály által ki van adva. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egy diát az első szekcióból klónozzunk, majd a klónozott diát a második szekcióba illesszük ugyanabban a prezentációban.

Az alábbi kódrészlet bemutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy megadott szekcióba illeszteni.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # A cél prezentáció mentése a lemezre
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **GYIK**

**A beszédjegyzetek és a felülvizsgáló megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések benne vannak a klónban. Ha nem szeretné őket, [remove them](/slides/hu/php-java/presentation-notes/) a beillesztés után.

**A diagramok és adatforrásaik hogyan kezelődnek?**

A diagramobjektum, a formázás és a beágyazott adatok másolva vannak. Ha a diagram külső forráshoz volt kapcsolva (például egy OLE‑beágyazott munkafüzethez), ez a kapcsolat megmarad egy [OLE object](/slides/hu/php-java/manage-ole/) formájában. Fájlok közötti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**A klón beillesztési pozícióját és szekcióit irányíthatom?**

Igen. A klónt beillesztheti egy adott dia indexre, és elhelyezheti egy választott [section](/slides/hu/php-java/slide-section/)‑ben. Ha a cél szekció nem létezik, először hozza létre, majd mozgassa a diát oda.