---
title: Exportera matematiska ekvationer från presentationer i JavaScript
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/nodejs-java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Möjliggör smidig export av matematiska ekvationer från PowerPoint till MathML med JavaScript och Aspose.Slides för Node.js—behåll formateringen och öka kompatibiliteten."
---
## **Introduktion**

Aspose.Slides låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="primary" %}} 

Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer. 

{{% /alert %}}

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom den sistnämnda är avsedd att genereras automatiskt av applikationer. Program läser och tolkar MathML lätt eftersom dess kod är i XML, så MathML används ofta som ett utskrifts- och utskriftsformat i många områden. 

Det här exempel‑koden visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

## **Vanliga frågor**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematikstycke ([MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathblock/)) till MathML. Båda typerna erbjuder en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/) är inte exportmöjliga formler.

**Varifrån kommer MathML i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationsdelmängden av standarden—som är allmänt använd i applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Ändrar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formulans innehåll; det ändrar inte presentationsfilen.