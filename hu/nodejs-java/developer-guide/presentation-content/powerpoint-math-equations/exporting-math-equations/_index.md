---
title: Matematikai egyenletek exportálása prezentációkból JavaScriptben
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/nodejs-java/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- egyenletek exportálása LaTeX-be
- PowerPoint LaTeX-be
- MathML
- LaTeX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Matematikai egyenleteket exportálhat közvetlenül PowerPoint prezentációkból LaTeX-be vagy MathML-be az Aspose.Slides for Node.js segítségével Java használatával."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy matematikai egyenleteket exportáljon a bemutatókból. Például előfordulhat, hogy ki kell nyernie a diákon (egy adott bemutatóból) található matematikai egyenleteket, és egy másik programban vagy platformon kell felhasználnia őket.

{{% alert color="primary" %}} 
Egyenleteket közvetlenül exportálhat LaTeX-be vagy MathML-be, amely a weben és számos alkalmazásban használt népszerű szabvány a matematikai tartalomra.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX-be**

Az Aspose.Slides közvetlenül képes egy PowerPoint matematikai egyenletet LaTeX-be konvertálni; köztes MathML-fájlra és külső konverterre nincs szükség. A matematikai egyenlet szövegkeretben tárolódik, mint egy [MathPortion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathportion/). Használja a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) metódust egy [MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/) megszerzéséhez, majd hívja meg a [MathParagraph.toLatex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/#toLatex--) metódust. A metódus egy karakterláncot ad vissza, amelyet elmenthet, megjeleníthet, elküldhet egy másik alkalmazásnak, vagy tovább feldolgozhat.

A következő példa minden dián minden szövegkeretet vizsgál, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) visszaadja a dián található összes szövegkeretet. A [MathPortion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathportion/) típusellenőrzés elválasztja a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszaadott karakterláncot az alkalmazásában használt LaTeX motorral. Ha egy szimbólum vagy Office Math elem nem rendelkezik megfelelő ábrázolással az adott környezetben, cserélje ki a visszaadott karakterláncban egy projektspecifikus paranccsal, vagy hagyja ki az egyenletet, és rögzítse a problémát felülvizsgálatra.

## **Matematikai egyenletek mentése MathML-ként**

Míg az emberek könnyen képesek kódot írni bizonyos egyenletformátumokhoz, például a LaTeX-hez, a MathML kódírása nehézséget jelent, mivel azt alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és dolgozzák fel a MathML-t, mivel a kódja XML-ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum sok területen.

Ez a mintakód megmutatja, hogyan exportálhat egy matematikai egyenletet egy bemutatóból MathML-be:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mi kerül pontosan exportálásra MathML-be—egy bekezdés vagy egy egyedi képletblokk?**  
Exportálhat egy egész matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathblock/)) MathML-be. Mindkét típus biztosít egy módszert a MathML-be íráshoz.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e, és nem egyszerű szöveg vagy kép?**  
Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathportion/)-ban él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mathparagraph/)-rel. A képek és a szokásos szövegrészek, amelyeknek nincs [MathParagraph] kapcsolata, nem exportálható képletek.

**Honnan származik a MathML egy bemutatóban—PowerPoint-specifikus vagy szabványos?**  
Az export a szabványos MathML-re (XML) irányul. Az Aspose a Presentation MathML-t használja—a szabvány bemutató alhalmazát—amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a képletek exportálása táblázatok, SmartArt, csoportok stb. belsejéből?**  
Igen, ha ezekben az objektumokban olyan szövegrészek találhatók, amelyek rendelkeznek [MathParagraph]-lel (azaz valódi PowerPoint képletek), akkor exportálódnak. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja a MathML-be exportálás az eredeti bemutatót?**  
Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a bemutató fájlt.