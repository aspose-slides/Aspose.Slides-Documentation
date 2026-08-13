---
title: "Mathematische Gleichungen aus Präsentationen in .NET exportieren"
linktitle: "Gleichungen exportieren"
type: docs
weight: 30
url: /de/net/exporting-math-equations/
keywords:
- "Mathematische Gleichungen exportieren"
- "Gleichungen nach LaTeX exportieren"
- "PowerPoint nach LaTeX"
- "MathML"
- "LaTeX"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint‑Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für .NET."
---
## **Einführung**

Aspose.Slides für .NET ermöglicht den Export mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="info" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem weit verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Mathematische Gleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathematikgleichung direkt nach LaTeX konvertieren; eine Zwischen‑MathML‑Datei und ein externer Konverter sind nicht erforderlich. Eine Mathematikgleichung wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) gespeichert. Verwenden Sie [MathPortion.MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/mathparagraph/) um ein [IMathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/imathparagraph/) zu erhalten und rufen Sie dann [IMathParagraph.ToLatex](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/imathparagraph/tolatex/) auf. Die Methode gibt eine Zeichenfolge zurück, die Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld auf jeder Folie, findet alle MathPortionen und schreibt jede Gleichung in eine separate `.tex`‑Datei:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/getalltextboxes/) gibt alle auf einer Folie gefundenen Textfelder zurück. Die Typprüfung von [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) trennt echte editierbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie die zurückgegebene Zeichenfolge mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es in der zurückgegebenen Zeichenfolge durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren Sie das Problem zur Überprüfung.

## **Mathematische Gleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da Letzteres dazu gedacht ist, automatisch von Anwendungen erzeugt zu werden. Programme können MathML leicht lesen und parsen, weil sein Code in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird. 

Dieses Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

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

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelkasten?**

Sie können entweder einen gesamten Mathematik‑Absatz ([MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder ein Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textportionen ohne einen [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich nach standard‑konformem MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textportionen mit einem [MathParagraph](https://reference.aspose.com/slides/de/net/aspose.slides.mathtext/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Wenn eine Formel als Bild eingebettet ist, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.