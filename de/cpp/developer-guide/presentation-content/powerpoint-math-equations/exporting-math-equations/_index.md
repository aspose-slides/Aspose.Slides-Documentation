---
title: Mathegleichungen aus Präsentationen in C++
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/cpp/exporting-math-equations/
keywords:
- Mathegleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Mathegleichungen aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für C++ exportieren."
---
## **Einführung**

Aspose.Slides for C++ ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem beliebten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Mathegleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint-Mathegleichung direkt nach LaTeX konvertieren; eine Zwischendatei im MathML-Format und ein externer Konverter sind nicht erforderlich. Eine Mathegleichung wird in einem Textfeld als [IMathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathportion/) gespeichert. Verwenden Sie [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/), um ein [IMathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathparagraph/) zu erhalten, und rufen Sie dann [IMathParagraph::ToLatex](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel durchsucht jedes Textfeld auf jeder Folie, findet alle Matheabschnitte und schreibt jede Gleichung in eine separate `.tex`-Datei:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/getalltextboxes/) gibt alle auf einer Folie gefundenen Textfelder zurück. Die Typprüfung von [IMathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathportion/) trennt echte bearbeitbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math-Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren das Problem zur späteren Überprüfung.

## **Mathegleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da Letzteres automatisch von Anwendungen generiert werden soll. Programme lesen und analysieren MathML problemlos, weil sein Code in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird.

Dieser Beispielcode zeigt, wie Sie eine Mathegleichung aus einer Präsentation nach MathML exportieren:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**  
Sie können entweder einen gesamten Matheabsatz ([MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein regulärer Text oder ein Bild ist?**  
Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – PowerPoint-spezifisch oder ein Standard?**  
Der Export richtet sich an das standardmäßige MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**  
Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**  
Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie ändert die Präsentationsdatei nicht.