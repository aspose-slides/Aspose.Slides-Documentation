---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/net/exporting-math-equations/
keywords: "Exportieren von mathematischen Gleichungen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Exportieren von PowerPoint-Mathematikgleichungen in C# oder .NET"
---

## **Einführung**

Aspose.Slides für .NET ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="primary" %}} 

Sie können Gleichungen nach MathML exportieren, einem weit verbreiteten Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen gesehen werden. 

{{% /alert %}}

## **Math‑Formeln als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, fällt es ihnen schwer, den Code für MathML zu schreiben, weil Letzteres automatisch von Apps generiert werden soll. Programme lesen und parsen MathML leicht, weil sein Code in XML vorliegt, sodass MathML in vielen Bereichen als Ausgabe‑ und Druckformat verwendet wird. 

Dieser Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:
```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```


## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder ein Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textportionen ohne einen [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf standardmäßiges MathML (XML). Aspose verwendet Presentation MathML – die Präsentationsuntermenge des Standards –, die in vielen Anwendungen und im Web weithin genutzt wird.

**Wird der Export von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textportionen mit einem [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Modifiziert der Export nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.