---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/nodejs-java/exporting-math-equations/
---

## **Exportieren von mathematischen Gleichungen aus Präsentationen**

Aspose.Slides für Node.js via Java ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen in MathML exportieren, ein beliebtes Format bzw. einen Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind. 
{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, fällt es ihnen schwer, den Code für MathML zu schreiben, weil Letzteres automatisch von Anwendungen generiert werden soll. Programme lesen und parsen MathML leicht, weil der Code in XML vorliegt, sodass MathML häufig als Ausgabe- und Druckformat in vielen Bereichen verwendet wird.

Dieses Beispiel zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation in MathML exportieren:
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

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten Mathematikabsatz ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Woran erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Bilder und normale Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) sind nicht exportierbare Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf Standard‑MathML (XML) ab. Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das breit in Anwendungen und im Web eingesetzt wird.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) enthalten (d.h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Modifiziert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.