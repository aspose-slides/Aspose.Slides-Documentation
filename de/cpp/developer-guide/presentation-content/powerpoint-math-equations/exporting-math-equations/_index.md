---
title: Mathematische Gleichungen aus Präsentationen in C++ exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/cpp/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint‑Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für C++."
---
## **Einleitung**

Aspose.Slides für C++ ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="info" %}} 

Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem beliebten Standard für mathematischen Inhalt, der im Web und in vielen Anwendungen verwendet wird.

{{% /alert %}}

## **Mathematische Gleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathematikgleichung direkt nach LaTeX konvertieren; eine Zwischen‑MathML-Datei und ein externer Konverter sind nicht erforderlich. Eine mathematische Gleichung wird in einem Textfeld als ein [IMathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathportion/) gespeichert. Verwenden Sie [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/), um ein [IMathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathparagraph/) zu erhalten, und rufen Sie anschließend [IMathParagraph::ToLatex](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiter verarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld auf jeder Folie, findet alle mathematischen Abschnitte und schreibt jede Gleichung in eine separate `.tex`‑Datei:

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

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder Office‑Math‑Element in dieser Umgebung keine passende Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren das Problem zur späteren Überprüfung.

## **Mathematische Gleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da Letzteres automatisch von Anwendungen erzeugt werden soll. Programme können MathML leicht lesen und parsen, weil es in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird. 

Dieser Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/). Bilder und normale Textabschnitte ohne [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich nach dem Standard‑MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web breit eingesetzt wird.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) enthalten (d.h. echte PowerPoint‑Formeln), werden sie exportiert. Wenn eine Formel als Bild eingebettet ist, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; es verändert die Präsentationsdatei nicht.