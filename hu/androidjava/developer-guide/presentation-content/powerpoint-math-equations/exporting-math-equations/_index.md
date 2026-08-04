---
title: Matematikai egyenletek exportálása bemutatókból Androidon
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/androidjava/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- egyenletek exportálása LaTeX-be
- PowerPoint LaTeX-be
- MathML
- LaTeX
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Exportálja a matematikai egyenleteket PowerPoint bemutatókból közvetlenül LaTeX vagy MathML formátumba az Aspose.Slides for Android via Java segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy matematikai egyenleteket exportáljon a bemutatókból. Például előfordulhat, hogy ki szeretné nyerni a diákon (egy adott bemutatóból) lévő matematikai egyenleteket, és egy másik programban vagy platformon használja fel őket.

{{% alert color="primary" %}} 
Közvetlenül exportálhatja az egyenleteket LaTeX‑be vagy MathML‑be, amely egy népszerű szabvány a weben és sok alkalmazásban használt matematikai tartalomhoz.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX‑be**

Az Aspose.Slides képes a PowerPoint matematikai egyenletet közvetlenül LaTeX‑be konvertálni; köztes MathML fájlra vagy külső konverterre nincs szükség. A matematikai egyenlet szövegkeretben van tárolva egy [IMathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/) formájában. Használja a [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) metódust egy [IMathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathparagraph/) lekéréséhez, majd hívja a [IMathParagraph.toLatex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metódust. A metódus egy karakterláncot ad vissza, amelyet elmenthet, megjeleníthet, egy másik alkalmazásnak küldhet, vagy további feldolgozásra használhat.

A következő példa minden szövegkeretet vizsgál minden dián, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:
```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) visszaadja a dián megtalált összes szövegkeretet. Az [IMathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/) típusellenőrzés elkülöníti a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszakapott karakterláncot az alkalmazásában használt LaTeX motorral. Ha egy szimbólumnak vagy Office Math elemnek nincs megfelelő ábrázolása az adott környezetben, cserélje le a visszakapott karakterláncban egy projektspecifikus parancsra, vagy hagyja ki az egyenletet, és rögzítse a problémát felülvizsgálatra.

## **Matematikai egyenletek mentése MathML‑ként**

Míg az emberek könnyen megírják a kódot bizonyos egyenletformátumokhoz, például a LaTeX‑hez, nehezebben tudnak MathML kódot írni, mivel az utóbbit alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és elemezhetik a MathML‑t, mert a kódja XML‑ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum sok területen.

Ez a példa kód megmutatja, hogyan exportálhat egy matematikai egyenletet egy bemutatóból MathML‑be:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Pontosan mi exportálódik MathML‑be – egy bekezdés vagy egy egyedi képletblokk?**

Exportálhat akár egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)), akár egy egyedi blokkokat ([MathBlock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathblock/)) MathML‑be. Mindkét típus biztosít egy módszert a MathML‑be íráshoz.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e, nem pedig hagyományos szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathportion/)‑ben él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)‑val. A képek és a szokásos szövegrészek, amelyeknek nincs [MathParagraph]‑juk, nem exportálható képletek.

**Honnan származik a MathML egy bemutatóban – PowerPoint‑specifikus vagy szabványos?**

Az export a szabványos MathML‑re (XML) irányul. Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a képletek exportálása táblázatok, SmartArt, csoportok stb. belsejéből?**

Igen, ha ezek az objektumok olyan szövegrészeket tartalmaznak, amelyek rendelkeznek [MathParagraph]‑sal (azaz valódi PowerPoint képletek), akkor exportálásra kerülnek. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja a MathML‑be exportálás az eredeti bemutatót?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a bemutató fájlt.