---
title: Exportera matematiska ekvationer från presentationer i Java
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Aktivera sömlös export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för Java—bevara formatering och öka kompatibiliteten."
---
## **Introduktion**

Aspose.Slides gör det möjligt att exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller en annan plattform. 

{{% alert color="primary" %}} 
Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer. 
{{% /alert %}}

## **Spara matematiska ekvationer som MathML**

Medan människor lätt skriver kod för vissa ekvationsformat som LaTeX, har de svårt att skriva kod för MathML eftersom det senare är avsett att genereras automatiskt av appar. Program läser och tolkar MathML enkelt eftersom dess kod är i XML, så MathML används vanligtvis som ett utdata- och utskriftsformat i många områden. 

Denna exempelkod visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

## **Vanliga frågor**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathblock/)) till MathML. Båda typerna erbjuder en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/) är inte exportbara formler.

**Var kommer MathML från i en presentation—är det PowerPoint-specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentation‑delmängden av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler inuti tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler), exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.