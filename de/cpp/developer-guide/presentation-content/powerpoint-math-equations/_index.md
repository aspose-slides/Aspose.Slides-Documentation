---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in C++ hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/cpp/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- mathematische Gleichung hinzufügen
- mathematisches Symbol hinzufügen
- mathematische Formel hinzufügen
- mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für C++ einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare C++-Codebeispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen im Office Math Markup Language (OMML). Mit Aspose.Slides für C++ können Sie dieselben mathematischen Inhalte programmatisch erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte Mathematikblöcke.

In PowerPoint fügen Benutzer normalerweise Gleichungen über **Einfügen > Gleichung** hinzu:

![PowerPoint Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Ein Math‑Shape, erstellt mit [AddMathShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapecollection/), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt innerhalb des Shape‑Textframes.
- [MathParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations in C++](/slides/de/cpp/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel erstellt ein Math‑Shape und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` erstellt ein Shape, das bereits einen Math‑Paragraph enthält. Greifen Sie auf das erste `MathPortion` zu, holen Sie dessen `MathParagraph` und fügen Sie Math‑Blocks oder Math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie `Divide`, um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der 1 durch x zeigt](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Für einen gestapelten Bruch verwenden Sie `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Radikale hinzufügen**

Verwenden Sie `Radical`, um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erzeugen. Das aktuelle Element wird zur Basis, das Argument zur Ordnung.

![Ein n‑te Wurzel Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie `AsArgumentOfFunction` oder `Function` für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathlimit/) oder nutzen `SetLowerLimit`.

![Der Grenzwert von x, wenn x gegen unendlich strebt](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie `Nary` für Summen, Vereinigungen, Schnittmengen und andere große Operatoren. Verwenden Sie `Integral` für Integrale. Mit beiden Methoden können Sie untere und obere Grenzen festlegen.

![Eine Summe mit unteren und oberen Grenzen](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N‑äre Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als `MathematicalText` hinzugefügt und zum Ausdruck verbunden.

Für ein Integral verwenden Sie `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher müssen Sie die Matrix bei Bedarf in runde Klammern, eckige Klammern oder geschweifte Klammern einschließen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie `ToMathArray`, wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie `AsArgumentOfFunction`, wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellungen für Indizes und Potenzen. Wenn die Indizes links von der Basis erscheinen sollen, nutzen Sie `SetSubSuperscriptOnTheLeft`.

![Ein großes Y mit linkem Tiefstellung 1 und Hochstellung n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Begrenzungszeichen hinzufügen**

Verwenden Sie `Enclose`, um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen festlegen für Begrenzungszeichen‑Ausdrücke, die mehrere Elemente enthalten.

![Ein Begrenzungszeichen‑Ausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Rahmenbox hinzufügen**

Verwenden Sie `ToBorderBox`, wenn die Gleichung selbst eingerahmt werden soll.

![Eine umrahmte Gleichung, die a² = b² + c² zeigt](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Terme gruppieren**

Verwenden Sie `Group`, um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x plus y gruppiert mit der Beschriftung irgendein Text darunter](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungs‑Hilfsfunktionen nur dort, wo sie die Formel klarer machen. Beispiel: `Overbar` setzt einen Strich über ein Math‑Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Schnellreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.Join](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/join/) |
| Brüche erstellen | [IMathElement.Divide](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Hoch‑ oder Tiefstellung hinzufügen | [SetSuperscript](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Funktionen hinzufügen | [Function](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Radikale hinzufügen | [IMathElement.Radical](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Grenzen hinzufügen | [SetLowerLimit](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Linksseitige Tief‑/Hochstellungen hinzufügen | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Summen und Integrale hinzufügen | [Nary](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [ToMathArray](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Begrenzungszeichen hinzufügen | [Enclose](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Striche und Rahmen hinzufügen | [Overbar](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Terme gruppieren | [Group](https://reference.aspose.com/slides/de/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das ein `MathPortion` enthält, holen Sie dessen `MathParagraph` und aktualisieren Sie die Math‑Blocks in diesem Paragraph.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Aspose.Slides exportiert mathematische Gleichungen nach MathML. Wenn Sie LaTeX benötigen, exportieren Sie zunächst nach MathML und konvertieren Sie das MathML anschließend mit einem Tool, das Ihr gewünschtes LaTeX‑Dialekt unterstützt.