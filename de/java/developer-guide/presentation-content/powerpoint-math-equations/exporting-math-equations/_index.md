---
title: Exportieren von mathematischen Gleichungen aus Präsentationen in Java
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/java/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entfesseln Sie den nahtlosen Export mathematischer Gleichungen von PowerPoint zu MathML mit Aspose.Slides für Java — erhalten Sie die Formatierung und steigern Sie die Kompatibilität."
---

## Exportieren von mathematischen Gleichungen aus Präsentationen

Aspose.Slides für Java ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen nach MathML exportieren, ein beliebtes Format bzw. ein Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind. 
{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da Letzteres von Anwendungen automatisch erzeugt werden soll. Programme lesen und parsen MathML leicht, weil dessen Code in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird.

Dieses Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:
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

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Bilder und normale Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) sind nicht exportierbare Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich an das standardisierte MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in zahlreichen Anwendungen und im Web verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) enthalten (d.h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; es verändert die Präsentationsdatei nicht.