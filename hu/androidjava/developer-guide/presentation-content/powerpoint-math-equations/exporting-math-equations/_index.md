---
title: Matematika egyenletek exportálása prezentációkból Androidon
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/androidjava/exporting-math-equations/
keywords:
- matematika egyenletek exportálása
- egyenletek exportálása LaTeX-be
- PowerPoint LaTeX-be
- MathML
- LaTeX
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Exportálja a matematikai egyenleteket PowerPoint prezentációkból közvetlenül LaTeX vagy MathML formátumba az Androidra szánt Aspose.Slides for Java segítségével."
---
## **Bevezetés**

Aspose.Slides for Android via Java lehetővé teszi, hogy matematikai egyenleteket exportáljon a prezentációkból. Például előfordulhat, hogy egy adott prezentációban lévő diákon szereplő matematikai egyenleteket ki kell nyerni, és egy másik programban vagy platformon fel kell használni.

{{% alert color="info" %}} 
Közvetlenül exportálhat egyenleteket LaTeX-re vagy MathML-re, amely egy népszerű szabvány a weben és számos alkalmazásban használt matematikai tartalomhoz.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX-be**

Az Aspose.Slides képes egy PowerPoint matematikai egyenletet közvetlenül LaTeX-re konvertálni; közbenső MathML fájlra és külső konverterre nincs szükség. A matematikai egyenlet egy szövegkeretben van tárolva, mint egy [IMathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/). Használja az [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) metódust egy [IMathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathparagraph/) lekéréséhez, majd hívja az [IMathParagraph.toLatex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metódust. A metódus egy karakterláncot ad vissza, amelyet elmenthet, megjeleníthet, egy másik alkalmazásnak elküldhet, vagy tovább feldolgozhat.

A következő példa minden szövegkeretet vizsgál minden dián, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) visszaadja az összes szövegkeretet, amely a dián megtalálható. Az [IMathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathportion/) típusellenőrzés szétválasztja a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Ellenőrizze a visszakapott karakterláncot a alkalmazása által használt LaTeX motorral. Ha egy szimbólum vagy Office Math elem nincs megfelelő ábrázolása abban a környezetben, cserélje le a visszakapott karakterláncban egy projektspecifikus parancsra, vagy hagyja ki az egyenletet, és jegyezze fel a problémát a felülvizsgálathoz.

## **Matematikai egyenletek mentése MathML-ként**

Míg az emberek egyszerűen írják a kódot egyes egyenletformátumokhoz, például a LaTeX-hez, nehezebb nekik a MathML kód írása, mivel az utóbbit alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és dolgozzák fel a MathML-t, mivel kódja XML-ben van, ezért a MathML gyakran használatos kimeneti és nyomtatási formátumként sok területen. 

Ez a példa kód megmutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML-re:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**Mi pontosan exportálódik MathML-be – bekezdés vagy egyéni képletblokk?**

Exportálhatja akár egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)) akár egy egyéni blokkot ([MathBlock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathblock/)) MathML-be. Mindkét típus biztosít egy módszert a MathML-be íráshoz.

**Hogyan tudom megmondani, hogy egy dián lévő objektum matematikai képlet-e a szokásos szöveg vagy kép helyett?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathportion/)‑ban él, és van egy [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/). Képek és szokásos szövegrészek, amelyeknek nincs [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)‑ja, nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabvány?**

Az export célja a szabványos MathML (XML). Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a képletek exportálása táblázatokba, SmartArt‑ba, csoportokba stb.?**

Igen, ha ezek az objektumok tartalmaznak szövegrészeket egy [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/)‑nal (azaz valódi PowerPoint képletek), akkor exportálódnak. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja a MathML‑be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentációs fájlt.