---
title: Exportera matematiska ekvationer från presentationer i Java
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- exportera ekvationer till LaTeX
- PowerPoint till LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Exportera matematiska ekvationer från PowerPoint-presentationer till LaTeX eller MathML direkt med Aspose.Slides för Java."
---
## **Introduktion**

Aspose.Slides låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller en annan plattform. 

{{% alert color="info" %}} 
Du kan exportera ekvationer direkt till LaTeX eller till MathML, en populär standard för matematiskt innehåll som används på webben och i många applikationer.
{{% /alert %}}

## **Exportera matematiska ekvationer till LaTeX**

Aspose.Slides kan konvertera en PowerPoint-matematikekvation direkt till LaTeX; en mellanliggande MathML-fil och en extern konverterare krävs inte. En matematikekvation lagras i en textram som en [IMathPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imathportion/). Använd [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imathportion/#getMathParagraph--) för att få ett [IMathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imathparagraph/), och anropa sedan [IMathParagraph.toLatex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imathparagraph/#toLatex--). Metoden returnerar en sträng som du kan spara, visa, skicka till en annan applikation eller bearbeta vidare.

Följande exempel granskar varje textram på varje bild, hittar alla matematiska delar och skriver varje ekvation till en separat `.tex`-fil:

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
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) returnerar alla textramar som hittas på en bild. Typkontrollen för [IMathPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imathportion/) separerar faktiska redigerbara ekvationer från vanlig text och bilder.

LaTeX-motorer och dokumentmallar stödjer inte alla samma kommandon, paket eller Unicode-tecken. Testa den returnerade strängen med den LaTeX-motor som din applikation använder. Om en symbol eller Office Math‑element saknar lämplig representation i den miljön, ersätt den i den returnerade strängen med ett projektspecifikt kommando eller hoppa över ekvationen och registrera problemet för granskning.

## **Spara matematiska ekvationer som MathML**

Även om människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårigheter att skriva koden för MathML eftersom den senare är avsedd att genereras automatiskt av appar. Program läser och parsar MathML enkelt eftersom dess kod är i XML, så MathML används ofta som ett utdata- och utskriftsformat inom många områden. 

Den här exempelkoden visar hur du exporterar en matematikekvation från en presentation till MathML:

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

## **FAQ**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathblock/)) till MathML. Båda typerna tillhandahåller en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematikformel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/) är inte exporterbara formler.

**Varifrån kommer MathML i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentation‑delen av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler inuti tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild görs den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formulans innehåll; det ändrar inte presentationsfilen.