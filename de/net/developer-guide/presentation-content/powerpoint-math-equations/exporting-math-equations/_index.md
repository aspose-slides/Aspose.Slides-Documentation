---
title: Mathematische Gleichungen aus Präsentationen in .NET exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/net/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Mathematische Gleichungen aus PowerPoint‑Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für .NET exportieren."
---
## **Einleitung**

Aspose.Slides für .NET ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="primary" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Exportieren von mathematischen Gleichungen nach LaTeX**

Aspose.Slides kann eine PowerPoint-Mathematikgleichung direkt nach LaTeX konvertieren; eine Zwischen-MathML-Datei und ein externer Konverter sind nicht erforderlich. Eine Mathematikgleichung wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) gespeichert. Verwenden Sie [MathPortion.MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/mathparagraph/), um ein [IMathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/imathparagraph/) zu erhalten, und rufen Sie anschließend [IMathParagraph.ToLatex](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/imathparagraph/tolatex/) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiter verarbeiten können.

Das folgende Beispiel prüft jedes Textfeld auf jeder Folie, findet alle MathPortionen und schreibt jede Gleichung in eine separate `.tex`‑Datei:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/getalltextboxes/) gibt alle Textfelder zurück, die auf einer Folie gefunden werden. Die Typüberprüfung von [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) trennt echte editierbare Gleichungen von normalem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren das Problem zur Überprüfung.

## **Speichern von mathematischen Gleichungen als MathML**

Obwohl Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, fällt es ihnen schwer, den Code für MathML zu schreiben, da Letzteres automatisch von Anwendungen generiert werden soll. Programme lesen und analysieren MathML problemlos, weil sein Code in XML vorliegt, weshalb MathML häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet wird.

Dieser Beispielcode zeigt, wie man eine Mathematikgleichung aus einer Präsentation nach MathML exportiert:

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

**Was genau nach MathML exportiert wird – ein Absatz oder ein einzelner Formelblock?**  
Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**  
Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textportionen ohne einen [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**  
Der Export zielt auf standardmäßiges MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln innerhalb von Tabellen, SmartArt, Gruppen usw. unterstützt?**  
Ja, wenn diese Objekte Textportionen mit einem [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**  
Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.