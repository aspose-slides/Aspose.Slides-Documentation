---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/androidjava/exporting-math-equations/

---

## Exportieren von mathematischen Gleichungen aus Präsentationen

Aspose.Slides für Android über Java ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 

Sie können Gleichungen in MathML exportieren, einem beliebten Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind.

{{% /alert %}}

Während Menschen es leicht fällt, den Code für einige Gleichungsformate wie LaTeX zu schreiben, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres automatisch von Anwendungen generiert werden soll. Programme können MathML leicht lesen und analysieren, da sein Code in XML ist, weshalb MathML häufig als Ausgabe- und Druckformat in vielen Bereichen verwendet wird.

Dieser Beispiels-Code zeigt Ihnen, wie Sie eine mathematische Gleichung aus einer Präsentation in MathML exportieren:

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