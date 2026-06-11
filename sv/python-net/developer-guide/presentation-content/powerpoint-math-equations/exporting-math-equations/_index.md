---
title: Exportera matematiska ekvationer från presentationer i Python
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/python-net/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lås upp smidig export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för Python via .NET—bevara formatering och öka kompatibiliteten."
---
## **Introduktion**

Aspose.Slides for Python via .NET låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera ekvationer från specifika bilder och återanvända dem i ett annat program eller en annan plattform.

{{% alert color="primary" %}}
Du kan exportera ekvationer till MathML, en allmänt använd standard för att representera matematiskt innehåll på webben och i många applikationer.
{{% /alert %}}

## **Spara matematiska ekvationer som MathML**

Även om människor enkelt kan skriva LaTeX genereras MathML vanligtvis automatiskt av applikationer. Eftersom MathML är XML‑baserat kan program läsa och tolka det på ett pålitligt sätt, vilket gör att det ofta används som output‑ och utskriftsformat inom många områden.

Följande exempel kod visar hur man exporterar en matematisk ekvation från en presentation till MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Vanliga frågor**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathblock/)) till MathML. Båda typerna har en metod för att skriva till MathML.

**Hur kan jag avgöra om ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathparagraph/). Bilder och vanlig text utan ett [MathParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathparagraph/) kan inte exporteras som formler.

**Var kommer MathML från i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationsdelmängden av standarden—som är allmänt använd i applikationer och på webben.

**Stöds export av formler inuti tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.