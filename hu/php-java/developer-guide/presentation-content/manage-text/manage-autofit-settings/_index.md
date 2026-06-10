---
title: Fejlessze előadásait az AutoFit használatával PHP-ben
linktitle: AutoFit beállítások
type: docs
weight: 30
url: /hu/php-java/manage-autofit-settings/
keywords:
- szövegdoboz
- autofit
- ne automatikusan illessze
- szöveg igazítása
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje az AutoFit beállításokat az Aspose.Slides for PHP-ben, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezető**

Alapértelmezés szerint, amikor szövegdobozt ad hozzá, a Microsoft PowerPoint a **Resize shape to fix text** beállítást használja a szövegdobozhoz – automatikusan átméretezi a szövegdobozt, hogy a szövege mindig beleférjen.

![szövegdoboz PowerPointban](textbox-in-powerpoint.png)

* Amikor a szövegdoboz szövege hosszabbá vagy nagyobbá válik, a PowerPoint automatikusan nagyobbá teszi a szövegdobozt – megnöveli a magasságát –, hogy több szöveget tudjon tartalmazni.  
* Amikor a szövegdoboz szövege rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegdobozt – csökkenti a magasságát –, hogy eltávolítsa a felesleges helyet.  

In PowerPointban ezek a 4 fontos paraméter vagy beállítás, amelyek a szövegdoboz autofit viselkedését szabályozzák:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**  

![autofit beállítások PowerPointban](autofit-options-powerpoint.png)

Az Aspose.Slides for PHP via Java hasonló lehetőségeket kínál – néhány tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat) osztályban – amelyek lehetővé teszik a szövegdobozok autofit viselkedésének vezérlését a bemutatókban.

## **Alakzat átméretezése a szöveghez igazítva**

Ha azt szeretné, hogy egy dobozban lévő szöveg mindig beleférjen a dobozba a szöveg módosítása után, a **Resize shape to fix text** beállítást kell használnia. Ennek beállításához állítsa a [AutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat) osztályból) `Shape` értékre.

![alwaysfit beállítás PowerPointban](alwaysfit-setting-powerpoint.png)

Ez a PHP kód megmutatja, hogyan lehet megadni, hogy a szöveg mindig beleférjen a dobozába egy PowerPoint bemutatóban:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ha a szöveg hosszabbá vagy nagyobbá válik, a szövegdobozt automatikusan átméretezik (magasság növelése), hogy az összes szöveg beleférjen. Ha a szöveg rövidebb, akkor a fordított történik.

## **Ne automatikusan igazítsa**

Ha azt szeretné, hogy egy szövegdoboz vagy alakzat megtartsa méreteit, függetlenül a tartalmazott szöveg módosításától, a **Do not Autofit** beállítást kell használni. Ennek beállításához állítsa a [AutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat) osztályból) `None` értékre.

![donotautofit beállítás PowerPointban](donotautofit-setting-powerpoint.png)

Ez a PHP kód megmutatja, hogyan lehet megadni, hogy egy szövegdoboz megtartsa méreteit egy PowerPoint bemutatóban:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ha a szöveg túl hosszú lesz a dobozhoz képest, kifolyik.

## **Szöveg zsugorítása túlcsorduláskor**

Ha egy szöveg túl hosszú lesz a dobozához, a **Shrink text on overflow** opcióval megadhatja, hogy a szöveg méretét és sorközét csökkenteni kell, hogy beleférjen a dobozba. Ennek beállításához állítsa a [AutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat) osztályból) `Normal` értékre.

![shrinktextonoverflow beállítás PowerPointban](shrinktextonoverflow-setting-powerpoint.png)

Ez a PHP kód megmutatja, hogyan lehet megadni, hogy egy szöveg zsugorítva legyen túlcsorduláskor egy PowerPoint bemutatóban:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Amikor a **Shrink text on overflow** opciót használják, a beállítás csak akkor kerül alkalmazásra, amikor a szöveg túl hosszú lesz a dobozhoz képest.
{{% /alert %}}

## **Szöveg tördelése**

Ha azt szeretné, hogy egy alakzatban lévő szöveg a forma belsejében legyen megtörve, amikor a szöveg túllépi az alakzat szélét (csak a szélességet), a **Wrap text in shape** paramétert kell használnia. Ennek beállításához állítsa a [WrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat#getWrapText--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrameFormat) osztályból) `true` értékre.

Ez a PHP kód megmutatja, hogyan használja a Szöveg tömbölés beállítást egy PowerPoint bemutatóban:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Ha egy alakzatra a `WrapText` tulajdonságot `False` értékre állítja, és a szöveg hosszabb lesz az alakzat szélességénél, a szöveg egyetlen sorban a forma szélén túlra nyúlik. 
{{% /alert %}}

## **GYIK**

**A szövegkeret belső margói befolyásolják az AutoFit-et?**

**Igen.** A kitöltés (belső margók) csökkenti a szöveg felhasználható területét, így az AutoFit korábban aktiválódik – a betűméretet vagy az alakzat méretét korábban csökkentve. Ellenőrizze és állítsa be a margókat, mielőtt finomhangolná az AutoFit-et.

**Hogyan működik az AutoFit a manuális és puha sortörésekkel?**

A kényszerített sortörések megmaradnak, és az AutoFit a betűméretet és a sorközöket körülöttük módosítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy az AutoFit mennyire agresszívan kell csökkentse a szöveget.

**A téma betűtípusának módosítása vagy a betűtípus helyettesítésének indítása befolyásolja az AutoFit eredményeit?**

Igen. A betűtípus helyettesítése egy eltérő glif metrikájú betűtípusra megváltoztatja a szöveg szélességét/magasságát, ami befolyásolhatja a végső betűméretet és a sortörést. Bármilyen betűtípus változtatás vagy helyettesítés után ellenőrizze újra a diákat.