---
title: Hantera presentationstext i Node.js via .NET
linktitle: Hantera text
type: docs
weight: 50
url: /sv/nodejs-net/manage-text/
keywords:
- text
- textruta
- lägga till text
- ändra text
- formatera text
- teckensnittsstorlek
- fet text
- textram
- stycke
- del
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till en textruta på en bild, ändra sedan dess text, teckensnittsstorlek och feta stil i JavaScript med Aspose.Slides för Node.js via .NET."
---
## **Översikt**

I Aspose.Slides tillhör text på en bild en form. En autoform, såsom en rektangel, har en textram; textramen innehåller stycken, och varje stycke innehåller delar, som är textsekvenser med samma formatering. Du ändrar texten via textramen och teckensnittet via formatet för en del.

Den här artikeln lägger till en textruta på en bild och sparar presentationen. Den öppnar sedan den sparade filen och ändrar textrutans text, teckenstorlek och fet stil.

Exemplen kräver ett projekt uppsatt enligt beskrivningen i [Installation](/slides/sv/nodejs-net/installation/). Spara varje exempel som en `.js`-fil i projektmappen och kör den från den mappen med `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Node.js via .NET har ingen egen API-referens. Den speglar Aspose.Slides för .NET API med camelCase-namn, så API-länkarna i den här artikeln leder till motsvarande klasser och medlemmar i [Aspose.Slides för .NET API-referensen](https://reference.aspose.com/slides/sv/net/).
{{% /alert %}}

## **Lägg till en textruta**

För att lägga till en textruta, lägg till en autoform på en bild med metoden [addAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/shapecollection/addautoshape/) och ge den text med metoden [addTextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/addtextframe/). Följande exempel lägger till en rektangel på den första bilden i en ny presentation och sparar presentationen som `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Positionen (x, y) och storleken (bredd, höjd) är i punkter.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Bilden i `text-box.pptx` innehåller en rektangel, 500 punkter bred och 80 punkter hög, med texten "Quarterly report" i standardteckensnittet och -storleken. Nästa exempel ändrar denna textruta.

## **Ändra texten och dess formatering**

Följande exempel öppnar `text-box.pptx`, som föregående exempel skapade, och hämtar den första formen på den första bilden. Former såsom bilder och tabeller har ingen textram, så exemplet kontrollerar att formen är en [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) innan den använder formens [textFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/textframe/). Därefter gör den följande:

1. Den ersätter texten via [text](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/text/)-egenskapen i textramen. Därefter innehåller textramen ett stycke med en del.
2. Den hämtar den delen från samlingarna [paragraphs](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/paragraphs/) och [portions](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/portions/) och läser dess [portionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/portionformat/).
3. Den anger [fontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontheight/), teckenstorleken i punkter, och [fontBold](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontbold/), som tar ett [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/)-värde.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

I `text-box-updated.pptx` visar textrutan "Quarterly report: third quarter" i fet 32-punkts stil. Eftersom den nya texten är en enda del gäller de två formateringsegenskaperna på hela den. Utan licens läggs en utvärderingsvattenstämpel till vid varje sparning. Eftersom `text-box.pptx` själv sparades i utvärderingsläge, innehåller `text-box-updated.pptx` två; se [Evaluate Aspose.Slides](/slides/sv/nodejs-net/evaluate-aspose-slides/).

## **Vanliga frågor**

**Varför tar `fontBold` ett `NullableBool`-värde istället för `true` eller `false`?**

En del kan lämna en egenskap odefinierad och ärva den från stycket, formen eller bildens layout och master. `NullableBool.NotDefined` betyder "ärva", medan `NullableBool.True` och `NullableBool.False` åsidosätter det ärvda värdet. Att tilldela `true` eller `false` kastar ett fel. Av samma anledning returnerar `fontHeight` `NaN` när delen ärver sin teckenstorlek.

**Hur ändrar jag textfärgen?**

Ställ in fyllningen för portionsformatet: tilldela `FillType.Solid` till `portionFormat.fillFormat.fillType`, och tilldela sedan en färg, exempelvis `"#FF0000"`, till `portionFormat.fillFormat.solidFillColor.color`. Lägg till `FillType` i de namn du importerar från paketet.

**Hur formaterar jag bara en del av texten?**

Formatering hör till delar, så placera den delen av texten i en egen del. Skapa delen med `Portion.CreatePortionFromText`, lägg till den i ett stycke med `add`-metoden i styckets `portions`-samling, och ställ sedan in den nya delens `portionFormat`. Lägg till `Portion` i de namn du importerar från paketet.

**Varför returnerar läsning av text "... text has been truncated due to evaluation version limitation"?**

Utan licens returnerar Aspose.Slides endast de fem första tecknen i längre text som du läser, exempelvis `textFrame.text`, följt av detta meddelande. Text som du skriver sparas i sin helhet. Applicera en licens enligt beskrivningen i [Licensing](/slides/sv/nodejs-net/licensing/) för att läsa den kompletta texten.