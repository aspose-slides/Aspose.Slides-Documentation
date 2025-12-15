---
title: Math‑Gleichungen aus Präsentationen auf Android exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/androidjava/exporting-math-equations/
keywords:
- Math‑Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Ermöglichen Sie einen nahtlosen Export von mathematischen Gleichungen aus PowerPoint nach MathML mit Aspose.Slides für Android via Java – bewahren Sie die Formatierung und erhöhen Sie die Kompatibilität."
---

## **Mathematische Gleichungen aus Präsentationen exportieren**

Aspose.Slides für Android über Java ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen nach MathML exportieren, einem beliebten Format bzw. Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind. 
{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres von Anwendungen automatisch erzeugt werden soll. Programme lesen und analysieren MathML problemlos, weil dessen Code in XML vorliegt; daher wird MathML in vielen Bereichen häufig als Ausgabe- und Druckformat verwendet.

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

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein regulärer Text oder Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Bilder und reguläre Textbereiche ohne einen [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation – PowerPoint-spezifisch oder ein Standard?**

Der Export richtet sich nach dem standardisierten MathML (XML). Aspose verwendet Presentation MathML – die Präsentationsuntermenge des Standards –, die in vielen Anwendungen und im Web verbreitet ist.

**Wird das Exportieren von Formeln innerhalb von Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textbereiche mit einem [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) enthalten (d. h. echte PowerPoint-Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.