---
title: PowerPoint tintaobjektumok kezelése PHP-ben
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/php-java/manage-ink/
keywords:
- tinta
- tintaobjektum
- tinta nyomvonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "PowerPoint tintaobjektumok kezelése – digitális tinta létrehozása, szerkesztése és stílusozása az Aspose.Slides for PHP via Java segítségével. Kódminták nyomvonalak, ecset szín és méret esetén."
---
## **Bevezetés**

A PowerPoint biztosítja a tinta funkciót, amely lehetővé teszi, hogy nem szabványos alakzatokat rajzoljunk, ezeket felhasználhatjuk más objektumok kiemelésére, kapcsolatok és folyamatok ábrázolására, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides minden szükséges tinta típust (például a [Ink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ink/) osztályt) biztosít az tintaobjektumok létrehozásához és kezeléséhez.

## **A szabályos objektumok és a tintaobjektumok közötti különbségek**

A PowerPoint dián lévő objektumok általában alakzatobjektumok formájában jelennek meg. Egy egyszerű alakzatobjektum egy tároló, amely meghatározza az objektum saját területét (keretét) és annak tulajdonságait. Ezek közé tartozik a tároló mérete, alakja, háttérszíne stb. További információkért lásd a [Alakzatelrendezés formátuma](https://docs.aspose.com/slides/hu/php-java/shape-manipulations/#access-layout-formats-for-shape) részt.

Amikor a PowerPoint egy tintaobjektummal dolgozik, a tároló (keret) minden tulajdonságát figyelmen kívül hagyja, kivéve a méretét. A tároló területének méretét a szabványos `width` és `height` értékek határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape nyomvonalak**

A nyomvonal egy alapvető elem vagy szabvány, amely a toll mozgásának útvonalát rögzíti, amikor a felhasználó digitális tintát ír. A nyomvonalak olyan felvételek, amelyek egymáshoz kapcsolódó pontok sorozatát írják le.

A legegyszerűbb kódolás minden mintapont X és Y koordinátáit adja meg. Amikor az összes kapcsolt pontot megjelenítik, egy ilyen kép jön létre:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok rajzoláshoz**

Az ecsetet használhatja vonalak rajzolására, amelyek a nyomvonalak pontjait kötnek össze. Az ecset saját színnel és mérettel rendelkezik, a `Brush.Color` és a `Brush.Size` tulajdonságoknak megfelelően.

### **Ink ecset színének beállítása**

Ez a PHP kód megmutatja, hogyan állíthatja be egy ecset színét:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ink ecset méretének beállítása**

Ez a PHP kód megmutatja, hogyan állíthatja be egy ecset méretét:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Általában az ecset szélessége és magassága nem egyezik meg, ezért a PowerPoint nem jeleníti meg az ecset méretét (az adat szakasz szürkén van). Ha azonban az ecset szélessége és magassága egyezik, a PowerPoint a következő módon mutatja a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

A tisztánlátás érdekében növeljük meg a tintaobjektum magasságát, és tekintsük át a fontos dimenziókat:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig feltételezi, hogy a vonal vastagsága nulla (lásd az utolsó képet).

Ezért a teljes tintaobjektum látható területének meghatározásához figyelembe kell venni a nyomvonalak ecsetméretét. Itt a célobjektum (a kézírásos szöveg nyomvonalobjektuma) a tároló (keret) méretéhez van méretezve. Amikor a tároló (keret) mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint ugyanezt a viselkedést mutatja a szövegek esetén is:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasnivaló**

* Az alakzatok általános ismertetéséhez lásd a [PowerPoint alakzatok](https://docs.aspose.com/slides/hu/php-java/powerpoint-shapes/) részt.
* A hatékony értékekkel kapcsolatos további információkért nézd meg a [Alakzat hatékony tulajdonságai](https://docs.aspose.com/slides/hu/php-java/shape-effective-properties/#getting-effective-font-height-value) szekciót.