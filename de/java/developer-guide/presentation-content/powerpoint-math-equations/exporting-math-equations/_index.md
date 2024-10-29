---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/java/exporting-math-equations/

---

## Exportieren von mathematischen Gleichungen aus Präsentationen

Aspose.Slides für Java ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 

Sie können Gleichungen in MathML exportieren, ein beliebtes Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind.

{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres dafür gedacht ist, automatisch von Anwendungen erzeugt zu werden. Programme können MathML leicht lesen und analysieren, da sein Code in XML vorliegt, sodass MathML häufig als Ausgabe- und Druckformat in vielen Bereichen verwendet wird.

Dieser Beispielcode zeigt Ihnen, wie Sie eine mathematische Gleichung aus einer Präsentation in MathML exportieren:

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