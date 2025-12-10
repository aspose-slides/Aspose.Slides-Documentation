---
title: Mathematische Gleichungen aus Präsentationen in C++
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/cpp/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Ermöglichen Sie den nahtlosen Export mathematischer Gleichungen von PowerPoint nach MathML mit Aspose.Slides für C++ — bewahren Sie die Formatierung und erhöhen Sie die Kompatibilität."
---

## **Mathematische Gleichungen aus Präsentationen exportieren**

Aspose.Slides für C++ ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen in MathML exportieren, ein populäres Format bzw. einen Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu finden sind. 
{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, tun sie sich schwer damit, den Code für MathML zu erstellen, weil letzteres automatisch von Anwendungen generiert werden soll. Programme können MathML leicht lesen und analysieren, da sein Code in XML vorliegt, sodass MathML häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet wird.

Dieses Beispiel zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```


## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode, um nach MathML zu schreiben.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder ein Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textanteile ohne einen [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich nach dem Standard‑MathML (XML). Aspose verwendet Presentation MathML – die Präsentationsuntermenge des Standards –, die in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, sofern diese Objekte Textanteile mit einem [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet – sie wird nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; die Präsentationsdatei wird nicht verändert.