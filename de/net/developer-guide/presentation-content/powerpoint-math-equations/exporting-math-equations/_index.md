---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/net/exporting-math-equations/
keywords: "Mathematische Gleichungen exportieren, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Exportieren von PowerPoint mathematischen Gleichungen in C# oder .NET"
---

Aspose.Slides für .NET ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder auf einer anderen Plattform verwenden.

{{% alert color="primary" %}} 

Sie können Gleichungen in MathML exportieren, einem beliebten Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind. 

{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres automatisch von Apps generiert werden soll. Programme lesen und parsen MathML problemlos, da dessen Code in XML geschrieben ist, weshalb MathML häufig als Aus- und Druckformat in vielen Bereichen verwendet wird.

Dieser Beispielcode zeigt Ihnen, wie Sie eine mathematische Gleichung aus einer Präsentation in MathML exportieren:

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