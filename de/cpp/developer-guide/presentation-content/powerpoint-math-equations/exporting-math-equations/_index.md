---
title: Exportieren von mathematischen Gleichungen aus Präsentationen in C++
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/cpp/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Ermöglichen Sie den nahtlosen Export mathematischer Gleichungen von PowerPoint nach MathML mit Aspose.Slides für C++ — bewahren Sie die Formatierung und erhöhen Sie die Kompatibilität."
---
## **Einführung**

Aspose.Slides for C++ ermöglicht den Export von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen nach MathML exportieren, einem beliebten Format bzw. Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu finden sind. 
{{% /alert %}}

## **Math-Gleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu erstellen, da Letzteres von Anwendungen automatisch generiert werden soll. Programme lesen und parsen MathML problemlos, da der Code in XML vorliegt; daher wird MathML in vielen Bereichen häufig als Ausgabe- und Druckformat verwendet.

Dieser Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

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

**Was genau wird nach MathML exportiert - ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen stellen eine Methode zum Schreiben nach MathML bereit.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textabschnitte ohne [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation - ist es PowerPoint-spezifisch oder ein Standard?**

Der Export richtet sich an standardisiertes MathML (XML). Aspose verwendet Presentation MathML - die Präsentations-Teilmenge des Standards -, die in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint-Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, geschieht dies nicht.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.