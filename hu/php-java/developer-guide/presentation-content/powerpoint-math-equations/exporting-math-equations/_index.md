---
title: "Matematikai egyenletek exportálása prezentációkból PHP-ben"
linktitle: "Egyenletek exportálása"
type: docs
weight: 30
url: /hu/php-java/exporting-math-equations/
keywords:
- "matematikai egyenletek exportálása"
- "egyenletek exportálása LaTeX-be"
- "PowerPoint LaTeX-be"
- MathML
- LaTeX
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Exportálja a matematikai egyenleteket a PowerPoint prezentációkból közvetlenül LaTeX-be vagy MathML-be az Aspose.Slides for PHP via Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java lehetővé teszi a matematikai egyenletek exportálását a prezentációkból. Például előfordulhat, hogy ki kell nyernie a diákon (egy adott prezentációból) található matematikai egyenleteket, és egy másik programban vagy platformon használja őket.

{{% alert color="primary" %}} 
Közvetlenül exportálhat egyenleteket LaTeX-be vagy MathML-be, egy népszerű szabványt a weben és számos alkalmazásban használt matematikai tartalomra.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX-be**

Az Aspose.Slides közvetlenül konvertálhat egy PowerPoint matematikai egyenletet LaTeX-be; köztes MathML fájlra és külső konverterre nincs szükség. A matematikai egyenlet egy szövegkeretben tárolódik [MathPortion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/). Használja a [MathPortion::getMathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/#getMathParagraph) a [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/) lekéréséhez, majd hívja a [MathParagraph::toLatex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/#toLatex). A metódus egy karakterláncot ad vissza, amelyet menthet, megjeleníthet, egy másik alkalmazásnak elküldhet vagy további feldolgozásra használhat.

Az alábbi példa minden szövegkeretet vizsgál minden dián, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

A [SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#getAllTextBoxes) visszaadja az egy dián található összes szövegkeretet. A [MathPortion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/) típusellenőrzés elválasztja a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és a dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszakapott karakterláncot az alkalmazása által használt LaTeX motorral. Ha egy szimbólum vagy Office Math elem nem rendelkezik megfelelő ábrázolással abban a környezetben, helyettesítse a visszakapott karakterláncban egy projektspecifikus paranccsal, vagy hagyja ki az egyenletet, és rögzítse a problémát felülvizsgálatra.

## **Matematikai egyenletek mentése MathML-be**

Míg az emberek könnyen írják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, a MathML kód megírása nehézséget jelent, mivel azt alkalmazásoknak kell automatikusan generálniuk. A programok könnyen olvassák és dolgozzák fel a MathML-t, mivel kódja XML-ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum sok területen.

Ez a példa kód bemutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML-be:

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

**Mi pontosan exportálódik MathML-be – egy bekezdés vagy egy egyedi képletblokk?**  
Exportálhatja akár egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathblock/)) MathML-be. Mindkét típus biztosít egy metódust a MathML-be íráshoz.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e, nem pedig szokásos szöveg vagy kép?**  
Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/) belsejében él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/) objektummal. A képek és a szokásos szövegrésszek [MathParagraph] nélkül nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint-specifikus vagy egy szabvány?**  
Az export a szabványos MathML-re (XML) irányul. Az Aspose a Presentation MathML-t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a képletek exportálása táblázatokban, SmartArt-ban, csoportokban stb.?**  
Igen, ha ezek az objektumok olyan szövegrésszeket tartalmaznak, amelyeknek van [MathParagraph] (azaz valódi PowerPoint képletek), azok exportálódnak. Ha egy képlet képként van beágyazva, nem.

**Módosítja a MathML-be exportálás az eredeti prezentációt?**  
Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentáció fájlt.