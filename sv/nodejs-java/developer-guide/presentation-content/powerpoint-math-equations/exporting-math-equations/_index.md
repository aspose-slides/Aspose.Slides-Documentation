---
title: Exportera matematiska ekvationer från presentationer i JavaScript
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/nodejs-java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- exportera ekvationer till LaTeX
- PowerPoint till LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportera matematiska ekvationer från PowerPoint-presentationer till LaTeX eller MathML direkt med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

Aspose.Slides låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="primary" %}} 

Du kan exportera ekvationer direkt till LaTeX eller till MathML, en populär standard för matematiskt innehåll som används på webben och i många applikationer.

{{% /alert %}}

## **Exportera matematiska ekvationer till LaTeX**

Aspose.Slides kan konvertera en PowerPoint‑matematisk ekvation direkt till LaTeX; en mellanliggande MathML‑fil och en extern konverterare krävs inte. En matematisk ekvation lagras i en textruta som en [MathPortion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/). Använd [MathPortion.getMathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) för att hämta ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/), och anropa sedan [MathParagraph.toLatex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Metoden returnerar en sträng som du kan spara, visa, skicka till en annan applikation eller bearbeta vidare.

Följande exempel undersöker varje textruta på varje bild, hittar alla matematiska portioner och skriver varje ekvation till en separat `.tex`‑fil:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) returnerar alla textrutor som hittas på en bild. [MathPortion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/)-typkontrollen separerar äkta redigerbara ekvationer från vanlig text och bilder.

LaTeX‑motorer och dokumentmallar stödjer inte alla samma kommandon, paket eller Unicode‑tecken. Testa den returnerade strängen med LaTeX‑motorn som din applikation använder. Om en symbol eller Office‑Math‑element saknar lämplig representation i den miljön, ersätt den i den returnerade strängen med ett projektspecifikt kommando eller hoppa över ekvationen och registrera problemet för granskning.

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårigheter att skriva koden för MathML eftersom detta format är avsett att genereras automatiskt av appar. Program läser och analyserar MathML enkelt eftersom dess kod är i XML, så MathML används ofta som ett utskrifts- och exportformat inom många områden. 

Detta exempel visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

## **FAQ**

**Vad exporteras egentligen till MathML – ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathblock/)) till MathML. Båda typerna tillhandahåller en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/). Bilder och vanlig text utan ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/) är inte exporterbara formler.

**Var kommer MathML i en presentation ifrån – är det PowerPoint‑specifikt eller en standard?**

Exporten använder standard‑MathML (XML). Aspose använder Presentation MathML – presentationsdelen av standarden – som är allmänt använd i applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textportioner med ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler), exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; den ändrar inte presentationsfilen.