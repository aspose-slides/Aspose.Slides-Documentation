---
title: Exportera matematiska ekvationer från presentationer på Android
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/androidjava/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Möjliggör smidig export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för Android via Java—bevara formatering och öka kompatibiliteten."
---
## **Introduktion**

Aspose.Slides för Android via Java gör det möjligt att exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de mathematiska ekvationerna på bildspel (från en specifik presentation) och använda dem i ett annat program eller en annan plattform.

{{% alert color="primary" %}} 

Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer. 

{{% /alert %}}

## **Exportera matematiska ekvationer från presentationer**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom det senare är tänkt att genereras automatiskt av appar. Program läser och tolkar MathML enkelt eftersom koden är i XML, så MathML används ofta som ett utskrifts‑ och utskriftsformat i många områden. 

Den här exempelkoden visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

## **FAQ**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathblock/)) till MathML. Båda typerna erbjuder en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathparagraph/) är inte exportbara formler.

**Varifrån kommer MathML i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationsdelmängden av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild görs den inte.

**Ändrar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formulans innehåll; det ändrar inte presentationsfilen.