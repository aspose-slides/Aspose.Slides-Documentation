---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /de/cpp/exporting-math-equations/

---

# Exportieren von mathematischen Gleichungen aus Präsentationen

Aspose.Slides für C++ ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder auf einer anderen Plattform verwenden.

{{% alert color="primary" %}} 

Sie können Gleichungen im MathML-Format exportieren, einem beliebten Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu sehen sind. 

{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres automatisch von Apps generiert werden soll. Programme lesen und analysieren MathML problemlos, da der Code in XML vorliegt, weshalb MathML häufig als Ausgabemuster und Druckformat in vielen Bereichen verwendet wird.

Dieser Beispielcode zeigt Ihnen, wie Sie eine mathematische Gleichung aus einer Präsentation in MathML exportieren:

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