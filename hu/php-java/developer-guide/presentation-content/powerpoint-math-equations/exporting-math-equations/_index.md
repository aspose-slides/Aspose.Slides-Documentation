---
title: Matematikai egyenletek exportálása prezentációkból PHP-ben
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/php-java/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- MathML
- LaTeX
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "A PowerPointból MathML-be történő matematikai egyenletek zökkenőmentes exportálásának lehetővé tétele az Aspose.Slides for PHP via Java használatával — megőrizze a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Aspose.Slides for PHP via Java lehetővé teszi, hogy matematikai egyenleteket exportáljon prezentációkból. Például előfordulhat, hogy ki szeretné nyerni a diákon (egy adott prezentációból) található matematikai egyenleteket, és egy másik programban vagy platformon szeretné felhasználni őket.

{{% alert color="primary" %}} 
Exportálhat egyenleteket MathML-be, egy népszerű formátumba vagy szabványba a matematikai egyenletek és hasonló tartalom számára, amely a weben és számos alkalmazásban látható. 
{{% /alert %}}

## **Matematikai egyenletek mentése MathML-be**

Miközben az emberek könnyen megírják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, nehezebben tudják megírni a MathML kódját, mivel ezt utóbbit automatikusan kell generálni alkalmazások által. A programok könnyen olvassák és elemzik a MathML-t, mivel a kódja XML-ben van, ezért a MathML gyakran használt kimeneti és nyomtatási formátum sok területen. 

Ez a példa kód megmutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML-be:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Pontosan mi exportálódik MathML-be—egy bekezdés vagy egy egyedi képletblokk?**

Exportálhatja akár egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/)), akár egy önálló blokkot ([MathBlock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathblock/)) MathML-be. Mindkét típus biztosít egy metódust a MathML‑be íráshoz.

**Hogyan lehet megállapítani, hogy egy dián lévő objektum matematikai képlet, nem pedig egyszerű szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/)‑ban él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/)-nal. Képek és egyszerű szöveg részek, amelyeknek nincs [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/)-ja, nem exportálható képletek.

**Honnan származik a MathML egy prezentációban—PowerPoint-specifikus vagy szabvány?**

Az export célpontja a szabványos MathML (XML). Az Aspose a Presentation MathML-t használja — a szabvány prezentációs részhalmazát, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott a képletek exportálása táblázatokban, SmartArt-ban, csoportokban stb.?**

Igen, ha azok az objektumok szövegrészeket tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/)‑nal (azaz valódi PowerPoint‑képletek), akkor exportálásra kerülnek. Ha egy képlet képként van beágyazva, az nem kerül exportálásra.

**Módosítja a MathML-be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának szerializálása; nem módosítja a prezentáció fájlt.